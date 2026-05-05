using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200002D RID: 45
	[Serializable]
	internal class UpdatePasswordRequest
	{
		// Token: 0x0600016E RID: 366 RVA: 0x000050AB File Offset: 0x000032AB
		[Preserve]
		internal UpdatePasswordRequest()
		{
		}

		// Token: 0x04000089 RID: 137
		[JsonProperty("password")]
		public string Password;

		// Token: 0x0400008A RID: 138
		[JsonProperty("newPassword")]
		public string NewPassword;
	}
}
