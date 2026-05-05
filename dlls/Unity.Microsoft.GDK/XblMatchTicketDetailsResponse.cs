using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000088 RID: 136
	[MovedFrom("Unity.GameCore")]
	public class XblMatchTicketDetailsResponse
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x0000A2B4 File Offset: 0x000084B4
		internal XblMatchTicketDetailsResponse(XblMatchTicketDetailsResponse interopHandle)
		{
			this.MatchStatus = interopHandle.matchStatus;
			this.EstimatedWaitTime = interopHandle.estimatedWaitTime;
			this.PreserveSession = interopHandle.preserveSession;
			this.TicketSession = new XblMultiplayerSessionReference(interopHandle.ticketSession);
			this.TargetSession = new XblMultiplayerSessionReference(interopHandle.targetSession);
			this.TicketAttributes = interopHandle.ticketAttributes.GetString();
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000A321 File Offset: 0x00008521
		public XblTicketStatus MatchStatus { get; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x0000A329 File Offset: 0x00008529
		public long EstimatedWaitTime { get; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000A331 File Offset: 0x00008531
		public XblPreserveSessionMode PreserveSession { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x0000A339 File Offset: 0x00008539
		public XblMultiplayerSessionReference TicketSession { get; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x0000A341 File Offset: 0x00008541
		public XblMultiplayerSessionReference TargetSession { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x0000A349 File Offset: 0x00008549
		public string TicketAttributes { get; }
	}
}
