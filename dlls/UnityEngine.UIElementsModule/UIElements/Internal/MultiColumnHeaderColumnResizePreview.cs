using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004C7 RID: 1223
	internal class MultiColumnHeaderColumnResizePreview : VisualElement
	{
		// Token: 0x06002648 RID: 9800 RVA: 0x000A03D8 File Offset: 0x0009E5D8
		public MultiColumnHeaderColumnResizePreview()
		{
			base.AddToClassList(MultiColumnHeaderColumnResizePreview.ussClassName);
			base.pickingMode = PickingMode.Ignore;
			VisualElement visualElement = new VisualElement
			{
				pickingMode = PickingMode.Ignore
			};
			visualElement.AddToClassList(MultiColumnHeaderColumnResizePreview.visualUssClassName);
			base.Add(visualElement);
		}

		// Token: 0x04001262 RID: 4706
		public static readonly string ussClassName = MultiColumnHeaderColumn.ussClassName + "__resize-preview";

		// Token: 0x04001263 RID: 4707
		public static readonly string visualUssClassName = MultiColumnHeaderColumnResizePreview.ussClassName + "__visual";
	}
}
