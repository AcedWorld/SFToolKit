using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000031 RID: 49
	[Serializable]
	internal class CodeLinkInfoResponse
	{
		// Token: 0x06000172 RID: 370 RVA: 0x000050CB File Offset: 0x000032CB
		[Preserve]
		public CodeLinkInfoResponse()
		{
		}

		// Token: 0x04000091 RID: 145
		[JsonProperty("identifier")]
		public string Identifier;

		// Token: 0x04000092 RID: 146
		[JsonProperty("expiration")]
		public string Expiration;
	}
}
