using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000006 RID: 6
	internal interface IMetricObserver
	{
		// Token: 0x06000008 RID: 8
		void Observe(MetricCollection collection);
	}
}
