using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000151 RID: 337
	public class XNetworkingTcpQueuedReceivedBufferUsageStatistics
	{
		// Token: 0x0600081F RID: 2079 RVA: 0x0000D8B6 File Offset: 0x0000BAB6
		internal XNetworkingTcpQueuedReceivedBufferUsageStatistics(XNetworkingTcpQueuedReceivedBufferUsageStatistics interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0000D8C5 File Offset: 0x0000BAC5
		public XNetworkingTcpQueuedReceivedBufferUsageStatistics()
		{
			this.interop = default(XNetworkingTcpQueuedReceivedBufferUsageStatistics);
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0000D8D9 File Offset: 0x0000BAD9
		// (set) Token: 0x06000822 RID: 2082 RVA: 0x0000D8E6 File Offset: 0x0000BAE6
		public ulong NumBytesCurrentlyQueued
		{
			get
			{
				return this.interop.numBytesCurrentlyQueued;
			}
			set
			{
				this.interop.numBytesCurrentlyQueued = value;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x0000D8F4 File Offset: 0x0000BAF4
		// (set) Token: 0x06000824 RID: 2084 RVA: 0x0000D901 File Offset: 0x0000BB01
		public ulong PeakNumBytesEverQueued
		{
			get
			{
				return this.interop.peakNumBytesEverQueued;
			}
			set
			{
				this.interop.peakNumBytesEverQueued = value;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x0000D90F File Offset: 0x0000BB0F
		// (set) Token: 0x06000826 RID: 2086 RVA: 0x0000D91C File Offset: 0x0000BB1C
		public ulong TotalNumBytesQueued
		{
			get
			{
				return this.interop.totalNumBytesQueued;
			}
			set
			{
				this.interop.totalNumBytesQueued = value;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0000D92A File Offset: 0x0000BB2A
		// (set) Token: 0x06000828 RID: 2088 RVA: 0x0000D937 File Offset: 0x0000BB37
		public ulong NumBytesDroppedForExceedingConfiguredMax
		{
			get
			{
				return this.interop.numBytesDroppedForExceedingConfiguredMax;
			}
			set
			{
				this.interop.numBytesDroppedForExceedingConfiguredMax = value;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x0000D945 File Offset: 0x0000BB45
		// (set) Token: 0x0600082A RID: 2090 RVA: 0x0000D952 File Offset: 0x0000BB52
		public ulong NumBytesDroppedDueToAnyFailure
		{
			get
			{
				return this.interop.numBytesDroppedDueToAnyFailure;
			}
			set
			{
				this.interop.numBytesDroppedDueToAnyFailure = value;
			}
		}

		// Token: 0x040004F2 RID: 1266
		internal XNetworkingTcpQueuedReceivedBufferUsageStatistics interop;
	}
}
