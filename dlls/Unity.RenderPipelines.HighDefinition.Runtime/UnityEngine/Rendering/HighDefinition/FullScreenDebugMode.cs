using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000035 RID: 53
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\DebugDisplay.cs")]
	public enum FullScreenDebugMode
	{
		// Token: 0x0400010D RID: 269
		None,
		// Token: 0x0400010E RID: 270
		MinLightingFullScreenDebug,
		// Token: 0x0400010F RID: 271
		ScreenSpaceAmbientOcclusion,
		// Token: 0x04000110 RID: 272
		ScreenSpaceReflections,
		// Token: 0x04000111 RID: 273
		TransparentScreenSpaceReflections,
		// Token: 0x04000112 RID: 274
		ScreenSpaceReflectionsPrev,
		// Token: 0x04000113 RID: 275
		ScreenSpaceReflectionsAccum,
		// Token: 0x04000114 RID: 276
		ScreenSpaceReflectionSpeedRejection,
		// Token: 0x04000115 RID: 277
		ContactShadows,
		// Token: 0x04000116 RID: 278
		ContactShadowsFade,
		// Token: 0x04000117 RID: 279
		ScreenSpaceShadows,
		// Token: 0x04000118 RID: 280
		PreRefractionColorPyramid,
		// Token: 0x04000119 RID: 281
		DepthPyramid,
		// Token: 0x0400011A RID: 282
		FinalColorPyramid,
		// Token: 0x0400011B RID: 283
		LightCluster,
		// Token: 0x0400011C RID: 284
		ScreenSpaceGlobalIllumination,
		// Token: 0x0400011D RID: 285
		RecursiveRayTracing,
		// Token: 0x0400011E RID: 286
		RayTracedSubSurface,
		// Token: 0x0400011F RID: 287
		VolumetricClouds,
		// Token: 0x04000120 RID: 288
		VolumetricCloudsShadow,
		// Token: 0x04000121 RID: 289
		RayTracingAccelerationStructure,
		// Token: 0x04000122 RID: 290
		MaxLightingFullScreenDebug,
		// Token: 0x04000123 RID: 291
		MinRenderingFullScreenDebug,
		// Token: 0x04000124 RID: 292
		MotionVectors,
		// Token: 0x04000125 RID: 293
		WorldSpacePosition,
		// Token: 0x04000126 RID: 294
		NanTracker,
		// Token: 0x04000127 RID: 295
		ColorLog,
		// Token: 0x04000128 RID: 296
		DepthOfFieldCoc,
		// Token: 0x04000129 RID: 297
		TransparencyOverdraw,
		// Token: 0x0400012A RID: 298
		QuadOverdraw,
		// Token: 0x0400012B RID: 299
		LocalVolumetricFogOverdraw,
		// Token: 0x0400012C RID: 300
		VertexDensity,
		// Token: 0x0400012D RID: 301
		RequestedVirtualTextureTiles,
		// Token: 0x0400012E RID: 302
		LensFlareDataDriven,
		// Token: 0x0400012F RID: 303
		MaxRenderingFullScreenDebug,
		// Token: 0x04000130 RID: 304
		MinMaterialFullScreenDebug,
		// Token: 0x04000131 RID: 305
		ValidateDiffuseColor,
		// Token: 0x04000132 RID: 306
		ValidateSpecularColor,
		// Token: 0x04000133 RID: 307
		MaxMaterialFullScreenDebug
	}
}
