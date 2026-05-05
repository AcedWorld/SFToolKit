using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000009 RID: 9
	public class IdToken : BaseJwt
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000022C2 File Offset: 0x000004C2
		[Preserve]
		internal IdToken()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000022CA File Offset: 0x000004CA
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000022D2 File Offset: 0x000004D2
		[JsonProperty("email")]
		public string Email { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000022DB File Offset: 0x000004DB
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000022E3 File Offset: 0x000004E3
		[JsonProperty("email_verified")]
		public bool EmailVerified { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000022EC File Offset: 0x000004EC
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000022F4 File Offset: 0x000004F4
		[JsonProperty("is_private_email")]
		public bool IsPrivateEmail { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000022FD File Offset: 0x000004FD
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002305 File Offset: 0x00000505
		[JsonProperty("nonce")]
		public string Nonce { get; set; }

		// Token: 0x0400000F RID: 15
		[JsonProperty("aud")]
		public string[] Audience;

		// Token: 0x04000013 RID: 19
		[JsonProperty("iss")]
		public string Issuer;

		// Token: 0x04000014 RID: 20
		[JsonProperty("jti")]
		public string JwtId;

		// Token: 0x04000016 RID: 22
		[JsonProperty("sub")]
		public string Subject;
	}
}
