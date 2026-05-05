using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000AF RID: 175
	[MovedFrom("Unity.GameCore")]
	public enum XblMultiplayerEventType : uint
	{
		// Token: 0x04000252 RID: 594
		UserAdded,
		// Token: 0x04000253 RID: 595
		UserRemoved,
		// Token: 0x04000254 RID: 596
		MemberJoined,
		// Token: 0x04000255 RID: 597
		MemberLeft,
		// Token: 0x04000256 RID: 598
		MemberPropertyChanged,
		// Token: 0x04000257 RID: 599
		LocalMemberPropertyWriteCompleted,
		// Token: 0x04000258 RID: 600
		LocalMemberConnectionAddressWriteCompleted,
		// Token: 0x04000259 RID: 601
		SessionPropertyChanged,
		// Token: 0x0400025A RID: 602
		SessionPropertyWriteCompleted,
		// Token: 0x0400025B RID: 603
		SessionSynchronizedPropertyWriteCompleted,
		// Token: 0x0400025C RID: 604
		HostChanged,
		// Token: 0x0400025D RID: 605
		SynchronizedHostWriteCompleted,
		// Token: 0x0400025E RID: 606
		JoinabilityStateChanged,
		// Token: 0x0400025F RID: 607
		PerformQosMeasurements,
		// Token: 0x04000260 RID: 608
		FindMatchCompleted,
		// Token: 0x04000261 RID: 609
		JoinGameCompleted,
		// Token: 0x04000262 RID: 610
		LeaveGameCompleted,
		// Token: 0x04000263 RID: 611
		JoinLobbyCompleted,
		// Token: 0x04000264 RID: 612
		ClientDisconnectedFromMultiplayerService,
		// Token: 0x04000265 RID: 613
		InviteSent,
		// Token: 0x04000266 RID: 614
		TournamentRegistrationStateChanged,
		// Token: 0x04000267 RID: 615
		TournamentGameSessionReady,
		// Token: 0x04000268 RID: 616
		ArbitrationComplete
	}
}
