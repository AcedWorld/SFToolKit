using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F6 RID: 246
	[MovedFrom("Unity.GameCore")]
	public enum XblSocialManagerEventType : uint
	{
		// Token: 0x040003D8 RID: 984
		UsersAddedToSocialGraph,
		// Token: 0x040003D9 RID: 985
		UsersRemovedFromSocialGraph,
		// Token: 0x040003DA RID: 986
		PresenceChanged,
		// Token: 0x040003DB RID: 987
		ProfilesChanged,
		// Token: 0x040003DC RID: 988
		SocialRelationshipsChanged,
		// Token: 0x040003DD RID: 989
		LocalUserAdded,
		// Token: 0x040003DE RID: 990
		SocialUserGroupLoaded,
		// Token: 0x040003DF RID: 991
		SocialUserGroupUpdated,
		// Token: 0x040003E0 RID: 992
		UnknownEvent
	}
}
