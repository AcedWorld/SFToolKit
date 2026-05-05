using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000092 RID: 146
	[Flags]
	[MovedFrom("Unity.GameCore")]
	public enum XblMultiplayerSessionChangeTypes : uint
	{
		// Token: 0x040001AE RID: 430
		None = 0U,
		// Token: 0x040001AF RID: 431
		Everything = 1U,
		// Token: 0x040001B0 RID: 432
		HostDeviceTokenChange = 2U,
		// Token: 0x040001B1 RID: 433
		InitializationStateChange = 4U,
		// Token: 0x040001B2 RID: 434
		MatchmakingStatusChange = 8U,
		// Token: 0x040001B3 RID: 435
		MemberListChange = 16U,
		// Token: 0x040001B4 RID: 436
		MemberStatusChange = 32U,
		// Token: 0x040001B5 RID: 437
		SessionJoinabilityChange = 64U,
		// Token: 0x040001B6 RID: 438
		CustomPropertyChange = 128U,
		// Token: 0x040001B7 RID: 439
		MemberCustomPropertyChange = 256U,
		// Token: 0x040001B8 RID: 440
		TournamentPropertyChange = 512U,
		// Token: 0x040001B9 RID: 441
		ArbitrationPropertyChange = 1024U
	}
}
