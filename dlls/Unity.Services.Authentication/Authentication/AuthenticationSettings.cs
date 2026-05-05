using System;

namespace Unity.Services.Authentication
{
	// Token: 0x0200003F RID: 63
	internal class AuthenticationSettings : IAuthenticationSettings
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00005266 File Offset: 0x00003466
		// (set) Token: 0x06000186 RID: 390 RVA: 0x0000526E File Offset: 0x0000346E
		public int AccessTokenRefreshBuffer { get; internal set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00005277 File Offset: 0x00003477
		// (set) Token: 0x06000188 RID: 392 RVA: 0x0000527F File Offset: 0x0000347F
		public int AccessTokenExpiryBuffer { get; internal set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00005288 File Offset: 0x00003488
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00005290 File Offset: 0x00003490
		public int RefreshAttemptFrequency { get; internal set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00005299 File Offset: 0x00003499
		// (set) Token: 0x0600018C RID: 396 RVA: 0x000052A1 File Offset: 0x000034A1
		public int CodeConfirmationAttempts { get; internal set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000052AA File Offset: 0x000034AA
		// (set) Token: 0x0600018E RID: 398 RVA: 0x000052B2 File Offset: 0x000034B2
		public int CodeConfirmationDelay { get; internal set; }

		// Token: 0x0600018F RID: 399 RVA: 0x000052BB File Offset: 0x000034BB
		internal AuthenticationSettings()
		{
			this.AccessTokenRefreshBuffer = 300;
			this.AccessTokenExpiryBuffer = 15;
			this.RefreshAttemptFrequency = 30;
			this.CodeConfirmationDelay = 5;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000052E5 File Offset: 0x000034E5
		internal void Reset()
		{
			this.AccessTokenRefreshBuffer = 300;
			this.AccessTokenExpiryBuffer = 15;
			this.RefreshAttemptFrequency = 30;
			this.CodeConfirmationDelay = 5;
		}

		// Token: 0x040000C4 RID: 196
		private const int k_AccessTokenRefreshBuffer = 300;

		// Token: 0x040000C5 RID: 197
		private const int k_AccessTokenExpiryBuffer = 15;

		// Token: 0x040000C6 RID: 198
		private const int k_RefreshAttemptFrequency = 30;

		// Token: 0x040000C7 RID: 199
		private const int k_CodeConfirmationDelay = 5;
	}
}
