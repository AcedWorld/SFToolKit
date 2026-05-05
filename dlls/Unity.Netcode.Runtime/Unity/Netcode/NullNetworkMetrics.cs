using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x020000AA RID: 170
	internal class NullNetworkMetrics : INetworkMetrics
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x00004E3E File Offset: 0x0000303E
		public void SetConnectionId(ulong connectionId)
		{
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackTransportBytesSent(long bytesCount)
		{
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackTransportBytesReceived(long bytesCount)
		{
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNetworkMessageSent(ulong receivedClientId, string messageType, long bytesCount)
		{
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNetworkMessageReceived(ulong senderClientId, string messageType, long bytesCount)
		{
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNamedMessageSent(ulong receiverClientId, string messageName, long bytesCount)
		{
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNamedMessageSent(IReadOnlyCollection<ulong> receiverClientIds, string messageName, long bytesCount)
		{
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNamedMessageReceived(ulong senderClientId, string messageName, long bytesCount)
		{
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackUnnamedMessageSent(ulong receiverClientId, long bytesCount)
		{
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackUnnamedMessageSent(IReadOnlyCollection<ulong> receiverClientIds, long bytesCount)
		{
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackUnnamedMessageReceived(ulong senderClientId, long bytesCount)
		{
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNetworkVariableDeltaSent(ulong receiverClientId, NetworkObject networkObject, string variableName, string networkBehaviourName, long bytesCount)
		{
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackNetworkVariableDeltaReceived(ulong senderClientId, NetworkObject networkObject, string variableName, string networkBehaviourName, long bytesCount)
		{
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackOwnershipChangeSent(ulong receiverClientId, NetworkObject networkObject, long bytesCount)
		{
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackOwnershipChangeReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackObjectSpawnSent(ulong receiverClientId, NetworkObject networkObject, long bytesCount)
		{
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackObjectSpawnReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackObjectDestroySent(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackObjectDestroyReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackRpcSent(ulong receiverClientId, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount)
		{
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackRpcSent(ulong[] receiverClientIds, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount)
		{
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackRpcReceived(ulong senderClientId, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount)
		{
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackServerLogSent(ulong receiverClientId, uint logType, long bytesCount)
		{
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackServerLogReceived(ulong senderClientId, uint logType, long bytesCount)
		{
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackSceneEventSent(IReadOnlyList<ulong> receiverClientIds, uint sceneEventType, string sceneName, long bytesCount)
		{
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackSceneEventSent(ulong receiverClientId, uint sceneEventType, string sceneName, long bytesCount)
		{
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackSceneEventReceived(ulong senderClientId, uint sceneEventType, string sceneName, long bytesCount)
		{
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackPacketSent(uint packetCount)
		{
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00004E3E File Offset: 0x0000303E
		public void TrackPacketReceived(uint packetCount)
		{
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00004E3E File Offset: 0x0000303E
		public void UpdateRttToServer(int rtt)
		{
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00004E3E File Offset: 0x0000303E
		public void UpdateNetworkObjectsCount(int count)
		{
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00004E3E File Offset: 0x0000303E
		public void UpdateConnectionsCount(int count)
		{
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00004E3E File Offset: 0x0000303E
		public void UpdatePacketLoss(float packetLoss)
		{
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00004E3E File Offset: 0x0000303E
		public void DispatchFrame()
		{
		}
	}
}
