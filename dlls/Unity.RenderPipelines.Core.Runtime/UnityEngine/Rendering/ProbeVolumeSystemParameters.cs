using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000086 RID: 134
	public struct ProbeVolumeSystemParameters
	{
		// Token: 0x04000286 RID: 646
		public ProbeVolumeTextureMemoryBudget memoryBudget;

		// Token: 0x04000287 RID: 647
		public ProbeVolumeBlendingTextureMemoryBudget blendingMemoryBudget;

		// Token: 0x04000288 RID: 648
		public Mesh probeDebugMesh;

		// Token: 0x04000289 RID: 649
		public Shader probeDebugShader;

		// Token: 0x0400028A RID: 650
		public Mesh offsetDebugMesh;

		// Token: 0x0400028B RID: 651
		public Shader offsetDebugShader;

		// Token: 0x0400028C RID: 652
		public ComputeShader scenarioBlendingShader;

		// Token: 0x0400028D RID: 653
		public ProbeVolumeSceneData sceneData;

		// Token: 0x0400028E RID: 654
		public ProbeVolumeSHBands shBands;

		// Token: 0x0400028F RID: 655
		public bool supportsRuntimeDebug;

		// Token: 0x04000290 RID: 656
		public bool supportStreaming;
	}
}
