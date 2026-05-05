using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200045E RID: 1118
	[Flags]
	public enum PerObjectData
	{
		// Token: 0x04000E2F RID: 3631
		None = 0,
		// Token: 0x04000E30 RID: 3632
		LightProbe = 1,
		// Token: 0x04000E31 RID: 3633
		ReflectionProbes = 2,
		// Token: 0x04000E32 RID: 3634
		LightProbeProxyVolume = 4,
		// Token: 0x04000E33 RID: 3635
		Lightmaps = 8,
		// Token: 0x04000E34 RID: 3636
		LightData = 16,
		// Token: 0x04000E35 RID: 3637
		MotionVectors = 32,
		// Token: 0x04000E36 RID: 3638
		LightIndices = 64,
		// Token: 0x04000E37 RID: 3639
		ReflectionProbeData = 128,
		// Token: 0x04000E38 RID: 3640
		OcclusionProbe = 256,
		// Token: 0x04000E39 RID: 3641
		OcclusionProbeProxyVolume = 512,
		// Token: 0x04000E3A RID: 3642
		ShadowMask = 1024
	}
}
