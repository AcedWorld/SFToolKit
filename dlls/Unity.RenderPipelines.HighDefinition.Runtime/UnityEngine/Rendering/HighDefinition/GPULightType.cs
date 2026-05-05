using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000080 RID: 128
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightDefinition.cs")]
	internal enum GPULightType
	{
		// Token: 0x0400061B RID: 1563
		Directional,
		// Token: 0x0400061C RID: 1564
		Point,
		// Token: 0x0400061D RID: 1565
		Spot,
		// Token: 0x0400061E RID: 1566
		ProjectorPyramid,
		// Token: 0x0400061F RID: 1567
		ProjectorBox,
		// Token: 0x04000620 RID: 1568
		Tube,
		// Token: 0x04000621 RID: 1569
		Rectangle,
		// Token: 0x04000622 RID: 1570
		Disc
	}
}
