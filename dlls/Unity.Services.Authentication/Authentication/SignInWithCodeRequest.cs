using System;
using Newtonsoft.Json;

namespace Unity.Services.Authentication
{
	// Token: 0x02000020 RID: 32
	[Serializable]
	internal class SignInWithCodeRequest
	{
		// Token: 0x04000075 RID: 117
		[JsonProperty("codeLinkSessionId")]
		public string CodeLinkSessionId;

		// Token: 0x04000076 RID: 118
		[JsonProperty("codeVerifier")]
		public string CodeVerifier;
	}
}
