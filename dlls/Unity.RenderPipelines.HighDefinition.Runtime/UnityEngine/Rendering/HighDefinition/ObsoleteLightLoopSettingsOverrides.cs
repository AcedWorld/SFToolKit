using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B2 RID: 434
	[Flags]
	[Obsolete("For data migration")]
	internal enum ObsoleteLightLoopSettingsOverrides
	{
		// Token: 0x040014E7 RID: 5351
		FptlForForwardOpaque = 1,
		// Token: 0x040014E8 RID: 5352
		BigTilePrepass = 2,
		// Token: 0x040014E9 RID: 5353
		ComputeLightEvaluation = 4,
		// Token: 0x040014EA RID: 5354
		ComputeLightVariants = 8,
		// Token: 0x040014EB RID: 5355
		ComputeMaterialVariants = 16,
		// Token: 0x040014EC RID: 5356
		TileAndCluster = 32
	}
}
