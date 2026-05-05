using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000179 RID: 377
	public enum AccelerationStructureStatus
	{
		// Token: 0x0400131A RID: 4890
		Clear,
		// Token: 0x0400131B RID: 4891
		Added,
		// Token: 0x0400131C RID: 4892
		Excluded,
		// Token: 0x0400131D RID: 4893
		TransparencyIssue = 4,
		// Token: 0x0400131E RID: 4894
		NullMaterial = 8,
		// Token: 0x0400131F RID: 4895
		MissingMesh = 16
	}
}
