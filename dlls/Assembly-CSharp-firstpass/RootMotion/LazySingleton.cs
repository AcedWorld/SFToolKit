using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000029 RID: 41
	public abstract class LazySingleton<T> : MonoBehaviour where T : LazySingleton<T>
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00007372 File Offset: 0x00005572
		public static bool hasInstance
		{
			get
			{
				return LazySingleton<T>.sInstance != null;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00007384 File Offset: 0x00005584
		public static T instance
		{
			get
			{
				if (LazySingleton<T>.sInstance == null)
				{
					LazySingleton<T>.sInstance = new GameObject(typeof(T).ToString()).AddComponent<T>();
				}
				return LazySingleton<T>.sInstance;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000073BB File Offset: 0x000055BB
		protected virtual void Awake()
		{
			LazySingleton<T>.sInstance = (T)((object)this);
		}

		// Token: 0x04000107 RID: 263
		private static T sInstance;
	}
}
