using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000DE RID: 222
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\VolumetricLighting\\HDRenderPipeline.VolumetricLighting.cs")]
	public enum LocalVolumetricFogBlendingMode
	{
		// Token: 0x0400096D RID: 2413
		Overwrite,
		// Token: 0x0400096E RID: 2414
		Additive,
		// Token: 0x0400096F RID: 2415
		Multiply,
		// Token: 0x04000970 RID: 2416
		Min,
		// Token: 0x04000971 RID: 2417
		Max
	}
}
