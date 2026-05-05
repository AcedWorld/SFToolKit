using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B4 RID: 436
	[Obsolete("For data migration")]
	[Serializable]
	internal class ObsoleteLightLoopSettings
	{
		// Token: 0x0400150D RID: 5389
		public ObsoleteLightLoopSettingsOverrides overrides;

		// Token: 0x0400150E RID: 5390
		[FormerlySerializedAs("enableTileAndCluster")]
		public bool enableDeferredTileAndCluster;

		// Token: 0x0400150F RID: 5391
		public bool enableComputeLightEvaluation;

		// Token: 0x04001510 RID: 5392
		public bool enableComputeLightVariants;

		// Token: 0x04001511 RID: 5393
		public bool enableComputeMaterialVariants;

		// Token: 0x04001512 RID: 5394
		public bool enableFptlForForwardOpaque;

		// Token: 0x04001513 RID: 5395
		public bool enableBigTilePrepass;

		// Token: 0x04001514 RID: 5396
		public bool isFptlEnabled;
	}
}
