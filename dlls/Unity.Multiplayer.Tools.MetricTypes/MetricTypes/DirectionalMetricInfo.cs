using System;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000007 RID: 7
	internal struct DirectionalMetricInfo
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002263 File Offset: 0x00000463
		public DirectionalMetricInfo(DirectedMetricType directedMetricType)
		{
			this.DirectedMetricType = directedMetricType;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000226C File Offset: 0x0000046C
		public DirectionalMetricInfo(MetricType metricType, NetworkDirection networkDirection)
		{
			this.DirectedMetricType = metricType.GetDirectedMetric(networkDirection);
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000016 RID: 22 RVA: 0x0000227B File Offset: 0x0000047B
		internal readonly DirectedMetricType DirectedMetricType { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002283 File Offset: 0x00000483
		internal MetricType Type
		{
			get
			{
				return this.DirectedMetricType.GetMetric();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002290 File Offset: 0x00000490
		internal NetworkDirection Direction
		{
			get
			{
				return this.DirectedMetricType.GetDirection();
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000229D File Offset: 0x0000049D
		internal MetricId Id
		{
			get
			{
				return this.DirectedMetricType.GetId();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000022AA File Offset: 0x000004AA
		internal string DisplayName
		{
			get
			{
				return this.DirectedMetricType.GetDisplayName();
			}
		}
	}
}
