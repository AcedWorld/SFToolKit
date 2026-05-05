using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200028D RID: 653
	[Flags]
	internal enum RenderHints
	{
		// Token: 0x04000859 RID: 2137
		None = 0,
		// Token: 0x0400085A RID: 2138
		GroupTransform = 1,
		// Token: 0x0400085B RID: 2139
		BoneTransform = 2,
		// Token: 0x0400085C RID: 2140
		ClipWithScissors = 4,
		// Token: 0x0400085D RID: 2141
		MaskContainer = 8,
		// Token: 0x0400085E RID: 2142
		DynamicColor = 16,
		// Token: 0x0400085F RID: 2143
		DirtyOffset = 5,
		// Token: 0x04000860 RID: 2144
		DirtyGroupTransform = 32,
		// Token: 0x04000861 RID: 2145
		DirtyBoneTransform = 64,
		// Token: 0x04000862 RID: 2146
		DirtyClipWithScissors = 128,
		// Token: 0x04000863 RID: 2147
		DirtyMaskContainer = 256,
		// Token: 0x04000864 RID: 2148
		DirtyDynamicColor = 512,
		// Token: 0x04000865 RID: 2149
		DirtyAll = 992
	}
}
