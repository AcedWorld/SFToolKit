using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200002C RID: 44
	[Serializable]
	internal class UnlinkRequest
	{
		// Token: 0x0600016D RID: 365 RVA: 0x000050A3 File Offset: 0x000032A3
		[Preserve]
		internal UnlinkRequest()
		{
		}

		// Token: 0x04000087 RID: 135
		[JsonProperty("idProvider")]
		public string IdProvider;

		// Token: 0x04000088 RID: 136
		[JsonProperty("externalId")]
		public string ExternalId;
	}
}
