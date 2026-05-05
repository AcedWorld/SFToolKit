using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000436 RID: 1078
	[Flags]
	public enum BatchDrawCommandFlags
	{
		// Token: 0x04000D3D RID: 3389
		None = 0,
		// Token: 0x04000D3E RID: 3390
		FlipWinding = 1,
		// Token: 0x04000D3F RID: 3391
		HasMotion = 2,
		// Token: 0x04000D40 RID: 3392
		IsLightMapped = 4,
		// Token: 0x04000D41 RID: 3393
		HasSortingPosition = 8,
		// Token: 0x04000D42 RID: 3394
		LODCrossFade = 16
	}
}
