using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C0 RID: 448
	internal class XGRInterop
	{
		// Token: 0x06000A77 RID: 2679
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCInitialize(IntPtr args);

		// Token: 0x06000A78 RID: 2680
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCCleanupAsync(XAsyncBlockPtr asyncBlock);

		// Token: 0x06000A79 RID: 2681
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketCreate(out HCWebsocketHandle websocket, [Optional] HCWebSocketMessageFunction messageFunc, [Optional] HCWebSocketBinaryMessageFunction binaryMessageFunc, [Optional] HCWebSocketCloseEventFunction closeFunc, IntPtr functionContext);

		// Token: 0x06000A7A RID: 2682
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketSetProxyUri(HCWebsocketHandle websocket, byte[] proxyUri);

		// Token: 0x06000A7B RID: 2683
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketSetHeader(HCWebsocketHandle websocket, byte[] headerName, byte[] headerValue);

		// Token: 0x06000A7C RID: 2684
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketGetEventFunctions(HCWebsocketHandle websocket, [Optional] out HCWebSocketMessageFunction messageFunc, [Optional] out HCWebSocketBinaryMessageFunction binaryMessageFunc, [Optional] out HCWebSocketCloseEventFunction closeFunc, out IntPtr functionContext);

		// Token: 0x06000A7D RID: 2685
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketConnectAsync(byte[] uri, byte[] subProtocol, HCWebsocketHandle websocket, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000A7E RID: 2686
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCGetWebSocketConnectResult(XAsyncBlockPtr asyncBlock, [In] ref WebSocketCompletionResult result);

		// Token: 0x06000A7F RID: 2687
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketSendMessageAsync(HCWebsocketHandle websocket, byte[] message, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000A80 RID: 2688
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketSendBinaryMessageAsync(HCWebsocketHandle websocket, byte[] data, uint payloadSize, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000A81 RID: 2689
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCGetWebSocketSendMessageResult(XAsyncBlockPtr asyncBlock, [In] ref WebSocketCompletionResult result);

		// Token: 0x06000A82 RID: 2690
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketDisconnect(HCWebsocketHandle websocket);

		// Token: 0x06000A83 RID: 2691
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern HCWebsocketHandle HCWebSocketDuplicateHandle(HCWebsocketHandle websocket);

		// Token: 0x06000A84 RID: 2692
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCWebSocketCloseHandle(HCWebsocketHandle websocket);

		// Token: 0x06000A85 RID: 2693
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int HCAddWebSocketRoutedHandler(HCWebSocketRoutedHandler handler, IntPtr conext);

		// Token: 0x06000A86 RID: 2694
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void HCRemoveWebSocketRoutedHandler(int handlerId);
	}
}
