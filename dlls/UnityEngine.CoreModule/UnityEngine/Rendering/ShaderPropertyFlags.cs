using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000489 RID: 1161
	[Flags]
	public enum ShaderPropertyFlags
	{
		// Token: 0x04000F21 RID: 3873
		None = 0,
		// Token: 0x04000F22 RID: 3874
		HideInInspector = 1,
		// Token: 0x04000F23 RID: 3875
		PerRendererData = 2,
		// Token: 0x04000F24 RID: 3876
		NoScaleOffset = 4,
		// Token: 0x04000F25 RID: 3877
		Normal = 8,
		// Token: 0x04000F26 RID: 3878
		HDR = 16,
		// Token: 0x04000F27 RID: 3879
		Gamma = 32,
		// Token: 0x04000F28 RID: 3880
		NonModifiableTextureData = 64,
		// Token: 0x04000F29 RID: 3881
		MainTexture = 128,
		// Token: 0x04000F2A RID: 3882
		MainColor = 256
	}
}
