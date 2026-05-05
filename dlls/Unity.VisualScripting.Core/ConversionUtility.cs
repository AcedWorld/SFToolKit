using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000CF RID: 207
	public static class ConversionUtility
	{
		// Token: 0x06000508 RID: 1288 RVA: 0x0000B335 File Offset: 0x00009535
		private static bool RespectsIdentity(Type source, Type destination)
		{
			return source == destination;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000B33E File Offset: 0x0000953E
		private static bool IsUpcast(Type source, Type destination)
		{
			return destination.IsAssignableFrom(source);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0000B347 File Offset: 0x00009547
		private static bool IsDowncast(Type source, Type destination)
		{
			return source.IsAssignableFrom(destination);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000B350 File Offset: 0x00009550
		private static bool ExpectsString(Type source, Type destination)
		{
			return destination == typeof(string);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0000B362 File Offset: 0x00009562
		public static bool HasImplicitNumericConversion(Type source, Type destination)
		{
			return ConversionUtility.implicitNumericConversions.ContainsKey(source) && ConversionUtility.implicitNumericConversions[source].Contains(destination);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000B384 File Offset: 0x00009584
		public static bool HasExplicitNumericConversion(Type source, Type destination)
		{
			return ConversionUtility.explicitNumericConversions.ContainsKey(source) && ConversionUtility.explicitNumericConversions[source].Contains(destination);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0000B3A6 File Offset: 0x000095A6
		public static bool HasNumericConversion(Type source, Type destination)
		{
			return ConversionUtility.HasImplicitNumericConversion(source, destination) || ConversionUtility.HasExplicitNumericConversion(source, destination);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0000B3BC File Offset: 0x000095BC
		private static IEnumerable<MethodInfo> FindUserDefinedConversionMethods(ConversionUtility.ConversionQuery query)
		{
			Type source = query.source;
			Type destination = query.destination;
			IEnumerable<MethodInfo> first = from m in source.GetMethods(BindingFlags.Static | BindingFlags.Public)
			where m.IsUserDefinedConversion()
			select m;
			IEnumerable<MethodInfo> second = from m in destination.GetMethods(BindingFlags.Static | BindingFlags.Public)
			where m.IsUserDefinedConversion()
			select m;
			return from m in first.Concat(second)
			where m.GetParameters()[0].ParameterType.IsAssignableFrom(source) || source.IsAssignableFrom(m.GetParameters()[0].ParameterType)
			select m;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0000B458 File Offset: 0x00009658
		private static MethodInfo[] GetUserDefinedConversionMethods(Type source, Type destination)
		{
			ConversionUtility.ConversionQuery conversionQuery = new ConversionUtility.ConversionQuery(source, destination);
			if (!ConversionUtility.userConversionMethodsCache.ContainsKey(conversionQuery))
			{
				ConversionUtility.userConversionMethodsCache.Add(conversionQuery, ConversionUtility.FindUserDefinedConversionMethods(conversionQuery).ToArray<MethodInfo>());
			}
			return ConversionUtility.userConversionMethodsCache[conversionQuery];
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0000B49C File Offset: 0x0000969C
		private static ConversionUtility.ConversionType GetUserDefinedConversionType(Type source, Type destination)
		{
			MethodInfo[] userDefinedConversionMethods = ConversionUtility.GetUserDefinedConversionMethods(source, destination);
			MethodInfo methodInfo = userDefinedConversionMethods.FirstOrDefault((MethodInfo m) => m.ReturnType == destination);
			if (methodInfo != null)
			{
				if (methodInfo.Name == "op_Implicit")
				{
					return ConversionUtility.ConversionType.UserDefinedImplicit;
				}
				if (methodInfo.Name == "op_Explicit")
				{
					return ConversionUtility.ConversionType.UserDefinedExplicit;
				}
			}
			else if (destination.IsPrimitive && destination != typeof(IntPtr) && destination != typeof(UIntPtr))
			{
				methodInfo = userDefinedConversionMethods.FirstOrDefault((MethodInfo m) => ConversionUtility.HasImplicitNumericConversion(m.ReturnType, destination));
				if (methodInfo != null)
				{
					if (methodInfo.Name == "op_Implicit")
					{
						return ConversionUtility.ConversionType.UserDefinedThenNumericImplicit;
					}
					if (methodInfo.Name == "op_Explicit")
					{
						return ConversionUtility.ConversionType.UserDefinedThenNumericExplicit;
					}
				}
				else
				{
					methodInfo = userDefinedConversionMethods.FirstOrDefault((MethodInfo m) => ConversionUtility.HasExplicitNumericConversion(m.ReturnType, destination));
					if (methodInfo != null)
					{
						return ConversionUtility.ConversionType.UserDefinedThenNumericExplicit;
					}
				}
			}
			return ConversionUtility.ConversionType.Impossible;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000B5AD File Offset: 0x000097AD
		private static bool HasEnumerableToArrayConversion(Type source, Type destination)
		{
			return source != typeof(string) && typeof(IEnumerable).IsAssignableFrom(source) && destination.IsArray && destination.GetArrayRank() == 1;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0000B5E8 File Offset: 0x000097E8
		private static bool HasEnumerableToListConversion(Type source, Type destination)
		{
			return source != typeof(string) && typeof(IEnumerable).IsAssignableFrom(source) && destination.IsGenericType && destination.GetGenericTypeDefinition() == typeof(List<>);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0000B638 File Offset: 0x00009838
		private static bool HasUnityHierarchyConversion(Type source, Type destination)
		{
			if (destination == typeof(GameObject))
			{
				return typeof(Component).IsAssignableFrom(source);
			}
			return (typeof(Component).IsAssignableFrom(destination) || destination.IsInterface) && (source == typeof(GameObject) || typeof(Component).IsAssignableFrom(source));
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0000B6A8 File Offset: 0x000098A8
		private static bool IsValidConversion(ConversionUtility.ConversionType conversionType, bool guaranteed)
		{
			return conversionType != ConversionUtility.ConversionType.Impossible && (!guaranteed || conversionType != ConversionUtility.ConversionType.Downcast);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000B6B9 File Offset: 0x000098B9
		public static bool CanConvert(object value, Type type, bool guaranteed)
		{
			return ConversionUtility.IsValidConversion(ConversionUtility.GetRequiredConversion(value, type), guaranteed);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0000B6C8 File Offset: 0x000098C8
		public static bool CanConvert(Type source, Type destination, bool guaranteed)
		{
			return ConversionUtility.IsValidConversion(ConversionUtility.GetRequiredConversion(source, destination), guaranteed);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0000B6D7 File Offset: 0x000098D7
		public static object Convert(object value, Type type)
		{
			return ConversionUtility.Convert(value, type, ConversionUtility.GetRequiredConversion(value, type));
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0000B6E7 File Offset: 0x000098E7
		public static T Convert<T>(object value)
		{
			return (T)((object)ConversionUtility.Convert(value, typeof(T)));
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0000B700 File Offset: 0x00009900
		public static bool TryConvert(object value, Type type, out object result, bool guaranteed)
		{
			ConversionUtility.ConversionType requiredConversion = ConversionUtility.GetRequiredConversion(value, type);
			if (ConversionUtility.IsValidConversion(requiredConversion, guaranteed))
			{
				result = ConversionUtility.Convert(value, type, requiredConversion);
				return true;
			}
			result = value;
			return false;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000B730 File Offset: 0x00009930
		public static bool TryConvert<T>(object value, out T result, bool guaranteed)
		{
			object obj;
			if (ConversionUtility.TryConvert(value, typeof(T), out obj, guaranteed))
			{
				result = (T)((object)obj);
				return true;
			}
			result = default(T);
			return false;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0000B768 File Offset: 0x00009968
		public static bool IsConvertibleTo(this Type source, Type destination, bool guaranteed)
		{
			return ConversionUtility.CanConvert(source, destination, guaranteed);
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000B772 File Offset: 0x00009972
		public static bool IsConvertibleTo(this object source, Type type, bool guaranteed)
		{
			return ConversionUtility.CanConvert(source, type, guaranteed);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0000B77C File Offset: 0x0000997C
		public static bool IsConvertibleTo<T>(this object source, bool guaranteed)
		{
			return ConversionUtility.CanConvert(source, typeof(T), guaranteed);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0000B78F File Offset: 0x0000998F
		public static object ConvertTo(this object source, Type type)
		{
			return ConversionUtility.Convert(source, type);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0000B798 File Offset: 0x00009998
		public static T ConvertTo<T>(this object source)
		{
			return (T)((object)ConversionUtility.Convert(source, typeof(T)));
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000B7B0 File Offset: 0x000099B0
		public static ConversionUtility.ConversionType GetRequiredConversion(Type source, Type destination)
		{
			ConversionUtility.ConversionQuery conversionQuery = new ConversionUtility.ConversionQuery(source, destination);
			ConversionUtility.ConversionType conversionType;
			if (!ConversionUtility.conversionTypesCache.TryGetValue(conversionQuery, out conversionType))
			{
				conversionType = ConversionUtility.DetermineConversionType(conversionQuery);
				ConversionUtility.conversionTypesCache.Add(conversionQuery, conversionType);
			}
			return conversionType;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0000B7EC File Offset: 0x000099EC
		private static ConversionUtility.ConversionType DetermineConversionType(ConversionUtility.ConversionQuery query)
		{
			Type source = query.source;
			Type destination = query.destination;
			if (source == null)
			{
				if (destination.IsNullable())
				{
					return ConversionUtility.ConversionType.Identity;
				}
				return ConversionUtility.ConversionType.Impossible;
			}
			else
			{
				Ensure.That("destination").IsNotNull<Type>(destination);
				if (ConversionUtility.RespectsIdentity(source, destination))
				{
					return ConversionUtility.ConversionType.Identity;
				}
				if (ConversionUtility.IsUpcast(source, destination))
				{
					return ConversionUtility.ConversionType.Upcast;
				}
				if (ConversionUtility.IsDowncast(source, destination))
				{
					return ConversionUtility.ConversionType.Downcast;
				}
				if (ConversionUtility.HasImplicitNumericConversion(source, destination))
				{
					return ConversionUtility.ConversionType.NumericImplicit;
				}
				if (ConversionUtility.HasExplicitNumericConversion(source, destination))
				{
					return ConversionUtility.ConversionType.NumericExplicit;
				}
				if (ConversionUtility.HasUnityHierarchyConversion(source, destination))
				{
					return ConversionUtility.ConversionType.UnityHierarchy;
				}
				if (ConversionUtility.HasEnumerableToArrayConversion(source, destination))
				{
					return ConversionUtility.ConversionType.EnumerableToArray;
				}
				if (ConversionUtility.HasEnumerableToListConversion(source, destination))
				{
					return ConversionUtility.ConversionType.EnumerableToList;
				}
				ConversionUtility.ConversionType userDefinedConversionType = ConversionUtility.GetUserDefinedConversionType(source, destination);
				if (userDefinedConversionType != ConversionUtility.ConversionType.Impossible)
				{
					return userDefinedConversionType;
				}
				return ConversionUtility.ConversionType.Impossible;
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0000B895 File Offset: 0x00009A95
		public static ConversionUtility.ConversionType GetRequiredConversion(object value, Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			return ConversionUtility.GetRequiredConversion((value != null) ? value.GetType() : null, type);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000B8B9 File Offset: 0x00009AB9
		private static object NumericConversion(object value, Type type)
		{
			return System.Convert.ChangeType(value, type);
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0000B8C4 File Offset: 0x00009AC4
		private static object UserDefinedConversion(ConversionUtility.ConversionType conversion, object value, Type type)
		{
			MethodInfo[] userDefinedConversionMethods = ConversionUtility.GetUserDefinedConversionMethods(value.GetType(), type);
			bool flag = conversion == ConversionUtility.ConversionType.UserDefinedThenNumericImplicit || conversion == ConversionUtility.ConversionType.UserDefinedThenNumericExplicit;
			MethodInfo methodInfo = null;
			if (flag)
			{
				foreach (MethodInfo methodInfo2 in userDefinedConversionMethods)
				{
					if (ConversionUtility.HasNumericConversion(methodInfo2.ReturnType, type))
					{
						methodInfo = methodInfo2;
						break;
					}
				}
			}
			else
			{
				foreach (MethodInfo methodInfo3 in userDefinedConversionMethods)
				{
					if (methodInfo3.ReturnType == type)
					{
						methodInfo = methodInfo3;
						break;
					}
				}
			}
			object obj = methodInfo.InvokeOptimized(null, value);
			if (flag)
			{
				obj = ConversionUtility.NumericConversion(obj, type);
			}
			return obj;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0000B96C File Offset: 0x00009B6C
		private static object EnumerableToArrayConversion(object value, Type arrayType)
		{
			Type elementType = arrayType.GetElementType();
			object[] array = ((IEnumerable)value).Cast<object>().Where(new Func<object, bool>(elementType.IsAssignableFrom)).ToArray<object>();
			Array array2 = Array.CreateInstance(elementType, array.Length);
			array.CopyTo(array2, 0);
			return array2;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		private static object EnumerableToListConversion(object value, Type listType)
		{
			Type @object = listType.GetGenericArguments()[0];
			object[] array = ((IEnumerable)value).Cast<object>().Where(new Func<object, bool>(@object.IsAssignableFrom)).ToArray<object>();
			IList list = (IList)Activator.CreateInstance(listType);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			return list;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0000BA18 File Offset: 0x00009C18
		private static object UnityHierarchyConversion(object value, Type type)
		{
			if (value.IsUnityNull())
			{
				return null;
			}
			if (type == typeof(GameObject) && value is Component)
			{
				return ((Component)value).gameObject;
			}
			if (typeof(Component).IsAssignableFrom(type) || type.IsInterface)
			{
				if (value is Component)
				{
					return ((Component)value).GetComponent(type);
				}
				if (value is GameObject)
				{
					return ((GameObject)value).GetComponent(type);
				}
			}
			throw new InvalidConversionException();
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0000BAA0 File Offset: 0x00009CA0
		private static object Convert(object value, Type type, ConversionUtility.ConversionType conversionType)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			if (conversionType == ConversionUtility.ConversionType.Impossible)
			{
				throw new InvalidConversionException(string.Format("Cannot convert from '{0}' to '{1}'.", ((value != null) ? value.GetType().ToString() : null) ?? "null", type));
			}
			object result;
			try
			{
				switch (conversionType)
				{
				case ConversionUtility.ConversionType.Identity:
				case ConversionUtility.ConversionType.Upcast:
				case ConversionUtility.ConversionType.Downcast:
					result = value;
					break;
				case ConversionUtility.ConversionType.NumericImplicit:
				case ConversionUtility.ConversionType.NumericExplicit:
					result = ConversionUtility.NumericConversion(value, type);
					break;
				case ConversionUtility.ConversionType.UserDefinedImplicit:
				case ConversionUtility.ConversionType.UserDefinedExplicit:
				case ConversionUtility.ConversionType.UserDefinedThenNumericImplicit:
				case ConversionUtility.ConversionType.UserDefinedThenNumericExplicit:
					result = ConversionUtility.UserDefinedConversion(conversionType, value, type);
					break;
				case ConversionUtility.ConversionType.UnityHierarchy:
					result = ConversionUtility.UnityHierarchyConversion(value, type);
					break;
				case ConversionUtility.ConversionType.EnumerableToArray:
					result = ConversionUtility.EnumerableToArrayConversion(value, type);
					break;
				case ConversionUtility.ConversionType.EnumerableToList:
					result = ConversionUtility.EnumerableToListConversion(value, type);
					break;
				case ConversionUtility.ConversionType.ToString:
					result = value.ToString();
					break;
				default:
					throw new UnexpectedEnumValueException<ConversionUtility.ConversionType>(conversionType);
				}
			}
			catch (Exception innerException)
			{
				throw new InvalidConversionException(string.Format("Failed to convert from '{0}' to '{1}' via {2}.", ((value != null) ? value.GetType().ToString() : null) ?? "null", type, conversionType), innerException);
			}
			return result;
		}

		// Token: 0x04000123 RID: 291
		private const BindingFlags UserDefinedBindingFlags = BindingFlags.Static | BindingFlags.Public;

		// Token: 0x04000124 RID: 292
		private static readonly Dictionary<ConversionUtility.ConversionQuery, ConversionUtility.ConversionType> conversionTypesCache = new Dictionary<ConversionUtility.ConversionQuery, ConversionUtility.ConversionType>(default(ConversionUtility.ConversionQueryComparer));

		// Token: 0x04000125 RID: 293
		private static readonly Dictionary<ConversionUtility.ConversionQuery, MethodInfo[]> userConversionMethodsCache = new Dictionary<ConversionUtility.ConversionQuery, MethodInfo[]>(default(ConversionUtility.ConversionQueryComparer));

		// Token: 0x04000126 RID: 294
		private static readonly Dictionary<Type, HashSet<Type>> implicitNumericConversions = new Dictionary<Type, HashSet<Type>>
		{
			{
				typeof(sbyte),
				new HashSet<Type>
				{
					typeof(byte),
					typeof(int),
					typeof(long),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(byte),
				new HashSet<Type>
				{
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(ulong),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(short),
				new HashSet<Type>
				{
					typeof(int),
					typeof(long),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(ushort),
				new HashSet<Type>
				{
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(ulong),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(int),
				new HashSet<Type>
				{
					typeof(long),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(uint),
				new HashSet<Type>
				{
					typeof(long),
					typeof(ulong),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(long),
				new HashSet<Type>
				{
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(char),
				new HashSet<Type>
				{
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(ulong),
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			},
			{
				typeof(float),
				new HashSet<Type>
				{
					typeof(double)
				}
			},
			{
				typeof(ulong),
				new HashSet<Type>
				{
					typeof(float),
					typeof(double),
					typeof(decimal)
				}
			}
		};

		// Token: 0x04000127 RID: 295
		private static readonly Dictionary<Type, HashSet<Type>> explicitNumericConversions = new Dictionary<Type, HashSet<Type>>
		{
			{
				typeof(sbyte),
				new HashSet<Type>
				{
					typeof(byte),
					typeof(ushort),
					typeof(uint),
					typeof(ulong),
					typeof(char)
				}
			},
			{
				typeof(byte),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(char)
				}
			},
			{
				typeof(short),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(ushort),
					typeof(uint),
					typeof(ulong),
					typeof(char)
				}
			},
			{
				typeof(ushort),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(char)
				}
			},
			{
				typeof(int),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(uint),
					typeof(ulong),
					typeof(char)
				}
			},
			{
				typeof(uint),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(char)
				}
			},
			{
				typeof(long),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(ulong),
					typeof(char)
				}
			},
			{
				typeof(ulong),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(char)
				}
			},
			{
				typeof(char),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short)
				}
			},
			{
				typeof(float),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(ulong),
					typeof(char),
					typeof(decimal)
				}
			},
			{
				typeof(double),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(ulong),
					typeof(char),
					typeof(float),
					typeof(decimal)
				}
			},
			{
				typeof(decimal),
				new HashSet<Type>
				{
					typeof(sbyte),
					typeof(byte),
					typeof(short),
					typeof(ushort),
					typeof(int),
					typeof(uint),
					typeof(long),
					typeof(ulong),
					typeof(char),
					typeof(float),
					typeof(double)
				}
			}
		};

		// Token: 0x020001CC RID: 460
		public enum ConversionType
		{
			// Token: 0x04000316 RID: 790
			Impossible,
			// Token: 0x04000317 RID: 791
			Identity,
			// Token: 0x04000318 RID: 792
			Upcast,
			// Token: 0x04000319 RID: 793
			Downcast,
			// Token: 0x0400031A RID: 794
			NumericImplicit,
			// Token: 0x0400031B RID: 795
			NumericExplicit,
			// Token: 0x0400031C RID: 796
			UserDefinedImplicit,
			// Token: 0x0400031D RID: 797
			UserDefinedExplicit,
			// Token: 0x0400031E RID: 798
			UserDefinedThenNumericImplicit,
			// Token: 0x0400031F RID: 799
			UserDefinedThenNumericExplicit,
			// Token: 0x04000320 RID: 800
			UnityHierarchy,
			// Token: 0x04000321 RID: 801
			EnumerableToArray,
			// Token: 0x04000322 RID: 802
			EnumerableToList,
			// Token: 0x04000323 RID: 803
			ToString
		}

		// Token: 0x020001CD RID: 461
		private struct ConversionQuery : IEquatable<ConversionUtility.ConversionQuery>
		{
			// Token: 0x06000C19 RID: 3097 RVA: 0x0003285C File Offset: 0x00030A5C
			public ConversionQuery(Type source, Type destination)
			{
				this.source = source;
				this.destination = destination;
			}

			// Token: 0x06000C1A RID: 3098 RVA: 0x0003286C File Offset: 0x00030A6C
			public bool Equals(ConversionUtility.ConversionQuery other)
			{
				return this.source == other.source && this.destination == other.destination;
			}

			// Token: 0x06000C1B RID: 3099 RVA: 0x00032894 File Offset: 0x00030A94
			public override bool Equals(object obj)
			{
				return obj is ConversionUtility.ConversionQuery && this.Equals((ConversionUtility.ConversionQuery)obj);
			}

			// Token: 0x06000C1C RID: 3100 RVA: 0x000328AC File Offset: 0x00030AAC
			public override int GetHashCode()
			{
				return HashUtility.GetHashCode<Type, Type>(this.source, this.destination);
			}

			// Token: 0x04000324 RID: 804
			public readonly Type source;

			// Token: 0x04000325 RID: 805
			public readonly Type destination;
		}

		// Token: 0x020001CE RID: 462
		private struct ConversionQueryComparer : IEqualityComparer<ConversionUtility.ConversionQuery>
		{
			// Token: 0x06000C1D RID: 3101 RVA: 0x000328BF File Offset: 0x00030ABF
			public bool Equals(ConversionUtility.ConversionQuery x, ConversionUtility.ConversionQuery y)
			{
				return x.Equals(y);
			}

			// Token: 0x06000C1E RID: 3102 RVA: 0x000328C9 File Offset: 0x00030AC9
			public int GetHashCode(ConversionUtility.ConversionQuery obj)
			{
				return obj.GetHashCode();
			}
		}
	}
}
