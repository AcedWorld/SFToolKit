using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000149 RID: 329
	[MovedFrom("Unity.GameCore")]
	public enum XNetworkingConnectivityLevelHint : uint
	{
		// Token: 0x040004D7 RID: 1239
		Unknown,
		// Token: 0x040004D8 RID: 1240
		None,
		// Token: 0x040004D9 RID: 1241
		LocalAccess,
		// Token: 0x040004DA RID: 1242
		InternetAccess,
		// Token: 0x040004DB RID: 1243
		ConstrainedInternetAccess
	}
}
