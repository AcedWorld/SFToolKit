using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F7 RID: 247
	[Flags]
	[MovedFrom("Unity.GameCore")]
	public enum XblSocialManagerExtraDetailLevel : uint
	{
		// Token: 0x040003E2 RID: 994
		NoExtraDetail = 0U,
		// Token: 0x040003E3 RID: 995
		TitleHistoryLevel = 1U,
		// Token: 0x040003E4 RID: 996
		PreferredColorLevel = 2U,
		// Token: 0x040003E5 RID: 997
		All = 3U
	}
}
