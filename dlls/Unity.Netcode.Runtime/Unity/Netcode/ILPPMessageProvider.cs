using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x02000058 RID: 88
	internal struct ILPPMessageProvider : INetworkMessageProvider
	{
		// Token: 0x06000246 RID: 582 RVA: 0x0000BF66 File Offset: 0x0000A166
		public List<NetworkMessageManager.MessageWithHandler> GetMessages()
		{
			return ILPPMessageProvider.__network_message_types;
		}

		// Token: 0x04000132 RID: 306
		internal static readonly List<NetworkMessageManager.MessageWithHandler> __network_message_types = new List<NetworkMessageManager.MessageWithHandler>();
	}
}
