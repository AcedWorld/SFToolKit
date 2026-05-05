using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.Services.Core;

namespace Unity.Services.Authentication
{
	// Token: 0x0200000D RID: 13
	public interface IAuthenticationService
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000B8 RID: 184
		// (remove) Token: 0x060000B9 RID: 185
		event Action SignedIn;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000BA RID: 186
		// (remove) Token: 0x060000BB RID: 187
		event Action SignedOut;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000BC RID: 188
		// (remove) Token: 0x060000BD RID: 189
		event Action Expired;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000BE RID: 190
		// (remove) Token: 0x060000BF RID: 191
		event Action<SignInCodeInfo> SignInCodeReceived;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000C0 RID: 192
		// (remove) Token: 0x060000C1 RID: 193
		event Action SignInCodeExpired;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000C2 RID: 194
		// (remove) Token: 0x060000C3 RID: 195
		event Action<RequestFailedException> SignInFailed;

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000C4 RID: 196
		bool IsSignedIn { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000C5 RID: 197
		bool IsAuthorized { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C6 RID: 198
		bool IsExpired { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000C7 RID: 199
		string AccessToken { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C8 RID: 200
		string PlayerId { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C9 RID: 201
		string PlayerName { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000CA RID: 202
		string Profile { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000CB RID: 203
		bool SessionTokenExists { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000CC RID: 204
		string LastNotificationDate { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000CD RID: 205
		PlayerInfo PlayerInfo { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000CE RID: 206
		List<Notification> Notifications { get; }

		// Token: 0x060000CF RID: 207
		Task SignInAnonymouslyAsync(SignInOptions options = null);

		// Token: 0x060000D0 RID: 208
		Task SignInWithAppleAsync(string idToken, SignInOptions options = null);

		// Token: 0x060000D1 RID: 209
		Task LinkWithAppleAsync(string idToken, LinkOptions options = null);

		// Token: 0x060000D2 RID: 210
		Task UnlinkAppleAsync();

		// Token: 0x060000D3 RID: 211
		Task SignInWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, SignInOptions options = null);

		// Token: 0x060000D4 RID: 212
		Task LinkWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, LinkOptions options = null);

		// Token: 0x060000D5 RID: 213
		Task UnlinkAppleGameCenterAsync();

		// Token: 0x060000D6 RID: 214
		Task SignInWithGoogleAsync(string idToken, SignInOptions options = null);

		// Token: 0x060000D7 RID: 215
		Task LinkWithGoogleAsync(string idToken, LinkOptions options = null);

		// Token: 0x060000D8 RID: 216
		Task UnlinkGoogleAsync();

		// Token: 0x060000D9 RID: 217
		Task SignInWithGooglePlayGamesAsync(string authCode, SignInOptions options = null);

		// Token: 0x060000DA RID: 218
		Task LinkWithGooglePlayGamesAsync(string authCode, LinkOptions options = null);

		// Token: 0x060000DB RID: 219
		Task UnlinkGooglePlayGamesAsync();

		// Token: 0x060000DC RID: 220
		Task SignInWithFacebookAsync(string accessToken, SignInOptions options = null);

		// Token: 0x060000DD RID: 221
		Task LinkWithFacebookAsync(string accessToken, LinkOptions options = null);

		// Token: 0x060000DE RID: 222
		Task UnlinkFacebookAsync();

		// Token: 0x060000DF RID: 223
		Task SignInWithSteamAsync(string sessionTicket, string identity, SignInOptions options = null);

		// Token: 0x060000E0 RID: 224
		[Obsolete("This method is deprecated as of version 2.7.1. Please use the SignInWithSteamAsync method with the 'identity' parameter for better security.")]
		Task SignInWithSteamAsync(string sessionTicket, SignInOptions options = null);

		// Token: 0x060000E1 RID: 225
		Task LinkWithSteamAsync(string sessionTicket, string identity, LinkOptions options = null);

		// Token: 0x060000E2 RID: 226
		[Obsolete("This method is deprecated as of version 2.7.1. Please use the LinkWithSteamAsync method with the 'identity' parameter for better security.")]
		Task LinkWithSteamAsync(string sessionTicket, LinkOptions options = null);

		// Token: 0x060000E3 RID: 227
		Task SignInWithSteamAsync(string sessionTicket, string identity, string appId, SignInOptions options = null);

		// Token: 0x060000E4 RID: 228
		Task LinkWithSteamAsync(string sessionTicket, string identity, string appId, LinkOptions options = null);

		// Token: 0x060000E5 RID: 229
		Task UnlinkSteamAsync();

		// Token: 0x060000E6 RID: 230
		Task SignInWithOculusAsync(string nonce, string userId, SignInOptions options = null);

		// Token: 0x060000E7 RID: 231
		Task LinkWithOculusAsync(string nonce, string userId, LinkOptions options = null);

		// Token: 0x060000E8 RID: 232
		Task UnlinkOculusAsync();

		// Token: 0x060000E9 RID: 233
		Task SignInWithOpenIdConnectAsync(string idProviderName, string idToken, SignInOptions options = null);

		// Token: 0x060000EA RID: 234
		Task LinkWithOpenIdConnectAsync(string idProviderName, string idToken, LinkOptions options = null);

		// Token: 0x060000EB RID: 235
		Task UnlinkOpenIdConnectAsync(string idProviderName);

		// Token: 0x060000EC RID: 236
		Task SignInWithUnityAsync(string token, SignInOptions options = null);

		// Token: 0x060000ED RID: 237
		Task LinkWithUnityAsync(string token, LinkOptions options = null);

		// Token: 0x060000EE RID: 238
		Task UnlinkUnityAsync();

		// Token: 0x060000EF RID: 239
		Task SignInWithUsernamePasswordAsync(string username, string password);

		// Token: 0x060000F0 RID: 240
		Task SignUpWithUsernamePasswordAsync(string username, string password);

		// Token: 0x060000F1 RID: 241
		Task AddUsernamePasswordAsync(string username, string password);

		// Token: 0x060000F2 RID: 242
		Task UpdatePasswordAsync(string currentPassword, string newPassword);

		// Token: 0x060000F3 RID: 243
		Task DeleteAccountAsync();

		// Token: 0x060000F4 RID: 244
		Task<PlayerInfo> GetPlayerInfoAsync();

		// Token: 0x060000F5 RID: 245
		Task<string> GetPlayerNameAsync(bool autoGenerate = true);

		// Token: 0x060000F6 RID: 246
		Task<string> UpdatePlayerNameAsync(string name);

		// Token: 0x060000F7 RID: 247
		Task<SignInCodeInfo> GenerateSignInCodeAsync(string identifier = null);

		// Token: 0x060000F8 RID: 248
		Task SignInWithCodeAsync(bool usePolling = false, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060000F9 RID: 249
		Task<SignInCodeInfo> GetSignInCodeInfoAsync(string code);

		// Token: 0x060000FA RID: 250
		Task ConfirmCodeAsync(string code, string idProvider = null, string externalToken = null);

		// Token: 0x060000FB RID: 251
		void ProcessAuthenticationTokens(string accessToken, string sessionToken = null);

		// Token: 0x060000FC RID: 252
		void SignOut(bool clearCredentials = false);

		// Token: 0x060000FD RID: 253
		void SwitchProfile(string profile);

		// Token: 0x060000FE RID: 254
		void ClearSessionToken();

		// Token: 0x060000FF RID: 255
		Task<List<Notification>> GetNotificationsAsync();
	}
}
