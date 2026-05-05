using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200008D RID: 141
	internal struct RelayMessageError
	{
		// Token: 0x06000272 RID: 626 RVA: 0x0000DA94 File Offset: 0x0000BC94
		internal static RelayMessageError Create(RelayAllocationId allocationId, byte errorCode)
		{
			return new RelayMessageError
			{
				Header = RelayMessageHeader.Create(RelayMessageType.Error),
				AllocationId = allocationId,
				ErrorCode = errorCode
			};
		}

		// Token: 0x040001D6 RID: 470
		public const int Length = 21;

		// Token: 0x040001D7 RID: 471
		public RelayMessageHeader Header;

		// Token: 0x040001D8 RID: 472
		public RelayAllocationId AllocationId;

		// Token: 0x040001D9 RID: 473
		public byte ErrorCode;
	}
}
