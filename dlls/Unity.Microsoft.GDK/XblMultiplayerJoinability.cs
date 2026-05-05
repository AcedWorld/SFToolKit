using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B0 RID: 176
	[MovedFrom("Unity.GameCore")]
	public enum XblMultiplayerJoinability : uint
	{
		// Token: 0x0400026A RID: 618
		None,
		// Token: 0x0400026B RID: 619
		JoinableByFriends,
		// Token: 0x0400026C RID: 620
		InviteOnly,
		// Token: 0x0400026D RID: 621
		DisableWhileGameInProgress,
		// Token: 0x0400026E RID: 622
		Closed
	}
}
