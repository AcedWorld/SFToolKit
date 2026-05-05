using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000182 RID: 386
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\Raytracing\\RayTracingFallbackHierarchy.cs")]
	public enum RayTracingFallbackHierachy
	{
		// Token: 0x0400135C RID: 4956
		[InspectorName("Reflection Probes and Sky")]
		ReflectionProbesAndSky = 3,
		// Token: 0x0400135D RID: 4957
		[InspectorName("Reflection Probes")]
		ReflectionProbes = 2,
		// Token: 0x0400135E RID: 4958
		[InspectorName("Sky")]
		Sky = 1,
		// Token: 0x0400135F RID: 4959
		[InspectorName("None")]
		None = 0
	}
}
