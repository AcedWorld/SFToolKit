using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200008B RID: 139
	internal struct RelayMessageConnectRequest
	{
		// Token: 0x06000270 RID: 624 RVA: 0x0000DA20 File Offset: 0x0000BC20
		internal static RelayMessageConnectRequest Create(RelayAllocationId allocationId, RelayConnectionData toConnectionData)
		{
			return new RelayMessageConnectRequest
			{
				Header = RelayMessageHeader.Create(RelayMessageType.ConnectRequest),
				AllocationId = allocationId,
				ToConnectionDataLength = byte.MaxValue,
				ToConnectionData = toConnectionData
			};
		}

		// Token: 0x040001CD RID: 461
		public const int Length = 276;

		// Token: 0x040001CE RID: 462
		public RelayMessageHeader Header;

		// Token: 0x040001CF RID: 463
		public RelayAllocationId AllocationId;

		// Token: 0x040001D0 RID: 464
		public byte ToConnectionDataLength;

		// Token: 0x040001D1 RID: 465
		public RelayConnectionData ToConnectionData;
	}
}
