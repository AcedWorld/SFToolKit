using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000045 RID: 69
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\LightingDebug.cs")]
	public enum HDRDebugMode
	{
		// Token: 0x040001B1 RID: 433
		None,
		// Token: 0x040001B2 RID: 434
		GamutView,
		// Token: 0x040001B3 RID: 435
		GamutClip,
		// Token: 0x040001B4 RID: 436
		ValuesAbovePaperWhite
	}
}
