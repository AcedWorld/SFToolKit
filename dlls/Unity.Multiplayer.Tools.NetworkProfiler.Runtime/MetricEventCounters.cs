using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x0200000A RID: 10
	internal class MetricEventCounters
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000012 RID: 18 RVA: 0x0000223F File Offset: 0x0000043F
		public string Sent { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002247 File Offset: 0x00000447
		public string Received { get; }

		// Token: 0x06000014 RID: 20 RVA: 0x00002250 File Offset: 0x00000450
		public MetricEventCounters(string displayName, ICounterFactory counterFactory)
		{
			this.Sent = displayName + " Sent";
			this.Received = displayName + " Received";
			this.m_SentCounter = counterFactory.Construct(this.Sent);
			this.m_ReceivedCounter = counterFactory.Construct(this.Received);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000022A9 File Offset: 0x000004A9
		public void Sample<TEventData>(IReadOnlyCollection<TEventData> sent, IReadOnlyCollection<TEventData> received)
		{
			this.m_SentCounter.Sample((long)sent.Count);
			this.m_ReceivedCounter.Sample((long)received.Count);
		}

		// Token: 0x04000009 RID: 9
		private readonly ICounter m_SentCounter;

		// Token: 0x0400000B RID: 11
		private readonly ICounter m_ReceivedCounter;
	}
}
