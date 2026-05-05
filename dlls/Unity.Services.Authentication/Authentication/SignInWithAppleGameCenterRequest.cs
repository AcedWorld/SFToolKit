using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000022 RID: 34
	[Serializable]
	internal class SignInWithAppleGameCenterRequest : SignInWithExternalTokenRequest
	{
		// Token: 0x06000163 RID: 355 RVA: 0x00005053 File Offset: 0x00003253
		[Preserve]
		internal SignInWithAppleGameCenterRequest()
		{
		}

		// Token: 0x04000078 RID: 120
		[JsonProperty("appleGameCenterConfig")]
		public AppleGameCenterConfig AppleGameCenterConfig;
	}
}
