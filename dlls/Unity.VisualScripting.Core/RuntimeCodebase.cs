using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000128 RID: 296
	public static class RuntimeCodebase
	{
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x000228D2 File Offset: 0x00020AD2
		public static IEnumerable<Type> types
		{
			get
			{
				return RuntimeCodebase._types;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x000228D9 File Offset: 0x00020AD9
		public static IEnumerable<Assembly> assemblies
		{
			get
			{
				return RuntimeCodebase._assemblies;
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x000228E0 File Offset: 0x00020AE0
		static RuntimeCodebase()
		{
			object obj = RuntimeCodebase.@lock;
			lock (obj)
			{
				foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				{
					RuntimeCodebase._assemblies.Add(assembly);
					foreach (Type item in assembly.GetTypesSafely())
					{
						RuntimeCodebase._types.Add(item);
					}
				}
			}
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x000229DC File Offset: 0x00020BDC
		public static IEnumerable<Attribute> GetAssemblyAttributes(Type attributeType)
		{
			return RuntimeCodebase.GetAssemblyAttributes(attributeType, RuntimeCodebase.assemblies);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000229E9 File Offset: 0x00020BE9
		public static IEnumerable<Attribute> GetAssemblyAttributes(Type attributeType, IEnumerable<Assembly> assemblies)
		{
			Ensure.That("attributeType").IsNotNull<Type>(attributeType);
			Ensure.That("assemblies").IsNotNull<IEnumerable<Assembly>>(assemblies);
			foreach (Assembly element in assemblies)
			{
				foreach (Attribute attribute in element.GetCustomAttributes(attributeType))
				{
					if (attributeType.IsInstanceOfType(attribute))
					{
						yield return attribute;
					}
				}
				IEnumerator<Attribute> enumerator2 = null;
			}
			IEnumerator<Assembly> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00022A00 File Offset: 0x00020C00
		public static IEnumerable<TAttribute> GetAssemblyAttributes<TAttribute>(IEnumerable<Assembly> assemblies) where TAttribute : Attribute
		{
			return RuntimeCodebase.GetAssemblyAttributes(typeof(TAttribute), assemblies).Cast<TAttribute>();
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00022A17 File Offset: 0x00020C17
		public static IEnumerable<TAttribute> GetAssemblyAttributes<TAttribute>() where TAttribute : Attribute
		{
			return RuntimeCodebase.GetAssemblyAttributes(typeof(TAttribute)).Cast<TAttribute>();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00022A30 File Offset: 0x00020C30
		public static void PrewarmTypeDeserialization(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			string key = RuntimeCodebase.SerializeType(type);
			if (!RuntimeCodebase.typeSerializations.ContainsKey(key))
			{
				RuntimeCodebase.typeSerializations.Add(key, type);
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00022A6D File Offset: 0x00020C6D
		public static string SerializeType(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			if (type == null)
			{
				return null;
			}
			return type.FullName;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00022A8C File Offset: 0x00020C8C
		public static bool TryDeserializeType(string typeName, out Type type)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				type = null;
				return false;
			}
			object obj = RuntimeCodebase.@lock;
			bool result;
			lock (obj)
			{
				if (!RuntimeCodebase.TryCachedTypeLookup(typeName, out type))
				{
					if (!RuntimeCodebase.TrySystemTypeLookup(typeName, out type) && !RuntimeCodebase.TryRenamedTypeLookup(typeName, out type))
					{
						return false;
					}
					RuntimeCodebase.typeSerializations.Add(typeName, type);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00022B04 File Offset: 0x00020D04
		public static Type DeserializeType(string typeName)
		{
			Type result;
			if (!RuntimeCodebase.TryDeserializeType(typeName, out result))
			{
				throw new SerializationException("Unable to find type: '" + (typeName ?? "(null)") + "'.");
			}
			return result;
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00022B3B File Offset: 0x00020D3B
		public static void ClearCachedTypes()
		{
			RuntimeCodebase.typeSerializations.Clear();
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00022B47 File Offset: 0x00020D47
		private static bool TryCachedTypeLookup(string typeName, out Type type)
		{
			return RuntimeCodebase.typeSerializations.TryGetValue(typeName, out type);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00022B58 File Offset: 0x00020D58
		private static bool TrySystemTypeLookup(string typeName, out Type type)
		{
			foreach (Assembly assembly in RuntimeCodebase._assemblies)
			{
				if (!RuntimeCodebase.disallowedAssemblies.Contains(assembly.GetName().Name))
				{
					type = assembly.GetType(typeName);
					if (type != null)
					{
						foreach (string value in RuntimeCodebase.disallowedAssemblies)
						{
							if (type.FullName.Contains(value))
							{
								return false;
							}
						}
						return true;
					}
				}
			}
			type = null;
			return false;
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00022C2C File Offset: 0x00020E2C
		private static bool TrySystemTypeLookup(TypeName typeName, out Type type)
		{
			if (RuntimeCodebase.disallowedAssemblies.Contains(typeName.AssemblyName))
			{
				type = null;
				return false;
			}
			if (typeName.IsArray)
			{
				IEnumerable<Assembly> assemblies = RuntimeCodebase._assemblies;
				Func<Assembly, bool> <>9__0;
				Func<Assembly, bool> predicate;
				if ((predicate = <>9__0) == null)
				{
					predicate = (<>9__0 = ((Assembly a) => typeName.AssemblyName == a.GetName().Name));
				}
				foreach (Assembly assembly in assemblies.Where(predicate))
				{
					type = assembly.GetType(typeName.Name);
					if (type != null)
					{
						return true;
					}
				}
				type = null;
				return false;
			}
			return RuntimeCodebase.TrySystemTypeLookup(typeName.ToLooseString(), out type);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00022D08 File Offset: 0x00020F08
		private static bool TryRenamedTypeLookup(string previousTypeName, out Type type)
		{
			Type type2;
			if (RuntimeCodebase.renamedTypes.TryGetValue(previousTypeName, out type2))
			{
				type = type2;
				return true;
			}
			TypeName typeName = TypeName.Parse(previousTypeName);
			foreach (KeyValuePair<string, Type> keyValuePair in RuntimeCodebase.renamedTypes)
			{
				typeName.ReplaceName(keyValuePair.Key, keyValuePair.Value);
			}
			foreach (KeyValuePair<string, string> keyValuePair2 in RuntimeCodebase.renamedNamespaces)
			{
				typeName.ReplaceNamespace(keyValuePair2.Key, keyValuePair2.Value);
			}
			foreach (KeyValuePair<string, string> keyValuePair3 in RuntimeCodebase.renamedAssemblies)
			{
				typeName.ReplaceAssembly(keyValuePair3.Key, keyValuePair3.Value);
			}
			if (RuntimeCodebase.TrySystemTypeLookup(typeName, out type))
			{
				return true;
			}
			type = null;
			return false;
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x00022E34 File Offset: 0x00021034
		public static Dictionary<string, string> renamedNamespaces
		{
			get
			{
				if (RuntimeCodebase._renamedNamespaces == null)
				{
					RuntimeCodebase._renamedNamespaces = RuntimeCodebase.FetchRenamedNamespaces();
				}
				return RuntimeCodebase._renamedNamespaces;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x00022E4C File Offset: 0x0002104C
		public static Dictionary<string, string> renamedAssemblies
		{
			get
			{
				if (RuntimeCodebase._renamedAssemblies == null)
				{
					RuntimeCodebase._renamedAssemblies = RuntimeCodebase.FetchRenamedAssemblies();
				}
				return RuntimeCodebase._renamedAssemblies;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x00022E64 File Offset: 0x00021064
		public static Dictionary<string, Type> renamedTypes
		{
			get
			{
				if (RuntimeCodebase._renamedTypes == null)
				{
					RuntimeCodebase._renamedTypes = RuntimeCodebase.FetchRenamedTypes();
				}
				return RuntimeCodebase._renamedTypes;
			}
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00022E7C File Offset: 0x0002107C
		public static Dictionary<string, string> RenamedMembers(Type type)
		{
			Dictionary<string, string> dictionary;
			if (!RuntimeCodebase._renamedMembers.TryGetValue(type, out dictionary))
			{
				dictionary = RuntimeCodebase.FetchRenamedMembers(type);
				RuntimeCodebase._renamedMembers.Add(type, dictionary);
			}
			return dictionary;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00022EAC File Offset: 0x000210AC
		private static Dictionary<string, string> FetchRenamedMembers(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			MemberInfo[] extendedMembers = type.GetExtendedMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			int i = 0;
			while (i < extendedMembers.Length)
			{
				MemberInfo memberInfo = extendedMembers[i];
				IEnumerable<RenamedFromAttribute> enumerable;
				try
				{
					enumerable = Attribute.GetCustomAttributes(memberInfo, typeof(RenamedFromAttribute), false).Cast<RenamedFromAttribute>();
				}
				catch (Exception arg)
				{
					Debug.LogWarning(string.Format("Failed to fetch RenamedFrom attributes for member '{0}':\n{1}", memberInfo, arg));
					goto IL_BB;
				}
				goto IL_5A;
				IL_BB:
				i++;
				continue;
				IL_5A:
				string name = memberInfo.Name;
				foreach (RenamedFromAttribute renamedFromAttribute in enumerable)
				{
					string previousName = renamedFromAttribute.previousName;
					if (dictionary.ContainsKey(previousName))
					{
						Debug.LogWarning(string.Format("Multiple members on '{0}' indicate having been renamed from '{1}'.\nIgnoring renamed attributes for '{2}'.", type, previousName, memberInfo));
					}
					else
					{
						dictionary.Add(previousName, name);
					}
				}
				goto IL_BB;
			}
			return dictionary;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00022FA0 File Offset: 0x000211A0
		private static Dictionary<string, string> FetchRenamedNamespaces()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (RenamedNamespaceAttribute renamedNamespaceAttribute in RuntimeCodebase.GetAssemblyAttributes<RenamedNamespaceAttribute>())
			{
				string previousName = renamedNamespaceAttribute.previousName;
				string newName = renamedNamespaceAttribute.newName;
				if (dictionary.ContainsKey(previousName))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"Multiple new names have been provided for namespace '",
						previousName,
						"'.\nIgnoring new name '",
						newName,
						"'."
					}));
				}
				else
				{
					dictionary.Add(previousName, newName);
				}
			}
			return dictionary;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0002303C File Offset: 0x0002123C
		private static Dictionary<string, string> FetchRenamedAssemblies()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (RenamedAssemblyAttribute renamedAssemblyAttribute in RuntimeCodebase.GetAssemblyAttributes<RenamedAssemblyAttribute>())
			{
				string previousName = renamedAssemblyAttribute.previousName;
				string newName = renamedAssemblyAttribute.newName;
				if (dictionary.ContainsKey(previousName))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"Multiple new names have been provided for assembly '",
						previousName,
						"'.\nIgnoring new name '",
						newName,
						"'."
					}));
				}
				else
				{
					dictionary.Add(previousName, newName);
				}
			}
			return dictionary;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x000230D8 File Offset: 0x000212D8
		private static Dictionary<string, Type> FetchRenamedTypes()
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			foreach (Assembly assembly in RuntimeCodebase.assemblies)
			{
				foreach (Type type in assembly.GetTypesSafely())
				{
					IEnumerable<RenamedFromAttribute> enumerable;
					try
					{
						enumerable = Attribute.GetCustomAttributes(type, typeof(RenamedFromAttribute), false).Cast<RenamedFromAttribute>();
					}
					catch (Exception arg)
					{
						Debug.LogWarning(string.Format("Failed to fetch RenamedFrom attributes for type '{0}':\n{1}", type, arg));
						continue;
					}
					string fullName = type.FullName;
					foreach (RenamedFromAttribute renamedFromAttribute in enumerable)
					{
						string previousName = renamedFromAttribute.previousName;
						if (dictionary.ContainsKey(previousName))
						{
							Debug.LogWarning(string.Format("Multiple types indicate having been renamed from '{0}'.\nIgnoring renamed attributes for '{1}'.", previousName, type));
						}
						else
						{
							dictionary.Add(previousName, type);
						}
					}
				}
			}
			return dictionary;
		}

		// Token: 0x040001CE RID: 462
		private static readonly object @lock = new object();

		// Token: 0x040001CF RID: 463
		private static readonly List<Type> _types = new List<Type>();

		// Token: 0x040001D0 RID: 464
		private static readonly List<Assembly> _assemblies = new List<Assembly>();

		// Token: 0x040001D1 RID: 465
		public static HashSet<string> disallowedAssemblies = new HashSet<string>();

		// Token: 0x040001D2 RID: 466
		private static readonly Dictionary<string, Type> typeSerializations = new Dictionary<string, Type>();

		// Token: 0x040001D3 RID: 467
		private static Dictionary<string, Type> _renamedTypes = null;

		// Token: 0x040001D4 RID: 468
		private static Dictionary<string, string> _renamedNamespaces = null;

		// Token: 0x040001D5 RID: 469
		private static Dictionary<string, string> _renamedAssemblies = null;

		// Token: 0x040001D6 RID: 470
		private static readonly Dictionary<Type, Dictionary<string, string>> _renamedMembers = new Dictionary<Type, Dictionary<string, string>>();
	}
}
