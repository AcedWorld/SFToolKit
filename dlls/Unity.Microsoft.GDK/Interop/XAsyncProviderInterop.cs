using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001DF RID: 479
	// (Invoke) Token: 0x06000C2A RID: 3114
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate int XAsyncProviderInterop(XAsyncOp op, XAsyncProviderData data);
}
