using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E2 RID: 482
	internal interface IMouseEventInternal
	{
		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000E74 RID: 3700
		// (set) Token: 0x06000E75 RID: 3701
		bool triggeredByOS { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000E76 RID: 3702
		// (set) Token: 0x06000E77 RID: 3703
		bool recomputeTopElementUnderMouse { get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000E78 RID: 3704
		// (set) Token: 0x06000E79 RID: 3705
		IPointerEvent sourcePointerEvent { get; set; }
	}
}
