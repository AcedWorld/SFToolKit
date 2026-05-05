using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001CF RID: 463
	internal struct XAppBroadcastStatus
	{
		// Token: 0x04000603 RID: 1539
		[MarshalAs(UnmanagedType.I1)]
		internal bool canStartBroadcast;

		// Token: 0x04000604 RID: 1540
		[MarshalAs(UnmanagedType.I1)]
		internal bool isAnyAppBroadcasting;

		// Token: 0x04000605 RID: 1541
		[MarshalAs(UnmanagedType.I1)]
		internal bool isCaptureResourceUnavailable;

		// Token: 0x04000606 RID: 1542
		[MarshalAs(UnmanagedType.I1)]
		internal bool isGameStreamInProgress;

		// Token: 0x04000607 RID: 1543
		[MarshalAs(UnmanagedType.I1)]
		internal bool isGpuConstrained;

		// Token: 0x04000608 RID: 1544
		[MarshalAs(UnmanagedType.I1)]
		internal bool isAppInactive;

		// Token: 0x04000609 RID: 1545
		[MarshalAs(UnmanagedType.I1)]
		internal bool isBlockedForApp;

		// Token: 0x0400060A RID: 1546
		[MarshalAs(UnmanagedType.I1)]
		internal bool isDisabledByUser;

		// Token: 0x0400060B RID: 1547
		[MarshalAs(UnmanagedType.I1)]
		internal bool isDisabledBySystem;
	}
}
