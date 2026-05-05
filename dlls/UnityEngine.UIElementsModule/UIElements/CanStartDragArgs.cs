using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200016D RID: 365
	internal readonly struct CanStartDragArgs
	{
		// Token: 0x06000BCE RID: 3022 RVA: 0x0002E3E0 File Offset: 0x0002C5E0
		internal CanStartDragArgs(VisualElement draggedElement, int id, IEnumerable<int> selectedIds)
		{
			this.draggedElement = draggedElement;
			this.id = id;
			this.selectedIds = selectedIds;
		}

		// Token: 0x0400058B RID: 1419
		public readonly VisualElement draggedElement;

		// Token: 0x0400058C RID: 1420
		public readonly int id;

		// Token: 0x0400058D RID: 1421
		public readonly IEnumerable<int> selectedIds;
	}
}
