using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001B0 RID: 432
	public static class fsPortableReflection
	{
		// Token: 0x06000B7B RID: 2939 RVA: 0x00030CEE File Offset: 0x0002EEEE
		public static bool HasAttribute<TAttribute>(MemberInfo element)
		{
			return fsPortableReflection.HasAttribute(element, typeof(TAttribute));
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x00030D00 File Offset: 0x0002EF00
		public static bool HasAttribute<TAttribute>(MemberInfo element, bool shouldCache)
		{
			return fsPortableReflection.HasAttribute(element, typeof(TAttribute), shouldCache);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x00030D13 File Offset: 0x0002EF13
		public static bool HasAttribute(MemberInfo element, Type attributeType)
		{
			return fsPortableReflection.HasAttribute(element, attributeType, true);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00030D1D File Offset: 0x0002EF1D
		public static bool HasAttribute(MemberInfo element, Type attributeType, bool shouldCache)
		{
			return Attribute.IsDefined(element, attributeType, true);
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00030D28 File Offset: 0x0002EF28
		public static Attribute GetAttribute(MemberInfo element, Type attributeType, bool shouldCache)
		{
			fsPortableReflection.AttributeQuery key = new fsPortableReflection.AttributeQuery
			{
				MemberInfo = element,
				AttributeType = attributeType
			};
			Attribute attribute;
			if (!fsPortableReflection._cachedAttributeQueries.TryGetValue(key, out attribute))
			{
				Attribute[] array = Attribute.GetCustomAttributes(element, attributeType, true).ToArray<Attribute>();
				if (array.Length != 0)
				{
					attribute = array[0];
				}
				if (shouldCache)
				{
					fsPortableReflection._cachedAttributeQueries[key] = attribute;
				}
			}
			return attribute;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00030D84 File Offset: 0x0002EF84
		public static TAttribute GetAttribute<TAttribute>(MemberInfo element, bool shouldCache) where TAttribute : Attribute
		{
			return (TAttribute)((object)fsPortableReflection.GetAttribute(element, typeof(TAttribute), shouldCache));
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x00030D9C File Offset: 0x0002EF9C
		public static TAttribute GetAttribute<TAttribute>(MemberInfo element) where TAttribute : Attribute
		{
			return fsPortableReflection.GetAttribute<TAttribute>(element, true);
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x00030DA8 File Offset: 0x0002EFA8
		public static PropertyInfo GetDeclaredProperty(this Type type, string propertyName)
		{
			PropertyInfo[] declaredProperties = type.GetDeclaredProperties();
			for (int i = 0; i < declaredProperties.Length; i++)
			{
				if (declaredProperties[i].Name == propertyName)
				{
					return declaredProperties[i];
				}
			}
			return null;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x00030DE0 File Offset: 0x0002EFE0
		public static MethodInfo GetDeclaredMethod(this Type type, string methodName)
		{
			MethodInfo[] declaredMethods = type.GetDeclaredMethods();
			for (int i = 0; i < declaredMethods.Length; i++)
			{
				if (declaredMethods[i].Name == methodName)
				{
					return declaredMethods[i];
				}
			}
			return null;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x00030E18 File Offset: 0x0002F018
		public static ConstructorInfo GetDeclaredConstructor(this Type type, Type[] parameters)
		{
			foreach (ConstructorInfo constructorInfo in type.GetDeclaredConstructors())
			{
				ParameterInfo[] parameters2 = constructorInfo.GetParameters();
				if (parameters.Length == parameters2.Length)
				{
					for (int j = 0; j < parameters2.Length; j++)
					{
						parameters2[j].ParameterType != parameters[j];
					}
					return constructorInfo;
				}
			}
			return null;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x00030E75 File Offset: 0x0002F075
		public static ConstructorInfo[] GetDeclaredConstructors(this Type type)
		{
			return type.GetConstructors(fsPortableReflection.DeclaredFlags & ~BindingFlags.Static);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00030E88 File Offset: 0x0002F088
		public static MemberInfo[] GetFlattenedMember(this Type type, string memberName)
		{
			List<MemberInfo> list = new List<MemberInfo>();
			while (type != null)
			{
				MemberInfo[] declaredMembers = type.GetDeclaredMembers();
				for (int i = 0; i < declaredMembers.Length; i++)
				{
					if (declaredMembers[i].Name == memberName)
					{
						list.Add(declaredMembers[i]);
					}
				}
				type = type.Resolve().BaseType;
			}
			return list.ToArray();
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x00030EE8 File Offset: 0x0002F0E8
		public static MethodInfo GetFlattenedMethod(this Type type, string methodName)
		{
			while (type != null)
			{
				MethodInfo[] declaredMethods = type.GetDeclaredMethods();
				for (int i = 0; i < declaredMethods.Length; i++)
				{
					if (declaredMethods[i].Name == methodName)
					{
						return declaredMethods[i];
					}
				}
				type = type.Resolve().BaseType;
			}
			return null;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x00030F37 File Offset: 0x0002F137
		public static IEnumerable<MethodInfo> GetFlattenedMethods(this Type type, string methodName)
		{
			while (type != null)
			{
				MethodInfo[] methods = type.GetDeclaredMethods();
				int num;
				for (int i = 0; i < methods.Length; i = num)
				{
					if (methods[i].Name == methodName)
					{
						yield return methods[i];
					}
					num = i + 1;
				}
				type = type.Resolve().BaseType;
				methods = null;
			}
			yield break;
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x00030F50 File Offset: 0x0002F150
		public static PropertyInfo GetFlattenedProperty(this Type type, string propertyName)
		{
			while (type != null)
			{
				PropertyInfo[] declaredProperties = type.GetDeclaredProperties();
				for (int i = 0; i < declaredProperties.Length; i++)
				{
					if (declaredProperties[i].Name == propertyName)
					{
						return declaredProperties[i];
					}
				}
				type = type.Resolve().BaseType;
			}
			return null;
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x00030FA0 File Offset: 0x0002F1A0
		public static MemberInfo GetDeclaredMember(this Type type, string memberName)
		{
			MemberInfo[] declaredMembers = type.GetDeclaredMembers();
			for (int i = 0; i < declaredMembers.Length; i++)
			{
				if (declaredMembers[i].Name == memberName)
				{
					return declaredMembers[i];
				}
			}
			return null;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x00030FD7 File Offset: 0x0002F1D7
		public static MethodInfo[] GetDeclaredMethods(this Type type)
		{
			return type.GetMethods(fsPortableReflection.DeclaredFlags);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x00030FE4 File Offset: 0x0002F1E4
		public static PropertyInfo[] GetDeclaredProperties(this Type type)
		{
			return type.GetProperties(fsPortableReflection.DeclaredFlags);
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x00030FF1 File Offset: 0x0002F1F1
		public static FieldInfo[] GetDeclaredFields(this Type type)
		{
			return type.GetFields(fsPortableReflection.DeclaredFlags);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00030FFE File Offset: 0x0002F1FE
		public static MemberInfo[] GetDeclaredMembers(this Type type)
		{
			return type.GetMembers(fsPortableReflection.DeclaredFlags);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0003100B File Offset: 0x0002F20B
		public static MemberInfo AsMemberInfo(Type type)
		{
			return type;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0003100E File Offset: 0x0002F20E
		public static bool IsType(MemberInfo member)
		{
			return member is Type;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00031019 File Offset: 0x0002F219
		public static Type AsType(MemberInfo member)
		{
			return (Type)member;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x00031021 File Offset: 0x0002F221
		public static Type Resolve(this Type type)
		{
			return type;
		}

		// Token: 0x040002C9 RID: 713
		public static Type[] EmptyTypes = new Type[0];

		// Token: 0x040002CA RID: 714
		private static IDictionary<fsPortableReflection.AttributeQuery, Attribute> _cachedAttributeQueries = new Dictionary<fsPortableReflection.AttributeQuery, Attribute>(new fsPortableReflection.AttributeQueryComparator());

		// Token: 0x040002CB RID: 715
		private static BindingFlags DeclaredFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		// Token: 0x02000225 RID: 549
		private struct AttributeQuery
		{
			// Token: 0x040009E6 RID: 2534
			public MemberInfo MemberInfo;

			// Token: 0x040009E7 RID: 2535
			public Type AttributeType;
		}

		// Token: 0x02000226 RID: 550
		private class AttributeQueryComparator : IEqualityComparer<fsPortableReflection.AttributeQuery>
		{
			// Token: 0x0600132F RID: 4911 RVA: 0x000392A9 File Offset: 0x000374A9
			public bool Equals(fsPortableReflection.AttributeQuery x, fsPortableReflection.AttributeQuery y)
			{
				return x.MemberInfo == y.MemberInfo && x.AttributeType == y.AttributeType;
			}

			// Token: 0x06001330 RID: 4912 RVA: 0x000392D1 File Offset: 0x000374D1
			public int GetHashCode(fsPortableReflection.AttributeQuery obj)
			{
				return obj.MemberInfo.GetHashCode() + 17 * obj.AttributeType.GetHashCode();
			}
		}
	}
}
