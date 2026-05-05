using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000030 RID: 48
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00007B9C File Offset: 0x00005D9C
		public static T instance
		{
			get
			{
				return Singleton<T>.sInstance;
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00007BA3 File Offset: 0x00005DA3
		public static void Clear()
		{
			Singleton<T>.sInstance = default(T);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00007BB0 File Offset: 0x00005DB0
		protected virtual void Awake()
		{
			if (Singleton<T>.sInstance != null)
			{
				Debug.LogError(base.name + "error: already initialized", this);
			}
			Singleton<T>.sInstance = (T)((object)this);
		}

		// Token: 0x04000116 RID: 278
		private static T sInstance;
	}
}
