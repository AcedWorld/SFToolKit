using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200013A RID: 314
	[VolumeComponentMenuForRenderPipeline("Post-processing/Panini Projection", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class PaniniProjection : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AC0 RID: 2752 RVA: 0x0005A66F File Offset: 0x0005886F
		public bool IsActive()
		{
			return this.distance.value > 0f;
		}

		// Token: 0x04000BC1 RID: 3009
		[Tooltip("Controls the panini projection distance. This controls the strength of the distorion.")]
		public ClampedFloatParameter distance = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BC2 RID: 3010
		[Tooltip("Controls how much cropping HDRP applies to the screen with the panini projection effect. A value of 1 crops the distortion to the edge of the screen.")]
		[VolumeComponent.Indent(1)]
		public ClampedFloatParameter cropToFit = new ClampedFloatParameter(1f, 0f, 1f, false);
	}
}
