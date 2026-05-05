using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001F4 RID: 500
	[EventCategory(EventCategory.EnterLeaveWindow)]
	public class MouseLeaveWindowEvent : MouseEventBase<MouseLeaveWindowEvent>
	{
		// Token: 0x06000EE7 RID: 3815 RVA: 0x00037FED File Offset: 0x000361ED
		static MouseLeaveWindowEvent()
		{
			EventBase<MouseLeaveWindowEvent>.SetCreateFunction(() => new MouseLeaveWindowEvent());
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x00038006 File Offset: 0x00036206
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00038017 File Offset: 0x00036217
		private void LocalInit()
		{
			base.propagation = EventBase.EventPropagation.Cancellable;
			((IMouseEventInternal)this).recomputeTopElementUnderMouse = false;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0003802A File Offset: 0x0003622A
		public MouseLeaveWindowEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0003803C File Offset: 0x0003623C
		public new static MouseLeaveWindowEvent GetPooled(Event systemEvent)
		{
			bool flag = systemEvent != null;
			if (flag)
			{
				PointerDeviceState.ReleaseAllButtons(PointerId.mousePointerId);
			}
			return MouseEventBase<MouseLeaveWindowEvent>.GetPooled(systemEvent);
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00038068 File Offset: 0x00036268
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
