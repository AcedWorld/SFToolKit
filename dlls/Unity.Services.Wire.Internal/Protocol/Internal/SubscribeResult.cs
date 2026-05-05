using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000010 RID: 16
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class SubscribeResult
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000023A7 File Offset: 0x000005A7
		[Preserve]
		public SubscribeResult()
		{
			this.publications = new Publication[0];
		}

		// Token: 0x04000039 RID: 57
		public bool expires;

		// Token: 0x0400003A RID: 58
		public uint ttl;

		// Token: 0x0400003B RID: 59
		public bool recoverable;

		// Token: 0x0400003C RID: 60
		public string epoch;

		// Token: 0x0400003D RID: 61
		public bool recovered;

		// Token: 0x0400003E RID: 62
		public ulong offset;

		// Token: 0x0400003F RID: 63
		public bool positioned;

		// Token: 0x04000040 RID: 64
		public string data;

		// Token: 0x04000041 RID: 65
		public Publication[] publications;
	}
}
