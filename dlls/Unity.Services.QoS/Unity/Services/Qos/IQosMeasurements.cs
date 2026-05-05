using System;

namespace Unity.Services.Qos
{
	// Token: 0x02000017 RID: 23
	public interface IQosMeasurements
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005F RID: 95
		int AverageLatencyMs { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000060 RID: 96
		float PacketLossPercent { get; }
	}
}
