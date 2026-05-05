using System;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x0200001B RID: 27
	internal interface IWebSocketSession
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001D7 RID: 471
		string ID { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001D8 RID: 472
		DateTime StartTime { get; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001D9 RID: 473
		WebSocket WebSocket { get; }
	}
}
