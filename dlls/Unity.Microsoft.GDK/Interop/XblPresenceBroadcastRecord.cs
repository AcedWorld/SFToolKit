using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200021A RID: 538
	internal struct XblPresenceBroadcastRecord
	{
		// Token: 0x04000774 RID: 1908
		internal readonly UTF8StringPtr broadcastId;

		// Token: 0x04000775 RID: 1909
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] session;

		// Token: 0x04000776 RID: 1910
		internal readonly XblPresenceBroadcastProvider provider;

		// Token: 0x04000777 RID: 1911
		internal readonly uint viewerCount;

		// Token: 0x04000778 RID: 1912
		internal readonly TimeT startTime;
	}
}
