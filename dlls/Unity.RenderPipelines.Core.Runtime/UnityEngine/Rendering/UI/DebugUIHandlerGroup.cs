using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000128 RID: 296
	public class DebugUIHandlerGroup : DebugUIHandlerWidget
	{
		// Token: 0x060008E0 RID: 2272 RVA: 0x00029474 File Offset: 0x00027674
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.Container>();
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
			if (this.m_Field.hideDisplayName)
			{
				this.header.gameObject.SetActive(false);
				return;
			}
			this.nameLabel.text = this.m_Field.displayName;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x000294D8 File Offset: 0x000276D8
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			if (!fromNext && !this.m_Container.IsDirectChild(previous))
			{
				DebugUIHandlerWidget lastItem = this.m_Container.GetLastItem();
				DebugManager.instance.ChangeSelection(lastItem, false);
				return true;
			}
			return false;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00029514 File Offset: 0x00027714
		public override DebugUIHandlerWidget Next()
		{
			if (this.m_Container == null)
			{
				return base.Next();
			}
			DebugUIHandlerWidget firstItem = this.m_Container.GetFirstItem();
			if (firstItem == null)
			{
				return base.Next();
			}
			return firstItem;
		}

		// Token: 0x04000532 RID: 1330
		public Text nameLabel;

		// Token: 0x04000533 RID: 1331
		public Transform header;

		// Token: 0x04000534 RID: 1332
		private DebugUI.Container m_Field;

		// Token: 0x04000535 RID: 1333
		private DebugUIHandlerContainer m_Container;
	}
}
