using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000149 RID: 329
	[VolumeComponentMenuForRenderPipeline("Post-processing/White Balance", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class WhiteBalance : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AD1 RID: 2769 RVA: 0x0005ACF7 File Offset: 0x00058EF7
		public bool IsActive()
		{
			return !Mathf.Approximately(this.temperature.value, 0f) || !Mathf.Approximately(this.tint.value, 0f);
		}

		// Token: 0x04000BFD RID: 3069
		[Tooltip("Controls the color temperature HDRP uses for white balancing.")]
		public ClampedFloatParameter temperature = new ClampedFloatParameter(0f, -100f, 100f, false);

		// Token: 0x04000BFE RID: 3070
		[Tooltip("Controls the white balance color to compensate for a green or magenta tint.")]
		public ClampedFloatParameter tint = new ClampedFloatParameter(0f, -100f, 100f, false);
	}
}
