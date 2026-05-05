using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E5 RID: 485
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Sky\\PhysicallyBasedSky\\ShaderVariablesPhysicallyBasedSky.cs")]
	internal enum PbrSkyConfig
	{
		// Token: 0x04001726 RID: 5926
		GroundIrradianceTableSize = 256,
		// Token: 0x04001727 RID: 5927
		InScatteredRadianceTableSizeX = 128,
		// Token: 0x04001728 RID: 5928
		InScatteredRadianceTableSizeY = 32,
		// Token: 0x04001729 RID: 5929
		InScatteredRadianceTableSizeZ = 16,
		// Token: 0x0400172A RID: 5930
		InScatteredRadianceTableSizeW = 64,
		// Token: 0x0400172B RID: 5931
		MultiScatteringLutWidth = 32,
		// Token: 0x0400172C RID: 5932
		MultiScatteringLutHeight = 32
	}
}
