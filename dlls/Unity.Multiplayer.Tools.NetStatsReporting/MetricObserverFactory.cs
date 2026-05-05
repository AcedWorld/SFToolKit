using System;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools
{
	// Token: 0x02000003 RID: 3
	internal static class MetricObserverFactory
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020B8 File Offset: 0x000002B8
		internal static IMetricObserver Construct()
		{
			return new MetricObserver();
		}
	}
}
