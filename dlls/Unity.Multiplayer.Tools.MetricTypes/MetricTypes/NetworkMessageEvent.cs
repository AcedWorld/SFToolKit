using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000010 RID: 16
	[Serializable]
	internal struct NetworkMessageEvent : INetworkMetricEvent
	{
		// Token: 0x06000024 RID: 36 RVA: 0x0000230E File Offset: 0x0000050E
		public NetworkMessageEvent(ConnectionInfo connection, string name, long bytesCount)
		{
			this = new NetworkMessageEvent(connection, StringConversionUtility.ConvertToFixedString(name), bytesCount);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000231E File Offset: 0x0000051E
		public NetworkMessageEvent(ConnectionInfo connection, FixedString64Bytes name, long bytesCount)
		{
			this.Connection = connection;
			this.Name = name;
			this.BytesCount = bytesCount;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002335 File Offset: 0x00000535
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000233D File Offset: 0x0000053D
		public readonly FixedString64Bytes Name { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002345 File Offset: 0x00000545
		public readonly long BytesCount { get; }
	}
}
