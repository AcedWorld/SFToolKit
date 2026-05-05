using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200001B RID: 27
	internal struct PackageVersion
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000213F File Offset: 0x0000033F
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002147 File Offset: 0x00000347
		public int Major { readonly get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002150 File Offset: 0x00000350
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002158 File Offset: 0x00000358
		public int Minor { readonly get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002161 File Offset: 0x00000361
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002169 File Offset: 0x00000369
		public int Patch { readonly get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002172 File Offset: 0x00000372
		// (set) Token: 0x0600002B RID: 43 RVA: 0x0000217A File Offset: 0x0000037A
		public string PreRelease { readonly get; set; }
	}
}
