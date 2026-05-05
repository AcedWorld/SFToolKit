using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000014 RID: 20
	[Serializable]
	internal struct ObjectDestroyedEvent : INetworkMetricEvent, INetworkObjectEvent
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002542 File Offset: 0x00000742
		public ObjectDestroyedEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, long bytesCount)
		{
			this.Connection = connection;
			this.NetworkId = networkId;
			this.BytesCount = bytesCount;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002559 File Offset: 0x00000759
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002561 File Offset: 0x00000761
		public readonly NetworkObjectIdentifier NetworkId { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002569 File Offset: 0x00000769
		public readonly long BytesCount { get; }
	}
}
