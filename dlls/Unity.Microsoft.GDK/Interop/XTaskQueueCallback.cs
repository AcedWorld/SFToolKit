using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200028C RID: 652
	// (Invoke) Token: 0x06000E79 RID: 3705
	internal delegate void XTaskQueueCallback(IntPtr context, [MarshalAs(UnmanagedType.I1)] bool canceled);
}
