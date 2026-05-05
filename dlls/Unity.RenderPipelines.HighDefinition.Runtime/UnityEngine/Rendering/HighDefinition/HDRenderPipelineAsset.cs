using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000161 RID: 353
	public class HDRenderPipelineAsset : RenderPipelineAsset, IVirtualTexturingEnabledRenderPipeline, IVersionable<HDRenderPipelineAsset.Version>, IMigratableAsset
	{
		// Token: 0x06000BD7 RID: 3031 RVA: 0x0005FEBC File Offset: 0x0005E0BC
		private HDRenderPipelineAsset()
		{
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0005FF13 File Offset: 0x0005E113
		private void OnEnable()
		{
			this.Migrate();
			if (this.m_RenderPipelineSettings.dynamicResolutionSettings.lowResVolumetricCloudsMinimumThreshold == 0f)
			{
				this.m_RenderPipelineSettings.dynamicResolutionSettings.lowResVolumetricCloudsMinimumThreshold = 50f;
			}
			HDRenderPipeline.SetupDLSSFeature(HDRenderPipelineGlobalSettings.instance);
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0005FF52 File Offset: 0x0005E152
		private void Reset()
		{
			this.OnValidate();
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0005FF5A File Offset: 0x0005E15A
		protected override RenderPipeline CreatePipeline()
		{
			return new HDRenderPipeline(this);
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0005FF62 File Offset: 0x0005E162
		protected override void OnValidate()
		{
			this.isInOnValidateCall = true;
			if (GraphicsSettings.currentRenderPipeline == this)
			{
				base.OnValidate();
			}
			this.isInOnValidateCall = false;
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x0005FF85 File Offset: 0x0005E185
		private HDRenderPipelineGlobalSettings globalSettings
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x0005FF8C File Offset: 0x0005E18C
		internal HDRenderPipelineRuntimeResources renderPipelineResources
		{
			get
			{
				return this.globalSettings.renderPipelineResources;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x0005FF99 File Offset: 0x0005E199
		// (set) Token: 0x06000BDF RID: 3039 RVA: 0x0005FFA1 File Offset: 0x0005E1A1
		internal bool frameSettingsHistory { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x0005FFAC File Offset: 0x0005E1AC
		internal ReflectionSystemParameters reflectionSystemParameters
		{
			get
			{
				return new ReflectionSystemParameters
				{
					maxActivePlanarReflectionProbe = 512,
					maxActiveEnvReflectionProbe = 512
				};
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0005FFDA File Offset: 0x0005E1DA
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x0005FFE2 File Offset: 0x0005E1E2
		public RenderPipelineSettings currentPlatformRenderPipelineSettings
		{
			get
			{
				return this.m_RenderPipelineSettings;
			}
			set
			{
				this.m_RenderPipelineSettings = value;
				this.OnValidate();
			}
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0005FFF1 File Offset: 0x0005E1F1
		internal void TurnOffRayTracing()
		{
			this.m_RenderPipelineSettings.supportRayTracing = false;
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0005FFFF File Offset: 0x0005E1FF
		public MaterialQuality defaultMaterialQualityLevel
		{
			get
			{
				return this.m_DefaultMaterialQualityLevel;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x00060007 File Offset: 0x0005E207
		public override string[] renderingLayerMaskNames
		{
			get
			{
				return this.globalSettings.renderingLayerMaskNames;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x00060014 File Offset: 0x0005E214
		public override string[] prefixedRenderingLayerMaskNames
		{
			get
			{
				return this.globalSettings.prefixedRenderingLayerMaskNames;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x00060021 File Offset: 0x0005E221
		public string[] lightLayerNames
		{
			get
			{
				return this.globalSettings.lightLayerNames;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x0006002E File Offset: 0x0005E22E
		public string[] decalLayerNames
		{
			get
			{
				return this.globalSettings.decalLayerNames;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0006003B File Offset: 0x0005E23B
		public override Shader defaultShader
		{
			get
			{
				HDRenderPipelineGlobalSettings globalSettings = this.globalSettings;
				if (globalSettings == null)
				{
					return null;
				}
				HDRenderPipelineRuntimeResources renderPipelineResources = globalSettings.renderPipelineResources;
				if (renderPipelineResources == null)
				{
					return null;
				}
				return renderPipelineResources.shaders.defaultPS;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x0006005E File Offset: 0x0005E25E
		// (set) Token: 0x06000BEB RID: 3051 RVA: 0x00060066 File Offset: 0x0005E266
		internal bool useRenderGraph
		{
			get
			{
				return this.m_UseRenderGraph;
			}
			set
			{
				this.m_UseRenderGraph = value;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000BEC RID: 3052 RVA: 0x0006006F File Offset: 0x0005E26F
		public bool virtualTexturingEnabled
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x00060072 File Offset: 0x0005E272
		// (set) Token: 0x06000BEE RID: 3054 RVA: 0x0006007A File Offset: 0x0005E27A
		HDRenderPipelineAsset.Version IVersionable<HDRenderPipelineAsset.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00060084 File Offset: 0x0005E284
		private bool Migrate()
		{
			return HDRenderPipelineAsset.k_Migration.Migrate(this);
		}

		// Token: 0x04000E0A RID: 3594
		[NonSerialized]
		internal bool isInOnValidateCall;

		// Token: 0x04000E0C RID: 3596
		[SerializeField]
		[FormerlySerializedAs("renderPipelineSettings")]
		private RenderPipelineSettings m_RenderPipelineSettings = RenderPipelineSettings.NewDefault();

		// Token: 0x04000E0D RID: 3597
		[SerializeField]
		internal bool allowShaderVariantStripping = true;

		// Token: 0x04000E0E RID: 3598
		[SerializeField]
		internal bool enableSRPBatcher = true;

		// Token: 0x04000E0F RID: 3599
		[FormerlySerializedAs("materialQualityLevels")]
		public MaterialQuality availableMaterialQualityLevels = (MaterialQuality)(-1);

		// Token: 0x04000E10 RID: 3600
		[SerializeField]
		[FormerlySerializedAs("m_CurrentMaterialQualityLevel")]
		private MaterialQuality m_DefaultMaterialQualityLevel = MaterialQuality.High;

		// Token: 0x04000E11 RID: 3601
		[SerializeField]
		[Obsolete("Use HDRP Global Settings' diffusionProfileSettingsList instead")]
		internal DiffusionProfileSettings diffusionProfileSettings;

		// Token: 0x04000E12 RID: 3602
		[SerializeField]
		internal VirtualTexturingSettingsSRP virtualTexturingSettings = new VirtualTexturingSettingsSRP();

		// Token: 0x04000E13 RID: 3603
		[SerializeField]
		private bool m_UseRenderGraph = true;

		// Token: 0x04000E14 RID: 3604
		private static readonly MigrationDescription<HDRenderPipelineAsset.Version, HDRenderPipelineAsset> k_Migration = MigrationDescription.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(new MigrationStep<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>[]
		{
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.UpgradeFrameSettingsToStruct, delegate(HDRenderPipelineAsset data)
			{
				FrameSettingsOverrideMask frameSettingsOverrideMask = default(FrameSettingsOverrideMask);
				if (data.m_ObsoleteFrameSettings != null)
				{
					FrameSettings.MigrateFromClassVersion(ref data.m_ObsoleteFrameSettings, ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings, ref frameSettingsOverrideMask);
				}
				if (data.m_ObsoleteBakedOrCustomReflectionFrameSettings != null)
				{
					FrameSettings.MigrateFromClassVersion(ref data.m_ObsoleteBakedOrCustomReflectionFrameSettings, ref data.m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings, ref frameSettingsOverrideMask);
				}
				if (data.m_ObsoleteRealtimeReflectionFrameSettings != null)
				{
					FrameSettings.MigrateFromClassVersion(ref data.m_ObsoleteRealtimeReflectionFrameSettings, ref data.m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings, ref frameSettingsOverrideMask);
				}
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddAfterPostProcessFrameSetting, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToAfterPostprocess(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddReflectionSettings, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToDefaultReflectionSettings(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateToNoReflectionSettings(ref data.m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateToNoReflectionRealtimeSettings(ref data.m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddPostProcessFrameSettings, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToPostProcess(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddRayTracingFrameSettings, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToRayTracing(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddFrameSettingDirectSpecularLighting, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToDirectSpecularLighting(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateToNoDirectSpecularLighting(ref data.m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateToDirectSpecularLighting(ref data.m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddCustomPostprocessAndCustomPass, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToCustomPostprocessAndCustomPass(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.ScalableSettingsRefactor, delegate(HDRenderPipelineAsset data)
			{
				data.m_RenderPipelineSettings.hdShadowInitParams.shadowResolutionArea.schemaId = ScalableSettingSchemaId.With4Levels;
				data.m_RenderPipelineSettings.hdShadowInitParams.shadowResolutionDirectional.schemaId = ScalableSettingSchemaId.With4Levels;
				data.m_RenderPipelineSettings.hdShadowInitParams.shadowResolutionPunctual.schemaId = ScalableSettingSchemaId.With4Levels;
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.ShadowFilteringVeryHighQualityRemoval, delegate(HDRenderPipelineAsset data)
			{
				ref HDShadowInitParameters ptr = ref data.m_RenderPipelineSettings.hdShadowInitParams;
				ptr.shadowFilteringQuality = ((ptr.shadowFilteringQuality > HDShadowFilteringQuality.High) ? HDShadowFilteringQuality.High : ptr.shadowFilteringQuality);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.SeparateColorGradingAndTonemappingFrameSettings, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateToSeparateColorGradingAndTonemapping(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.ReplaceTextureArraysByAtlasForCookieAndPlanar, delegate(HDRenderPipelineAsset data)
			{
				ref GlobalLightLoopSettings ptr = ref data.m_RenderPipelineSettings.lightLoopSettings;
				float num = Mathf.Sqrt((float)(ptr.cookieAtlasSize * ptr.cookieAtlasSize * (CookieAtlasResolution)ptr.cookieTexArraySize));
				float num2 = Mathf.Sqrt((float)(ptr.planarReflectionAtlasSize * ptr.planarReflectionAtlasSize * (PlanarReflectionAtlasResolution)ptr.maxPlanarReflectionOnScreen));
				num = (float)Mathf.NextPowerOfTwo((int)num);
				num2 = (float)Mathf.NextPowerOfTwo((int)num2);
				num = Mathf.Clamp(num, 256f, 8192f);
				num2 = Mathf.Clamp(num2, 256f, 8192f);
				ptr.cookieAtlasSize = (CookieAtlasResolution)num;
				ptr.planarReflectionAtlasSize = (PlanarReflectionAtlasResolution)num2;
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddedAdaptiveSSS, delegate(HDRenderPipelineAsset data)
			{
				bool obsoleteincreaseSssSampleCount = data.m_RenderPipelineSettings.m_ObsoleteincreaseSssSampleCount;
				FrameSettings.MigrateSubsurfaceParams(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings, obsoleteincreaseSssSampleCount);
				FrameSettings.MigrateSubsurfaceParams(ref data.m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings, obsoleteincreaseSssSampleCount);
				FrameSettings.MigrateSubsurfaceParams(ref data.m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings, obsoleteincreaseSssSampleCount);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.RemoveCookieCubeAtlasToOctahedral2D, delegate(HDRenderPipelineAsset data)
			{
				ref GlobalLightLoopSettings ptr = ref data.m_RenderPipelineSettings.lightLoopSettings;
				Mathf.Sqrt((float)(ptr.cookieAtlasSize * ptr.cookieAtlasSize * (CookieAtlasResolution)ptr.cookieTexArraySize));
				Mathf.Sqrt((float)(ptr.planarReflectionAtlasSize * ptr.planarReflectionAtlasSize * (PlanarReflectionAtlasResolution)ptr.maxPlanarReflectionOnScreen));
				Debug.Log("HDRP Internally changed the storage of Cube Cookie to use Octahedral Projection inside the 2D Cookie Atlas. It is recommended that you increase the size of the 2D Cookie Atlas if your cookies no longer fit. To fix this, select your HDRP Asset and in the Inspector, go to Lighting > Cookies. In the 2D Atlas Size drop-down, select a larger cookie resolution.");
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.RoughDistortion, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateRoughDistortion(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateRoughDistortion(ref data.m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateRoughDistortion(ref data.m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.VirtualTexturing, delegate(HDRenderPipelineAsset data)
			{
				FrameSettings.MigrateVirtualTexturing(ref data.m_ObsoleteFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateVirtualTexturing(ref data.m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings);
				FrameSettings.MigrateVirtualTexturing(ref data.m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings);
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.AddedHDRenderPipelineGlobalSettings, delegate(HDRenderPipelineAsset data)
			{
				data.m_ObsoleteDefaultVolumeProfile = null;
				data.m_ObsoleteDefaultLookDevProfile = null;
				data.m_ObsoleteRenderPipelineResources = null;
				data.m_ObsoleteRenderPipelineRayTracingResources = null;
				data.m_ObsoleteBeforeTransparentCustomPostProcesses = null;
				data.m_ObsoleteBeforePostProcessCustomPostProcesses = null;
				data.m_ObsoleteAfterPostProcessCustomPostProcesses = null;
				data.m_ObsoleteBeforeTAACustomPostProcesses = null;
				data.m_ObsoleteDiffusionProfileSettingsList = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName0 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName1 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName2 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName3 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName4 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName5 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName6 = null;
				data.m_RenderPipelineSettings.m_ObsoleteLightLayerName7 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName0 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName1 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName2 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName3 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName4 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName5 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName6 = null;
				data.m_RenderPipelineSettings.m_ObsoleteDecalLayerName7 = null;
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.DecalSurfaceGradient, delegate(HDRenderPipelineAsset data)
			{
				data.m_RenderPipelineSettings.supportSurfaceGradient = false;
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.RemovalOfUpscaleFilter, delegate(HDRenderPipelineAsset data)
			{
				if (data.m_RenderPipelineSettings.dynamicResolutionSettings.upsampleFilter == DynamicResUpscaleFilter.Bilinear)
				{
					data.m_RenderPipelineSettings.dynamicResolutionSettings.upsampleFilter = DynamicResUpscaleFilter.CatmullRom;
				}
				if (data.m_RenderPipelineSettings.dynamicResolutionSettings.upsampleFilter == DynamicResUpscaleFilter.Lanczos)
				{
					data.m_RenderPipelineSettings.dynamicResolutionSettings.upsampleFilter = DynamicResUpscaleFilter.ContrastAdaptiveSharpen;
				}
			}),
			MigrationStep.New<HDRenderPipelineAsset.Version, HDRenderPipelineAsset>(HDRenderPipelineAsset.Version.CombinedPlanarAndCubemapReflectionAtlases, delegate(HDRenderPipelineAsset data)
			{
				ref GlobalLightLoopSettings ptr = ref data.m_RenderPipelineSettings.lightLoopSettings;
				CubeReflectionResolution reflectionCubemapSize = ptr.reflectionCubemapSize;
				CubeReflectionResolution[] array = (CubeReflectionResolution[])Enum.GetValues(typeof(CubeReflectionResolution));
				int num = Mathf.Max(Array.IndexOf<CubeReflectionResolution>(array, reflectionCubemapSize), 0);
				CubeReflectionResolution[] values = new CubeReflectionResolution[]
				{
					array[Mathf.Min(num, array.Length - 1)],
					array[Mathf.Min(num + 1, array.Length - 1)],
					array[Mathf.Min(num + 2, array.Length - 1)]
				};
				data.m_RenderPipelineSettings.cubeReflectionResolution = new RenderPipelineSettings.ReflectionProbeResolutionScalableSetting(values, ScalableSettingSchemaId.With3Levels);
				int reflectionProbeSizeInAtlas = ReflectionProbeTextureCache.GetReflectionProbeSizeInAtlas((int)ptr.reflectionCubemapSize);
				int num2 = ptr.reflectionProbeCacheSize * reflectionProbeSizeInAtlas * reflectionProbeSizeInAtlas;
				int num3 = (int)(ptr.planarReflectionAtlasSize * ptr.planarReflectionAtlasSize);
				int num4 = num2 + num3;
				ptr.reflectionProbeTexCacheSize = ReflectionProbeTextureCacheResolution.Resolution16384x16384;
				foreach (ReflectionProbeTextureCacheResolution reflectionProbeTextureCacheResolution in from ReflectionProbeTextureCacheResolution r in Enum.GetValues(typeof(ReflectionProbeTextureCacheResolution))
				orderby (int)(r & (ReflectionProbeTextureCacheResolution)65535)
				select r)
				{
					int num5 = (int)(reflectionProbeTextureCacheResolution & (ReflectionProbeTextureCacheResolution)65535);
					int num6 = (int)(reflectionProbeTextureCacheResolution >> 16);
					if (num6 == 0)
					{
						num6 = num5;
					}
					if (num6 * num5 >= num4)
					{
						ptr.reflectionProbeTexCacheSize = reflectionProbeTextureCacheResolution;
						break;
					}
				}
				ptr.maxCubeReflectionOnScreen = Mathf.Clamp(ptr.maxEnvLightsOnScreen - ptr.maxPlanarReflectionOnScreen, 64, 128);
			})
		});

		// Token: 0x04000E15 RID: 3605
		[SerializeField]
		private HDRenderPipelineAsset.Version m_Version = MigrationDescription.LastVersion<HDRenderPipelineAsset.Version>();

		// Token: 0x04000E16 RID: 3606
		[SerializeField]
		[FormerlySerializedAs("serializedFrameSettings")]
		[FormerlySerializedAs("m_FrameSettings")]
		[Obsolete("For data migration")]
		private ObsoleteFrameSettings m_ObsoleteFrameSettings;

		// Token: 0x04000E17 RID: 3607
		[SerializeField]
		[FormerlySerializedAs("m_BakedOrCustomReflectionFrameSettings")]
		[Obsolete("For data migration")]
		private ObsoleteFrameSettings m_ObsoleteBakedOrCustomReflectionFrameSettings;

		// Token: 0x04000E18 RID: 3608
		[SerializeField]
		[FormerlySerializedAs("m_RealtimeReflectionFrameSettings")]
		[Obsolete("For data migration")]
		private ObsoleteFrameSettings m_ObsoleteRealtimeReflectionFrameSettings;

		// Token: 0x04000E19 RID: 3609
		[SerializeField]
		[FormerlySerializedAs("m_DefaultVolumeProfile")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal VolumeProfile m_ObsoleteDefaultVolumeProfile;

		// Token: 0x04000E1A RID: 3610
		[SerializeField]
		[FormerlySerializedAs("m_DefaultLookDevProfile")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal VolumeProfile m_ObsoleteDefaultLookDevProfile;

		// Token: 0x04000E1B RID: 3611
		[SerializeField]
		[FormerlySerializedAs("m_RenderingPathDefaultCameraFrameSettings")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal FrameSettings m_ObsoleteFrameSettingsMovedToDefaultSettings;

		// Token: 0x04000E1C RID: 3612
		[SerializeField]
		[FormerlySerializedAs("m_RenderingPathDefaultBakedOrCustomReflectionFrameSettings")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal FrameSettings m_ObsoleteBakedOrCustomReflectionFrameSettingsMovedToDefaultSettings;

		// Token: 0x04000E1D RID: 3613
		[SerializeField]
		[FormerlySerializedAs("m_RenderingPathDefaultRealtimeReflectionFrameSettings")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal FrameSettings m_ObsoleteRealtimeReflectionFrameSettingsMovedToDefaultSettings;

		// Token: 0x04000E1E RID: 3614
		[SerializeField]
		[FormerlySerializedAs("m_RenderPipelineResources")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal HDRenderPipelineRuntimeResources m_ObsoleteRenderPipelineResources;

		// Token: 0x04000E1F RID: 3615
		[SerializeField]
		[FormerlySerializedAs("m_RenderPipelineRayTracingResources")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal HDRenderPipelineRayTracingResources m_ObsoleteRenderPipelineRayTracingResources;

		// Token: 0x04000E20 RID: 3616
		[SerializeField]
		[FormerlySerializedAs("beforeTransparentCustomPostProcesses")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal List<string> m_ObsoleteBeforeTransparentCustomPostProcesses;

		// Token: 0x04000E21 RID: 3617
		[SerializeField]
		[FormerlySerializedAs("beforePostProcessCustomPostProcesses")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal List<string> m_ObsoleteBeforePostProcessCustomPostProcesses;

		// Token: 0x04000E22 RID: 3618
		[SerializeField]
		[FormerlySerializedAs("afterPostProcessCustomPostProcesses")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal List<string> m_ObsoleteAfterPostProcessCustomPostProcesses;

		// Token: 0x04000E23 RID: 3619
		[SerializeField]
		[FormerlySerializedAs("beforeTAACustomPostProcesses")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal List<string> m_ObsoleteBeforeTAACustomPostProcesses;

		// Token: 0x04000E24 RID: 3620
		[SerializeField]
		[FormerlySerializedAs("shaderVariantLogLevel")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal int m_ObsoleteShaderVariantLogLevel;

		// Token: 0x04000E25 RID: 3621
		[SerializeField]
		[FormerlySerializedAs("m_LensAttenuation")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal LensAttenuationMode m_ObsoleteLensAttenuation;

		// Token: 0x04000E26 RID: 3622
		[SerializeField]
		[FormerlySerializedAs("diffusionProfileSettingsList")]
		[Obsolete("Moved from HDRPAsset to HDGlobal Settings")]
		internal DiffusionProfileSettings[] m_ObsoleteDiffusionProfileSettingsList;

		// Token: 0x020003BD RID: 957
		private enum Version
		{
			// Token: 0x04002656 RID: 9814
			None,
			// Token: 0x04002657 RID: 9815
			First,
			// Token: 0x04002658 RID: 9816
			UpgradeFrameSettingsToStruct,
			// Token: 0x04002659 RID: 9817
			AddAfterPostProcessFrameSetting,
			// Token: 0x0400265A RID: 9818
			AddFrameSettingSpecularLighting = 5,
			// Token: 0x0400265B RID: 9819
			AddReflectionSettings,
			// Token: 0x0400265C RID: 9820
			AddPostProcessFrameSettings,
			// Token: 0x0400265D RID: 9821
			AddRayTracingFrameSettings,
			// Token: 0x0400265E RID: 9822
			AddFrameSettingDirectSpecularLighting,
			// Token: 0x0400265F RID: 9823
			AddCustomPostprocessAndCustomPass,
			// Token: 0x04002660 RID: 9824
			ScalableSettingsRefactor,
			// Token: 0x04002661 RID: 9825
			ShadowFilteringVeryHighQualityRemoval,
			// Token: 0x04002662 RID: 9826
			SeparateColorGradingAndTonemappingFrameSettings,
			// Token: 0x04002663 RID: 9827
			ReplaceTextureArraysByAtlasForCookieAndPlanar,
			// Token: 0x04002664 RID: 9828
			AddedAdaptiveSSS,
			// Token: 0x04002665 RID: 9829
			RemoveCookieCubeAtlasToOctahedral2D,
			// Token: 0x04002666 RID: 9830
			RoughDistortion,
			// Token: 0x04002667 RID: 9831
			VirtualTexturing,
			// Token: 0x04002668 RID: 9832
			AddedHDRenderPipelineGlobalSettings,
			// Token: 0x04002669 RID: 9833
			DecalSurfaceGradient,
			// Token: 0x0400266A RID: 9834
			RemovalOfUpscaleFilter,
			// Token: 0x0400266B RID: 9835
			CombinedPlanarAndCubemapReflectionAtlases
		}
	}
}
