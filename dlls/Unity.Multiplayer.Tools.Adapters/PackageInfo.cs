using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200001A RID: 26
	internal struct PackageInfo
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000211D File Offset: 0x0000031D
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002125 File Offset: 0x00000325
		public string PackageName { readonly get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000212E File Offset: 0x0000032E
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002136 File Offset: 0x00000336
		public PackageVersion Version { readonly get; set; }
	}
}
