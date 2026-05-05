using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	internal class LinkWithExternalTokenRequest
	{
		// Token: 0x06000164 RID: 356 RVA: 0x0000505B File Offset: 0x0000325B
		[Preserve]
		internal LinkWithExternalTokenRequest()
		{
		}

		// Token: 0x04000079 RID: 121
		[JsonProperty("idProvider")]
		public string IdProvider;

		// Token: 0x0400007A RID: 122
		[JsonProperty("token")]
		public string Token;

		// Token: 0x0400007B RID: 123
		[JsonProperty("forceLink")]
		public bool ForceLink;
	}
}
