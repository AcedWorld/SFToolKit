using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000007 RID: 7
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class ConnectRequest
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000021CE File Offset: 0x000003CE
		[Preserve]
		public ConnectRequest()
		{
			this.subs = new Dictionary<string, SubscribeRequest>();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021E1 File Offset: 0x000003E1
		public ConnectRequest(string token) : this()
		{
			this.token = token;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000021F0 File Offset: 0x000003F0
		public ConnectRequest(string token, Dictionary<string, SubscribeRequest> subscriptionRequests)
		{
			this.subs = subscriptionRequests;
			this.token = token;
		}

		// Token: 0x04000019 RID: 25
		public string token;

		// Token: 0x0400001A RID: 26
		public Dictionary<string, SubscribeRequest> subs;
	}
}
