using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200000D RID: 13
	[Flags]
	internal enum NetworkDirection
	{
		// Token: 0x0400003D RID: 61
		None = 0,
		// Token: 0x0400003E RID: 62
		Received = 1,
		// Token: 0x0400003F RID: 63
		Sent = 2,
		// Token: 0x04000040 RID: 64
		SentAndReceived = 3
	}
}
