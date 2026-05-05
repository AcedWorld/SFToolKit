using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000169 RID: 361
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\HDStencilUsage.cs")]
	internal enum StencilUsage
	{
		// Token: 0x04000E98 RID: 3736
		Clear,
		// Token: 0x04000E99 RID: 3737
		IsUnlit,
		// Token: 0x04000E9A RID: 3738
		RequiresDeferredLighting,
		// Token: 0x04000E9B RID: 3739
		SubsurfaceScattering = 4,
		// Token: 0x04000E9C RID: 3740
		TraceReflectionRay = 8,
		// Token: 0x04000E9D RID: 3741
		Decals = 16,
		// Token: 0x04000E9E RID: 3742
		ObjectMotionVector = 32,
		// Token: 0x04000E9F RID: 3743
		ExcludeFromTUAndAA = 2,
		// Token: 0x04000EA0 RID: 3744
		DistortionVectors = 4,
		// Token: 0x04000EA1 RID: 3745
		SMAA = 4,
		// Token: 0x04000EA2 RID: 3746
		WaterSurface = 16,
		// Token: 0x04000EA3 RID: 3747
		AfterOpaqueReservedBits = 56,
		// Token: 0x04000EA4 RID: 3748
		UserBit0 = 64,
		// Token: 0x04000EA5 RID: 3749
		UserBit1 = 128,
		// Token: 0x04000EA6 RID: 3750
		HDRPReservedBits = 63
	}
}
