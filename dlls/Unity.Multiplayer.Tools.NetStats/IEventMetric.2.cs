using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000013 RID: 19
	internal interface IEventMetric<TValue> : IEventMetric, IMetric
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004D RID: 77
		IReadOnlyList<TValue> Values { get; }
	}
}
