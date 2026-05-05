using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001DA RID: 474
	// (Invoke) Token: 0x06000C1B RID: 3099
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XAppCaptureMetadataPurgedCallback(IntPtr context);
}
