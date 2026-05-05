using System;

namespace Unity.Networking.Transport.Error
{
	// Token: 0x020000A8 RID: 168
	public enum DisconnectReason : byte
	{
		// Token: 0x04000234 RID: 564
		Default,
		// Token: 0x04000235 RID: 565
		Timeout,
		// Token: 0x04000236 RID: 566
		MaxConnectionAttempts,
		// Token: 0x04000237 RID: 567
		ClosedByRemote,
		// Token: 0x04000238 RID: 568
		Count
	}
}
