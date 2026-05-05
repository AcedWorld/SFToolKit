using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004C4 RID: 1220
	internal class MultiColumnHeaderColumnMovePreview : VisualElement
	{
		// Token: 0x06002623 RID: 9763 RVA: 0x0009F6CC File Offset: 0x0009D8CC
		public MultiColumnHeaderColumnMovePreview()
		{
			base.AddToClassList(MultiColumnHeaderColumnMovePreview.ussClassName);
			base.pickingMode = PickingMode.Ignore;
		}

		// Token: 0x0400124E RID: 4686
		public static readonly string ussClassName = MultiColumnHeaderColumn.ussClassName + "__move-preview";
	}
}
