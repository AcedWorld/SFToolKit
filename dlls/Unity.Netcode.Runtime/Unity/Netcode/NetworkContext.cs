using System;

namespace Unity.Netcode
{
	// Token: 0x02000075 RID: 117
	internal ref struct NetworkContext
	{
		// Token: 0x0400017E RID: 382
		public object SystemOwner;

		// Token: 0x0400017F RID: 383
		public ulong SenderId;

		// Token: 0x04000180 RID: 384
		public float Timestamp;

		// Token: 0x04000181 RID: 385
		public NetworkMessageHeader Header;

		// Token: 0x04000182 RID: 386
		public int SerializedHeaderSize;

		// Token: 0x04000183 RID: 387
		public uint MessageSize;
	}
}
