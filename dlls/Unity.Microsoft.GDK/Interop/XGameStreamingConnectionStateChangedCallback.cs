using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000252 RID: 594
	// (Invoke) Token: 0x06000E18 RID: 3608
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XGameStreamingConnectionStateChangedCallback(IntPtr context, XGameStreamingClientId client, XGameStreamingConnectionState state);
}
