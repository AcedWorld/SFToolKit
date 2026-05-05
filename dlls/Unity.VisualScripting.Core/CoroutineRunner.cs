using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000151 RID: 337
	[Singleton(Name = "VisualScripting CoroutineRunner", Automatic = true, Persistent = true)]
	[AddComponentMenu("")]
	[DisableAnnotation]
	[IncludeInSettings(false)]
	public sealed class CoroutineRunner : MonoBehaviour, ISingleton
	{
		// Token: 0x06000912 RID: 2322 RVA: 0x0002736C File Offset: 0x0002556C
		private void Awake()
		{
			Singleton<CoroutineRunner>.Awake(this);
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00027374 File Offset: 0x00025574
		private void OnDestroy()
		{
			base.StopAllCoroutines();
			Singleton<CoroutineRunner>.OnDestroy(this);
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x00027382 File Offset: 0x00025582
		public static CoroutineRunner instance
		{
			get
			{
				return Singleton<CoroutineRunner>.instance;
			}
		}
	}
}
