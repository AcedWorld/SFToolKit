using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001F2 RID: 498
	[EventCategory(EventCategory.EnterLeaveWindow)]
	public class MouseEnterWindowEvent : MouseEventBase<MouseEnterWindowEvent>
	{
		// Token: 0x06000EDF RID: 3807 RVA: 0x00037F53 File Offset: 0x00036153
		static MouseEnterWindowEvent()
		{
			EventBase<MouseEnterWindowEvent>.SetCreateFunction(() => new MouseEnterWindowEvent());
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x00037F6C File Offset: 0x0003616C
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x00037F7D File Offset: 0x0003617D
		private void LocalInit()
		{
			base.propagation = EventBase.EventPropagation.Cancellable;
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x00037F88 File Offset: 0x00036188
		public MouseEnterWindowEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00037F9C File Offset: 0x0003619C
		protected internal override void PostDispatch(IPanel panel)
		{
			EventBase eventBase = ((IMouseEventInternal)this).sourcePointerEvent as EventBase;
			bool flag = eventBase == null;
			if (flag)
			{
				BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
				if (baseVisualElementPanel != null)
				{
					baseVisualElementPanel.CommitElementUnderPointers();
				}
			}
			base.PostDispatch(panel);
		}
	}
}
