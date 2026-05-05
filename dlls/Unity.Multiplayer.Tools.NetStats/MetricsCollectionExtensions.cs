using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000024 RID: 36
	internal static class MetricsCollectionExtensions
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003250 File Offset: 0x00001450
		public static IReadOnlyList<TMetric> GetEventValues<TMetric>(this MetricCollection collection, MetricId metricId)
		{
			IEventMetric<TMetric> eventMetric;
			if (!collection.TryGetEvent<TMetric>(metricId, out eventMetric))
			{
				return Array.Empty<TMetric>();
			}
			return eventMetric.Values;
		}
	}
}
