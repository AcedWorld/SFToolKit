using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200001A RID: 26
	internal class MetricFactory
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00002BEC File Offset: 0x00000DEC
		public bool TryConstruct(MetricHeader header, out IMetric metric)
		{
			IMetricFactory metricFactory;
			if (!this.k_Factories.TryGetValue(header.MetricContainerType, out metricFactory))
			{
				Debug.LogError("Failed to find factory for type " + header.MetricContainerType.ToString());
				metric = null;
				return false;
			}
			return metricFactory.TryConstruct(header, out metric);
		}

		// Token: 0x04000027 RID: 39
		private readonly Dictionary<MetricContainerType, IMetricFactory> k_Factories = new Dictionary<MetricContainerType, IMetricFactory>
		{
			{
				MetricContainerType.Counter,
				new CounterFactory()
			},
			{
				MetricContainerType.Event,
				new EventMetricFactory()
			},
			{
				MetricContainerType.Gauge,
				new GaugeFactory()
			},
			{
				MetricContainerType.Timer,
				new TimerFactory()
			}
		};
	}
}
