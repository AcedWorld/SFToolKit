using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000011 RID: 17
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class Unsubscribe
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000023BB File Offset: 0x000005BB
		[Preserve]
		public Unsubscribe()
		{
		}

		// Token: 0x04000042 RID: 66
		public uint code;

		// Token: 0x04000043 RID: 67
		public string reason;
	}
}
