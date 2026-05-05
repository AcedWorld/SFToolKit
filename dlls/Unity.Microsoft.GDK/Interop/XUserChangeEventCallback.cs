using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000291 RID: 657
	// (Invoke) Token: 0x06000E87 RID: 3719
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XUserChangeEventCallback(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent changeEvent);
}
