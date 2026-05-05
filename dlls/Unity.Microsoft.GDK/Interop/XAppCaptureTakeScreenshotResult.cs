using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D0 RID: 464
	internal struct XAppCaptureTakeScreenshotResult
	{
		// Token: 0x0400060C RID: 1548
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
		internal string localId;

		// Token: 0x0400060D RID: 1549
		internal XAppCaptureScreenshotFormatFlag availableScreenshotFormats;
	}
}
