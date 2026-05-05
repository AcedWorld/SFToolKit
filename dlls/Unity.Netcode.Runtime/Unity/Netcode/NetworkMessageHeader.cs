using System;

namespace Unity.Netcode
{
	// Token: 0x02000077 RID: 119
	internal struct NetworkMessageHeader : INetworkSerializeByMemcpy
	{
		// Token: 0x04000185 RID: 389
		public uint MessageType;

		// Token: 0x04000186 RID: 390
		public uint MessageSize;
	}
}
