using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000097 RID: 151
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightLoop\\LightLoop.cs")]
	internal enum LightFeatureFlags
	{
		// Token: 0x040006FF RID: 1791
		Punctual = 4096,
		// Token: 0x04000700 RID: 1792
		Area = 8192,
		// Token: 0x04000701 RID: 1793
		Directional = 16384,
		// Token: 0x04000702 RID: 1794
		Env = 32768,
		// Token: 0x04000703 RID: 1795
		Sky = 65536,
		// Token: 0x04000704 RID: 1796
		SSRefraction = 131072,
		// Token: 0x04000705 RID: 1797
		SSReflection = 262144
	}
}
