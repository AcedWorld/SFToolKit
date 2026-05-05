using System;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004C1 RID: 1217
	public struct DiscLight
	{
		// Token: 0x04000FE9 RID: 4073
		public int instanceID;

		// Token: 0x04000FEA RID: 4074
		public bool shadow;

		// Token: 0x04000FEB RID: 4075
		public LightMode mode;

		// Token: 0x04000FEC RID: 4076
		public Vector3 position;

		// Token: 0x04000FED RID: 4077
		public Quaternion orientation;

		// Token: 0x04000FEE RID: 4078
		public LinearColor color;

		// Token: 0x04000FEF RID: 4079
		public LinearColor indirectColor;

		// Token: 0x04000FF0 RID: 4080
		public float range;

		// Token: 0x04000FF1 RID: 4081
		public float radius;

		// Token: 0x04000FF2 RID: 4082
		public FalloffType falloff;
	}
}
