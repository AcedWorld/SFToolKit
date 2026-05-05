using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000135 RID: 309
	[VolumeComponentMenuForRenderPipeline("Post-processing/Lens Distortion", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class LensDistortion : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AB7 RID: 2743 RVA: 0x0005A348 File Offset: 0x00058548
		public bool IsActive()
		{
			return Mathf.Abs(this.intensity.value) > 0f && (this.xMultiplier.value > 0f || this.yMultiplier.value > 0f);
		}

		// Token: 0x04000BA9 RID: 2985
		[Tooltip("Controls the overall strength of the distortion effect.")]
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, -1f, 1f, false);

		// Token: 0x04000BAA RID: 2986
		[Tooltip("Controls the distortion intensity on the x-axis. Acts as a multiplier.")]
		public ClampedFloatParameter xMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000BAB RID: 2987
		[Tooltip("Controls the distortion intensity on the x-axis. Acts as a multiplier.")]
		public ClampedFloatParameter yMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000BAC RID: 2988
		[Tooltip("Distortion center point. 0.5,0.5 is center of the screen.")]
		public Vector2Parameter center = new Vector2Parameter(new Vector2(0.5f, 0.5f), false);

		// Token: 0x04000BAD RID: 2989
		[Tooltip("Controls global screen scaling for the distortion effect. Use this to hide the screen borders when using a high \"Intensity\".")]
		public ClampedFloatParameter scale = new ClampedFloatParameter(1f, 0.01f, 5f, false);
	}
}
