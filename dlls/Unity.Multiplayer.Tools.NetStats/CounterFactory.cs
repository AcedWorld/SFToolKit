using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200000C RID: 12
	internal class CounterFactory : IMetricFactory
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002759 File Offset: 0x00000959
		public bool TryConstruct(MetricHeader header, out IMetric metric)
		{
			metric = new Counter(header.MetricId, 0L);
			return true;
		}
	}
}
