using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001FA RID: 506
	public class ContextualMenuPopulateEvent : MouseEventBase<ContextualMenuPopulateEvent>
	{
		// Token: 0x06000EFA RID: 3834 RVA: 0x00038123 File Offset: 0x00036323
		static ContextualMenuPopulateEvent()
		{
			EventBase<ContextualMenuPopulateEvent>.SetCreateFunction(() => new ContextualMenuPopulateEvent());
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x0003813C File Offset: 0x0003633C
		// (set) Token: 0x06000EFC RID: 3836 RVA: 0x00038144 File Offset: 0x00036344
		public DropdownMenu menu { get; private set; }

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0003814D File Offset: 0x0003634D
		// (set) Token: 0x06000EFE RID: 3838 RVA: 0x00038155 File Offset: 0x00036355
		public EventBase triggerEvent { get; private set; }

		// Token: 0x06000EFF RID: 3839 RVA: 0x00038160 File Offset: 0x00036360
		public static ContextualMenuPopulateEvent GetPooled(EventBase triggerEvent, DropdownMenu menu, IEventHandler target, ContextualMenuManager menuManager)
		{
			ContextualMenuPopulateEvent pooled = EventBase<ContextualMenuPopulateEvent>.GetPooled(triggerEvent);
			bool flag = triggerEvent != null;
			if (flag)
			{
				triggerEvent.Acquire();
				pooled.triggerEvent = triggerEvent;
				IMouseEvent mouseEvent = triggerEvent as IMouseEvent;
				bool flag2 = mouseEvent != null;
				if (flag2)
				{
					pooled.modifiers = mouseEvent.modifiers;
					pooled.mousePosition = mouseEvent.mousePosition;
					pooled.localMousePosition = mouseEvent.mousePosition;
					pooled.mouseDelta = mouseEvent.mouseDelta;
					pooled.button = mouseEvent.button;
					pooled.clickCount = mouseEvent.clickCount;
				}
				else
				{
					IPointerEvent pointerEvent = triggerEvent as IPointerEvent;
					bool flag3 = pointerEvent != null;
					if (flag3)
					{
						pooled.modifiers = pointerEvent.modifiers;
						pooled.mousePosition = pointerEvent.position;
						pooled.localMousePosition = pointerEvent.position;
						pooled.mouseDelta = pointerEvent.deltaPosition;
						pooled.button = pointerEvent.button;
						pooled.clickCount = pointerEvent.clickCount;
					}
				}
				IMouseEventInternal mouseEventInternal = triggerEvent as IMouseEventInternal;
				bool flag4 = mouseEventInternal != null;
				if (flag4)
				{
					((IMouseEventInternal)pooled).triggeredByOS = mouseEventInternal.triggeredByOS;
				}
				else
				{
					IPointerEventInternal pointerEventInternal = triggerEvent as IPointerEventInternal;
					bool flag5 = pointerEventInternal != null;
					if (flag5)
					{
						((IMouseEventInternal)pooled).triggeredByOS = pointerEventInternal.triggeredByOS;
					}
				}
			}
			pooled.target = target;
			pooled.menu = menu;
			pooled.m_ContextualMenuManager = menuManager;
			return pooled;
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x000382D3 File Offset: 0x000364D3
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x000382E4 File Offset: 0x000364E4
		private void LocalInit()
		{
			this.menu = null;
			this.m_ContextualMenuManager = null;
			bool flag = this.triggerEvent != null;
			if (flag)
			{
				this.triggerEvent.Dispose();
				this.triggerEvent = null;
			}
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00038324 File Offset: 0x00036524
		public ContextualMenuPopulateEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x00038338 File Offset: 0x00036538
		protected internal override void PostDispatch(IPanel panel)
		{
			bool flag = !base.isDefaultPrevented && this.m_ContextualMenuManager != null;
			if (flag)
			{
				this.menu.PrepareForDisplay(this.triggerEvent);
				this.m_ContextualMenuManager.DoDisplayMenu(this.menu, this.triggerEvent);
			}
			base.PostDispatch(panel);
		}

		// Token: 0x040006D0 RID: 1744
		private ContextualMenuManager m_ContextualMenuManager;
	}
}
