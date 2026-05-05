using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000026 RID: 38
	internal class TimerFactory : IMetricFactory
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000032A0 File Offset: 0x000014A0
		public bool TryConstruct(MetricHeader header, out IMetric metric)
		{
			metric = new Timer(header.MetricId, default(TimeSpan));
			return true;
		}
	}
}
