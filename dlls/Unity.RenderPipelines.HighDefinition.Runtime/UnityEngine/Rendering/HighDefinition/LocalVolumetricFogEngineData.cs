using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000DB RID: 219
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\VolumetricLighting\\HDRenderPipeline.VolumetricLighting.cs")]
	internal struct LocalVolumetricFogEngineData
	{
		// Token: 0x0600094C RID: 2380 RVA: 0x00051F1C File Offset: 0x0005011C
		public static LocalVolumetricFogEngineData GetNeutralValues()
		{
			LocalVolumetricFogEngineData result;
			result.scattering = Vector3.zero;
			result.extinction = 0f;
			result.textureTiling = Vector3.one;
			result.textureScroll = Vector3.zero;
			result.rcpPosFaceFade = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			result.rcpNegFaceFade = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			result.invertFade = 0;
			result.rcpDistFadeLen = 0f;
			result.endTimesRcpDistFadeLen = 1f;
			result.falloffMode = LocalVolumetricFogFalloffMode.Linear;
			result.blendingMode = LocalVolumetricFogBlendingMode.Additive;
			result.albedo = Vector3.zero;
			return result;
		}

		// Token: 0x0400094A RID: 2378
		public Vector3 scattering;

		// Token: 0x0400094B RID: 2379
		public float extinction;

		// Token: 0x0400094C RID: 2380
		public Vector3 textureTiling;

		// Token: 0x0400094D RID: 2381
		public int invertFade;

		// Token: 0x0400094E RID: 2382
		public Vector3 textureScroll;

		// Token: 0x0400094F RID: 2383
		public float rcpDistFadeLen;

		// Token: 0x04000950 RID: 2384
		public Vector3 rcpPosFaceFade;

		// Token: 0x04000951 RID: 2385
		public float endTimesRcpDistFadeLen;

		// Token: 0x04000952 RID: 2386
		public Vector3 rcpNegFaceFade;

		// Token: 0x04000953 RID: 2387
		public LocalVolumetricFogBlendingMode blendingMode;

		// Token: 0x04000954 RID: 2388
		public Vector3 albedo;

		// Token: 0x04000955 RID: 2389
		public LocalVolumetricFogFalloffMode falloffMode;
	}
}
