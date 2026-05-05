using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	internal struct ServerLogEvent : INetworkMetricEvent
	{
		// Token: 0x0600004E RID: 78 RVA: 0x0000268D File Offset: 0x0000088D
		public ServerLogEvent(ConnectionInfo connection, LogLevel logLevel, long bytesCount)
		{
			this.Connection = connection;
			this.LogLevel = logLevel;
			this.BytesCount = bytesCount;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000026A4 File Offset: 0x000008A4
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000026AC File Offset: 0x000008AC
		public readonly LogLevel LogLevel { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000026B4 File Offset: 0x000008B4
		public readonly long BytesCount { get; }
	}
}
