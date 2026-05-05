using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rewired.Utils
{
	// Token: 0x02000497 RID: 1175
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public static class ReflectionTools
	{
		// Token: 0x06002F34 RID: 12084 RVA: 0x00024153 File Offset: 0x00022353
		public static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}

		// Token: 0x06002F35 RID: 12085 RVA: 0x0002415B File Offset: 0x0002235B
		public static bool IsEnum(Type type)
		{
			return !(type == null) && type.IsEnum;
		}

		// Token: 0x06002F36 RID: 12086 RVA: 0x0002416E File Offset: 0x0002236E
		public static Type GetUnderlyingEnumType(Type enumType)
		{
			if (enumType == null)
			{
				return null;
			}
			if (!ReflectionTools.IsEnum(enumType))
			{
				return null;
			}
			return Enum.GetUnderlyingType(enumType);
		}

		// Token: 0x06002F37 RID: 12087 RVA: 0x0002418B File Offset: 0x0002238B
		public static bool IsClass(Type type)
		{
			return type.IsClass;
		}

		// Token: 0x06002F38 RID: 12088 RVA: 0x00024193 File Offset: 0x00022393
		public static bool IsPrimitive(Type type)
		{
			return type.IsPrimitive;
		}

		// Token: 0x06002F39 RID: 12089 RVA: 0x0002419B File Offset: 0x0002239B
		public static bool IsArray(Type type)
		{
			return type.IsArray;
		}

		// Token: 0x06002F3A RID: 12090 RVA: 0x000241A3 File Offset: 0x000223A3
		public static bool DoesTypeImplement(Type type, Type baseOrInterfaceType)
		{
			return baseOrInterfaceType.IsAssignableFrom(type);
		}

		// Token: 0x06002F3B RID: 12091 RVA: 0x000241AC File Offset: 0x000223AC
		public static bool IsGenericType(Type type)
		{
			return !(type == null) && type.IsGenericType;
		}

		// Token: 0x06002F3C RID: 12092 RVA: 0x000241BF File Offset: 0x000223BF
		public static Type[] GetGenericArguments(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetGenericArguments();
		}

		// Token: 0x06002F3D RID: 12093 RVA: 0x000241D2 File Offset: 0x000223D2
		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetFields();
		}

		// Token: 0x06002F3E RID: 12094 RVA: 0x000241E5 File Offset: 0x000223E5
		public static IEnumerable<FieldInfo> GetFields(Type type, ReflectionTools.BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetFields((System.Reflection.BindingFlags)bindingFlags);
		}

		// Token: 0x06002F3F RID: 12095 RVA: 0x000241F9 File Offset: 0x000223F9
		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetProperties();
		}

		// Token: 0x06002F40 RID: 12096 RVA: 0x0002420C File Offset: 0x0002240C
		public static IEnumerable<PropertyInfo> GetProperties(Type type, ReflectionTools.BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetProperties((System.Reflection.BindingFlags)bindingFlags);
		}

		// Token: 0x06002F41 RID: 12097 RVA: 0x00024220 File Offset: 0x00022420
		public static IEnumerable<MethodInfo> GetMethods(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetMethods();
		}

		// Token: 0x06002F42 RID: 12098 RVA: 0x00024233 File Offset: 0x00022433
		public static IEnumerable<MethodInfo> GetMethods(Type type, ReflectionTools.BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetMethods((System.Reflection.BindingFlags)bindingFlags);
		}

		// Token: 0x06002F43 RID: 12099 RVA: 0x00024247 File Offset: 0x00022447
		public static bool IsDefined(Type type, Type attributeType, bool inherit)
		{
			return !(type == null) && !(attributeType == null) && type.IsDefined(attributeType, inherit);
		}

		// Token: 0x06002F44 RID: 12100 RVA: 0x000A4854 File Offset: 0x000A2A54
		public static T GetAttribute<T>(Type type, bool inherit) where T : Attribute
		{
			T t;
			if (type == null)
			{
				t = default(T);
				return t;
			}
			try
			{
				object[] customAttributes = type.GetCustomAttributes(typeof(T), inherit);
				if (customAttributes == null || customAttributes.Length == 0)
				{
					t = default(T);
					t = t;
				}
				else
				{
					t = (customAttributes[0] as T);
				}
			}
			catch
			{
				t = default(T);
			}
			return t;
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x000A48C8 File Offset: 0x000A2AC8
		internal static bool IsAssemblyLoaded(string assemblyName, bool useShortName, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(assemblyName))
			{
				return false;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (assemblies == null)
			{
				return false;
			}
			for (int i = 0; i < assemblies.Length; i++)
			{
				if (ignoreCase)
				{
					if (useShortName)
					{
						if (assemblies[i].GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					else if (assemblies[i].FullName.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
				else if (useShortName)
				{
					if (assemblies[i].GetName().Name.Equals(assemblyName))
					{
						return true;
					}
				}
				else if (assemblies[i].FullName.Equals(assemblyName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x00024265 File Offset: 0x00022465
		internal static Type GetTypeInUnityEditorAssembly(string classPath, bool ignoreCase = false)
		{
			return ReflectionTools.JmDRdKitdJDOfjAoNgfTfflSlcmlA(classPath, true, ignoreCase);
		}

		// Token: 0x06002F47 RID: 12103 RVA: 0x0002426F File Offset: 0x0002246F
		internal static Type GetTypeInUnityBuildAssembly(string classPath, bool ignoreCase = false)
		{
			return ReflectionTools.JmDRdKitdJDOfjAoNgfTfflSlcmlA(classPath, false, ignoreCase);
		}

		// Token: 0x06002F48 RID: 12104 RVA: 0x000A495C File Offset: 0x000A2B5C
		private static Type JmDRdKitdJDOfjAoNgfTfflSlcmlA(string A_0, bool A_1, bool A_2 = false)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type type = assemblies[i].GetType(A_0, false, A_2);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		// Token: 0x06002F49 RID: 12105 RVA: 0x00024279 File Offset: 0x00022479
		internal static Type GetTypeInAssembly(string classPath, string assemblyName, bool ignoreCase = false)
		{
			return Type.GetType(classPath + ", " + assemblyName + ", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false, ignoreCase);
		}

		// Token: 0x06002F4A RID: 12106 RVA: 0x000A499C File Offset: 0x000A2B9C
		public static TRet GetPrivateField<T, TRet>(T obj, string name)
		{
			ReflectionTools.BindingFlags bindingAttr = ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.NonPublic;
			return (TRet)((object)typeof(T).GetField(name, (System.Reflection.BindingFlags)bindingAttr).GetValue(obj));
		}

		// Token: 0x06002F4B RID: 12107 RVA: 0x000A49D0 File Offset: 0x000A2BD0
		public static TRet GetPrivateProperty<T, TRet>(T obj, string name)
		{
			ReflectionTools.BindingFlags bindingAttr = ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.NonPublic;
			return (TRet)((object)typeof(T).GetProperty(name, (System.Reflection.BindingFlags)bindingAttr).GetValue(obj, null));
		}

		// Token: 0x06002F4C RID: 12108 RVA: 0x000A4A04 File Offset: 0x000A2C04
		public static void SetPrivateField<T>(T obj, string name, object value)
		{
			ReflectionTools.BindingFlags bindingAttr = ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.NonPublic;
			typeof(T).GetField(name, (System.Reflection.BindingFlags)bindingAttr).SetValue(obj, value);
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x000A4A34 File Offset: 0x000A2C34
		public static void SetPrivateProperty<T>(T obj, string name, object value)
		{
			ReflectionTools.BindingFlags bindingAttr = ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.NonPublic;
			typeof(T).GetProperty(name, (System.Reflection.BindingFlags)bindingAttr).SetValue(obj, value, null);
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x000A4A64 File Offset: 0x000A2C64
		public static TRet CallPrivateMethod<T, TRet>(T obj, string name, params object[] param)
		{
			ReflectionTools.BindingFlags bindingAttr = ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.NonPublic;
			return (TRet)((object)typeof(T).GetMethod(name, (System.Reflection.BindingFlags)bindingAttr).Invoke(obj, param));
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x00024293 File Offset: 0x00022493
		public static MethodInfo GetMethodInfo(Delegate @delegate)
		{
			if (@delegate == null)
			{
				return null;
			}
			return @delegate.Method;
		}

		// Token: 0x02000498 RID: 1176
		[Flags]
		public enum BindingFlags
		{
			// Token: 0x040019C0 RID: 6592
			IgnoreCase = 1,
			// Token: 0x040019C1 RID: 6593
			DeclaredOnly = 2,
			// Token: 0x040019C2 RID: 6594
			Instance = 4,
			// Token: 0x040019C3 RID: 6595
			Static = 8,
			// Token: 0x040019C4 RID: 6596
			Public = 16,
			// Token: 0x040019C5 RID: 6597
			NonPublic = 32,
			// Token: 0x040019C6 RID: 6598
			FlattenHierarchy = 64
		}
	}
}
