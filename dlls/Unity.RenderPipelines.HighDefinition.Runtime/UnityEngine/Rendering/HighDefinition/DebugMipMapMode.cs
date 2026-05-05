using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200004A RID: 74
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\MipMapDebug.cs")]
	public enum DebugMipMapMode
	{
		// Token: 0x0400021E RID: 542
		None,
		// Token: 0x0400021F RID: 543
		MipRatio,
		// Token: 0x04000220 RID: 544
		MipCount,
		// Token: 0x04000221 RID: 545
		MipCountReduction,
		// Token: 0x04000222 RID: 546
		StreamingMipBudget,
		// Token: 0x04000223 RID: 547
		StreamingMip
	}
}
