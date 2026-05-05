using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F3 RID: 243
	[MovedFrom("Unity.GameCore")]
	public enum XblPresenceFilter : uint
	{
		// Token: 0x040003C6 RID: 966
		Unknown,
		// Token: 0x040003C7 RID: 967
		TitleOnline,
		// Token: 0x040003C8 RID: 968
		TitleOffline,
		// Token: 0x040003C9 RID: 969
		TitleOnlineOutsideTitle,
		// Token: 0x040003CA RID: 970
		AllOnline,
		// Token: 0x040003CB RID: 971
		AllOffline,
		// Token: 0x040003CC RID: 972
		AllTitle,
		// Token: 0x040003CD RID: 973
		All
	}
}
