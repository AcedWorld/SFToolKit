using System;
using WebSocketSharp.Net.WebSockets;

namespace WebSocketSharp.Server
{
	// Token: 0x02000049 RID: 73
	public interface IWebSocketSession
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060004DE RID: 1246
		WebSocketState ConnectionState { get; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060004DF RID: 1247
		WebSocketContext Context { get; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060004E0 RID: 1248
		string ID { get; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060004E1 RID: 1249
		string Protocol { get; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060004E2 RID: 1250
		DateTime StartTime { get; }
	}
}
