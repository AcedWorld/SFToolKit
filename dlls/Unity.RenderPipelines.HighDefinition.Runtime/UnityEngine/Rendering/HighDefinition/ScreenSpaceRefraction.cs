using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000BE RID: 190
	[VolumeComponentMenuForRenderPipeline("Lighting/Screen Space Refraction", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class ScreenSpaceRefraction : VolumeComponent
	{
		// Token: 0x0400083F RID: 2111
		[Tooltip("Controls the distance at which HDRP fades out SSR near the edge of the screen.")]
		public ClampedFloatParameter screenFadeDistance = new ClampedFloatParameter(0.1f, 0.001f, 1f, false);

		// Token: 0x0200034B RID: 843
		internal enum RefractionModel
		{
			// Token: 0x04002349 RID: 9033
			None,
			// Token: 0x0400234A RID: 9034
			Planar,
			// Token: 0x0400234B RID: 9035
			Sphere,
			// Token: 0x0400234C RID: 9036
			Thin
		}
	}
}
