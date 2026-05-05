using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000147 RID: 327
	[VolumeComponentMenuForRenderPipeline("Post-processing/Vignette", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class Vignette : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000ACE RID: 2766 RVA: 0x0005ABB4 File Offset: 0x00058DB4
		public bool IsActive()
		{
			return (this.mode.value == VignetteMode.Procedural && this.intensity.value > 0f) || (this.mode.value == VignetteMode.Masked && this.opacity.value > 0f && this.mask.value != null);
		}

		// Token: 0x04000BF4 RID: 3060
		[Tooltip("Specifies the mode HDRP uses to display the vignette effect.")]
		public VignetteModeParameter mode = new VignetteModeParameter(VignetteMode.Procedural, false);

		// Token: 0x04000BF5 RID: 3061
		[Tooltip("Specifies the color of the vignette.")]
		public ColorParameter color = new ColorParameter(Color.black, false, false, true, false);

		// Token: 0x04000BF6 RID: 3062
		[Tooltip("Sets the center point for the vignette.")]
		public Vector2Parameter center = new Vector2Parameter(new Vector2(0.5f, 0.5f), false);

		// Token: 0x04000BF7 RID: 3063
		[Tooltip("Controls the strength of the vignette effect.")]
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BF8 RID: 3064
		[Tooltip("Controls the smoothness of the vignette borders.")]
		public ClampedFloatParameter smoothness = new ClampedFloatParameter(0.2f, 0.01f, 1f, false);

		// Token: 0x04000BF9 RID: 3065
		[Tooltip("Controls how round the vignette is, lower values result in a more square vignette.")]
		public ClampedFloatParameter roundness = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000BFA RID: 3066
		[Tooltip("When enabled, the vignette is perfectly round. When disabled, the vignette matches shape with the current aspect ratio.")]
		public BoolParameter rounded = new BoolParameter(false, false);

		// Token: 0x04000BFB RID: 3067
		[Tooltip("Specifies a black and white mask Texture to use as a vignette.")]
		public Texture2DParameter mask = new Texture2DParameter(null, false);

		// Token: 0x04000BFC RID: 3068
		[Range(0f, 1f)]
		[Tooltip("Controls the opacity of the mask vignette. Lower values result in a more transparent vignette.")]
		public ClampedFloatParameter opacity = new ClampedFloatParameter(1f, 0f, 1f, false);
	}
}
