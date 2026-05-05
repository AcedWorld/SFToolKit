using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001ED RID: 493
	// (Invoke) Token: 0x06000D94 RID: 3476
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void HCTraceCallback(byte[] areaName, HCTraceLevel level, ulong threadId, ulong timestamp, byte[] message);
}
