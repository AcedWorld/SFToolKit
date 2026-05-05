using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000036 RID: 54
	[Serializable]
	internal class LinkResponse
	{
		// Token: 0x06000178 RID: 376 RVA: 0x000051C4 File Offset: 0x000033C4
		[Preserve]
		public LinkResponse()
		{
		}

		// Token: 0x040000A0 RID: 160
		[JsonProperty("user")]
		public User User;
	}
}
