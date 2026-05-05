using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A4 RID: 164
	[Flags]
	public enum ProbeRenderSteps
	{
		// Token: 0x0400075E RID: 1886
		None = 0,
		// Token: 0x0400075F RID: 1887
		CubeFace0 = 1,
		// Token: 0x04000760 RID: 1888
		CubeFace1 = 2,
		// Token: 0x04000761 RID: 1889
		CubeFace2 = 4,
		// Token: 0x04000762 RID: 1890
		CubeFace3 = 8,
		// Token: 0x04000763 RID: 1891
		CubeFace4 = 16,
		// Token: 0x04000764 RID: 1892
		CubeFace5 = 32,
		// Token: 0x04000765 RID: 1893
		Planar = 64,
		// Token: 0x04000766 RID: 1894
		IncrementRenderCount = 128,
		// Token: 0x04000767 RID: 1895
		ReflectionProbeMask = 191,
		// Token: 0x04000768 RID: 1896
		PlanarProbeMask = 192
	}
}
