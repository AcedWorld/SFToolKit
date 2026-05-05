using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200040A RID: 1034
	[Flags]
	public enum RenderTargetFlags
	{
		// Token: 0x04000C56 RID: 3158
		None = 0,
		// Token: 0x04000C57 RID: 3159
		ReadOnlyDepth = 1,
		// Token: 0x04000C58 RID: 3160
		ReadOnlyStencil = 2,
		// Token: 0x04000C59 RID: 3161
		ReadOnlyDepthStencil = 3
	}
}
