using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	internal struct ObjectSpawnedEvent : INetworkMetricEvent, INetworkObjectEvent
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00002571 File Offset: 0x00000771
		public ObjectSpawnedEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, long bytesCount)
		{
			this.Connection = connection;
			this.NetworkId = networkId;
			this.BytesCount = bytesCount;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002588 File Offset: 0x00000788
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002590 File Offset: 0x00000790
		public readonly NetworkObjectIdentifier NetworkId { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002598 File Offset: 0x00000798
		public readonly long BytesCount { get; }
	}
}
