using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D9 RID: 473
	// (Invoke) Token: 0x06000C17 RID: 3095
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XAppBroadcastMonitorCallback(IntPtr context);
}
