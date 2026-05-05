using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200009D RID: 157
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@14.0.11\\Runtime\\PostProcessing\\HDROutputDefines.cs")]
	public enum HDRRangeReduction
	{
		// Token: 0x04000367 RID: 871
		None,
		// Token: 0x04000368 RID: 872
		Reinhard,
		// Token: 0x04000369 RID: 873
		BT2390,
		// Token: 0x0400036A RID: 874
		ACES1000Nits,
		// Token: 0x0400036B RID: 875
		ACES2000Nits,
		// Token: 0x0400036C RID: 876
		ACES4000Nits
	}
}
