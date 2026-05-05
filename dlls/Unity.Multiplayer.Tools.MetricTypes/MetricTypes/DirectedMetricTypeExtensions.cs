using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.Common;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000006 RID: 6
	internal static class DirectedMetricTypeExtensions
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002174 File Offset: 0x00000374
		static DirectedMetricTypeExtensions()
		{
			MetricType[] values = EnumUtil.GetValues<MetricType>();
			NetworkDirection[] values2 = EnumUtil.GetValues<NetworkDirection>();
			foreach (MetricType metricType in values)
			{
				foreach (NetworkDirection direction in values2)
				{
					DirectedMetricType directedMetric = metricType.GetDirectedMetric(direction);
					string text = metricType.ToString() + direction.ToString();
					DirectedMetricTypeExtensions.s_Identifiers[directedMetric] = text;
					DirectedMetricTypeExtensions.s_DisplayNames[directedMetric] = StringUtil.AddSpacesToCamelCase(text);
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000221C File Offset: 0x0000041C
		internal static DirectedMetricType GetDirectedMetric(this MetricType metricType, NetworkDirection direction)
		{
			return (DirectedMetricType)(metricType << 2 | (MetricType)(direction & NetworkDirection.SentAndReceived));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002225 File Offset: 0x00000425
		internal static MetricType GetMetric(this DirectedMetricType directedMetric)
		{
			return (MetricType)(directedMetric >> 2);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000222A File Offset: 0x0000042A
		internal static NetworkDirection GetDirection(this DirectedMetricType directedMetric)
		{
			return (NetworkDirection)(directedMetric & (DirectedMetricType)3);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000222F File Offset: 0x0000042F
		internal static MetricId GetId(this DirectedMetricType directedMetric)
		{
			return MetricId.Create<DirectedMetricType>(directedMetric);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002238 File Offset: 0x00000438
		internal static string GetDisplayName(this DirectedMetricType directedMetric)
		{
			string result;
			if (DirectedMetricTypeExtensions.s_DisplayNames.TryGetValue(directedMetric, out result))
			{
				return result;
			}
			return directedMetric.ToString();
		}

		// Token: 0x04000007 RID: 7
		private static readonly Dictionary<DirectedMetricType, string> s_Identifiers = new Dictionary<DirectedMetricType, string>();

		// Token: 0x04000008 RID: 8
		private static readonly Dictionary<DirectedMetricType, string> s_DisplayNames = new Dictionary<DirectedMetricType, string>();
	}
}
