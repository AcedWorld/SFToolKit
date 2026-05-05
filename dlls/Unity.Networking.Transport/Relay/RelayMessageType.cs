using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200008F RID: 143
	internal enum RelayMessageType : byte
	{
		// Token: 0x040001DF RID: 479
		Bind,
		// Token: 0x040001E0 RID: 480
		BindReceived,
		// Token: 0x040001E1 RID: 481
		Ping,
		// Token: 0x040001E2 RID: 482
		ConnectRequest,
		// Token: 0x040001E3 RID: 483
		Accepted = 6,
		// Token: 0x040001E4 RID: 484
		Disconnect = 9,
		// Token: 0x040001E5 RID: 485
		Relay,
		// Token: 0x040001E6 RID: 486
		Error = 12
	}
}
