using System;

namespace Unity.Netcode
{
	// Token: 0x0200004F RID: 79
	internal class DefaultMessageSender : INetworkMessageSender
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0000B9E1 File Offset: 0x00009BE1
		public DefaultMessageSender(NetworkManager manager)
		{
			this.m_NetworkTransport = manager.NetworkConfig.NetworkTransport;
			this.m_ConnectionManager = manager.ConnectionManager;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000BA08 File Offset: 0x00009C08
		public void Send(ulong clientId, NetworkDelivery delivery, FastBufferWriter batchData)
		{
			ArraySegment<byte> payload = batchData.ToTempByteArray();
			this.m_NetworkTransport.Send(this.m_ConnectionManager.ClientIdToTransportId(clientId), payload, delivery);
		}

		// Token: 0x04000120 RID: 288
		private NetworkTransport m_NetworkTransport;

		// Token: 0x04000121 RID: 289
		private NetworkConnectionManager m_ConnectionManager;
	}
}
