using System;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004BE RID: 1214
	public struct PointLight
	{
		// Token: 0x04000FC7 RID: 4039
		public int instanceID;

		// Token: 0x04000FC8 RID: 4040
		public bool shadow;

		// Token: 0x04000FC9 RID: 4041
		public LightMode mode;

		// Token: 0x04000FCA RID: 4042
		public Vector3 position;

		// Token: 0x04000FCB RID: 4043
		public Quaternion orientation;

		// Token: 0x04000FCC RID: 4044
		public LinearColor color;

		// Token: 0x04000FCD RID: 4045
		public LinearColor indirectColor;

		// Token: 0x04000FCE RID: 4046
		public float range;

		// Token: 0x04000FCF RID: 4047
		public float sphereRadius;

		// Token: 0x04000FD0 RID: 4048
		public FalloffType falloff;
	}
}
