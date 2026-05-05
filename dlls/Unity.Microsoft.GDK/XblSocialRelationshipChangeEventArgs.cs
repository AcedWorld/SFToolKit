using System;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000EA RID: 234
	public struct XblSocialRelationshipChangeEventArgs
	{
		// Token: 0x040003B0 RID: 944
		public ulong callerXboxUserId;

		// Token: 0x040003B1 RID: 945
		public XblSocialNotificationType socialNotification;

		// Token: 0x040003B2 RID: 946
		public ulong[] xboxUserIds;
	}
}
