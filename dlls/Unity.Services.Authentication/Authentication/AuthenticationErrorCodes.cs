using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000009 RID: 9
	public static class AuthenticationErrorCodes
	{
		// Token: 0x04000031 RID: 49
		public static readonly int MinValue = 10000;

		// Token: 0x04000032 RID: 50
		public static readonly int ClientInvalidUserState = 10000;

		// Token: 0x04000033 RID: 51
		public static readonly int ClientNoActiveSession = 10001;

		// Token: 0x04000034 RID: 52
		public static readonly int InvalidParameters = 10002;

		// Token: 0x04000035 RID: 53
		public static readonly int AccountAlreadyLinked = 10003;

		// Token: 0x04000036 RID: 54
		public static readonly int AccountLinkLimitExceeded = 10004;

		// Token: 0x04000037 RID: 55
		public static readonly int ClientUnlinkExternalIdNotFound = 10005;

		// Token: 0x04000038 RID: 56
		public static readonly int ClientInvalidProfile = 10006;

		// Token: 0x04000039 RID: 57
		public static readonly int InvalidSessionToken = 10007;

		// Token: 0x0400003A RID: 58
		public static readonly int InvalidProvider = 10008;

		// Token: 0x0400003B RID: 59
		public static readonly int BannedUser = 10009;

		// Token: 0x0400003C RID: 60
		public static readonly int EnvironmentMismatch = 10010;
	}
}
