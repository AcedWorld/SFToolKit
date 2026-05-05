using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000028 RID: 40
	[Serializable]
	internal class SessionTokenRequest
	{
		// Token: 0x06000169 RID: 361 RVA: 0x00005083 File Offset: 0x00003283
		[Preserve]
		public SessionTokenRequest()
		{
		}

		// Token: 0x04000080 RID: 128
		[JsonProperty("sessionToken")]
		public string SessionToken;
	}
}
