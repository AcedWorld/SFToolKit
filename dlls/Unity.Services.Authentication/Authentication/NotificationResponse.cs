using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000035 RID: 53
	[Serializable]
	internal class NotificationResponse
	{
		// Token: 0x06000177 RID: 375 RVA: 0x000051BC File Offset: 0x000033BC
		[Preserve]
		public NotificationResponse()
		{
		}

		// Token: 0x04000099 RID: 153
		[JsonProperty("id")]
		public string Id;

		// Token: 0x0400009A RID: 154
		[JsonProperty("caseID")]
		public string CaseId;

		// Token: 0x0400009B RID: 155
		[JsonProperty("message")]
		public string Message;

		// Token: 0x0400009C RID: 156
		[JsonProperty("playerId")]
		public string PlayerId;

		// Token: 0x0400009D RID: 157
		[JsonProperty("projectId")]
		public string ProjectId;

		// Token: 0x0400009E RID: 158
		[JsonProperty("type")]
		public string Type;

		// Token: 0x0400009F RID: 159
		[JsonProperty("createdAt")]
		public string CreatedAt;
	}
}
