using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000B6 RID: 182
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\ScreenSpaceLighting\\RayMarchingFallbackHierarchy.cs")]
	public enum RayMarchingFallbackHierarchy
	{
		// Token: 0x040007F8 RID: 2040
		[InspectorName("Reflection Probes and Sky")]
		ReflectionProbesAndSky = 3,
		// Token: 0x040007F9 RID: 2041
		[InspectorName("Reflection Probes")]
		ReflectionProbes = 2,
		// Token: 0x040007FA RID: 2042
		[InspectorName("Sky")]
		Sky = 1,
		// Token: 0x040007FB RID: 2043
		[InspectorName("None")]
		None = 0
	}
}
