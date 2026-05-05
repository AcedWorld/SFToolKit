using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200008B RID: 139
	[MovedFrom("Unity.GameCore")]
	public class XblCreateMatchTicketResponse
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x0000A351 File Offset: 0x00008551
		internal XblCreateMatchTicketResponse(XblCreateMatchTicketResponse interopHandle)
		{
			this.MatchTicketId = Converters.ByteArrayToString(interopHandle.matchTicketId);
			this.EstimatedWaitTime = interopHandle.estimatedWaitTime;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0000A376 File Offset: 0x00008576
		public string MatchTicketId { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000A37E File Offset: 0x0000857E
		public long EstimatedWaitTime { get; }
	}
}
