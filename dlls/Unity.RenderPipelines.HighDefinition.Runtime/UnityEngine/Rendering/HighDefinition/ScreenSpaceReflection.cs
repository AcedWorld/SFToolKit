using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000BD RID: 189
	[VolumeComponentMenuForRenderPipeline("Lighting/Screen Space Reflection", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class ScreenSpaceReflection : VolumeComponentWithQuality
	{
		// Token: 0x06000867 RID: 2151 RVA: 0x0004BD6C File Offset: 0x00049F6C
		private bool UsesRayTracingQualityMode()
		{
			return this.tracing.overrideState && this.tracing.value == RayCastingMode.RayTracing && (!this.mode.overrideState || (this.mode.overrideState && this.mode.value == RayTracingMode.Quality));
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0004BDC4 File Offset: 0x00049FC4
		private bool UsesRayTracing()
		{
			HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
			return currentAsset != null && currentAsset.currentPlatformRenderPipelineSettings.supportRayTracing && this.tracing.overrideState && this.tracing.value != RayCastingMode.RayMarching;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x0004BE10 File Offset: 0x0004A010
		// (set) Token: 0x0600086A RID: 2154 RVA: 0x0004BE5F File Offset: 0x0004A05F
		public float minSmoothness
		{
			get
			{
				if ((this.UsesRayTracing() && (this.UsesRayTracingQualityMode() || !base.UsesQualitySettings())) || !this.UsesRayTracing())
				{
					return this.m_MinSmoothness.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRMinSmoothness[this.quality.value];
			}
			set
			{
				this.m_MinSmoothness.value = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x0004BE70 File Offset: 0x0004A070
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x0004BEBF File Offset: 0x0004A0BF
		public float smoothnessFadeStart
		{
			get
			{
				if ((this.UsesRayTracing() && (this.UsesRayTracingQualityMode() || !base.UsesQualitySettings())) || !this.UsesRayTracing())
				{
					return this.m_SmoothnessFadeStart.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRSmoothnessFadeStart[this.quality.value];
			}
			set
			{
				this.m_SmoothnessFadeStart.value = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0004BECD File Offset: 0x0004A0CD
		// (set) Token: 0x0600086E RID: 2158 RVA: 0x0004BEF9 File Offset: 0x0004A0F9
		public int rayMaxIterations
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_RayMaxIterations.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().SSRMaxRaySteps[this.quality.value];
			}
			set
			{
				this.m_RayMaxIterations.value = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x0004BF07 File Offset: 0x0004A107
		// (set) Token: 0x06000870 RID: 2160 RVA: 0x0004BF3B File Offset: 0x0004A13B
		public float rayLength
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesRayTracingQualityMode())
				{
					return this.m_RayLength.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRRayLength[this.quality.value];
			}
			set
			{
				this.m_RayLength.value = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x0004BF49 File Offset: 0x0004A149
		// (set) Token: 0x06000872 RID: 2162 RVA: 0x0004BF7D File Offset: 0x0004A17D
		public float clampValue
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesRayTracingQualityMode())
				{
					return this.m_ClampValue.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRClampValue[this.quality.value];
			}
			set
			{
				this.m_ClampValue.value = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x0004BF8B File Offset: 0x0004A18B
		// (set) Token: 0x06000874 RID: 2164 RVA: 0x0004BFBF File Offset: 0x0004A1BF
		public bool denoise
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesRayTracingQualityMode())
				{
					return this.m_Denoise.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRDenoise[this.quality.value];
			}
			set
			{
				this.m_Denoise.value = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000875 RID: 2165 RVA: 0x0004BFCD File Offset: 0x0004A1CD
		// (set) Token: 0x06000876 RID: 2166 RVA: 0x0004C001 File Offset: 0x0004A201
		public int denoiserRadius
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesRayTracingQualityMode())
				{
					return this.m_DenoiserRadius.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRDenoiserRadius[this.quality.value];
			}
			set
			{
				this.m_DenoiserRadius.value = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x0004C00F File Offset: 0x0004A20F
		// (set) Token: 0x06000878 RID: 2168 RVA: 0x0004C043 File Offset: 0x0004A243
		public bool affectSmoothSurfaces
		{
			get
			{
				if (!base.UsesQualitySettings() || this.UsesRayTracingQualityMode())
				{
					return this.m_AffectSmoothSurfaces.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRSmoothDenoising[this.quality.value];
			}
			set
			{
				this.m_AffectSmoothSurfaces.value = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0004C051 File Offset: 0x0004A251
		// (set) Token: 0x0600087A RID: 2170 RVA: 0x0004C07D File Offset: 0x0004A27D
		public bool fullResolution
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_FullResolution.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRFullResolution[this.quality.value];
			}
			set
			{
				this.m_FullResolution.value = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x0004C08B File Offset: 0x0004A28B
		// (set) Token: 0x0600087C RID: 2172 RVA: 0x0004C0B7 File Offset: 0x0004A2B7
		public int rayMaxIterationsRT
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_RayMaxIterationsRT.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTRRayMaxIterations[this.quality.value];
			}
			set
			{
				this.m_RayMaxIterationsRT.value = value;
			}
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0004C0C5 File Offset: 0x0004A2C5
		internal static bool RayTracingActive(ScreenSpaceReflection volume)
		{
			return volume.tracing.value != RayCastingMode.RayMarching;
		}

		// Token: 0x0400081E RID: 2078
		[Tooltip("Enable Screen Space Reflections.")]
		public BoolParameter enabled = new BoolParameter(true, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x0400081F RID: 2079
		[Tooltip("Enable Transparent Screen Space Reflections.")]
		public BoolParameter enabledTransparent = new BoolParameter(true, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x04000820 RID: 2080
		[Tooltip("Controls the casting technique used to evaluate the effect.")]
		public RayCastingModeParameter tracing = new RayCastingModeParameter(RayCastingMode.RayMarching, false);

		// Token: 0x04000821 RID: 2081
		[SerializeField]
		[FormerlySerializedAs("minSmoothness")]
		private ClampedFloatParameter m_MinSmoothness = new ClampedFloatParameter(0.9f, 0f, 1f, false);

		// Token: 0x04000822 RID: 2082
		[SerializeField]
		[FormerlySerializedAs("smoothnessFadeStart")]
		private ClampedFloatParameter m_SmoothnessFadeStart = new ClampedFloatParameter(0.9f, 0f, 1f, false);

		// Token: 0x04000823 RID: 2083
		public BoolParameter reflectSky = new BoolParameter(true, false);

		// Token: 0x04000824 RID: 2084
		public SSRAlgoParameter usedAlgorithm = new SSRAlgoParameter(ScreenSpaceReflectionAlgorithm.Approximation, false);

		// Token: 0x04000825 RID: 2085
		public ClampedFloatParameter depthBufferThickness = new ClampedFloatParameter(0.01f, 0f, 1f, false);

		// Token: 0x04000826 RID: 2086
		public ClampedFloatParameter screenFadeDistance = new ClampedFloatParameter(0.1f, 0f, 1f, false);

		// Token: 0x04000827 RID: 2087
		public ClampedFloatParameter accumulationFactor = new ClampedFloatParameter(0.75f, 0f, 1f, false);

		// Token: 0x04000828 RID: 2088
		[AdditionalProperty]
		public ClampedFloatParameter biasFactor = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04000829 RID: 2089
		[AdditionalProperty]
		public FloatParameter speedRejectionParam = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x0400082A RID: 2090
		[AdditionalProperty]
		public ClampedFloatParameter speedRejectionScalerFactor = new ClampedFloatParameter(0.2f, 0.001f, 1f, false);

		// Token: 0x0400082B RID: 2091
		[AdditionalProperty]
		public BoolParameter speedSmoothReject = new BoolParameter(false, false);

		// Token: 0x0400082C RID: 2092
		[AdditionalProperty]
		public BoolParameter speedSurfaceOnly = new BoolParameter(true, false);

		// Token: 0x0400082D RID: 2093
		[AdditionalProperty]
		public BoolParameter speedTargetOnly = new BoolParameter(true, false);

		// Token: 0x0400082E RID: 2094
		public BoolParameter enableWorldSpeedRejection = new BoolParameter(false, false);

		// Token: 0x0400082F RID: 2095
		[SerializeField]
		[FormerlySerializedAs("rayMaxIterations")]
		private MinIntParameter m_RayMaxIterations = new MinIntParameter(64, 0, false);

		// Token: 0x04000830 RID: 2096
		[FormerlySerializedAs("fallbackHierachy")]
		[AdditionalProperty]
		public RayTracingFallbackHierachyParameter rayMiss = new RayTracingFallbackHierachyParameter(RayTracingFallbackHierachy.ReflectionProbesAndSky, false);

		// Token: 0x04000831 RID: 2097
		[AdditionalProperty]
		public RayTracingFallbackHierachyParameter lastBounceFallbackHierarchy = new RayTracingFallbackHierachyParameter(RayTracingFallbackHierachy.ReflectionProbesAndSky, false);

		// Token: 0x04000832 RID: 2098
		[Tooltip("Controls the dimmer applied to the ambient and legacy light probes.")]
		[AdditionalProperty]
		public ClampedFloatParameter ambientProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000833 RID: 2099
		public LayerMaskParameter layerMask = new LayerMaskParameter(-1, false);

		// Token: 0x04000834 RID: 2100
		public ClampedIntParameter textureLodBias = new ClampedIntParameter(1, 0, 7, false);

		// Token: 0x04000835 RID: 2101
		[SerializeField]
		[FormerlySerializedAs("rayLength")]
		private MinFloatParameter m_RayLength = new MinFloatParameter(50f, 0.01f, false);

		// Token: 0x04000836 RID: 2102
		[SerializeField]
		[FormerlySerializedAs("clampValue")]
		[Tooltip("Clamps the exposed intensity, this only affects reflections on opaque objects.")]
		private MinFloatParameter m_ClampValue = new MinFloatParameter(100f, 0.001f, false);

		// Token: 0x04000837 RID: 2103
		[SerializeField]
		[FormerlySerializedAs("denoise")]
		[Tooltip("Denoise the ray-traced reflection.")]
		private BoolParameter m_Denoise = new BoolParameter(true, false);

		// Token: 0x04000838 RID: 2104
		[SerializeField]
		[FormerlySerializedAs("denoiserRadius")]
		[Tooltip("Controls the radius of the ray traced reflection denoiser.")]
		private ClampedIntParameter m_DenoiserRadius = new ClampedIntParameter(8, 1, 32, false);

		// Token: 0x04000839 RID: 2105
		[SerializeField]
		[Tooltip("Denoiser affects smooth surfaces.")]
		private BoolParameter m_AffectSmoothSurfaces = new BoolParameter(false, false);

		// Token: 0x0400083A RID: 2106
		public RayTracingModeParameter mode = new RayTracingModeParameter(RayTracingMode.Quality, false);

		// Token: 0x0400083B RID: 2107
		[SerializeField]
		[FormerlySerializedAs("fullResolution")]
		[Tooltip("Full Resolution")]
		private BoolParameter m_FullResolution = new BoolParameter(false, false);

		// Token: 0x0400083C RID: 2108
		public ClampedIntParameter sampleCount = new ClampedIntParameter(1, 1, 32, false);

		// Token: 0x0400083D RID: 2109
		public ClampedIntParameter bounceCount = new ClampedIntParameter(1, 1, 8, false);

		// Token: 0x0400083E RID: 2110
		[SerializeField]
		[FormerlySerializedAs("rayMaxIterations")]
		private MinIntParameter m_RayMaxIterationsRT = new MinIntParameter(48, 0, false);
	}
}
