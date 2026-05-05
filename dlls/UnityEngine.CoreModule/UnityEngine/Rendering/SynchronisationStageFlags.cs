using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000429 RID: 1065
	public enum SynchronisationStageFlags
	{
		// Token: 0x04000D0C RID: 3340
		VertexProcessing = 1,
		// Token: 0x04000D0D RID: 3341
		PixelProcessing,
		// Token: 0x04000D0E RID: 3342
		ComputeProcessing = 4,
		// Token: 0x04000D0F RID: 3343
		AllGPUOperations = 7
	}
}
