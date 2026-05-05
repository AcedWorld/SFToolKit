using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000067 RID: 103
	[VolumeComponentMenuForRenderPipeline("Lighting/Screen Space Global Illumination", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class GlobalIllumination : VolumeComponentWithQuality
	{
		// Token: 0x06000277 RID: 631 RVA: 0x0000E698 File Offset: 0x0000C898
		private bool UsesQualityMode()
		{
			return this.tracing.overrideState && this.tracing == RayCastingMode.RayTracing && (!this.mode.overrideState || (this.mode.overrideState && this.mode == RayTracingMode.Quality));
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000E6EC File Offset: 0x0000C8EC
		private GlobalIllumination()
		{
			base.displayName = "Screen Space Global Illumination";
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0000E8B7 File Offset: 0x0000CAB7
		// (set) Token: 0x0600027A RID: 634 RVA: 0x0000E8E3 File Offset: 0x0000CAE3
		public int maxRaySteps
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_MaxRaySteps.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().SSGIRaySteps[this.quality.value];
			}
			set
			{
				this.m_MaxRaySteps.value = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0000E8F1 File Offset: 0x0000CAF1
		// (set) Token: 0x0600027C RID: 636 RVA: 0x0000E91D File Offset: 0x0000CB1D
		public bool denoiseSS
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_DenoiseSS.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().SSGIDenoise[this.quality.value];
			}
			set
			{
				this.m_DenoiseSS.value = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600027D RID: 637 RVA: 0x0000E92B File Offset: 0x0000CB2B
		// (set) Token: 0x0600027E RID: 638 RVA: 0x0000E95F File Offset: 0x0000CB5F
		public bool halfResolutionDenoiserSS
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_HalfResolutionDenoiserSS.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().SSGIHalfResDenoise[this.quality.value];
			}
			set
			{
				this.m_HalfResolutionDenoiserSS.value = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600027F RID: 639 RVA: 0x0000E96D File Offset: 0x0000CB6D
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000E999 File Offset: 0x0000CB99
		public float denoiserRadiusSS
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_DenoiserRadiusSS.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().SSGIDenoiserRadius[this.quality.value];
			}
			set
			{
				this.m_DenoiserRadiusSS.value = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000281 RID: 641 RVA: 0x0000E9A7 File Offset: 0x0000CBA7
		// (set) Token: 0x06000282 RID: 642 RVA: 0x0000E9D3 File Offset: 0x0000CBD3
		public bool secondDenoiserPassSS
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_SecondDenoiserPassSS.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().SSGISecondDenoise[this.quality.value];
			}
			set
			{
				this.m_SecondDenoiserPassSS.value = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0000E9E1 File Offset: 0x0000CBE1
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0000EA15 File Offset: 0x0000CC15
		public float rayLength
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_RayLength.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIRayLength[this.quality.value];
			}
			set
			{
				this.m_RayLength.value = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000EA23 File Offset: 0x0000CC23
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0000EA57 File Offset: 0x0000CC57
		public float clampValue
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_ClampValue.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIClampValue[this.quality.value];
			}
			set
			{
				this.m_ClampValue.value = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0000EA65 File Offset: 0x0000CC65
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0000EA91 File Offset: 0x0000CC91
		public bool fullResolution
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_FullResolution.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIFullResolution[this.quality.value];
			}
			set
			{
				this.m_FullResolution.value = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000289 RID: 649 RVA: 0x0000EA9F File Offset: 0x0000CC9F
		// (set) Token: 0x0600028A RID: 650 RVA: 0x0000EAD3 File Offset: 0x0000CCD3
		public bool denoise
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_Denoise.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIDenoise[this.quality.value];
			}
			set
			{
				this.m_Denoise.value = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0000EAE1 File Offset: 0x0000CCE1
		// (set) Token: 0x0600028C RID: 652 RVA: 0x0000EB15 File Offset: 0x0000CD15
		public bool halfResolutionDenoiser
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_HalfResolutionDenoiser.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIHalfResDenoise[this.quality.value];
			}
			set
			{
				this.m_HalfResolutionDenoiser.value = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000EB23 File Offset: 0x0000CD23
		// (set) Token: 0x0600028E RID: 654 RVA: 0x0000EB57 File Offset: 0x0000CD57
		public float denoiserRadius
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_DenoiserRadius.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIDenoiserRadius[this.quality.value];
			}
			set
			{
				this.m_DenoiserRadius.value = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000EB65 File Offset: 0x0000CD65
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000EB99 File Offset: 0x0000CD99
		public bool secondDenoiserPass
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_SecondDenoiserPass.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGISecondDenoise[this.quality.value];
			}
			set
			{
				this.m_SecondDenoiserPass.value = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000EBA7 File Offset: 0x0000CDA7
		// (set) Token: 0x06000292 RID: 658 RVA: 0x0000EBDB File Offset: 0x0000CDDB
		public int maxMixedRaySteps
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesQualityMode())
				{
					return this.m_MaxMixedRaySteps.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTGIRaySteps[this.quality.value];
			}
			set
			{
				this.m_MaxMixedRaySteps.value = value;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000EBE9 File Offset: 0x0000CDE9
		internal static bool RayTracingActive(GlobalIllumination volume)
		{
			return volume.tracing.value != RayCastingMode.RayMarching;
		}

		// Token: 0x040002A3 RID: 675
		[Tooltip("Enable screen space global illumination.")]
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x040002A4 RID: 676
		[Tooltip("Controls the casting technique used to evaluate the effect. Ray marching uses a ray-marched screen-space solution, Ray tracing uses a hardware accelerated world-space solution. Mixed uses first Ray marching, then Ray tracing if it fails to intersect on-screen geometry.")]
		public RayCastingModeParameter tracing = new RayCastingModeParameter(RayCastingMode.RayMarching, false);

		// Token: 0x040002A5 RID: 677
		[Tooltip("Controls the fallback hierarchy for indirect diffuse in case the ray misses.")]
		[FormerlySerializedAs("fallbackHierarchy")]
		[AdditionalProperty]
		public RayMarchingFallbackHierarchyParameter rayMiss = new RayMarchingFallbackHierarchyParameter(RayMarchingFallbackHierarchy.ReflectionProbesAndSky, false);

		// Token: 0x040002A6 RID: 678
		[Tooltip("Controls the thickness of the depth buffer used for ray marching.")]
		public ClampedFloatParameter depthBufferThickness = new ClampedFloatParameter(0.1f, 0f, 0.5f, false);

		// Token: 0x040002A7 RID: 679
		public BoolParameter fullResolutionSS = new BoolParameter(true, false);

		// Token: 0x040002A8 RID: 680
		[SerializeField]
		[Tooltip("Controls the number of steps used for ray marching.")]
		private MinIntParameter m_MaxRaySteps = new MinIntParameter(32, 0, false);

		// Token: 0x040002A9 RID: 681
		[SerializeField]
		[FormerlySerializedAs("denoise")]
		private BoolParameter m_DenoiseSS = new BoolParameter(true, false);

		// Token: 0x040002AA RID: 682
		[SerializeField]
		[Tooltip("Use a half resolution denoiser.")]
		private BoolParameter m_HalfResolutionDenoiserSS = new BoolParameter(false, false);

		// Token: 0x040002AB RID: 683
		[SerializeField]
		[Tooltip("Controls the radius of the GI denoiser (First Pass).")]
		private ClampedFloatParameter m_DenoiserRadiusSS = new ClampedFloatParameter(0.6f, 0.001f, 1f, false);

		// Token: 0x040002AC RID: 684
		[SerializeField]
		[Tooltip("Enable second denoising pass.")]
		private BoolParameter m_SecondDenoiserPassSS = new BoolParameter(true, false);

		// Token: 0x040002AD RID: 685
		[Tooltip("Controls the fallback hierarchy for lighting the last bounce.")]
		[AdditionalProperty]
		public RayMarchingFallbackHierarchyParameter lastBounceFallbackHierarchy = new RayMarchingFallbackHierarchyParameter(RayMarchingFallbackHierarchy.ReflectionProbesAndSky, false);

		// Token: 0x040002AE RID: 686
		[Tooltip("Controls the dimmer applied to the ambient and legacy light probes.")]
		[AdditionalProperty]
		public ClampedFloatParameter ambientProbeDimmer = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x040002AF RID: 687
		[Tooltip("Defines the layers that GI should include.")]
		public LayerMaskParameter layerMask = new LayerMaskParameter(-1, false);

		// Token: 0x040002B0 RID: 688
		[Tooltip("The LOD Bias HDRP applies to textures in the global illumination. A higher value increases performance and makes denoising easier, but it might reduce visual fidelity.")]
		public ClampedIntParameter textureLodBias = new ClampedIntParameter(7, 0, 7, false);

		// Token: 0x040002B1 RID: 689
		[SerializeField]
		[FormerlySerializedAs("rayLength")]
		private MinFloatParameter m_RayLength = new MinFloatParameter(50f, 0.01f, false);

		// Token: 0x040002B2 RID: 690
		[SerializeField]
		[FormerlySerializedAs("clampValue")]
		[Tooltip("Controls the clamp of intensity.")]
		private MinFloatParameter m_ClampValue = new MinFloatParameter(100f, 0.001f, false);

		// Token: 0x040002B3 RID: 691
		[Tooltip("Controls which version of the effect should be used.")]
		public RayTracingModeParameter mode = new RayTracingModeParameter(RayTracingMode.Quality, false);

		// Token: 0x040002B4 RID: 692
		[SerializeField]
		[FormerlySerializedAs("fullResolution")]
		[Tooltip("Full Resolution")]
		private BoolParameter m_FullResolution = new BoolParameter(false, false);

		// Token: 0x040002B5 RID: 693
		[Tooltip("Number of samples for GI.")]
		public ClampedIntParameter sampleCount = new ClampedIntParameter(2, 1, 32, false);

		// Token: 0x040002B6 RID: 694
		[Tooltip("Number of bounces for GI.")]
		public ClampedIntParameter bounceCount = new ClampedIntParameter(1, 1, 8, false);

		// Token: 0x040002B7 RID: 695
		[SerializeField]
		[FormerlySerializedAs("denoise")]
		[Tooltip("Denoise the ray-traced GI.")]
		private BoolParameter m_Denoise = new BoolParameter(true, false);

		// Token: 0x040002B8 RID: 696
		[SerializeField]
		[FormerlySerializedAs("halfResolutionDenoiser")]
		[Tooltip("Use a half resolution denoiser.")]
		private BoolParameter m_HalfResolutionDenoiser = new BoolParameter(false, false);

		// Token: 0x040002B9 RID: 697
		[SerializeField]
		[FormerlySerializedAs("denoiserRadius")]
		[Tooltip("Controls the radius of the GI denoiser (First Pass).")]
		private ClampedFloatParameter m_DenoiserRadius = new ClampedFloatParameter(0.6f, 0.001f, 1f, false);

		// Token: 0x040002BA RID: 698
		[SerializeField]
		[FormerlySerializedAs("secondDenoiserPass")]
		[Tooltip("Enable second denoising pass.")]
		private BoolParameter m_SecondDenoiserPass = new BoolParameter(true, false);

		// Token: 0x040002BB RID: 699
		[SerializeField]
		[Tooltip("Controls the number of steps HDRP uses for mixed tracing.")]
		private MinIntParameter m_MaxMixedRaySteps = new MinIntParameter(48, 0, false);

		// Token: 0x040002BC RID: 700
		[AdditionalProperty]
		[Tooltip("When enabled, global illumination generated by moving objects will not be accumulated, generating less ghosting but introducing additional noise.")]
		public BoolParameter receiverMotionRejection = new BoolParameter(true, false);
	}
}
