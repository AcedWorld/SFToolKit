using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001A6 RID: 422
	[MovedFrom("Unity.GameCore")]
	public enum XUserPrivilegeDenyReason : uint
	{
		// Token: 0x040005BF RID: 1471
		None,
		// Token: 0x040005C0 RID: 1472
		PurchaseRequired,
		// Token: 0x040005C1 RID: 1473
		Restricted,
		// Token: 0x040005C2 RID: 1474
		Banned,
		// Token: 0x040005C3 RID: 1475
		Unknown = 4294967295U
	}
}
