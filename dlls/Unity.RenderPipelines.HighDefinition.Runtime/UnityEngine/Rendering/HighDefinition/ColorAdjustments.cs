using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200011E RID: 286
	[VolumeComponentMenuForRenderPipeline("Post-processing/Color Adjustments", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ColorAdjustments : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000A91 RID: 2705 RVA: 0x000598E8 File Offset: 0x00057AE8
		public bool IsActive()
		{
			return this.postExposure.value != 0f || this.contrast.value != 0f || this.colorFilter != Color.white || this.hueShift != 0f || this.saturation != 0f;
		}

		// Token: 0x04000B42 RID: 2882
		[Tooltip("Adjusts the brightness of the image just before color grading, in EV.")]
		public FloatParameter postExposure = new FloatParameter(0f, false);

		// Token: 0x04000B43 RID: 2883
		[Tooltip("Controls the overall range of the tonal values.")]
		public ClampedFloatParameter contrast = new ClampedFloatParameter(0f, -100f, 100f, false);

		// Token: 0x04000B44 RID: 2884
		[Tooltip("Specifies the color that HDRP tints the render to.")]
		public ColorParameter colorFilter = new ColorParameter(Color.white, true, false, true, false);

		// Token: 0x04000B45 RID: 2885
		[Tooltip("Controls the hue of all colors in the render.")]
		public ClampedFloatParameter hueShift = new ClampedFloatParameter(0f, -180f, 180f, false);

		// Token: 0x04000B46 RID: 2886
		[Tooltip("Controls the intensity of all colors in the render.")]
		public ClampedFloatParameter saturation = new ClampedFloatParameter(0f, -100f, 100f, false);
	}
}
