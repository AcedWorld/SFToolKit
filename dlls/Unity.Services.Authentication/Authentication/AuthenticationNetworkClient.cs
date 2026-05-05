using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Environments.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x02000046 RID: 70
	internal class AuthenticationNetworkClient : IAuthenticationNetworkClient
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000056E4 File Offset: 0x000038E4
		internal AccessTokenComponent AccessTokenComponent { get; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000056EC File Offset: 0x000038EC
		internal ICloudProjectId CloudProjectIdComponent { get; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000056F4 File Offset: 0x000038F4
		internal IEnvironments EnvironmentComponent { get; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001BD RID: 445 RVA: 0x000056FC File Offset: 0x000038FC
		internal INetworkHandler NetworkHandler { get; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00005704 File Offset: 0x00003904
		private string AccessToken
		{
			get
			{
				return this.AccessTokenComponent.AccessToken;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00005711 File Offset: 0x00003911
		private string EnvironmentName
		{
			get
			{
				return this.EnvironmentComponent.Current;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00005720 File Offset: 0x00003920
		internal AuthenticationNetworkClient(string host, ICloudProjectId cloudProjectId, IEnvironments environment, INetworkHandler networkHandler, AccessTokenComponent accessToken)
		{
			this.AccessTokenComponent = accessToken;
			this.CloudProjectIdComponent = cloudProjectId;
			this.EnvironmentComponent = environment;
			this.NetworkHandler = networkHandler;
			this.m_AnonymousUrl = host + "/v1/authentication/anonymous";
			this.m_SessionTokenUrl = host + "/v1/authentication/session-token";
			this.m_ExternalTokenUrl = host + "/v1/authentication/external-token";
			this.m_LinkExternalTokenUrl = host + "/v1/authentication/link";
			this.m_UnlinkExternalTokenUrl = host + "/v1/authentication/unlink";
			this.m_UsersUrl = host + "/v1/users";
			this.m_UsernamePasswordSignInUrl = host + "/v1/authentication/usernamepassword/sign-in";
			this.m_UsernamePasswordSignUpUrl = host + "/v1/authentication/usernamepassword/sign-up";
			this.m_UpdatePasswordUrl = host + "/v1/authentication/usernamepassword/update-password";
			this.m_GenerateSignInCodeUrl = host + "/v1/authentication/code-link/generate";
			this.m_ConfirmSignInCodeUrl = host + "/v1/authentication/code-link/confirm";
			this.m_GetCodeIdentifierUrl = host + "/v1/authentication/code-link/info";
			this.m_CodeSignInUrl = host + "/v1/authentication/code-link/sign-in";
			this.m_GetNotificationsUrl = host + "/v1/users/{PlayerId}/notifications";
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["ProjectId"] = this.CloudProjectIdComponent.GetCloudProjectId();
			dictionary["Error-Version"] = "v1";
			this.m_CommonHeaders = dictionary;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00005870 File Offset: 0x00003A70
		public Task<SignInResponse> SignInAnonymouslyAsync()
		{
			return this.NetworkHandler.PostAsync<SignInResponse>(this.m_AnonymousUrl, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000588F File Offset: 0x00003A8F
		public Task<SignInResponse> SignInWithSessionTokenAsync(string token)
		{
			return this.NetworkHandler.PostAsync<SignInResponse>(this.m_SessionTokenUrl, new SessionTokenRequest
			{
				SessionToken = token
			}, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000058BC File Offset: 0x00003ABC
		public Task<SignInResponse> SignInWithExternalTokenAsync(string idProvider, SignInWithExternalTokenRequest externalToken)
		{
			string url = this.m_ExternalTokenUrl + "/" + idProvider;
			return this.NetworkHandler.PostAsync<SignInResponse>(url, externalToken, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000058F4 File Offset: 0x00003AF4
		public Task<LinkResponse> LinkWithExternalTokenAsync(string idProvider, LinkWithExternalTokenRequest externalToken)
		{
			string url = this.m_LinkExternalTokenUrl + "/" + idProvider;
			return this.NetworkHandler.PostAsync<LinkResponse>(url, externalToken, this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00005934 File Offset: 0x00003B34
		public Task<UnlinkResponse> UnlinkExternalTokenAsync(string idProvider, UnlinkRequest request)
		{
			string url = this.m_UnlinkExternalTokenUrl + "/" + idProvider;
			return this.NetworkHandler.PostAsync<UnlinkResponse>(url, request, this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00005972 File Offset: 0x00003B72
		public Task<PlayerInfoResponse> GetPlayerInfoAsync(string playerId)
		{
			return this.NetworkHandler.GetAsync<PlayerInfoResponse>(this.CreateUserRequestUrl(playerId), this.WithAccessToken(this.GetCommonHeaders()));
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00005992 File Offset: 0x00003B92
		public Task DeleteAccountAsync(string playerId)
		{
			return this.NetworkHandler.DeleteAsync(this.CreateUserRequestUrl(playerId), this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000059B8 File Offset: 0x00003BB8
		public Task<SignInResponse> SignInWithUsernamePasswordAsync(UsernamePasswordRequest credentials)
		{
			return this.NetworkHandler.PostAsync<SignInResponse>(this.m_UsernamePasswordSignInUrl, credentials, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000059D8 File Offset: 0x00003BD8
		public Task<SignInResponse> SignUpWithUsernamePasswordAsync(UsernamePasswordRequest credentials)
		{
			return this.NetworkHandler.PostAsync<SignInResponse>(this.m_UsernamePasswordSignUpUrl, credentials, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000059F8 File Offset: 0x00003BF8
		public Task<SignInResponse> AddUsernamePasswordAsync(UsernamePasswordRequest credentials)
		{
			return this.NetworkHandler.PostAsync<SignInResponse>(this.m_UsernamePasswordSignUpUrl, credentials, this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00005A1E File Offset: 0x00003C1E
		public Task<SignInResponse> UpdatePasswordAsync(UpdatePasswordRequest credentials)
		{
			return this.NetworkHandler.PostAsync<SignInResponse>(this.m_UpdatePasswordUrl, credentials, this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00005A44 File Offset: 0x00003C44
		public Task<GenerateCodeResponse> GenerateSignInCodeAsync(GenerateSignInCodeRequest request)
		{
			return this.NetworkHandler.PostAsync<GenerateCodeResponse>(this.m_GenerateSignInCodeUrl, request, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00005A64 File Offset: 0x00003C64
		public Task<CodeLinkConfirmResponse> ConfirmCodeAsync(ConfirmSignInCodeRequest request)
		{
			return this.NetworkHandler.PostAsync<CodeLinkConfirmResponse>(this.m_ConfirmSignInCodeUrl, request, this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00005A8C File Offset: 0x00003C8C
		public Task<SignInResponse> SignInWithCodeAsync(SignInWithCodeRequest request)
		{
			string url = this.m_CodeSignInUrl + "/" + request.CodeLinkSessionId;
			return this.NetworkHandler.PostAsync<SignInResponse>(url, request, this.WithEnvironment(this.GetCommonHeaders()));
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00005AC9 File Offset: 0x00003CC9
		public Task<CodeLinkInfoResponse> GetCodeIdentifierAsync(CodeLinkInfoRequest request)
		{
			return this.NetworkHandler.PostAsync<CodeLinkInfoResponse>(this.m_GetCodeIdentifierUrl, request, this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00005AEF File Offset: 0x00003CEF
		public Task<GetNotificationsResponse> GetNotificationsAsync(string playerId)
		{
			return this.NetworkHandler.GetAsync<GetNotificationsResponse>(this.m_GetNotificationsUrl.Replace("{PlayerId}", playerId), this.WithEnvironment(this.WithAccessToken(this.GetCommonHeaders())));
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00005B1F File Offset: 0x00003D1F
		private string CreateUserRequestUrl(string user)
		{
			return this.m_UsersUrl + "/" + user;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00005B32 File Offset: 0x00003D32
		private Dictionary<string, string> WithAccessToken(Dictionary<string, string> headers)
		{
			headers["Authorization"] = "Bearer " + this.AccessToken;
			return headers;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00005B50 File Offset: 0x00003D50
		private Dictionary<string, string> WithEnvironment(Dictionary<string, string> headers)
		{
			string environmentName = this.EnvironmentName;
			if (!string.IsNullOrEmpty(environmentName))
			{
				headers["UnityEnvironment"] = environmentName;
			}
			return headers;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00005B79 File Offset: 0x00003D79
		private Dictionary<string, string> GetCommonHeaders()
		{
			return new Dictionary<string, string>(this.m_CommonHeaders);
		}

		// Token: 0x040000D6 RID: 214
		private const string k_PlayerIdReplacement = "{PlayerId}";

		// Token: 0x040000D7 RID: 215
		private const string k_AnonymousUrlStem = "/v1/authentication/anonymous";

		// Token: 0x040000D8 RID: 216
		private const string k_SessionTokenUrlStem = "/v1/authentication/session-token";

		// Token: 0x040000D9 RID: 217
		private const string k_ExternalTokenUrlStem = "/v1/authentication/external-token";

		// Token: 0x040000DA RID: 218
		private const string k_LinkExternalTokenUrlStem = "/v1/authentication/link";

		// Token: 0x040000DB RID: 219
		private const string k_UnlinkExternalTokenUrlStem = "/v1/authentication/unlink";

		// Token: 0x040000DC RID: 220
		private const string k_UsersUrlStem = "/v1/users";

		// Token: 0x040000DD RID: 221
		private const string k_UsernamePasswordSignInUrlStem = "/v1/authentication/usernamepassword/sign-in";

		// Token: 0x040000DE RID: 222
		private const string k_UsernamePasswordSignUpUrlStem = "/v1/authentication/usernamepassword/sign-up";

		// Token: 0x040000DF RID: 223
		private const string k_UpdatePasswordUrlStem = "/v1/authentication/usernamepassword/update-password";

		// Token: 0x040000E0 RID: 224
		private const string k_GenerateSignInCodeUrlStem = "/v1/authentication/code-link/generate";

		// Token: 0x040000E1 RID: 225
		private const string k_ConfirmSignInCodeUrlStem = "/v1/authentication/code-link/confirm";

		// Token: 0x040000E2 RID: 226
		private const string k_GetCodeIdentifierUrlStem = "/v1/authentication/code-link/info";

		// Token: 0x040000E3 RID: 227
		private const string k_CodeSignInUrlStem = "/v1/authentication/code-link/sign-in";

		// Token: 0x040000E4 RID: 228
		private const string k_GetNotificationsStem = "/v1/users/{PlayerId}/notifications";

		// Token: 0x040000E9 RID: 233
		private readonly string m_AnonymousUrl;

		// Token: 0x040000EA RID: 234
		private readonly string m_SessionTokenUrl;

		// Token: 0x040000EB RID: 235
		private readonly string m_ExternalTokenUrl;

		// Token: 0x040000EC RID: 236
		private readonly string m_LinkExternalTokenUrl;

		// Token: 0x040000ED RID: 237
		private readonly string m_UnlinkExternalTokenUrl;

		// Token: 0x040000EE RID: 238
		private readonly string m_UsersUrl;

		// Token: 0x040000EF RID: 239
		private readonly string m_UsernamePasswordSignInUrl;

		// Token: 0x040000F0 RID: 240
		private readonly string m_UsernamePasswordSignUpUrl;

		// Token: 0x040000F1 RID: 241
		private readonly string m_UpdatePasswordUrl;

		// Token: 0x040000F2 RID: 242
		private readonly string m_GenerateSignInCodeUrl;

		// Token: 0x040000F3 RID: 243
		private readonly string m_ConfirmSignInCodeUrl;

		// Token: 0x040000F4 RID: 244
		private readonly string m_CodeSignInUrl;

		// Token: 0x040000F5 RID: 245
		private readonly string m_GetCodeIdentifierUrl;

		// Token: 0x040000F6 RID: 246
		private readonly string m_GetNotificationsUrl;

		// Token: 0x040000F7 RID: 247
		private readonly Dictionary<string, string> m_CommonHeaders;
	}
}
