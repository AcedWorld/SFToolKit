using System;

namespace Unity.Netcode
{
	// Token: 0x0200005C RID: 92
	internal interface INetworkMessageSender
	{
		// Token: 0x06000259 RID: 601
		void Send(ulong clientId, NetworkDelivery delivery, FastBufferWriter batchData);
	}
}
