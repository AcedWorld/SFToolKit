using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000211 RID: 529
	internal class SceneObjectIDMap
	{
		// Token: 0x06000F9F RID: 3999 RVA: 0x00079990 File Offset: 0x00077B90
		public static bool TryGetSceneObjectID<TCategory>(GameObject gameObject, out int index, out TCategory category) where TCategory : struct, IConvertible
		{
			if (!typeof(TCategory).IsEnum)
			{
				throw new ArgumentException("'TCategory' must be an Enum type.");
			}
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			index = 0;
			category = default(TCategory);
			SceneObjectIDMapSceneAsset sceneObjectIDMapSceneAsset;
			return SceneObjectIDMap.TryGetOrCreateSceneIDMapFor(gameObject.scene, out sceneObjectIDMapSceneAsset) && sceneObjectIDMapSceneAsset.TryGetSceneIDFor<TCategory>(gameObject, out index, out category);
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x000799F4 File Offset: 0x00077BF4
		public static int GetOrCreateSceneObjectID<TCategory>(GameObject gameObject, TCategory category) where TCategory : struct, IConvertible
		{
			if (!typeof(TCategory).IsEnum)
			{
				throw new ArgumentException("'TCategory' must be an Enum type.");
			}
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			SceneObjectIDMapSceneAsset sceneObjectIDMapSceneAsset;
			if (!SceneObjectIDMap.TryGetOrCreateSceneIDMapFor(gameObject.scene, out sceneObjectIDMapSceneAsset))
			{
				throw new ArgumentException(string.Format("Provided GameObject {0} does not belong to a loaded scene.", gameObject));
			}
			int result;
			TCategory tcategory;
			if (!sceneObjectIDMapSceneAsset.TryGetSceneIDFor<TCategory>(gameObject, out result, out tcategory))
			{
				sceneObjectIDMapSceneAsset.TryInsert<TCategory>(gameObject, category, out result);
			}
			return result;
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x00079A6C File Offset: 0x00077C6C
		public static void GetAllIDsForAllScenes<TCategory>(TCategory category, List<GameObject> outGameObjects, List<int> outIndices, List<Scene> outScenes) where TCategory : struct, IConvertible
		{
			if (outGameObjects == null)
			{
				throw new ArgumentNullException("outGameObjects");
			}
			if (outIndices == null)
			{
				throw new ArgumentNullException("outIndices");
			}
			if (outIndices == null)
			{
				throw new ArgumentNullException("outScenes");
			}
			int count = outGameObjects.Count;
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				SceneObjectIDMap.GetAllIDsFor<TCategory>(category, sceneAt, outGameObjects, outIndices);
				int j = 0;
				int num = outGameObjects.Count - count;
				while (j < num)
				{
					outScenes.Add(sceneAt);
					j++;
				}
			}
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x00079AE8 File Offset: 0x00077CE8
		public static void GetAllIDsFor<TCategory>(TCategory category, Scene scene, List<GameObject> outGameObjects, List<int> outIndices) where TCategory : struct, IConvertible
		{
			if (outGameObjects == null)
			{
				throw new ArgumentNullException("outGameObjects");
			}
			if (outIndices == null)
			{
				throw new ArgumentNullException("outIndices");
			}
			SceneObjectIDMapSceneAsset sceneObjectIDMapSceneAsset;
			if (SceneObjectIDMap.TryGetSceneIDMapFor(scene, out sceneObjectIDMapSceneAsset))
			{
				sceneObjectIDMapSceneAsset.GetALLIDsFor<TCategory>(category, outGameObjects, outIndices);
			}
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x00079B24 File Offset: 0x00077D24
		private static bool TryGetSceneIDMapFor(Scene scene, out SceneObjectIDMapSceneAsset map)
		{
			if (!scene.isLoaded)
			{
				map = null;
				return false;
			}
			GameObject[] rootGameObjects = scene.GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				if (rootGameObjects[i].name == "SceneIDMap")
				{
					SceneObjectIDMapSceneAsset component;
					map = (component = rootGameObjects[i].GetComponent<SceneObjectIDMapSceneAsset>());
					if (component != null && !map.Equals(null))
					{
						return true;
					}
				}
			}
			map = null;
			return false;
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x00079B90 File Offset: 0x00077D90
		private static SceneObjectIDMapSceneAsset CreateSceneIDMapFor(Scene scene)
		{
			GameObject gameObject = new GameObject("SceneIDMap");
			gameObject.hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInBuild);
			SceneObjectIDMapSceneAsset result = gameObject.AddComponent<SceneObjectIDMapSceneAsset>();
			SceneManager.MoveGameObjectToScene(gameObject, scene);
			return result;
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x00079BBD File Offset: 0x00077DBD
		private static bool TryGetOrCreateSceneIDMapFor(Scene scene, out SceneObjectIDMapSceneAsset map)
		{
			if (!scene.isLoaded)
			{
				map = null;
				return false;
			}
			if (!SceneObjectIDMap.TryGetSceneIDMapFor(scene, out map))
			{
				map = SceneObjectIDMap.CreateSceneIDMapFor(scene);
			}
			return true;
		}
	}
}
