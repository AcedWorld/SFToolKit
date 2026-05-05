using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000017 RID: 23
	[Serializable]
	internal struct RpcEvent : INetworkMetricEvent, INetworkObjectEvent
	{
		// Token: 0x06000041 RID: 65 RVA: 0x000025CF File Offset: 0x000007CF
		public RpcEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, string name, string networkBehaviourName, long bytesCount)
		{
			this = new RpcEvent(connection, networkId, StringConversionUtility.ConvertToFixedString(name), StringConversionUtility.ConvertToFixedString(networkBehaviourName), bytesCount);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000025E8 File Offset: 0x000007E8
		public RpcEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, FixedString64Bytes name, FixedString64Bytes networkBehaviourName, long bytesCount)
		{
			this.Connection = connection;
			this.NetworkId = networkId;
			this.Name = name;
			this.NetworkBehaviourName = networkBehaviourName;
			this.BytesCount = bytesCount;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000260F File Offset: 0x0000080F
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002617 File Offset: 0x00000817
		public readonly NetworkObjectIdentifier NetworkId { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000261F File Offset: 0x0000081F
		public readonly FixedString64Bytes Name { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002627 File Offset: 0x00000827
		public readonly FixedString64Bytes NetworkBehaviourName { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000047 RID: 71 RVA: 0x0000262F File Offset: 0x0000082F
		public readonly long BytesCount { get; }
	}
}
