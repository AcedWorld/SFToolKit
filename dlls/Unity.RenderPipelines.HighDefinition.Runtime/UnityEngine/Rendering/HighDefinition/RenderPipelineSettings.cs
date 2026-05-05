using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B9 RID: 441
	[Serializable]
	public struct RenderPipelineSettings
	{
		// Token: 0x06000D81 RID: 3457 RVA: 0x0006EA54 File Offset: 0x0006CC54
		internal static RenderPipelineSettings NewDefault()
		{
			return new RenderPipelineSettings
			{
				supportShadowMask = true,
				supportSSAO = true,
				supportSubsurfaceScattering = true,
				sssSampleBudget = new IntScalableSetting(new int[]
				{
					20,
					40,
					80
				}, ScalableSettingSchemaId.With3Levels),
				supportVolumetrics = true,
				supportDistortion = true,
				supportTransparentBackface = true,
				supportTransparentDepthPrepass = true,
				supportTransparentDepthPostpass = true,
				colorBufferFormat = RenderPipelineSettings.ColorBufferFormat.R11G11B10,
				supportCustomPass = true,
				customBufferFormat = RenderPipelineSettings.CustomBufferFormat.R8G8B8A8,
				supportedLitShaderMode = RenderPipelineSettings.SupportedLitShaderMode.DeferredOnly,
				supportDecals = true,
				supportDecalLayers = false,
				supportSurfaceGradient = true,
				decalNormalBufferHP = false,
				msaaSampleCount = MSAASamples.None,
				supportMotionVectors = true,
				supportRuntimeAOVAPI = false,
				supportDitheringCrossFade = true,
				supportTerrainHole = false,
				supportWater = false,
				waterSimulationResolution = WaterSimulationResolution.Medium128,
				waterCPUSimulation = false,
				supportDataDrivenLensFlare = true,
				planarReflectionResolution = new RenderPipelineSettings.PlanarReflectionAtlasResolutionScalableSetting(new PlanarReflectionAtlasResolution[]
				{
					PlanarReflectionAtlasResolution.Resolution256,
					PlanarReflectionAtlasResolution.Resolution1024,
					PlanarReflectionAtlasResolution.Resolution2048
				}, ScalableSettingSchemaId.With3Levels),
				cubeReflectionResolution = new RenderPipelineSettings.ReflectionProbeResolutionScalableSetting(new CubeReflectionResolution[]
				{
					CubeReflectionResolution.CubeReflectionResolution128,
					CubeReflectionResolution.CubeReflectionResolution256,
					CubeReflectionResolution.CubeReflectionResolution512
				}, ScalableSettingSchemaId.With3Levels),
				lightLoopSettings = GlobalLightLoopSettings.NewDefault(),
				hdShadowInitParams = HDShadowInitParameters.NewDefault(),
				decalSettings = GlobalDecalSettings.NewDefault(),
				postProcessSettings = GlobalPostProcessSettings.NewDefault(),
				dynamicResolutionSettings = GlobalDynamicResolutionSettings.NewDefault(),
				lowresTransparentSettings = GlobalLowResolutionTransparencySettings.NewDefault(),
				xrSettings = GlobalXRSettings.NewDefault(),
				postProcessQualitySettings = GlobalPostProcessingQualitySettings.NewDefault(),
				lightingQualitySettings = GlobalLightingQualitySettings.NewDefault(),
				lightSettings = RenderPipelineSettings.LightSettings.NewDefault(),
				supportRayTracing = false,
				supportedRayTracingMode = RenderPipelineSettings.SupportedRayTracingMode.Both,
				lodBias = new FloatScalableSetting(new float[]
				{
					1f,
					1f,
					1f
				}, ScalableSettingSchemaId.With3Levels),
				maximumLODLevel = new IntScalableSetting(new int[3], ScalableSettingSchemaId.With3Levels),
				lightProbeSystem = RenderPipelineSettings.LightProbeSystem.LegacyLightProbes,
				probeVolumeMemoryBudget = ProbeVolumeTextureMemoryBudget.MemoryBudgetMedium,
				probeVolumeBlendingMemoryBudget = ProbeVolumeBlendingTextureMemoryBudget.MemoryBudgetLow,
				supportProbeVolumeStreaming = false,
				probeVolumeSHBands = ProbeVolumeSHBands.SphericalHarmonicsL1
			};
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000D82 RID: 3458 RVA: 0x0006EC8E File Offset: 0x0006CE8E
		// (set) Token: 0x06000D83 RID: 3459 RVA: 0x0006EC9A File Offset: 0x0006CE9A
		public string lightLayerName0
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName0;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName0 = value;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000D84 RID: 3460 RVA: 0x0006ECA7 File Offset: 0x0006CEA7
		// (set) Token: 0x06000D85 RID: 3461 RVA: 0x0006ECB3 File Offset: 0x0006CEB3
		public string lightLayerName1
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName1;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName1 = value;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000D86 RID: 3462 RVA: 0x0006ECC0 File Offset: 0x0006CEC0
		// (set) Token: 0x06000D87 RID: 3463 RVA: 0x0006ECCC File Offset: 0x0006CECC
		public string lightLayerName2
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName2;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName2 = value;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x0006ECD9 File Offset: 0x0006CED9
		// (set) Token: 0x06000D89 RID: 3465 RVA: 0x0006ECE5 File Offset: 0x0006CEE5
		public string lightLayerName3
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName3;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName3 = value;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000D8A RID: 3466 RVA: 0x0006ECF2 File Offset: 0x0006CEF2
		// (set) Token: 0x06000D8B RID: 3467 RVA: 0x0006ECFE File Offset: 0x0006CEFE
		public string lightLayerName4
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName4;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName4 = value;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x0006ED0B File Offset: 0x0006CF0B
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x0006ED17 File Offset: 0x0006CF17
		public string lightLayerName5
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName5;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName5 = value;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x0006ED24 File Offset: 0x0006CF24
		// (set) Token: 0x06000D8F RID: 3471 RVA: 0x0006ED30 File Offset: 0x0006CF30
		public string lightLayerName6
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName6;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName6 = value;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000D90 RID: 3472 RVA: 0x0006ED3D File Offset: 0x0006CF3D
		// (set) Token: 0x06000D91 RID: 3473 RVA: 0x0006ED49 File Offset: 0x0006CF49
		public string lightLayerName7
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.lightLayerName7;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.lightLayerName7 = value;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000D92 RID: 3474 RVA: 0x0006ED56 File Offset: 0x0006CF56
		// (set) Token: 0x06000D93 RID: 3475 RVA: 0x0006ED62 File Offset: 0x0006CF62
		public string decalLayerName0
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName0;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName0 = value;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000D94 RID: 3476 RVA: 0x0006ED6F File Offset: 0x0006CF6F
		// (set) Token: 0x06000D95 RID: 3477 RVA: 0x0006ED7B File Offset: 0x0006CF7B
		public string decalLayerName1
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName1;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName1 = value;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000D96 RID: 3478 RVA: 0x0006ED88 File Offset: 0x0006CF88
		// (set) Token: 0x06000D97 RID: 3479 RVA: 0x0006ED94 File Offset: 0x0006CF94
		public string decalLayerName2
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName2;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName2 = value;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000D98 RID: 3480 RVA: 0x0006EDA1 File Offset: 0x0006CFA1
		// (set) Token: 0x06000D99 RID: 3481 RVA: 0x0006EDAD File Offset: 0x0006CFAD
		public string decalLayerName3
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName3;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName3 = value;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000D9A RID: 3482 RVA: 0x0006EDBA File Offset: 0x0006CFBA
		// (set) Token: 0x06000D9B RID: 3483 RVA: 0x0006EDC6 File Offset: 0x0006CFC6
		public string decalLayerName4
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName4;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName4 = value;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000D9C RID: 3484 RVA: 0x0006EDD3 File Offset: 0x0006CFD3
		// (set) Token: 0x06000D9D RID: 3485 RVA: 0x0006EDDF File Offset: 0x0006CFDF
		public string decalLayerName5
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName5;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName5 = value;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000D9E RID: 3486 RVA: 0x0006EDEC File Offset: 0x0006CFEC
		// (set) Token: 0x06000D9F RID: 3487 RVA: 0x0006EDF8 File Offset: 0x0006CFF8
		public string decalLayerName6
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName6;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName6 = value;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x0006EE05 File Offset: 0x0006D005
		// (set) Token: 0x06000DA1 RID: 3489 RVA: 0x0006EE11 File Offset: 0x0006D011
		public string decalLayerName7
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.decalLayerName7;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.decalLayerName7 = value;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x0006EE1E File Offset: 0x0006D01E
		[Obsolete]
		public bool supportMSAA
		{
			get
			{
				return this.msaaSampleCount != MSAASamples.None;
			}
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x0006EE2C File Offset: 0x0006D02C
		internal bool SupportsAlpha()
		{
			return CoreUtils.IsSceneFilteringEnabled() || this.colorBufferFormat == RenderPipelineSettings.ColorBufferFormat.R16G16B16A16;
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x0006EE41 File Offset: 0x0006D041
		// (set) Token: 0x06000DA5 RID: 3493 RVA: 0x0006EE4D File Offset: 0x0006D04D
		public bool supportRuntimeDebugDisplay
		{
			get
			{
				return HDRenderPipelineGlobalSettings.instance.supportRuntimeDebugDisplay;
			}
			set
			{
				HDRenderPipelineGlobalSettings.instance.supportRuntimeDebugDisplay = value;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000DA6 RID: 3494 RVA: 0x0006EE5A File Offset: 0x0006D05A
		internal bool supportProbeVolume
		{
			get
			{
				return this.lightProbeSystem == RenderPipelineSettings.LightProbeSystem.ProbeVolumes;
			}
		}

		// Token: 0x0400154A RID: 5450
		public bool supportShadowMask;

		// Token: 0x0400154B RID: 5451
		public bool supportSSR;

		// Token: 0x0400154C RID: 5452
		public bool supportSSRTransparent;

		// Token: 0x0400154D RID: 5453
		public bool supportSSAO;

		// Token: 0x0400154E RID: 5454
		public bool supportSSGI;

		// Token: 0x0400154F RID: 5455
		public bool supportSubsurfaceScattering;

		// Token: 0x04001550 RID: 5456
		public IntScalableSetting sssSampleBudget;

		// Token: 0x04001551 RID: 5457
		public bool supportVolumetrics;

		// Token: 0x04001552 RID: 5458
		public bool supportVolumetricClouds;

		// Token: 0x04001553 RID: 5459
		public bool supportLightLayers;

		// Token: 0x04001554 RID: 5460
		public bool supportWater;

		// Token: 0x04001555 RID: 5461
		public WaterSimulationResolution waterSimulationResolution;

		// Token: 0x04001556 RID: 5462
		public bool waterCPUSimulation;

		// Token: 0x04001557 RID: 5463
		public bool supportDistortion;

		// Token: 0x04001558 RID: 5464
		public bool supportTransparentBackface;

		// Token: 0x04001559 RID: 5465
		public bool supportTransparentDepthPrepass;

		// Token: 0x0400155A RID: 5466
		public bool supportTransparentDepthPostpass;

		// Token: 0x0400155B RID: 5467
		public RenderPipelineSettings.ColorBufferFormat colorBufferFormat;

		// Token: 0x0400155C RID: 5468
		public bool supportCustomPass;

		// Token: 0x0400155D RID: 5469
		public RenderPipelineSettings.CustomBufferFormat customBufferFormat;

		// Token: 0x0400155E RID: 5470
		public RenderPipelineSettings.SupportedLitShaderMode supportedLitShaderMode;

		// Token: 0x0400155F RID: 5471
		public RenderPipelineSettings.PlanarReflectionAtlasResolutionScalableSetting planarReflectionResolution;

		// Token: 0x04001560 RID: 5472
		public RenderPipelineSettings.ReflectionProbeResolutionScalableSetting cubeReflectionResolution;

		// Token: 0x04001561 RID: 5473
		public bool supportDecals;

		// Token: 0x04001562 RID: 5474
		public bool supportDecalLayers;

		// Token: 0x04001563 RID: 5475
		public bool supportSurfaceGradient;

		// Token: 0x04001564 RID: 5476
		public bool decalNormalBufferHP;

		// Token: 0x04001565 RID: 5477
		public MSAASamples msaaSampleCount;

		// Token: 0x04001566 RID: 5478
		public bool supportMotionVectors;

		// Token: 0x04001567 RID: 5479
		public bool supportDataDrivenLensFlare;

		// Token: 0x04001568 RID: 5480
		public bool supportRuntimeAOVAPI;

		// Token: 0x04001569 RID: 5481
		public bool supportDitheringCrossFade;

		// Token: 0x0400156A RID: 5482
		public bool supportTerrainHole;

		// Token: 0x0400156B RID: 5483
		public RenderPipelineSettings.LightProbeSystem lightProbeSystem;

		// Token: 0x0400156C RID: 5484
		public ProbeVolumeTextureMemoryBudget probeVolumeMemoryBudget;

		// Token: 0x0400156D RID: 5485
		public ProbeVolumeBlendingTextureMemoryBudget probeVolumeBlendingMemoryBudget;

		// Token: 0x0400156E RID: 5486
		public bool supportProbeVolumeStreaming;

		// Token: 0x0400156F RID: 5487
		public ProbeVolumeSHBands probeVolumeSHBands;

		// Token: 0x04001570 RID: 5488
		public bool supportRayTracing;

		// Token: 0x04001571 RID: 5489
		public RenderPipelineSettings.SupportedRayTracingMode supportedRayTracingMode;

		// Token: 0x04001572 RID: 5490
		public GlobalLightLoopSettings lightLoopSettings;

		// Token: 0x04001573 RID: 5491
		public HDShadowInitParameters hdShadowInitParams;

		// Token: 0x04001574 RID: 5492
		public GlobalDecalSettings decalSettings;

		// Token: 0x04001575 RID: 5493
		public GlobalPostProcessSettings postProcessSettings;

		// Token: 0x04001576 RID: 5494
		public GlobalDynamicResolutionSettings dynamicResolutionSettings;

		// Token: 0x04001577 RID: 5495
		public GlobalLowResolutionTransparencySettings lowresTransparentSettings;

		// Token: 0x04001578 RID: 5496
		public GlobalXRSettings xrSettings;

		// Token: 0x04001579 RID: 5497
		public GlobalPostProcessingQualitySettings postProcessQualitySettings;

		// Token: 0x0400157A RID: 5498
		public RenderPipelineSettings.LightSettings lightSettings;

		// Token: 0x0400157B RID: 5499
		public IntScalableSetting maximumLODLevel;

		// Token: 0x0400157C RID: 5500
		public FloatScalableSetting lodBias;

		// Token: 0x0400157D RID: 5501
		public GlobalLightingQualitySettings lightingQualitySettings;

		// Token: 0x0400157E RID: 5502
		[Obsolete("For data migration")]
		internal bool m_ObsoleteincreaseSssSampleCount;

		// Token: 0x0400157F RID: 5503
		[SerializeField]
		[FormerlySerializedAs("lightLayerName0")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName0;

		// Token: 0x04001580 RID: 5504
		[SerializeField]
		[FormerlySerializedAs("lightLayerName1")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName1;

		// Token: 0x04001581 RID: 5505
		[SerializeField]
		[FormerlySerializedAs("lightLayerName2")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName2;

		// Token: 0x04001582 RID: 5506
		[SerializeField]
		[FormerlySerializedAs("lightLayerName3")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName3;

		// Token: 0x04001583 RID: 5507
		[SerializeField]
		[FormerlySerializedAs("lightLayerName4")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName4;

		// Token: 0x04001584 RID: 5508
		[SerializeField]
		[FormerlySerializedAs("lightLayerName5")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName5;

		// Token: 0x04001585 RID: 5509
		[SerializeField]
		[FormerlySerializedAs("lightLayerName6")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName6;

		// Token: 0x04001586 RID: 5510
		[SerializeField]
		[FormerlySerializedAs("lightLayerName7")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteLightLayerName7;

		// Token: 0x04001587 RID: 5511
		[SerializeField]
		[FormerlySerializedAs("decalLayerName0")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName0;

		// Token: 0x04001588 RID: 5512
		[SerializeField]
		[FormerlySerializedAs("decalLayerName1")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName1;

		// Token: 0x04001589 RID: 5513
		[SerializeField]
		[FormerlySerializedAs("decalLayerName2")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName2;

		// Token: 0x0400158A RID: 5514
		[SerializeField]
		[FormerlySerializedAs("decalLayerName3")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName3;

		// Token: 0x0400158B RID: 5515
		[SerializeField]
		[FormerlySerializedAs("decalLayerName4")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName4;

		// Token: 0x0400158C RID: 5516
		[SerializeField]
		[FormerlySerializedAs("decalLayerName5")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName5;

		// Token: 0x0400158D RID: 5517
		[SerializeField]
		[FormerlySerializedAs("decalLayerName6")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName6;

		// Token: 0x0400158E RID: 5518
		[SerializeField]
		[FormerlySerializedAs("decalLayerName7")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal string m_ObsoleteDecalLayerName7;

		// Token: 0x0400158F RID: 5519
		[SerializeField]
		[FormerlySerializedAs("supportRuntimeDebugDisplay")]
		[Obsolete("Moved to HDGlobal Settings")]
		internal bool m_ObsoleteSupportRuntimeDebugDisplay;

		// Token: 0x02000400 RID: 1024
		public enum SupportedLitShaderMode
		{
			// Token: 0x040028B3 RID: 10419
			ForwardOnly = 1,
			// Token: 0x040028B4 RID: 10420
			DeferredOnly,
			// Token: 0x040028B5 RID: 10421
			Both
		}

		// Token: 0x02000401 RID: 1025
		public enum LightProbeSystem
		{
			// Token: 0x040028B7 RID: 10423
			[InspectorName("Light Probe Groups")]
			LegacyLightProbes,
			// Token: 0x040028B8 RID: 10424
			ProbeVolumes
		}

		// Token: 0x02000402 RID: 1026
		public enum ColorBufferFormat
		{
			// Token: 0x040028BA RID: 10426
			R11G11B10 = 74,
			// Token: 0x040028BB RID: 10427
			R16G16B16A16 = 48
		}

		// Token: 0x02000403 RID: 1027
		public enum CustomBufferFormat
		{
			// Token: 0x040028BD RID: 10429
			[InspectorName("Signed R8G8B8A8")]
			SignedR8G8B8A8 = 12,
			// Token: 0x040028BE RID: 10430
			R8G8B8A8 = 8,
			// Token: 0x040028BF RID: 10431
			R16G16B16A16 = 48,
			// Token: 0x040028C0 RID: 10432
			R11G11B10 = 74
		}

		// Token: 0x02000404 RID: 1028
		public enum SupportedRayTracingMode
		{
			// Token: 0x040028C2 RID: 10434
			Performance = 1,
			// Token: 0x040028C3 RID: 10435
			Quality,
			// Token: 0x040028C4 RID: 10436
			Both
		}

		// Token: 0x02000405 RID: 1029
		[Serializable]
		public struct LightSettings
		{
			// Token: 0x060013E7 RID: 5095 RVA: 0x00096D3C File Offset: 0x00094F3C
			internal static RenderPipelineSettings.LightSettings NewDefault()
			{
				return new RenderPipelineSettings.LightSettings
				{
					useContactShadow = new BoolScalableSetting(new bool[]
					{
						default(bool),
						default(bool),
						true
					}, ScalableSettingSchemaId.With3Levels)
				};
			}

			// Token: 0x040028C5 RID: 10437
			public BoolScalableSetting useContactShadow;
		}

		// Token: 0x02000406 RID: 1030
		[Serializable]
		public class PlanarReflectionAtlasResolutionScalableSetting : ScalableSetting<PlanarReflectionAtlasResolution>
		{
			// Token: 0x060013E8 RID: 5096 RVA: 0x00096D6D File Offset: 0x00094F6D
			public PlanarReflectionAtlasResolutionScalableSetting(PlanarReflectionAtlasResolution[] values, ScalableSettingSchemaId schemaId) : base(values, schemaId)
			{
			}
		}

		// Token: 0x02000407 RID: 1031
		[Serializable]
		public class ReflectionProbeResolutionScalableSetting : ScalableSetting<CubeReflectionResolution>
		{
			// Token: 0x060013E9 RID: 5097 RVA: 0x00096D77 File Offset: 0x00094F77
			public ReflectionProbeResolutionScalableSetting(CubeReflectionResolution[] values, ScalableSettingSchemaId schemaId) : base(values, schemaId)
			{
			}
		}
	}
}
