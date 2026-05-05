using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000038 RID: 56
	[Serializable]
	internal class SignInResponse
	{
		// Token: 0x0600017A RID: 378 RVA: 0x000051D4 File Offset: 0x000033D4
		[Preserve]
		public SignInResponse()
		{
		}

		// Token: 0x040000A6 RID: 166
		[JsonProperty("userId")]
		public string UserId;

		// Token: 0x040000A7 RID: 167
		[JsonProperty("idToken")]
		public string IdToken;

		// Token: 0x040000A8 RID: 168
		[JsonProperty("sessionToken")]
		public string SessionToken;

		// Token: 0x040000A9 RID: 169
		[JsonProperty("expiresIn")]
		public int ExpiresIn;

		// Token: 0x040000AA RID: 170
		[JsonProperty("user")]
		public User User;

		// Token: 0x040000AB RID: 171
		[JsonProperty("lastNotificationDate")]
		[CanBeNull]
		public string LastNotificationDate;
	}
}
