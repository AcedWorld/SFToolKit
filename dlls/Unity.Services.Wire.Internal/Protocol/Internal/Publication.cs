using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Services.Wire.Internal;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x0200000C RID: 12
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class Publication
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002231 File Offset: 0x00000431
		[Preserve]
		public Publication()
		{
		}

		// Token: 0x04000025 RID: 37
		public WireMessage data;

		// Token: 0x04000026 RID: 38
		public ClientInfo info;

		// Token: 0x04000027 RID: 39
		public ulong offset;

		// Token: 0x04000028 RID: 40
		public Dictionary<string, string> tags;
	}
}
