using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C1 RID: 193
	[VolumeComponentMenuForRenderPipeline("Shadowing/Contact Shadows", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class ContactShadows : VolumeComponentWithQuality
	{
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0004C360 File Offset: 0x0004A560
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x0004C399 File Offset: 0x0004A599
		public int sampleCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_SampleCount.value;
				}
				int value = this.quality.value;
				return VolumeComponentWithQuality.GetLightingQualitySettings().ContactShadowSampleCount[value];
			}
			set
			{
				this.m_SampleCount.value = value;
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0004C3A8 File Offset: 0x0004A5A8
		private ContactShadows()
		{
			base.displayName = "Contact Shadows";
		}

		// Token: 0x04000858 RID: 2136
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x04000859 RID: 2137
		public ClampedFloatParameter length = new ClampedFloatParameter(0.15f, 0f, 1f, false);

		// Token: 0x0400085A RID: 2138
		public ClampedFloatParameter opacity = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x0400085B RID: 2139
		public ClampedFloatParameter distanceScaleFactor = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x0400085C RID: 2140
		public MinFloatParameter maxDistance = new MinFloatParameter(50f, 0f, false);

		// Token: 0x0400085D RID: 2141
		public MinFloatParameter minDistance = new MinFloatParameter(0f, 0f, false);

		// Token: 0x0400085E RID: 2142
		public MinFloatParameter fadeDistance = new MinFloatParameter(5f, 0f, false);

		// Token: 0x0400085F RID: 2143
		public MinFloatParameter fadeInDistance = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000860 RID: 2144
		public ClampedFloatParameter rayBias = new ClampedFloatParameter(0.2f, 0f, 1f, false);

		// Token: 0x04000861 RID: 2145
		public ClampedFloatParameter thicknessScale = new ClampedFloatParameter(0.15f, 0.02f, 1f, false);

		// Token: 0x04000862 RID: 2146
		[SerializeField]
		[FormerlySerializedAs("sampleCount")]
		private NoInterpClampedIntParameter m_SampleCount = new NoInterpClampedIntParameter(10, 4, 64, false);
	}
}
