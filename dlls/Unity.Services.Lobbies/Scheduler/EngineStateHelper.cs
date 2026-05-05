using System;
using UnityEngine;

namespace Unity.Services.Lobbies.Scheduler
{
	// Token: 0x0200002B RID: 43
	internal static class EngineStateHelper
	{
		// Token: 0x06000144 RID: 324 RVA: 0x00006224 File Offset: 0x00004424
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			EngineStateHelper.IsPlaying = Application.isPlaying;
		}

		// Token: 0x040000AD RID: 173
		public static bool IsPlaying;
	}
}
