using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200008C RID: 140
	internal struct RelayMessageDisconnect
	{
		// Token: 0x06000271 RID: 625 RVA: 0x0000DA60 File Offset: 0x0000BC60
		internal static RelayMessageDisconnect Create(RelayAllocationId fromAllocationId, RelayAllocationId toAllocationId)
		{
			return new RelayMessageDisconnect
			{
				Header = RelayMessageHeader.Create(RelayMessageType.Disconnect),
				FromAllocationId = fromAllocationId,
				ToAllocationId = toAllocationId
			};
		}

		// Token: 0x040001D2 RID: 466
		public const int Length = 36;

		// Token: 0x040001D3 RID: 467
		public RelayMessageHeader Header;

		// Token: 0x040001D4 RID: 468
		public RelayAllocationId FromAllocationId;

		// Token: 0x040001D5 RID: 469
		public RelayAllocationId ToAllocationId;
	}
}
