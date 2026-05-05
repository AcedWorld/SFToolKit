using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000021 RID: 33
	[Serializable]
	internal class LinkWithAppleGameCenterRequest : LinkWithExternalTokenRequest
	{
		// Token: 0x06000162 RID: 354 RVA: 0x0000504B File Offset: 0x0000324B
		[Preserve]
		internal LinkWithAppleGameCenterRequest()
		{
		}

		// Token: 0x04000077 RID: 119
		[JsonProperty("appleGameCenterConfig")]
		public AppleGameCenterConfig AppleGameCenterConfig;
	}
}
