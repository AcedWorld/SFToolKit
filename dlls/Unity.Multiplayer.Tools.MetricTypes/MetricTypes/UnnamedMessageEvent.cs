using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	internal struct UnnamedMessageEvent : INetworkMetricEvent
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00002729 File Offset: 0x00000929
		public UnnamedMessageEvent(ConnectionInfo connection, long bytesCount)
		{
			this.Connection = connection;
			this.BytesCount = bytesCount;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002739 File Offset: 0x00000939
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002741 File Offset: 0x00000941
		public readonly long BytesCount { get; }
	}
}
