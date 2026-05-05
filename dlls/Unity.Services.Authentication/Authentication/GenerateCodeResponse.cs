using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000033 RID: 51
	[Serializable]
	internal class GenerateCodeResponse
	{
		// Token: 0x06000174 RID: 372 RVA: 0x000050DB File Offset: 0x000032DB
		[Preserve]
		public GenerateCodeResponse()
		{
		}

		// Token: 0x04000095 RID: 149
		[JsonProperty("codeLinkSessionId")]
		public string CodeLinkSessionId;

		// Token: 0x04000096 RID: 150
		[JsonProperty("signInCode")]
		public string SignInCode;

		// Token: 0x04000097 RID: 151
		[JsonProperty("expiration")]
		public string Expiration;
	}
}
