using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	internal class Counter : Metric<long>
	{
		// Token: 0x06000026 RID: 38 RVA: 0x0000273C File Offset: 0x0000093C
		public Counter(MetricId metricId, long defaultValue = 0L) : base(metricId, defaultValue)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002746 File Offset: 0x00000946
		public void Increment(long increment = 1L)
		{
			base.Value += increment;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002756 File Offset: 0x00000956
		public override MetricContainerType MetricContainerType
		{
			get
			{
				return MetricContainerType.Counter;
			}
		}
	}
}
