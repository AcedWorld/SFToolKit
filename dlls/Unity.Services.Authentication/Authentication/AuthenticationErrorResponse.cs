using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200002F RID: 47
	[Serializable]
	internal class AuthenticationErrorResponse
	{
		// Token: 0x06000170 RID: 368 RVA: 0x000050BB File Offset: 0x000032BB
		[Preserve]
		public AuthenticationErrorResponse()
		{
		}

		// Token: 0x0400008D RID: 141
		[JsonProperty("title")]
		public string Title;

		// Token: 0x0400008E RID: 142
		[JsonProperty("detail")]
		public string Detail;

		// Token: 0x0400008F RID: 143
		[JsonProperty("status")]
		public int Status;

		// Token: 0x04000090 RID: 144
		[JsonProperty("details")]
		public List<object> Details;
	}
}
