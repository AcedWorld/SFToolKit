using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x0200000D RID: 13
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class Push
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002239 File Offset: 0x00000439
		[Preserve]
		public Push()
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002241 File Offset: 0x00000441
		internal string GetPushType()
		{
			if (this.IsPub())
			{
				return "PUB";
			}
			if (this.IsUnsub())
			{
				return "UNSUB";
			}
			return "UNKNOWN";
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002264 File Offset: 0x00000464
		internal bool IsUnsub()
		{
			return this.unsubscribe != null;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000226F File Offset: 0x0000046F
		internal bool IsPub()
		{
			return this.pub != null;
		}

		// Token: 0x04000029 RID: 41
		public string channel;

		// Token: 0x0400002A RID: 42
		public Publication pub;

		// Token: 0x0400002B RID: 43
		public Unsubscribe unsubscribe;
	}
}
