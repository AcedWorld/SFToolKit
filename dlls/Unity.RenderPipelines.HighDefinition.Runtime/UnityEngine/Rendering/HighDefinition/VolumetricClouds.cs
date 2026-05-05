using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E7 RID: 231
	[VolumeComponentMenuForRenderPipeline("Sky/Volumetric Clouds", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class VolumetricClouds : VolumeComponent, IVersionable<VolumetricClouds.Version>, ISerializationCallbackReceiver
	{
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x000524F8 File Offset: 0x000506F8
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x00052505 File Offset: 0x00050705
		public VolumetricClouds.CloudPresets cloudPreset
		{
			get
			{
				return this.m_CloudPreset.value;
			}
			set
			{
				this.m_CloudPreset.value = value;
				this.ApplyCurrentCloudPreset();
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0005251C File Offset: 0x0005071C
		private void ApplyCurrentCloudPreset()
		{
			switch (this.cloudPreset)
			{
			case VolumetricClouds.CloudPresets.Sparse:
				this.densityMultiplier.value = 0.4f;
				this.shapeFactor.value = 0.95f;
				this.shapeScale.value = 5f;
				this.erosionFactor.value = 0.8f;
				this.erosionScale.value = 107f;
				this.densityCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.05f, 1f),
					new Keyframe(0.75f, 1f),
					new Keyframe(1f, 0f)
				});
				this.erosionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 1f),
					new Keyframe(0.1f, 0.9f),
					new Keyframe(1f, 1f)
				});
				this.ambientOcclusionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.25f, 0.5f),
					new Keyframe(1f, 0f)
				});
				this.bottomAltitude.value = 3000f;
				this.altitudeRange.value = 1000f;
				return;
			case VolumetricClouds.CloudPresets.Cloudy:
				this.densityMultiplier.value = 0.4f;
				this.shapeFactor.value = 0.9f;
				this.shapeScale.value = 5f;
				this.erosionFactor.value = 0.8f;
				this.erosionScale.value = 107f;
				this.densityCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.15f, 1f),
					new Keyframe(1f, 0.1f)
				});
				this.erosionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 1f),
					new Keyframe(0.1f, 0.9f),
					new Keyframe(1f, 1f)
				});
				this.ambientOcclusionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.25f, 0.4f),
					new Keyframe(1f, 0f)
				});
				this.bottomAltitude.value = 1200f;
				this.altitudeRange.value = 2000f;
				return;
			case VolumetricClouds.CloudPresets.Overcast:
				this.densityMultiplier.value = 0.3f;
				this.shapeFactor.value = 0.5f;
				this.shapeScale.value = 5f;
				this.erosionFactor.value = 0.8f;
				this.erosionScale.value = 107f;
				this.densityCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.05f, 1f),
					new Keyframe(0.9f, 0f),
					new Keyframe(1f, 0f)
				});
				this.erosionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 1f),
					new Keyframe(0.1f, 0.9f),
					new Keyframe(1f, 1f)
				});
				this.ambientOcclusionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(1f, 0f)
				});
				this.bottomAltitude.value = 1500f;
				this.altitudeRange.value = 2500f;
				return;
			case VolumetricClouds.CloudPresets.Stormy:
				this.densityMultiplier.value = 0.35f;
				this.shapeFactor.value = 0.85f;
				this.shapeScale.value = 5f;
				this.erosionFactor.value = 0.749f;
				this.erosionScale.value = 107f;
				this.densityCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.037f, 1f),
					new Keyframe(0.6f, 1f),
					new Keyframe(1f, 0f)
				});
				this.erosionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 1f),
					new Keyframe(0.05f, 0.8f),
					new Keyframe(0.2438f, 0.9498f),
					new Keyframe(0.5f, 1f),
					new Keyframe(0.93f, 0.9268f),
					new Keyframe(1f, 1f)
				});
				this.ambientOcclusionCurve.value = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.1f, 0.4f),
					new Keyframe(1f, 0f)
				});
				this.bottomAltitude.value = 1000f;
				this.altitudeRange.value = 5000f;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00052B98 File Offset: 0x00050D98
		private VolumetricClouds()
		{
			base.displayName = "Volumetric Clouds";
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x000531A6 File Offset: 0x000513A6
		public void OnBeforeSerialize()
		{
			if (this.m_Version == VolumetricClouds.Version.Count)
			{
				this.m_Version = VolumetricClouds.Version.ShapeOffset;
			}
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000531B8 File Offset: 0x000513B8
		public void OnAfterDeserialize()
		{
			if (this.m_Version == VolumetricClouds.Version.Count)
			{
				this.m_Version = VolumetricClouds.Version.Initial;
			}
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000531CC File Offset: 0x000513CC
		private void Awake()
		{
			VolumetricClouds.k_Migration.Migrate(this);
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000973 RID: 2419 RVA: 0x000531E8 File Offset: 0x000513E8
		// (set) Token: 0x06000974 RID: 2420 RVA: 0x000531F0 File Offset: 0x000513F0
		VolumetricClouds.Version IVersionable<VolumetricClouds.Version>.version
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

		// Token: 0x04000997 RID: 2455
		public const int CloudShadowResolutionCount = 5;

		// Token: 0x04000998 RID: 2456
		[Tooltip("Enable/Disable the volumetric clouds effect.")]
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x04000999 RID: 2457
		[Tooltip("When enabled, clouds are part of the scene and you can interact with them. This means you can move around and inside the clouds, they can appear between the Camera and other GameObjects, and the Camera's clipping planes affect the clouds. When disabled, the clouds are part of the skybox. This means the clouds and their shadows appear relative to the Camera and always appear behind geometry.")]
		public BoolParameter localClouds = new BoolParameter(false, false);

		// Token: 0x0400099A RID: 2458
		[Tooltip("Controls the curvature of the cloud volume which defines the distance at which the clouds intersect with the horizon.")]
		public ClampedFloatParameter earthCurvature = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x0400099B RID: 2459
		[Tooltip("Tiling (x,y) of the cloud map.")]
		public Vector2Parameter cloudTiling = new Vector2Parameter(new Vector2(1f, 1f), false);

		// Token: 0x0400099C RID: 2460
		[Tooltip("Offset (x,y) of the cloud map.")]
		public Vector2Parameter cloudOffset = new Vector2Parameter(new Vector2(0f, 0f), false);

		// Token: 0x0400099D RID: 2461
		[Tooltip("Controls the altitude of the bottom of the volumetric clouds volume in meters.")]
		public MinFloatParameter bottomAltitude = new MinFloatParameter(1200f, 0.01f, false);

		// Token: 0x0400099E RID: 2462
		[Tooltip("Controls the size of the volumetric clouds volume in meters.")]
		public MinFloatParameter altitudeRange = new MinFloatParameter(2000f, 100f, false);

		// Token: 0x0400099F RID: 2463
		[Tooltip("Controls the mode in which the clouds fade in when close to the camera's near plane.")]
		public VolumetricClouds.CloudFadeInModeParameter fadeInMode = new VolumetricClouds.CloudFadeInModeParameter(VolumetricClouds.CloudFadeInMode.Automatic, false);

		// Token: 0x040009A0 RID: 2464
		[Tooltip("Controls the minimal distance at which clouds start appearing.")]
		public MinFloatParameter fadeInStart = new MinFloatParameter(0f, 0f, false);

		// Token: 0x040009A1 RID: 2465
		[Tooltip("Controls the distance that it takes for the clouds to reach their complete density.")]
		public MinFloatParameter fadeInDistance = new MinFloatParameter(0f, 0f, false);

		// Token: 0x040009A2 RID: 2466
		[Tooltip("Controls the number of steps when evaluating the clouds' transmittance. A higher value may lead to a lower noise level and longer view distance, but at a higher cost.")]
		public ClampedIntParameter numPrimarySteps = new ClampedIntParameter(64, 32, 1024, false);

		// Token: 0x040009A3 RID: 2467
		[Tooltip("Controls the number of steps when evaluating the clouds' lighting. A higher value will lead to smoother lighting and improved self-shadowing, but at a higher cost.")]
		public ClampedIntParameter numLightSteps = new ClampedIntParameter(6, 1, 32, false);

		// Token: 0x040009A4 RID: 2468
		[Tooltip("Specifies the cloud map - Coverage (R), Rain (G), Type (B).")]
		public TextureParameter cloudMap = new TextureParameter(null, TextureDimension.Tex2D, false);

		// Token: 0x040009A5 RID: 2469
		[Tooltip("Specifies the lookup table for the clouds - Profile Coverage (R), Erosion (G), Ambient Occlusion (B).")]
		public TextureParameter cloudLut = new TextureParameter(null, TextureDimension.Tex2D, false);

		// Token: 0x040009A6 RID: 2470
		[Tooltip("Specifies the cloud control Mode: Simple, Advanced or Manual.")]
		public VolumetricClouds.CloudControlParameter cloudControl = new VolumetricClouds.CloudControlParameter(VolumetricClouds.CloudControl.Simple, false);

		// Token: 0x040009A7 RID: 2471
		[SerializeField]
		[FormerlySerializedAs("cloudPreset")]
		private VolumetricClouds.CloudPresetsParameter m_CloudPreset = new VolumetricClouds.CloudPresetsParameter(VolumetricClouds.CloudPresets.Cloudy, false);

		// Token: 0x040009A8 RID: 2472
		[Tooltip("Specifies the lower cloud layer distribution in the advanced mode.")]
		public TextureParameter cumulusMap = new TextureParameter(null, TextureDimension.Tex2D, false);

		// Token: 0x040009A9 RID: 2473
		[Tooltip("Overrides the coverage of the lower cloud layer specified in the cumulus map in the advanced mode.")]
		public ClampedFloatParameter cumulusMapMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009AA RID: 2474
		[Tooltip("Specifies the higher cloud layer distribution in the advanced mode.")]
		public TextureParameter altoStratusMap = new TextureParameter(null, TextureDimension.Tex2D, false);

		// Token: 0x040009AB RID: 2475
		[Tooltip("Overrides the coverage of the higher cloud layer specified in the alto stratus map in the advanced mode.")]
		public ClampedFloatParameter altoStratusMapMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009AC RID: 2476
		[Tooltip("Specifies the anvil shaped clouds distribution in the advanced mode.")]
		public TextureParameter cumulonimbusMap = new TextureParameter(null, TextureDimension.Tex2D, false);

		// Token: 0x040009AD RID: 2477
		[Tooltip("Overrides the coverage of the anvil shaped clouds specified in the cumulonimbus map in the advanced mode.")]
		public ClampedFloatParameter cumulonimbusMapMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009AE RID: 2478
		[Tooltip("Specifies the rain distribution in the advanced mode.")]
		public TextureParameter rainMap = new TextureParameter(null, TextureDimension.Tex2D, false);

		// Token: 0x040009AF RID: 2479
		[Tooltip("Specifies the internal texture resolution used for the cloud map in the advanced mode. A lower value will lead to higher performance, but less precise cloud type transitions.")]
		public VolumetricClouds.CloudMapResolutionParameter cloudMapResolution = new VolumetricClouds.CloudMapResolutionParameter(VolumetricClouds.CloudMapResolution.Medium64x64, false);

		// Token: 0x040009B0 RID: 2480
		[Tooltip("Controls the density (Y axis) of the volumetric clouds as a function of the height (X Axis) inside the cloud volume.")]
		public AnimationCurveParameter densityCurve = new AnimationCurveParameter(new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.15f, 1f),
			new Keyframe(1f, 0.1f)
		}), false);

		// Token: 0x040009B1 RID: 2481
		[Tooltip("Controls the erosion (Y axis) of the volumetric clouds as a function of the height (X Axis) inside the cloud volume.")]
		public AnimationCurveParameter erosionCurve = new AnimationCurveParameter(new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(0.1f, 0.9f),
			new Keyframe(1f, 1f)
		}), false);

		// Token: 0x040009B2 RID: 2482
		[Tooltip("Controls the ambient occlusion (Y axis) of the volumetric clouds as a function of the height (X Axis) inside the cloud volume.")]
		public AnimationCurveParameter ambientOcclusionCurve = new AnimationCurveParameter(new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.25f, 0.4f),
			new Keyframe(1f, 0f)
		}), false);

		// Token: 0x040009B3 RID: 2483
		[Tooltip("Specifies the tint of the cloud scattering color.")]
		public ColorParameter scatteringTint = new ColorParameter(new Color(0f, 0f, 0f, 1f), false);

		// Token: 0x040009B4 RID: 2484
		[Tooltip("Controls the amount of local scattering in the clouds. A higher value may produce a more powdery or diffused aspect.")]
		[AdditionalProperty]
		public ClampedFloatParameter powderEffectIntensity = new ClampedFloatParameter(0.25f, 0f, 1f, false);

		// Token: 0x040009B5 RID: 2485
		[Tooltip("Controls the amount of multi-scattering inside the cloud.")]
		[AdditionalProperty]
		public ClampedFloatParameter multiScattering = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x040009B6 RID: 2486
		[Tooltip("Controls the global density of the cloud volume.")]
		public ClampedFloatParameter densityMultiplier = new ClampedFloatParameter(0.4f, 0f, 1f, false);

		// Token: 0x040009B7 RID: 2487
		[Tooltip("Controls the larger noise passing through the cloud coverage. A higher value will yield less cloud coverage and smaller clouds.")]
		public ClampedFloatParameter shapeFactor = new ClampedFloatParameter(0.9f, 0f, 1f, false);

		// Token: 0x040009B8 RID: 2488
		[Tooltip("Controls the size of the larger noise passing through the cloud coverage.")]
		public MinFloatParameter shapeScale = new MinFloatParameter(5f, 0.1f, false);

		// Token: 0x040009B9 RID: 2489
		[Tooltip("Controls the world space offset applied when evaluating the larger noise passing through the cloud coverage.")]
		public Vector3Parameter shapeOffset = new Vector3Parameter(Vector3.zero, false);

		// Token: 0x040009BA RID: 2490
		[Tooltip("Controls the smaller noise on the edge of the clouds. A higher value will erode clouds more significantly.")]
		public ClampedFloatParameter erosionFactor = new ClampedFloatParameter(0.8f, 0f, 1f, false);

		// Token: 0x040009BB RID: 2491
		[Tooltip("Controls the size of the smaller noise passing through the cloud coverage.")]
		public MinFloatParameter erosionScale = new MinFloatParameter(107f, 1f, false);

		// Token: 0x040009BC RID: 2492
		[Tooltip("Controls the type of noise used to generate the smaller noise passing through the cloud coverage.")]
		[AdditionalProperty]
		public VolumetricClouds.CloudErosionNoiseParameter erosionNoiseType = new VolumetricClouds.CloudErosionNoiseParameter(VolumetricClouds.CloudErosionNoise.Perlin32, false);

		// Token: 0x040009BD RID: 2493
		[Tooltip("Controls the influence of the light probes on the cloud volume. A lower value will suppress the ambient light and produce darker clouds overall.")]
		public ClampedFloatParameter ambientLightProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009BE RID: 2494
		[Tooltip("Controls the influence of the sun light on the cloud volume. A lower value will suppress the sun light and produce darker clouds overall.")]
		public ClampedFloatParameter sunLightDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009BF RID: 2495
		[Tooltip("Controls how much Erosion Factor is taken into account when computing ambient occlusion. The Erosion Factor parameter is editable in the custom preset, Advanced and Manual Modes.")]
		[AdditionalProperty]
		public ClampedFloatParameter erosionOcclusion = new ClampedFloatParameter(0.1f, 0f, 1f, false);

		// Token: 0x040009C0 RID: 2496
		[Tooltip("Sets the global horizontal wind speed in kilometers per hour.\nThis value can be relative to the Global Wind Speed defined in the Visual Environment.")]
		public WindSpeedParameter globalWindSpeed = new WindSpeedParameter(100f, WindParameter.WindOverrideMode.Global, false);

		// Token: 0x040009C1 RID: 2497
		[Tooltip("Controls the orientation of the wind relative to the X world vector.\nThis value can be relative to the Global Wind Orientation defined in the Visual Environment.")]
		public WindOrientationParameter orientation = new WindOrientationParameter(0f, WindParameter.WindOverrideMode.Global, false);

		// Token: 0x040009C2 RID: 2498
		[AdditionalProperty]
		[Tooltip("Controls the intensity of the wind-based altitude distortion of the clouds.")]
		public ClampedFloatParameter altitudeDistortion = new ClampedFloatParameter(0.25f, -1f, 1f, false);

		// Token: 0x040009C3 RID: 2499
		[Tooltip("Controls the multiplier to the speed of the cloud map.")]
		[AdditionalProperty]
		public ClampedFloatParameter cloudMapSpeedMultiplier = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x040009C4 RID: 2500
		[Tooltip("Controls the multiplier to the speed of the larger cloud shapes.")]
		[AdditionalProperty]
		public ClampedFloatParameter shapeSpeedMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009C5 RID: 2501
		[Tooltip("Controls the multiplier to the speed of the erosion cloud shapes.")]
		[AdditionalProperty]
		public ClampedFloatParameter erosionSpeedMultiplier = new ClampedFloatParameter(0.25f, 0f, 1f, false);

		// Token: 0x040009C6 RID: 2502
		[Tooltip("Controls the vertical wind speed of the larger cloud shapes.")]
		[AdditionalProperty]
		public FloatParameter verticalShapeWindSpeed = new FloatParameter(0f, false);

		// Token: 0x040009C7 RID: 2503
		[Tooltip("Controls the vertical wind speed of the erosion cloud shapes.")]
		[AdditionalProperty]
		public FloatParameter verticalErosionWindSpeed = new FloatParameter(0f, false);

		// Token: 0x040009C8 RID: 2504
		[Tooltip("Temporal accumulation increases the visual quality of clouds by decreasing the noise. A higher value will give you better quality but can create ghosting.")]
		public ClampedFloatParameter temporalAccumulationFactor = new ClampedFloatParameter(0.95f, 0f, 1f, false);

		// Token: 0x040009C9 RID: 2505
		[Tooltip("Enable/Disable the volumetric clouds ghosting reduction. When enabled, reduces significantly the ghosting of the volumetric clouds, but may introduce some flickering at lower temporal accumulation factors.")]
		public BoolParameter ghostingReduction = new BoolParameter(false, false);

		// Token: 0x040009CA RID: 2506
		[Tooltip("Specifies the strength of the perceptual blending for the volumetric clouds. This value should be treated as flag and only be set to 0.0 or 1.0.")]
		public ClampedFloatParameter perceptualBlending = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009CB RID: 2507
		[Tooltip("Enable/Disable the volumetric clouds shadow. This will override the cookie of your directional light and the cloud layer shadow (if active).")]
		public BoolParameter shadows = new BoolParameter(false, false);

		// Token: 0x040009CC RID: 2508
		[Tooltip("Specifies the resolution of the volumetric clouds shadow map.")]
		public VolumetricClouds.CloudShadowResolutionParameter shadowResolution = new VolumetricClouds.CloudShadowResolutionParameter(VolumetricClouds.CloudShadowResolution.Medium256, false);

		// Token: 0x040009CD RID: 2509
		[Tooltip("Controls the vertical offset applied to compute the volumetric clouds shadow in meters. To have accurate results, enter the average height at which the volumetric clouds shadow is received.")]
		public FloatParameter shadowPlaneHeightOffset = new FloatParameter(0f, false);

		// Token: 0x040009CE RID: 2510
		[Tooltip("Sets the size of the area covered by shadow around the camera.")]
		[AdditionalProperty]
		public MinFloatParameter shadowDistance = new MinFloatParameter(8000f, 1000f, false);

		// Token: 0x040009CF RID: 2511
		[Tooltip("Controls the opacity of the volumetric clouds shadow.")]
		[AdditionalProperty]
		public ClampedFloatParameter shadowOpacity = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x040009D0 RID: 2512
		[Tooltip("Controls the shadow opacity when outside the area covered by the volumetric clouds shadow.")]
		[AdditionalProperty]
		public ClampedFloatParameter shadowOpacityFallback = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x040009D1 RID: 2513
		private static readonly MigrationDescription<VolumetricClouds.Version, VolumetricClouds> k_Migration = MigrationDescription.New<VolumetricClouds.Version, VolumetricClouds>(new MigrationStep<VolumetricClouds.Version, VolumetricClouds>[]
		{
			MigrationStep.New<VolumetricClouds.Version, VolumetricClouds>(VolumetricClouds.Version.GlobalWind, delegate(VolumetricClouds c)
			{
				c.globalWindSpeed.overrideState = c.m_ObsoleteWindSpeed.overrideState;
				c.globalWindSpeed.value = new WindParameter.WindParamaterValue
				{
					mode = WindParameter.WindOverrideMode.Custom,
					customValue = c.m_ObsoleteWindSpeed.value
				};
				c.orientation.overrideState = c.m_ObsoleteOrientation.overrideState;
				c.orientation.value = new WindParameter.WindParamaterValue
				{
					mode = WindParameter.WindOverrideMode.Custom,
					customValue = c.m_ObsoleteOrientation.value
				};
			}),
			MigrationStep.New<VolumetricClouds.Version, VolumetricClouds>(VolumetricClouds.Version.ShapeOffset, delegate(VolumetricClouds c)
			{
				c.shapeOffset.overrideState = (c.m_ObsoleteShapeOffsetX.overrideState || c.m_ObsoleteShapeOffsetY.overrideState || c.m_ObsoleteShapeOffsetZ.overrideState);
				c.shapeOffset.value = new Vector3(c.m_ObsoleteShapeOffsetX.value, c.m_ObsoleteShapeOffsetY.value, c.m_ObsoleteShapeOffsetZ.value);
			})
		});

		// Token: 0x040009D2 RID: 2514
		[SerializeField]
		private VolumetricClouds.Version m_Version = VolumetricClouds.Version.Count;

		// Token: 0x040009D3 RID: 2515
		[SerializeField]
		[FormerlySerializedAs("globalWindSpeed")]
		[Obsolete("For Data Migration")]
		private MinFloatParameter m_ObsoleteWindSpeed = new MinFloatParameter(1f, 0f, false);

		// Token: 0x040009D4 RID: 2516
		[SerializeField]
		[FormerlySerializedAs("orientation")]
		[Obsolete("For Data Migration")]
		private ClampedFloatParameter m_ObsoleteOrientation = new ClampedFloatParameter(0f, 0f, 360f, false);

		// Token: 0x040009D5 RID: 2517
		[SerializeField]
		[FormerlySerializedAs("shapeOffsetX")]
		[Obsolete("For Data Migration")]
		private FloatParameter m_ObsoleteShapeOffsetX = new FloatParameter(0f, false);

		// Token: 0x040009D6 RID: 2518
		[SerializeField]
		[FormerlySerializedAs("shapeOffsetY")]
		[Obsolete("For Data Migration")]
		private FloatParameter m_ObsoleteShapeOffsetY = new FloatParameter(0f, false);

		// Token: 0x040009D7 RID: 2519
		[SerializeField]
		[FormerlySerializedAs("shapeOffsetZ")]
		[Obsolete("For Data Migration")]
		private FloatParameter m_ObsoleteShapeOffsetZ = new FloatParameter(0f, false);

		// Token: 0x02000362 RID: 866
		public enum CloudControl
		{
			// Token: 0x0400239E RID: 9118
			Simple,
			// Token: 0x0400239F RID: 9119
			Advanced,
			// Token: 0x040023A0 RID: 9120
			Manual
		}

		// Token: 0x02000363 RID: 867
		[Serializable]
		public sealed class CloudControlParameter : VolumeParameter<VolumetricClouds.CloudControl>
		{
			// Token: 0x060012DA RID: 4826 RVA: 0x000907E0 File Offset: 0x0008E9E0
			public CloudControlParameter(VolumetricClouds.CloudControl value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}

		// Token: 0x02000364 RID: 868
		public enum CloudPresets
		{
			// Token: 0x040023A2 RID: 9122
			Sparse,
			// Token: 0x040023A3 RID: 9123
			Cloudy,
			// Token: 0x040023A4 RID: 9124
			Overcast,
			// Token: 0x040023A5 RID: 9125
			Stormy,
			// Token: 0x040023A6 RID: 9126
			Custom
		}

		// Token: 0x02000365 RID: 869
		[Serializable]
		public sealed class CloudPresetsParameter : VolumeParameter<VolumetricClouds.CloudPresets>
		{
			// Token: 0x060012DB RID: 4827 RVA: 0x000907EA File Offset: 0x0008E9EA
			public CloudPresetsParameter(VolumetricClouds.CloudPresets value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}

		// Token: 0x02000366 RID: 870
		public enum CloudShadowResolution
		{
			// Token: 0x040023A8 RID: 9128
			VeryLow64 = 64,
			// Token: 0x040023A9 RID: 9129
			Low128 = 128,
			// Token: 0x040023AA RID: 9130
			Medium256 = 256,
			// Token: 0x040023AB RID: 9131
			High512 = 512,
			// Token: 0x040023AC RID: 9132
			Ultra1024 = 1024
		}

		// Token: 0x02000367 RID: 871
		[Serializable]
		public sealed class CloudShadowResolutionParameter : VolumeParameter<VolumetricClouds.CloudShadowResolution>
		{
			// Token: 0x060012DC RID: 4828 RVA: 0x000907F4 File Offset: 0x0008E9F4
			public CloudShadowResolutionParameter(VolumetricClouds.CloudShadowResolution value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}

		// Token: 0x02000368 RID: 872
		public enum CloudMapResolution
		{
			// Token: 0x040023AE RID: 9134
			Low32x32 = 32,
			// Token: 0x040023AF RID: 9135
			Medium64x64 = 64,
			// Token: 0x040023B0 RID: 9136
			High128x128 = 128,
			// Token: 0x040023B1 RID: 9137
			Ultra256x256 = 256
		}

		// Token: 0x02000369 RID: 873
		[Serializable]
		public sealed class CloudMapResolutionParameter : VolumeParameter<VolumetricClouds.CloudMapResolution>
		{
			// Token: 0x060012DD RID: 4829 RVA: 0x000907FE File Offset: 0x0008E9FE
			public CloudMapResolutionParameter(VolumetricClouds.CloudMapResolution value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}

		// Token: 0x0200036A RID: 874
		public enum CloudErosionNoise
		{
			// Token: 0x040023B3 RID: 9139
			Worley32,
			// Token: 0x040023B4 RID: 9140
			Perlin32
		}

		// Token: 0x0200036B RID: 875
		[Serializable]
		public sealed class CloudErosionNoiseParameter : VolumeParameter<VolumetricClouds.CloudErosionNoise>
		{
			// Token: 0x060012DE RID: 4830 RVA: 0x00090808 File Offset: 0x0008EA08
			public CloudErosionNoiseParameter(VolumetricClouds.CloudErosionNoise value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}

		// Token: 0x0200036C RID: 876
		public enum CloudFadeInMode
		{
			// Token: 0x040023B6 RID: 9142
			Automatic,
			// Token: 0x040023B7 RID: 9143
			Manual
		}

		// Token: 0x0200036D RID: 877
		[Serializable]
		public sealed class CloudFadeInModeParameter : VolumeParameter<VolumetricClouds.CloudFadeInMode>
		{
			// Token: 0x060012DF RID: 4831 RVA: 0x00090812 File Offset: 0x0008EA12
			public CloudFadeInModeParameter(VolumetricClouds.CloudFadeInMode value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}

		// Token: 0x0200036E RID: 878
		private enum Version
		{
			// Token: 0x040023B9 RID: 9145
			Initial,
			// Token: 0x040023BA RID: 9146
			GlobalWind,
			// Token: 0x040023BB RID: 9147
			ShapeOffset,
			// Token: 0x040023BC RID: 9148
			Count
		}
	}
}
