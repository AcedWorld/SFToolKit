using System;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004DA RID: 1242
	[Flags]
	public enum TextureCreationFlags
	{
		// Token: 0x0400102D RID: 4141
		None = 0,
		// Token: 0x0400102E RID: 4142
		MipChain = 1,
		// Token: 0x0400102F RID: 4143
		DontInitializePixels = 4,
		// Token: 0x04001030 RID: 4144
		Crunch = 64,
		// Token: 0x04001031 RID: 4145
		DontUploadUponCreate = 1024,
		// Token: 0x04001032 RID: 4146
		IgnoreMipmapLimit = 2048
	}
}
