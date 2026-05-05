using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200018B RID: 395
	[VolumeComponentMenuForRenderPipeline("Ray Tracing/Recursive Rendering (Preview)", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class RecursiveRendering : VolumeComponent
	{
		// Token: 0x06000C78 RID: 3192 RVA: 0x000684C8 File Offset: 0x000666C8
		public RecursiveRendering()
		{
			base.displayName = "Recursive Rendering (Preview)";
		}

		// Token: 0x04001373 RID: 4979
		[Tooltip("Enable. Enables recursive rendering.")]
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x04001374 RID: 4980
		[Tooltip("Layer Mask. Layer mask used to include the objects for recursive rendering.")]
		public LayerMaskParameter layerMask = new LayerMaskParameter(-1, false);

		// Token: 0x04001375 RID: 4981
		[Tooltip("Max Depth. Defines the maximal recursion for rays.")]
		public ClampedIntParameter maxDepth = new ClampedIntParameter(4, 1, 10, false);

		// Token: 0x04001376 RID: 4982
		public MinFloatParameter rayLength = new MinFloatParameter(10f, 0f, false);

		// Token: 0x04001377 RID: 4983
		[Tooltip("Minmal Smoothness for Reflection. If the surface has a smoothness value below this threshold, a reflection ray will not be case and it will fallback on other techniques.")]
		public ClampedFloatParameter minSmoothness = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04001378 RID: 4984
		[AdditionalProperty]
		[Tooltip("Controls which sources are used to fallback on when the traced ray misses.")]
		public RayTracingFallbackHierachyParameter rayMiss = new RayTracingFallbackHierachyParameter(RayTracingFallbackHierachy.ReflectionProbesAndSky, false);

		// Token: 0x04001379 RID: 4985
		[AdditionalProperty]
		[Tooltip("Controls the fallback hierarchy for lighting the last bounce.")]
		public RayTracingFallbackHierachyParameter lastBounce = new RayTracingFallbackHierachyParameter(RayTracingFallbackHierachy.ReflectionProbesAndSky, false);

		// Token: 0x0400137A RID: 4986
		[Tooltip("Controls the dimmer applied to the ambient and legacy light probes.")]
		[AdditionalProperty]
		public ClampedFloatParameter ambientProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);
	}
}
