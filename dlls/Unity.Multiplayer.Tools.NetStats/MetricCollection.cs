using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	internal sealed class MetricCollection
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020D0 File Offset: 0x000002D0
		internal MetricCollection(IReadOnlyDictionary<MetricId, IMetric<long>> counters, IReadOnlyDictionary<MetricId, IMetric<double>> gauges, IReadOnlyDictionary<MetricId, IMetric<TimeSpan>> timers, IReadOnlyDictionary<MetricId, IEventMetric> payloadEvents)
		{
			this.m_Counters = counters;
			this.m_Gauges = gauges;
			this.m_Timers = timers;
			this.m_PayloadEvents = payloadEvents;
			this.Metrics = counters.Values.Concat(gauges.Values).Concat(timers.Values).Concat(this.m_PayloadEvents.Values).ToList<IMetric>();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002140 File Offset: 0x00000340
		internal MetricCollection(IReadOnlyCollection<IMetric> metrics, ulong localConnectionId)
		{
			this.m_Counters = metrics.OfType<IMetric<long>>().ToDictionary(new Func<IMetric<long>, MetricId>(MetricCollection.<.ctor>g__ByMetricId|5_0));
			this.m_Gauges = metrics.OfType<IMetric<double>>().ToDictionary(new Func<IMetric<double>, MetricId>(MetricCollection.<.ctor>g__ByMetricId|5_0));
			this.m_Timers = metrics.OfType<IMetric<TimeSpan>>().ToDictionary(new Func<IMetric<TimeSpan>, MetricId>(MetricCollection.<.ctor>g__ByMetricId|5_0));
			this.m_PayloadEvents = metrics.OfType<IEventMetric>().ToDictionary(new Func<IEventMetric, MetricId>(MetricCollection.<.ctor>g__ByMetricId|5_0));
			this.ConnectionId = localConnectionId;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000021D6 File Offset: 0x000003D6
		public IReadOnlyList<IMetric> Metrics { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021DE File Offset: 0x000003DE
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000021E6 File Offset: 0x000003E6
		public ulong ConnectionId { get; set; } = ulong.MaxValue;

		// Token: 0x0600000E RID: 14 RVA: 0x000021EF File Offset: 0x000003EF
		public bool TryGetCounter(MetricId metricId, out IMetric<long> counter)
		{
			return this.m_Counters.TryGetValue(metricId, out counter);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002200 File Offset: 0x00000400
		public IMetric<long> GetCounterOrDefault(MetricId metricId)
		{
			IMetric<long> result;
			if (this.TryGetCounter(metricId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000221B File Offset: 0x0000041B
		public bool TryGetGauge(MetricId metricId, out IMetric<double> gauge)
		{
			return this.m_Gauges.TryGetValue(metricId, out gauge);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000222A File Offset: 0x0000042A
		public bool TryGetTimer(MetricId metricId, out IMetric<TimeSpan> timer)
		{
			return this.m_Timers.TryGetValue(metricId, out timer);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000223C File Offset: 0x0000043C
		public bool TryGetEvent<TEvent>(MetricId metricId, out IEventMetric<TEvent> metricEvent)
		{
			IEventMetric eventMetric;
			if (this.m_PayloadEvents.TryGetValue(metricId, out eventMetric))
			{
				IEventMetric<TEvent> eventMetric2 = eventMetric as IEventMetric<TEvent>;
				if (eventMetric2 != null)
				{
					metricEvent = eventMetric2;
					return true;
				}
			}
			metricEvent = null;
			return false;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000226C File Offset: 0x0000046C
		public IEventMetric<TEvent> GetPayloadEventOrDefault<TEvent>(MetricId metricId)
		{
			IEventMetric<TEvent> result;
			if (this.TryGetEvent<TEvent>(metricId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002288 File Offset: 0x00000488
		public int GetEventCount(MetricId metricId)
		{
			IEventMetric eventMetric;
			if (this.m_PayloadEvents.TryGetValue(metricId, out eventMetric))
			{
				return eventMetric.Count;
			}
			return 0;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000022AD File Offset: 0x000004AD
		[CompilerGenerated]
		internal static MetricId <.ctor>g__ByMetricId|5_0(IMetric metric)
		{
			return metric.Id;
		}

		// Token: 0x04000001 RID: 1
		private IReadOnlyDictionary<MetricId, IMetric<long>> m_Counters;

		// Token: 0x04000002 RID: 2
		private IReadOnlyDictionary<MetricId, IMetric<double>> m_Gauges;

		// Token: 0x04000003 RID: 3
		private IReadOnlyDictionary<MetricId, IMetric<TimeSpan>> m_Timers;

		// Token: 0x04000004 RID: 4
		private IReadOnlyDictionary<MetricId, IEventMetric> m_PayloadEvents;
	}
}
