using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	internal class LinkWithOculusRequest : LinkWithExternalTokenRequest
	{
		// Token: 0x06000166 RID: 358 RVA: 0x0000506B File Offset: 0x0000326B
		[Preserve]
		internal LinkWithOculusRequest()
		{
		}

		// Token: 0x0400007D RID: 125
		[JsonProperty("oculusConfig")]
		public OculusConfig OculusConfig;
	}
}
