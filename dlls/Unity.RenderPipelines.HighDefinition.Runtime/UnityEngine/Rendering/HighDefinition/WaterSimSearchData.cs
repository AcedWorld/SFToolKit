using System;
using Unity.Collections;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200021B RID: 539
	public struct WaterSimSearchData
	{
		// Token: 0x04001860 RID: 6240
		[ReadOnly]
		public NativeArray<float4> displacementData;

		// Token: 0x04001861 RID: 6241
		public float waterSurfaceElevation;

		// Token: 0x04001862 RID: 6242
		public int simulationRes;

		// Token: 0x04001863 RID: 6243
		public WaterSpectrumParameters spectrum;

		// Token: 0x04001864 RID: 6244
		public WaterRenderingParameters rendering;

		// Token: 0x04001865 RID: 6245
		public int activeBandCount;
	}
}
