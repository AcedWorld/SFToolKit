using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200013C RID: 316
	[VolumeComponentMenuForRenderPipeline("Post-processing/Split Toning", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class SplitToning : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AC4 RID: 2756 RVA: 0x0005A7FD File Offset: 0x000589FD
		public bool IsActive()
		{
			return this.shadows != Color.grey || this.highlights != Color.grey;
		}

		// Token: 0x04000BCA RID: 3018
		[Tooltip("Specifies the color to use for shadows.")]
		public ColorParameter shadows = new ColorParameter(Color.grey, false, false, true, false);

		// Token: 0x04000BCB RID: 3019
		[Tooltip("Specifies the color to use for highlights.")]
		public ColorParameter highlights = new ColorParameter(Color.grey, false, false, true, false);

		// Token: 0x04000BCC RID: 3020
		[Tooltip("Controls the balance between the colors in the highlights and shadows.")]
		public ClampedFloatParameter balance = new ClampedFloatParameter(0f, -100f, 100f, false);
	}
}
