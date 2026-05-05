using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	internal class SignInWithOculusRequest : SignInWithExternalTokenRequest
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00005073 File Offset: 0x00003273
		[Preserve]
		internal SignInWithOculusRequest()
		{
		}

		// Token: 0x0400007E RID: 126
		[JsonProperty("oculusConfig")]
		public OculusConfig OculusConfig;
	}
}
