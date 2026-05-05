using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004D3 RID: 1235
	internal class MultiColumnHeaderColumnResizeHandle : VisualElement
	{
		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x060026BF RID: 9919 RVA: 0x000A2EED File Offset: 0x000A10ED
		public VisualElement dragArea { get; }

		// Token: 0x060026C0 RID: 9920 RVA: 0x000A2EF8 File Offset: 0x000A10F8
		public MultiColumnHeaderColumnResizeHandle()
		{
			base.AddToClassList(MultiColumnHeaderColumnResizeHandle.ussClassName);
			this.dragArea = new VisualElement
			{
				focusable = true
			};
			this.dragArea.AddToClassList(MultiColumnHeaderColumnResizeHandle.dragAreaUssClassName);
			base.Add(this.dragArea);
		}

		// Token: 0x040012AF RID: 4783
		public static readonly string ussClassName = MultiColumnCollectionHeader.ussClassName + "__column-resize-handle";

		// Token: 0x040012B0 RID: 4784
		public static readonly string dragAreaUssClassName = MultiColumnHeaderColumnResizeHandle.ussClassName + "__drag-area";
	}
}
