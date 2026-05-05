using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	internal class UsernamePasswordRequest
	{
		// Token: 0x0600016F RID: 367 RVA: 0x000050B3 File Offset: 0x000032B3
		[Preserve]
		internal UsernamePasswordRequest()
		{
		}

		// Token: 0x0400008B RID: 139
		[JsonProperty("username")]
		public string Username;

		// Token: 0x0400008C RID: 140
		[JsonProperty("password")]
		public string Password;
	}
}
