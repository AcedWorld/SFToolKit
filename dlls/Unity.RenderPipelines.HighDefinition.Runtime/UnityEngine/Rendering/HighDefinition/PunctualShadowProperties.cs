using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C5 RID: 197
	internal struct PunctualShadowProperties
	{
		// Token: 0x04000884 RID: 2180
		public bool isSpot;

		// Token: 0x04000885 RID: 2181
		public bool softShadow;

		// Token: 0x04000886 RID: 2182
		public int lightIndex;

		// Token: 0x04000887 RID: 2183
		public float lightRadius;

		// Token: 0x04000888 RID: 2184
		public float lightConeAngle;

		// Token: 0x04000889 RID: 2185
		public Vector3 lightPosition;

		// Token: 0x0400088A RID: 2186
		public int kernelSize;

		// Token: 0x0400088B RID: 2187
		public bool distanceBasedDenoiser;
	}
}
