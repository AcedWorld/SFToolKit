using System;
using System.Collections.Generic;

namespace Unity.Services.Qos
{
	// Token: 0x0200001D RID: 29
	internal class QosResult : IQosAnnotatedResult, IQosResult
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00003E9A File Offset: 0x0000209A
		public QosResult(string region, int averageLatencyMs, float packetLossPercent, Dictionary<string, List<string>> annotations = null)
		{
			this.Region = region;
			this.AverageLatencyMs = averageLatencyMs;
			this.PacketLossPercent = packetLossPercent;
			this.Annotations = (annotations ?? new Dictionary<string, List<string>>());
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003EC8 File Offset: 0x000020C8
		public string Region { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003ED0 File Offset: 0x000020D0
		public int AverageLatencyMs { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003ED8 File Offset: 0x000020D8
		public float PacketLossPercent { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003EE0 File Offset: 0x000020E0
		public Dictionary<string, List<string>> Annotations { get; }
	}
}
