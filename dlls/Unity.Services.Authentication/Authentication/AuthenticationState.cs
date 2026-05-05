using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000006 RID: 6
	internal enum AuthenticationState
	{
		// Token: 0x04000025 RID: 37
		SignedOut,
		// Token: 0x04000026 RID: 38
		SigningIn,
		// Token: 0x04000027 RID: 39
		Authorized,
		// Token: 0x04000028 RID: 40
		Refreshing,
		// Token: 0x04000029 RID: 41
		Expired
	}
}
