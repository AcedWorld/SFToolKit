using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200009E RID: 158
	public enum TileClusterCategoryDebug
	{
		// Token: 0x0400073A RID: 1850
		Punctual = 1,
		// Token: 0x0400073B RID: 1851
		Area,
		// Token: 0x0400073C RID: 1852
		[InspectorName("Area and Punctual")]
		AreaAndPunctual,
		// Token: 0x0400073D RID: 1853
		[InspectorName("Reflection Probes")]
		Environment,
		// Token: 0x0400073E RID: 1854
		[InspectorName("Reflection Probes and Punctual")]
		EnvironmentAndPunctual,
		// Token: 0x0400073F RID: 1855
		[InspectorName("Reflection Probes and Area")]
		EnvironmentAndArea,
		// Token: 0x04000740 RID: 1856
		[InspectorName("Reflection Probes, Area and Punctual")]
		EnvironmentAndAreaAndPunctual,
		// Token: 0x04000741 RID: 1857
		Decal,
		// Token: 0x04000742 RID: 1858
		[Obsolete("Unused")]
		LocalVolumetricFog = 0,
		// Token: 0x04000743 RID: 1859
		[Obsolete("Unused", true)]
		[InspectorName("Local Volumetric Fog")]
		DensityVolumes = 0
	}
}
