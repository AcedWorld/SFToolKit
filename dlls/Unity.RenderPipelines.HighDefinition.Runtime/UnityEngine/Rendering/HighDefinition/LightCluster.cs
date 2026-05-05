using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200017F RID: 383
	[VolumeComponentMenuForRenderPipeline("Ray Tracing/Light Cluster (Preview)", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class LightCluster : VolumeComponent
	{
		// Token: 0x06000C71 RID: 3185 RVA: 0x0006839C File Offset: 0x0006659C
		public LightCluster()
		{
			base.displayName = "Light Cluster (Preview)";
		}

		// Token: 0x04001356 RID: 4950
		[Tooltip("Controls the range of the cluster around the camera in meters.")]
		public MinFloatParameter cameraClusterRange = new MinFloatParameter(10f, 0.001f, false);
	}
}
