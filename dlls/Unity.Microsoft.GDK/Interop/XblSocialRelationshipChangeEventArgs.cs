using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000228 RID: 552
	public struct XblSocialRelationshipChangeEventArgs
	{
		// Token: 0x040007A8 RID: 1960
		public ulong callerXboxUserId;

		// Token: 0x040007A9 RID: 1961
		public XblSocialNotificationType socialNotification;

		// Token: 0x040007AA RID: 1962
		public unsafe ulong* xboxUserIds;

		// Token: 0x040007AB RID: 1963
		public SizeT xboxUserIdsCount;
	}
}
