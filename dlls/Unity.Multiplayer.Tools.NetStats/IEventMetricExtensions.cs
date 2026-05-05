using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000012 RID: 18
	internal static class IEventMetricExtensions
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00002A6F File Offset: 0x00000C6F
		public static bool WentOverLimit(this IEventMetric metric)
		{
			return metric.NumberOfValuesReceived > metric.MaxNumberOfValues;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002A7F File Offset: 0x00000C7F
		public static int NumberOfValuesIgnored(this IEventMetric metric)
		{
			return metric.NumberOfValuesReceived - metric.Count;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002A90 File Offset: 0x00000C90
		public static string WentOverLimitMessage(this IEventMetric metric)
		{
			return string.Format("Multiplayer Tools: Metric {0} received {1} values, ", metric.Name, metric.NumberOfValuesReceived) + string.Format("which exceeds the limit of {0}. ", metric.MaxNumberOfValues) + string.Format("{0} values were ignored.", metric.NumberOfValuesIgnored());
		}
	}
}
