using System;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000129 RID: 297
	public class DebugUIHandlerHBox : DebugUIHandlerWidget
	{
		// Token: 0x060008E4 RID: 2276 RVA: 0x0002955B File Offset: 0x0002775B
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00029570 File Offset: 0x00027770
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

		// Token: 0x060008E6 RID: 2278 RVA: 0x000295AC File Offset: 0x000277AC
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

		// Token: 0x04000536 RID: 1334
		private DebugUIHandlerContainer m_Container;
	}
}
