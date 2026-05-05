using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200025A RID: 602
	internal struct XNetworkingTcpQueuedReceivedBufferUsageStatistics
	{
		// Token: 0x04000831 RID: 2097
		internal ulong numBytesCurrentlyQueued;

		// Token: 0x04000832 RID: 2098
		internal ulong peakNumBytesEverQueued;

		// Token: 0x04000833 RID: 2099
		internal ulong totalNumBytesQueued;

		// Token: 0x04000834 RID: 2100
		internal ulong numBytesDroppedForExceedingConfiguredMax;

		// Token: 0x04000835 RID: 2101
		internal ulong numBytesDroppedDueToAnyFailure;
	}
}
