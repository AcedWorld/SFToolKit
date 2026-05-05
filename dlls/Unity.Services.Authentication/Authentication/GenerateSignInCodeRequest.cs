using System;
using Newtonsoft.Json;

namespace Unity.Services.Authentication
{
	// Token: 0x0200001F RID: 31
	[Serializable]
	internal class GenerateSignInCodeRequest
	{
		// Token: 0x04000073 RID: 115
		[JsonProperty("identifier")]
		public string Identifier;

		// Token: 0x04000074 RID: 116
		[JsonProperty("codeChallenge")]
		public string CodeChallenge;
	}
}
