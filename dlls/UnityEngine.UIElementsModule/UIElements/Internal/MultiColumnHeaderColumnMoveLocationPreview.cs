using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004C5 RID: 1221
	internal class MultiColumnHeaderColumnMoveLocationPreview : VisualElement
	{
		// Token: 0x06002625 RID: 9765 RVA: 0x0009F700 File Offset: 0x0009D900
		public MultiColumnHeaderColumnMoveLocationPreview()
		{
			base.AddToClassList(MultiColumnHeaderColumnMoveLocationPreview.ussClassName);
			base.pickingMode = PickingMode.Ignore;
			VisualElement visualElement = new VisualElement();
			visualElement.AddToClassList(MultiColumnHeaderColumnMoveLocationPreview.visualUssClassName);
			visualElement.pickingMode = PickingMode.Ignore;
			base.Add(visualElement);
		}

		// Token: 0x0400124F RID: 4687
		public static readonly string ussClassName = MultiColumnHeaderColumn.ussClassName + "__move-location-preview";

		// Token: 0x04001250 RID: 4688
		public static readonly string visualUssClassName = MultiColumnHeaderColumnMoveLocationPreview.ussClassName + "__visual";
	}
}
