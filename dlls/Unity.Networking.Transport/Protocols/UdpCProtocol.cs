using System;

namespace Unity.Networking.Transport.Protocols
{
	// Token: 0x020000A5 RID: 165
	internal enum UdpCProtocol
	{
		// Token: 0x04000225 RID: 549
		ConnectionRequest,
		// Token: 0x04000226 RID: 550
		ConnectionReject,
		// Token: 0x04000227 RID: 551
		ConnectionAccept,
		// Token: 0x04000228 RID: 552
		Disconnect,
		// Token: 0x04000229 RID: 553
		Data,
		// Token: 0x0400022A RID: 554
		Ping,
		// Token: 0x0400022B RID: 555
		Pong
	}
}
