using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000228 RID: 552
	internal class AttributeHelperEngine
	{
		// Token: 0x06001839 RID: 6201 RVA: 0x0002819C File Offset: 0x0002639C
		[RequiredByNativeCode]
		private static Type GetParentTypeDisallowingMultipleInclusion(Type type)
		{
			Type result = null;
			while (type != null && type != typeof(MonoBehaviour))
			{
				bool flag = Attribute.IsDefined(type, typeof(DisallowMultipleComponent));
				if (flag)
				{
					result = type;
				}
				type = type.BaseType;
			}
			return result;
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x000281F4 File Offset: 0x000263F4
		[RequiredByNativeCode]
		private static Type[] GetRequiredComponents(Type klass)
		{
			List<Type> list = null;
			while (klass != null && klass != typeof(MonoBehaviour))
			{
				RequireComponent[] array = (RequireComponent[])klass.GetCustomAttributes(typeof(RequireComponent), false);
				Type baseType = klass.BaseType;
				foreach (RequireComponent requireComponent in array)
				{
					bool flag = list == null && array.Length == 1 && baseType == typeof(MonoBehaviour);
					if (flag)
					{
						return new Type[]
						{
							requireComponent.m_Type0,
							requireComponent.m_Type1,
							requireComponent.m_Type2
						};
					}
					bool flag2 = list == null;
					if (flag2)
					{
						list = new List<Type>();
					}
					bool flag3 = requireComponent.m_Type0 != null;
					if (flag3)
					{
						list.Add(requireComponent.m_Type0);
					}
					bool flag4 = requireComponent.m_Type1 != null;
					if (flag4)
					{
						list.Add(requireComponent.m_Type1);
					}
					bool flag5 = requireComponent.m_Type2 != null;
					if (flag5)
					{
						list.Add(requireComponent.m_Type2);
					}
				}
				klass = baseType;
			}
			bool flag6 = list == null;
			if (flag6)
			{
				return null;
			}
			return list.ToArray();
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x00028358 File Offset: 0x00026558
		private static int GetExecuteMode(Type klass)
		{
			object[] customAttributes = klass.GetCustomAttributes(typeof(ExecuteAlways), false);
			bool flag = customAttributes.Length != 0;
			int result;
			if (flag)
			{
				result = 2;
			}
			else
			{
				object[] customAttributes2 = klass.GetCustomAttributes(typeof(ExecuteInEditMode), false);
				bool flag2 = customAttributes2.Length != 0;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x000283AC File Offset: 0x000265AC
		[RequiredByNativeCode]
		private static int CheckIsEditorScript(Type klass)
		{
			while (klass != null && klass != typeof(MonoBehaviour))
			{
				int executeMode = AttributeHelperEngine.GetExecuteMode(klass);
				bool flag = executeMode > 0;
				if (flag)
				{
					return executeMode;
				}
				klass = klass.BaseType;
			}
			return 0;
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x00028400 File Offset: 0x00026600
		[RequiredByNativeCode]
		private static int GetDefaultExecutionOrderFor(Type klass)
		{
			DefaultExecutionOrder customAttributeOfType = AttributeHelperEngine.GetCustomAttributeOfType<DefaultExecutionOrder>(klass);
			bool flag = customAttributeOfType == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = customAttributeOfType.order;
			}
			return result;
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x0002842C File Offset: 0x0002662C
		private static T GetCustomAttributeOfType<T>(Type klass) where T : Attribute
		{
			Type typeFromHandle = typeof(T);
			object[] customAttributes = klass.GetCustomAttributes(typeFromHandle, true);
			bool flag = customAttributes != null && customAttributes.Length != 0;
			T result;
			if (flag)
			{
				result = (T)((object)customAttributes[0]);
			}
			else
			{
				result = default(T);
			}
			return result;
		}
	}
}
