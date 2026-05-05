using System;

namespace Unity.Networking.QoS
{
	// Token: 0x02000005 RID: 5
	internal struct InternalQosResult
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020F0 File Offset: 0x000002F0
		internal uint AverageLatencyMs
		{
			get
			{
				if (this.ResponsesReceived <= 0U)
				{
					return uint.MaxValue;
				}
				return this.AggregateLatencyMs / this.ResponsesReceived;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000210A File Offset: 0x0000030A
		internal float PacketLoss
		{
			get
			{
				if (this.RequestsSent != 0U && this.ResponsesReceived <= this.RequestsSent)
				{
					return 1f - this.ResponsesReceived / this.RequestsSent;
				}
				return float.MaxValue;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000213F File Offset: 0x0000033F
		internal void AddAggregateLatency(uint amountMs)
		{
			this.AggregateLatencyMs += amountMs;
		}

		// Token: 0x04000002 RID: 2
		internal const uint InvalidLatencyValue = 4294967295U;

		// Token: 0x04000003 RID: 3
		internal const float InvalidPacketLossValue = 3.4028235E+38f;

		// Token: 0x04000004 RID: 4
		internal uint RequestsSent;

		// Token: 0x04000005 RID: 5
		internal uint ResponsesReceived;

		// Token: 0x04000006 RID: 6
		internal uint InvalidRequests;

		// Token: 0x04000007 RID: 7
		internal uint InvalidResponses;

		// Token: 0x04000008 RID: 8
		internal uint DuplicateResponses;

		// Token: 0x04000009 RID: 9
		internal FcType FcType;

		// Token: 0x0400000A RID: 10
		internal byte FcUnits;

		// Token: 0x0400000B RID: 11
		internal uint AggregateLatencyMs;
	}
}
