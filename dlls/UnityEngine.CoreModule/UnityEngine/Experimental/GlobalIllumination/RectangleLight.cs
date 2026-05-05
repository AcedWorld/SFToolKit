using System;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004C0 RID: 1216
	public struct RectangleLight
	{
		// Token: 0x04000FDE RID: 4062
		public int instanceID;

		// Token: 0x04000FDF RID: 4063
		public bool shadow;

		// Token: 0x04000FE0 RID: 4064
		public LightMode mode;

		// Token: 0x04000FE1 RID: 4065
		public Vector3 position;

		// Token: 0x04000FE2 RID: 4066
		public Quaternion orientation;

		// Token: 0x04000FE3 RID: 4067
		public LinearColor color;

		// Token: 0x04000FE4 RID: 4068
		public LinearColor indirectColor;

		// Token: 0x04000FE5 RID: 4069
		public float range;

		// Token: 0x04000FE6 RID: 4070
		public float width;

		// Token: 0x04000FE7 RID: 4071
		public float height;

		// Token: 0x04000FE8 RID: 4072
		public FalloffType falloff;
	}
}
