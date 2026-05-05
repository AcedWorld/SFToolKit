using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x0200014B RID: 331
	public static class SceneSingleton<T> where T : MonoBehaviour, ISingleton
	{
		// Token: 0x060008D8 RID: 2264 RVA: 0x00026890 File Offset: 0x00024A90
		static SceneSingleton()
		{
			if (SceneSingleton<T>.attribute == null)
			{
				throw new InvalidImplementationException(string.Format("Missing singleton attribute for '{0}'.", typeof(T)));
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x000268DD File Offset: 0x00024ADD
		private static bool persistent
		{
			get
			{
				return SceneSingleton<T>.attribute.Persistent;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x000268E9 File Offset: 0x00024AE9
		private static bool automatic
		{
			get
			{
				return SceneSingleton<T>.attribute.Automatic;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x000268F5 File Offset: 0x00024AF5
		private static string name
		{
			get
			{
				return SceneSingleton<T>.attribute.Name;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x00026901 File Offset: 0x00024B01
		private static HideFlags hideFlags
		{
			get
			{
				return SceneSingleton<T>.attribute.HideFlags;
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0002690D File Offset: 0x00024B0D
		private static void EnsureSceneValid(Scene scene)
		{
			if (!scene.IsValid())
			{
				throw new InvalidOperationException("Scene '" + scene.name + "' is invalid and cannot be used in singleton operations.");
			}
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00026934 File Offset: 0x00024B34
		public static bool InstantiatedIn(Scene scene)
		{
			SceneSingleton<T>.EnsureSceneValid(scene);
			if (Application.isPlaying)
			{
				return SceneSingleton<T>.instances.ContainsKey(scene);
			}
			return SceneSingleton<T>.FindInstances(scene).Length == 1;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0002695A File Offset: 0x00024B5A
		public static T InstanceIn(Scene scene)
		{
			SceneSingleton<T>.EnsureSceneValid(scene);
			if (!Application.isPlaying)
			{
				return SceneSingleton<T>.FindOrCreateInstance(scene);
			}
			if (SceneSingleton<T>.instances.ContainsKey(scene))
			{
				return SceneSingleton<T>.instances[scene];
			}
			return SceneSingleton<T>.FindOrCreateInstance(scene);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0002698F File Offset: 0x00024B8F
		private static T[] FindObjectsOfType()
		{
			return Object.FindObjectsOfType<T>();
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00026998 File Offset: 0x00024B98
		private static T[] FindInstances(Scene scene)
		{
			SceneSingleton<T>.EnsureSceneValid(scene);
			return (from o in SceneSingleton<T>.FindObjectsOfType()
			where o.gameObject.scene == scene
			select o).ToArray<T>();
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000269D8 File Offset: 0x00024BD8
		private static T FindOrCreateInstance(Scene scene)
		{
			Scene scene2 = scene;
			SceneSingleton<T>.EnsureSceneValid(scene2);
			T[] array = SceneSingleton<T>.FindInstances(scene2);
			if (array.Length == 1)
			{
				return array[0];
			}
			if (array.Length != 0)
			{
				throw new UnityException(string.Format("More than one '{0}' singleton in scene '{1}'.", typeof(T), scene.name));
			}
			if (!SceneSingleton<T>.automatic)
			{
				throw new UnityException(string.Format("Missing '{0}' singleton in scene '{1}'.", typeof(T), scene.name));
			}
			if (SceneSingleton<T>.persistent)
			{
				throw new UnityException("Scene singletons cannot be persistent.");
			}
			GameObject gameObject = new GameObject(SceneSingleton<T>.name ?? typeof(T).Name);
			gameObject.hideFlags = SceneSingleton<T>.hideFlags;
			SceneManager.MoveGameObjectToScene(gameObject, scene2);
			T t = gameObject.AddComponent<T>();
			t.hideFlags = SceneSingleton<T>.hideFlags;
			return t;
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00026AA8 File Offset: 0x00024CA8
		public static void Awake(T instance)
		{
			Ensure.That("instance").IsNotNull<T>(instance);
			Scene scene = instance.gameObject.scene;
			SceneSingleton<T>.EnsureSceneValid(scene);
			if (SceneSingleton<T>.instances.ContainsKey(scene))
			{
				throw new UnityException(string.Format("More than one '{0}' singleton in scene '{1}'.", typeof(T), scene.name));
			}
			SceneSingleton<T>.instances.Add(scene, instance);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00026B18 File Offset: 0x00024D18
		public static void OnDestroy(T instance)
		{
			Ensure.That("instance").IsNotNull<T>(instance);
			Scene scene = instance.gameObject.scene;
			if (!scene.IsValid())
			{
				foreach (KeyValuePair<Scene, T> keyValuePair in SceneSingleton<T>.instances)
				{
					if (keyValuePair.Value == instance)
					{
						SceneSingleton<T>.instances.Remove(keyValuePair.Key);
						break;
					}
				}
				return;
			}
			if (!SceneSingleton<T>.instances.ContainsKey(scene))
			{
				throw new UnityException(string.Format("Trying to destroy invalid instance of '{0}' singleton in scene '{1}'.", typeof(T), scene.name));
			}
			if (SceneSingleton<T>.instances[scene] == instance)
			{
				SceneSingleton<T>.instances.Remove(scene);
				return;
			}
			throw new UnityException(string.Format("Trying to destroy invalid instance of '{0}' singleton in scene '{1}'.", typeof(T), scene.name));
		}

		// Token: 0x0400021B RID: 539
		private static Dictionary<Scene, T> instances = new Dictionary<Scene, T>();

		// Token: 0x0400021C RID: 540
		private static readonly SingletonAttribute attribute = typeof(T).GetAttribute(true);
	}
}
