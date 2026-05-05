using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000093 RID: 147
	[Serializable]
	public struct GlobalLightLoopSettings
	{
		// Token: 0x06000725 RID: 1829 RVA: 0x00047BB4 File Offset: 0x00045DB4
		internal static GlobalLightLoopSettings NewDefault()
		{
			return new GlobalLightLoopSettings
			{
				cookieAtlasSize = CookieAtlasResolution.CookieResolution2048,
				cookieFormat = CookieAtlasGraphicsFormat.R11G11B10,
				cookieAtlasLastValidMip = 0,
				cookieTexArraySize = 1,
				reflectionProbeFormat = ReflectionAndPlanarProbeFormat.R11G11B10,
				reflectionProbeTexCacheSize = ReflectionProbeTextureCacheResolution.Resolution4096x4096,
				reflectionProbeTexLastValidCubeMip = 3,
				reflectionProbeTexLastValidPlanarMip = 0,
				reflectionProbeDecreaseResToFit = true,
				skyReflectionSize = SkyResolution.SkyResolution256,
				skyLightingOverrideLayerMask = 0,
				maxDirectionalLightsOnScreen = 16,
				maxPunctualLightsOnScreen = 512,
				maxAreaLightsOnScreen = 64,
				maxCubeReflectionOnScreen = 32,
				maxPlanarReflectionOnScreen = 8,
				maxDecalsOnScreen = 512,
				maxLightsPerClusterCell = 8,
				maxLocalVolumetricFogOnScreen = 256
			};
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00047C84 File Offset: 0x00045E84
		internal static Vector2Int GetReflectionProbeTextureCacheDim(ReflectionProbeTextureCacheResolution resolution)
		{
			if (resolution <= ReflectionProbeTextureCacheResolution.Resolution16384x16384)
			{
				return new Vector2Int((int)resolution, (int)resolution);
			}
			return new Vector2Int((int)(resolution >> 16), (int)(resolution & (ReflectionProbeTextureCacheResolution)65535));
		}

		// Token: 0x040006D8 RID: 1752
		internal static readonly GlobalLightLoopSettings @default;

		// Token: 0x040006D9 RID: 1753
		[FormerlySerializedAs("cookieSize")]
		public CookieAtlasResolution cookieAtlasSize;

		// Token: 0x040006DA RID: 1754
		public CookieAtlasGraphicsFormat cookieFormat;

		// Token: 0x040006DB RID: 1755
		public int cookieAtlasLastValidMip;

		// Token: 0x040006DC RID: 1756
		[SerializeField]
		[Obsolete("There is no more texture array for cookies, use cookie atlases properties instead.", false)]
		internal int cookieTexArraySize;

		// Token: 0x040006DD RID: 1757
		[FormerlySerializedAs("planarReflectionTextureSize")]
		[SerializeField]
		[Obsolete("There is no more planar reflection atlas, use reflection probe atlases instead.", false)]
		public PlanarReflectionAtlasResolution planarReflectionAtlasSize;

		// Token: 0x040006DE RID: 1758
		[SerializeField]
		[Obsolete("There is no more texture array for cube reflection probes, use reflection probe atlases properties instead.", false)]
		internal int reflectionProbeCacheSize;

		// Token: 0x040006DF RID: 1759
		[SerializeField]
		[Obsolete("There is no more cube reflection probe size, use cube reflection probe size tiers instead.", false)]
		internal CubeReflectionResolution reflectionCubemapSize;

		// Token: 0x040006E0 RID: 1760
		[SerializeField]
		[Obsolete("There is no more max env light on screen, use max planar and cube reflection probes on screen instead.", false)]
		internal int maxEnvLightsOnScreen;

		// Token: 0x040006E1 RID: 1761
		public bool reflectionCacheCompressed;

		// Token: 0x040006E2 RID: 1762
		public ReflectionAndPlanarProbeFormat reflectionProbeFormat;

		// Token: 0x040006E3 RID: 1763
		public ReflectionProbeTextureCacheResolution reflectionProbeTexCacheSize;

		// Token: 0x040006E4 RID: 1764
		public int reflectionProbeTexLastValidCubeMip;

		// Token: 0x040006E5 RID: 1765
		public int reflectionProbeTexLastValidPlanarMip;

		// Token: 0x040006E6 RID: 1766
		public bool reflectionProbeDecreaseResToFit;

		// Token: 0x040006E7 RID: 1767
		public SkyResolution skyReflectionSize;

		// Token: 0x040006E8 RID: 1768
		public LayerMask skyLightingOverrideLayerMask;

		// Token: 0x040006E9 RID: 1769
		public bool supportFabricConvolution;

		// Token: 0x040006EA RID: 1770
		public int maxDirectionalLightsOnScreen;

		// Token: 0x040006EB RID: 1771
		public int maxPunctualLightsOnScreen;

		// Token: 0x040006EC RID: 1772
		public int maxAreaLightsOnScreen;

		// Token: 0x040006ED RID: 1773
		public int maxCubeReflectionOnScreen;

		// Token: 0x040006EE RID: 1774
		public int maxPlanarReflectionOnScreen;

		// Token: 0x040006EF RID: 1775
		public int maxDecalsOnScreen;

		// Token: 0x040006F0 RID: 1776
		public int maxLightsPerClusterCell;

		// Token: 0x040006F1 RID: 1777
		[Obsolete("The texture resolution limit in volumetric fogs have been removed. This field is unused.")]
		public LocalVolumetricFogResolution maxLocalVolumetricFogSize;

		// Token: 0x040006F2 RID: 1778
		[Range(1f, 1024f)]
		public int maxLocalVolumetricFogOnScreen;
	}
}
