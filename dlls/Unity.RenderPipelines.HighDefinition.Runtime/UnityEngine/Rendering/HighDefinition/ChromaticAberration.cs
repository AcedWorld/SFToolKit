using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200011D RID: 285
	[VolumeComponentMenuForRenderPipeline("Post-processing/Chromatic Aberration", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ChromaticAberration : VolumeComponentWithQuality, IPostProcessComponent
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x00059848 File Offset: 0x00057A48
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x00059886 File Offset: 0x00057A86
		public int maxSamples
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_MaxSamples.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().ChromaticAberrationMaxSamples[item];
			}
			set
			{
				this.m_MaxSamples.value = value;
			}
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00059894 File Offset: 0x00057A94
		public bool IsActive()
		{
			return this.intensity.value > 0f;
		}

		// Token: 0x04000B3F RID: 2879
		[Tooltip("Specifies a Texture which HDRP uses to shift the hue of chromatic aberrations.")]
		public Texture2DParameter spectralLut = new Texture2DParameter(null, false);

		// Token: 0x04000B40 RID: 2880
		[Tooltip("Use the slider to set the strength of the Chromatic Aberration effect.")]
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000B41 RID: 2881
		[Tooltip("Controls the maximum number of samples HDRP uses to render the effect. A lower sample number results in better performance.")]
		[SerializeField]
		[FormerlySerializedAs("maxSamples")]
		private ClampedIntParameter m_MaxSamples = new ClampedIntParameter(6, 3, 24, false);
	}
}
