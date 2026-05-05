using System;
using Newtonsoft.Json;

namespace Unity.Services.Authentication
{
	// Token: 0x0200001E RID: 30
	[Serializable]
	internal class ConfirmSignInCodeRequest
	{
		// Token: 0x0400006F RID: 111
		[JsonProperty("signInCode")]
		public string SignInCode;

		// Token: 0x04000070 RID: 112
		[JsonProperty("idProvider")]
		public string IdProvider;

		// Token: 0x04000071 RID: 113
		[JsonProperty("externalToken")]
		public string ExternalToken;

		// Token: 0x04000072 RID: 114
		[JsonProperty("sessionToken")]
		public string SessionToken;
	}
}
