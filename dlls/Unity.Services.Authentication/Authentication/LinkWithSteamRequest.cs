using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000024 RID: 36
	internal class LinkWithSteamRequest : LinkWithExternalTokenRequest
	{
		// Token: 0x06000165 RID: 357 RVA: 0x00005063 File Offset: 0x00003263
		[Preserve]
		internal LinkWithSteamRequest()
		{
		}

		// Token: 0x0400007C RID: 124
		[JsonProperty("steamConfig")]
		public SteamConfig SteamConfig;
	}
}
