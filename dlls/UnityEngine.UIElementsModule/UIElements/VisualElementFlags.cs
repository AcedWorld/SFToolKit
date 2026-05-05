using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003EF RID: 1007
	[Flags]
	internal enum VisualElementFlags
	{
		// Token: 0x04000DA9 RID: 3497
		WorldTransformDirty = 1,
		// Token: 0x04000DAA RID: 3498
		WorldTransformInverseDirty = 2,
		// Token: 0x04000DAB RID: 3499
		WorldClipDirty = 4,
		// Token: 0x04000DAC RID: 3500
		BoundingBoxDirty = 8,
		// Token: 0x04000DAD RID: 3501
		WorldBoundingBoxDirty = 16,
		// Token: 0x04000DAE RID: 3502
		EventCallbackParentCategoriesDirty = 32,
		// Token: 0x04000DAF RID: 3503
		LayoutManual = 64,
		// Token: 0x04000DB0 RID: 3504
		CompositeRoot = 128,
		// Token: 0x04000DB1 RID: 3505
		RequireMeasureFunction = 256,
		// Token: 0x04000DB2 RID: 3506
		EnableViewDataPersistence = 512,
		// Token: 0x04000DB3 RID: 3507
		DisableClipping = 1024,
		// Token: 0x04000DB4 RID: 3508
		NeedsAttachToPanelEvent = 2048,
		// Token: 0x04000DB5 RID: 3509
		HierarchyDisplayed = 4096,
		// Token: 0x04000DB6 RID: 3510
		StyleInitialized = 8192,
		// Token: 0x04000DB7 RID: 3511
		Init = 4159
	}
}
