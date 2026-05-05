using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	internal class SignInResponse
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002316 File Offset: 0x00000516
		[Preserve]
		public SignInResponse()
		{
		}

		// Token: 0x04000019 RID: 25
		[JsonProperty("passport")]
		public string PassportId;

		// Token: 0x0400001A RID: 26
		[JsonProperty("userId")]
		public string UserId;

		// Token: 0x0400001B RID: 27
		[JsonProperty("access_token")]
		public string AccessToken;

		// Token: 0x0400001C RID: 28
		[JsonProperty("id_token")]
		public string IdToken;

		// Token: 0x0400001D RID: 29
		[JsonProperty("token_type")]
		public string tokenType;

		// Token: 0x0400001E RID: 30
		[JsonProperty("expires_in")]
		public int ExpiresIn;

		// Token: 0x0400001F RID: 31
		[JsonProperty("refresh_token")]
		public string RefreshToken;
	}
}
