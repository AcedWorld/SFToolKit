using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200003B RID: 59
	internal class UsernameInfo
	{
		// Token: 0x0600017D RID: 381 RVA: 0x000051EC File Offset: 0x000033EC
		[Preserve]
		public UsernameInfo()
		{
		}

		// Token: 0x040000B2 RID: 178
		[JsonProperty("username")]
		public string Username;

		// Token: 0x040000B3 RID: 179
		[JsonProperty("createdAt")]
		public string CreatedAt;

		// Token: 0x040000B4 RID: 180
		[JsonProperty("lastLoginAt")]
		public string LastLoginAt;

		// Token: 0x040000B5 RID: 181
		[JsonProperty("passwordUpdatedAt")]
		public string PasswordUpdatedAt;
	}
}
