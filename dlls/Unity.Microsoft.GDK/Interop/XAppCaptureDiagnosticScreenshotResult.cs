using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D3 RID: 467
	internal struct XAppCaptureDiagnosticScreenshotResult
	{
		// Token: 0x0400061A RID: 1562
		internal long fileCount;

		// Token: 0x0400061B RID: 1563
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		internal XAppCaptureScreenshotFile[] files;
	}
}
