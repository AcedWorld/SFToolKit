using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000152 RID: 338
	public class XNetworkingStatisticsBuffer
	{
		// Token: 0x0600082B RID: 2091 RVA: 0x0000D960 File Offset: 0x0000BB60
		internal XNetworkingStatisticsBuffer(XNetworkingStatisticsBuffer interop)
		{
			this._interop = interop;
			this._tcpQueuedReceivedBufferUsageStatistics = new XNetworkingTcpQueuedReceivedBufferUsageStatistics(interop.tcpQueuedReceiveBufferUsage);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0000D980 File Offset: 0x0000BB80
		public XNetworkingStatisticsBuffer()
		{
			this._interop = default(XNetworkingStatisticsBuffer);
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0000D994 File Offset: 0x0000BB94
		internal XNetworkingStatisticsBuffer interop
		{
			get
			{
				this._interop.tcpQueuedReceiveBufferUsage = this._tcpQueuedReceivedBufferUsageStatistics.interop;
				return this._interop;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0000D9B2 File Offset: 0x0000BBB2
		// (set) Token: 0x0600082F RID: 2095 RVA: 0x0000D9BA File Offset: 0x0000BBBA
		public XNetworkingTcpQueuedReceivedBufferUsageStatistics TcpQueuedReceiveBufferUsage
		{
			get
			{
				return this._tcpQueuedReceivedBufferUsageStatistics;
			}
			set
			{
				this._tcpQueuedReceivedBufferUsageStatistics = value;
			}
		}

		// Token: 0x040004F3 RID: 1267
		internal XNetworkingStatisticsBuffer _interop;

		// Token: 0x040004F4 RID: 1268
		internal XNetworkingTcpQueuedReceivedBufferUsageStatistics _tcpQueuedReceivedBufferUsageStatistics;
	}
}
