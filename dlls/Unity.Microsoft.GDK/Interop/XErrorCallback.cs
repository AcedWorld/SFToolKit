using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200023F RID: 575
	// (Invoke) Token: 0x06000DEF RID: 3567
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XErrorCallback(int hr, [MarshalAs(UnmanagedType.LPStr)] string msg, IntPtr context);
}
