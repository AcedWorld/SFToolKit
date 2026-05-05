using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000008 RID: 8
	internal class MetricCollectionBuilder
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000022B5 File Offset: 0x000004B5
		public MetricCollectionBuilder WithCounters(params Counter[] counters)
		{
			this.m_Counters.AddRange(counters);
			return this;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022C4 File Offset: 0x000004C4
		public MetricCollectionBuilder WithGauges(params Gauge[] gauges)
		{
			this.m_Gauges.AddRange(gauges);
			return this;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022D3 File Offset: 0x000004D3
		public MetricCollectionBuilder WithTimers(params Timer[] timers)
		{
			this.m_Timers.AddRange(timers);
			return this;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000022E2 File Offset: 0x000004E2
		public MetricCollectionBuilder WithMetricEvents<TEvent>(params IEventMetric<TEvent>[] metricEvents) where TEvent : struct
		{
			this.m_PayloadEvents.AddRange(metricEvents);
			return this;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000022F4 File Offset: 0x000004F4
		public MetricCollection Build()
		{
			return new MetricCollection(new ReadOnlyDictionary<MetricId, IMetric<long>>(this.m_Counters.ToDictionary((IMetric<long> x) => x.Id, (IMetric<long> x) => x)), new ReadOnlyDictionary<MetricId, IMetric<double>>(this.m_Gauges.ToDictionary((IMetric<double> x) => x.Id, (IMetric<double> x) => x)), new ReadOnlyDictionary<MetricId, IMetric<TimeSpan>>(this.m_Timers.ToDictionary((IMetric<TimeSpan> x) => x.Id, (IMetric<TimeSpan> x) => x)), new ReadOnlyDictionary<MetricId, IEventMetric>(this.m_PayloadEvents.ToDictionary((IEventMetric x) => x.Id, (IEventMetric x) => x)));
		}

		// Token: 0x04000007 RID: 7
		private readonly List<IMetric<long>> m_Counters = new List<IMetric<long>>();

		// Token: 0x04000008 RID: 8
		private readonly List<IMetric<double>> m_Gauges = new List<IMetric<double>>();

		// Token: 0x04000009 RID: 9
		private readonly List<IMetric<TimeSpan>> m_Timers = new List<IMetric<TimeSpan>>();

		// Token: 0x0400000A RID: 10
		private readonly List<IEventMetric> m_PayloadEvents = new List<IEventMetric>();
	}
}
