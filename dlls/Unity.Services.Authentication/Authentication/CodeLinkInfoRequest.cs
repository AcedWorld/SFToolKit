using System;
using Newtonsoft.Json;

namespace Unity.Services.Authentication
{
	// Token: 0x0200001D RID: 29
	[Serializable]
	internal class CodeLinkInfoRequest
	{
		// Token: 0x0400006E RID: 110
		[JsonProperty("signInCode")]
		public string SignInCode;
	}
}
