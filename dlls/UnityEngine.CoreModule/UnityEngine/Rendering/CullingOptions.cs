using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200044F RID: 1103
	[Flags]
	public enum CullingOptions
	{
		// Token: 0x04000DD7 RID: 3543
		None = 0,
		// Token: 0x04000DD8 RID: 3544
		ForceEvenIfCameraIsNotActive = 1,
		// Token: 0x04000DD9 RID: 3545
		OcclusionCull = 2,
		// Token: 0x04000DDA RID: 3546
		NeedsLighting = 4,
		// Token: 0x04000DDB RID: 3547
		NeedsReflectionProbes = 8,
		// Token: 0x04000DDC RID: 3548
		Stereo = 16,
		// Token: 0x04000DDD RID: 3549
		DisablePerObjectCulling = 32,
		// Token: 0x04000DDE RID: 3550
		ShadowCasters = 64
	}
}
