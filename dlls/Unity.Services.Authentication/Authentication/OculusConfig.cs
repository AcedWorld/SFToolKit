using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	internal class OculusConfig
	{
		// Token: 0x06000168 RID: 360 RVA: 0x0000507B File Offset: 0x0000327B
		[Preserve]
		internal OculusConfig()
		{
		}

		// Token: 0x0400007F RID: 127
		[JsonProperty("userId")]
		public string UserId;
	}
}
