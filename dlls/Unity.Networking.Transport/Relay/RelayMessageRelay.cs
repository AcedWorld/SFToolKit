using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000091 RID: 145
	internal struct RelayMessageRelay
	{
		// Token: 0x06000276 RID: 630 RVA: 0x0000DB4C File Offset: 0x0000BD4C
		internal static RelayMessageRelay Create(RelayAllocationId fromAllocationId, RelayAllocationId toAllocationId, ushort dataLength)
		{
			return new RelayMessageRelay
			{
				Header = RelayMessageHeader.Create(RelayMessageType.Relay),
				FromAllocationId = fromAllocationId,
				ToAllocationId = toAllocationId,
				DataLength = RelayNetworkProtocol.SwitchEndianness(dataLength)
			};
		}

		// Token: 0x040001EB RID: 491
		public const int Length = 38;

		// Token: 0x040001EC RID: 492
		public RelayMessageHeader Header;

		// Token: 0x040001ED RID: 493
		public RelayAllocationId FromAllocationId;

		// Token: 0x040001EE RID: 494
		public RelayAllocationId ToAllocationId;

		// Token: 0x040001EF RID: 495
		public ushort DataLength;
	}
}
