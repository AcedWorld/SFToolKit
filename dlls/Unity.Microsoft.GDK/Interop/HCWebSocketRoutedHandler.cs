using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001BF RID: 447
	// (Invoke) Token: 0x06000A74 RID: 2676
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void HCWebSocketRoutedHandler(HCWebsocketHandle websocket, NativeBool receiving, [Optional] IntPtr message, [Optional] IntPtr payloadBytes, SizeT payloadSize, IntPtr conext);
}
