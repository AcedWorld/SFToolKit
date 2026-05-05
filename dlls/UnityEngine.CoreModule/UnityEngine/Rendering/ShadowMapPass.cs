using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020003FF RID: 1023
	[Flags]
	public enum ShadowMapPass
	{
		// Token: 0x04000BDD RID: 3037
		PointlightPositiveX = 1,
		// Token: 0x04000BDE RID: 3038
		PointlightNegativeX = 2,
		// Token: 0x04000BDF RID: 3039
		PointlightPositiveY = 4,
		// Token: 0x04000BE0 RID: 3040
		PointlightNegativeY = 8,
		// Token: 0x04000BE1 RID: 3041
		PointlightPositiveZ = 16,
		// Token: 0x04000BE2 RID: 3042
		PointlightNegativeZ = 32,
		// Token: 0x04000BE3 RID: 3043
		DirectionalCascade0 = 64,
		// Token: 0x04000BE4 RID: 3044
		DirectionalCascade1 = 128,
		// Token: 0x04000BE5 RID: 3045
		DirectionalCascade2 = 256,
		// Token: 0x04000BE6 RID: 3046
		DirectionalCascade3 = 512,
		// Token: 0x04000BE7 RID: 3047
		Spotlight = 1024,
		// Token: 0x04000BE8 RID: 3048
		Pointlight = 63,
		// Token: 0x04000BE9 RID: 3049
		Directional = 960,
		// Token: 0x04000BEA RID: 3050
		All = 2047
	}
}
