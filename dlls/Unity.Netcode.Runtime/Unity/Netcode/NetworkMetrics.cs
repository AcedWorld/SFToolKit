using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;
using Unity.Profiling;

namespace Unity.Netcode
{
	// Token: 0x020000A6 RID: 166
	internal class NetworkMetrics : INetworkMetrics
	{
		// Token: 0x0600037F RID: 895 RVA: 0x00011448 File Offset: 0x0000F648
		static NetworkMetrics()
		{
			NetworkMetrics.s_SceneEventTypeNames = new Dictionary<uint, string>();
			foreach (object obj in Enum.GetValues(typeof(SceneEventType)))
			{
				SceneEventType key = (SceneEventType)obj;
				NetworkMetrics.s_SceneEventTypeNames[(uint)key] = key.ToString();
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000114D4 File Offset: 0x0000F6D4
		private static string GetSceneEventTypeName(uint typeCode)
		{
			string result;
			if (!NetworkMetrics.s_SceneEventTypeNames.TryGetValue(typeCode, out result))
			{
				result = "Unknown";
			}
			return result;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x000114F8 File Offset: 0x0000F6F8
		public NetworkMetrics()
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
				this.m_PacketLossGauge
			}).Build();
			this.Dispatcher.RegisterObserver(NetcodeObserver.Observer);
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000382 RID: 898 RVA: 0x000119D4 File Offset: 0x0000FBD4
		internal IMetricDispatcher Dispatcher { get; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000383 RID: 899 RVA: 0x000119DC File Offset: 0x0000FBDC
		private bool CanSendMetrics
		{
			get
			{
				return this.m_NumberOfMetricsThisFrame < 1000UL;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x000119EC File Offset: 0x0000FBEC
		public void SetConnectionId(ulong connectionId)
		{
			this.Dispatcher.SetConnectionId(connectionId);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000119FA File Offset: 0x0000FBFA
		public void TrackTransportBytesSent(long bytesCount)
		{
			this.m_TransportBytesSent.Increment(bytesCount);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00011A08 File Offset: 0x0000FC08
		public void TrackTransportBytesReceived(long bytesCount)
		{
			this.m_TransportBytesReceived.Increment(bytesCount);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00011A16 File Offset: 0x0000FC16
		public void TrackNetworkMessageSent(ulong receivedClientId, string messageType, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NetworkMessageSentEvent.Mark(new NetworkMessageEvent(new ConnectionInfo(receivedClientId), messageType, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00011A3F File Offset: 0x0000FC3F
		public void TrackNetworkMessageReceived(ulong senderClientId, string messageType, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NetworkMessageReceivedEvent.Mark(new NetworkMessageEvent(new ConnectionInfo(senderClientId), messageType, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00011A68 File Offset: 0x0000FC68
		public void TrackNamedMessageSent(ulong receiverClientId, string messageName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NamedMessageSentEvent.Mark(new NamedMessageEvent(new ConnectionInfo(receiverClientId), messageName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00011A94 File Offset: 0x0000FC94
		public void TrackNamedMessageSent(IReadOnlyCollection<ulong> receiverClientIds, string messageName, long bytesCount)
		{
			foreach (ulong receiverClientId in receiverClientIds)
			{
				this.TrackNamedMessageSent(receiverClientId, messageName, bytesCount);
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00011AE0 File Offset: 0x0000FCE0
		public void TrackNamedMessageReceived(ulong senderClientId, string messageName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NamedMessageReceivedEvent.Mark(new NamedMessageEvent(new ConnectionInfo(senderClientId), messageName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00011B09 File Offset: 0x0000FD09
		public void TrackUnnamedMessageSent(ulong receiverClientId, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_UnnamedMessageSentEvent.Mark(new UnnamedMessageEvent(new ConnectionInfo(receiverClientId), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00011B34 File Offset: 0x0000FD34
		public void TrackUnnamedMessageSent(IReadOnlyCollection<ulong> receiverClientIds, long bytesCount)
		{
			foreach (ulong receiverClientId in receiverClientIds)
			{
				this.TrackUnnamedMessageSent(receiverClientId, bytesCount);
			}
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00011B80 File Offset: 0x0000FD80
		public void TrackUnnamedMessageReceived(ulong senderClientId, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_UnnamedMessageReceivedEvent.Mark(new UnnamedMessageEvent(new ConnectionInfo(senderClientId), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00011BA8 File Offset: 0x0000FDA8
		public void TrackNetworkVariableDeltaSent(ulong receiverClientId, NetworkObject networkObject, string variableName, string networkBehaviourName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NetworkVariableDeltaSentEvent.Mark(new NetworkVariableEvent(new ConnectionInfo(receiverClientId), NetworkMetrics.GetObjectIdentifier(networkObject), variableName, networkBehaviourName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00011BDA File Offset: 0x0000FDDA
		public void TrackNetworkVariableDeltaReceived(ulong senderClientId, NetworkObject networkObject, string variableName, string networkBehaviourName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NetworkVariableDeltaReceivedEvent.Mark(new NetworkVariableEvent(new ConnectionInfo(senderClientId), NetworkMetrics.GetObjectIdentifier(networkObject), variableName, networkBehaviourName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00011C0C File Offset: 0x0000FE0C
		public void TrackOwnershipChangeSent(ulong receiverClientId, NetworkObject networkObject, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_OwnershipChangeSentEvent.Mark(new OwnershipChangeEvent(new ConnectionInfo(receiverClientId), NetworkMetrics.GetObjectIdentifier(networkObject), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00011C3A File Offset: 0x0000FE3A
		public void TrackOwnershipChangeReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_OwnershipChangeReceivedEvent.Mark(new OwnershipChangeEvent(new ConnectionInfo(senderClientId), NetworkMetrics.GetObjectIdentifier(networkObject), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00011C68 File Offset: 0x0000FE68
		public void TrackObjectSpawnSent(ulong receiverClientId, NetworkObject networkObject, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ObjectSpawnSentEvent.Mark(new ObjectSpawnedEvent(new ConnectionInfo(receiverClientId), NetworkMetrics.GetObjectIdentifier(networkObject), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00011C96 File Offset: 0x0000FE96
		public void TrackObjectSpawnReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ObjectSpawnReceivedEvent.Mark(new ObjectSpawnedEvent(new ConnectionInfo(senderClientId), NetworkMetrics.GetObjectIdentifier(networkObject), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00011CC4 File Offset: 0x0000FEC4
		public void TrackObjectDestroySent(ulong receiverClientId, NetworkObject networkObject, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ObjectDestroySentEvent.Mark(new ObjectDestroyedEvent(new ConnectionInfo(receiverClientId), NetworkMetrics.GetObjectIdentifier(networkObject), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00011CF2 File Offset: 0x0000FEF2
		public void TrackObjectDestroyReceived(ulong senderClientId, NetworkObject networkObject, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ObjectDestroyReceivedEvent.Mark(new ObjectDestroyedEvent(new ConnectionInfo(senderClientId), NetworkMetrics.GetObjectIdentifier(networkObject), bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00011D20 File Offset: 0x0000FF20
		public void TrackRpcSent(ulong receiverClientId, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_RpcSentEvent.Mark(new RpcEvent(new ConnectionInfo(receiverClientId), NetworkMetrics.GetObjectIdentifier(networkObject), rpcName, networkBehaviourName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00011D54 File Offset: 0x0000FF54
		public void TrackRpcSent(ulong[] receiverClientIds, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount)
		{
			foreach (ulong receiverClientId in receiverClientIds)
			{
				this.TrackRpcSent(receiverClientId, networkObject, rpcName, networkBehaviourName, bytesCount);
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00011D82 File Offset: 0x0000FF82
		public void TrackRpcReceived(ulong senderClientId, NetworkObject networkObject, string rpcName, string networkBehaviourName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_RpcReceivedEvent.Mark(new RpcEvent(new ConnectionInfo(senderClientId), NetworkMetrics.GetObjectIdentifier(networkObject), rpcName, networkBehaviourName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00011DB4 File Offset: 0x0000FFB4
		public void TrackServerLogSent(ulong receiverClientId, uint logType, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ServerLogSentEvent.Mark(new ServerLogEvent(new ConnectionInfo(receiverClientId), (LogLevel)logType, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00011DDD File Offset: 0x0000FFDD
		public void TrackServerLogReceived(ulong senderClientId, uint logType, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ServerLogReceivedEvent.Mark(new ServerLogEvent(new ConnectionInfo(senderClientId), (LogLevel)logType, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00011E08 File Offset: 0x00010008
		public void TrackSceneEventSent(IReadOnlyList<ulong> receiverClientIds, uint sceneEventType, string sceneName, long bytesCount)
		{
			foreach (ulong receiverClientId in receiverClientIds)
			{
				this.TrackSceneEventSent(receiverClientId, sceneEventType, sceneName, bytesCount);
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00011E54 File Offset: 0x00010054
		public void TrackSceneEventSent(ulong receiverClientId, uint sceneEventType, string sceneName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_SceneEventSentEvent.Mark(new SceneEventMetric(new ConnectionInfo(receiverClientId), NetworkMetrics.GetSceneEventTypeName(sceneEventType), sceneName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00011E84 File Offset: 0x00010084
		public void TrackSceneEventReceived(ulong senderClientId, uint sceneEventType, string sceneName, long bytesCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_SceneEventReceivedEvent.Mark(new SceneEventMetric(new ConnectionInfo(senderClientId), NetworkMetrics.GetSceneEventTypeName(sceneEventType), sceneName, bytesCount));
			this.IncrementMetricCount();
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00011EB4 File Offset: 0x000100B4
		public void TrackPacketSent(uint packetCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_PacketSentCounter.Increment((long)((ulong)packetCount));
			this.IncrementMetricCount();
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00011ED2 File Offset: 0x000100D2
		public void TrackPacketReceived(uint packetCount)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_PacketReceivedCounter.Increment((long)((ulong)packetCount));
			this.IncrementMetricCount();
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00011EF0 File Offset: 0x000100F0
		public void UpdateRttToServer(int rttMilliseconds)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			double value = (double)rttMilliseconds * 0.001;
			this.m_RttToServerGauge.Set(value);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00011F1F File Offset: 0x0001011F
		public void UpdateNetworkObjectsCount(int count)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_NetworkObjectsGauge.Set((double)count);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00011F37 File Offset: 0x00010137
		public void UpdateConnectionsCount(int count)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_ConnectionsGauge.Set((double)count);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00011F4F File Offset: 0x0001014F
		public void UpdatePacketLoss(float packetLoss)
		{
			if (!this.CanSendMetrics)
			{
				return;
			}
			this.m_PacketLossGauge.Set((double)packetLoss);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00011F67 File Offset: 0x00010167
		public void DispatchFrame()
		{
			this.Dispatcher.Dispatch();
			this.m_NumberOfMetricsThisFrame = 0UL;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00011F7C File Offset: 0x0001017C
		private void IncrementMetricCount()
		{
			this.m_NumberOfMetricsThisFrame += 1UL;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00011F8D File Offset: 0x0001018D
		private static NetworkObjectIdentifier GetObjectIdentifier(NetworkObject networkObject)
		{
			return new NetworkObjectIdentifier(networkObject.GetNameForMetrics(), networkObject.NetworkObjectId);
		}

		// Token: 0x040001FE RID: 510
		private const ulong k_MaxMetricsPerFrame = 1000UL;

		// Token: 0x040001FF RID: 511
		private static Dictionary<uint, string> s_SceneEventTypeNames;

		// Token: 0x04000200 RID: 512
		private static ProfilerMarker s_FrameDispatch = new ProfilerMarker("NetworkMetrics.DispatchFrame");

		// Token: 0x04000201 RID: 513
		private readonly Counter m_TransportBytesSent = new Counter(NetworkMetricTypes.TotalBytesSent.Id, 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000202 RID: 514
		private readonly Counter m_TransportBytesReceived = new Counter(NetworkMetricTypes.TotalBytesReceived.Id, 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000203 RID: 515
		private readonly EventMetric<NetworkMessageEvent> m_NetworkMessageSentEvent = new EventMetric<NetworkMessageEvent>(NetworkMetricTypes.NetworkMessageSent.Id);

		// Token: 0x04000204 RID: 516
		private readonly EventMetric<NetworkMessageEvent> m_NetworkMessageReceivedEvent = new EventMetric<NetworkMessageEvent>(NetworkMetricTypes.NetworkMessageReceived.Id);

		// Token: 0x04000205 RID: 517
		private readonly EventMetric<NamedMessageEvent> m_NamedMessageSentEvent = new EventMetric<NamedMessageEvent>(NetworkMetricTypes.NamedMessageSent.Id);

		// Token: 0x04000206 RID: 518
		private readonly EventMetric<NamedMessageEvent> m_NamedMessageReceivedEvent = new EventMetric<NamedMessageEvent>(NetworkMetricTypes.NamedMessageReceived.Id);

		// Token: 0x04000207 RID: 519
		private readonly EventMetric<UnnamedMessageEvent> m_UnnamedMessageSentEvent = new EventMetric<UnnamedMessageEvent>(NetworkMetricTypes.UnnamedMessageSent.Id);

		// Token: 0x04000208 RID: 520
		private readonly EventMetric<UnnamedMessageEvent> m_UnnamedMessageReceivedEvent = new EventMetric<UnnamedMessageEvent>(NetworkMetricTypes.UnnamedMessageReceived.Id);

		// Token: 0x04000209 RID: 521
		private readonly EventMetric<NetworkVariableEvent> m_NetworkVariableDeltaSentEvent = new EventMetric<NetworkVariableEvent>(NetworkMetricTypes.NetworkVariableDeltaSent.Id);

		// Token: 0x0400020A RID: 522
		private readonly EventMetric<NetworkVariableEvent> m_NetworkVariableDeltaReceivedEvent = new EventMetric<NetworkVariableEvent>(NetworkMetricTypes.NetworkVariableDeltaReceived.Id);

		// Token: 0x0400020B RID: 523
		private readonly EventMetric<OwnershipChangeEvent> m_OwnershipChangeSentEvent = new EventMetric<OwnershipChangeEvent>(NetworkMetricTypes.OwnershipChangeSent.Id);

		// Token: 0x0400020C RID: 524
		private readonly EventMetric<OwnershipChangeEvent> m_OwnershipChangeReceivedEvent = new EventMetric<OwnershipChangeEvent>(NetworkMetricTypes.OwnershipChangeReceived.Id);

		// Token: 0x0400020D RID: 525
		private readonly EventMetric<ObjectSpawnedEvent> m_ObjectSpawnSentEvent = new EventMetric<ObjectSpawnedEvent>(NetworkMetricTypes.ObjectSpawnedSent.Id);

		// Token: 0x0400020E RID: 526
		private readonly EventMetric<ObjectSpawnedEvent> m_ObjectSpawnReceivedEvent = new EventMetric<ObjectSpawnedEvent>(NetworkMetricTypes.ObjectSpawnedReceived.Id);

		// Token: 0x0400020F RID: 527
		private readonly EventMetric<ObjectDestroyedEvent> m_ObjectDestroySentEvent = new EventMetric<ObjectDestroyedEvent>(NetworkMetricTypes.ObjectDestroyedSent.Id);

		// Token: 0x04000210 RID: 528
		private readonly EventMetric<ObjectDestroyedEvent> m_ObjectDestroyReceivedEvent = new EventMetric<ObjectDestroyedEvent>(NetworkMetricTypes.ObjectDestroyedReceived.Id);

		// Token: 0x04000211 RID: 529
		private readonly EventMetric<RpcEvent> m_RpcSentEvent = new EventMetric<RpcEvent>(NetworkMetricTypes.RpcSent.Id);

		// Token: 0x04000212 RID: 530
		private readonly EventMetric<RpcEvent> m_RpcReceivedEvent = new EventMetric<RpcEvent>(NetworkMetricTypes.RpcReceived.Id);

		// Token: 0x04000213 RID: 531
		private readonly EventMetric<ServerLogEvent> m_ServerLogSentEvent = new EventMetric<ServerLogEvent>(NetworkMetricTypes.ServerLogSent.Id);

		// Token: 0x04000214 RID: 532
		private readonly EventMetric<ServerLogEvent> m_ServerLogReceivedEvent = new EventMetric<ServerLogEvent>(NetworkMetricTypes.ServerLogReceived.Id);

		// Token: 0x04000215 RID: 533
		private readonly EventMetric<SceneEventMetric> m_SceneEventSentEvent = new EventMetric<SceneEventMetric>(NetworkMetricTypes.SceneEventSent.Id);

		// Token: 0x04000216 RID: 534
		private readonly EventMetric<SceneEventMetric> m_SceneEventReceivedEvent = new EventMetric<SceneEventMetric>(NetworkMetricTypes.SceneEventReceived.Id);

		// Token: 0x04000217 RID: 535
		private readonly Counter m_PacketSentCounter = new Counter(NetworkMetricTypes.PacketsSent.Id, 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000218 RID: 536
		private readonly Counter m_PacketReceivedCounter = new Counter(NetworkMetricTypes.PacketsReceived.Id, 0L)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x04000219 RID: 537
		private readonly Gauge m_RttToServerGauge = new Gauge(NetworkMetricTypes.RttToServer.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x0400021A RID: 538
		private readonly Gauge m_NetworkObjectsGauge = new Gauge(NetworkMetricTypes.NetworkObjects.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x0400021B RID: 539
		private readonly Gauge m_ConnectionsGauge = new Gauge(NetworkMetricTypes.ConnectedClients.Id, 0.0)
		{
			ShouldResetOnDispatch = true
		};

		// Token: 0x0400021C RID: 540
		private readonly Gauge m_PacketLossGauge = new Gauge(NetworkMetricTypes.PacketLoss.Id, 0.0);

		// Token: 0x0400021D RID: 541
		private ulong m_NumberOfMetricsThisFrame;
	}
}
