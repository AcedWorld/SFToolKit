using System;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.MetricEvents
{
	// Token: 0x02000004 RID: 4
	internal static class MetricEventPublisher
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000005 RID: 5 RVA: 0x000020CC File Offset: 0x000002CC
		// (remove) Token: 0x06000006 RID: 6 RVA: 0x00002100 File Offset: 0x00000300
		public static event Action<MetricCollection> OnMetricsReceived;

		// Token: 0x06000007 RID: 7 RVA: 0x00002133 File Offset: 0x00000333
		public static void RaiseOnMetricsReceived(MetricCollection metricCollection)
		{
			Action<MetricCollection> onMetricsReceived = MetricEventPublisher.OnMetricsReceived;
			if (onMetricsReceived == null)
			{
				return;
			}
			onMetricsReceived(metricCollection);
		}
	}
}
