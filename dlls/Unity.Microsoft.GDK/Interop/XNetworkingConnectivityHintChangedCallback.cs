using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200025E RID: 606
	// (Invoke) Token: 0x06000E24 RID: 3620
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XNetworkingConnectivityHintChangedCallback(IntPtr context, XNetworkingConnectivityHint connectivityHint);
}
