using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200019E RID: 414
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\RenderPass\\CustomPass\\CustomPassInjectionPoint.cs")]
	public enum CustomPassInjectionPoint
	{
		// Token: 0x040013E4 RID: 5092
		BeforeRendering,
		// Token: 0x040013E5 RID: 5093
		AfterOpaqueDepthAndNormal = 5,
		// Token: 0x040013E6 RID: 5094
		AfterOpaqueAndSky,
		// Token: 0x040013E7 RID: 5095
		BeforePreRefraction = 4,
		// Token: 0x040013E8 RID: 5096
		BeforeTransparent = 1,
		// Token: 0x040013E9 RID: 5097
		BeforePostProcess,
		// Token: 0x040013EA RID: 5098
		AfterPostProcess
	}
}
