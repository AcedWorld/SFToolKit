using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000035 RID: 53
	[Flags]
	public enum ClearFlag
	{
		// Token: 0x04000139 RID: 313
		None = 0,
		// Token: 0x0400013A RID: 314
		Color = 1,
		// Token: 0x0400013B RID: 315
		Depth = 2,
		// Token: 0x0400013C RID: 316
		Stencil = 4,
		// Token: 0x0400013D RID: 317
		DepthStencil = 6,
		// Token: 0x0400013E RID: 318
		ColorStencil = 5,
		// Token: 0x0400013F RID: 319
		All = 7
	}
}
