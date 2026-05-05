using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001DC RID: 476
	// (Invoke) Token: 0x06000C22 RID: 3106
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XAsyncCompletionRoutineInterop(IntPtr asyncBlock);
}
