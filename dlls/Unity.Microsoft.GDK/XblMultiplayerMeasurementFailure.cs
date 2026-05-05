using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B3 RID: 179
	[MovedFrom("Unity.GameCore")]
	public enum XblMultiplayerMeasurementFailure : uint
	{
		// Token: 0x0400028D RID: 653
		Unknown,
		// Token: 0x0400028E RID: 654
		None,
		// Token: 0x0400028F RID: 655
		Timeout,
		// Token: 0x04000290 RID: 656
		Latency,
		// Token: 0x04000291 RID: 657
		BandwidthUp,
		// Token: 0x04000292 RID: 658
		BandwidthDown,
		// Token: 0x04000293 RID: 659
		Group,
		// Token: 0x04000294 RID: 660
		Network,
		// Token: 0x04000295 RID: 661
		Episode
	}
}
