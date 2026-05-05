using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D6 RID: 470
	internal struct XAppCaptureVideoCaptureSettings
	{
		// Token: 0x0400062C RID: 1580
		internal uint width;

		// Token: 0x0400062D RID: 1581
		internal uint height;

		// Token: 0x0400062E RID: 1582
		internal ulong maxRecordTimespanDurationInMs;

		// Token: 0x0400062F RID: 1583
		internal XAppCaptureVideoEncoding encoding;

		// Token: 0x04000630 RID: 1584
		internal XAppCaptureVideoColorFormat colorFormat;

		// Token: 0x04000631 RID: 1585
		[MarshalAs(UnmanagedType.I1)]
		internal bool isCaptureByGamesAllowed;
	}
}
