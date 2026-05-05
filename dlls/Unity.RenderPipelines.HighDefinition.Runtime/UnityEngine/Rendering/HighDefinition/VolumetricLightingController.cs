using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E9 RID: 233
	[Obsolete]
	internal class VolumetricLightingController : VolumeComponent
	{
		// Token: 0x06000976 RID: 2422 RVA: 0x00053254 File Offset: 0x00051454
		private VolumetricLightingController()
		{
			base.displayName = "Volumetric Fog Quality (Deprecated)";
		}

		// Token: 0x04000A1C RID: 2588
		[Tooltip("Sets the distance (in meters) from the Camera's Near Clipping Plane to the back of the Camera's volumetric lighting buffer.")]
		public MinFloatParameter depthExtent = new MinFloatParameter(64f, 0.1f, false);

		// Token: 0x04000A1D RID: 2589
		[Tooltip("Controls the distribution of slices along the Camera's focal axis. 0 is exponential distribution and 1 is linear distribution.")]
		[FormerlySerializedAs("depthDistributionUniformity")]
		public ClampedFloatParameter sliceDistributionUniformity = new ClampedFloatParameter(0.75f, 0f, 1f, false);
	}
}
