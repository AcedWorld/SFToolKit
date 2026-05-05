using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000064 RID: 100
	internal enum ProcessPacketCommandType : byte
	{
		// Token: 0x0400014C RID: 332
		Drop,
		// Token: 0x0400014D RID: 333
		AddressUpdate,
		// Token: 0x0400014E RID: 334
		ConnectionAccept,
		// Token: 0x0400014F RID: 335
		ConnectionReject,
		// Token: 0x04000150 RID: 336
		ConnectionRequest,
		// Token: 0x04000151 RID: 337
		Data,
		// Token: 0x04000152 RID: 338
		Disconnect,
		// Token: 0x04000153 RID: 339
		DataWithImplicitConnectionAccept,
		// Token: 0x04000154 RID: 340
		Ping,
		// Token: 0x04000155 RID: 341
		Pong,
		// Token: 0x04000156 RID: 342
		ProtocolStatusUpdate
	}
}
