using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	internal struct OwnershipChangeEvent : INetworkMetricEvent, INetworkObjectEvent
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000025A0 File Offset: 0x000007A0
		public OwnershipChangeEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, long bytesCount)
		{
			this.Connection = connection;
			this.NetworkId = networkId;
			this.BytesCount = bytesCount;
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000025B7 File Offset: 0x000007B7
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000025BF File Offset: 0x000007BF
		public readonly NetworkObjectIdentifier NetworkId { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000025C7 File Offset: 0x000007C7
		public readonly long BytesCount { get; }
	}
}
