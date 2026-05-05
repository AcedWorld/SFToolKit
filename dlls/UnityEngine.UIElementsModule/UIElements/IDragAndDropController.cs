using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x0200016B RID: 363
	internal interface IDragAndDropController<in TArgs>
	{
		// Token: 0x06000BC7 RID: 3015
		bool CanStartDrag(IEnumerable<int> itemIds);

		// Token: 0x06000BC8 RID: 3016
		StartDragArgs SetupDragAndDrop(IEnumerable<int> itemIds, bool skipText = false);

		// Token: 0x06000BC9 RID: 3017
		DragVisualMode HandleDragAndDrop(TArgs args);

		// Token: 0x06000BCA RID: 3018
		void OnDrop(TArgs args);

		// Token: 0x06000BCB RID: 3019 RVA: 0x00003CD2 File Offset: 0x00001ED2
		void DragCleanup()
		{
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x00003CD2 File Offset: 0x00001ED2
		void HandleAutoExpand(ReusableCollectionItem item, Vector2 pointerPosition)
		{
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0002E3D9 File Offset: 0x0002C5D9
		IEnumerable<int> GetSortedSelectedIds()
		{
			return Enumerable.Empty<int>();
		}
	}
}
