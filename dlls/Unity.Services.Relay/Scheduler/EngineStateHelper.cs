using System;
using UnityEngine;

namespace Unity.Services.Relay.Scheduler
{
	// Token: 0x02000015 RID: 21
	internal static class EngineStateHelper
	{
		// Token: 0x0600003F RID: 63 RVA: 0x000027CA File Offset: 0x000009CA
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			EngineStateHelper.IsPlaying = Application.isPlaying;
		}

		// Token: 0x04000048 RID: 72
		public static bool IsPlaying;
	}
}
