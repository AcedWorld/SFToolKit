using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000043 RID: 67
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\LightingDebug.cs")]
	public enum ShadowMapDebugMode
	{
		// Token: 0x040001A2 RID: 418
		None,
		// Token: 0x040001A3 RID: 419
		VisualizePunctualLightAtlas,
		// Token: 0x040001A4 RID: 420
		VisualizeDirectionalLightAtlas,
		// Token: 0x040001A5 RID: 421
		VisualizeAreaLightAtlas,
		// Token: 0x040001A6 RID: 422
		VisualizeCachedPunctualLightAtlas,
		// Token: 0x040001A7 RID: 423
		VisualizeCachedAreaLightAtlas,
		// Token: 0x040001A8 RID: 424
		VisualizeShadowMap,
		// Token: 0x040001A9 RID: 425
		SingleShadow
	}
}
