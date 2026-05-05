using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004D1 RID: 1233
	internal class MultiColumnHeaderColumnIcon : Image
	{
		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x0600269C RID: 9884 RVA: 0x000A2392 File Offset: 0x000A0592
		// (set) Token: 0x0600269D RID: 9885 RVA: 0x000A239A File Offset: 0x000A059A
		public bool isImageInline { get; set; }

		// Token: 0x0600269E RID: 9886 RVA: 0x000A23A3 File Offset: 0x000A05A3
		public MultiColumnHeaderColumnIcon()
		{
			base.AddToClassList(MultiColumnHeaderColumnIcon.ussClassName);
			base.RegisterCallback<CustomStyleResolvedEvent>(delegate(CustomStyleResolvedEvent evt)
			{
				this.UpdateClassList();
			}, TrickleDown.NoTrickleDown);
		}

		// Token: 0x0600269F RID: 9887 RVA: 0x000A23D0 File Offset: 0x000A05D0
		public void UpdateClassList()
		{
			base.parent.RemoveFromClassList(MultiColumnHeaderColumn.hasIconUssClassName);
			bool flag = base.image != null || base.sprite != null || base.vectorImage != null;
			if (flag)
			{
				base.parent.AddToClassList(MultiColumnHeaderColumn.hasIconUssClassName);
			}
		}

		// Token: 0x04001295 RID: 4757
		public new static readonly string ussClassName = MultiColumnHeaderColumn.ussClassName + "__icon";
	}
}
