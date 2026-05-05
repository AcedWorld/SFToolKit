using System;

namespace UnityEngine
{
	// Token: 0x020001BC RID: 444
	public struct TextureMipmapLimitSettings
	{
		// Token: 0x17000356 RID: 854
		// (get) Token: 0x0600100D RID: 4109 RVA: 0x00015CF3 File Offset: 0x00013EF3
		// (set) Token: 0x0600100E RID: 4110 RVA: 0x00015CFB File Offset: 0x00013EFB
		public TextureMipmapLimitBiasMode limitBiasMode { readonly get; set; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x0600100F RID: 4111 RVA: 0x00015D04 File Offset: 0x00013F04
		// (set) Token: 0x06001010 RID: 4112 RVA: 0x00015D0C File Offset: 0x00013F0C
		public int limitBias { readonly get; set; }
	}
}
