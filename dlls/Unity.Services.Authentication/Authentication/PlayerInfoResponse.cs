using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000037 RID: 55
	[Serializable]
	internal class PlayerInfoResponse
	{
		// Token: 0x06000179 RID: 377 RVA: 0x000051CC File Offset: 0x000033CC
		[Preserve]
		public PlayerInfoResponse()
		{
		}

		// Token: 0x040000A1 RID: 161
		[JsonProperty("id")]
		public string Id;

		// Token: 0x040000A2 RID: 162
		[JsonProperty("createdAt")]
		public string CreatedAt;

		// Token: 0x040000A3 RID: 163
		[JsonProperty("externalIds")]
		public List<ExternalIdentity> ExternalIds;

		// Token: 0x040000A4 RID: 164
		[JsonProperty("username")]
		[CanBeNull]
		public string Username;

		// Token: 0x040000A5 RID: 165
		[JsonProperty("usernamepassword")]
		[CanBeNull]
		public UsernameInfo UsernamePassword;
	}
}
