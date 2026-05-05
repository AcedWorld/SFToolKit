using System;

namespace Unity.Netcode
{
	// Token: 0x020000A5 RID: 165
	internal class MetricHooks : INetworkHooks
	{
		// Token: 0x06000372 RID: 882 RVA: 0x000113CE File Offset: 0x0000F5CE
		public MetricHooks(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery) where T : INetworkMessage
		{
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000113DD File Offset: 0x0000F5DD
		public void OnAfterSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery, int messageSizeBytes) where T : INetworkMessage
		{
			this.m_NetworkManager.NetworkMetrics.TrackNetworkMessageSent(clientId, typeof(T).Name, (long)messageSizeBytes);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00011402 File Offset: 0x0000F602
		public void OnBeforeReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes)
		{
			this.m_NetworkManager.NetworkMetrics.TrackNetworkMessageReceived(senderId, messageType.Name, (long)messageSizeBytes);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes)
		{
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery)
		{
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0001141D File Offset: 0x0000F61D
		public void OnAfterSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery)
		{
			this.m_NetworkManager.NetworkMetrics.TrackTransportBytesSent((long)batchSizeInBytes);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00011431 File Offset: 0x0000F631
		public void OnBeforeReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes)
		{
			this.m_NetworkManager.NetworkMetrics.TrackTransportBytesReceived((long)batchSizeInBytes);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes)
		{
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000C36D File Offset: 0x0000A56D
		public bool OnVerifyCanSend(ulong destinationId, Type messageType, NetworkDelivery delivery)
		{
			return true;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000C36D File Offset: 0x0000A56D
		public bool OnVerifyCanReceive(ulong senderId, Type messageType, FastBufferReader messageContent, ref NetworkContext context)
		{
			return true;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage
		{
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage
		{
		}

		// Token: 0x040001FD RID: 509
		private readonly NetworkManager m_NetworkManager;
	}
}
