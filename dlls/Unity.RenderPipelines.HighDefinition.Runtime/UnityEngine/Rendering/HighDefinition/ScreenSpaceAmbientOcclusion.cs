using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000B8 RID: 184
	[VolumeComponentMenuForRenderPipeline("Lighting/Ambient Occlusion", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ScreenSpaceAmbientOcclusion : VolumeComponentWithQuality
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x0004B9A4 File Offset: 0x00049BA4
		// (set) Token: 0x06000854 RID: 2132 RVA: 0x0004B9D0 File Offset: 0x00049BD0
		public float rayLength
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_RayLength.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTAORayLength[this.quality.value];
			}
			set
			{
				this.m_RayLength.value = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x0004B9DE File Offset: 0x00049BDE
		// (set) Token: 0x06000856 RID: 2134 RVA: 0x0004BA0A File Offset: 0x00049C0A
		public int sampleCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_SampleCount.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTAOSampleCount[this.quality.value];
			}
			set
			{
				this.m_SampleCount.value = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0004BA18 File Offset: 0x00049C18
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x0004BA44 File Offset: 0x00049C44
		public bool denoise
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_Denoise.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTAODenoise[this.quality.value];
			}
			set
			{
				this.m_Denoise.value = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0004BA52 File Offset: 0x00049C52
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x0004BA7E File Offset: 0x00049C7E
		public float denoiserRadius
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_DenoiserRadius.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().RTAODenoiserRadius[this.quality.value];
			}
			set
			{
				this.m_DenoiserRadius.value = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0004BA8C File Offset: 0x00049C8C
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x0004BAB8 File Offset: 0x00049CB8
		public int stepCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_StepCount.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().AOStepCount[this.quality.value];
			}
			set
			{
				this.m_StepCount.value = value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x0004BAC6 File Offset: 0x00049CC6
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x0004BAF2 File Offset: 0x00049CF2
		public bool fullResolution
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_FullResolution.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().AOFullRes[this.quality.value];
			}
			set
			{
				this.m_FullResolution.value = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0004BB00 File Offset: 0x00049D00
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x0004BB2C File Offset: 0x00049D2C
		public int maximumRadiusInPixels
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_MaximumRadiusInPixels.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().AOMaximumRadiusPixels[this.quality.value];
			}
			set
			{
				this.m_MaximumRadiusInPixels.value = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x0004BB3A File Offset: 0x00049D3A
		// (set) Token: 0x06000862 RID: 2146 RVA: 0x0004BB66 File Offset: 0x00049D66
		public bool bilateralUpsample
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_BilateralUpsample.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().AOBilateralUpsample[this.quality.value];
			}
			set
			{
				this.m_BilateralUpsample.value = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x0004BB74 File Offset: 0x00049D74
		// (set) Token: 0x06000864 RID: 2148 RVA: 0x0004BBA0 File Offset: 0x00049DA0
		public int directionCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_DirectionCount.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().AODirectionCount[this.quality.value];
			}
			set
			{
				this.m_DirectionCount.value = value;
			}
		}

		// Token: 0x040007FC RID: 2044
		public BoolParameter rayTracing = new BoolParameter(false, false);

		// Token: 0x040007FD RID: 2045
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 4f, false);

		// Token: 0x040007FE RID: 2046
		public ClampedFloatParameter directLightingStrength = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x040007FF RID: 2047
		public ClampedFloatParameter radius = new ClampedFloatParameter(2f, 0.25f, 5f, false);

		// Token: 0x04000800 RID: 2048
		public ClampedFloatParameter spatialBilateralAggressiveness = new ClampedFloatParameter(0.15f, 0f, 1f, false);

		// Token: 0x04000801 RID: 2049
		public BoolParameter temporalAccumulation = new BoolParameter(true, false);

		// Token: 0x04000802 RID: 2050
		public ClampedFloatParameter ghostingReduction = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04000803 RID: 2051
		public ClampedFloatParameter blurSharpness = new ClampedFloatParameter(0.1f, 0f, 1f, false);

		// Token: 0x04000804 RID: 2052
		public LayerMaskParameter layerMask = new LayerMaskParameter(-1, false);

		// Token: 0x04000805 RID: 2053
		[AdditionalProperty]
		public ClampedFloatParameter specularOcclusion = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04000806 RID: 2054
		[AdditionalProperty]
		public BoolParameter occluderMotionRejection = new BoolParameter(true, false);

		// Token: 0x04000807 RID: 2055
		[AdditionalProperty]
		public BoolParameter receiverMotionRejection = new BoolParameter(true, false);

		// Token: 0x04000808 RID: 2056
		[SerializeField]
		[FormerlySerializedAs("stepCount")]
		private ClampedIntParameter m_StepCount = new ClampedIntParameter(6, 2, 32, false);

		// Token: 0x04000809 RID: 2057
		[SerializeField]
		[FormerlySerializedAs("fullResolution")]
		private BoolParameter m_FullResolution = new BoolParameter(false, false);

		// Token: 0x0400080A RID: 2058
		[SerializeField]
		[FormerlySerializedAs("maximumRadiusInPixels")]
		private ClampedIntParameter m_MaximumRadiusInPixels = new ClampedIntParameter(40, 16, 256, false);

		// Token: 0x0400080B RID: 2059
		[AdditionalProperty]
		[SerializeField]
		[FormerlySerializedAs("bilateralUpsample")]
		private BoolParameter m_BilateralUpsample = new BoolParameter(true, false);

		// Token: 0x0400080C RID: 2060
		[SerializeField]
		[FormerlySerializedAs("directionCount")]
		private ClampedIntParameter m_DirectionCount = new ClampedIntParameter(2, 1, 6, false);

		// Token: 0x0400080D RID: 2061
		[SerializeField]
		[FormerlySerializedAs("rayLength")]
		private MinFloatParameter m_RayLength = new MinFloatParameter(50f, 0.01f, false);

		// Token: 0x0400080E RID: 2062
		[SerializeField]
		[FormerlySerializedAs("sampleCount")]
		private ClampedIntParameter m_SampleCount = new ClampedIntParameter(1, 1, 64, false);

		// Token: 0x0400080F RID: 2063
		[SerializeField]
		[FormerlySerializedAs("denoise")]
		private BoolParameter m_Denoise = new BoolParameter(true, false);

		// Token: 0x04000810 RID: 2064
		[SerializeField]
		[FormerlySerializedAs("denoiserRadius")]
		private ClampedFloatParameter m_DenoiserRadius = new ClampedFloatParameter(1f, 0.001f, 1f, false);
	}
}
