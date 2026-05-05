using System;
using UnityEngine;

namespace Unity.Services.Qos.V2.Scheduler
{
	// Token: 0x02000022 RID: 34
	internal static class EngineStateHelper
	{
		// Token: 0x06000087 RID: 135 RVA: 0x000040C9 File Offset: 0x000022C9
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			EngineStateHelper.IsPlaying = Application.isPlaying;
		}

		// Token: 0x0400006F RID: 111
		public static bool IsPlaying;
	}
}
