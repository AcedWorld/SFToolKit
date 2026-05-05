using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000005 RID: 5
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition-config@14.0.11\\Runtime\\ShaderConfig.cs")]
	public enum ShaderOptions
	{
		// Token: 0x0400000C RID: 12
		ColoredShadow = 1,
		// Token: 0x0400000D RID: 13
		CameraRelativeRendering = 1,
		// Token: 0x0400000E RID: 14
		PreExposition = 1,
		// Token: 0x0400000F RID: 15
		PrecomputedAtmosphericAttenuation = 0,
		// Token: 0x04000010 RID: 16
		XrMaxViews = 2,
		// Token: 0x04000011 RID: 17
		AreaLights = 1,
		// Token: 0x04000012 RID: 18
		BarnDoor = 0,
		// Token: 0x04000013 RID: 19
		GlobalMipBias,
		// Token: 0x04000014 RID: 20
		FPTLMaxLightCount = 63,
		// Token: 0x04000015 RID: 21
		LightClusterMaxCellElementCount = 24,
		// Token: 0x04000016 RID: 22
		PathTracingMaxLightCount = 16
	}
}
