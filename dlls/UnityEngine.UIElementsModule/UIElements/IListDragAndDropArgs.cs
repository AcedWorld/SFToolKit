using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000168 RID: 360
	internal interface IListDragAndDropArgs
	{
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000BB5 RID: 2997
		object target { get; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000BB6 RID: 2998
		int insertAtIndex { get; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000BB7 RID: 2999
		int parentId { get; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000BB8 RID: 3000
		int childIndex { get; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000BB9 RID: 3001
		DragAndDropData dragAndDropData { get; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000BBA RID: 3002
		DragAndDropPosition dragAndDropPosition { get; }
	}
}
