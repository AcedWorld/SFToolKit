using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F9 RID: 505
	internal struct XblMultiplayerMatchmakingServer
	{
		// Token: 0x040006C0 RID: 1728
		internal XblMatchmakingStatus Status;

		// Token: 0x040006C1 RID: 1729
		internal UTF8StringPtr StatusDetails;

		// Token: 0x040006C2 RID: 1730
		internal uint TypicalWaitInSeconds;

		// Token: 0x040006C3 RID: 1731
		internal XblMultiplayerSessionReference TargetSessionRef;
	}
}
