using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200014C RID: 332
	public static class Singleton<T> where T : MonoBehaviour, ISingleton
	{
		// Token: 0x060008E5 RID: 2277 RVA: 0x00026C34 File Offset: 0x00024E34
		static Singleton()
		{
			Singleton<T>.attribute = typeof(T).GetAttribute(true);
			if (Singleton<T>.attribute == null)
			{
				throw new InvalidImplementationException(string.Format("Missing singleton attribute for '{0}'.", typeof(T)));
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00026C8B File Offset: 0x00024E8B
		private static bool persistent
		{
			get
			{
				return Singleton<T>.attribute.Persistent;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x00026C97 File Offset: 0x00024E97
		private static bool automatic
		{
			get
			{
				return Singleton<T>.attribute.Automatic;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00026CA3 File Offset: 0x00024EA3
		private static string name
		{
			get
			{
				return Singleton<T>.attribute.Name;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x00026CAF File Offset: 0x00024EAF
		private static HideFlags hideFlags
		{
			get
			{
				return Singleton<T>.attribute.HideFlags;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060008EA RID: 2282 RVA: 0x00026CBC File Offset: 0x00024EBC
		public static bool instantiated
		{
			get
			{
				object @lock = Singleton<T>._lock;
				bool result;
				lock (@lock)
				{
					if (Application.isPlaying)
					{
						result = (Singleton<T>._instance != null);
					}
					else
					{
						result = (Singleton<T>.FindInstances().Length == 1);
					}
				}
				return result;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x00026D1C File Offset: 0x00024F1C
		public static T instance
		{
			get
			{
				object @lock = Singleton<T>._lock;
				T result;
				lock (@lock)
				{
					if (Application.isPlaying)
					{
						if (Singleton<T>._instance == null)
						{
							Singleton<T>.Instantiate();
						}
						result = Singleton<T>._instance;
					}
					else
					{
						result = Singleton<T>.Instantiate();
					}
				}
				return result;
			}
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00026D84 File Offset: 0x00024F84
		private static T[] FindObjectsOfType()
		{
			return Object.FindObjectsOfType<T>();
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00026D8B File Offset: 0x00024F8B
		private static T[] FindInstances()
		{
			return Singleton<T>.FindObjectsOfType();
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00026D94 File Offset: 0x00024F94
		public static T Instantiate()
		{
			object @lock = Singleton<T>._lock;
			T instance;
			lock (@lock)
			{
				T[] array = Singleton<T>.FindInstances();
				if (array.Length == 1)
				{
					Singleton<T>._instance = array[0];
				}
				else if (array.Length == 0)
				{
					if (!Singleton<T>.automatic)
					{
						throw new UnityException(string.Format("Missing '{0}' singleton in the scene.", typeof(T)));
					}
					GameObject gameObject = new GameObject(Singleton<T>.name ?? typeof(T).Name);
					gameObject.hideFlags = Singleton<T>.hideFlags;
					T t = gameObject.AddComponent<T>();
					t.hideFlags = Singleton<T>.hideFlags;
					Singleton<T>.Awake(t);
					if (Singleton<T>.persistent && Application.isPlaying)
					{
						Object.DontDestroyOnLoad(gameObject);
					}
				}
				else if (array.Length > 1)
				{
					throw new UnityException(string.Format("More than one '{0}' singleton in the scene.", typeof(T)));
				}
				instance = Singleton<T>._instance;
			}
			return instance;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00026E94 File Offset: 0x00025094
		public static void Awake(T instance)
		{
			Ensure.That("instance").IsNotNull<T>(instance);
			if (Singleton<T>.awoken.Contains(instance))
			{
				return;
			}
			if (Singleton<T>._instance != null)
			{
				throw new UnityException(string.Format("More than one '{0}' singleton in the scene.", typeof(T)));
			}
			Singleton<T>._instance = instance;
			Singleton<T>.awoken.Add(instance);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00026F00 File Offset: 0x00025100
		public static void OnDestroy(T instance)
		{
			Ensure.That("instance").IsNotNull<T>(instance);
			if (Singleton<T>._instance == instance)
			{
				Singleton<T>._instance = default(T);
				return;
			}
			throw new UnityException(string.Format("Trying to destroy invalid instance of '{0}' singleton.", typeof(T)));
		}

		// Token: 0x0400021D RID: 541
		private static readonly SingletonAttribute attribute;

		// Token: 0x0400021E RID: 542
		private static readonly object _lock = new object();

		// Token: 0x0400021F RID: 543
		private static readonly HashSet<T> awoken = new HashSet<T>();

		// Token: 0x04000220 RID: 544
		private static T _instance;
	}
}
