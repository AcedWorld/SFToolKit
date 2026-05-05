using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000032 RID: 50
	[Serializable]
	internal class ExternalIdentity
	{
		// Token: 0x06000173 RID: 371 RVA: 0x000050D3 File Offset: 0x000032D3
		[Preserve]
		public ExternalIdentity()
		{
		}

		// Token: 0x04000093 RID: 147
		[JsonProperty("providerId")]
		public string ProviderId;

		// Token: 0x04000094 RID: 148
		[JsonProperty("externalId")]
		public string ExternalId;
	}
}
