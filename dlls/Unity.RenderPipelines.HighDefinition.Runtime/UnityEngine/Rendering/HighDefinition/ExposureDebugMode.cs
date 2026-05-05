using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000044 RID: 68
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\LightingDebug.cs")]
	public enum ExposureDebugMode
	{
		// Token: 0x040001AB RID: 427
		None,
		// Token: 0x040001AC RID: 428
		SceneEV100Values,
		// Token: 0x040001AD RID: 429
		HistogramView,
		// Token: 0x040001AE RID: 430
		FinalImageHistogramView,
		// Token: 0x040001AF RID: 431
		MeteringWeighted
	}
}
