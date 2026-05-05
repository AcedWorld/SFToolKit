using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000007 RID: 7
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition-config@14.0.11\\Runtime\\ShaderConfig.cs")]
	public class InternalLightCullingDefs
	{
		// Token: 0x04000022 RID: 34
		public static int s_MaxNrBigTileLightsPlusOne = Math.Clamp((ShaderConfig.FPTLMaxLightCount + 1) * 8, 512, 1024);

		// Token: 0x04000023 RID: 35
		public static int s_LightListMaxCoarseEntries = Math.Clamp(ShaderConfig.FPTLMaxLightCount + 1, 64, 256);

		// Token: 0x04000024 RID: 36
		public static int s_LightClusterMaxCoarseEntries = Math.Clamp((ShaderConfig.FPTLMaxLightCount + 1) * 2, 128, 256);

		// Token: 0x04000025 RID: 37
		public static int s_LightDwordPerFptlTile = (ShaderConfig.FPTLMaxLightCount + 1) / 2;

		// Token: 0x04000026 RID: 38
		public static int s_LightClusterPackingCountBits = (int)Mathf.Ceil(Mathf.Log((float)Mathf.NextPowerOfTwo(ShaderConfig.FPTLMaxLightCount), 2f));

		// Token: 0x04000027 RID: 39
		public static int s_LightClusterPackingCountMask = (1 << InternalLightCullingDefs.s_LightClusterPackingCountBits) - 1;

		// Token: 0x04000028 RID: 40
		public static int s_LightClusterPackingOffsetBits = 32 - InternalLightCullingDefs.s_LightClusterPackingCountBits;

		// Token: 0x04000029 RID: 41
		public static int s_LightClusterPackingOffsetMask = (1 << InternalLightCullingDefs.s_LightClusterPackingOffsetBits) - 1;
	}
}
