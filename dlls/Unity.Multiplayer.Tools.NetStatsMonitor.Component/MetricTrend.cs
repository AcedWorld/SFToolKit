using System;
using Unity.Multiplayer.Tools.Common;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	internal class MetricTrend
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020BE File Offset: 0x000002BE
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020C6 File Offset: 0x000002C6
		public MetricId Metric { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020CF File Offset: 0x000002CF
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020D7 File Offset: 0x000002D7
		public LogNormalRandomWalk Trend { get; set; }
	}
}
