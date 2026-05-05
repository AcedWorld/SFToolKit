using System;
using Unity.Multiplayer.Tools;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Netcode
{
	// Token: 0x020000A7 RID: 167
	internal class NetcodeObserver
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00011FA0 File Offset: 0x000101A0
		public static IMetricObserver Observer { get; } = MetricObserverFactory.Construct();
	}
}
