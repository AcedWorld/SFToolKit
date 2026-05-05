using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F5 RID: 501
	internal struct XblMatchTicketDetailsResponse
	{
		// Token: 0x040006AE RID: 1710
		internal XblTicketStatus matchStatus;

		// Token: 0x040006AF RID: 1711
		internal long estimatedWaitTime;

		// Token: 0x040006B0 RID: 1712
		internal XblPreserveSessionMode preserveSession;

		// Token: 0x040006B1 RID: 1713
		internal XblMultiplayerSessionReference ticketSession;

		// Token: 0x040006B2 RID: 1714
		internal XblMultiplayerSessionReference targetSession;

		// Token: 0x040006B3 RID: 1715
		internal readonly UTF8StringPtr ticketAttributes;
	}
}
