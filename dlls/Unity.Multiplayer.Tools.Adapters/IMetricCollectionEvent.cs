using System;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000008 RID: 8
	internal interface IMetricCollectionEvent : IAdapterComponent
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000010 RID: 16
		// (remove) Token: 0x06000011 RID: 17
		event Action<MetricCollection> MetricCollectionEvent;
	}
}
