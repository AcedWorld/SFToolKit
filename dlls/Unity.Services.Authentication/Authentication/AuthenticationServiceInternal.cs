using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.Services.Authentication.Generated;
using Unity.Services.Core;
using Unity.Services.Core.Environments.Internal;
using Unity.Services.Core.Scheduler.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x02000005 RID: 5
	internal class AuthenticationServiceInternal : IAuthenticationService
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020EC File Offset: 0x000002EC
		public Task SignInWithOpenIdConnectAsync(string idProviderName, string idToken, SignInOptions options = null)
		{
			if (!this.ValidateOpenIdConnectIdProviderName(idProviderName))
			{
				throw this.ExceptionHandler.BuildInvalidIdProviderNameException();
			}
			return this.SignInWithExternalTokenAsync(idProviderName, new SignInWithExternalTokenRequest
			{
				IdProvider = idProviderName,
				Token = idToken,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002140 File Offset: 0x00000340
		public Task LinkWithOpenIdConnectAsync(string idProviderName, string idToken, LinkOptions options = null)
		{
			if (!this.ValidateOpenIdConnectIdProviderName(idProviderName))
			{
				throw this.ExceptionHandler.BuildInvalidIdProviderNameException();
			}
			return this.LinkWithExternalTokenAsync(idProviderName, new LinkWithExternalTokenRequest
			{
				IdProvider = idProviderName,
				Token = idToken,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000218E File Offset: 0x0000038E
		public Task UnlinkOpenIdConnectAsync(string idProviderName)
		{
			if (!this.ValidateOpenIdConnectIdProviderName(idProviderName))
			{
				throw this.ExceptionHandler.BuildInvalidIdProviderNameException();
			}
			return this.UnlinkExternalTokenAsync(idProviderName);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021AC File Offset: 0x000003AC
		public void ProcessAuthenticationTokens(string accessToken, string sessionToken = null)
		{
			if (this.State == AuthenticationState.SignedOut || this.State == AuthenticationState.Expired)
			{
				try
				{
					this.ValidateAccessToken(accessToken);
				}
				catch (RequestFailedException)
				{
					throw;
				}
				catch (Exception ex)
				{
					throw AuthenticationException.Create(0, "Failed validating access token: " + ex.Message, null);
				}
				this.CompleteSignIn(accessToken, sessionToken, true, null, null);
				return;
			}
			throw this.ExceptionHandler.BuildClientInvalidStateException(this.State);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000222C File Offset: 0x0000042C
		private void ValidateAccessToken(string accessToken)
		{
			if (string.IsNullOrEmpty(accessToken))
			{
				throw AuthenticationException.Create(51, "Empty or null access token.", null);
			}
			AccessToken accessToken2 = this.m_JwtDecoder.Decode<AccessToken>(accessToken);
			if (accessToken2 == null)
			{
				throw AuthenticationException.Create(51, "Failed to decode and verify access token.", null);
			}
			string text = accessToken2.Audience.FirstOrDefault((string s) => s.StartsWith("envName:"));
			string text2 = (text != null) ? text.Replace("envName:", "") : null;
			if (this.EnvironmentComponent.Current != text2)
			{
				throw AuthenticationException.Create(AuthenticationErrorCodes.EnvironmentMismatch, string.Concat(new string[]
				{
					"The configured environment(",
					this.EnvironmentComponent.Current,
					") and the access token one(",
					text2 ?? "null",
					") don't match."
				}), null);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002309 File Offset: 0x00000509
		private bool ValidateOpenIdConnectIdProviderName(string idProviderName)
		{
			return !string.IsNullOrEmpty(idProviderName) && Regex.Match(idProviderName, "^oidc-[a-z0-9-_\\.]{1,15}$").Success;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002325 File Offset: 0x00000525
		// (set) Token: 0x0600000D RID: 13 RVA: 0x0000232D File Offset: 0x0000052D
		internal string CodeLinkSessionId { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002336 File Offset: 0x00000536
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000233E File Offset: 0x0000053E
		internal string CodeVerifier { get; set; }

		// Token: 0x06000010 RID: 16 RVA: 0x00002348 File Offset: 0x00000548
		public Task<SignInCodeInfo> GenerateSignInCodeAsync(string identifier = null)
		{
			AuthenticationServiceInternal.<GenerateSignInCodeAsync>d__15 <GenerateSignInCodeAsync>d__;
			<GenerateSignInCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<SignInCodeInfo>.Create();
			<GenerateSignInCodeAsync>d__.<>4__this = this;
			<GenerateSignInCodeAsync>d__.identifier = identifier;
			<GenerateSignInCodeAsync>d__.<>1__state = -1;
			<GenerateSignInCodeAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<GenerateSignInCodeAsync>d__15>(ref <GenerateSignInCodeAsync>d__);
			return <GenerateSignInCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002394 File Offset: 0x00000594
		public Task SignInWithCodeAsync(bool usePolling = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			AuthenticationServiceInternal.<SignInWithCodeAsync>d__16 <SignInWithCodeAsync>d__;
			<SignInWithCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SignInWithCodeAsync>d__.<>4__this = this;
			<SignInWithCodeAsync>d__.usePolling = usePolling;
			<SignInWithCodeAsync>d__.cancellationToken = cancellationToken;
			<SignInWithCodeAsync>d__.<>1__state = -1;
			<SignInWithCodeAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<SignInWithCodeAsync>d__16>(ref <SignInWithCodeAsync>d__);
			return <SignInWithCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023E8 File Offset: 0x000005E8
		private Task<SignInResponse> PollForCodeConfirmationAsync(SignInWithCodeRequest request, CancellationToken cancellationToken)
		{
			AuthenticationServiceInternal.<PollForCodeConfirmationAsync>d__17 <PollForCodeConfirmationAsync>d__;
			<PollForCodeConfirmationAsync>d__.<>t__builder = AsyncTaskMethodBuilder<SignInResponse>.Create();
			<PollForCodeConfirmationAsync>d__.<>4__this = this;
			<PollForCodeConfirmationAsync>d__.request = request;
			<PollForCodeConfirmationAsync>d__.cancellationToken = cancellationToken;
			<PollForCodeConfirmationAsync>d__.<>1__state = -1;
			<PollForCodeConfirmationAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<PollForCodeConfirmationAsync>d__17>(ref <PollForCodeConfirmationAsync>d__);
			return <PollForCodeConfirmationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000243C File Offset: 0x0000063C
		private Task DelayWithScheduler(double delaySeconds)
		{
			TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
			this.m_Scheduler.ScheduleAction(delegate
			{
				tcs.SetResult(true);
			}, delaySeconds);
			return tcs.Task;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002480 File Offset: 0x00000680
		public Task<SignInCodeInfo> GetSignInCodeInfoAsync(string code)
		{
			AuthenticationServiceInternal.<GetSignInCodeInfoAsync>d__19 <GetSignInCodeInfoAsync>d__;
			<GetSignInCodeInfoAsync>d__.<>t__builder = AsyncTaskMethodBuilder<SignInCodeInfo>.Create();
			<GetSignInCodeInfoAsync>d__.<>4__this = this;
			<GetSignInCodeInfoAsync>d__.code = code;
			<GetSignInCodeInfoAsync>d__.<>1__state = -1;
			<GetSignInCodeInfoAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<GetSignInCodeInfoAsync>d__19>(ref <GetSignInCodeInfoAsync>d__);
			return <GetSignInCodeInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000024CC File Offset: 0x000006CC
		public Task ConfirmCodeAsync(string code, string idProvider = null, string externalToken = null)
		{
			AuthenticationServiceInternal.<ConfirmCodeAsync>d__20 <ConfirmCodeAsync>d__;
			<ConfirmCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ConfirmCodeAsync>d__.<>4__this = this;
			<ConfirmCodeAsync>d__.code = code;
			<ConfirmCodeAsync>d__.idProvider = idProvider;
			<ConfirmCodeAsync>d__.externalToken = externalToken;
			<ConfirmCodeAsync>d__.<>1__state = -1;
			<ConfirmCodeAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<ConfirmCodeAsync>d__20>(ref <ConfirmCodeAsync>d__);
			return <ConfirmCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000016 RID: 22 RVA: 0x00002528 File Offset: 0x00000728
		// (remove) Token: 0x06000017 RID: 23 RVA: 0x00002560 File Offset: 0x00000760
		public event Action<RequestFailedException> SignInFailed;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000018 RID: 24 RVA: 0x00002598 File Offset: 0x00000798
		// (remove) Token: 0x06000019 RID: 25 RVA: 0x000025D0 File Offset: 0x000007D0
		public event Action SignedIn;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600001A RID: 26 RVA: 0x00002608 File Offset: 0x00000808
		// (remove) Token: 0x0600001B RID: 27 RVA: 0x00002640 File Offset: 0x00000840
		public event Action SignedOut;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600001C RID: 28 RVA: 0x00002678 File Offset: 0x00000878
		// (remove) Token: 0x0600001D RID: 29 RVA: 0x000026B0 File Offset: 0x000008B0
		public event Action Expired;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600001E RID: 30 RVA: 0x000026E8 File Offset: 0x000008E8
		// (remove) Token: 0x0600001F RID: 31 RVA: 0x00002720 File Offset: 0x00000920
		public event Action<SignInCodeInfo> SignInCodeReceived;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000020 RID: 32 RVA: 0x00002758 File Offset: 0x00000958
		// (remove) Token: 0x06000021 RID: 33 RVA: 0x00002790 File Offset: 0x00000990
		public event Action SignInCodeExpired;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000022 RID: 34 RVA: 0x000027C8 File Offset: 0x000009C8
		// (remove) Token: 0x06000023 RID: 35 RVA: 0x00002800 File Offset: 0x00000A00
		public event Action<RequestFailedException> UpdatePasswordFailed;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002835 File Offset: 0x00000A35
		public bool IsSignedIn
		{
			get
			{
				return this.State == AuthenticationState.Authorized || this.State == AuthenticationState.Refreshing || this.State == AuthenticationState.Expired;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002854 File Offset: 0x00000A54
		public bool IsAuthorized
		{
			get
			{
				return this.State == AuthenticationState.Authorized || this.State == AuthenticationState.Refreshing;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000286A File Offset: 0x00000A6A
		public bool IsExpired
		{
			get
			{
				return this.State == AuthenticationState.Expired;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002875 File Offset: 0x00000A75
		public bool SessionTokenExists
		{
			get
			{
				return !string.IsNullOrEmpty(this.SessionTokenComponent.SessionToken);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000288A File Offset: 0x00000A8A
		public string Profile
		{
			get
			{
				return this.m_Profile.Current;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002897 File Offset: 0x00000A97
		public string AccessToken
		{
			get
			{
				return this.AccessTokenComponent.AccessToken;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000028A4 File Offset: 0x00000AA4
		public string PlayerId
		{
			get
			{
				return this.PlayerIdComponent.PlayerId;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000028B1 File Offset: 0x00000AB1
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000028B9 File Offset: 0x00000AB9
		public PlayerInfo PlayerInfo { get; internal set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000028C2 File Offset: 0x00000AC2
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000028CA File Offset: 0x00000ACA
		[CanBeNull]
		public string LastNotificationDate { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000028D3 File Offset: 0x00000AD3
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000028DB File Offset: 0x00000ADB
		internal long? ExpirationActionId { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000028E4 File Offset: 0x00000AE4
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000028EC File Offset: 0x00000AEC
		internal long? RefreshActionId { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000028F5 File Offset: 0x00000AF5
		internal AccessTokenComponent AccessTokenComponent { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000028FD File Offset: 0x00000AFD
		internal EnvironmentIdComponent EnvironmentIdComponent { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002905 File Offset: 0x00000B05
		internal PlayerIdComponent PlayerIdComponent { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000290D File Offset: 0x00000B0D
		internal PlayerNameComponent PlayerNameComponent { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002915 File Offset: 0x00000B15
		internal SessionTokenComponent SessionTokenComponent { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000291D File Offset: 0x00000B1D
		internal IEnvironments EnvironmentComponent { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002925 File Offset: 0x00000B25
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000292D File Offset: 0x00000B2D
		internal AuthenticationState State { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002936 File Offset: 0x00000B36
		internal IAuthenticationSettings Settings { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003C RID: 60 RVA: 0x0000293E File Offset: 0x00000B3E
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002946 File Offset: 0x00000B46
		internal IAuthenticationNetworkClient NetworkClient { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003E RID: 62 RVA: 0x0000294F File Offset: 0x00000B4F
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002957 File Offset: 0x00000B57
		internal IPlayerNamesApi PlayerNamesApi { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002960 File Offset: 0x00000B60
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002968 File Offset: 0x00000B68
		internal IAuthenticationExceptionHandler ExceptionHandler { get; set; }

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000042 RID: 66 RVA: 0x00002974 File Offset: 0x00000B74
		// (remove) Token: 0x06000043 RID: 67 RVA: 0x000029AC File Offset: 0x00000BAC
		internal event Action<AuthenticationState, AuthenticationState> StateChanged;

		// Token: 0x06000044 RID: 68 RVA: 0x000029E4 File Offset: 0x00000BE4
		internal AuthenticationServiceInternal(IAuthenticationSettings settings, IAuthenticationNetworkClient networkClient, IPlayerNamesApi playerNamesApi, IProfile profile, IJwtDecoder jwtDecoder, IAuthenticationCache cache, IActionScheduler scheduler, IAuthenticationMetrics metrics, AccessTokenComponent accessToken, EnvironmentIdComponent environmentId, PlayerIdComponent playerId, PlayerNameComponent playerName, SessionTokenComponent sessionToken, IEnvironments environment)
		{
			this.Settings = settings;
			this.NetworkClient = networkClient;
			this.PlayerNamesApi = playerNamesApi;
			this.m_Profile = profile;
			this.m_JwtDecoder = jwtDecoder;
			this.m_Cache = cache;
			this.m_Scheduler = scheduler;
			this.m_Metrics = metrics;
			this.ExceptionHandler = new AuthenticationExceptionHandler(this.m_Metrics);
			this.AccessTokenComponent = accessToken;
			this.EnvironmentIdComponent = environmentId;
			this.PlayerIdComponent = playerId;
			this.PlayerNameComponent = playerName;
			this.SessionTokenComponent = sessionToken;
			this.EnvironmentComponent = environment;
			this.State = AuthenticationState.SignedOut;
			this.MigrateCache();
			this.PlayerIdComponent.PlayerIdChanged += this.OnPlayerIdChanged;
			this.Expired += delegate()
			{
				this.m_Metrics.SendExpiredSessionMetric();
			};
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002AAB File Offset: 0x00000CAB
		private void OnPlayerIdChanged(string playerId)
		{
			this.PlayerNameComponent.Clear();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public Task SignInAnonymouslyAsync(SignInOptions options = null)
		{
			if (this.State != AuthenticationState.SignedOut && this.State != AuthenticationState.Expired)
			{
				RequestFailedException exception = this.ExceptionHandler.BuildClientInvalidStateException(this.State);
				this.SendSignInFailedEvent(exception, false);
				return Task.FromException(exception);
			}
			if (this.SessionTokenExists)
			{
				string sessionToken = this.SessionTokenComponent.SessionToken;
				if (string.IsNullOrEmpty(sessionToken))
				{
					this.SessionTokenComponent.Clear();
					RequestFailedException exception2 = this.ExceptionHandler.BuildClientSessionTokenNotExistsException();
					this.SendSignInFailedEvent(exception2, true);
					return Task.FromException(exception2);
				}
				return this.HandleSignInRequestAsync(() => this.NetworkClient.SignInWithSessionTokenAsync(sessionToken), true);
			}
			else
			{
				if (options == null || options.CreateAccount)
				{
					return this.HandleSignInRequestAsync(new Func<Task<SignInResponse>>(this.NetworkClient.SignInAnonymouslyAsync), true);
				}
				this.SessionTokenComponent.Clear();
				RequestFailedException exception3 = this.ExceptionHandler.BuildClientSessionTokenNotExistsException();
				this.SendSignInFailedEvent(exception3, true);
				return Task.FromException(exception3);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002BB4 File Offset: 0x00000DB4
		public Task DeleteAccountAsync()
		{
			AuthenticationServiceInternal.<DeleteAccountAsync>d__121 <DeleteAccountAsync>d__;
			<DeleteAccountAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DeleteAccountAsync>d__.<>4__this = this;
			<DeleteAccountAsync>d__.<>1__state = -1;
			<DeleteAccountAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<DeleteAccountAsync>d__121>(ref <DeleteAccountAsync>d__);
			return <DeleteAccountAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002BF8 File Offset: 0x00000DF8
		public void SignOut(bool clearCredentials = false)
		{
			this.AccessTokenComponent.Clear();
			this.PlayerInfo = null;
			this.m_Notifications = null;
			if (clearCredentials)
			{
				this.SessionTokenComponent.Clear();
				this.PlayerIdComponent.Clear();
				this.PlayerNameComponent.Clear();
			}
			this.CancelScheduledRefresh();
			this.CancelScheduledExpiration();
			this.ChangeState(AuthenticationState.SignedOut);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C58 File Offset: 0x00000E58
		public void SwitchProfile(string profile)
		{
			if (this.State != AuthenticationState.SignedOut)
			{
				throw this.ExceptionHandler.BuildClientInvalidStateException(this.State);
			}
			if (!string.IsNullOrEmpty(profile) && Regex.Match(profile, "^[a-zA-Z0-9_-]{1,30}$").Success)
			{
				this.m_Profile.Current = profile;
				this.PlayerIdComponent.Refresh();
				this.SessionTokenComponent.Refresh();
				this.PlayerNameComponent.Refresh();
				return;
			}
			throw this.ExceptionHandler.BuildClientInvalidProfileException();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002CD2 File Offset: 0x00000ED2
		public void ClearSessionToken()
		{
			if (this.State == AuthenticationState.SignedOut)
			{
				this.SessionTokenComponent.Clear();
				return;
			}
			throw this.ExceptionHandler.BuildClientInvalidStateException(this.State);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002CFC File Offset: 0x00000EFC
		public Task<PlayerInfo> GetPlayerInfoAsync()
		{
			AuthenticationServiceInternal.<GetPlayerInfoAsync>d__125 <GetPlayerInfoAsync>d__;
			<GetPlayerInfoAsync>d__.<>t__builder = AsyncTaskMethodBuilder<PlayerInfo>.Create();
			<GetPlayerInfoAsync>d__.<>4__this = this;
			<GetPlayerInfoAsync>d__.<>1__state = -1;
			<GetPlayerInfoAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<GetPlayerInfoAsync>d__125>(ref <GetPlayerInfoAsync>d__);
			return <GetPlayerInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D40 File Offset: 0x00000F40
		internal Task RefreshAccessTokenAsync()
		{
			if (!this.IsSignedIn)
			{
				return Task.CompletedTask;
			}
			if (this.State == AuthenticationState.Expired)
			{
				return Task.CompletedTask;
			}
			string sessionToken = this.SessionTokenComponent.SessionToken;
			if (string.IsNullOrEmpty(sessionToken))
			{
				return Task.CompletedTask;
			}
			return this.StartRefreshAsync(sessionToken);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D8C File Offset: 0x00000F8C
		internal Task HandleSignInRequestAsync(Func<Task<SignInResponse>> signInRequest, bool enableRefresh = true)
		{
			AuthenticationServiceInternal.<HandleSignInRequestAsync>d__127 <HandleSignInRequestAsync>d__;
			<HandleSignInRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<HandleSignInRequestAsync>d__.<>4__this = this;
			<HandleSignInRequestAsync>d__.signInRequest = signInRequest;
			<HandleSignInRequestAsync>d__.enableRefresh = enableRefresh;
			<HandleSignInRequestAsync>d__.<>1__state = -1;
			<HandleSignInRequestAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<HandleSignInRequestAsync>d__127>(ref <HandleSignInRequestAsync>d__);
			return <HandleSignInRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002DE0 File Offset: 0x00000FE0
		internal Task StartRefreshAsync(string sessionToken)
		{
			AuthenticationServiceInternal.<StartRefreshAsync>d__128 <StartRefreshAsync>d__;
			<StartRefreshAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StartRefreshAsync>d__.<>4__this = this;
			<StartRefreshAsync>d__.sessionToken = sessionToken;
			<StartRefreshAsync>d__.<>1__state = -1;
			<StartRefreshAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<StartRefreshAsync>d__128>(ref <StartRefreshAsync>d__);
			return <StartRefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002E2B File Offset: 0x0000102B
		internal void CompleteSignIn(SignInResponse response, bool enableRefresh = true)
		{
			this.CompleteSignIn(response.IdToken, response.SessionToken, enableRefresh, response.User, response.LastNotificationDate);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002E4C File Offset: 0x0000104C
		private void CompleteSignIn(string accessToken, string sessionToken, bool enableRefresh = true, User user = null, string lastNotificationDate = null)
		{
			try
			{
				AccessToken accessToken2 = this.m_JwtDecoder.Decode<AccessToken>(accessToken);
				if (accessToken2 == null)
				{
					throw AuthenticationException.Create(51, "Failed to decode and verify access token.", null);
				}
				this.AccessTokenComponent.AccessToken = accessToken;
				if (accessToken2.Audience != null)
				{
					EnvironmentIdComponent environmentIdComponent = this.EnvironmentIdComponent;
					string text = accessToken2.Audience.FirstOrDefault((string s) => s.StartsWith("envId:"));
					environmentIdComponent.EnvironmentId = ((text != null) ? text.Substring(6) : null);
				}
				this.PlayerInfo = ((user != null) ? new PlayerInfo(user) : new PlayerInfo(accessToken2.Subject));
				this.PlayerIdComponent.PlayerId = accessToken2.Subject;
				this.SessionTokenComponent.SessionToken = sessionToken;
				long num = accessToken2.Expiration - accessToken2.IssuedAt;
				long num2 = num - (long)this.Settings.AccessTokenRefreshBuffer;
				long num3 = num - (long)this.Settings.AccessTokenExpiryBuffer;
				if (enableRefresh && sessionToken != null && num2 > 0L && num2 < num3)
				{
					this.ScheduleRefresh((double)num2);
				}
				if (num3 > 0L)
				{
					this.ScheduleExpiration((double)num3);
				}
				this.LastNotificationDate = lastNotificationDate;
				this.ChangeState(AuthenticationState.Authorized);
			}
			catch (AuthenticationException)
			{
				throw;
			}
			catch (Exception innerException)
			{
				throw AuthenticationException.Create(0, "Unknown error completing sign-in.", innerException);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002FAC File Offset: 0x000011AC
		internal void ScheduleRefresh(double delay)
		{
			if (delay >= 0.0)
			{
				this.CancelScheduledRefresh();
				this.RefreshActionId = new long?(this.m_Scheduler.ScheduleAction(new Action(this.ExecuteScheduledRefresh), delay));
				this.AccessTokenComponent.RefreshTime = new DateTime?(DateTime.UtcNow.AddSeconds(delay));
				return;
			}
			Logger.LogError(string.Format("Schedule delay for refresh is invalid ({0}).", delay));
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003024 File Offset: 0x00001224
		internal void ScheduleExpiration(double delay)
		{
			if (delay >= 0.0)
			{
				this.CancelScheduledExpiration();
				this.ExpirationActionId = new long?(this.m_Scheduler.ScheduleAction(new Action(this.ExecuteScheduledExpiration), delay));
				this.AccessTokenComponent.ExpiryTime = new DateTime?(DateTime.UtcNow.AddSeconds(delay));
				return;
			}
			Logger.LogError(string.Format("Schedule delay for expiration is invalid ({0}).", delay));
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000309C File Offset: 0x0000129C
		internal void ExecuteScheduledRefresh()
		{
			this.RefreshActionId = null;
			this.AccessTokenComponent.RefreshTime = null;
			this.RefreshAccessTokenAsync();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000030D4 File Offset: 0x000012D4
		internal void ExecuteScheduledExpiration()
		{
			this.ExpirationActionId = null;
			this.AccessTokenComponent.ExpiryTime = null;
			this.Expire();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000310C File Offset: 0x0000130C
		internal void CancelScheduledRefresh()
		{
			if (this.RefreshActionId != null)
			{
				this.m_Scheduler.CancelAction(this.RefreshActionId.Value);
				this.RefreshActionId = null;
				this.AccessTokenComponent.RefreshTime = null;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003168 File Offset: 0x00001368
		internal void CancelScheduledExpiration()
		{
			if (this.ExpirationActionId != null)
			{
				this.m_Scheduler.CancelAction(this.ExpirationActionId.Value);
				this.ExpirationActionId = null;
				this.AccessTokenComponent.ExpiryTime = null;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000031C1 File Offset: 0x000013C1
		internal void Expire()
		{
			this.AccessTokenComponent.Clear();
			this.CancelScheduledRefresh();
			this.CancelScheduledExpiration();
			this.ChangeState(AuthenticationState.Expired);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000031E4 File Offset: 0x000013E4
		internal void MigrateCache()
		{
			try
			{
				this.SessionTokenComponent.Migrate();
			}
			catch (Exception exception)
			{
				Logger.LogException(exception);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003218 File Offset: 0x00001418
		private void ChangeState(AuthenticationState newState)
		{
			if (this.State == newState)
			{
				return;
			}
			AuthenticationState state = this.State;
			this.State = newState;
			this.HandleStateChanged(state, newState);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003248 File Offset: 0x00001448
		private void HandleStateChanged(AuthenticationState oldState, AuthenticationState newState)
		{
			Action<AuthenticationState, AuthenticationState> stateChanged = this.StateChanged;
			if (stateChanged != null)
			{
				stateChanged(oldState, newState);
			}
			switch (newState)
			{
			case AuthenticationState.SignedOut:
				if (oldState != AuthenticationState.SigningIn)
				{
					Action signedOut = this.SignedOut;
					if (signedOut == null)
					{
						return;
					}
					signedOut();
					return;
				}
				break;
			case AuthenticationState.SigningIn:
			case AuthenticationState.Refreshing:
				break;
			case AuthenticationState.Authorized:
				if (oldState != AuthenticationState.Refreshing)
				{
					Action signedIn = this.SignedIn;
					if (signedIn == null)
					{
						return;
					}
					signedIn();
					return;
				}
				break;
			case AuthenticationState.Expired:
			{
				Action expired = this.Expired;
				if (expired == null)
				{
					return;
				}
				expired();
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000032BD File Offset: 0x000014BD
		private void SendSignInFailedEvent(RequestFailedException exception, bool forceSignOut)
		{
			Action<RequestFailedException> signInFailed = this.SignInFailed;
			if (signInFailed != null)
			{
				signInFailed(exception);
			}
			if (forceSignOut)
			{
				this.SignOut(false);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000032DB File Offset: 0x000014DB
		public Task SignInWithAppleAsync(string idToken, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("apple.com", new SignInWithExternalTokenRequest
			{
				IdProvider = "apple.com",
				Token = idToken,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003315 File Offset: 0x00001515
		public Task LinkWithAppleAsync(string idToken, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("apple.com", new LinkWithExternalTokenRequest
			{
				IdProvider = "apple.com",
				Token = idToken,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000334B File Offset: 0x0000154B
		public Task UnlinkAppleAsync()
		{
			return this.UnlinkExternalTokenAsync("apple.com");
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003358 File Offset: 0x00001558
		public Task SignInWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("apple-game-center", new SignInWithAppleGameCenterRequest
			{
				IdProvider = "apple-game-center",
				Token = signature,
				AppleGameCenterConfig = new AppleGameCenterConfig
				{
					TeamPlayerId = teamPlayerId,
					PublicKeyURL = publicKeyURL,
					Salt = salt,
					Timestamp = timestamp
				},
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000033C8 File Offset: 0x000015C8
		public Task LinkWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("apple-game-center", new LinkWithAppleGameCenterRequest
			{
				IdProvider = "apple-game-center",
				Token = signature,
				AppleGameCenterConfig = new AppleGameCenterConfig
				{
					TeamPlayerId = teamPlayerId,
					PublicKeyURL = publicKeyURL,
					Salt = salt,
					Timestamp = timestamp
				},
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003434 File Offset: 0x00001634
		public Task UnlinkAppleGameCenterAsync()
		{
			return this.UnlinkExternalTokenAsync("apple-game-center");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003441 File Offset: 0x00001641
		public Task SignInWithFacebookAsync(string accessToken, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("facebook.com", new SignInWithExternalTokenRequest
			{
				IdProvider = "facebook.com",
				Token = accessToken,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000347B File Offset: 0x0000167B
		public Task LinkWithFacebookAsync(string accessToken, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("facebook.com", new LinkWithExternalTokenRequest
			{
				IdProvider = "facebook.com",
				Token = accessToken,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000034B1 File Offset: 0x000016B1
		public Task UnlinkFacebookAsync()
		{
			return this.UnlinkExternalTokenAsync("facebook.com");
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000034BE File Offset: 0x000016BE
		public Task SignInWithGoogleAsync(string idToken, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("google.com", new SignInWithExternalTokenRequest
			{
				IdProvider = "google.com",
				Token = idToken,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000034F8 File Offset: 0x000016F8
		public Task LinkWithGoogleAsync(string idToken, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("google.com", new LinkWithExternalTokenRequest
			{
				IdProvider = "google.com",
				Token = idToken,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000352E File Offset: 0x0000172E
		public Task UnlinkGoogleAsync()
		{
			return this.UnlinkExternalTokenAsync("google.com");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000353B File Offset: 0x0000173B
		public Task SignInWithGooglePlayGamesAsync(string authCode, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("google-play-games", new SignInWithExternalTokenRequest
			{
				IdProvider = "google-play-games",
				Token = authCode,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003575 File Offset: 0x00001775
		public Task LinkWithGooglePlayGamesAsync(string authCode, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("google-play-games", new LinkWithExternalTokenRequest
			{
				IdProvider = "google-play-games",
				Token = authCode,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000035AB File Offset: 0x000017AB
		public Task UnlinkGooglePlayGamesAsync()
		{
			return this.UnlinkExternalTokenAsync("google-play-games");
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000035B8 File Offset: 0x000017B8
		public Task SignInWithOculusAsync(string nonce, string userId, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("oculus", new SignInWithOculusRequest
			{
				IdProvider = "oculus",
				Token = nonce,
				OculusConfig = new OculusConfig
				{
					UserId = userId
				},
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003610 File Offset: 0x00001810
		public Task LinkWithOculusAsync(string nonce, string userId, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("oculus", new LinkWithOculusRequest
			{
				IdProvider = "oculus",
				Token = nonce,
				OculusConfig = new OculusConfig
				{
					UserId = userId
				},
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003663 File Offset: 0x00001863
		public Task UnlinkOculusAsync()
		{
			return this.UnlinkExternalTokenAsync("oculus");
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003670 File Offset: 0x00001870
		[Obsolete("This method is deprecated as of version 2.7.1. Please use the SignInWithSteamAsync method with the 'identity' parameter for better security.")]
		public Task SignInWithSteamAsync(string sessionTicket, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("steampowered.com", new SignInWithSteamRequest
			{
				IdProvider = "steampowered.com",
				Token = sessionTicket,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000036AA File Offset: 0x000018AA
		[Obsolete("This method is deprecated as of version 2.7.1. Please use the LinkWithSteamAsync method with the 'identity' parameter for better security.")]
		public Task LinkWithSteamAsync(string sessionTicket, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("steampowered.com", new LinkWithSteamRequest
			{
				IdProvider = "steampowered.com",
				Token = sessionTicket,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000036E0 File Offset: 0x000018E0
		public Task SignInWithSteamAsync(string sessionTicket, string identity, SignInOptions options = null)
		{
			this.ValidateSteamIdentity(identity);
			return this.SignInWithExternalTokenAsync("steampowered.com", new SignInWithSteamRequest
			{
				IdProvider = "steampowered.com",
				Token = sessionTicket,
				SteamConfig = new SteamConfig
				{
					identity = identity
				},
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003740 File Offset: 0x00001940
		public Task LinkWithSteamAsync(string sessionTicket, string identity, LinkOptions options = null)
		{
			this.ValidateSteamIdentity(identity);
			return this.LinkWithExternalTokenAsync("steampowered.com", new LinkWithSteamRequest
			{
				IdProvider = "steampowered.com",
				Token = sessionTicket,
				SteamConfig = new SteamConfig
				{
					identity = identity
				},
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000379C File Offset: 0x0000199C
		public Task SignInWithSteamAsync(string sessionTicket, string identity, string appId, SignInOptions options = null)
		{
			this.ValidateSteamIdentity(identity);
			return this.SignInWithExternalTokenAsync("steampowered.com", new SignInWithSteamRequest
			{
				IdProvider = "steampowered.com",
				Token = sessionTicket,
				SteamConfig = new SteamConfig
				{
					identity = identity,
					appId = appId
				},
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003804 File Offset: 0x00001A04
		public Task LinkWithSteamAsync(string sessionTicket, string identity, string appId, LinkOptions options = null)
		{
			this.ValidateSteamIdentity(identity);
			return this.LinkWithExternalTokenAsync("steampowered.com", new LinkWithSteamRequest
			{
				IdProvider = "steampowered.com",
				Token = sessionTicket,
				SteamConfig = new SteamConfig
				{
					identity = identity,
					appId = appId
				},
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003867 File Offset: 0x00001A67
		private void ValidateSteamIdentity(string identity)
		{
			if (string.IsNullOrEmpty(identity))
			{
				throw this.ExceptionHandler.BuildUnknownException("Identity cannot be null or empty.");
			}
			if (!Regex.IsMatch(identity, "^[a-zA-Z0-9]{5,30}$"))
			{
				throw this.ExceptionHandler.BuildUnknownException("The provided identity must only contain alphanumeric characters and be between 5 and 30 characters in length.");
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000038A0 File Offset: 0x00001AA0
		public Task UnlinkSteamAsync()
		{
			return this.UnlinkExternalTokenAsync("steampowered.com");
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000038AD File Offset: 0x00001AAD
		public Task SignInWithUnityAsync(string token, SignInOptions options = null)
		{
			return this.SignInWithExternalTokenAsync("unity", new SignInWithExternalTokenRequest
			{
				IdProvider = "unity",
				Token = token,
				SignInOnly = (options != null && !options.CreateAccount)
			}, true);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000038E7 File Offset: 0x00001AE7
		public Task LinkWithUnityAsync(string token, LinkOptions options = null)
		{
			return this.LinkWithExternalTokenAsync("unity", new LinkWithExternalTokenRequest
			{
				IdProvider = "unity",
				Token = token,
				ForceLink = (options != null && options.ForceLink)
			});
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000391D File Offset: 0x00001B1D
		public Task UnlinkUnityAsync()
		{
			return this.UnlinkExternalTokenAsync("unity");
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000392C File Offset: 0x00001B2C
		internal Task SignInWithExternalTokenAsync(string idProvider, SignInWithExternalTokenRequest request, bool enableRefresh = true)
		{
			if (this.State == AuthenticationState.SignedOut || this.State == AuthenticationState.Expired)
			{
				return this.HandleSignInRequestAsync(() => this.NetworkClient.SignInWithExternalTokenAsync(idProvider, request), enableRefresh);
			}
			RequestFailedException exception = this.ExceptionHandler.BuildClientInvalidStateException(this.State);
			this.SendSignInFailedEvent(exception, false);
			return Task.FromException(exception);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000399C File Offset: 0x00001B9C
		internal Task LinkWithExternalTokenAsync(string idProvider, LinkWithExternalTokenRequest request)
		{
			AuthenticationServiceInternal.<LinkWithExternalTokenAsync>d__173 <LinkWithExternalTokenAsync>d__;
			<LinkWithExternalTokenAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<LinkWithExternalTokenAsync>d__.<>4__this = this;
			<LinkWithExternalTokenAsync>d__.idProvider = idProvider;
			<LinkWithExternalTokenAsync>d__.request = request;
			<LinkWithExternalTokenAsync>d__.<>1__state = -1;
			<LinkWithExternalTokenAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<LinkWithExternalTokenAsync>d__173>(ref <LinkWithExternalTokenAsync>d__);
			return <LinkWithExternalTokenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000039F0 File Offset: 0x00001BF0
		internal Task UnlinkExternalTokenAsync(string idProvider)
		{
			AuthenticationServiceInternal.<UnlinkExternalTokenAsync>d__174 <UnlinkExternalTokenAsync>d__;
			<UnlinkExternalTokenAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<UnlinkExternalTokenAsync>d__.<>4__this = this;
			<UnlinkExternalTokenAsync>d__.idProvider = idProvider;
			<UnlinkExternalTokenAsync>d__.<>1__state = -1;
			<UnlinkExternalTokenAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<UnlinkExternalTokenAsync>d__174>(ref <UnlinkExternalTokenAsync>d__);
			return <UnlinkExternalTokenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003A3B File Offset: 0x00001C3B
		public List<Notification> Notifications
		{
			get
			{
				return this.m_Notifications;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003A44 File Offset: 0x00001C44
		public Task<List<Notification>> GetNotificationsAsync()
		{
			AuthenticationServiceInternal.<GetNotificationsAsync>d__178 <GetNotificationsAsync>d__;
			<GetNotificationsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<Notification>>.Create();
			<GetNotificationsAsync>d__.<>4__this = this;
			<GetNotificationsAsync>d__.<>1__state = -1;
			<GetNotificationsAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<GetNotificationsAsync>d__178>(ref <GetNotificationsAsync>d__);
			return <GetNotificationsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003A87 File Offset: 0x00001C87
		public string PlayerName
		{
			get
			{
				return this.PlayerNameComponent.PlayerName;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003A94 File Offset: 0x00001C94
		public Task<string> GetPlayerNameAsync(bool autoGenerate = true)
		{
			AuthenticationServiceInternal.<GetPlayerNameAsync>d__181 <GetPlayerNameAsync>d__;
			<GetPlayerNameAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetPlayerNameAsync>d__.<>4__this = this;
			<GetPlayerNameAsync>d__.autoGenerate = autoGenerate;
			<GetPlayerNameAsync>d__.<>1__state = -1;
			<GetPlayerNameAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<GetPlayerNameAsync>d__181>(ref <GetPlayerNameAsync>d__);
			return <GetPlayerNameAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003AE0 File Offset: 0x00001CE0
		public Task<string> UpdatePlayerNameAsync(string playerName)
		{
			AuthenticationServiceInternal.<UpdatePlayerNameAsync>d__182 <UpdatePlayerNameAsync>d__;
			<UpdatePlayerNameAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<UpdatePlayerNameAsync>d__.<>4__this = this;
			<UpdatePlayerNameAsync>d__.playerName = playerName;
			<UpdatePlayerNameAsync>d__.<>1__state = -1;
			<UpdatePlayerNameAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<UpdatePlayerNameAsync>d__182>(ref <UpdatePlayerNameAsync>d__);
			return <UpdatePlayerNameAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003B2B File Offset: 0x00001D2B
		public Task SignInWithUsernamePasswordAsync(string username, string password)
		{
			return this.SignInWithUsernamePasswordRequestAsync(this.BuildUsernamePasswordRequest(username, password), true);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003B3C File Offset: 0x00001D3C
		public Task SignUpWithUsernamePasswordAsync(string username, string password)
		{
			return this.SignUpWithUsernamePasswordRequestAsync(this.BuildUsernamePasswordRequest(username, password), true);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003B4D File Offset: 0x00001D4D
		public Task AddUsernamePasswordAsync(string username, string password)
		{
			return this.AddUsernamePasswordRequestAsync(this.BuildUsernamePasswordRequest(username, password));
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003B5D File Offset: 0x00001D5D
		public Task UpdatePasswordAsync(string currentPassword, string newPassword)
		{
			if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
			{
				throw this.ExceptionHandler.BuildInvalidCredentialsException();
			}
			return this.UpdatePasswordRequestAsync(new UpdatePasswordRequest
			{
				Password = currentPassword,
				NewPassword = newPassword
			}, true);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003B98 File Offset: 0x00001D98
		internal Task SignInWithUsernamePasswordRequestAsync(UsernamePasswordRequest request, bool enableRefresh = true)
		{
			if (this.State == AuthenticationState.SignedOut || this.State == AuthenticationState.Expired)
			{
				return this.HandleSignInRequestAsync(() => this.NetworkClient.SignInWithUsernamePasswordAsync(request), enableRefresh);
			}
			RequestFailedException exception = this.ExceptionHandler.BuildClientInvalidStateException(this.State);
			this.SendSignInFailedEvent(exception, false);
			return Task.FromException(exception);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003C00 File Offset: 0x00001E00
		internal Task SignUpWithUsernamePasswordRequestAsync(UsernamePasswordRequest request, bool enableRefresh = true)
		{
			if (this.State == AuthenticationState.SignedOut || this.State == AuthenticationState.Expired)
			{
				return this.HandleSignInRequestAsync(() => this.NetworkClient.SignUpWithUsernamePasswordAsync(request), enableRefresh);
			}
			RequestFailedException exception = this.ExceptionHandler.BuildClientInvalidStateException(this.State);
			this.SendSignInFailedEvent(exception, false);
			return Task.FromException(exception);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003C68 File Offset: 0x00001E68
		internal Task AddUsernamePasswordRequestAsync(UsernamePasswordRequest request)
		{
			AuthenticationServiceInternal.<AddUsernamePasswordRequestAsync>d__189 <AddUsernamePasswordRequestAsync>d__;
			<AddUsernamePasswordRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<AddUsernamePasswordRequestAsync>d__.<>4__this = this;
			<AddUsernamePasswordRequestAsync>d__.request = request;
			<AddUsernamePasswordRequestAsync>d__.<>1__state = -1;
			<AddUsernamePasswordRequestAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<AddUsernamePasswordRequestAsync>d__189>(ref <AddUsernamePasswordRequestAsync>d__);
			return <AddUsernamePasswordRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003CB4 File Offset: 0x00001EB4
		internal Task UpdatePasswordRequestAsync(UpdatePasswordRequest request, bool enableRefresh = true)
		{
			if (this.IsAuthorized)
			{
				return this.HandleUpdatePasswordRequestAsync(() => this.NetworkClient.UpdatePasswordAsync(request), enableRefresh);
			}
			return Task.FromException(this.ExceptionHandler.BuildClientInvalidStateException(this.State));
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003D08 File Offset: 0x00001F08
		internal Task HandleUpdatePasswordRequestAsync(Func<Task<SignInResponse>> updatePasswordRequest, bool enableRefresh = true)
		{
			AuthenticationServiceInternal.<HandleUpdatePasswordRequestAsync>d__191 <HandleUpdatePasswordRequestAsync>d__;
			<HandleUpdatePasswordRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<HandleUpdatePasswordRequestAsync>d__.<>4__this = this;
			<HandleUpdatePasswordRequestAsync>d__.updatePasswordRequest = updatePasswordRequest;
			<HandleUpdatePasswordRequestAsync>d__.enableRefresh = enableRefresh;
			<HandleUpdatePasswordRequestAsync>d__.<>1__state = -1;
			<HandleUpdatePasswordRequestAsync>d__.<>t__builder.Start<AuthenticationServiceInternal.<HandleUpdatePasswordRequestAsync>d__191>(ref <HandleUpdatePasswordRequestAsync>d__);
			return <HandleUpdatePasswordRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003D5B File Offset: 0x00001F5B
		private UsernamePasswordRequest BuildUsernamePasswordRequest(string username, string password)
		{
			if (!this.ValidateCredentials(username, password))
			{
				throw this.ExceptionHandler.BuildInvalidCredentialsException();
			}
			return new UsernamePasswordRequest
			{
				Username = username,
				Password = password
			};
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003D86 File Offset: 0x00001F86
		private void SendUpdatePasswordFailedEvent(RequestFailedException exception, bool forceSignOut)
		{
			Action<RequestFailedException> updatePasswordFailed = this.UpdatePasswordFailed;
			if (updatePasswordFailed != null)
			{
				updatePasswordFailed(exception);
			}
			if (forceSignOut)
			{
				this.SignOut(false);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003DA4 File Offset: 0x00001FA4
		private bool ValidateCredentials(string username, string password)
		{
			return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
		}

		// Token: 0x04000002 RID: 2
		private const string k_IdProviderNameRegex = "^oidc-[a-z0-9-_\\.]{1,15}$";

		// Token: 0x04000005 RID: 5
		private const string k_ProfileRegex = "^[a-zA-Z0-9_-]{1,30}$";

		// Token: 0x0400001C RID: 28
		private readonly IProfile m_Profile;

		// Token: 0x0400001D RID: 29
		private readonly IJwtDecoder m_JwtDecoder;

		// Token: 0x0400001E RID: 30
		private readonly IAuthenticationCache m_Cache;

		// Token: 0x0400001F RID: 31
		private readonly IActionScheduler m_Scheduler;

		// Token: 0x04000020 RID: 32
		private readonly IAuthenticationMetrics m_Metrics;

		// Token: 0x04000022 RID: 34
		private const string k_SteamIdentityRegex = "^[a-zA-Z0-9]{5,30}$";

		// Token: 0x04000023 RID: 35
		private List<Notification> m_Notifications;
	}
}
