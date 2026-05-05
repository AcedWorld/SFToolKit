using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	internal class AppleGameCenterConfig
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00005023 File Offset: 0x00003223
		[Preserve]
		internal AppleGameCenterConfig()
		{
		}

		// Token: 0x0400006A RID: 106
		[JsonProperty("teamPlayerId")]
		public string TeamPlayerId;

		// Token: 0x0400006B RID: 107
		[JsonProperty("publicKeyUrl")]
		public string PublicKeyURL;

		// Token: 0x0400006C RID: 108
		[JsonProperty("salt")]
		public string Salt;

		// Token: 0x0400006D RID: 109
		[JsonProperty("timestamp")]
		public ulong Timestamp;
	}
}
