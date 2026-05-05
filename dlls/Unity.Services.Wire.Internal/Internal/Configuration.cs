using System;
using Unity.Services.Authentication.Internal;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200001C RID: 28
	internal class Configuration
	{
		// Token: 0x0400008B RID: 139
		public IAccessToken token;

		// Token: 0x0400008C RID: 140
		public string address;

		// Token: 0x0400008D RID: 141
		public double CommandTimeoutInSeconds = 5.0;

		// Token: 0x0400008E RID: 142
		public double RetrieveTokenTimeoutInSeconds = 5.0;

		// Token: 0x0400008F RID: 143
		public IWebSocket WebSocket;

		// Token: 0x04000090 RID: 144
		public double MaxServerPingDelay = 10.0;
	}
}
