using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000039 RID: 57
	[Serializable]
	internal class UnlinkResponse
	{
		// Token: 0x0600017B RID: 379 RVA: 0x000051DC File Offset: 0x000033DC
		[Preserve]
		public UnlinkResponse()
		{
		}

		// Token: 0x040000AC RID: 172
		[JsonProperty("user")]
		public User User;
	}
}
