using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000178 RID: 376
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\Raytracing\\HDRaytracingManager.cs")]
	internal enum RayTracingRendererFlag
	{
		// Token: 0x0400130F RID: 4879
		Opaque = 1,
		// Token: 0x04001310 RID: 4880
		CastShadowTransparent,
		// Token: 0x04001311 RID: 4881
		CastShadowOpaque = 4,
		// Token: 0x04001312 RID: 4882
		CastShadow = 6,
		// Token: 0x04001313 RID: 4883
		AmbientOcclusion = 8,
		// Token: 0x04001314 RID: 4884
		Reflection = 16,
		// Token: 0x04001315 RID: 4885
		GlobalIllumination = 32,
		// Token: 0x04001316 RID: 4886
		RecursiveRendering = 64,
		// Token: 0x04001317 RID: 4887
		PathTracing = 128,
		// Token: 0x04001318 RID: 4888
		All = 255
	}
}
