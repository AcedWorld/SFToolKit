using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000019 RID: 25
	public static class Utils
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00004E78 File Offset: 0x00003078
		public static void SmartDestroy(Object obj)
		{
			if (obj == null)
			{
				return;
			}
			Object.Destroy(obj);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004E8A File Offset: 0x0000308A
		public static void SmartDontDestroyOnLoad(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			Object.DontDestroyOnLoad(go);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004E9C File Offset: 0x0000309C
		public static List<T> FindRootObjectsByType<T>(bool includeInactive) where T : Component
		{
			List<T> list = new List<T>();
			Utils.FindRootObjectsByType<T>(includeInactive, list);
			return list;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004EB8 File Offset: 0x000030B8
		public static void FindRootObjectsByType<T>(bool includeInactive, IList<T> results) where T : Component
		{
			if (results == null)
			{
				results = new List<T>();
			}
			else
			{
				results.Clear();
			}
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.IsValid())
				{
					sceneAt.GetRootGameObjects(Utils._tmpSceneObjects);
					foreach (GameObject gameObject in Utils._tmpSceneObjects)
					{
						T component = gameObject.GetComponent<T>();
						if (!(component == null) && (includeInactive || component.gameObject.activeInHierarchy))
						{
							results.Add(component);
						}
					}
				}
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004F74 File Offset: 0x00003174
		public static bool IsAnySceneAccessible()
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (!sceneAt.IsValid())
				{
					return false;
				}
				try
				{
					sceneAt.GetRootGameObjects(Utils._tmpSceneObjects);
				}
				catch
				{
					return false;
				}
			}
			return SceneManager.sceneCount > 0;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004FD4 File Offset: 0x000031D4
		public static T FindRootObjectByType<T>(bool includeInactive) where T : Component
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.IsValid())
				{
					sceneAt.GetRootGameObjects(Utils._tmpSceneObjects);
					foreach (GameObject gameObject in Utils._tmpSceneObjects)
					{
						T component = gameObject.GetComponent<T>();
						if (!(component == null) && (includeInactive || component.gameObject.activeInHierarchy))
						{
							return component;
						}
					}
				}
			}
			return default(T);
		}

		// Token: 0x04000072 RID: 114
		private static List<GameObject> _tmpSceneObjects = new List<GameObject>();
	}
}
