using System;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEngine.Rendering
{
	// Token: 0x0200001F RID: 31
	[VolumeComponentMenuForRenderPipeline("Lighting/Probe Volumes Options (Experimental)", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ProbeVolumesOptions : VolumeComponent
	{
		// Token: 0x04000088 RID: 136
		[Tooltip("The overridden normal bias to be applied to the world position when sampling the Probe Volumes data structure. Unit is meters.")]
		public ClampedFloatParameter normalBias = new ClampedFloatParameter(0.33f, 0f, 2f, false);

		// Token: 0x04000089 RID: 137
		[Tooltip("A bias alongside the view vector to be applied to the world position when sampling the Probe Volumes data structure. Unit is meters.")]
		public ClampedFloatParameter viewBias = new ClampedFloatParameter(0f, 0f, 2f, false);

		// Token: 0x0400008A RID: 138
		[Tooltip("Whether to scale the bias for Probe Volumes by the minimum distance between probes.")]
		public BoolParameter scaleBiasWithMinProbeDistance = new BoolParameter(false, false);

		// Token: 0x0400008B RID: 139
		[AdditionalProperty]
		[Tooltip("Noise to be applied to the sampling position. It can hide seams issues between subdivision levels, but introduces noise.")]
		public ClampedFloatParameter samplingNoise = new ClampedFloatParameter(0.1f, 0f, 0.5f, false);

		// Token: 0x0400008C RID: 140
		[AdditionalProperty]
		[Tooltip("Whether to animate the noise when TAA is enabled. It can potentially remove the visible noise patterns.")]
		public BoolParameter animateSamplingNoise = new BoolParameter(true, false);

		// Token: 0x0400008D RID: 141
		[AdditionalProperty]
		[Tooltip("Method used to reduce leaks. Currently available modes are crude, but cheap methods.")]
		public APVLeakReductionModeParameter leakReductionMode = new APVLeakReductionModeParameter(APVLeakReductionMode.ValidityAndNormalBased, false);

		// Token: 0x0400008E RID: 142
		[AdditionalProperty]
		[Tooltip("Controls how normal based leak reduction is applied. Lower values would consider all probes equally important, while higher ones would favor probes further along the normal direction of the surface.")]
		public ClampedFloatParameter minValidDotProductValue = new ClampedFloatParameter(0.1f, -1f, 0.33f, false);

		// Token: 0x0400008F RID: 143
		[AdditionalProperty]
		[Tooltip("When enabled, reflection probe normalization can only decrease the reflection intensity.")]
		public BoolParameter occlusionOnlyReflectionNormalization = new BoolParameter(true, false);
	}
}
