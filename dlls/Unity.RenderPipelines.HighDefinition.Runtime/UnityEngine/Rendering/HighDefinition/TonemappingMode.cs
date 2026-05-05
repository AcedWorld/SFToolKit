using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200013D RID: 317
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\PostProcessing\\Components\\Tonemapping.cs")]
	public enum TonemappingMode
	{
		// Token: 0x04000BCE RID: 3022
		None,
		// Token: 0x04000BCF RID: 3023
		Neutral,
		// Token: 0x04000BD0 RID: 3024
		ACES,
		// Token: 0x04000BD1 RID: 3025
		Custom,
		// Token: 0x04000BD2 RID: 3026
		External
	}
}
