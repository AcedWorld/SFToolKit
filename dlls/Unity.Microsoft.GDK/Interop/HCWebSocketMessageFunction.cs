using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001BC RID: 444
	// (Invoke) Token: 0x06000A68 RID: 2664
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void HCWebSocketMessageFunction(HCWebsocketHandle websocket, IntPtr incomingBodyString, IntPtr functionContext);
}
