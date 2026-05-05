using System;
using Unity.Multiplayer.Tools.MetricEvents;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools
{
	// Token: 0x02000003 RID: 3
	internal class MetricObserver : IMetricObserver
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020BB File Offset: 0x000002BB
		public void Observe(MetricCollection collection)
		{
			MetricEventPublisher.RaiseOnMetricsReceived(collection);
		}
	}
}
