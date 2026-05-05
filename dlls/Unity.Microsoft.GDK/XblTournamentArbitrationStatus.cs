using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000A3 RID: 163
	[MovedFrom("Unity.GameCore")]
	public enum XblTournamentArbitrationStatus : uint
	{
		// Token: 0x0400021C RID: 540
		Waiting,
		// Token: 0x0400021D RID: 541
		InProgress,
		// Token: 0x0400021E RID: 542
		Complete,
		// Token: 0x0400021F RID: 543
		Playing,
		// Token: 0x04000220 RID: 544
		Incomplete,
		// Token: 0x04000221 RID: 545
		Joining
	}
}
