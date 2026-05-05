using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.MetricTypes;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x02000008 RID: 8
	internal class MetricByteCounters
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002108 File Offset: 0x00000308
		public MetricByteCounters(string displayName, ICounterFactory counterFactory)
		{
			this.Sent = displayName + " Bytes Sent";
			this.Received = displayName + " Bytes Received";
			this.m_SentCounter = counterFactory.Construct(this.Sent);
			this.m_ReceivedCounter = counterFactory.Construct(this.Received);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002161 File Offset: 0x00000361
		public string Sent { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002169 File Offset: 0x00000369
		public string Received { get; }

		// Token: 0x0600000E RID: 14 RVA: 0x00002174 File Offset: 0x00000374
		public void Sample<TEventData>(IReadOnlyList<TEventData> sentMetrics, IReadOnlyList<TEventData> receivedMetrics) where TEventData : struct, INetworkMetricEvent
		{
			long num = 0L;
			for (int i = 0; i < sentMetrics.Count; i++)
			{
				TEventData teventData = sentMetrics[i];
				num += teventData.BytesCount;
			}
			long num2 = 0L;
			for (int j = 0; j < receivedMetrics.Count; j++)
			{
				TEventData teventData2 = receivedMetrics[j];
				num2 += teventData2.BytesCount;
			}
			this.Sample(num, num2);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021E7 File Offset: 0x000003E7
		public void Sample(long sent, long received)
		{
			this.m_SentCounter.Sample(sent);
			this.m_ReceivedCounter.Sample(received);
		}

		// Token: 0x04000002 RID: 2
		private readonly ICounter m_SentCounter;

		// Token: 0x04000003 RID: 3
		private readonly ICounter m_ReceivedCounter;
	}
}
