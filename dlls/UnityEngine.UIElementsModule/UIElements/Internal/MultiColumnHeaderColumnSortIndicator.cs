using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004D0 RID: 1232
	internal class MultiColumnHeaderColumnSortIndicator : VisualElement
	{
		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x06002698 RID: 9880 RVA: 0x000A22BB File Offset: 0x000A04BB
		// (set) Token: 0x06002699 RID: 9881 RVA: 0x000A22C8 File Offset: 0x000A04C8
		public string sortOrderLabel
		{
			get
			{
				return this.m_IndexLabel.text;
			}
			set
			{
				this.m_IndexLabel.text = value;
			}
		}

		// Token: 0x0600269A RID: 9882 RVA: 0x000A22D8 File Offset: 0x000A04D8
		public MultiColumnHeaderColumnSortIndicator()
		{
			base.AddToClassList(MultiColumnHeaderColumnSortIndicator.ussClassName);
			base.pickingMode = PickingMode.Ignore;
			VisualElement visualElement = new VisualElement
			{
				pickingMode = PickingMode.Ignore
			};
			visualElement.AddToClassList(MultiColumnHeaderColumnSortIndicator.arrowUssClassName);
			base.Add(visualElement);
			this.m_IndexLabel = new Label
			{
				pickingMode = PickingMode.Ignore
			};
			this.m_IndexLabel.AddToClassList(MultiColumnHeaderColumnSortIndicator.indexLabelUssClassName);
			base.Add(this.m_IndexLabel);
		}

		// Token: 0x04001291 RID: 4753
		public static readonly string ussClassName = MultiColumnHeaderColumn.ussClassName + "__sort-indicator";

		// Token: 0x04001292 RID: 4754
		public static readonly string arrowUssClassName = MultiColumnHeaderColumnSortIndicator.ussClassName + "__arrow";

		// Token: 0x04001293 RID: 4755
		public static readonly string indexLabelUssClassName = MultiColumnHeaderColumnSortIndicator.ussClassName + "__index-label";

		// Token: 0x04001294 RID: 4756
		private Label m_IndexLabel;
	}
}
