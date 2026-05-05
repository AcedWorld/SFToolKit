using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.Common;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000004 RID: 4
	[AddComponentMenu("")]
	internal class CustomTestDataGenerator : MonoBehaviour
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020E8 File Offset: 0x000002E8
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020F0 File Offset: 0x000002F0
		internal List<MetricTrend> MetricTrends { get; set; } = new List<MetricTrend>
		{
			new MetricTrend
			{
				Trend = new LogNormalRandomWalk()
			}
		};

		// Token: 0x0600000A RID: 10 RVA: 0x000020F9 File Offset: 0x000002F9
		private void Start()
		{
			this.m_Rnsm = Object.FindObjectOfType<RuntimeNetStatsMonitor>();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002108 File Offset: 0x00000308
		private void Update()
		{
			if (!this.m_Rnsm)
			{
				return;
			}
			foreach (MetricTrend metricTrend in this.MetricTrends)
			{
				float value = metricTrend.Trend.NextFloat(this.m_Random);
				this.m_Rnsm.AddCustomValue(metricTrend.Metric, value);
			}
		}

		// Token: 0x04000004 RID: 4
		private RuntimeNetStatsMonitor m_Rnsm;

		// Token: 0x04000005 RID: 5
		private Random m_Random = new Random();
	}
}
