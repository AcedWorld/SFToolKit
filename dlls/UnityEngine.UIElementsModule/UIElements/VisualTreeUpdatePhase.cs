using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000419 RID: 1049
	internal enum VisualTreeUpdatePhase
	{
		// Token: 0x04000E36 RID: 3638
		ViewData,
		// Token: 0x04000E37 RID: 3639
		Bindings,
		// Token: 0x04000E38 RID: 3640
		Animation,
		// Token: 0x04000E39 RID: 3641
		Styles,
		// Token: 0x04000E3A RID: 3642
		Layout,
		// Token: 0x04000E3B RID: 3643
		TransformClip,
		// Token: 0x04000E3C RID: 3644
		Repaint,
		// Token: 0x04000E3D RID: 3645
		Count
	}
}
