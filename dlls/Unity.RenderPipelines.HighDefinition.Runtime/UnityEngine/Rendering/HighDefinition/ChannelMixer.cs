using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200011C RID: 284
	[VolumeComponentMenuForRenderPipeline("Post-processing/Channel Mixer", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ChannelMixer : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000A8B RID: 2699 RVA: 0x00059684 File Offset: 0x00057884
		public bool IsActive()
		{
			return this.redOutRedIn.value != 100f || this.redOutGreenIn.value != 0f || this.redOutBlueIn.value != 0f || this.greenOutRedIn.value != 0f || this.greenOutGreenIn.value != 100f || this.greenOutBlueIn.value != 0f || this.blueOutRedIn.value != 0f || this.blueOutGreenIn.value != 0f || this.blueOutBlueIn.value != 100f;
		}

		// Token: 0x04000B36 RID: 2870
		[Header("Red Output Channel")]
		[Tooltip("Controls the influence of the red channel in the output red channel.")]
		[InspectorName("Red")]
		public ClampedFloatParameter redOutRedIn = new ClampedFloatParameter(100f, -200f, 200f, false);

		// Token: 0x04000B37 RID: 2871
		[Tooltip("Controls the influence of the green channel in the output red channel.")]
		[InspectorName("Green")]
		public ClampedFloatParameter redOutGreenIn = new ClampedFloatParameter(0f, -200f, 200f, false);

		// Token: 0x04000B38 RID: 2872
		[Tooltip("Controls the influence of the blue channel in the output red channel.")]
		[InspectorName("Blue")]
		public ClampedFloatParameter redOutBlueIn = new ClampedFloatParameter(0f, -200f, 200f, false);

		// Token: 0x04000B39 RID: 2873
		[Header("Green Output Channel")]
		[Tooltip("Controls the influence of the red channel in the output green channel.")]
		[InspectorName("Red")]
		public ClampedFloatParameter greenOutRedIn = new ClampedFloatParameter(0f, -200f, 200f, false);

		// Token: 0x04000B3A RID: 2874
		[Tooltip("Controls the influence of the green channel in the output green channel.")]
		[InspectorName("Green")]
		public ClampedFloatParameter greenOutGreenIn = new ClampedFloatParameter(100f, -200f, 200f, false);

		// Token: 0x04000B3B RID: 2875
		[Tooltip("Controls the influence of the blue channel in the output green channel.")]
		[InspectorName("Blue")]
		public ClampedFloatParameter greenOutBlueIn = new ClampedFloatParameter(0f, -200f, 200f, false);

		// Token: 0x04000B3C RID: 2876
		[Header("Blue Output Channel")]
		[Tooltip("Controls the influence of the red channel in the output blue channel.")]
		[InspectorName("Red")]
		public ClampedFloatParameter blueOutRedIn = new ClampedFloatParameter(0f, -200f, 200f, false);

		// Token: 0x04000B3D RID: 2877
		[Tooltip("Controls the influence of the green channel in the output blue channel.")]
		[InspectorName("Green")]
		public ClampedFloatParameter blueOutGreenIn = new ClampedFloatParameter(0f, -200f, 200f, false);

		// Token: 0x04000B3E RID: 2878
		[Tooltip("Controls the influence of the blue channel in the output blue channel.")]
		[InspectorName("Blue")]
		public ClampedFloatParameter blueOutBlueIn = new ClampedFloatParameter(100f, -200f, 200f, false);
	}
}
