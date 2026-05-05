using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001C6 RID: 454
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\ShaderPass\\ShaderPass.cs")]
	internal enum ShaderPass
	{
		// Token: 0x0400159B RID: 5531
		GBuffer,
		// Token: 0x0400159C RID: 5532
		Forward,
		// Token: 0x0400159D RID: 5533
		ForwardUnlit,
		// Token: 0x0400159E RID: 5534
		DeferredLighting,
		// Token: 0x0400159F RID: 5535
		DepthOnly,
		// Token: 0x040015A0 RID: 5536
		TransparentDepthPrepass,
		// Token: 0x040015A1 RID: 5537
		TransparentDepthPostpass,
		// Token: 0x040015A2 RID: 5538
		MotionVectors,
		// Token: 0x040015A3 RID: 5539
		Distortion,
		// Token: 0x040015A4 RID: 5540
		LightTransport,
		// Token: 0x040015A5 RID: 5541
		Shadows,
		// Token: 0x040015A6 RID: 5542
		SubsurfaceScattering,
		// Token: 0x040015A7 RID: 5543
		VolumetricLighting,
		// Token: 0x040015A8 RID: 5544
		DbufferProjector,
		// Token: 0x040015A9 RID: 5545
		DbufferMesh,
		// Token: 0x040015AA RID: 5546
		ForwardEmissiveProjector,
		// Token: 0x040015AB RID: 5547
		ForwardEmissiveMesh,
		// Token: 0x040015AC RID: 5548
		Raytracing,
		// Token: 0x040015AD RID: 5549
		RaytracingIndirect,
		// Token: 0x040015AE RID: 5550
		RaytracingVisibility,
		// Token: 0x040015AF RID: 5551
		RaytracingForward,
		// Token: 0x040015B0 RID: 5552
		RaytracingGBuffer,
		// Token: 0x040015B1 RID: 5553
		RaytracingSubSurface,
		// Token: 0x040015B2 RID: 5554
		PathTracing,
		// Token: 0x040015B3 RID: 5555
		RayTracingDebug,
		// Token: 0x040015B4 RID: 5556
		Constant,
		// Token: 0x040015B5 RID: 5557
		FullScreenDebug
	}
}
