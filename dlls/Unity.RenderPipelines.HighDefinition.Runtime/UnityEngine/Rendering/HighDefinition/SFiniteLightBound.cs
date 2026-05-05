using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000099 RID: 153
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightLoop\\LightLoop.cs")]
	internal struct SFiniteLightBound
	{
		// Token: 0x0400071C RID: 1820
		public Vector3 boxAxisX;

		// Token: 0x0400071D RID: 1821
		public Vector3 boxAxisY;

		// Token: 0x0400071E RID: 1822
		public Vector3 boxAxisZ;

		// Token: 0x0400071F RID: 1823
		public Vector3 center;

		// Token: 0x04000720 RID: 1824
		public float scaleXY;

		// Token: 0x04000721 RID: 1825
		public float radius;
	}
}
