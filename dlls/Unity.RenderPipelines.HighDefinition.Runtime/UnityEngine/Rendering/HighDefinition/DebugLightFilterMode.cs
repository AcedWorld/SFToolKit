using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000040 RID: 64
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\LightingDebug.cs")]
	[Flags]
	public enum DebugLightFilterMode
	{
		// Token: 0x0400018D RID: 397
		None = 0,
		// Token: 0x0400018E RID: 398
		DirectDirectional = 1,
		// Token: 0x0400018F RID: 399
		DirectPunctual = 2,
		// Token: 0x04000190 RID: 400
		DirectRectangle = 4,
		// Token: 0x04000191 RID: 401
		DirectTube = 8,
		// Token: 0x04000192 RID: 402
		DirectSpotCone = 16,
		// Token: 0x04000193 RID: 403
		DirectSpotPyramid = 32,
		// Token: 0x04000194 RID: 404
		DirectSpotBox = 64,
		// Token: 0x04000195 RID: 405
		IndirectReflectionProbe = 128,
		// Token: 0x04000196 RID: 406
		IndirectPlanarProbe = 256
	}
}
