using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000048 RID: 72
	[Serializable]
	public class LightingDebugSettings
	{
		// Token: 0x06000222 RID: 546 RVA: 0x0000C4EC File Offset: 0x0000A6EC
		public bool IsDebugDisplayEnabled()
		{
			return this.debugLightingMode != DebugLightingMode.None || this.debugLightFilterMode != DebugLightFilterMode.None || this.debugLightLayers || this.overrideSmoothness || this.overrideAlbedo || this.overrideNormal || this.overrideAmbientOcclusion || this.overrideSpecularColor || this.overrideEmissiveColor || this.shadowDebugMode == ShadowMapDebugMode.SingleShadow;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000C54C File Offset: 0x0000A74C
		internal bool IsDebugDisplayRemovePostprocess()
		{
			return this.debugLightingMode == DebugLightingMode.LuxMeter || this.debugLightingMode == DebugLightingMode.LuminanceMeter || this.debugLightingMode == DebugLightingMode.VisualizeShadowMasks || this.debugLightingMode == DebugLightingMode.IndirectDiffuseOcclusion || this.debugLightingMode == DebugLightingMode.IndirectSpecularOcclusion || this.debugLightingMode == DebugLightingMode.ProbeVolumeSampledSubdivision;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000C58C File Offset: 0x0000A78C
		internal static Vector4[] GetDefaultRenderingLayersColorPalette()
		{
			Vector4[] array = new Vector4[32];
			Vector4[] array2 = new Vector4[]
			{
				new Vector4(230f, 159f, 0f) / 255f,
				new Vector4(86f, 180f, 233f) / 255f,
				new Vector4(255f, 182f, 291f) / 255f,
				new Vector4(0f, 158f, 115f) / 255f,
				new Vector4(240f, 228f, 66f) / 255f,
				new Vector4(0f, 114f, 178f) / 255f,
				new Vector4(213f, 94f, 0f) / 255f,
				new Vector4(170f, 68f, 170f) / 255f
			};
			int i;
			for (i = 0; i < array2.Length; i++)
			{
				array[i] = array2[i];
			}
			while (i < array.Length)
			{
				array[i] = new Vector4(0f, 0f, 0f);
				i++;
			}
			return array;
		}

		// Token: 0x040001C6 RID: 454
		public DebugLightFilterMode debugLightFilterMode;

		// Token: 0x040001C7 RID: 455
		public DebugLightingMode debugLightingMode;

		// Token: 0x040001C8 RID: 456
		public bool debugLightLayers;

		// Token: 0x040001C9 RID: 457
		public DebugLightLayersMask debugLightLayersFilterMask = (DebugLightLayersMask)(-1);

		// Token: 0x040001CA RID: 458
		public bool debugSelectionLightLayers;

		// Token: 0x040001CB RID: 459
		public bool debugSelectionShadowLayers;

		// Token: 0x040001CC RID: 460
		public Vector4[] debugRenderingLayersColors = LightingDebugSettings.GetDefaultRenderingLayersColorPalette();

		// Token: 0x040001CD RID: 461
		public ShadowMapDebugMode shadowDebugMode;

		// Token: 0x040001CE RID: 462
		public bool shadowDebugUseSelection;

		// Token: 0x040001CF RID: 463
		public uint shadowMapIndex;

		// Token: 0x040001D0 RID: 464
		public float shadowMinValue;

		// Token: 0x040001D1 RID: 465
		public float shadowMaxValue = 1f;

		// Token: 0x040001D2 RID: 466
		public float shadowResolutionScaleFactor = 1f;

		// Token: 0x040001D3 RID: 467
		public bool clearShadowAtlas;

		// Token: 0x040001D4 RID: 468
		public bool overrideSmoothness;

		// Token: 0x040001D5 RID: 469
		public float overrideSmoothnessValue = 0.5f;

		// Token: 0x040001D6 RID: 470
		public bool overrideAlbedo;

		// Token: 0x040001D7 RID: 471
		public Color overrideAlbedoValue = new Color(0.5f, 0.5f, 0.5f);

		// Token: 0x040001D8 RID: 472
		public bool overrideNormal;

		// Token: 0x040001D9 RID: 473
		public bool overrideAmbientOcclusion;

		// Token: 0x040001DA RID: 474
		public float overrideAmbientOcclusionValue = 1f;

		// Token: 0x040001DB RID: 475
		public bool overrideSpecularColor;

		// Token: 0x040001DC RID: 476
		public Color overrideSpecularColorValue = new Color(1f, 1f, 1f);

		// Token: 0x040001DD RID: 477
		public bool overrideEmissiveColor;

		// Token: 0x040001DE RID: 478
		public Color overrideEmissiveColorValue = new Color(1f, 1f, 1f);

		// Token: 0x040001DF RID: 479
		public bool displaySkyReflection;

		// Token: 0x040001E0 RID: 480
		public float skyReflectionMipmap;

		// Token: 0x040001E1 RID: 481
		public bool displayLightVolumes;

		// Token: 0x040001E2 RID: 482
		public LightVolumeDebug lightVolumeDebugByCategory;

		// Token: 0x040001E3 RID: 483
		public uint maxDebugLightCount = 24U;

		// Token: 0x040001E4 RID: 484
		public ExposureDebugMode exposureDebugMode;

		// Token: 0x040001E5 RID: 485
		public float debugExposure;

		// Token: 0x040001E6 RID: 486
		[Obsolete("Please use the lens attenuation mode in HDRP Global Settings", true)]
		public float debugLensAttenuation = 0.65f;

		// Token: 0x040001E7 RID: 487
		public bool showTonemapCurveAlongHistogramView = true;

		// Token: 0x040001E8 RID: 488
		public bool centerHistogramAroundMiddleGrey;

		// Token: 0x040001E9 RID: 489
		public bool displayFinalImageHistogramAsRGB;

		// Token: 0x040001EA RID: 490
		public bool displayMaskOnly;

		// Token: 0x040001EB RID: 491
		public bool displayOnSceneOverlay = true;

		// Token: 0x040001EC RID: 492
		public HDRDebugMode hdrDebugMode;

		// Token: 0x040001ED RID: 493
		public bool displayCookieAtlas;

		// Token: 0x040001EE RID: 494
		public bool displayCookieCubeArray;

		// Token: 0x040001EF RID: 495
		public uint cubeArraySliceIndex;

		// Token: 0x040001F0 RID: 496
		public uint cookieAtlasMipLevel;

		// Token: 0x040001F1 RID: 497
		public bool clearCookieAtlas;

		// Token: 0x040001F2 RID: 498
		public bool displayReflectionProbeAtlas;

		// Token: 0x040001F3 RID: 499
		public uint reflectionProbeMipLevel;

		// Token: 0x040001F4 RID: 500
		public uint reflectionProbeSlice;

		// Token: 0x040001F5 RID: 501
		public bool reflectionProbeApplyExposure;

		// Token: 0x040001F6 RID: 502
		public bool clearReflectionProbeAtlas;

		// Token: 0x040001F7 RID: 503
		public bool showPunctualLight = true;

		// Token: 0x040001F8 RID: 504
		public bool showDirectionalLight = true;

		// Token: 0x040001F9 RID: 505
		public bool showAreaLight = true;

		// Token: 0x040001FA RID: 506
		public bool showReflectionProbe = true;

		// Token: 0x040001FB RID: 507
		[Obsolete("The local volumetric fog atlas was removed. This field is unused.")]
		public bool displayLocalVolumetricFogAtlas;

		// Token: 0x040001FC RID: 508
		public uint localVolumetricFogAtlasSlice;

		// Token: 0x040001FD RID: 509
		public bool localVolumetricFogUseSelection;

		// Token: 0x040001FE RID: 510
		public TileClusterDebug tileClusterDebug;

		// Token: 0x040001FF RID: 511
		public TileClusterCategoryDebug tileClusterDebugByCategory = TileClusterCategoryDebug.Punctual;

		// Token: 0x04000200 RID: 512
		public ClusterDebugMode clusterDebugMode;

		// Token: 0x04000201 RID: 513
		public float clusterDebugDistance = 1f;
	}
}
