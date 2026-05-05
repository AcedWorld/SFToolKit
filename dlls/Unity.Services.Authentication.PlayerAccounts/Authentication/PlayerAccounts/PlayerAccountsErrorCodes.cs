using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000004 RID: 4
	public static class PlayerAccountsErrorCodes
	{
		// Token: 0x04000001 RID: 1
		public const int UnknownError = 10100;

		// Token: 0x04000002 RID: 2
		public const int InvalidState = 10101;

		// Token: 0x04000003 RID: 3
		public const int MissingClientId = 10102;

		// Token: 0x04000004 RID: 4
		public const int InvalidClient = 10103;

		// Token: 0x04000005 RID: 5
		public const int InvalidScope = 10104;

		// Token: 0x04000006 RID: 6
		public const int InvalidRequest = 10105;

		// Token: 0x04000007 RID: 7
		public const int InvalidGrant = 10106;

		// Token: 0x04000008 RID: 8
		public const int MissingRefreshToken = 10107;

		// Token: 0x04000009 RID: 9
		public const int UnauthorizedClient = 10108;

		// Token: 0x0400000A RID: 10
		public const int UnsupportedGrantType = 10109;

		// Token: 0x0400000B RID: 11
		public const int UnsupportedResponseType = 10110;
	}
}
