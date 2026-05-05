using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F3 RID: 499
	internal struct XblCreateMatchTicketResponse
	{
		// Token: 0x040006A9 RID: 1705
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal byte[] matchTicketId;

		// Token: 0x040006AA RID: 1706
		internal long estimatedWaitTime;
	}
}
