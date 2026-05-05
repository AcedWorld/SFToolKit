using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000032 RID: 50
	internal interface IWebSocket
	{
		// Token: 0x060000C1 RID: 193
		void Connect();

		// Token: 0x060000C2 RID: 194
		void Close(WebSocketCloseCode code = WebSocketCloseCode.Normal, string reason = null);

		// Token: 0x060000C3 RID: 195
		void Send(byte[] data);

		// Token: 0x060000C4 RID: 196
		WebSocketState GetState();

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000C5 RID: 197
		// (remove) Token: 0x060000C6 RID: 198
		event WebSocketOpenEventHandler OnOpen;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000C7 RID: 199
		// (remove) Token: 0x060000C8 RID: 200
		event WebSocketMessageEventHandler OnMessage;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000C9 RID: 201
		// (remove) Token: 0x060000CA RID: 202
		event WebSocketErrorEventHandler OnError;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000CB RID: 203
		// (remove) Token: 0x060000CC RID: 204
		event WebSocketCloseEventHandler OnClose;
	}
}
