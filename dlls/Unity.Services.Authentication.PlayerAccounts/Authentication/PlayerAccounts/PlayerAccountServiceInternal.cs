using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Core.Configuration.Internal;
using UnityEngine;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200000D RID: 13
	internal class PlayerAccountServiceInternal : IPlayerAccountService
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000027 RID: 39 RVA: 0x00002340 File Offset: 0x00000540
		// (remove) Token: 0x06000028 RID: 40 RVA: 0x00002378 File Offset: 0x00000578
		public event Action SignedIn;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000029 RID: 41 RVA: 0x000023B0 File Offset: 0x000005B0
		// (remove) Token: 0x0600002A RID: 42 RVA: 0x000023E8 File Offset: 0x000005E8
		public event Action SignedOut;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600002B RID: 43 RVA: 0x00002420 File Offset: 0x00000620
		// (remove) Token: 0x0600002C RID: 44 RVA: 0x00002458 File Offset: 0x00000658
		public event Action<RequestFailedException> SignInFailed;

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000248D File Offset: 0x0000068D
		public string AccountPortalUrl
		{
			get
			{
				return "https://player-account.unity.com";
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002494 File Offset: 0x00000694
		public bool IsSignedIn
		{
			get
			{
				return this.SignInState == PlayerAccountState.Authorized || this.SignInState == PlayerAccountState.Refreshing;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000024AA File Offset: 0x000006AA
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000024B2 File Offset: 0x000006B2
		public string AccessToken { get; internal set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000024BB File Offset: 0x000006BB
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000024C3 File Offset: 0x000006C3
		public string IdToken { get; internal set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000024CC File Offset: 0x000006CC
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000024D4 File Offset: 0x000006D4
		public string RefreshToken { get; internal set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000024DD File Offset: 0x000006DD
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000024E5 File Offset: 0x000006E5
		public IdToken IdTokenClaims { get; internal set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000024EE File Offset: 0x000006EE
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000024F6 File Offset: 0x000006F6
		internal PlayerAccountState SignInState { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000024FF File Offset: 0x000006FF
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002507 File Offset: 0x00000707
		internal string RedirectUri { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002510 File Offset: 0x00000710
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002518 File Offset: 0x00000718
		internal string CodeVerifier { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002521 File Offset: 0x00000721
		internal string ClientId
		{
			get
			{
				UnityPlayerAccountSettings settings = this.m_Settings;
				if (settings == null)
				{
					return null;
				}
				return settings.ClientId;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002534 File Offset: 0x00000734
		internal PlayerAccountServiceInternal(UnityPlayerAccountSettings settings, ICloudProjectId cloudProjectId, IJwtDecoder jwtDecoder, INetworkHandler networkingClient)
		{
			this.m_Settings = settings;
			this.m_CloudProjectId = cloudProjectId;
			this.m_BrowserUtils = BrowserUtils.CreateBrowserUtils(this.m_CloudProjectId, this.m_Settings, new Action<string>(this.OnAuthCodeReceived));
			this.m_JwtDecoder = jwtDecoder;
			this.m_NetworkingClient = networkingClient;
			this.SignInState = PlayerAccountState.SignedOut;
			Application.deepLinkActivated += this.OnDeepLinkActivated;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000025A0 File Offset: 0x000007A0
		public Task StartSignInAsync(bool isSigningUp = false)
		{
			PlayerAccountServiceInternal.<StartSignInAsync>d__53 <StartSignInAsync>d__;
			<StartSignInAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StartSignInAsync>d__.<>4__this = this;
			<StartSignInAsync>d__.isSigningUp = isSigningUp;
			<StartSignInAsync>d__.<>1__state = -1;
			<StartSignInAsync>d__.<>t__builder.Start<PlayerAccountServiceInternal.<StartSignInAsync>d__53>(ref <StartSignInAsync>d__);
			return <StartSignInAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000025EC File Offset: 0x000007EC
		public Task RefreshTokenAsync()
		{
			if (!this.IsSignedIn)
			{
				throw PlayerAccountsException.Create(10101, "Player is not signed in.", null);
			}
			string refreshToken = this.RefreshToken;
			if (string.IsNullOrEmpty(refreshToken))
			{
				throw PlayerAccountsException.Create(10107, "Refresh token is null or empty.", null);
			}
			this.SignInState = PlayerAccountState.Refreshing;
			string refreshRequest = string.Concat(new string[]
			{
				"client_id=",
				this.ClientId,
				"&refresh_token=",
				refreshToken,
				"&grant_type=refresh_token"
			});
			if (!string.IsNullOrEmpty(this.m_Settings.Scope))
			{
				refreshRequest = refreshRequest + "&scope=" + this.m_Settings.Scope;
			}
			return this.HandleSignInRequestAsync(() => this.m_NetworkingClient.PostAsync<SignInResponse>("https://player-login.unity.com/v1/oauth2/token", refreshRequest, null));
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000026C1 File Offset: 0x000008C1
		public void SignOut()
		{
			this.AccessToken = null;
			int signInState = (int)this.SignInState;
			this.SignInState = PlayerAccountState.SignedOut;
			if (signInState != 1)
			{
				Action signedOut = this.SignedOut;
				if (signedOut == null)
				{
					return;
				}
				signedOut();
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000026EC File Offset: 0x000008EC
		private string BuildAuthorizationRequestUrl(bool isSigningUp)
		{
			CodeChallengeGenerator codeChallengeGenerator = new CodeChallengeGenerator();
			this.CodeVerifier = codeChallengeGenerator.GenerateCode();
			string text = codeChallengeGenerator.GenerateStateString();
			string text2 = CodeChallengeGenerator.S256EncodeChallenge(this.CodeVerifier);
			IBrowserUtils browserUtils = this.m_BrowserUtils;
			this.RedirectUri = ((browserUtils != null) ? browserUtils.GetRedirectUri() : null);
			string text3 = string.Concat(new string[]
			{
				"https://player-login.unity.com/v1/oauth2/auth?response_type=code&redirect_uri=",
				Uri.EscapeDataString(this.RedirectUri),
				"&response_mode=query&client_id=",
				this.ClientId,
				"&state=",
				text,
				"&code_challenge=",
				text2,
				"&code_challenge_method=S256"
			});
			if (isSigningUp)
			{
				text3 += "&action=sign-up";
			}
			if (!string.IsNullOrEmpty(this.m_Settings.Scope))
			{
				text3 = text3 + "&scope=" + this.m_Settings.Scope;
			}
			Logger.Log("AuthorizationRequest URL: " + text3);
			return text3;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000027D4 File Offset: 0x000009D4
		private void OnDeepLinkActivated(string url)
		{
			Uri uri = new Uri(url);
			if (uri.Scheme != this.m_Settings.DeepLinkUriScheme)
			{
				return;
			}
			Dictionary<string, string> dictionary = UriHelper.ParseQueryString(uri.Query.Trim());
			Dictionary<string, string> dictionary2 = UriHelper.ParseQueryString(uri.Fragment.Trim());
			string text;
			dictionary.TryGetValue("code", out text);
			string text2;
			dictionary.TryGetValue("error", out text2);
			if (string.IsNullOrEmpty(text))
			{
				dictionary2.TryGetValue("code", out text);
			}
			if (string.IsNullOrEmpty(text2))
			{
				dictionary2.TryGetValue("error", out text2);
			}
			if (!string.IsNullOrEmpty(text2))
			{
				throw PlayerAccountsExceptionHandler.HandleError(text2, null, null);
			}
			this.OnAuthCodeReceived(text);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002886 File Offset: 0x00000A86
		private void OnAuthCodeReceived(string code)
		{
			this.SignInRequestAsync(code, this.CodeVerifier, this.RedirectUri);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000289C File Offset: 0x00000A9C
		private Task SignInRequestAsync(string code, string codeVerifier, string redirectUri)
		{
			string signInRequestBody = string.Concat(new string[]
			{
				"code=",
				code,
				"&redirect_uri=",
				Uri.EscapeDataString(redirectUri),
				"&client_id=",
				this.ClientId,
				"&code_verifier=",
				codeVerifier,
				"&grant_type=authorization_code"
			});
			return this.HandleSignInRequestAsync(() => this.m_NetworkingClient.PostAsync<SignInResponse>("https://player-login.unity.com/v1/oauth2/token", signInRequestBody, null));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000291C File Offset: 0x00000B1C
		private Task HandleSignInRequestAsync(Func<Task<SignInResponse>> signInRequest)
		{
			PlayerAccountServiceInternal.<HandleSignInRequestAsync>d__60 <HandleSignInRequestAsync>d__;
			<HandleSignInRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<HandleSignInRequestAsync>d__.<>4__this = this;
			<HandleSignInRequestAsync>d__.signInRequest = signInRequest;
			<HandleSignInRequestAsync>d__.<>1__state = -1;
			<HandleSignInRequestAsync>d__.<>t__builder.Start<PlayerAccountServiceInternal.<HandleSignInRequestAsync>d__60>(ref <HandleSignInRequestAsync>d__);
			return <HandleSignInRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002967 File Offset: 0x00000B67
		private void SendSignInFailedEvent(RequestFailedException exception, bool forceSignOut)
		{
			Action<RequestFailedException> signInFailed = this.SignInFailed;
			if (signInFailed != null)
			{
				signInFailed(exception);
			}
			if (forceSignOut)
			{
				this.SignOut();
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002984 File Offset: 0x00000B84
		internal void CompleteSignIn(SignInResponse signInResponse)
		{
			this.AccessToken = ((signInResponse != null) ? signInResponse.AccessToken : null);
			this.IdToken = ((signInResponse != null) ? signInResponse.IdToken : null);
			if (this.IdToken != null)
			{
				this.IdTokenClaims = this.m_JwtDecoder.Decode<IdToken>(this.IdToken);
			}
			this.RefreshToken = ((signInResponse != null) ? signInResponse.RefreshToken : null);
			this.SignInState = PlayerAccountState.Authorized;
			Action signedIn = this.SignedIn;
			if (signedIn == null)
			{
				return;
			}
			signedIn();
		}

		// Token: 0x04000024 RID: 36
		private const string k_AccountPortalUrl = "https://player-account.unity.com";

		// Token: 0x04000025 RID: 37
		private const string k_AuthUrl = "https://player-login.unity.com/v1/oauth2/auth";

		// Token: 0x04000026 RID: 38
		private const string k_TokenUrl = "https://player-login.unity.com/v1/oauth2/token";

		// Token: 0x04000027 RID: 39
		private const string k_CodeChallengeMethod = "S256";

		// Token: 0x0400002F RID: 47
		private readonly ICloudProjectId m_CloudProjectId;

		// Token: 0x04000030 RID: 48
		private readonly IBrowserUtils m_BrowserUtils;

		// Token: 0x04000031 RID: 49
		private readonly IJwtDecoder m_JwtDecoder;

		// Token: 0x04000032 RID: 50
		private readonly INetworkHandler m_NetworkingClient;

		// Token: 0x04000033 RID: 51
		private readonly UnityPlayerAccountSettings m_Settings;
	}
}
