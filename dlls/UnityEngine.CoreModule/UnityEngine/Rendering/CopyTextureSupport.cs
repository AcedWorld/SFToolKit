using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200041A RID: 1050
	[Flags]
	public enum CopyTextureSupport
	{
		// Token: 0x04000CC3 RID: 3267
		None = 0,
		// Token: 0x04000CC4 RID: 3268
		Basic = 1,
		// Token: 0x04000CC5 RID: 3269
		Copy3D = 2,
		// Token: 0x04000CC6 RID: 3270
		DifferentTypes = 4,
		// Token: 0x04000CC7 RID: 3271
		TextureToRT = 8,
		// Token: 0x04000CC8 RID: 3272
		RTToTexture = 16
	}
}
