using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000AB RID: 171
	internal class HDRuntimeReflectionSystem : ScriptableRuntimeReflectionSystem
	{
		// Token: 0x060007E4 RID: 2020 RVA: 0x00049C14 File Offset: 0x00047E14
		[RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			if (GraphicsSettings.currentRenderPipeline is HDRenderPipelineAsset)
			{
				ScriptableRuntimeReflectionSystemSettings.system = HDRuntimeReflectionSystem.k_instance;
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00049C2C File Offset: 0x00047E2C
		public override bool TickRealtimeProbes()
		{
			ReflectionProbe.UpdateCachedState();
			return base.TickRealtimeProbes();
		}

		// Token: 0x0400079B RID: 1947
		private static HDRuntimeReflectionSystem k_instance = new HDRuntimeReflectionSystem();
	}
}
