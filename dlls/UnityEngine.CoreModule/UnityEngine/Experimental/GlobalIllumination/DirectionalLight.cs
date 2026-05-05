using System;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004BD RID: 1213
	public struct DirectionalLight
	{
		// Token: 0x04000FBE RID: 4030
		public int instanceID;

		// Token: 0x04000FBF RID: 4031
		public bool shadow;

		// Token: 0x04000FC0 RID: 4032
		public LightMode mode;

		// Token: 0x04000FC1 RID: 4033
		public Vector3 position;

		// Token: 0x04000FC2 RID: 4034
		public Quaternion orientation;

		// Token: 0x04000FC3 RID: 4035
		public LinearColor color;

		// Token: 0x04000FC4 RID: 4036
		public LinearColor indirectColor;

		// Token: 0x04000FC5 RID: 4037
		public float penumbraWidthRadian;

		// Token: 0x04000FC6 RID: 4038
		[Obsolete("Directional lights support cookies now. In order to position the cookie projection in the world, a position and full orientation are necessary. Use the position and orientation members instead of the direction parameter.", true)]
		public Vector3 direction;
	}
}
