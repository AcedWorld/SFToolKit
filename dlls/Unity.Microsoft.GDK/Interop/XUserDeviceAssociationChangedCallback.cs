using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000294 RID: 660
	// (Invoke) Token: 0x06000E8F RID: 3727
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XUserDeviceAssociationChangedCallback(IntPtr context, ref XUserDeviceAssociationChange change);
}
