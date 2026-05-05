using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000150 RID: 336
	public static class ComponentHolderProtocol
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x00027070 File Offset: 0x00025270
		public static bool IsComponentHolderType(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			return typeof(GameObject).IsAssignableFrom(type) || typeof(Component).IsAssignableFrom(type);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000270A6 File Offset: 0x000252A6
		public static bool IsComponentHolder(this Object uo)
		{
			return uo is GameObject || uo is Component;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x000270BB File Offset: 0x000252BB
		public static GameObject GameObject(this Object uo)
		{
			if (uo is GameObject)
			{
				return (GameObject)uo;
			}
			if (uo is Component)
			{
				return ((Component)uo).gameObject;
			}
			return null;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x000270E1 File Offset: 0x000252E1
		public static T AddComponent<T>(this Object uo) where T : Component
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).AddComponent<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).gameObject.AddComponent<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00027115 File Offset: 0x00025315
		public static T GetOrAddComponent<T>(this Object uo) where T : Component
		{
			T result;
			if ((result = uo.GetComponent<T>()) == null)
			{
				result = uo.AddComponent<T>();
			}
			return result;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0002712C File Offset: 0x0002532C
		public static T GetComponent<T>(this Object uo)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponent<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponent<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0002715B File Offset: 0x0002535B
		public static T GetComponentInChildren<T>(this Object uo)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentInChildren<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentInChildren<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0002718A File Offset: 0x0002538A
		public static T GetComponentInParent<T>(this Object uo)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentInParent<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentInParent<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000271B9 File Offset: 0x000253B9
		public static T[] GetComponents<T>(this Object uo)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponents<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponents<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x000271E8 File Offset: 0x000253E8
		public static T[] GetComponentsInChildren<T>(this Object uo)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentsInChildren<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentsInChildren<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00027217 File Offset: 0x00025417
		public static T[] GetComponentsInParent<T>(this Object uo)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentsInParent<T>();
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentsInParent<T>();
			}
			throw new NotSupportedException();
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00027246 File Offset: 0x00025446
		public static Component GetComponent(this Object uo, Type type)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponent(type);
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponent(type);
			}
			throw new NotSupportedException();
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00027277 File Offset: 0x00025477
		public static Component GetComponentInChildren(this Object uo, Type type)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentInChildren(type);
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentInChildren(type);
			}
			throw new NotSupportedException();
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x000272A8 File Offset: 0x000254A8
		public static Component GetComponentInParent(this Object uo, Type type)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentInParent(type);
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentInParent(type);
			}
			throw new NotSupportedException();
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x000272D9 File Offset: 0x000254D9
		public static Component[] GetComponents(this Object uo, Type type)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponents(type);
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponents(type);
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0002730A File Offset: 0x0002550A
		public static Component[] GetComponentsInChildren(this Object uo, Type type)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentsInChildren(type);
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentsInChildren(type);
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0002733B File Offset: 0x0002553B
		public static Component[] GetComponentsInParent(this Object uo, Type type)
		{
			if (uo is GameObject)
			{
				return ((GameObject)uo).GetComponentsInParent(type);
			}
			if (uo is Component)
			{
				return ((Component)uo).GetComponentsInParent(type);
			}
			throw new NotSupportedException();
		}
	}
}
