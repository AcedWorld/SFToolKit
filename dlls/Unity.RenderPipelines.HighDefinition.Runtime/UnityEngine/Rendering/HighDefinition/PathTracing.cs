using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000173 RID: 371
	[VolumeComponentMenuForRenderPipeline("Ray Tracing/Path Tracing (Preview)", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class PathTracing : VolumeComponent
	{
		// Token: 0x06000C31 RID: 3121 RVA: 0x00064960 File Offset: 0x00062B60
		public PathTracing()
		{
			base.displayName = "Path Tracing (Preview)";
		}

		// Token: 0x040012C5 RID: 4805
		[Tooltip("Enables path tracing (thus disabling most other passes).")]
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x040012C6 RID: 4806
		[Tooltip("Defines the layers that path tracing should include.")]
		public LayerMaskParameter layerMask = new LayerMaskParameter(-1, false);

		// Token: 0x040012C7 RID: 4807
		[Tooltip("Defines the maximum number of paths cast within each pixel, over time (one per frame).")]
		public ClampedIntParameter maximumSamples = new ClampedIntParameter(256, 1, 16384, false);

		// Token: 0x040012C8 RID: 4808
		[Tooltip("Defines the minimum number of bounces for each path, in [1, 32].")]
		public ClampedIntParameter minimumDepth = new ClampedIntParameter(1, 1, 32, false);

		// Token: 0x040012C9 RID: 4809
		[Tooltip("Defines the maximum number of bounces for each path, in [minimumDepth, 32].")]
		public ClampedIntParameter maximumDepth = new ClampedIntParameter(4, 1, 32, false);

		// Token: 0x040012CA RID: 4810
		[Tooltip("Defines the maximum, post-exposed luminance computed for indirect path segments. Lower values help prevent noise and fireflies (very bright pixels), but introduce bias by darkening the overall result. Increase this value if your image looks too dark.")]
		public MinFloatParameter maximumIntensity = new MinFloatParameter(10f, 0f, false);

		// Token: 0x040012CB RID: 4811
		[Tooltip("Defines if and when sky importance sampling is enabled. It should be turned on for sky models with high contrast and bright spots, and turned off for smooth, uniform skies.")]
		public SkyImportanceSamplingParameter skyImportanceSampling = new SkyImportanceSamplingParameter(SkyImportanceSamplingMode.HDRIOnly, false);

		// Token: 0x040012CC RID: 4812
		[Tooltip("Defines the number of tiles (X: width, Y: height) and the indices of the current tile (Z: i in [0, width[, W: j in [0, height[) for interleaved tiled rendering.")]
		public Vector4Parameter tilingParameters = new Vector4Parameter(new Vector4(1f, 1f, 0f, 0f), false);

		// Token: 0x040012CD RID: 4813
		[Tooltip("Defines the mode used to calculate the noise index used per path tracing sample.")]
		public SeedModeParameter seedMode = new SeedModeParameter(SeedMode.Repeating, false);
	}
}
