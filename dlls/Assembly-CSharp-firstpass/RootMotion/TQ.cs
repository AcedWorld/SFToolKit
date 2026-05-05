using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200000F RID: 15
	public class TQ
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00002226 File Offset: 0x00000426
		public TQ()
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000026C6 File Offset: 0x000008C6
		public TQ(Vector3 translation, Quaternion rotation)
		{
			this.t = translation;
			this.q = rotation;
		}

		// Token: 0x04000046 RID: 70
		public Vector3 t;

		// Token: 0x04000047 RID: 71
		public Quaternion q;
	}
}
