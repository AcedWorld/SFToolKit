using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x02000167 RID: 359
	public static class UnityObjectUtility
	{
		// Token: 0x06000997 RID: 2455 RVA: 0x00028F4B File Offset: 0x0002714B
		public static bool IsDestroyed(this Object target)
		{
			return target != null && target == null;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00028F59 File Offset: 0x00027159
		public static bool IsUnityNull(this object obj)
		{
			return obj == null || (obj is Object && (Object)obj == null);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00028F78 File Offset: 0x00027178
		public static string ToSafeString(this Object uo)
		{
			if (uo == null)
			{
				return "(null)";
			}
			if (!UnityThread.allowsAPI)
			{
				return uo.GetType().Name;
			}
			if (uo == null)
			{
				return "(Destroyed)";
			}
			string result;
			try
			{
				result = uo.name;
			}
			catch (Exception ex)
			{
				result = string.Concat(new string[]
				{
					"(",
					ex.GetType().Name,
					" in ToString: ",
					ex.Message,
					")"
				});
			}
			return result;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0002900C File Offset: 0x0002720C
		public static string ToSafeString(this object obj)
		{
			if (obj == null)
			{
				return "(null)";
			}
			Object @object = obj as Object;
			if (@object != null)
			{
				return @object.ToSafeString();
			}
			string result;
			try
			{
				result = obj.ToString();
			}
			catch (Exception ex)
			{
				result = string.Concat(new string[]
				{
					"(",
					ex.GetType().Name,
					" in ToString: ",
					ex.Message,
					")"
				});
			}
			return result;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002908C File Offset: 0x0002728C
		public static T AsUnityNull<T>(this T obj) where T : Object
		{
			if (obj == null)
			{
				return default(T);
			}
			return obj;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000290B2 File Offset: 0x000272B2
		public static bool TrulyEqual(Object a, Object b)
		{
			return !(a != b) && a == null == (b == null);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000290D2 File Offset: 0x000272D2
		public static IEnumerable<T> NotUnityNull<T>(this IEnumerable<T> enumerable) where T : Object
		{
			return from i in enumerable
			where i != null
			select i;
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000290F9 File Offset: 0x000272F9
		public static IEnumerable<T> FindObjectsOfTypeIncludingInactive<T>()
		{
			int num;
			for (int i = 0; i < SceneManager.sceneCount; i = num + 1)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.isLoaded)
				{
					foreach (GameObject gameObject in sceneAt.GetRootGameObjects())
					{
						foreach (T t in gameObject.GetComponentsInChildren<T>(true))
						{
							yield return t;
						}
						T[] array2 = null;
					}
					GameObject[] array = null;
				}
				num = i;
			}
			yield break;
		}
	}
}
