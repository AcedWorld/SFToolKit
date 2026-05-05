using System;

namespace Unity.Netcode
{
	// Token: 0x0200011B RID: 283
	internal interface IRealTimeProvider
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060008E7 RID: 2279
		float RealTimeSinceStartup { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060008E8 RID: 2280
		float UnscaledTime { get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060008E9 RID: 2281
		float UnscaledDeltaTime { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060008EA RID: 2282
		float DeltaTime { get; }
	}
}
