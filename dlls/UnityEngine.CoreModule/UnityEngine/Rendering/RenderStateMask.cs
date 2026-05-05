using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200046B RID: 1131
	[Flags]
	public enum RenderStateMask
	{
		// Token: 0x04000E7B RID: 3707
		Nothing = 0,
		// Token: 0x04000E7C RID: 3708
		Blend = 1,
		// Token: 0x04000E7D RID: 3709
		Raster = 2,
		// Token: 0x04000E7E RID: 3710
		Depth = 4,
		// Token: 0x04000E7F RID: 3711
		Stencil = 8,
		// Token: 0x04000E80 RID: 3712
		Everything = 15
	}
}
