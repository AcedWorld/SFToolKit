using System;
using Unity.Services.Authentication.Shared;
using Unity.Services.Core;

namespace Unity.Services.Authentication
{
	// Token: 0x0200000C RID: 12
	internal interface IAuthenticationExceptionHandler
	{
		// Token: 0x060000AE RID: 174
		RequestFailedException BuildClientInvalidStateException(AuthenticationState state);

		// Token: 0x060000AF RID: 175
		RequestFailedException BuildClientInvalidProfileException();

		// Token: 0x060000B0 RID: 176
		RequestFailedException BuildClientUnlinkExternalIdNotFoundException();

		// Token: 0x060000B1 RID: 177
		RequestFailedException BuildClientSessionTokenNotExistsException();

		// Token: 0x060000B2 RID: 178
		RequestFailedException BuildUnknownException(string error);

		// Token: 0x060000B3 RID: 179
		RequestFailedException BuildInvalidIdProviderNameException();

		// Token: 0x060000B4 RID: 180
		RequestFailedException BuildInvalidPlayerNameException();

		// Token: 0x060000B5 RID: 181
		RequestFailedException BuildInvalidCredentialsException();

		// Token: 0x060000B6 RID: 182
		RequestFailedException ConvertException(WebRequestException exception);

		// Token: 0x060000B7 RID: 183
		RequestFailedException ConvertException(ApiException exception);
	}
}
