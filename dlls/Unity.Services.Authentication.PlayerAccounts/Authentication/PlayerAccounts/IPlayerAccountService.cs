using System;
using System.Threading.Tasks;
using Unity.Services.Core;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000007 RID: 7
	public interface IPlayerAccountService
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000007 RID: 7
		// (remove) Token: 0x06000008 RID: 8
		event Action SignedIn;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000009 RID: 9
		// (remove) Token: 0x0600000A RID: 10
		event Action SignedOut;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600000B RID: 11
		// (remove) Token: 0x0600000C RID: 12
		event Action<RequestFailedException> SignInFailed;

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000D RID: 13
		string AccessToken { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14
		string IdToken { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15
		string AccountPortalUrl { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16
		IdToken IdTokenClaims { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000011 RID: 17
		bool IsSignedIn { get; }

		// Token: 0x06000012 RID: 18
		Task StartSignInAsync(bool isSigningUp = false);

		// Token: 0x06000013 RID: 19
		Task RefreshTokenAsync();

		// Token: 0x06000014 RID: 20
		void SignOut();
	}
}
