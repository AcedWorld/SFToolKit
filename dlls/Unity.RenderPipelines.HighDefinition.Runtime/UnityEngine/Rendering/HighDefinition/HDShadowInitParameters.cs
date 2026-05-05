using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D0 RID: 208
	[Serializable]
	public struct HDShadowInitParameters
	{
		// Token: 0x060008F1 RID: 2289 RVA: 0x0004EBC8 File Offset: 0x0004CDC8
		internal static HDShadowInitParameters NewDefault()
		{
			return new HDShadowInitParameters
			{
				maxShadowRequests = 128,
				directionalShadowsDepthBits = DepthBits.Depth32,
				punctualLightShadowAtlas = HDShadowInitParameters.HDShadowAtlasInitParams.GetDefault(),
				areaLightShadowAtlas = HDShadowInitParameters.HDShadowAtlasInitParams.GetDefault(),
				cachedPunctualLightShadowAtlas = 2048,
				cachedAreaLightShadowAtlas = 1024,
				allowDirectionalMixedCachedShadows = false,
				shadowResolutionDirectional = new IntScalableSetting(new int[]
				{
					256,
					512,
					1024,
					2048
				}, ScalableSettingSchemaId.With4Levels),
				shadowResolutionArea = new IntScalableSetting(new int[]
				{
					256,
					512,
					1024,
					2048
				}, ScalableSettingSchemaId.With4Levels),
				shadowResolutionPunctual = new IntScalableSetting(new int[]
				{
					256,
					512,
					1024,
					2048
				}, ScalableSettingSchemaId.With4Levels),
				shadowFilteringQuality = HDShadowFilteringQuality.Medium,
				areaShadowFilteringQuality = HDAreaShadowFilteringQuality.Medium,
				supportScreenSpaceShadows = false,
				maxScreenSpaceShadowSlots = 4,
				screenSpaceShadowBufferFormat = ScreenSpaceShadowFormat.R16G16B16A16,
				maxDirectionalShadowMapResolution = 2048,
				maxAreaShadowMapResolution = 2048,
				maxPunctualShadowMapResolution = 2048
			};
		}

		// Token: 0x040008EC RID: 2284
		internal const int k_DefaultShadowAtlasResolution = 4096;

		// Token: 0x040008ED RID: 2285
		internal const int k_DefaultMaxShadowRequests = 128;

		// Token: 0x040008EE RID: 2286
		internal const DepthBits k_DefaultShadowMapDepthBits = DepthBits.Depth32;

		// Token: 0x040008EF RID: 2287
		public int maxShadowRequests;

		// Token: 0x040008F0 RID: 2288
		public DepthBits directionalShadowsDepthBits;

		// Token: 0x040008F1 RID: 2289
		[FormerlySerializedAs("shadowQuality")]
		public HDShadowFilteringQuality shadowFilteringQuality;

		// Token: 0x040008F2 RID: 2290
		public HDAreaShadowFilteringQuality areaShadowFilteringQuality;

		// Token: 0x040008F3 RID: 2291
		public HDShadowInitParameters.HDShadowAtlasInitParams punctualLightShadowAtlas;

		// Token: 0x040008F4 RID: 2292
		public HDShadowInitParameters.HDShadowAtlasInitParams areaLightShadowAtlas;

		// Token: 0x040008F5 RID: 2293
		public int cachedPunctualLightShadowAtlas;

		// Token: 0x040008F6 RID: 2294
		public int cachedAreaLightShadowAtlas;

		// Token: 0x040008F7 RID: 2295
		public bool allowDirectionalMixedCachedShadows;

		// Token: 0x040008F8 RID: 2296
		public IntScalableSetting shadowResolutionDirectional;

		// Token: 0x040008F9 RID: 2297
		public IntScalableSetting shadowResolutionPunctual;

		// Token: 0x040008FA RID: 2298
		public IntScalableSetting shadowResolutionArea;

		// Token: 0x040008FB RID: 2299
		public int maxDirectionalShadowMapResolution;

		// Token: 0x040008FC RID: 2300
		public int maxPunctualShadowMapResolution;

		// Token: 0x040008FD RID: 2301
		public int maxAreaShadowMapResolution;

		// Token: 0x040008FE RID: 2302
		public bool supportScreenSpaceShadows;

		// Token: 0x040008FF RID: 2303
		public int maxScreenSpaceShadowSlots;

		// Token: 0x04000900 RID: 2304
		public ScreenSpaceShadowFormat screenSpaceShadowBufferFormat;

		// Token: 0x0200035B RID: 859
		[Serializable]
		public struct HDShadowAtlasInitParams
		{
			// Token: 0x060012D0 RID: 4816 RVA: 0x00090654 File Offset: 0x0008E854
			internal static HDShadowInitParameters.HDShadowAtlasInitParams GetDefault()
			{
				return new HDShadowInitParameters.HDShadowAtlasInitParams
				{
					shadowAtlasResolution = 4096,
					shadowAtlasDepthBits = DepthBits.Depth32,
					useDynamicViewportRescale = true
				};
			}

			// Token: 0x0400238F RID: 9103
			public int shadowAtlasResolution;

			// Token: 0x04002390 RID: 9104
			public DepthBits shadowAtlasDepthBits;

			// Token: 0x04002391 RID: 9105
			public bool useDynamicViewportRescale;
		}
	}
}
