using System;

namespace UnityEngine.Rendering.HighDefinition.Attributes
{
	// Token: 0x02000237 RID: 567
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\MaterialDebug.cs")]
	public enum DebugViewGbuffer
	{
		// Token: 0x04001955 RID: 6485
		None,
		// Token: 0x04001956 RID: 6486
		Depth = 10,
		// Token: 0x04001957 RID: 6487
		BakeDiffuseLightingWithAlbedoPlusEmissive,
		// Token: 0x04001958 RID: 6488
		BakeShadowMask0,
		// Token: 0x04001959 RID: 6489
		BakeShadowMask1,
		// Token: 0x0400195A RID: 6490
		BakeShadowMask2,
		// Token: 0x0400195B RID: 6491
		BakeShadowMask3
	}
}
