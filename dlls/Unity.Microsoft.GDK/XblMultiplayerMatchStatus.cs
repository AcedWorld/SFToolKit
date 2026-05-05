using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B2 RID: 178
	[MovedFrom("Unity.GameCore")]
	public enum XblMultiplayerMatchStatus : uint
	{
		// Token: 0x0400027C RID: 636
		None,
		// Token: 0x0400027D RID: 637
		SubmittingMatchTicket,
		// Token: 0x0400027E RID: 638
		Searching,
		// Token: 0x0400027F RID: 639
		Found,
		// Token: 0x04000280 RID: 640
		Joining,
		// Token: 0x04000281 RID: 641
		WaitingForRemoteClientsToJoin,
		// Token: 0x04000282 RID: 642
		Measuring,
		// Token: 0x04000283 RID: 643
		UploadingQosMeasurements,
		// Token: 0x04000284 RID: 644
		WaitingForRemoteClientsToUploadQos,
		// Token: 0x04000285 RID: 645
		Evaluating,
		// Token: 0x04000286 RID: 646
		Completed,
		// Token: 0x04000287 RID: 647
		Resubmitting,
		// Token: 0x04000288 RID: 648
		Expired,
		// Token: 0x04000289 RID: 649
		Canceling,
		// Token: 0x0400028A RID: 650
		Canceled,
		// Token: 0x0400028B RID: 651
		Failed
	}
}
