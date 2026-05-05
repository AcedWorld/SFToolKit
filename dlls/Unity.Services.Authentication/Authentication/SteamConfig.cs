using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200002B RID: 43
	internal class SteamConfig
	{
		// Token: 0x0600016C RID: 364 RVA: 0x0000509B File Offset: 0x0000329B
		[Preserve]
		internal SteamConfig()
		{
		}

		// Token: 0x04000085 RID: 133
		[JsonProperty("identity")]
		public string identity;

		// Token: 0x04000086 RID: 134
		[JsonProperty("appId")]
		[CanBeNull]
		public string appId;
	}
}
