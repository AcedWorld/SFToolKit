using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000012 RID: 18
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class UnsubscribeRequest
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000023C3 File Offset: 0x000005C3
		[Preserve]
		public UnsubscribeRequest()
		{
		}

		// Token: 0x04000044 RID: 68
		public string channel;
	}
}
