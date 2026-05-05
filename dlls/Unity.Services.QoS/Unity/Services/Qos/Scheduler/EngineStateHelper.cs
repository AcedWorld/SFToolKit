using System;
using UnityEngine;

namespace Unity.Services.Qos.Scheduler
{
	// Token: 0x0200004A RID: 74
	internal static class EngineStateHelper
	{
		// Token: 0x06000162 RID: 354 RVA: 0x00006143 File Offset: 0x00004343
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			EngineStateHelper.IsPlaying = Application.isPlaying;
		}

		// Token: 0x040000AC RID: 172
		public static bool IsPlaying;
	}
}
