using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000086 RID: 134
	[MovedFrom("Unity.GameCore")]
	public class XblHopperStatisticsResponse
	{
		// Token: 0x060004AD RID: 1197 RVA: 0x0000A22D File Offset: 0x0000842D
		internal XblHopperStatisticsResponse()
		{
			this.HopperName = "";
			this.EstimatedWaitTime = 0L;
			this.PlayersWaitingToMatch = 0U;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000A24F File Offset: 0x0000844F
		internal XblHopperStatisticsResponse(XblHopperStatisticsResponse interopHandle)
		{
			this.HopperName = interopHandle.hopperName.GetString();
			this.EstimatedWaitTime = interopHandle.estimatedWaitTime;
			this.PlayersWaitingToMatch = interopHandle.playersWaitingToMatch;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000A281 File Offset: 0x00008481
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0000A289 File Offset: 0x00008489
		public string HopperName { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000A292 File Offset: 0x00008492
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x0000A29A File Offset: 0x0000849A
		public long EstimatedWaitTime { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000A2A3 File Offset: 0x000084A3
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000A2AB File Offset: 0x000084AB
		public uint PlayersWaitingToMatch { get; set; }
	}
}
