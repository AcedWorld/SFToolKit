using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D1 RID: 465
	internal struct XAppCaptureRecordClipResult
	{
		// Token: 0x0400060E RID: 1550
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		internal string path;

		// Token: 0x0400060F RID: 1551
		internal long fileSize;

		// Token: 0x04000610 RID: 1552
		internal long startTime;

		// Token: 0x04000611 RID: 1553
		internal uint durationInMs;

		// Token: 0x04000612 RID: 1554
		internal uint width;

		// Token: 0x04000613 RID: 1555
		internal uint height;

		// Token: 0x04000614 RID: 1556
		internal XAppCaptureVideoEncoding encoding;

		// Token: 0x04000615 RID: 1557
		internal uint startTimePreciseOffsetHns;
	}
}
