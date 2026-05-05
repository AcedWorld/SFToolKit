using System;
using System.Collections.Generic;

namespace Unity.Services.Qos.Runner
{
	// Token: 0x02000051 RID: 81
	public struct QosAnnotatedResult
	{
		// Token: 0x040000B2 RID: 178
		public string Region;

		// Token: 0x040000B3 RID: 179
		public int AverageLatencyMs;

		// Token: 0x040000B4 RID: 180
		public float PacketLossPercent;

		// Token: 0x040000B5 RID: 181
		public Dictionary<string, List<string>> Annotations;
	}
}
