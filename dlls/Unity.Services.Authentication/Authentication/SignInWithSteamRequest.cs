using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200002A RID: 42
	[Serializable]
	internal class SignInWithSteamRequest : SignInWithExternalTokenRequest
	{
		// Token: 0x0600016B RID: 363 RVA: 0x00005093 File Offset: 0x00003293
		[Preserve]
		internal SignInWithSteamRequest()
		{
		}

		// Token: 0x04000084 RID: 132
		[JsonProperty("steamConfig")]
		public SteamConfig SteamConfig;
	}
}
