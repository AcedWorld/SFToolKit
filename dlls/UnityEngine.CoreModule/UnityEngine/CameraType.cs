using System;

namespace UnityEngine
{
	// Token: 0x0200017E RID: 382
	[Flags]
	public enum CameraType
	{
		// Token: 0x040004B0 RID: 1200
		Game = 1,
		// Token: 0x040004B1 RID: 1201
		SceneView = 2,
		// Token: 0x040004B2 RID: 1202
		Preview = 4,
		// Token: 0x040004B3 RID: 1203
		VR = 8,
		// Token: 0x040004B4 RID: 1204
		Reflection = 16
	}
}
