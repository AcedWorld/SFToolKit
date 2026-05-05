using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x0200005B RID: 91
	internal interface INetworkMessageProvider
	{
		// Token: 0x06000258 RID: 600
		List<NetworkMessageManager.MessageWithHandler> GetMessages();
	}
}
