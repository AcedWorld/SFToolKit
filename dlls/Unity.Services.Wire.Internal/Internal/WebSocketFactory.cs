using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000039 RID: 57
	internal class WebSocketFactory : IWebsocketFactory
	{
		// Token: 0x060000EC RID: 236 RVA: 0x00004193 File Offset: 0x00002393
		public IWebSocket CreateInstance(string url)
		{
			return new WebSocket(url);
		}
	}
}
