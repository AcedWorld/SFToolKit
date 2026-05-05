using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000247 RID: 583
	// (Invoke) Token: 0x06000E03 RID: 3587
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XGameSaveBlobInfoCallback(XGameSaveBlobInfo info, IntPtr context);
}
