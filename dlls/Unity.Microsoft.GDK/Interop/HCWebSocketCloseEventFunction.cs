using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001BE RID: 446
	// (Invoke) Token: 0x06000A70 RID: 2672
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void HCWebSocketCloseEventFunction(HCWebsocketHandle websocket, HCWebSocketCloseStatus closeStatus, IntPtr functionContext);
}
