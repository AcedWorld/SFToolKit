using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001EB RID: 491
	internal struct XblAchievementsManagerEvent
	{
		// Token: 0x04000684 RID: 1668
		internal XblAchievementProgressChangeEntry progressInfo;

		// Token: 0x04000685 RID: 1669
		internal ulong xboxUserId;

		// Token: 0x04000686 RID: 1670
		internal XblAchievementsManagerEventType eventType;
	}
}
