using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200008E RID: 142
	internal struct RelayMessageHeader
	{
		// Token: 0x06000273 RID: 627 RVA: 0x0000DAC8 File Offset: 0x0000BCC8
		public bool IsValid()
		{
			return this.Signature == 29402 && this.Version == 0;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000DAE4 File Offset: 0x0000BCE4
		internal static RelayMessageHeader Create(RelayMessageType type)
		{
			return new RelayMessageHeader
			{
				Signature = 29402,
				Version = 0,
				Type = type
			};
		}

		// Token: 0x040001DA RID: 474
		public const int Length = 4;

		// Token: 0x040001DB RID: 475
		public ushort Signature;

		// Token: 0x040001DC RID: 476
		public byte Version;

		// Token: 0x040001DD RID: 477
		public RelayMessageType Type;
	}
}
