using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Unity.VisualScripting
{
	// Token: 0x020000D7 RID: 215
	public static class MemberUtility
	{
		// Token: 0x060005D5 RID: 1493 RVA: 0x0000EE9A File Offset: 0x0000D09A
		public static bool IsOperator(this MethodInfo method)
		{
			return method.IsSpecialName && OperatorUtility.operatorNames.ContainsKey(method.Name);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0000EEB6 File Offset: 0x0000D0B6
		public static bool IsUserDefinedConversion(this MethodInfo method)
		{
			return method.IsSpecialName && (method.Name == "op_Implicit" || method.Name == "op_Explicit");
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0000EEE8 File Offset: 0x0000D0E8
		public static MethodInfo MakeGenericMethodVia(this MethodInfo openConstructedMethod, params Type[] closedConstructedParameterTypes)
		{
			Ensure.That("openConstructedMethod").IsNotNull<MethodInfo>(openConstructedMethod);
			Ensure.That("closedConstructedParameterTypes").IsNotNull<Type[]>(closedConstructedParameterTypes);
			if (!openConstructedMethod.ContainsGenericParameters)
			{
				return openConstructedMethod;
			}
			Type[] array = (from p in openConstructedMethod.GetParameters()
			select p.ParameterType).ToArray<Type>();
			if (array.Length != closedConstructedParameterTypes.Length)
			{
				throw new ArgumentOutOfRangeException("closedConstructedParameterTypes");
			}
			Dictionary<Type, Type> resolvedGenericParameters = new Dictionary<Type, Type>();
			for (int i = 0; i < array.Length; i++)
			{
				Type openConstructedType = array[i];
				Type closedConstructedType = closedConstructedParameterTypes[i];
				openConstructedType.MakeGenericTypeVia(closedConstructedType, resolvedGenericParameters, true);
			}
			Type[] typeArguments = openConstructedMethod.GetGenericArguments().Select(delegate(Type openConstructedGenericArgument)
			{
				if (resolvedGenericParameters.ContainsKey(openConstructedGenericArgument))
				{
					return resolvedGenericParameters[openConstructedGenericArgument];
				}
				return openConstructedGenericArgument;
			}).ToArray<Type>();
			return openConstructedMethod.MakeGenericMethod(typeArguments);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0000EFBC File Offset: 0x0000D1BC
		public static bool IsGenericExtension(this MethodInfo methodInfo)
		{
			return MemberUtility.GenericExtensionMethods.Value.Contains(methodInfo);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0000EFCE File Offset: 0x0000D1CE
		private static IEnumerable<MethodInfo> GetInheritedExtensionMethods(Type thisArgumentType)
		{
			MethodInfo[] cache = MemberUtility.ExtensionMethodsCache.Value.Cache;
			foreach (MethodInfo methodInfo in cache)
			{
				if (methodInfo.GetParameters()[0].ParameterType.CanMakeGenericTypeVia(thisArgumentType))
				{
					if (methodInfo.ContainsGenericParameters)
					{
						IEnumerable<Type> source = thisArgumentType.Yield<Type>().Concat(from p in methodInfo.GetParametersWithoutThis()
						select p.ParameterType);
						MethodInfo methodInfo2 = methodInfo.MakeGenericMethodVia(source.ToArray<Type>());
						MemberUtility.GenericExtensionMethods.Value.Add(methodInfo2);
						yield return methodInfo2;
					}
					else
					{
						yield return methodInfo;
					}
				}
			}
			MethodInfo[] array = null;
			yield break;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0000EFE0 File Offset: 0x0000D1E0
		public static IEnumerable<MethodInfo> GetExtensionMethods(this Type thisArgumentType, bool inherited = true)
		{
			if (inherited)
			{
				Lazy<Dictionary<Type, MethodInfo[]>> inheritedExtensionMethodsCache = MemberUtility.InheritedExtensionMethodsCache;
				lock (inheritedExtensionMethodsCache)
				{
					MethodInfo[] array;
					if (!MemberUtility.InheritedExtensionMethodsCache.Value.TryGetValue(thisArgumentType, out array))
					{
						array = MemberUtility.GetInheritedExtensionMethods(thisArgumentType).ToArray<MethodInfo>();
						MemberUtility.InheritedExtensionMethodsCache.Value.Add(thisArgumentType, array);
					}
					return array;
				}
			}
			return from method in MemberUtility.ExtensionMethodsCache.Value.Cache
			where method.GetParameters()[0].ParameterType == thisArgumentType
			select method;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0000F090 File Offset: 0x0000D290
		public static bool IsExtension(this MethodInfo methodInfo)
		{
			return methodInfo.HasAttribute(false);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0000F09C File Offset: 0x0000D29C
		public static bool IsExtensionMethod(this MemberInfo memberInfo)
		{
			MethodInfo methodInfo = memberInfo as MethodInfo;
			return methodInfo != null && methodInfo.IsExtension();
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0000F0BB File Offset: 0x0000D2BB
		public static Delegate CreateDelegate(this MethodInfo methodInfo, Type delegateType)
		{
			return Delegate.CreateDelegate(delegateType, methodInfo);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0000F0C4 File Offset: 0x0000D2C4
		public static bool IsAccessor(this MemberInfo memberInfo)
		{
			return memberInfo is FieldInfo || memberInfo is PropertyInfo;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0000F0D9 File Offset: 0x0000D2D9
		public static Type GetAccessorType(this MemberInfo memberInfo)
		{
			if (memberInfo is FieldInfo)
			{
				return ((FieldInfo)memberInfo).FieldType;
			}
			if (memberInfo is PropertyInfo)
			{
				return ((PropertyInfo)memberInfo).PropertyType;
			}
			return null;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0000F104 File Offset: 0x0000D304
		public static bool IsPubliclyGettable(this MemberInfo memberInfo)
		{
			if (memberInfo is FieldInfo)
			{
				return ((FieldInfo)memberInfo).IsPublic;
			}
			if (memberInfo is PropertyInfo)
			{
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				return propertyInfo.CanRead && propertyInfo.GetGetMethod(false) != null;
			}
			if (memberInfo is MethodInfo)
			{
				return ((MethodInfo)memberInfo).IsPublic;
			}
			if (memberInfo is ConstructorInfo)
			{
				return ((ConstructorInfo)memberInfo).IsPublic;
			}
			throw new NotSupportedException();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0000F17C File Offset: 0x0000D37C
		private static Type ExtendedDeclaringType(this MemberInfo memberInfo)
		{
			MethodInfo methodInfo = memberInfo as MethodInfo;
			if (methodInfo != null && methodInfo.IsExtension())
			{
				return methodInfo.GetParameters()[0].ParameterType;
			}
			return memberInfo.DeclaringType;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000F1AF File Offset: 0x0000D3AF
		public static Type ExtendedDeclaringType(this MemberInfo memberInfo, bool invokeAsExtension)
		{
			if (invokeAsExtension)
			{
				return memberInfo.ExtendedDeclaringType();
			}
			return memberInfo.DeclaringType;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0000F1C1 File Offset: 0x0000D3C1
		public static bool IsStatic(this PropertyInfo propertyInfo)
		{
			MethodInfo getMethod = propertyInfo.GetGetMethod(true);
			if (getMethod == null || !getMethod.IsStatic)
			{
				MethodInfo setMethod = propertyInfo.GetSetMethod(true);
				return setMethod != null && setMethod.IsStatic;
			}
			return true;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		public static bool IsStatic(this MemberInfo memberInfo)
		{
			if (memberInfo is FieldInfo)
			{
				return ((FieldInfo)memberInfo).IsStatic;
			}
			if (memberInfo is PropertyInfo)
			{
				return ((PropertyInfo)memberInfo).IsStatic();
			}
			if (memberInfo is MethodBase)
			{
				return ((MethodBase)memberInfo).IsStatic;
			}
			throw new NotSupportedException();
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0000F23A File Offset: 0x0000D43A
		private static IEnumerable<ParameterInfo> GetParametersWithoutThis(this MethodBase methodBase)
		{
			return methodBase.GetParameters().Skip(methodBase.IsExtensionMethod() ? 1 : 0);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0000F253 File Offset: 0x0000D453
		public static bool IsInvokedAsExtension(this MethodBase methodBase, Type targetType)
		{
			return methodBase.IsExtensionMethod() && methodBase.DeclaringType != targetType;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0000F26B File Offset: 0x0000D46B
		public static IEnumerable<ParameterInfo> GetInvocationParameters(this MethodBase methodBase, bool invokeAsExtension)
		{
			if (invokeAsExtension)
			{
				return methodBase.GetParametersWithoutThis();
			}
			return methodBase.GetParameters();
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0000F27D File Offset: 0x0000D47D
		public static IEnumerable<ParameterInfo> GetInvocationParameters(this MethodBase methodBase, Type targetType)
		{
			return methodBase.GetInvocationParameters(methodBase.IsInvokedAsExtension(targetType));
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000F28C File Offset: 0x0000D48C
		public static Type UnderlyingParameterType(this ParameterInfo parameterInfo)
		{
			if (parameterInfo.ParameterType.IsByRef)
			{
				return parameterInfo.ParameterType.GetElementType();
			}
			return parameterInfo.ParameterType;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0000F2AD File Offset: 0x0000D4AD
		public static bool HasDefaultValue(this ParameterInfo parameterInfo)
		{
			return (parameterInfo.Attributes & ParameterAttributes.HasDefault) == ParameterAttributes.HasDefault;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000F2C4 File Offset: 0x0000D4C4
		public static object DefaultValue(this ParameterInfo parameterInfo)
		{
			if (parameterInfo.HasDefaultValue())
			{
				object obj = parameterInfo.DefaultValue;
				if (obj == null && parameterInfo.ParameterType.IsValueType)
				{
					obj = parameterInfo.ParameterType.Default();
				}
				return obj;
			}
			return parameterInfo.UnderlyingParameterType().Default();
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0000F30C File Offset: 0x0000D50C
		public static object PseudoDefaultValue(this ParameterInfo parameterInfo)
		{
			if (parameterInfo.HasDefaultValue())
			{
				object obj = parameterInfo.DefaultValue;
				if (obj == null && parameterInfo.ParameterType.IsValueType)
				{
					obj = parameterInfo.ParameterType.PseudoDefault();
				}
				return obj;
			}
			return parameterInfo.UnderlyingParameterType().PseudoDefault();
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0000F354 File Offset: 0x0000D554
		public static bool AllowsNull(this ParameterInfo parameterInfo)
		{
			Type parameterType = parameterInfo.ParameterType;
			return (parameterType.IsReferenceType() && parameterInfo.HasAttribute(true)) || Nullable.GetUnderlyingType(parameterType) != null;
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0000F387 File Offset: 0x0000D587
		public static bool HasOutModifier(this ParameterInfo parameterInfo)
		{
			Ensure.That("parameterInfo").IsNotNull<ParameterInfo>(parameterInfo);
			return parameterInfo.IsOut && parameterInfo.ParameterType.IsByRef;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0000F3AE File Offset: 0x0000D5AE
		public static bool CanWrite(this FieldInfo fieldInfo)
		{
			return !fieldInfo.IsInitOnly && !fieldInfo.IsLiteral;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000F3C3 File Offset: 0x0000D5C3
		public static Member ToManipulator(this MemberInfo memberInfo)
		{
			return memberInfo.ToManipulator(memberInfo.DeclaringType);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0000F3D4 File Offset: 0x0000D5D4
		public static Member ToManipulator(this MemberInfo memberInfo, Type targetType)
		{
			FieldInfo fieldInfo = memberInfo as FieldInfo;
			if (fieldInfo != null)
			{
				return fieldInfo.ToManipulator(targetType);
			}
			PropertyInfo propertyInfo = memberInfo as PropertyInfo;
			if (propertyInfo != null)
			{
				return propertyInfo.ToManipulator(targetType);
			}
			MethodInfo methodInfo = memberInfo as MethodInfo;
			if (methodInfo != null)
			{
				return methodInfo.ToManipulator(targetType);
			}
			ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
			if (constructorInfo != null)
			{
				return constructorInfo.ToManipulator(targetType);
			}
			throw new InvalidOperationException();
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0000F42E File Offset: 0x0000D62E
		public static Member ToManipulator(this FieldInfo fieldInfo, Type targetType)
		{
			return new Member(targetType, fieldInfo);
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0000F437 File Offset: 0x0000D637
		public static Member ToManipulator(this PropertyInfo propertyInfo, Type targetType)
		{
			return new Member(targetType, propertyInfo);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0000F440 File Offset: 0x0000D640
		public static Member ToManipulator(this MethodInfo methodInfo, Type targetType)
		{
			return new Member(targetType, methodInfo);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0000F449 File Offset: 0x0000D649
		public static Member ToManipulator(this ConstructorInfo constructorInfo, Type targetType)
		{
			return new Member(targetType, constructorInfo);
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0000F454 File Offset: 0x0000D654
		public static ConstructorInfo GetConstructorAccepting(this Type type, Type[] paramTypes, bool nonPublic)
		{
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
			if (nonPublic)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return type.GetConstructors(bindingFlags).FirstOrDefault(delegate(ConstructorInfo constructor)
			{
				ParameterInfo[] parameters = constructor.GetParameters();
				if (parameters.Length != paramTypes.Length)
				{
					return false;
				}
				for (int i = 0; i < parameters.Length; i++)
				{
					if (paramTypes[i] == null)
					{
						if (!parameters[i].ParameterType.IsNullable())
						{
							return false;
						}
					}
					else if (!parameters[i].ParameterType.IsAssignableFrom(paramTypes[i]))
					{
						return false;
					}
				}
				return true;
			});
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0000F491 File Offset: 0x0000D691
		public static ConstructorInfo GetConstructorAccepting(this Type type, params Type[] paramTypes)
		{
			return type.GetConstructorAccepting(paramTypes, true);
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000F49B File Offset: 0x0000D69B
		public static ConstructorInfo GetPublicConstructorAccepting(this Type type, params Type[] paramTypes)
		{
			return type.GetConstructorAccepting(paramTypes, false);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000F4A5 File Offset: 0x0000D6A5
		public static ConstructorInfo GetDefaultConstructor(this Type type)
		{
			return type.GetConstructorAccepting(Array.Empty<Type>());
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000F4B2 File Offset: 0x0000D6B2
		public static ConstructorInfo GetPublicDefaultConstructor(this Type type)
		{
			return type.GetPublicConstructorAccepting(Array.Empty<Type>());
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
		public static MemberInfo[] GetExtendedMember(this Type type, string name, MemberTypes types, BindingFlags flags)
		{
			List<MemberInfo> list = type.GetMember(name, types, flags).ToList<MemberInfo>();
			if (types.HasFlag(MemberTypes.Method))
			{
				list.AddRange((from extension in type.GetExtensionMethods(true)
				where extension.Name == name
				select extension).Cast<MemberInfo>());
			}
			return list.ToArray();
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0000F52C File Offset: 0x0000D72C
		public static MemberInfo[] GetExtendedMembers(this Type type, BindingFlags flags)
		{
			HashSet<MemberInfo> hashSet = type.GetMembers(flags).ToHashSet<MemberInfo>();
			foreach (MethodInfo item in type.GetExtensionMethods(true))
			{
				hashSet.Add(item);
			}
			return hashSet.ToArray<MemberInfo>();
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0000F590 File Offset: 0x0000D790
		private static bool NameMatches(this MemberInfo member, string name)
		{
			return member.Name == name;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0000F5A0 File Offset: 0x0000D7A0
		private static bool ParametersMatch(this MethodBase methodBase, IEnumerable<Type> parameterTypes, bool invokeAsExtension)
		{
			Ensure.That("parameterTypes").IsNotNull<IEnumerable<Type>>(parameterTypes);
			return (from paramInfo in methodBase.GetInvocationParameters(invokeAsExtension)
			select paramInfo.ParameterType).SequenceEqual(parameterTypes);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0000F5EE File Offset: 0x0000D7EE
		private static bool GenericArgumentsMatch(this MethodInfo method, IEnumerable<Type> genericArgumentTypes)
		{
			Ensure.That("genericArgumentTypes").IsNotNull<IEnumerable<Type>>(genericArgumentTypes);
			return !method.ContainsGenericParameters && method.GetGenericArguments().SequenceEqual(genericArgumentTypes);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0000F616 File Offset: 0x0000D816
		public static bool SignatureMatches(this FieldInfo field, string name)
		{
			return field.NameMatches(name);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0000F61F File Offset: 0x0000D81F
		public static bool SignatureMatches(this PropertyInfo property, string name)
		{
			return property.NameMatches(name);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0000F628 File Offset: 0x0000D828
		public static bool SignatureMatches(this ConstructorInfo constructor, string name, IEnumerable<Type> parameterTypes)
		{
			return constructor.NameMatches(name) && constructor.ParametersMatch(parameterTypes, false);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0000F63D File Offset: 0x0000D83D
		public static bool SignatureMatches(this MethodInfo method, string name, IEnumerable<Type> parameterTypes, bool invokeAsExtension)
		{
			return method.NameMatches(name) && method.ParametersMatch(parameterTypes, invokeAsExtension) && !method.ContainsGenericParameters;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0000F65D File Offset: 0x0000D85D
		public static bool SignatureMatches(this MethodInfo method, string name, IEnumerable<Type> parameterTypes, IEnumerable<Type> genericArgumentTypes, bool invokeAsExtension)
		{
			return method.NameMatches(name) && method.ParametersMatch(parameterTypes, invokeAsExtension) && method.GenericArgumentsMatch(genericArgumentTypes);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000F67C File Offset: 0x0000D87C
		public static FieldInfo GetFieldUnambiguous(this Type type, string name, BindingFlags flags)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("name").IsNotNull(name);
			flags |= BindingFlags.DeclaredOnly;
			while (type != null)
			{
				FieldInfo field = type.GetField(name, flags);
				if (field != null)
				{
					return field;
				}
				type = type.BaseType;
			}
			return null;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000F6D8 File Offset: 0x0000D8D8
		public static PropertyInfo GetPropertyUnambiguous(this Type type, string name, BindingFlags flags)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("name").IsNotNull(name);
			flags |= BindingFlags.DeclaredOnly;
			while (type != null)
			{
				PropertyInfo property = type.GetProperty(name, flags);
				if (property != null)
				{
					return property;
				}
				type = type.BaseType;
			}
			return null;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0000F734 File Offset: 0x0000D934
		public static MethodInfo GetMethodUnambiguous(this Type type, string name, BindingFlags flags)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("name").IsNotNull(name);
			flags |= BindingFlags.DeclaredOnly;
			while (type != null)
			{
				MethodInfo method = type.GetMethod(name, flags);
				if (method != null)
				{
					return method;
				}
				type = type.BaseType;
			}
			return null;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0000F790 File Offset: 0x0000D990
		private static TMemberInfo DisambiguateHierarchy<TMemberInfo>(this IEnumerable<TMemberInfo> members, Type type) where TMemberInfo : MemberInfo
		{
			while (type != null)
			{
				foreach (TMemberInfo tmemberInfo in members)
				{
					MethodInfo methodInfo = tmemberInfo as MethodInfo;
					bool invokeAsExtension = methodInfo != null && methodInfo.IsInvokedAsExtension(type);
					if (tmemberInfo.ExtendedDeclaringType(invokeAsExtension) == type)
					{
						return tmemberInfo;
					}
				}
				type = type.BaseType;
			}
			return default(TMemberInfo);
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0000F82C File Offset: 0x0000DA2C
		public static FieldInfo Disambiguate(this IEnumerable<FieldInfo> fields, Type type)
		{
			Ensure.That("fields").IsNotNull<IEnumerable<FieldInfo>>(fields);
			Ensure.That("type").IsNotNull<Type>(type);
			return fields.DisambiguateHierarchy(type);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0000F855 File Offset: 0x0000DA55
		public static PropertyInfo Disambiguate(this IEnumerable<PropertyInfo> properties, Type type)
		{
			Ensure.That("properties").IsNotNull<IEnumerable<PropertyInfo>>(properties);
			Ensure.That("type").IsNotNull<Type>(type);
			return properties.DisambiguateHierarchy(type);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0000F880 File Offset: 0x0000DA80
		public static ConstructorInfo Disambiguate(this IEnumerable<ConstructorInfo> constructors, Type type, IEnumerable<Type> parameterTypes)
		{
			Ensure.That("constructors").IsNotNull<IEnumerable<ConstructorInfo>>(constructors);
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("parameterTypes").IsNotNull<IEnumerable<Type>>(parameterTypes);
			return (from m in constructors
			where m.ParametersMatch(parameterTypes, false) && !m.ContainsGenericParameters
			select m).DisambiguateHierarchy(type);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0000F8E8 File Offset: 0x0000DAE8
		public static MethodInfo Disambiguate(this IEnumerable<MethodInfo> methods, Type type, IEnumerable<Type> parameterTypes)
		{
			Ensure.That("methods").IsNotNull<IEnumerable<MethodInfo>>(methods);
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("parameterTypes").IsNotNull<IEnumerable<Type>>(parameterTypes);
			return (from m in methods
			where m.ParametersMatch(parameterTypes, m.IsInvokedAsExtension(type)) && !m.ContainsGenericParameters
			select m).DisambiguateHierarchy(type);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0000F960 File Offset: 0x0000DB60
		public static MethodInfo Disambiguate(this IEnumerable<MethodInfo> methods, Type type, IEnumerable<Type> parameterTypes, IEnumerable<Type> genericArgumentTypes)
		{
			Ensure.That("methods").IsNotNull<IEnumerable<MethodInfo>>(methods);
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("parameterTypes").IsNotNull<IEnumerable<Type>>(parameterTypes);
			Ensure.That("genericArgumentTypes").IsNotNull<IEnumerable<Type>>(genericArgumentTypes);
			return (from m in methods
			where m.ParametersMatch(parameterTypes, m.IsInvokedAsExtension(type)) && m.GenericArgumentsMatch(genericArgumentTypes)
			select m).DisambiguateHierarchy(type);
		}

		// Token: 0x04000151 RID: 337
		private static readonly Lazy<ExtensionMethodCache> ExtensionMethodsCache = new Lazy<ExtensionMethodCache>(() => new ExtensionMethodCache(), true);

		// Token: 0x04000152 RID: 338
		private static readonly Lazy<Dictionary<Type, MethodInfo[]>> InheritedExtensionMethodsCache = new Lazy<Dictionary<Type, MethodInfo[]>>(() => new Dictionary<Type, MethodInfo[]>(), true);

		// Token: 0x04000153 RID: 339
		private static readonly Lazy<HashSet<MethodInfo>> GenericExtensionMethods = new Lazy<HashSet<MethodInfo>>(() => new HashSet<MethodInfo>(), true);
	}
}
