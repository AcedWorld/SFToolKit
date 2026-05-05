using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B0 RID: 432
	[DebuggerDisplay("{bitDatas.humanizedData}")]
	[DebuggerTypeProxy(typeof(FrameSettings.FrameSettingsDebugView))]
	[Serializable]
	public struct FrameSettings
	{
		// Token: 0x06000D40 RID: 3392 RVA: 0x0006C808 File Offset: 0x0006AA08
		internal static FrameSettings NewDefaultCamera()
		{
			return new FrameSettings
			{
				bitDatas = new BitArray128(new uint[]
				{
					20U,
					21U,
					22U,
					34U,
					23U,
					94U,
					24U,
					95U,
					46U,
					26U,
					27U,
					28U,
					29U,
					30U,
					32U,
					0U,
					8U,
					9U,
					6U,
					68U,
					10U,
					11U,
					12U,
					96U,
					13U,
					14U,
					67U,
					15U,
					39U,
					80U,
					81U,
					82U,
					83U,
					84U,
					97U,
					85U,
					86U,
					87U,
					88U,
					93U,
					89U,
					90U,
					91U,
					17U,
					18U,
					19U,
					2U,
					3U,
					40U,
					41U,
					42U,
					42U,
					43U,
					44U,
					45U,
					122U,
					123U,
					124U,
					125U,
					120U,
					121U,
					16U,
					33U,
					35U,
					37U,
					38U,
					92U,
					127U,
					79U,
					99U
				}),
				lodBias = 1f,
				sssQualityMode = SssQualityMode.FromQualitySettings,
				sssQualityLevel = 0,
				sssCustomSampleBudget = 20,
				msaaMode = MSAAMode.None
			};
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0006C86C File Offset: 0x0006AA6C
		internal static FrameSettings NewDefaultRealtimeReflectionProbe()
		{
			return new FrameSettings
			{
				bitDatas = new BitArray128(new uint[]
				{
					20U,
					46U,
					26U,
					28U,
					29U,
					30U,
					0U,
					8U,
					9U,
					6U,
					68U,
					10U,
					11U,
					12U,
					96U,
					2U,
					3U,
					40U,
					41U,
					42U,
					42U,
					43U,
					44U,
					45U,
					122U,
					123U,
					124U,
					125U,
					120U,
					121U,
					33U,
					92U,
					127U,
					38U
				}),
				lodBias = 1f,
				sssQualityMode = SssQualityMode.FromQualitySettings,
				sssQualityLevel = 0,
				sssCustomSampleBudget = 20,
				msaaMode = MSAAMode.None
			};
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x0006C8D0 File Offset: 0x0006AAD0
		internal static FrameSettings NewDefaultCustomOrBakeReflectionProbe()
		{
			return new FrameSettings
			{
				bitDatas = new BitArray128(new uint[]
				{
					20U,
					21U,
					22U,
					24U,
					46U,
					26U,
					27U,
					28U,
					29U,
					30U,
					0U,
					8U,
					9U,
					6U,
					68U,
					12U,
					96U,
					13U,
					14U,
					67U,
					2U,
					3U,
					40U,
					41U,
					43U,
					44U,
					45U,
					122U,
					123U,
					124U,
					125U,
					120U,
					121U,
					36U,
					79U,
					99U,
					127U
				}),
				lodBias = 1f,
				sssQualityMode = SssQualityMode.FromQualitySettings,
				sssQualityLevel = 0,
				sssCustomSampleBudget = 20,
				msaaMode = MSAAMode.None
			};
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000D43 RID: 3395 RVA: 0x0006C931 File Offset: 0x0006AB31
		// (set) Token: 0x06000D44 RID: 3396 RVA: 0x0006C944 File Offset: 0x0006AB44
		public LitShaderMode litShaderMode
		{
			get
			{
				if (!this.bitDatas[0U])
				{
					return LitShaderMode.Forward;
				}
				return LitShaderMode.Deferred;
			}
			set
			{
				this.bitDatas[0U] = (value == LitShaderMode.Deferred);
			}
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0006C956 File Offset: 0x0006AB56
		public bool IsEnabled(FrameSettingsField field)
		{
			return this.bitDatas[(uint)field];
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0006C964 File Offset: 0x0006AB64
		public void SetEnabled(FrameSettingsField field, bool value)
		{
			this.bitDatas[(uint)field] = value;
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0006C974 File Offset: 0x0006AB74
		public float GetResolvedLODBias(HDRenderPipelineAsset hdrp)
		{
			FloatScalableSetting floatScalableSetting = hdrp.currentPlatformRenderPipelineSettings.lodBias;
			switch (this.lodBiasMode)
			{
			case LODBiasMode.FromQualitySettings:
				return floatScalableSetting[this.lodBiasQualityLevel];
			case LODBiasMode.ScaleQualitySettings:
				return this.lodBias * floatScalableSetting[this.lodBiasQualityLevel];
			case LODBiasMode.OverrideQualitySettings:
				return this.lodBias;
			default:
				throw new ArgumentOutOfRangeException("lodBiasMode");
			}
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0006C9DC File Offset: 0x0006ABDC
		public int GetResolvedMaximumLODLevel(HDRenderPipelineAsset hdrp)
		{
			IntScalableSetting intScalableSetting = hdrp.currentPlatformRenderPipelineSettings.maximumLODLevel;
			switch (this.maximumLODLevelMode)
			{
			case MaximumLODLevelMode.FromQualitySettings:
				return intScalableSetting[this.maximumLODLevelQualityLevel];
			case MaximumLODLevelMode.OffsetQualitySettings:
				return intScalableSetting[this.maximumLODLevelQualityLevel] + this.maximumLODLevel;
			case MaximumLODLevelMode.OverrideQualitySettings:
				return this.maximumLODLevel;
			default:
				throw new ArgumentOutOfRangeException("maximumLODLevelMode");
			}
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x0006CA44 File Offset: 0x0006AC44
		public int GetResolvedSssSampleBudget(HDRenderPipelineAsset hdrp)
		{
			IntScalableSetting sssSampleBudget = hdrp.currentPlatformRenderPipelineSettings.sssSampleBudget;
			SssQualityMode sssQualityMode = this.sssQualityMode;
			if (sssQualityMode == SssQualityMode.FromQualitySettings)
			{
				return sssSampleBudget[this.sssQualityLevel];
			}
			if (sssQualityMode != SssQualityMode.OverrideQualitySettings)
			{
				throw new ArgumentOutOfRangeException("sssCustomSampleBudget");
			}
			return this.sssCustomSampleBudget;
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x0006CA8B File Offset: 0x0006AC8B
		public MSAASamples GetResolvedMSAAMode(HDRenderPipelineAsset hdrp)
		{
			if (this.msaaMode == MSAAMode.FromHDRPAsset)
			{
				return hdrp.currentPlatformRenderPipelineSettings.msaaSampleCount;
			}
			return (MSAASamples)this.msaaMode;
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x0006CAA9 File Offset: 0x0006ACA9
		internal bool fptl
		{
			get
			{
				return this.litShaderMode == LitShaderMode.Deferred || this.bitDatas[120U];
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000D4C RID: 3404 RVA: 0x0006CAC3 File Offset: 0x0006ACC3
		internal float specularGlobalDimmer
		{
			get
			{
				if (!this.bitDatas[38U])
				{
					return 0f;
				}
				return 1f;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x0006CADF File Offset: 0x0006ACDF
		private bool asyncEnabled
		{
			get
			{
				return (SystemInfo.supportsAsyncCompute || RenderGraph.requireDebugData) && this.bitDatas[40U];
			}
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x0006CAFE File Offset: 0x0006ACFE
		internal bool BuildLightListRunsAsync()
		{
			return this.asyncEnabled && this.bitDatas[41U];
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x0006CB17 File Offset: 0x0006AD17
		internal bool SSRRunsAsync()
		{
			return this.asyncEnabled && this.bitDatas[42U];
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x0006CB30 File Offset: 0x0006AD30
		internal bool SSAORunsAsync()
		{
			return this.asyncEnabled && this.bitDatas[43U];
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x0006CB49 File Offset: 0x0006AD49
		internal bool ContactShadowsRunsAsync()
		{
			return this.asyncEnabled && this.bitDatas[44U];
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x0006CB62 File Offset: 0x0006AD62
		internal bool VolumeVoxelizationRunsAsync()
		{
			return this.asyncEnabled && this.bitDatas[45U];
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x0006CB7C File Offset: 0x0006AD7C
		internal static void Override(ref FrameSettings overriddenFrameSettings, FrameSettings overridingFrameSettings, FrameSettingsOverrideMask frameSettingsOverideMask)
		{
			overriddenFrameSettings.bitDatas = ((overridingFrameSettings.bitDatas & frameSettingsOverideMask.mask) | (~frameSettingsOverideMask.mask & overriddenFrameSettings.bitDatas));
			if (frameSettingsOverideMask.mask[47U])
			{
				overriddenFrameSettings.sssQualityMode = overridingFrameSettings.sssQualityMode;
			}
			if (frameSettingsOverideMask.mask[48U])
			{
				overriddenFrameSettings.sssQualityLevel = overridingFrameSettings.sssQualityLevel;
			}
			if (frameSettingsOverideMask.mask[49U])
			{
				overriddenFrameSettings.sssCustomSampleBudget = overridingFrameSettings.sssCustomSampleBudget;
			}
			if (frameSettingsOverideMask.mask[61U])
			{
				overriddenFrameSettings.lodBias = overridingFrameSettings.lodBias;
			}
			if (frameSettingsOverideMask.mask[60U])
			{
				overriddenFrameSettings.lodBiasMode = overridingFrameSettings.lodBiasMode;
			}
			if (frameSettingsOverideMask.mask[64U])
			{
				overriddenFrameSettings.lodBiasQualityLevel = overridingFrameSettings.lodBiasQualityLevel;
			}
			if (frameSettingsOverideMask.mask[63U])
			{
				overriddenFrameSettings.maximumLODLevel = overridingFrameSettings.maximumLODLevel;
			}
			if (frameSettingsOverideMask.mask[62U])
			{
				overriddenFrameSettings.maximumLODLevelMode = overridingFrameSettings.maximumLODLevelMode;
			}
			if (frameSettingsOverideMask.mask[65U])
			{
				overriddenFrameSettings.maximumLODLevelQualityLevel = overridingFrameSettings.maximumLODLevelQualityLevel;
			}
			if (frameSettingsOverideMask.mask[66U])
			{
				overriddenFrameSettings.materialQuality = overridingFrameSettings.materialQuality;
			}
			if (frameSettingsOverideMask.mask[4U])
			{
				overriddenFrameSettings.msaaMode = overridingFrameSettings.msaaMode;
			}
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x0006CCF0 File Offset: 0x0006AEF0
		internal static void Sanitize(ref FrameSettings sanitizedFrameSettings, Camera camera, RenderPipelineSettings renderPipelineSettings)
		{
			bool flag = camera.cameraType == CameraType.Reflection;
			bool flag2 = GeometryUtils.IsProjectionMatrixOblique(camera.projectionMatrix);
			bool flag3 = HDUtils.IsRegularPreviewCamera(camera);
			bool flag4 = CoreUtils.IsSceneViewFogEnabled(camera);
			bool flag5 = !flag || (flag && flag2);
			switch (renderPipelineSettings.supportedLitShaderMode)
			{
			case RenderPipelineSettings.SupportedLitShaderMode.ForwardOnly:
				sanitizedFrameSettings.litShaderMode = LitShaderMode.Forward;
				break;
			case RenderPipelineSettings.SupportedLitShaderMode.DeferredOnly:
				sanitizedFrameSettings.litShaderMode = LitShaderMode.Deferred;
				break;
			}
			ref BitArray128 ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[20U] = (ptr[20U] & !flag3);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[22U] = (ptr[22U] & (renderPipelineSettings.supportShadowMask && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[21U] = (ptr[21U] & !flag3);
			bool flag6 = HDRenderPipeline.PipelineSupportsRayTracing(renderPipelineSettings);
			ptr = ref sanitizedFrameSettings.bitDatas;
			bool flag7 = ptr[92U] = (ptr[92U] & (flag6 && !flag3 && flag5));
			if (sanitizedFrameSettings.litShaderMode > LitShaderMode.Forward || flag6 || renderPipelineSettings.supportWater)
			{
				sanitizedFrameSettings.msaaMode = MSAAMode.None;
			}
			bool flag8 = (sanitizedFrameSettings.msaaMode == MSAAMode.FromHDRPAsset) ? (renderPipelineSettings.msaaSampleCount != MSAASamples.None) : (sanitizedFrameSettings.msaaMode != MSAAMode.None);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[34U] = (ptr[34U] & (renderPipelineSettings.hdShadowInitParams.supportScreenSpaceShadows && (sanitizedFrameSettings.bitDatas[2U] & !flag8)));
			ptr = ref sanitizedFrameSettings.bitDatas;
			bool flag9 = ptr[23U] = (ptr[23U] & (renderPipelineSettings.supportSSR && !flag8 && !flag3 && flag5));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[94U] = (ptr[94U] & (flag9 && renderPipelineSettings.supportSSRTransparent && sanitizedFrameSettings.bitDatas[3U] && renderPipelineSettings.supportTransparentDepthPrepass));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[13U] = (ptr[13U] & !flag3);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[24U] = (ptr[24U] & (renderPipelineSettings.supportSSAO && !flag3 && sanitizedFrameSettings.bitDatas[2U] && flag5));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[95U] = (ptr[95U] & (renderPipelineSettings.supportSSGI && !flag3 && sanitizedFrameSettings.bitDatas[2U] && flag5));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[46U] = (ptr[46U] & renderPipelineSettings.supportSubsurfaceScattering);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[79U] = (ptr[79U] & (renderPipelineSettings.supportVolumetricClouds && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[98U] = (ptr[98U] & sanitizedFrameSettings.bitDatas[79U]);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[99U] = (ptr[99U] & (renderPipelineSettings.supportWater && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[97U] = (ptr[97U] & (sanitizedFrameSettings.bitDatas[97U] && renderPipelineSettings.supportDataDrivenLensFlare));
			ptr = ref sanitizedFrameSettings.bitDatas;
			bool flag10 = ptr[27U] = (ptr[27U] & (flag4 && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[28U] = (ptr[28U] & (renderPipelineSettings.supportVolumetrics && flag10));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[29U] = (ptr[29U] & (!flag3 && flag5));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[30U] = (ptr[30U] & (renderPipelineSettings.supportLightLayers && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[32U] = (ptr[32U] & ((!flag || (flag2 && flag)) && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[15U] = (ptr[15U] & (!flag && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[8U] = (ptr[8U] & (renderPipelineSettings.supportTransparentDepthPrepass && !flag3 && sanitizedFrameSettings.bitDatas[3U]));
			ptr = ref sanitizedFrameSettings.bitDatas;
			bool flag11 = ptr[10U] = (ptr[10U] & (renderPipelineSettings.supportMotionVectors && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[11U] = (ptr[11U] & (flag11 && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[16U] = (ptr[16U] & (flag11 && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[12U] = (ptr[12U] & (renderPipelineSettings.supportDecals && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[96U] = (ptr[96U] & (renderPipelineSettings.supportDecalLayers && sanitizedFrameSettings.bitDatas[12U]));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[9U] = (ptr[9U] & (renderPipelineSettings.supportTransparentDepthPostpass && !flag3 && sanitizedFrameSettings.bitDatas[3U]));
			ptr = ref sanitizedFrameSettings.bitDatas;
			bool flag12 = ptr[14U] = (ptr[14U] & (renderPipelineSettings.supportDistortion && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[67U] = (ptr[67U] & (flag12 && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[18U] = (ptr[18U] & (renderPipelineSettings.lowresTransparentSettings.enabled && sanitizedFrameSettings.bitDatas[3U]));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[41U] = (ptr[41U] & sanitizedFrameSettings.asyncEnabled);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[42U] = (ptr[42U] & sanitizedFrameSettings.asyncEnabled);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[43U] = (ptr[43U] & sanitizedFrameSettings.asyncEnabled);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[44U] = (ptr[44U] & (sanitizedFrameSettings.asyncEnabled && !flag7));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[45U] = (ptr[45U] & sanitizedFrameSettings.asyncEnabled);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[6U] = (ptr[6U] & renderPipelineSettings.supportCustomPass);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[6U] = (ptr[6U] & camera.cameraType != CameraType.Preview);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[39U] = (ptr[39U] & camera.cameraType != CameraType.Preview);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[120U] = (ptr[120U] & !flag8);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[127U] = (ptr[127U] & (renderPipelineSettings.supportProbeVolume && !flag3));
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[126U] = (ptr[126U] & renderPipelineSettings.supportProbeVolume);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[33U] = (ptr[33U] & !flag3);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[35U] = (ptr[35U] & !flag3);
			ptr = ref sanitizedFrameSettings.bitDatas;
			ptr[46U] = (ptr[46U] & sanitizedFrameSettings.bitDatas[2U]);
			sanitizedFrameSettings.bitDatas[68U] = false;
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x0006D506 File Offset: 0x0006B706
		internal static void AggregateFrameSettings(ref FrameSettings aggregatedFrameSettings, Camera camera, HDAdditionalCameraData additionalData, HDRenderPipelineAsset hdrpAsset)
		{
			FrameSettings.AggregateFrameSettings(ref aggregatedFrameSettings, camera, additionalData, HDRenderPipelineGlobalSettings.instance.GetDefaultFrameSettings((additionalData != null) ? additionalData.defaultFrameSettings : FrameSettingsRenderType.Camera), hdrpAsset.currentPlatformRenderPipelineSettings);
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x0006D52C File Offset: 0x0006B72C
		internal unsafe static void AggregateFrameSettings(ref FrameSettings aggregatedFrameSettings, Camera camera, HDAdditionalCameraData additionalData, ref FrameSettings defaultFrameSettings, RenderPipelineSettings supportedFeatures)
		{
			aggregatedFrameSettings = defaultFrameSettings;
			if (additionalData && additionalData.customRenderingSettings)
			{
				FrameSettings.Override(ref aggregatedFrameSettings, *additionalData.renderingPathCustomFrameSettings, additionalData.renderingPathCustomFrameSettingsOverrideMask);
			}
			FrameSettings.Sanitize(ref aggregatedFrameSettings, camera, supportedFeatures);
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x0006D56C File Offset: 0x0006B76C
		public static bool operator ==(FrameSettings a, FrameSettings b)
		{
			return a.bitDatas == b.bitDatas && a.sssQualityMode == b.sssQualityMode && a.sssQualityLevel == b.sssQualityLevel && a.sssCustomSampleBudget == b.sssCustomSampleBudget && a.lodBias == b.lodBias && a.lodBiasMode == b.lodBiasMode && a.lodBiasQualityLevel == b.lodBiasQualityLevel && a.maximumLODLevel == b.maximumLODLevel && a.maximumLODLevelMode == b.maximumLODLevelMode && a.maximumLODLevelQualityLevel == b.maximumLODLevelQualityLevel && a.materialQuality == b.materialQuality && a.msaaMode == b.msaaMode;
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x0006D62E File Offset: 0x0006B82E
		public static bool operator !=(FrameSettings a, FrameSettings b)
		{
			return !(a == b);
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x0006D63C File Offset: 0x0006B83C
		public override bool Equals(object obj)
		{
			return obj is FrameSettings && this.bitDatas.Equals(((FrameSettings)obj).bitDatas) && this.sssQualityMode.Equals(((FrameSettings)obj).sssQualityMode) && this.sssQualityLevel.Equals(((FrameSettings)obj).sssQualityLevel) && this.sssCustomSampleBudget.Equals(((FrameSettings)obj).sssCustomSampleBudget) && this.lodBias.Equals(((FrameSettings)obj).lodBias) && this.lodBiasMode.Equals(((FrameSettings)obj).lodBiasMode) && this.lodBiasQualityLevel.Equals(((FrameSettings)obj).lodBiasQualityLevel) && this.maximumLODLevel.Equals(((FrameSettings)obj).maximumLODLevel) && this.maximumLODLevelMode.Equals(((FrameSettings)obj).maximumLODLevelMode) && this.maximumLODLevelQualityLevel.Equals(((FrameSettings)obj).maximumLODLevelQualityLevel) && this.materialQuality.Equals(((FrameSettings)obj).materialQuality) && this.msaaMode.Equals(((FrameSettings)obj).msaaMode);
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x0006D7D0 File Offset: 0x0006B9D0
		public override int GetHashCode()
		{
			return (((((((((((1474027755 * -1521134295 + this.bitDatas.GetHashCode()) * -1521134295 + this.sssQualityMode.GetHashCode()) * -1521134295 + this.sssQualityLevel.GetHashCode()) * -1521134295 + this.sssCustomSampleBudget.GetHashCode()) * -1521134295 + this.lodBias.GetHashCode()) * -1521134295 + this.lodBiasMode.GetHashCode()) * -1521134295 + this.lodBiasQualityLevel.GetHashCode()) * -1521134295 + this.maximumLODLevel.GetHashCode()) * -1521134295 + this.maximumLODLevelMode.GetHashCode()) * -1521134295 + this.maximumLODLevelQualityLevel.GetHashCode()) * -1521134295 + this.materialQuality.GetHashCode()) * -1521134295 + this.msaaMode.GetHashCode();
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x0006D8E0 File Offset: 0x0006BAE0
		internal static void MigrateFromClassVersion(ref ObsoleteFrameSettings oldFrameSettingsFormat, ref FrameSettings newFrameSettingsFormat, ref FrameSettingsOverrideMask newFrameSettingsOverrideMask)
		{
			if (oldFrameSettingsFormat == null)
			{
				return;
			}
			ObsoleteLitShaderMode shaderLitMode = oldFrameSettingsFormat.shaderLitMode;
			if (shaderLitMode != ObsoleteLitShaderMode.Forward)
			{
				if (shaderLitMode != ObsoleteLitShaderMode.Deferred)
				{
					throw new ArgumentException("Unknown ObsoleteLitShaderMode");
				}
				newFrameSettingsFormat.litShaderMode = LitShaderMode.Deferred;
			}
			else
			{
				newFrameSettingsFormat.litShaderMode = LitShaderMode.Forward;
			}
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.ShadowMaps, oldFrameSettingsFormat.enableShadow);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.ContactShadows, oldFrameSettingsFormat.enableContactShadows);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Shadowmask, oldFrameSettingsFormat.enableShadowMask);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.SSR, oldFrameSettingsFormat.enableSSR);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.SSAO, oldFrameSettingsFormat.enableSSAO);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.SubsurfaceScattering, oldFrameSettingsFormat.enableSubsurfaceScattering);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Transmission, oldFrameSettingsFormat.enableTransmission);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.AtmosphericScattering, oldFrameSettingsFormat.enableAtmosphericScattering);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Volumetrics, oldFrameSettingsFormat.enableVolumetrics);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.ReprojectionForVolumetrics, oldFrameSettingsFormat.enableReprojectionForVolumetrics);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.LightLayers, oldFrameSettingsFormat.enableLightLayers);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.DepthPrepassWithDeferredRendering, oldFrameSettingsFormat.enableDepthPrepassWithDeferredRendering);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.TransparentPrepass, oldFrameSettingsFormat.enableTransparentPrepass);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.MotionVectors, oldFrameSettingsFormat.enableMotionVectors);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.ObjectMotionVectors, oldFrameSettingsFormat.enableObjectMotionVectors);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Decals, oldFrameSettingsFormat.enableDecals);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Refraction, oldFrameSettingsFormat.enableRoughRefraction);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.TransparentPostpass, oldFrameSettingsFormat.enableTransparentPostpass);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Distortion, oldFrameSettingsFormat.enableDistortion);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.Postprocess, oldFrameSettingsFormat.enablePostprocess);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.OpaqueObjects, oldFrameSettingsFormat.enableOpaqueObjects);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.TransparentObjects, oldFrameSettingsFormat.enableTransparentObjects);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.MSAA, oldFrameSettingsFormat.enableMSAA);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.ExposureControl, oldFrameSettingsFormat.enableExposureControl);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.AsyncCompute, oldFrameSettingsFormat.enableAsyncCompute);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.LightListAsync, oldFrameSettingsFormat.runLightListAsync);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.SSRAsync, oldFrameSettingsFormat.runSSRAsync);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.SSAOAsync, oldFrameSettingsFormat.runSSAOAsync);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.ContactShadowsAsync, oldFrameSettingsFormat.runContactShadowsAsync);
			newFrameSettingsFormat.SetEnabled(FrameSettingsField.VolumeVoxelizationsAsync, oldFrameSettingsFormat.runVolumeVoxelizationAsync);
			if (oldFrameSettingsFormat.lightLoopSettings != null)
			{
				newFrameSettingsFormat.SetEnabled(FrameSettingsField.DeferredTile, oldFrameSettingsFormat.lightLoopSettings.enableDeferredTileAndCluster);
				newFrameSettingsFormat.SetEnabled(FrameSettingsField.ComputeLightEvaluation, oldFrameSettingsFormat.lightLoopSettings.enableComputeLightEvaluation);
				newFrameSettingsFormat.SetEnabled(FrameSettingsField.ComputeLightVariants, oldFrameSettingsFormat.lightLoopSettings.enableComputeLightVariants);
				newFrameSettingsFormat.SetEnabled(FrameSettingsField.ComputeMaterialVariants, oldFrameSettingsFormat.lightLoopSettings.enableComputeMaterialVariants);
				newFrameSettingsFormat.SetEnabled(FrameSettingsField.FPTLForForwardOpaque, oldFrameSettingsFormat.lightLoopSettings.enableFptlForForwardOpaque);
				newFrameSettingsFormat.SetEnabled(FrameSettingsField.BigTilePrepass, oldFrameSettingsFormat.lightLoopSettings.enableBigTilePrepass);
			}
			newFrameSettingsOverrideMask.mask = default(BitArray128);
			foreach (object obj in Enum.GetValues(typeof(ObsoleteFrameSettingsOverrides)))
			{
				ObsoleteFrameSettingsOverrides obsoleteFrameSettingsOverrides = (ObsoleteFrameSettingsOverrides)obj;
				if ((obsoleteFrameSettingsOverrides & oldFrameSettingsFormat.overrides) > (ObsoleteFrameSettingsOverrides)0)
				{
					if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.TransparentPostpass)
					{
						if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.AtmosphericScaterring)
						{
							if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.SSR)
							{
								if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.VolumeVoxelizationsAsync)
								{
									newFrameSettingsOverrideMask.mask[45U] = true;
									continue;
								}
								switch (obsoleteFrameSettingsOverrides)
								{
								case ObsoleteFrameSettingsOverrides.Shadow:
									newFrameSettingsOverrideMask.mask[20U] = true;
									continue;
								case ObsoleteFrameSettingsOverrides.ContactShadow:
									newFrameSettingsOverrideMask.mask[21U] = true;
									continue;
								case ObsoleteFrameSettingsOverrides.Shadow | ObsoleteFrameSettingsOverrides.ContactShadow:
									break;
								case ObsoleteFrameSettingsOverrides.ShadowMask:
									newFrameSettingsOverrideMask.mask[22U] = true;
									continue;
								default:
									if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.SSR)
									{
										newFrameSettingsOverrideMask.mask[23U] = true;
										continue;
									}
									break;
								}
							}
							else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.SubsurfaceScattering)
							{
								if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.SSAO)
								{
									newFrameSettingsOverrideMask.mask[24U] = true;
									continue;
								}
								if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.SubsurfaceScattering)
								{
									newFrameSettingsOverrideMask.mask[46U] = true;
									continue;
								}
							}
							else
							{
								if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.Transmission)
								{
									newFrameSettingsOverrideMask.mask[26U] = true;
									continue;
								}
								if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.AtmosphericScaterring)
								{
									newFrameSettingsOverrideMask.mask[27U] = true;
									continue;
								}
							}
						}
						else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.LightLayers)
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.Volumetrics)
							{
								newFrameSettingsOverrideMask.mask[28U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.ReprojectionForVolumetrics)
							{
								newFrameSettingsOverrideMask.mask[29U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.LightLayers)
							{
								newFrameSettingsOverrideMask.mask[30U] = true;
								continue;
							}
						}
						else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.ExposureControl)
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.MSAA)
							{
								newFrameSettingsOverrideMask.mask[31U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.ExposureControl)
							{
								newFrameSettingsOverrideMask.mask[32U] = true;
								continue;
							}
						}
						else
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.TransparentPrepass)
							{
								newFrameSettingsOverrideMask.mask[8U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.TransparentPostpass)
							{
								newFrameSettingsOverrideMask.mask[9U] = true;
								continue;
							}
						}
					}
					else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.ShaderLitMode)
					{
						if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.Decals)
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.MotionVectors)
							{
								newFrameSettingsOverrideMask.mask[10U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.ObjectMotionVectors)
							{
								newFrameSettingsOverrideMask.mask[11U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.Decals)
							{
								newFrameSettingsOverrideMask.mask[12U] = true;
								continue;
							}
						}
						else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.Distortion)
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.RoughRefraction)
							{
								newFrameSettingsOverrideMask.mask[13U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.Distortion)
							{
								newFrameSettingsOverrideMask.mask[14U] = true;
								continue;
							}
						}
						else
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.Postprocess)
							{
								newFrameSettingsOverrideMask.mask[15U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.ShaderLitMode)
							{
								newFrameSettingsOverrideMask.mask[0U] = true;
								continue;
							}
						}
					}
					else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.TransparentObjects)
					{
						if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.AsyncCompute)
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.DepthPrepassWithDeferredRendering)
							{
								newFrameSettingsOverrideMask.mask[1U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.AsyncCompute)
							{
								newFrameSettingsOverrideMask.mask[40U] = true;
								continue;
							}
						}
						else
						{
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.OpaqueObjects)
							{
								newFrameSettingsOverrideMask.mask[2U] = true;
								continue;
							}
							if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.TransparentObjects)
							{
								newFrameSettingsOverrideMask.mask[3U] = true;
								continue;
							}
						}
					}
					else if (obsoleteFrameSettingsOverrides <= ObsoleteFrameSettingsOverrides.SSRAsync)
					{
						if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.LightListAsync)
						{
							newFrameSettingsOverrideMask.mask[41U] = true;
							continue;
						}
						if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.SSRAsync)
						{
							newFrameSettingsOverrideMask.mask[42U] = true;
							continue;
						}
					}
					else
					{
						if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.SSAOAsync)
						{
							newFrameSettingsOverrideMask.mask[43U] = true;
							continue;
						}
						if (obsoleteFrameSettingsOverrides == ObsoleteFrameSettingsOverrides.ContactShadowsAsync)
						{
							newFrameSettingsOverrideMask.mask[44U] = true;
							continue;
						}
					}
					throw new ArgumentException("Unknown ObsoleteFrameSettingsOverride, was " + obsoleteFrameSettingsOverrides.ToString());
				}
			}
			if (oldFrameSettingsFormat.lightLoopSettings != null)
			{
				foreach (object obj2 in Enum.GetValues(typeof(ObsoleteLightLoopSettingsOverrides)))
				{
					ObsoleteLightLoopSettingsOverrides obsoleteLightLoopSettingsOverrides = (ObsoleteLightLoopSettingsOverrides)obj2;
					if ((obsoleteLightLoopSettingsOverrides & oldFrameSettingsFormat.lightLoopSettings.overrides) > (ObsoleteLightLoopSettingsOverrides)0)
					{
						if (obsoleteLightLoopSettingsOverrides <= ObsoleteLightLoopSettingsOverrides.ComputeLightVariants)
						{
							switch (obsoleteLightLoopSettingsOverrides)
							{
							case ObsoleteLightLoopSettingsOverrides.FptlForForwardOpaque:
								newFrameSettingsOverrideMask.mask[120U] = true;
								continue;
							case ObsoleteLightLoopSettingsOverrides.BigTilePrepass:
								newFrameSettingsOverrideMask.mask[121U] = true;
								continue;
							case ObsoleteLightLoopSettingsOverrides.FptlForForwardOpaque | ObsoleteLightLoopSettingsOverrides.BigTilePrepass:
								break;
							case ObsoleteLightLoopSettingsOverrides.ComputeLightEvaluation:
								newFrameSettingsOverrideMask.mask[123U] = true;
								continue;
							default:
								if (obsoleteLightLoopSettingsOverrides == ObsoleteLightLoopSettingsOverrides.ComputeLightVariants)
								{
									newFrameSettingsOverrideMask.mask[124U] = true;
									continue;
								}
								break;
							}
						}
						else
						{
							if (obsoleteLightLoopSettingsOverrides == ObsoleteLightLoopSettingsOverrides.ComputeMaterialVariants)
							{
								newFrameSettingsOverrideMask.mask[125U] = true;
								continue;
							}
							if (obsoleteLightLoopSettingsOverrides == ObsoleteLightLoopSettingsOverrides.TileAndCluster)
							{
								newFrameSettingsOverrideMask.mask[122U] = true;
								continue;
							}
						}
						throw new ArgumentException("Unknown ObsoleteLightLoopSettingsOverrides");
					}
				}
			}
			oldFrameSettingsFormat = null;
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0006E124 File Offset: 0x0006C324
		internal static void MigrateMSAA(ref FrameSettings cameraFrameSettings, ref FrameSettingsOverrideMask newFrameSettingsOverrideMask)
		{
			if (cameraFrameSettings.IsEnabled(FrameSettingsField.MSAA))
			{
				cameraFrameSettings.msaaMode = MSAAMode.FromHDRPAsset;
			}
			else
			{
				cameraFrameSettings.msaaMode = MSAAMode.None;
			}
			newFrameSettingsOverrideMask.mask[4U] = newFrameSettingsOverrideMask.mask[31U];
			newFrameSettingsOverrideMask.mask[31U] = false;
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0006E173 File Offset: 0x0006C373
		internal static void MigrateToCustomPostprocessAndCustomPass(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.CustomPass, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.CustomPostProcess, true);
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x0006E186 File Offset: 0x0006C386
		internal static void MigrateToAfterPostprocess(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.AfterPostprocess, true);
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0006E191 File Offset: 0x0006C391
		internal static void MigrateToDefaultReflectionSettings(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.ReflectionProbe, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.PlanarProbe, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.ReplaceDiffuseForIndirect, false);
			cameraFrameSettings.SetEnabled(FrameSettingsField.SkyReflection, true);
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x0006E1B7 File Offset: 0x0006C3B7
		internal static void MigrateToNoReflectionRealtimeSettings(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.ReflectionProbe, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.PlanarProbe, false);
			cameraFrameSettings.SetEnabled(FrameSettingsField.ReplaceDiffuseForIndirect, false);
			cameraFrameSettings.SetEnabled(FrameSettingsField.SkyReflection, true);
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x0006E1DD File Offset: 0x0006C3DD
		internal static void MigrateToNoReflectionSettings(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.ReflectionProbe, false);
			cameraFrameSettings.SetEnabled(FrameSettingsField.PlanarProbe, false);
			cameraFrameSettings.SetEnabled(FrameSettingsField.ReplaceDiffuseForIndirect, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.SkyReflection, false);
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x0006E204 File Offset: 0x0006C404
		internal static void MigrateToPostProcess(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.StopNaN, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.DepthOfField, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.MotionBlur, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.PaniniProjection, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.Bloom, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.LensFlareDataDriven, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.LensDistortion, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.ChromaticAberration, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.Vignette, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.ColorGrading, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.FilmGrain, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.Dithering, true);
			cameraFrameSettings.SetEnabled(FrameSettingsField.Antialiasing, true);
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x0006E286 File Offset: 0x0006C486
		internal static void MigrateToLensFlare(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.LensFlareDataDriven, true);
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x0006E291 File Offset: 0x0006C491
		internal static void MigrateToDirectSpecularLighting(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.DirectSpecularLighting, true);
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x0006E29C File Offset: 0x0006C49C
		internal static void MigrateToNoDirectSpecularLighting(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.DirectSpecularLighting, false);
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x0006E2A7 File Offset: 0x0006C4A7
		internal static void MigrateToRayTracing(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.RayTracing, true);
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x0006E2B2 File Offset: 0x0006C4B2
		internal static void MigrateToSeparateColorGradingAndTonemapping(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.Tonemapping, true);
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0006E2BD File Offset: 0x0006C4BD
		internal static void MigrateSubsurfaceParams(ref FrameSettings fs, bool previouslyHighQuality)
		{
			fs.SetEnabled(FrameSettingsField.SubsurfaceScattering, fs.bitDatas[25U]);
			fs.sssQualityMode = (previouslyHighQuality ? SssQualityMode.OverrideQualitySettings : SssQualityMode.FromQualitySettings);
			fs.sssQualityLevel = 0;
			fs.sssCustomSampleBudget = (previouslyHighQuality ? 55 : 20);
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x0006E2F7 File Offset: 0x0006C4F7
		internal static void MigrateRoughDistortion(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.RoughDistortion, true);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x0006E302 File Offset: 0x0006C502
		internal static void MigrateVirtualTexturing(ref FrameSettings cameraFrameSettings)
		{
			cameraFrameSettings.SetEnabled(FrameSettingsField.VirtualTexturing, true);
		}

		// Token: 0x040014D6 RID: 5334
		[SerializeField]
		private BitArray128 bitDatas;

		// Token: 0x040014D7 RID: 5335
		[SerializeField]
		public float lodBias;

		// Token: 0x040014D8 RID: 5336
		[SerializeField]
		public LODBiasMode lodBiasMode;

		// Token: 0x040014D9 RID: 5337
		[SerializeField]
		public int lodBiasQualityLevel;

		// Token: 0x040014DA RID: 5338
		[SerializeField]
		public int maximumLODLevel;

		// Token: 0x040014DB RID: 5339
		[SerializeField]
		public MaximumLODLevelMode maximumLODLevelMode;

		// Token: 0x040014DC RID: 5340
		[SerializeField]
		public int maximumLODLevelQualityLevel;

		// Token: 0x040014DD RID: 5341
		[SerializeField]
		public SssQualityMode sssQualityMode;

		// Token: 0x040014DE RID: 5342
		[SerializeField]
		public int sssQualityLevel;

		// Token: 0x040014DF RID: 5343
		[SerializeField]
		public int sssCustomSampleBudget;

		// Token: 0x040014E0 RID: 5344
		[SerializeField]
		public MSAAMode msaaMode;

		// Token: 0x040014E1 RID: 5345
		internal int sssResolvedSampleBudget;

		// Token: 0x040014E2 RID: 5346
		public MaterialQuality materialQuality;

		// Token: 0x020003F9 RID: 1017
		[DebuggerDisplay("{m_Value}", Name = "{m_Label,nq}")]
		internal class DebuggerEntry
		{
			// Token: 0x060013CD RID: 5069 RVA: 0x000966A7 File Offset: 0x000948A7
			public DebuggerEntry(string label, object value)
			{
				this.m_Label = label;
				this.m_Value = value;
			}

			// Token: 0x040028A3 RID: 10403
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string m_Label;

			// Token: 0x040028A4 RID: 10404
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private object m_Value;
		}

		// Token: 0x020003FA RID: 1018
		[DebuggerDisplay("", Name = "{m_GroupName,nq}")]
		internal class DebuggerGroup
		{
			// Token: 0x060013CE RID: 5070 RVA: 0x000966BD File Offset: 0x000948BD
			public DebuggerGroup(string groupName, FrameSettings.DebuggerEntry[] entries)
			{
				this.m_GroupName = groupName;
				this.m_Entries = entries;
			}

			// Token: 0x040028A5 RID: 10405
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string m_GroupName;

			// Token: 0x040028A6 RID: 10406
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public FrameSettings.DebuggerEntry[] m_Entries;
		}

		// Token: 0x020003FB RID: 1019
		internal class FrameSettingsDebugView
		{
			// Token: 0x060013CF RID: 5071 RVA: 0x000966D3 File Offset: 0x000948D3
			public FrameSettingsDebugView(FrameSettings frameSettings)
			{
				this.m_FrameSettings = frameSettings;
			}

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x060013D0 RID: 5072 RVA: 0x000966E4 File Offset: 0x000948E4
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public FrameSettings.DebuggerGroup[] Keys
			{
				get
				{
					int length = Enum.GetValues(typeof(FrameSettingsField)).Length;
					Dictionary<FrameSettingsField, FrameSettingsFieldAttribute> dictionary = new Dictionary<FrameSettingsField, FrameSettingsFieldAttribute>();
					List<FrameSettings.DebuggerGroup> list = new List<FrameSettings.DebuggerGroup>();
					Dictionary<FrameSettingsField, string> enumNameMap = FrameSettingsFieldAttribute.GetEnumNameMap();
					Type typeFromHandle = typeof(FrameSettingsField);
					List<FrameSettingsField> list2 = new List<FrameSettingsField>();
					foreach (FrameSettingsField frameSettingsField in enumNameMap.Keys)
					{
						dictionary[frameSettingsField] = typeFromHandle.GetField(enumNameMap[frameSettingsField]).GetCustomAttribute<FrameSettingsFieldAttribute>();
						if (dictionary[frameSettingsField] == null)
						{
							list2.Add(frameSettingsField);
						}
					}
					using (IEnumerator<int> enumerator2 = (from a in dictionary.Values
					where a != null
					select a.@group).Distinct<int>().GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							int groupIndex = enumerator2.Current;
							List<FrameSettings.DebuggerGroup> list3 = list;
							string groupName = FrameSettingsHistory.foldoutNames[groupIndex];
							FrameSettings.DebuggerEntry[] entries;
							if (dictionary == null)
							{
								entries = null;
							}
							else
							{
								IEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>> enumerable = dictionary.Where(delegate(KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute> pair)
								{
									FrameSettingsFieldAttribute value2 = pair.Value;
									return value2 != null && value2.group == groupIndex;
								});
								if (enumerable == null)
								{
									entries = null;
								}
								else
								{
									entries = (from pair in enumerable
									orderby pair.Value.orderInGroup
									select pair into kvp
									select new FrameSettings.DebuggerEntry(Enum.GetName(typeof(FrameSettingsField), kvp.Key), this.m_FrameSettings.bitDatas[(uint)kvp.Key])).ToArray<FrameSettings.DebuggerEntry>();
								}
							}
							list3.Add(new FrameSettings.DebuggerGroup(groupName, entries));
						}
					}
					List<FrameSettings.DebuggerGroup> list4 = list;
					string groupName2 = "Bits without attribute";
					IEnumerable<FrameSettingsField> enumerable2 = from fs in list2
					where fs != FrameSettingsField.None
					select fs;
					list4.Add(new FrameSettings.DebuggerGroup(groupName2, (enumerable2 != null) ? (from fs in enumerable2
					select new FrameSettings.DebuggerEntry(Enum.GetName(typeof(FrameSettingsField), fs), this.m_FrameSettings.bitDatas[(uint)fs])).ToArray<FrameSettings.DebuggerEntry>() : null));
					list.Add(new FrameSettings.DebuggerGroup("Non Bit data", new FrameSettings.DebuggerEntry[]
					{
						new FrameSettings.DebuggerEntry("sssQualityMode", this.m_FrameSettings.sssQualityMode),
						new FrameSettings.DebuggerEntry("sssQualityLevel", this.m_FrameSettings.sssQualityLevel),
						new FrameSettings.DebuggerEntry("sssCustomSampleBudget", this.m_FrameSettings.sssCustomSampleBudget),
						new FrameSettings.DebuggerEntry("lodBias", this.m_FrameSettings.lodBias),
						new FrameSettings.DebuggerEntry("lodBiasMode", this.m_FrameSettings.lodBiasMode),
						new FrameSettings.DebuggerEntry("lodBiasQualityLevel", this.m_FrameSettings.lodBiasQualityLevel),
						new FrameSettings.DebuggerEntry("maximumLODLevel", this.m_FrameSettings.maximumLODLevel),
						new FrameSettings.DebuggerEntry("maximumLODLevelMode", this.m_FrameSettings.maximumLODLevelMode),
						new FrameSettings.DebuggerEntry("maximumLODLevelQualityLevel", this.m_FrameSettings.maximumLODLevelQualityLevel),
						new FrameSettings.DebuggerEntry("materialQuality", this.m_FrameSettings.materialQuality),
						new FrameSettings.DebuggerEntry("msaaMode", this.m_FrameSettings.msaaMode)
					}));
					return list.ToArray();
				}
			}

			// Token: 0x040028A7 RID: 10407
			private const int numberOfNonBitValues = 2;

			// Token: 0x040028A8 RID: 10408
			private FrameSettings m_FrameSettings;
		}
	}
}
