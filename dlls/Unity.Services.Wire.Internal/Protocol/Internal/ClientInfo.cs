using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000004 RID: 4
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class ClientInfo
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		[Preserve]
		public ClientInfo()
		{
		}

		// Token: 0x0400000F RID: 15
		public string user;

		// Token: 0x04000010 RID: 16
		public string client;

		// Token: 0x04000011 RID: 17
		public byte[] conn_info;

		// Token: 0x04000012 RID: 18
		public byte[] chan_info;
	}
}
