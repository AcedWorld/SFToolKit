using System;

namespace Unity.Services.Qos
{
	// Token: 0x02000018 RID: 24
	public interface IQosResult
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000061 RID: 97
		string Region { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000062 RID: 98
		int AverageLatencyMs { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000063 RID: 99
		float PacketLossPercent { get; }
	}
}
