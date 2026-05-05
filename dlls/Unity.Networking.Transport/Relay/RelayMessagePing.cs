using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000090 RID: 144
	internal struct RelayMessagePing
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000DB18 File Offset: 0x0000BD18
		internal static RelayMessagePing Create(RelayAllocationId fromAllocationId, ushort dataLength)
		{
			return new RelayMessagePing
			{
				Header = RelayMessageHeader.Create(RelayMessageType.Ping),
				FromAllocationId = fromAllocationId,
				SequenceNumber = 1
			};
		}

		// Token: 0x040001E7 RID: 487
		public const int Length = 22;

		// Token: 0x040001E8 RID: 488
		public RelayMessageHeader Header;

		// Token: 0x040001E9 RID: 489
		public RelayAllocationId FromAllocationId;

		// Token: 0x040001EA RID: 490
		public ushort SequenceNumber;
	}
}
