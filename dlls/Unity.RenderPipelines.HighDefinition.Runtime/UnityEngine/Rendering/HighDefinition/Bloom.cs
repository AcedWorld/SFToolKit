using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200011A RID: 282
	[VolumeComponentMenuForRenderPipeline("Post-processing/Bloom", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class Bloom : VolumeComponentWithQuality, IPostProcessComponent
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x000594B8 File Offset: 0x000576B8
		// (set) Token: 0x06000A83 RID: 2691 RVA: 0x000594F6 File Offset: 0x000576F6
		public BloomResolution resolution
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_Resolution.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().BloomRes[item];
			}
			set
			{
				this.m_Resolution.value = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000A84 RID: 2692 RVA: 0x00059504 File Offset: 0x00057704
		// (set) Token: 0x06000A85 RID: 2693 RVA: 0x00059542 File Offset: 0x00057742
		public bool highQualityPrefiltering
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_HighQualityPrefiltering.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().BloomHighQualityPrefiltering[item];
			}
			set
			{
				this.m_HighQualityPrefiltering.value = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000A86 RID: 2694 RVA: 0x00059550 File Offset: 0x00057750
		// (set) Token: 0x06000A87 RID: 2695 RVA: 0x0005958E File Offset: 0x0005778E
		public bool highQualityFiltering
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_HighQualityFiltering.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().BloomHighQualityFiltering[item];
			}
			set
			{
				this.m_HighQualityFiltering.value = value;
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0005959C File Offset: 0x0005779C
		public bool IsActive()
		{
			return this.intensity.value > 0f;
		}

		// Token: 0x04000B2C RID: 2860
		[Header("Bloom")]
		[Tooltip("Set the level of brightness to filter out pixels under this level. This value is expressed in gamma-space. A value above 0 will disregard energy conservation rules.")]
		public MinFloatParameter threshold = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000B2D RID: 2861
		[Tooltip("Controls the strength of the bloom filter.")]
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000B2E RID: 2862
		[Tooltip("Set the radius of the bloom effect")]
		public ClampedFloatParameter scatter = new ClampedFloatParameter(0.7f, 0f, 1f, false);

		// Token: 0x04000B2F RID: 2863
		[Tooltip("Use the color picker to select a color for the Bloom effect to tint to.")]
		public ColorParameter tint = new ColorParameter(Color.white, false, false, true, false);

		// Token: 0x04000B30 RID: 2864
		[Header("Lens Dirt")]
		[Tooltip("Specifies a Texture to add smudges or dust to the bloom effect.")]
		public Texture2DParameter dirtTexture = new Texture2DParameter(null, false);

		// Token: 0x04000B31 RID: 2865
		[Tooltip("Controls the strength of the lens dirt.")]
		public MinFloatParameter dirtIntensity = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000B32 RID: 2866
		[Tooltip("When enabled, bloom stretches horizontally depending on the current physical Camera's Anamorphism property value.")]
		[AdditionalProperty]
		public BoolParameter anamorphic = new BoolParameter(true, false);

		// Token: 0x04000B33 RID: 2867
		[Header("Advanced Tweaks")]
		[AdditionalProperty]
		[Tooltip("Specifies the resolution at which HDRP processes the effect. Quarter resolution is less resource intensive but can result in aliasing artifacts.")]
		[SerializeField]
		[FormerlySerializedAs("resolution")]
		private BloomResolutionParameter m_Resolution = new BloomResolutionParameter(BloomResolution.Half, false);

		// Token: 0x04000B34 RID: 2868
		[AdditionalProperty]
		[Tooltip("When enabled, bloom uses multiple bilinear samples for the prefiltering pass.")]
		[SerializeField]
		private BoolParameter m_HighQualityPrefiltering = new BoolParameter(false, false);

		// Token: 0x04000B35 RID: 2869
		[AdditionalProperty]
		[Tooltip("When enabled, bloom uses bicubic sampling instead of bilinear sampling for the upsampling passes.")]
		[SerializeField]
		[FormerlySerializedAs("highQualityFiltering")]
		private BoolParameter m_HighQualityFiltering = new BoolParameter(true, false);
	}
}
