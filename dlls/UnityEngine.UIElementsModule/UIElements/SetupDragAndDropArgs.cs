using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200016E RID: 366
	internal readonly struct SetupDragAndDropArgs
	{
		// Token: 0x06000BCF RID: 3023 RVA: 0x0002E3F8 File Offset: 0x0002C5F8
		internal SetupDragAndDropArgs(VisualElement draggedElement, IEnumerable<int> selectedIds, StartDragArgs startDragArgs)
		{
			this.draggedElement = draggedElement;
			this.selectedIds = selectedIds;
			this.startDragArgs = startDragArgs;
		}

		// Token: 0x0400058E RID: 1422
		public readonly VisualElement draggedElement;

		// Token: 0x0400058F RID: 1423
		public readonly IEnumerable<int> selectedIds;

		// Token: 0x04000590 RID: 1424
		public readonly StartDragArgs startDragArgs;
	}
}
