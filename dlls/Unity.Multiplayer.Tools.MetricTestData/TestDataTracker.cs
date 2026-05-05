using System;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.MetricTestData
{
	// Token: 0x02000005 RID: 5
	internal class TestDataTracker : ITestDataTracker
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000020BC File Offset: 0x000002BC
		public TestDataTracker()
		{
			this.Dispatcher = new MetricDispatcherBuilder().WithCounters(new Counter[]
			{
				this.m_TransportBytesSent,
				this.m_TransportBytesReceived
			}).WithMetricEvents<NetworkMessageEvent>(new EventMetric<NetworkMessageEvent>[]
			{
				this.m_NetworkMessageSentEvent,
				this.m_NetworkMessageReceivedEvent
			}).WithMetricEvents<NamedMessageEvent>(new EventMetric<NamedMessageEvent>[]
			{
				this.m_NamedMessageSentEvent,
				this.m_NamedMessageReceivedEvent
			}).WithMetricEvents<UnnamedMessageEvent>(new EventMetric<UnnamedMessageEvent>[]
			{
				this.m_UnnamedMessageSentEvent,
				this.m_UnnamedMessageReceivedEvent
			}).WithMetricEvents<NetworkVariableEvent>(new EventMetric<NetworkVariableEvent>[]
			{
				this.m_NetworkVariableDeltaSentEvent,
				this.m_NetworkVariableDeltaReceivedEvent
			}).WithMetricEvents<OwnershipChangeEvent>(new EventMetric<OwnershipChangeEvent>[]
			{
				this.m_OwnershipChangeSentEvent,
				this.m_OwnershipChangeReceivedEvent
			}).WithMetricEvents<ObjectSpawnedEvent>(new EventMetric<ObjectSpawnedEvent>[]
			{
				this.m_ObjectSpawnSentEvent,
				this.m_ObjectSpawnReceivedEvent
			}).WithMetricEvents<ObjectDestroyedEvent>(new EventMetric<ObjectDestroyedEvent>[]
			{
				this.m_ObjectDestroySentEvent,
				this.m_ObjectDestroyReceivedEvent
			}).WithMetricEvents<RpcEvent>(new EventMetric<RpcEvent>[]
			{
				this.m_RpcSentEvent,
				this.m_RpcReceivedEvent
			}).WithMetricEvents<ServerLogEvent>(new EventMetric<ServerLogEvent>[]
			{
				this.m_ServerLogSentEvent,
				this.m_ServerLogReceivedEvent
			}).WithMetricEvents<SceneEventMetric>(new EventMetric<SceneEventMetric>[]
			{
				this.m_SceneEventSentEvent,
				this.m_SceneEventReceivedEvent
			}).WithCounters(new Counter[]
			{
				this.m_PacketSentCounter,
				this.m_PacketReceivedCounter
			}).WithGauges(new Gauge[]
			{
				this.m_RttToServerGauge
			}).WithGauges(new Gauge[]
			{
				this.m_NetworkObjectsGauge
			}).WithGauges(new Gauge[]
			{
				this.m_ConnectionsGauge
			}).WithGauges(new Gauge[]
			{
				this.m_PacketLoss
			}).Build();
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002509 File Offset: 0x00000709
		public IMetricDispatcher Dispatcher { get; }

		// Token: 0x06000023 RID: 35 RVA: 0x00002511 File Offset: 0x00000711
		public void SetConnectionId(ulong connectionId)
		{
			this.Dispatcher.SetConnectionId(connectionId);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000251F File Offset: 0x0000071F
		public void TrackTransportBytesSent(long bytesCount)
		{
			this.m_TransportBytesSent.Increment(bytesCount);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000252D File Offset: 0x0000072D
		public void TrackTransportBytesReceived(long bytesCount)
		{
			this.m_TransportBytesReceived.Increment(bytesCount);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000253B File Offset: 0x0000073B
		public void TrackNetworkMessageSent(NetworkMessageEvent networkMessageEvent)
		{
			this.m_NetworkMessageSentEvent.Mark(networkMessageEvent);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002549 File Offset: 0x00000749
		public void TrackNetworkMessageReceived(NetworkMessageEvent networkMessageEvent)
		{
			this.m_NetworkMessageReceivedEvent.Mark(networkMessageEvent);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002557 File Offset: 0x00000757
		public void TrackNamedMessageSent(NamedMessageEvent namedMessageEvent)
		{
			this.m_NamedMessageSentEvent.Mark(namedMessageEvent);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002565 File Offset: 0x00000765
		public void TrackNamedMessageReceived(NamedMessageEvent namedMessageEvent)
		{
			this.m_NamedMessageReceivedEvent.Mark(namedMessageEvent);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002573 File Offset: 0x00000773
		public void TrackUnnamedMessageSent(UnnamedMessageEvent unnamedMessageEvent)
		{
			this.m_UnnamedMessageSentEvent.Mark(unnamedMessageEvent);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002581 File Offset: 0x00000781
		public void TrackUnnamedMessageReceived(UnnamedMessageEvent unnamedMessageEvent)
		{
			this.m_UnnamedMessageReceivedEvent.Mark(unnamedMessageEvent);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000258F File Offset: 0x0000078F
		public void TrackNetworkVariableDeltaSent(NetworkVariableEvent networkVariableEvent)
		{
			this.m_NetworkVariableDeltaSentEvent.Mark(networkVariableEvent);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000259D File Offset: 0x0000079D
		public void TrackNetworkVariableDeltaReceived(NetworkVariableEvent networkVariableEvent)
		{
			this.m_NetworkVariableDeltaReceivedEvent.Mark(networkVariableEvent);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000025AB File Offset: 0x000007AB
		public void TrackOwnershipChangeSent(OwnershipChangeEvent ownershipChangeEvent)
		{
			this.m_OwnershipChangeSentEvent.Mark(ownershipChangeEvent);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000025B9 File Offset: 0x000007B9
		public void TrackOwnershipChangeReceived(OwnershipChangeEvent ownershipChangeEvent)
		{
			this.m_OwnershipChangeReceivedEvent.Mark(ownershipChangeEvent);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000025C7 File Offset: 0x000007C7
		public void TrackObjectSpawnSent(ObjectSpawnedEvent objectSpawnedEvent)
		{
			this.m_ObjectSpawnSentEvent.Mark(objectSpawnedEvent);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000025D5 File Offset: 0x000007D5
		public void TrackObjectSpawnReceived(ObjectSpawnedEvent objectSpawnedEvent)
		{
			this.m_ObjectSpawnReceivedEvent.Mark(objectSpawnedEvent);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000025E3 File Offset: 0x000007E3
		public void TrackObjectDestroySent(ObjectDestroyedEvent objectDestroyedEvent)
		{
			this.m_ObjectDestroySentEvent.Mark(objectDestroyedEvent);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000025F1 File Offset: 0x000007F1
		public void TrackObjectDestroyReceived(ObjectDestroyedEvent objectDestroyedEvent)
		{
			this.m_ObjectDestroyReceivedEvent.Mark(objectDestroyedEvent);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000025FF File Offset: 0x000007FF
		public void TrackRpcSent(RpcEvent rpcEvent)
		{
			this.m_RpcSentEvent.Mark(rpcEvent);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000260D File Offset: 0x0000080D
		public void TrackRpcReceived(RpcEvent rpcEvent)
		{
			this.m_RpcReceivedEvent.Mark(rpcEvent);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000261B File Offset: 0x0000081B
		public void TrackServerLogSent(ServerLogEvent serverLogEvent)
		{
			this.m_ServerLogSentEvent.Mark(serverLogEvent);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002629 File Offset: 0x00000829
		public void TrackServerLogReceived(ServerLogEvent serverLogEvent)
		{
			this.m_ServerLogReceivedEvent.Mark(serverLogEvent);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002637 File Offset: 0x00000837
		public void TrackSceneEventSent(SceneEventMetric sceneEvent)
		{
			this.m_SceneEventSentEvent.Mark(sceneEvent);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002645 File Offset: 0x00000845
		public void TrackSceneEventReceived(SceneEventMetric sceneEvent)
		{
			this.m_SceneEventReceivedEvent.Mark(sceneEvent);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002653 File Offset: 0x00000853
		public void TrackPacketSent(int packetCount)
		{
			this.m_PacketSentCounter.Increment((long)packetCount);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002662 File Offset: 0x00000862
		public void TrackPacketReceived(int packetCount)
		{
			this.m_PacketReceivedCounter.Increment((long)packetCount);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002671 File Offset: 0x00000871
		public void TrackRttToServer(int rtt)
		{
			this.m_RttToServerGauge.Set((double)rtt);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002680 File Offset: 0x00000880
		public void UpdateNetworkObjectsCount(int count)
		{
			this.m_NetworkObjectsGauge.Set((double)count);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000268F File Offset: 0x0000088F
		public void UpdateConnectionsCount(int count)
		{
			this.m_ConnectionsGauge.Set((double)count);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000269E File Offset: 0x0000089E
		public void UpdatePacketLoss(float count)
		{
			this.m_PacketLoss.Set((double)count);
		}

		// Token: 0x04000006 RID: 6
		private readonly Counter m_TransportBytesSent = new Counter(DirectedMetricType.TotalBytesSent.GetId(), 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000007 RID: 7
		private readonly Counter m_TransportBytesReceived = new Counter(DirectedMetricType.TotalBytesReceived.GetId(), 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000008 RID: 8
		private readonly EventMetric<NetworkMessageEvent> m_NetworkMessageSentEvent = new EventMetric<NetworkMessageEvent>(DirectedMetricType.NetworkMessageSent.GetId());

		// Token: 0x04000009 RID: 9
		private readonly EventMetric<NetworkMessageEvent> m_NetworkMessageReceivedEvent = new EventMetric<NetworkMessageEvent>(DirectedMetricType.NetworkMessageReceived.GetId());

		// Token: 0x0400000A RID: 10
		private readonly EventMetric<NamedMessageEvent> m_NamedMessageSentEvent = new EventMetric<NamedMessageEvent>(DirectedMetricType.NamedMessageSent.GetId());

		// Token: 0x0400000B RID: 11
		private readonly EventMetric<NamedMessageEvent> m_NamedMessageReceivedEvent = new EventMetric<NamedMessageEvent>(DirectedMetricType.NamedMessageReceived.GetId());

		// Token: 0x0400000C RID: 12
		private readonly EventMetric<UnnamedMessageEvent> m_UnnamedMessageSentEvent = new EventMetric<UnnamedMessageEvent>(DirectedMetricType.UnnamedMessageSent.GetId());

		// Token: 0x0400000D RID: 13
		private readonly EventMetric<UnnamedMessageEvent> m_UnnamedMessageReceivedEvent = new EventMetric<UnnamedMessageEvent>(DirectedMetricType.UnnamedMessageReceived.GetId());

		// Token: 0x0400000E RID: 14
		private readonly EventMetric<NetworkVariableEvent> m_NetworkVariableDeltaSentEvent = new EventMetric<NetworkVariableEvent>(DirectedMetricType.NetworkVariableDeltaSent.GetId());

		// Token: 0x0400000F RID: 15
		private readonly EventMetric<NetworkVariableEvent> m_NetworkVariableDeltaReceivedEvent = new EventMetric<NetworkVariableEvent>(DirectedMetricType.NetworkVariableDeltaReceived.GetId());

		// Token: 0x04000010 RID: 16
		private readonly EventMetric<OwnershipChangeEvent> m_OwnershipChangeSentEvent = new EventMetric<OwnershipChangeEvent>(DirectedMetricType.OwnershipChangeSent.GetId());

		// Token: 0x04000011 RID: 17
		private readonly EventMetric<OwnershipChangeEvent> m_OwnershipChangeReceivedEvent = new EventMetric<OwnershipChangeEvent>(DirectedMetricType.OwnershipChangeReceived.GetId());

		// Token: 0x04000012 RID: 18
		private readonly EventMetric<ObjectSpawnedEvent> m_ObjectSpawnSentEvent = new EventMetric<ObjectSpawnedEvent>(DirectedMetricType.ObjectSpawnedSent.GetId());

		// Token: 0x04000013 RID: 19
		private readonly EventMetric<ObjectSpawnedEvent> m_ObjectSpawnReceivedEvent = new EventMetric<ObjectSpawnedEvent>(DirectedMetricType.ObjectSpawnedReceived.GetId());

		// Token: 0x04000014 RID: 20
		private readonly EventMetric<ObjectDestroyedEvent> m_ObjectDestroySentEvent = new EventMetric<ObjectDestroyedEvent>(DirectedMetricType.ObjectDestroyedSent.GetId());

		// Token: 0x04000015 RID: 21
		private readonly EventMetric<ObjectDestroyedEvent> m_ObjectDestroyReceivedEvent = new EventMetric<ObjectDestroyedEvent>(DirectedMetricType.ObjectDestroyedReceived.GetId());

		// Token: 0x04000016 RID: 22
		private readonly EventMetric<RpcEvent> m_RpcSentEvent = new EventMetric<RpcEvent>(DirectedMetricType.RpcSent.GetId());

		// Token: 0x04000017 RID: 23
		private readonly EventMetric<RpcEvent> m_RpcReceivedEvent = new EventMetric<RpcEvent>(DirectedMetricType.RpcReceived.GetId());

		// Token: 0x04000018 RID: 24
		private readonly EventMetric<ServerLogEvent> m_ServerLogSentEvent = new EventMetric<ServerLogEvent>(DirectedMetricType.ServerLogSent.GetId());

		// Token: 0x04000019 RID: 25
		private readonly EventMetric<ServerLogEvent> m_ServerLogReceivedEvent = new EventMetric<ServerLogEvent>(DirectedMetricType.ServerLogReceived.GetId());

		// Token: 0x0400001A RID: 26
		private readonly EventMetric<SceneEventMetric> m_SceneEventSentEvent = new EventMetric<SceneEventMetric>(DirectedMetricType.SceneEventSent.GetId());

		// Token: 0x0400001B RID: 27
		private readonly EventMetric<SceneEventMetric> m_SceneEventReceivedEvent = new EventMetric<SceneEventMetric>(DirectedMetricType.SceneEventReceived.GetId());

		// Token: 0x0400001C RID: 28
		private readonly Counter m_PacketSentCounter = new Counter(NetworkMetricTypes.PacketsSent.Id, 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x0400001D RID: 29
		private readonly Counter m_PacketReceivedCounter = new Counter(NetworkMetricTypes.PacketsReceived.Id, 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x0400001E RID: 30
		private readonly Gauge m_RttToServerGauge = new Gauge(NetworkMetricTypes.RttToServer.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x0400001F RID: 31
		private readonly Gauge m_NetworkObjectsGauge = new Gauge(NetworkMetricTypes.NetworkObjects.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000020 RID: 32
		private readonly Gauge m_ConnectionsGauge = new Gauge(NetworkMetricTypes.ConnectedClients.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000021 RID: 33
		private readonly Gauge m_PacketLoss = new Gauge(NetworkMetricTypes.PacketLoss.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};
	}
}
