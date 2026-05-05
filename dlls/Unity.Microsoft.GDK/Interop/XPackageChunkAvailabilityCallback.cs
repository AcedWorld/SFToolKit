using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000268 RID: 616
	// (Invoke) Token: 0x06000E39 RID: 3641
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XPackageChunkAvailabilityCallback(IntPtr context, XPackageChunkSelectorInterop selector, XPackageChunkAvailability availability);
}
