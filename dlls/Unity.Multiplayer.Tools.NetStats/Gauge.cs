using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200000F RID: 15
	[Serializable]
	internal class Gauge : Metric<double>
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00002A37 File Offset: 0x00000C37
		public Gauge(MetricId metricId, double defaultValue = 0.0) : base(metricId, defaultValue)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002A41 File Offset: 0x00000C41
		public void Set(double value)
		{
			base.Value = value;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002A4A File Offset: 0x00000C4A
		public override MetricContainerType MetricContainerType
		{
			get
			{
				return MetricContainerType.Gauge;
			}
		}
	}
}
