using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200043E RID: 1086
	internal enum VertexFlags
	{
		// Token: 0x04000F00 RID: 3840
		IsSolid,
		// Token: 0x04000F01 RID: 3841
		IsText,
		// Token: 0x04000F02 RID: 3842
		IsTextured,
		// Token: 0x04000F03 RID: 3843
		IsDynamic,
		// Token: 0x04000F04 RID: 3844
		IsSvgGradients,
		// Token: 0x04000F05 RID: 3845
		[Obsolete("Enum member VertexFlags.LastType has been deprecated. Use VertexFlags.IsGraphViewEdge instead.")]
		LastType = 10,
		// Token: 0x04000F06 RID: 3846
		IsGraphViewEdge = 10
	}
}
