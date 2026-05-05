using System;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200013A RID: 314
	public class DebugUIHandlerVBox : DebugUIHandlerWidget
	{
		// Token: 0x06000952 RID: 2386 RVA: 0x0002ABC8 File Offset: 0x00028DC8
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0002ABE0 File Offset: 0x00028DE0
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

		// Token: 0x06000954 RID: 2388 RVA: 0x0002AC1C File Offset: 0x00028E1C
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

		// Token: 0x04000579 RID: 1401
		private DebugUIHandlerContainer m_Container;
	}
}
