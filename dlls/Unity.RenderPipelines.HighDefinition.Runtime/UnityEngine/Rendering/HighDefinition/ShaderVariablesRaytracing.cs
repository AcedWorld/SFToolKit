using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200018C RID: 396
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\Raytracing\\Shaders\\ShaderVariablesRaytracing.cs", needAccessors = false, generateCBuffer = true, constantRegister = 3)]
	internal struct ShaderVariablesRaytracing
	{
		// Token: 0x0400137B RID: 4987
		public float _RayTracingPadding0;

		// Token: 0x0400137C RID: 4988
		public float _RaytracingRayMaxLength;

		// Token: 0x0400137D RID: 4989
		public int _RaytracingNumSamples;

		// Token: 0x0400137E RID: 4990
		public int _RaytracingSampleIndex;

		// Token: 0x0400137F RID: 4991
		public float _RaytracingIntensityClamp;

		// Token: 0x04001380 RID: 4992
		public int _RayCountEnabled;

		// Token: 0x04001381 RID: 4993
		public int _RaytracingPreExposition;

		// Token: 0x04001382 RID: 4994
		public float _RaytracingCameraNearPlane;

		// Token: 0x04001383 RID: 4995
		public float _RaytracingPixelSpreadAngle;

		// Token: 0x04001384 RID: 4996
		public float _RaytracingReflectionMinSmoothness;

		// Token: 0x04001385 RID: 4997
		public float _RaytracingReflectionSmoothnessFadeStart;

		// Token: 0x04001386 RID: 4998
		public int _RaytracingMinRecursion;

		// Token: 0x04001387 RID: 4999
		public int _RaytracingMaxRecursion;

		// Token: 0x04001388 RID: 5000
		public int _RayTracingDiffuseLightingOnly;

		// Token: 0x04001389 RID: 5001
		public float _DirectionalShadowFallbackIntensity;

		// Token: 0x0400138A RID: 5002
		public float _RayTracingLodBias;

		// Token: 0x0400138B RID: 5003
		public int _RayTracingRayMissFallbackHierarchy;

		// Token: 0x0400138C RID: 5004
		public int _RayTracingRayMissUseAmbientProbeAsSky;

		// Token: 0x0400138D RID: 5005
		public int _RayTracingLastBounceFallbackHierarchy;

		// Token: 0x0400138E RID: 5006
		public int _RayTracingClampingFlag;

		// Token: 0x0400138F RID: 5007
		public float _RayTracingAmbientProbeDimmer;

		// Token: 0x04001390 RID: 5008
		public int _RayTracingAPVRayMiss;

		// Token: 0x04001391 RID: 5009
		public float _RayTracingRayBias;

		// Token: 0x04001392 RID: 5010
		public float _RayTracingDistantRayBias;

		// Token: 0x04001393 RID: 5011
		public int _PaddingRT0;
	}
}
