using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000015 RID: 21
	internal interface IMetric<TValue> : IMetric
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000055 RID: 85
		TValue Value { get; }
	}
}
