using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D5 RID: 469
	internal struct XAppCaptureLocalResult
	{
		// Token: 0x04000624 RID: 1572
		internal IntPtr clipHandle;

		// Token: 0x04000625 RID: 1573
		internal ulong fileSizeInBytes;

		// Token: 0x04000626 RID: 1574
		internal SYSTEMTIME clipStartTimestamp;

		// Token: 0x04000627 RID: 1575
		internal ulong durationInMilliseconds;

		// Token: 0x04000628 RID: 1576
		internal uint width;

		// Token: 0x04000629 RID: 1577
		internal uint height;

		// Token: 0x0400062A RID: 1578
		internal XAppCaptureVideoEncoding encoding;

		// Token: 0x0400062B RID: 1579
		internal XAppCaptureVideoColorFormat colorFormat;
	}
}
