using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000C3 RID: 195
	[MovedFrom("Unity.GameCore")]
	public enum XblTournamentRegistrationState : uint
	{
		// Token: 0x040002EE RID: 750
		Unknown,
		// Token: 0x040002EF RID: 751
		Pending,
		// Token: 0x040002F0 RID: 752
		Withdrawn,
		// Token: 0x040002F1 RID: 753
		Rejected,
		// Token: 0x040002F2 RID: 754
		Registered,
		// Token: 0x040002F3 RID: 755
		Completed
	}
}
