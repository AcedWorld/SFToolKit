using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200003C RID: 60
	internal class AccessToken : BaseJwt
	{
		// Token: 0x0600017E RID: 382 RVA: 0x000051F4 File Offset: 0x000033F4
		[Preserve]
		public AccessToken()
		{
		}

		// Token: 0x040000B6 RID: 182
		[JsonProperty("aud")]
		public string[] Audience;

		// Token: 0x040000B7 RID: 183
		[JsonProperty("client_id")]
		public string ClientId;

		// Token: 0x040000B8 RID: 184
		[JsonProperty("ext")]
		public AccessTokenExtraClaims Extra;

		// Token: 0x040000B9 RID: 185
		[JsonProperty("iat")]
		public long IssuedAt;

		// Token: 0x040000BA RID: 186
		[JsonProperty("iss")]
		public string Issuer;

		// Token: 0x040000BB RID: 187
		[JsonProperty("jti")]
		public string JwtId;

		// Token: 0x040000BC RID: 188
		[JsonProperty("project_id")]
		public string ProjectId;

		// Token: 0x040000BD RID: 189
		[JsonProperty("scp")]
		public string[] Scope;

		// Token: 0x040000BE RID: 190
		[JsonProperty("sub")]
		public string Subject;

		// Token: 0x040000BF RID: 191
		[JsonProperty("sign_in_provider")]
		public string SignInProvider;

		// Token: 0x040000C0 RID: 192
		[JsonProperty("exp")]
		public long Expiration;
	}
}
