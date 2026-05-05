using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000008 RID: 8
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class ConnectResult
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002206 File Offset: 0x00000406
		[Preserve]
		public ConnectResult()
		{
			this.subs = new Dictionary<string, SubscribeResult>();
		}

		// Token: 0x0400001B RID: 27
		public string client;

		// Token: 0x0400001C RID: 28
		public string version;

		// Token: 0x0400001D RID: 29
		public bool expires;

		// Token: 0x0400001E RID: 30
		public uint ttl;

		// Token: 0x0400001F RID: 31
		public string data;

		// Token: 0x04000020 RID: 32
		public uint ping;

		// Token: 0x04000021 RID: 33
		public bool pong;

		// Token: 0x04000022 RID: 34
		public Dictionary<string, SubscribeResult> subs;
	}
}
