using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001BD RID: 445
	// (Invoke) Token: 0x06000A6C RID: 2668
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void HCWebSocketBinaryMessageFunction(HCWebsocketHandle websocket, IntPtr payloadBytes, uint payloadSize, IntPtr functionContext);
}
