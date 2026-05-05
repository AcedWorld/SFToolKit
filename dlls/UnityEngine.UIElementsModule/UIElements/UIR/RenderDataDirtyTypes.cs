using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200045A RID: 1114
	[Flags]
	internal enum RenderDataDirtyTypes
	{
		// Token: 0x04000FD5 RID: 4053
		None = 0,
		// Token: 0x04000FD6 RID: 4054
		Transform = 1,
		// Token: 0x04000FD7 RID: 4055
		ClipRectSize = 2,
		// Token: 0x04000FD8 RID: 4056
		Clipping = 4,
		// Token: 0x04000FD9 RID: 4057
		ClippingHierarchy = 8,
		// Token: 0x04000FDA RID: 4058
		Visuals = 16,
		// Token: 0x04000FDB RID: 4059
		VisualsHierarchy = 32,
		// Token: 0x04000FDC RID: 4060
		VisualsOpacityId = 64,
		// Token: 0x04000FDD RID: 4061
		Opacity = 128,
		// Token: 0x04000FDE RID: 4062
		OpacityHierarchy = 256,
		// Token: 0x04000FDF RID: 4063
		Color = 512,
		// Token: 0x04000FE0 RID: 4064
		AllVisuals = 112
	}
}
