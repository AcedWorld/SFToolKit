using System;

namespace Unity.Netcode
{
	// Token: 0x02000074 RID: 116
	internal struct NetworkBatchHeader : INetworkSerializeByMemcpy
	{
		// Token: 0x04000179 RID: 377
		internal const ushort MagicValue = 4448;

		// Token: 0x0400017A RID: 378
		public ushort Magic;

		// Token: 0x0400017B RID: 379
		public ushort BatchCount;

		// Token: 0x0400017C RID: 380
		public int BatchSize;

		// Token: 0x0400017D RID: 381
		public ulong BatchHash;
	}
}
