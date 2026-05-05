using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000040 RID: 64
	internal interface IAuthenticationSettings
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000191 RID: 401
		int AccessTokenRefreshBuffer { get; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000192 RID: 402
		int AccessTokenExpiryBuffer { get; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000193 RID: 403
		int RefreshAttemptFrequency { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000194 RID: 404
		int CodeConfirmationAttempts { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000195 RID: 405
		int CodeConfirmationDelay { get; }
	}
}
