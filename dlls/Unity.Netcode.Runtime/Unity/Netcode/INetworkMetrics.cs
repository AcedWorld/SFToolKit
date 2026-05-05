using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x020000A4 RID: 164
	internal interface INetworkMetrics
	{
		// Token: 0x06000350 RID: 848
		void SetConnectionId(ulong connectionId);

		// Token: 0x06000351 RID: 849
		void TrackTransportBytesSent(long bytesCount);

		// Token: 0x06000352 RID: 850
		void TrackTransportBytesReceived(long bytesCount);

		// Token: 0x06000353 RID: 851
		void TrackNetworkMessageSent(ulong receivedClientId, string messageType, long bytesCount);

		// Token: 0x06000354 RID: 852
		void TrackNetworkMessageReceived(ulong senderClientId, string messageType, long bytesCount);

		// Token: 0x06000355 RID: 853
		void TrackNamedMessageSent(ulong receiverClientId, string messageName, long bytesCount);

		// Token: 0x06000356 RID: 854
		void TrackNamedMessageSent(IReadOnlyCollection<ulong> receiverClientIds, string messageName, long bytesCount);

		// Token: 0x06000357 RID: 855
		void TrackNamedMessageReceived(ulong senderClientId, string messageName, long bytesCount);

		// Token: 0x06000358 RID: 856
		void TrackUnnamedMessageSent(ulong receiverClientId, long bytesCount);

		// Token: 0x06000359 RID: 857
		void TrackUnnamedMessageSent(IReadOnlyCollection<ulong> receiverClientIds, long bytesCount);

		// Token: 0x0600035A RID: 858
		void TrackUnnamedMessageReceived(ulong senderClientId, long bytesCount);

		// Token: 0x0600035B RID: 859
		void TrackNetworkVariableDeltaSent(ulong receiverClientId, NetworkObject networkObject, string variableName, string networkBehaviourName, long bytesCount);

		// Token: 0x0600035C RID: 860
		void TrackNetworkVariableDeltaReceived(ulong senderClientId, NetworkObject networkObject, string variableName, string networkBehaviourName, long bytesCount);

		// Token: 0x0600035D RID: 861
		void TrackOwnershipChangeSent(ulong receiverClientId, NetworkObject networkObject, long bytesCount);

		// Token: 0x0600035E RID: 862
		void TrackOwnershipChangeReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount);

		// Token: 0x0600035F RID: 863
		void TrackObjectSpawnSent(ulong receiverClientId, NetworkObject networkObject, long bytesCount);

		// Token: 0x06000360 RID: 864
		void TrackObjectSpawnReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount);

		// Token: 0x06000361 RID: 865
		void TrackObjectDestroySent(ulong receiverClientId, NetworkObject networkObject, long bytesCount);

		// Token: 0x06000362 RID: 866
		void TrackObjectDestroyReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount);

		// Token: 0x06000363 RID: 867
		void TrackRpcSent(ulong receiverClientId, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount);

		// Token: 0x06000364 RID: 868
		void TrackRpcSent(ulong[] receiverClientIds, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount);

		// Token: 0x06000365 RID: 869
		void TrackRpcReceived(ulong senderClientId, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount);

		// Token: 0x06000366 RID: 870
		void TrackServerLogSent(ulong receiverClientId, uint logType, long bytesCount);

		// Token: 0x06000367 RID: 871
		void TrackServerLogReceived(ulong senderClientId, uint logType, long bytesCount);

		// Token: 0x06000368 RID: 872
		void TrackSceneEventSent(IReadOnlyList<ulong> receiverClientIds, uint sceneEventType, string sceneName, long bytesCount);

		// Token: 0x06000369 RID: 873
		void TrackSceneEventSent(ulong receiverClientId, uint sceneEventType, string sceneName, long bytesCount);

		// Token: 0x0600036A RID: 874
		void TrackSceneEventReceived(ulong senderClientId, uint sceneEventType, string sceneName, long bytesCount);

		// Token: 0x0600036B RID: 875
		void TrackPacketSent(uint packetCount);

		// Token: 0x0600036C RID: 876
		void TrackPacketReceived(uint packetCount);

		// Token: 0x0600036D RID: 877
		void UpdateRttToServer(int rtt);

		// Token: 0x0600036E RID: 878
		void UpdateNetworkObjectsCount(int count);

		// Token: 0x0600036F RID: 879
		void UpdateConnectionsCount(int count);

		// Token: 0x06000370 RID: 880
		void UpdatePacketLoss(float packetLoss);

		// Token: 0x06000371 RID: 881
		void DispatchFrame();
	}
}
