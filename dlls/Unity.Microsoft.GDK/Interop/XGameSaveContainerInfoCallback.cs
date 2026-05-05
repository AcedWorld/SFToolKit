using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000248 RID: 584
	// (Invoke) Token: 0x06000E07 RID: 3591
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XGameSaveContainerInfoCallback(XGameSaveContainerInfo info, IntPtr context);
}
