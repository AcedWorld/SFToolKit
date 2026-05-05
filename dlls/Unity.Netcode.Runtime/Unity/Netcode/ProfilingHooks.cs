using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace Unity.Netcode
{
	// Token: 0x020000DB RID: 219
	internal class ProfilingHooks : INetworkHooks
	{
		// Token: 0x06000532 RID: 1330 RVA: 0x00015C78 File Offset: 0x00013E78
		private ProfilerMarker GetHandlerProfilerMarker(Type type)
		{
			ProfilerMarker profilerMarker;
			if (this.m_HandlerProfilerMarkers.TryGetValue(type, out profilerMarker))
			{
				return profilerMarker;
			}
			profilerMarker = new ProfilerMarker("NetworkMessageManager.DeserializeAndHandle." + type.Name);
			this.m_HandlerProfilerMarkers[type] = profilerMarker;
			return profilerMarker;
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00015CBC File Offset: 0x00013EBC
		private ProfilerMarker GetSenderProfilerMarker(Type type)
		{
			ProfilerMarker profilerMarker;
			if (this.m_SenderProfilerMarkers.TryGetValue(type, out profilerMarker))
			{
				return profilerMarker;
			}
			profilerMarker = new ProfilerMarker("NetworkMessageManager.SerializeAndEnqueue." + type.Name);
			this.m_SenderProfilerMarkers[type] = profilerMarker;
			return profilerMarker;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery) where T : INetworkMessage
		{
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery, int messageSizeBytes) where T : INetworkMessage
		{
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes)
		{
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes)
		{
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery)
		{
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery)
		{
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes)
		{
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes)
		{
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0000C36D File Offset: 0x0000A56D
		public bool OnVerifyCanSend(ulong destinationId, Type messageType, NetworkDelivery delivery)
		{
			return true;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0000C36D File Offset: 0x0000A56D
		public bool OnVerifyCanReceive(ulong senderId, Type messageType, FastBufferReader messageContent, ref NetworkContext context)
		{
			return true;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage
		{
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage
		{
		}

		// Token: 0x0400026E RID: 622
		private Dictionary<Type, ProfilerMarker> m_HandlerProfilerMarkers = new Dictionary<Type, ProfilerMarker>();

		// Token: 0x0400026F RID: 623
		private Dictionary<Type, ProfilerMarker> m_SenderProfilerMarkers = new Dictionary<Type, ProfilerMarker>();

		// Token: 0x04000270 RID: 624
		private readonly ProfilerMarker m_SendBatch = new ProfilerMarker("NetworkMessageManager.SendBatch");

		// Token: 0x04000271 RID: 625
		private readonly ProfilerMarker m_ReceiveBatch = new ProfilerMarker("NetworkMessageManager.ReceiveBatchBatch");
	}
}
