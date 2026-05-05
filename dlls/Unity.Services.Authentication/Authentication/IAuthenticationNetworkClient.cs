using System;
using System.Threading.Tasks;

namespace Unity.Services.Authentication
{
	// Token: 0x02000049 RID: 73
	internal interface IAuthenticationNetworkClient
	{
		// Token: 0x060001DF RID: 479
		Task<SignInResponse> SignInAnonymouslyAsync();

		// Token: 0x060001E0 RID: 480
		Task<SignInResponse> SignInWithSessionTokenAsync(string token);

		// Token: 0x060001E1 RID: 481
		Task<SignInResponse> SignInWithExternalTokenAsync(string idProvider, SignInWithExternalTokenRequest externalToken);

		// Token: 0x060001E2 RID: 482
		Task<LinkResponse> LinkWithExternalTokenAsync(string idProvider, LinkWithExternalTokenRequest externalToken);

		// Token: 0x060001E3 RID: 483
		Task<UnlinkResponse> UnlinkExternalTokenAsync(string idProvider, UnlinkRequest request);

		// Token: 0x060001E4 RID: 484
		Task<PlayerInfoResponse> GetPlayerInfoAsync(string playerId);

		// Token: 0x060001E5 RID: 485
		Task DeleteAccountAsync(string playerId);

		// Token: 0x060001E6 RID: 486
		Task<SignInResponse> SignInWithUsernamePasswordAsync(UsernamePasswordRequest credentials);

		// Token: 0x060001E7 RID: 487
		Task<SignInResponse> SignUpWithUsernamePasswordAsync(UsernamePasswordRequest credentials);

		// Token: 0x060001E8 RID: 488
		Task<SignInResponse> AddUsernamePasswordAsync(UsernamePasswordRequest credentials);

		// Token: 0x060001E9 RID: 489
		Task<SignInResponse> UpdatePasswordAsync(UpdatePasswordRequest credentials);

		// Token: 0x060001EA RID: 490
		Task<GenerateCodeResponse> GenerateSignInCodeAsync(GenerateSignInCodeRequest request);

		// Token: 0x060001EB RID: 491
		Task<CodeLinkConfirmResponse> ConfirmCodeAsync(ConfirmSignInCodeRequest request);

		// Token: 0x060001EC RID: 492
		Task<SignInResponse> SignInWithCodeAsync(SignInWithCodeRequest request);

		// Token: 0x060001ED RID: 493
		Task<CodeLinkInfoResponse> GetCodeIdentifierAsync(CodeLinkInfoRequest request);

		// Token: 0x060001EE RID: 494
		Task<GetNotificationsResponse> GetNotificationsAsync(string playerId);
	}
}
