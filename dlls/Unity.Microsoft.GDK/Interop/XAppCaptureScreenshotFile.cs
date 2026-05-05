using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D2 RID: 466
	internal struct XAppCaptureScreenshotFile
	{
		// Token: 0x04000616 RID: 1558
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		internal string path;

		// Token: 0x04000617 RID: 1559
		internal long fileSize;

		// Token: 0x04000618 RID: 1560
		internal uint width;

		// Token: 0x04000619 RID: 1561
		internal uint height;
	}
}
