using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000243 RID: 579
	// (Invoke) Token: 0x06000DFF RID: 3583
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XGameProtocolActivationCallback(IntPtr context, [MarshalAs(UnmanagedType.LPStr)] string protocolUri);
}
