using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000123 RID: 291
	[VolumeComponentMenuForRenderPipeline("Post-processing/Depth Of Field", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class DepthOfField : VolumeComponentWithQuality, IPostProcessComponent
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00059C68 File Offset: 0x00057E68
		// (set) Token: 0x06000A96 RID: 2710 RVA: 0x00059CA6 File Offset: 0x00057EA6
		public int nearSampleCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_NearSampleCount.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().NearBlurSampleCount[item];
			}
			set
			{
				this.m_NearSampleCount.value = value;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x00059CB4 File Offset: 0x00057EB4
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x00059CF2 File Offset: 0x00057EF2
		public float nearMaxBlur
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_NearMaxBlur.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().NearBlurMaxRadius[item];
			}
			set
			{
				this.m_NearMaxBlur.value = value;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00059D00 File Offset: 0x00057F00
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x00059D3E File Offset: 0x00057F3E
		public int farSampleCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_FarSampleCount.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().FarBlurSampleCount[item];
			}
			set
			{
				this.m_FarSampleCount.value = value;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00059D4C File Offset: 0x00057F4C
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x00059D8A File Offset: 0x00057F8A
		public float farMaxBlur
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_FarMaxBlur.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().FarBlurMaxRadius[item];
			}
			set
			{
				this.m_FarMaxBlur.value = value;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00059D98 File Offset: 0x00057F98
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x00059DD6 File Offset: 0x00057FD6
		public bool highQualityFiltering
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_HighQualityFiltering.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().DoFHighQualityFiltering[item];
			}
			set
			{
				this.m_HighQualityFiltering.value = value;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00059DE4 File Offset: 0x00057FE4
		// (set) Token: 0x06000AA0 RID: 2720 RVA: 0x00059E22 File Offset: 0x00058022
		public bool physicallyBased
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_PhysicallyBased.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().DoFPhysicallyBased[item];
			}
			set
			{
				this.m_PhysicallyBased.value = value;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x00059E30 File Offset: 0x00058030
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x00059E61 File Offset: 0x00058061
		public bool limitManualRangeNearBlur
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_LimitManualRangeNearBlur.value;
				}
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().LimitManualRangeNearBlur[this.quality.levelAndOverride.Item1];
			}
			set
			{
				this.m_LimitManualRangeNearBlur.value = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x00059E70 File Offset: 0x00058070
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x00059EAE File Offset: 0x000580AE
		public DepthOfFieldResolution resolution
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_Resolution.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().DoFResolution[item];
			}
			set
			{
				this.m_Resolution.value = value;
			}
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00059EBC File Offset: 0x000580BC
		public bool IsActive()
		{
			return this.focusMode.value != DepthOfFieldMode.Off && (this.IsNearLayerActive() || this.IsFarLayerActive());
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00059EDD File Offset: 0x000580DD
		public bool IsNearLayerActive()
		{
			return this.nearMaxBlur > 0f && this.nearFocusEnd.value > 0f;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00059F00 File Offset: 0x00058100
		public bool IsFarLayerActive()
		{
			return this.farMaxBlur > 0f;
		}

		// Token: 0x04000B5B RID: 2907
		internal static Vector2 s_HighQualityAdaptiveSamplingWeights = new Vector2(4f, 1f);

		// Token: 0x04000B5C RID: 2908
		internal static Vector2 s_LowQualityAdaptiveSamplingWeights = new Vector2(1f, 0.75f);

		// Token: 0x04000B5D RID: 2909
		[Tooltip("Specifies the mode that HDRP uses to set the focus for the depth of field effect.")]
		public DepthOfFieldModeParameter focusMode = new DepthOfFieldModeParameter(DepthOfFieldMode.Off, false);

		// Token: 0x04000B5E RID: 2910
		[Tooltip("The distance to the focus plane from the Camera.")]
		public MinFloatParameter focusDistance = new MinFloatParameter(10f, 0.1f, false);

		// Token: 0x04000B5F RID: 2911
		[Tooltip("Specifies where to read the focus distance from..")]
		public FocusDistanceModeParameter focusDistanceMode = new FocusDistanceModeParameter(FocusDistanceMode.Volume, false);

		// Token: 0x04000B60 RID: 2912
		[Header("Near Range")]
		[Tooltip("Sets the distance from the Camera at which the near field blur begins to decrease in intensity.")]
		public MinFloatParameter nearFocusStart = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000B61 RID: 2913
		[Tooltip("Sets the distance from the Camera at which the near field does not blur anymore.")]
		public MinFloatParameter nearFocusEnd = new MinFloatParameter(4f, 0f, false);

		// Token: 0x04000B62 RID: 2914
		[Header("Far Range")]
		[Tooltip("Sets the distance from the Camera at which the far field starts blurring.")]
		public MinFloatParameter farFocusStart = new MinFloatParameter(10f, 0f, false);

		// Token: 0x04000B63 RID: 2915
		[Tooltip("Sets the distance from the Camera at which the far field blur reaches its maximum blur radius.")]
		public MinFloatParameter farFocusEnd = new MinFloatParameter(20f, 0f, false);

		// Token: 0x04000B64 RID: 2916
		[Header("Near Blur")]
		[Tooltip("Sets the number of samples to use for the near field.")]
		[SerializeField]
		[FormerlySerializedAs("nearSampleCount")]
		private ClampedIntParameter m_NearSampleCount = new ClampedIntParameter(5, 3, 8, false);

		// Token: 0x04000B65 RID: 2917
		[SerializeField]
		[FormerlySerializedAs("nearMaxBlur")]
		[Tooltip("Sets the maximum radius the near blur can reach.")]
		private ClampedFloatParameter m_NearMaxBlur = new ClampedFloatParameter(4f, 0f, 8f, false);

		// Token: 0x04000B66 RID: 2918
		[Header("Far Blur")]
		[Tooltip("Sets the number of samples to use for the far field.")]
		[SerializeField]
		[FormerlySerializedAs("farSampleCount")]
		private ClampedIntParameter m_FarSampleCount = new ClampedIntParameter(7, 3, 16, false);

		// Token: 0x04000B67 RID: 2919
		[Tooltip("Sets the maximum radius the far blur can reach.")]
		[SerializeField]
		[FormerlySerializedAs("farMaxBlur")]
		private ClampedFloatParameter m_FarMaxBlur = new ClampedFloatParameter(8f, 0f, 16f, false);

		// Token: 0x04000B68 RID: 2920
		[Header("Advanced Tweaks")]
		[AdditionalProperty]
		[Tooltip("Specifies the resolution at which HDRP processes the depth of field effect.")]
		[SerializeField]
		[FormerlySerializedAs("resolution")]
		private DepthOfFieldResolutionParameter m_Resolution = new DepthOfFieldResolutionParameter(DepthOfFieldResolution.Half, false);

		// Token: 0x04000B69 RID: 2921
		[AdditionalProperty]
		[Tooltip("When enabled, HDRP uses bicubic instead of bilinear filtering for the depth of field effect. Also conceals tiling artifacts in the physically-based mode.")]
		[SerializeField]
		[FormerlySerializedAs("highQualityFiltering")]
		private BoolParameter m_HighQualityFiltering = new BoolParameter(true, false);

		// Token: 0x04000B6A RID: 2922
		[AdditionalProperty]
		[Tooltip("When enabled, HDRP uses a more accurate but slower physically based algorithm to compute the depth of field effect.")]
		[SerializeField]
		private BoolParameter m_PhysicallyBased = new BoolParameter(false, false);

		// Token: 0x04000B6B RID: 2923
		[AdditionalProperty]
		[Tooltip("Adjust near blur CoC based on depth distance when manual, non-physical mode is used.")]
		[SerializeField]
		private BoolParameter m_LimitManualRangeNearBlur = new BoolParameter(false, false);
	}
}
