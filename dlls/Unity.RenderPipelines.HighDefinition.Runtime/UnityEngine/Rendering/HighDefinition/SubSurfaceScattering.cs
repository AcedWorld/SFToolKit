using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000114 RID: 276
	[VolumeComponentMenuForRenderPipeline("Ray Tracing/SubSurface Scattering (Preview)", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class SubSurfaceScattering : VolumeComponent
	{
		// Token: 0x06000A7D RID: 2685 RVA: 0x000592B8 File Offset: 0x000574B8
		public SubSurfaceScattering()
		{
			base.displayName = "SubSurface Scattering (Preview)";
		}

		// Token: 0x04000B27 RID: 2855
		[Tooltip("Enable ray traced sub-surface scattering.")]
		public BoolParameter rayTracing = new BoolParameter(false, false);

		// Token: 0x04000B28 RID: 2856
		[Tooltip("Number of samples for sub-surface scattering.")]
		public ClampedIntParameter sampleCount = new ClampedIntParameter(1, 1, 32, false);
	}
}
