using System;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200021C RID: 540
	public struct WaterSearchParameters
	{
		// Token: 0x04001866 RID: 6246
		public float3 targetPosition;

		// Token: 0x04001867 RID: 6247
		public float3 startPosition;

		// Token: 0x04001868 RID: 6248
		public float error;

		// Token: 0x04001869 RID: 6249
		public int maxIterations;
	}
}
