using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200000F RID: 15
	internal enum PlayerAccountState
	{
		// Token: 0x04000035 RID: 53
		SignedOut,
		// Token: 0x04000036 RID: 54
		SigningIn,
		// Token: 0x04000037 RID: 55
		Authorized,
		// Token: 0x04000038 RID: 56
		Refreshing,
		// Token: 0x04000039 RID: 57
		Expired
	}
}
