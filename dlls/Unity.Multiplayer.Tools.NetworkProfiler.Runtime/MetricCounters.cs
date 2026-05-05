using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.MetricTypes;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x02000009 RID: 9
	internal class MetricCounters
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002201 File Offset: 0x00000401
		public MetricCounters(string displayName, ICounterFactory byteCounterFactory, ICounterFactory eventCounterFactory)
		{
			this.Bytes = new MetricByteCounters(displayName, byteCounterFactory);
			this.Events = new MetricEventCounters(displayName, eventCounterFactory);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002223 File Offset: 0x00000423
		public void Sample<TEventData>(IReadOnlyList<TEventData> sent, IReadOnlyList<TEventData> received) where TEventData : struct, INetworkMetricEvent
		{
			this.Bytes.Sample<TEventData>(sent, received);
			this.Events.Sample<TEventData>(sent, received);
		}

		// Token: 0x04000006 RID: 6
		public readonly MetricByteCounters Bytes;

		// Token: 0x04000007 RID: 7
		public readonly MetricEventCounters Events;
	}
}
