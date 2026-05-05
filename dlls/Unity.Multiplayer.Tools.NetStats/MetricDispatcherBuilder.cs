using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200000A RID: 10
	internal sealed class MetricDispatcherBuilder
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000025A4 File Offset: 0x000007A4
		public MetricDispatcherBuilder WithCounters(params Counter[] counters)
		{
			foreach (Counter counter in counters)
			{
				this.m_Counters[counter.Id] = counter;
				this.m_Resettables.Add(counter);
			}
			return this;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000025E4 File Offset: 0x000007E4
		public MetricDispatcherBuilder WithGauges(params Gauge[] gauges)
		{
			foreach (Gauge gauge in gauges)
			{
				this.m_Gauges[gauge.Id] = gauge;
				this.m_Resettables.Add(gauge);
			}
			return this;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002624 File Offset: 0x00000824
		public MetricDispatcherBuilder WithTimers(params Timer[] timers)
		{
			foreach (Timer timer in timers)
			{
				this.m_Timers[timer.Id] = timer;
				this.m_Resettables.Add(timer);
			}
			return this;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002664 File Offset: 0x00000864
		public MetricDispatcherBuilder WithMetricEvents<[IsUnmanaged] TEvent>(params EventMetric<TEvent>[] metricEvents) where TEvent : struct, ValueType
		{
			foreach (EventMetric<TEvent> eventMetric in metricEvents)
			{
				this.m_PayloadEvents[eventMetric.Id] = eventMetric;
				this.m_Resettables.Add(eventMetric);
			}
			return this;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000026A4 File Offset: 0x000008A4
		public IMetricDispatcher Build()
		{
			return new MetricDispatcher(new MetricCollection(new ReadOnlyDictionary<MetricId, IMetric<long>>(this.m_Counters), new ReadOnlyDictionary<MetricId, IMetric<double>>(this.m_Gauges), new ReadOnlyDictionary<MetricId, IMetric<TimeSpan>>(this.m_Timers), new ReadOnlyDictionary<MetricId, IEventMetric>(this.m_PayloadEvents)), this.m_Resettables, this.m_PayloadEvents.Values.ToList<IEventMetric>());
		}

		// Token: 0x04000010 RID: 16
		private readonly IDictionary<MetricId, IMetric<long>> m_Counters = new Dictionary<MetricId, IMetric<long>>();

		// Token: 0x04000011 RID: 17
		private readonly IDictionary<MetricId, IMetric<double>> m_Gauges = new Dictionary<MetricId, IMetric<double>>();

		// Token: 0x04000012 RID: 18
		private readonly IDictionary<MetricId, IMetric<TimeSpan>> m_Timers = new Dictionary<MetricId, IMetric<TimeSpan>>();

		// Token: 0x04000013 RID: 19
		private readonly IDictionary<MetricId, IEventMetric> m_PayloadEvents = new Dictionary<MetricId, IEventMetric>();

		// Token: 0x04000014 RID: 20
		private readonly List<IResettable> m_Resettables = new List<IResettable>();
	}
}
