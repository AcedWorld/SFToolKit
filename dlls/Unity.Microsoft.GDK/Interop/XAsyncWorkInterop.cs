using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001DD RID: 477
	// (Invoke) Token: 0x06000C26 RID: 3110
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate int XAsyncWorkInterop(IntPtr asyncBlock);
}
