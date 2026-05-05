using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000089 RID: 137
	internal struct RelayMessageAccepted
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000D990 File Offset: 0x0000BB90
		internal static RelayMessageAccepted Create(RelayAllocationId fromAllocationId, RelayAllocationId toAllocationId)
		{
			return new RelayMessageAccepted
			{
				Header = RelayMessageHeader.Create(RelayMessageType.Accepted),
				FromAllocationId = fromAllocationId,
				ToAllocationId = toAllocationId
			};
		}

		// Token: 0x040001C6 RID: 454
		public const int Length = 36;

		// Token: 0x040001C7 RID: 455
		public RelayMessageHeader Header;

		// Token: 0x040001C8 RID: 456
		public RelayAllocationId FromAllocationId;

		// Token: 0x040001C9 RID: 457
		public RelayAllocationId ToAllocationId;
	}
}
