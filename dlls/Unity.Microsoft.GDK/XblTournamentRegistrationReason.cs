using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000C2 RID: 194
	[MovedFrom("Unity.GameCore")]
	public enum XblTournamentRegistrationReason : uint
	{
		// Token: 0x040002E7 RID: 743
		Unknown,
		// Token: 0x040002E8 RID: 744
		RegistrationClosed,
		// Token: 0x040002E9 RID: 745
		MemberAlreadyRegistered,
		// Token: 0x040002EA RID: 746
		TournamentFull,
		// Token: 0x040002EB RID: 747
		TeamEliminated,
		// Token: 0x040002EC RID: 748
		TournamentCompleted
	}
}
