using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	internal struct NetworkVariableEvent : INetworkMetricEvent, INetworkObjectEvent
	{
		// Token: 0x0600002E RID: 46 RVA: 0x000024DA File Offset: 0x000006DA
		public NetworkVariableEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, string name, string networkBehaviourName, long bytesCount)
		{
			this = new NetworkVariableEvent(connection, networkId, StringConversionUtility.ConvertToFixedString(name), StringConversionUtility.ConvertToFixedString(networkBehaviourName), bytesCount);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000024F3 File Offset: 0x000006F3
		public NetworkVariableEvent(ConnectionInfo connection, NetworkObjectIdentifier networkId, FixedString64Bytes name, FixedString64Bytes networkBehaviourName, long bytesCount)
		{
			this.Connection = connection;
			this.NetworkId = networkId;
			this.Name = name;
			this.NetworkBehaviourName = networkBehaviourName;
			this.BytesCount = bytesCount;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000251A File Offset: 0x0000071A
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002522 File Offset: 0x00000722
		public readonly NetworkObjectIdentifier NetworkId { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000252A File Offset: 0x0000072A
		public readonly FixedString64Bytes Name { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002532 File Offset: 0x00000732
		public readonly FixedString64Bytes NetworkBehaviourName { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000034 RID: 52 RVA: 0x0000253A File Offset: 0x0000073A
		public readonly long BytesCount { get; }
	}
}
