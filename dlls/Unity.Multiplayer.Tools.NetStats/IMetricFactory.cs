using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000016 RID: 22
	internal interface IMetricFactory
	{
		// Token: 0x06000056 RID: 86
		bool TryConstruct(MetricHeader header, out IMetric metric);
	}
}
