using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200003A RID: 58
	[Serializable]
	internal class User
	{
		// Token: 0x0600017C RID: 380 RVA: 0x000051E4 File Offset: 0x000033E4
		[Preserve]
		public User()
		{
		}

		// Token: 0x040000AD RID: 173
		[JsonProperty("id")]
		public string Id;

		// Token: 0x040000AE RID: 174
		[JsonProperty("createdAt")]
		public string CreatedAt;

		// Token: 0x040000AF RID: 175
		[JsonProperty("externalIds")]
		public List<ExternalIdentity> ExternalIds;

		// Token: 0x040000B0 RID: 176
		[JsonProperty("username")]
		[CanBeNull]
		public string Username;

		// Token: 0x040000B1 RID: 177
		[JsonProperty("UsernameInfo")]
		[CanBeNull]
		public UsernameInfo UsernameInfo;
	}
}
