using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E4 RID: 484
	public class MouseDownEvent : MouseEventBase<MouseDownEvent>
	{
		// Token: 0x06000EA0 RID: 3744 RVA: 0x00037AB8 File Offset: 0x00035CB8
		static MouseDownEvent()
		{
			EventBase<MouseDownEvent>.SetCreateFunction(() => new MouseDownEvent());
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00037AD1 File Offset: 0x00035CD1
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00037AE2 File Offset: 0x00035CE2
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x00037AEE File Offset: 0x00035CEE
		public MouseDownEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x00037B00 File Offset: 0x00035D00
		public new static MouseDownEvent GetPooled(Event systemEvent)
		{
			bool flag = systemEvent != null;
			if (flag)
			{
				PointerDeviceState.PressButton(PointerId.mousePointerId, systemEvent.button);
			}
			return MouseEventBase<MouseDownEvent>.GetPooled(systemEvent);
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x00037B34 File Offset: 0x00035D34
		private static MouseDownEvent MakeFromPointerEvent(IPointerEvent pointerEvent)
		{
			bool flag = pointerEvent != null && pointerEvent.button >= 0;
			if (flag)
			{
				PointerDeviceState.PressButton(PointerId.mousePointerId, pointerEvent.button);
			}
			return MouseEventBase<MouseDownEvent>.GetPooled(pointerEvent);
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x00037B78 File Offset: 0x00035D78
		internal static MouseDownEvent GetPooled(PointerDownEvent pointerEvent)
		{
			return MouseDownEvent.MakeFromPointerEvent(pointerEvent);
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x00037B90 File Offset: 0x00035D90
		internal static MouseDownEvent GetPooled(PointerMoveEvent pointerEvent)
		{
			return MouseDownEvent.MakeFromPointerEvent(pointerEvent);
		}
	}
}
