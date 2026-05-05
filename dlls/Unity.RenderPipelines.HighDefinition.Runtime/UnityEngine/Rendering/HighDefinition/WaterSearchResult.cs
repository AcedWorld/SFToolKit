using System;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200021D RID: 541
	public struct WaterSearchResult
	{
		// Token: 0x0400186A RID: 6250
		public float height;

		// Token: 0x0400186B RID: 6251
		public float error;

		// Token: 0x0400186C RID: 6252
		public float3 candidateLocation;

		// Token: 0x0400186D RID: 6253
		public int numIterations;
	}
}
