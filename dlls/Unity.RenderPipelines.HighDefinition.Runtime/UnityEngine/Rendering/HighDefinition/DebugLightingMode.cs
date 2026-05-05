using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200003F RID: 63
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\LightingDebug.cs")]
	public enum DebugLightingMode
	{
		// Token: 0x0400017B RID: 379
		None,
		// Token: 0x0400017C RID: 380
		DiffuseLighting,
		// Token: 0x0400017D RID: 381
		SpecularLighting,
		// Token: 0x0400017E RID: 382
		DirectDiffuseLighting,
		// Token: 0x0400017F RID: 383
		DirectSpecularLighting,
		// Token: 0x04000180 RID: 384
		IndirectDiffuseLighting,
		// Token: 0x04000181 RID: 385
		ReflectionLighting,
		// Token: 0x04000182 RID: 386
		RefractionLighting,
		// Token: 0x04000183 RID: 387
		EmissiveLighting,
		// Token: 0x04000184 RID: 388
		LuxMeter,
		// Token: 0x04000185 RID: 389
		LuminanceMeter,
		// Token: 0x04000186 RID: 390
		MatcapView,
		// Token: 0x04000187 RID: 391
		VisualizeCascade,
		// Token: 0x04000188 RID: 392
		VisualizeShadowMasks,
		// Token: 0x04000189 RID: 393
		IndirectDiffuseOcclusion,
		// Token: 0x0400018A RID: 394
		IndirectSpecularOcclusion,
		// Token: 0x0400018B RID: 395
		ProbeVolumeSampledSubdivision
	}
}
