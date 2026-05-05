using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000010 RID: 16
	internal class GaugeFactory : IMetricFactory
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00002A4D File Offset: 0x00000C4D
		public bool TryConstruct(MetricHeader header, out IMetric metric)
		{
			metric = new Gauge(header.MetricId, 0.0);
			return true;
		}
	}
}
