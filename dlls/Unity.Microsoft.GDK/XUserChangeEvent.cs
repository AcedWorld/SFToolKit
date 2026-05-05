using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200019F RID: 415
	[MovedFrom("Unity.GameCore")]
	public enum XUserChangeEvent : uint
	{
		// Token: 0x04000594 RID: 1428
		SignedInAgain,
		// Token: 0x04000595 RID: 1429
		SigningOut,
		// Token: 0x04000596 RID: 1430
		SignedOut,
		// Token: 0x04000597 RID: 1431
		Gamertag,
		// Token: 0x04000598 RID: 1432
		GamerPicture,
		// Token: 0x04000599 RID: 1433
		Privileges
	}
}
