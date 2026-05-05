using System;

namespace Unity.Netcode
{
	// Token: 0x0200006C RID: 108
	internal struct RpcMetadata : INetworkSerializeByMemcpy
	{
		// Token: 0x04000165 RID: 357
		public ulong NetworkObjectId;

		// Token: 0x04000166 RID: 358
		public ushort NetworkBehaviourId;

		// Token: 0x04000167 RID: 359
		public uint NetworkRpcMethodId;
	}
}
