using System;

namespace Unity.Netcode
{
	// Token: 0x02000059 RID: 89
	internal interface INetworkHooks
	{
		// Token: 0x06000248 RID: 584
		void OnBeforeSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery) where T : INetworkMessage;

		// Token: 0x06000249 RID: 585
		void OnAfterSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery, int messageSizeBytes) where T : INetworkMessage;

		// Token: 0x0600024A RID: 586
		void OnBeforeReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes);

		// Token: 0x0600024B RID: 587
		void OnAfterReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes);

		// Token: 0x0600024C RID: 588
		void OnBeforeSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery);

		// Token: 0x0600024D RID: 589
		void OnAfterSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery);

		// Token: 0x0600024E RID: 590
		void OnBeforeReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes);

		// Token: 0x0600024F RID: 591
		void OnAfterReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes);

		// Token: 0x06000250 RID: 592
		bool OnVerifyCanSend(ulong destinationId, Type messageType, NetworkDelivery delivery);

		// Token: 0x06000251 RID: 593
		bool OnVerifyCanReceive(ulong senderId, Type messageType, FastBufferReader messageContent, ref NetworkContext context);

		// Token: 0x06000252 RID: 594
		void OnBeforeHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage;

		// Token: 0x06000253 RID: 595
		void OnAfterHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage;
	}
}
