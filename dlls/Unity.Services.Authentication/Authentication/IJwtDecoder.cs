using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000055 RID: 85
	internal interface IJwtDecoder
	{
		// Token: 0x0600023F RID: 575
		T Decode<T>(string token) where T : BaseJwt;
	}
}
