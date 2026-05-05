using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	internal class PlayerAccountsErrorResponse
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000230E File Offset: 0x0000050E
		[Preserve]
		public PlayerAccountsErrorResponse()
		{
		}

		// Token: 0x04000017 RID: 23
		[JsonProperty("error")]
		public string Error;

		// Token: 0x04000018 RID: 24
		[JsonProperty("error_description")]
		public string Description;
	}
}
