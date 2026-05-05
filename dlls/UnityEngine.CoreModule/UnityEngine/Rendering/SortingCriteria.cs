using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000475 RID: 1141
	[Flags]
	public enum SortingCriteria
	{
		// Token: 0x04000EA3 RID: 3747
		None = 0,
		// Token: 0x04000EA4 RID: 3748
		SortingLayer = 1,
		// Token: 0x04000EA5 RID: 3749
		RenderQueue = 2,
		// Token: 0x04000EA6 RID: 3750
		BackToFront = 4,
		// Token: 0x04000EA7 RID: 3751
		QuantizedFrontToBack = 8,
		// Token: 0x04000EA8 RID: 3752
		OptimizeStateChanges = 16,
		// Token: 0x04000EA9 RID: 3753
		CanvasOrder = 32,
		// Token: 0x04000EAA RID: 3754
		RendererPriority = 64,
		// Token: 0x04000EAB RID: 3755
		CommonOpaque = 59,
		// Token: 0x04000EAC RID: 3756
		CommonTransparent = 23
	}
}
