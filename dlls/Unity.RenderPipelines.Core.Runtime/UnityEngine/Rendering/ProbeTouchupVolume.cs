using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200008F RID: 143
	[ExecuteAlways]
	[AddComponentMenu("Rendering/Probe Volume Touchup")]
	public class ProbeTouchupVolume : MonoBehaviour
	{
		// Token: 0x0400030F RID: 783
		[Range(0.0001f, 2f)]
		public float intensityScale = 1f;

		// Token: 0x04000310 RID: 784
		public bool invalidateProbes;

		// Token: 0x04000311 RID: 785
		public bool overrideDilationThreshold;

		// Token: 0x04000312 RID: 786
		[Range(0f, 0.99f)]
		public float overriddenDilationThreshold = 0.75f;

		// Token: 0x04000313 RID: 787
		public Vector3 size = new Vector3(1f, 1f, 1f);
	}
}
