using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000029 RID: 41
	[Serializable]
	internal class SignInWithExternalTokenRequest
	{
		// Token: 0x0600016A RID: 362 RVA: 0x0000508B File Offset: 0x0000328B
		[Preserve]
		internal SignInWithExternalTokenRequest()
		{
		}

		// Token: 0x04000081 RID: 129
		[JsonProperty("idProvider")]
		public string IdProvider;

		// Token: 0x04000082 RID: 130
		[JsonProperty("token")]
		public string Token;

		// Token: 0x04000083 RID: 131
		[JsonProperty("signInOnly")]
		public bool SignInOnly;
	}
}
