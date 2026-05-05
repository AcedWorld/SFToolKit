using System;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.MetricTestData
{
	// Token: 0x02000004 RID: 4
	internal interface ITestDataTracker
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3
		IMetricDispatcher Dispatcher { get; }

		// Token: 0x06000004 RID: 4
		void SetConnectionId(ulong connectionId);

		// Token: 0x06000005 RID: 5
		void TrackTransportBytesSent(long bytesCount);

		// Token: 0x06000006 RID: 6
		void TrackTransportBytesReceived(long bytesCount);

		// Token: 0x06000007 RID: 7
		void TrackNetworkMessageSent(NetworkMessageEvent networkMessageEvent);

		// Token: 0x06000008 RID: 8
		void TrackNetworkMessageReceived(NetworkMessageEvent networkMessageEvent);

		// Token: 0x06000009 RID: 9
		void TrackNamedMessageSent(NamedMessageEvent namedMessageEvent);

		// Token: 0x0600000A RID: 10
		void TrackNamedMessageReceived(NamedMessageEvent namedMessageEvent);

		// Token: 0x0600000B RID: 11
		void TrackUnnamedMessageSent(UnnamedMessageEvent unnamedMessageEvent);

		// Token: 0x0600000C RID: 12
		void TrackUnnamedMessageReceived(UnnamedMessageEvent unnamedMessageEvent);

		// Token: 0x0600000D RID: 13
		void TrackNetworkVariableDeltaSent(NetworkVariableEvent networkVariableEvent);

		// Token: 0x0600000E RID: 14
		void TrackNetworkVariableDeltaReceived(NetworkVariableEvent networkVariableEvent);

		// Token: 0x0600000F RID: 15
		void TrackOwnershipChangeSent(OwnershipChangeEvent ownershipChangeEvent);

		// Token: 0x06000010 RID: 16
		void TrackOwnershipChangeReceived(OwnershipChangeEvent ownershipChangeEvent);

		// Token: 0x06000011 RID: 17
		void TrackObjectSpawnSent(ObjectSpawnedEvent objectSpawnedEvent);

		// Token: 0x06000012 RID: 18
		void TrackObjectSpawnReceived(ObjectSpawnedEvent objectSpawnedEvent);

		// Token: 0x06000013 RID: 19
		void TrackObjectDestroySent(ObjectDestroyedEvent objectDestroyedEvent);

		// Token: 0x06000014 RID: 20
		void TrackObjectDestroyReceived(ObjectDestroyedEvent objectDestroyedEvent);

		// Token: 0x06000015 RID: 21
		void TrackRpcSent(RpcEvent rpcEvent);

		// Token: 0x06000016 RID: 22
		void TrackRpcReceived(RpcEvent rpcEvent);

		// Token: 0x06000017 RID: 23
		void TrackServerLogSent(ServerLogEvent serverLogEvent);

		// Token: 0x06000018 RID: 24
		void TrackServerLogReceived(ServerLogEvent serverLogEvent);

		// Token: 0x06000019 RID: 25
		void TrackSceneEventSent(SceneEventMetric sceneEvent);

		// Token: 0x0600001A RID: 26
		void TrackSceneEventReceived(SceneEventMetric sceneEvent);

		// Token: 0x0600001B RID: 27
		void TrackPacketSent(int packetCount);

		// Token: 0x0600001C RID: 28
		void TrackPacketReceived(int packetCount);

		// Token: 0x0600001D RID: 29
		void TrackRttToServer(int rtt);

		// Token: 0x0600001E RID: 30
		void UpdateNetworkObjectsCount(int count);

		// Token: 0x0600001F RID: 31
		void UpdateConnectionsCount(int count);

		// Token: 0x06000020 RID: 32
		void UpdatePacketLoss(float count);
	}
}
