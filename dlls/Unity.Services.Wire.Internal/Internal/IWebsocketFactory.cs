using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000028 RID: 40
	internal interface IWebsocketFactory
	{
		// Token: 0x060000A4 RID: 164
		IWebSocket CreateInstance(string url);
	}
}
