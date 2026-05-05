using System;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004C4 RID: 1220
	public struct Cookie
	{
		// Token: 0x06002ABE RID: 10942 RVA: 0x00047D38 File Offset: 0x00045F38
		public static Cookie Defaults()
		{
			Cookie result;
			result.instanceID = 0;
			result.scale = 1f;
			result.sizes = new Vector2(1f, 1f);
			return result;
		}

		// Token: 0x04001008 RID: 4104
		public int instanceID;

		// Token: 0x04001009 RID: 4105
		public float scale;

		// Token: 0x0400100A RID: 4106
		public Vector2 sizes;
	}
}
