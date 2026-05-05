using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000017 RID: 23
	internal interface IJwtDecoder
	{
		// Token: 0x06000073 RID: 115
		T Decode<T>(string token) where T : BaseJwt;
	}
}
