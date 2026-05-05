using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000011 RID: 17
	internal interface IEventMetric : IMetric
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000047 RID: 71
		int Count { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000048 RID: 72
		int MaxNumberOfValues { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000049 RID: 73
		int NumberOfValuesReceived { get; }
	}
}
