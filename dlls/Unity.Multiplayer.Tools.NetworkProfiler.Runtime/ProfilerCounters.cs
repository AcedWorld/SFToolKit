using System;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x0200000B RID: 11
	internal class ProfilerCounters
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000022CF File Offset: 0x000004CF
		public static ProfilerCounters Instance
		{
			get
			{
				ProfilerCounters result;
				if ((result = ProfilerCounters.s_Singleton) == null)
				{
					result = (ProfilerCounters.s_Singleton = new ProfilerCounters(null, null));
				}
				return result;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022E8 File Offset: 0x000004E8
		public ProfilerCounters(ICounterFactory byteCounterFactory = null, ICounterFactory eventCounterFactory = null)
		{
			this.m_ByteCounterFactory = (byteCounterFactory ?? new ByteCounterFactory());
			this.m_EventCounterFactory = (eventCounterFactory ?? new EventCounterFactory());
			this.totalBytes = this.ConstructMetricByteCounters("Total");
			this.rpc = this.ConstructMetricCounters(MetricType.Rpc);
			this.namedMessage = this.ConstructMetricCounters(MetricType.NamedMessage);
			this.unnamedMessage = this.ConstructMetricCounters(MetricType.UnnamedMessage);
			this.networkVariableDelta = this.ConstructMetricCounters("Network Variable");
			this.objectSpawned = this.ConstructMetricCounters(MetricType.ObjectSpawned);
			this.objectDestroyed = this.ConstructMetricCounters(MetricType.ObjectDestroyed);
			this.serverLog = this.ConstructMetricCounters(MetricType.ServerLog);
			this.sceneEvent = this.ConstructMetricCounters(MetricType.SceneEvent);
			this.ownershipChange = this.ConstructMetricCounters(MetricType.OwnershipChange);
			this.customMessage = this.ConstructMetricCounters("Custom");
			this.networkMessage = this.ConstructMetricCounters("Network Messages");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000023C9 File Offset: 0x000005C9
		private MetricByteCounters ConstructMetricByteCounters(string name)
		{
			return new MetricByteCounters(name, this.m_ByteCounterFactory);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000023D7 File Offset: 0x000005D7
		private MetricCounters ConstructMetricCounters(MetricType metricType)
		{
			return this.ConstructMetricCounters(metricType.GetDisplayNameString());
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000023E5 File Offset: 0x000005E5
		private MetricCounters ConstructMetricCounters(string name)
		{
			return new MetricCounters(name, this.m_ByteCounterFactory, this.m_EventCounterFactory);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000023FC File Offset: 0x000005FC
		public void UpdateFromMetrics(MetricCollection collection)
		{
			IMetric<long> metric;
			IMetric<long> metric2;
			this.totalBytes.Sample(collection.TryGetCounter(DirectedMetricType.TotalBytesSent.GetId(), out metric) ? metric.Value : 0L, collection.TryGetCounter(DirectedMetricType.TotalBytesReceived.GetId(), out metric2) ? metric2.Value : 0L);
			this.rpc.Sample<RpcEvent>(collection.GetEventValues(DirectedMetricType.RpcSent.GetId()), collection.GetEventValues(DirectedMetricType.RpcReceived.GetId()));
			this.namedMessage.Sample<NamedMessageEvent>(collection.GetEventValues(DirectedMetricType.NamedMessageSent.GetId()), collection.GetEventValues(DirectedMetricType.NamedMessageReceived.GetId()));
			this.unnamedMessage.Sample<UnnamedMessageEvent>(collection.GetEventValues(DirectedMetricType.UnnamedMessageSent.GetId()), collection.GetEventValues(DirectedMetricType.UnnamedMessageReceived.GetId()));
			this.customMessage.Sample<NamedMessageEvent>(collection.GetEventValues(DirectedMetricType.NamedMessageSent.GetId()), collection.GetEventValues(DirectedMetricType.NamedMessageReceived.GetId()));
			this.customMessage.Sample<UnnamedMessageEvent>(collection.GetEventValues(DirectedMetricType.UnnamedMessageSent.GetId()), collection.GetEventValues(DirectedMetricType.UnnamedMessageReceived.GetId()));
			this.networkVariableDelta.Sample<NetworkVariableEvent>(collection.GetEventValues(DirectedMetricType.NetworkVariableDeltaSent.GetId()), collection.GetEventValues(DirectedMetricType.NetworkVariableDeltaReceived.GetId()));
			this.objectSpawned.Sample<ObjectSpawnedEvent>(collection.GetEventValues(DirectedMetricType.ObjectSpawnedSent.GetId()), collection.GetEventValues(DirectedMetricType.ObjectSpawnedReceived.GetId()));
			this.objectDestroyed.Sample<ObjectDestroyedEvent>(collection.GetEventValues(DirectedMetricType.ObjectDestroyedSent.GetId()), collection.GetEventValues(DirectedMetricType.ObjectDestroyedReceived.GetId()));
			this.serverLog.Sample<ServerLogEvent>(collection.GetEventValues(DirectedMetricType.ServerLogSent.GetId()), collection.GetEventValues(DirectedMetricType.ServerLogReceived.GetId()));
			this.sceneEvent.Sample<SceneEventMetric>(collection.GetEventValues(DirectedMetricType.SceneEventSent.GetId()), collection.GetEventValues(DirectedMetricType.SceneEventReceived.GetId()));
			this.ownershipChange.Sample<OwnershipChangeEvent>(collection.GetEventValues(DirectedMetricType.OwnershipChangeSent.GetId()), collection.GetEventValues(DirectedMetricType.OwnershipChangeReceived.GetId()));
			this.networkMessage.Sample<NetworkMessageEvent>(collection.GetEventValues(DirectedMetricType.NetworkMessageSent.GetId()), collection.GetEventValues(DirectedMetricType.NetworkMessageReceived.GetId()));
		}

		// Token: 0x0400000C RID: 12
		private static ProfilerCounters s_Singleton;

		// Token: 0x0400000D RID: 13
		public readonly MetricByteCounters totalBytes;

		// Token: 0x0400000E RID: 14
		public readonly MetricCounters rpc;

		// Token: 0x0400000F RID: 15
		public readonly MetricCounters namedMessage;

		// Token: 0x04000010 RID: 16
		public readonly MetricCounters unnamedMessage;

		// Token: 0x04000011 RID: 17
		public readonly MetricCounters networkVariableDelta;

		// Token: 0x04000012 RID: 18
		public readonly MetricCounters objectSpawned;

		// Token: 0x04000013 RID: 19
		public readonly MetricCounters objectDestroyed;

		// Token: 0x04000014 RID: 20
		public readonly MetricCounters serverLog;

		// Token: 0x04000015 RID: 21
		public readonly MetricCounters sceneEvent;

		// Token: 0x04000016 RID: 22
		public readonly MetricCounters ownershipChange;

		// Token: 0x04000017 RID: 23
		public readonly MetricCounters customMessage;

		// Token: 0x04000018 RID: 24
		public readonly MetricCounters networkMessage;

		// Token: 0x04000019 RID: 25
		private ICounterFactory m_ByteCounterFactory;

		// Token: 0x0400001A RID: 26
		private ICounterFactory m_EventCounterFactory;
	}
}
