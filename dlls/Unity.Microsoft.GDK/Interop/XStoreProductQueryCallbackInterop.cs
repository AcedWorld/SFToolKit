using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000280 RID: 640
	// (Invoke) Token: 0x06000E55 RID: 3669
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XStoreProductQueryCallbackInterop([In] ref XStoreProductInterop product, IntPtr context);
}
