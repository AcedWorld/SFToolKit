using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F4 RID: 500
	internal struct XblHopperStatisticsResponse
	{
		// Token: 0x040006AB RID: 1707
		internal UTF8StringPtr hopperName;

		// Token: 0x040006AC RID: 1708
		internal long estimatedWaitTime;

		// Token: 0x040006AD RID: 1709
		internal uint playersWaitingToMatch;
	}
}
