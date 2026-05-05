using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000176 RID: 374
	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\Raytracing\\HDRaytracingLightCluster.cs")]
	internal struct LightVolume
	{
		// Token: 0x040012DF RID: 4831
		public int active;

		// Token: 0x040012E0 RID: 4832
		public int shape;

		// Token: 0x040012E1 RID: 4833
		public Vector3 position;

		// Token: 0x040012E2 RID: 4834
		public Vector3 range;

		// Token: 0x040012E3 RID: 4835
		public uint lightType;

		// Token: 0x040012E4 RID: 4836
		public uint lightIndex;
	}
}
