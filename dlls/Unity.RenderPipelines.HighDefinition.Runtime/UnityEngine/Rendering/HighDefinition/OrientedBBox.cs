using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000030 RID: 48
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Core\\Utilities\\GeometryUtils.cs")]
	internal struct OrientedBBox
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000586E File Offset: 0x00003A6E
		public Vector3 forward
		{
			get
			{
				return Vector3.Cross(this.up, this.right);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005884 File Offset: 0x00003A84
		public OrientedBBox(Matrix4x4 trs)
		{
			Vector3 a = trs.GetColumn(0);
			Vector3 a2 = trs.GetColumn(1);
			Vector3 vector = trs.GetColumn(2);
			this.center = trs.GetColumn(3);
			this.right = a * (1f / a.magnitude);
			this.up = a2 * (1f / a2.magnitude);
			this.extentX = 0.5f * a.magnitude;
			this.extentY = 0.5f * a2.magnitude;
			this.extentZ = 0.5f * vector.magnitude;
		}

		// Token: 0x040000DF RID: 223
		public Vector3 right;

		// Token: 0x040000E0 RID: 224
		public float extentX;

		// Token: 0x040000E1 RID: 225
		public Vector3 up;

		// Token: 0x040000E2 RID: 226
		public float extentY;

		// Token: 0x040000E3 RID: 227
		public Vector3 center;

		// Token: 0x040000E4 RID: 228
		public float extentZ;
	}
}
