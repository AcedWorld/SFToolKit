using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200000C RID: 12
	[Serializable]
	internal struct NamedMessageEvent : INetworkMetricEvent
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000022B7 File Offset: 0x000004B7
		public NamedMessageEvent(ConnectionInfo connection, string name, long bytesCount)
		{
			this = new NamedMessageEvent(connection, StringConversionUtility.ConvertToFixedString(name), bytesCount);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022C7 File Offset: 0x000004C7
		public NamedMessageEvent(ConnectionInfo connection, FixedString64Bytes name, long bytesCount)
		{
			this.Connection = connection;
			this.Name = name;
			this.BytesCount = bytesCount;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000022DE File Offset: 0x000004DE
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000022E6 File Offset: 0x000004E6
		public readonly FixedString64Bytes Name { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000022EE File Offset: 0x000004EE
		public readonly long BytesCount { get; }
	}
}
