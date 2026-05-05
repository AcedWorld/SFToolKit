using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000008 RID: 8
	internal interface INetworkMetricEvent
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001B RID: 27
		ConnectionInfo Connection { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001C RID: 28
		long BytesCount { get; }
	}
}
