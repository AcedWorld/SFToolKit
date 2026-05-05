using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C1 RID: 449
	internal struct WebSocketCompletionResult
	{
		// Token: 0x040005D7 RID: 1495
		internal readonly HCWebsocketHandle websocket;

		// Token: 0x040005D8 RID: 1496
		internal readonly int errorCode;

		// Token: 0x040005D9 RID: 1497
		internal readonly uint platformErrorCode;
	}
}
