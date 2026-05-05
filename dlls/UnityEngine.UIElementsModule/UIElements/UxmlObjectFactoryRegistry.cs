using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D6 RID: 982
	internal class UxmlObjectFactoryRegistry
	{
		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x0600202D RID: 8237 RVA: 0x000797B0 File Offset: 0x000779B0
		internal static Dictionary<string, List<IBaseUxmlObjectFactory>> factories
		{
			get
			{
				bool flag = UxmlObjectFactoryRegistry.s_Factories == null;
				if (flag)
				{
					UxmlObjectFactoryRegistry.s_Factories = new Dictionary<string, List<IBaseUxmlObjectFactory>>();
					UxmlObjectFactoryRegistry.RegisterEngineFactories();
					UxmlObjectFactoryRegistry.RegisterUserFactories();
				}
				return UxmlObjectFactoryRegistry.s_Factories;
			}
		}

		// Token: 0x0600202E RID: 8238 RVA: 0x000797EC File Offset: 0x000779EC
		protected static void RegisterFactory(IBaseUxmlObjectFactory factory)
		{
			List<IBaseUxmlObjectFactory> list;
			bool flag = UxmlObjectFactoryRegistry.factories.TryGetValue(factory.uxmlQualifiedName, out list);
			if (flag)
			{
				foreach (IBaseUxmlObjectFactory baseUxmlObjectFactory in list)
				{
					bool flag2 = baseUxmlObjectFactory.GetType() == factory.GetType();
					if (flag2)
					{
						throw new ArgumentException("A factory for the type " + factory.GetType().FullName + " was already registered");
					}
				}
				list.Add(factory);
			}
			else
			{
				list = new List<IBaseUxmlObjectFactory>
				{
					factory
				};
				UxmlObjectFactoryRegistry.factories.Add(factory.uxmlQualifiedName, list);
			}
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x000798B4 File Offset: 0x00077AB4
		internal static bool TryGetFactories(string fullTypeName, out List<IBaseUxmlObjectFactory> factoryList)
		{
			return UxmlObjectFactoryRegistry.factories.TryGetValue(fullTypeName, out factoryList);
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x000798D4 File Offset: 0x00077AD4
		private static void RegisterEngineFactories()
		{
			IBaseUxmlObjectFactory[] array = new IBaseUxmlObjectFactory[]
			{
				new Columns.UxmlObjectFactory<Columns>(),
				new Column.UxmlObjectFactory<Column>(),
				new SortColumnDescriptions.UxmlObjectFactory<SortColumnDescriptions>(),
				new SortColumnDescription.UxmlObjectFactory<SortColumnDescription>()
			};
			foreach (IBaseUxmlObjectFactory factory in array)
			{
				UxmlObjectFactoryRegistry.RegisterFactory(factory);
			}
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x00079928 File Offset: 0x00077B28
		private static void RegisterUserFactories()
		{
			HashSet<string> hashSet = new HashSet<string>(ScriptingRuntime.GetAllUserAssemblies());
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				bool flag = !hashSet.Contains(assembly.GetName().Name + ".dll") || assembly.GetName().Name == "UnityEngine.UIElementsModule";
				if (!flag)
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						bool flag2 = !typeof(IBaseUxmlObjectFactory).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract || type.IsGenericType;
						if (!flag2)
						{
							IBaseUxmlObjectFactory factory = (IBaseUxmlObjectFactory)Activator.CreateInstance(type);
							UxmlObjectFactoryRegistry.RegisterFactory(factory);
						}
					}
				}
			}
		}

		// Token: 0x04000D42 RID: 3394
		private static Dictionary<string, List<IBaseUxmlObjectFactory>> s_Factories;
	}
}
