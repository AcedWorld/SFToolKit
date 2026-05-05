using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E6 RID: 486
	public class MouseUpEvent : MouseEventBase<MouseUpEvent>
	{
		// Token: 0x06000EAB RID: 3755 RVA: 0x00037BBB File Offset: 0x00035DBB
		static MouseUpEvent()
		{
			EventBase<MouseUpEvent>.SetCreateFunction(() => new MouseUpEvent());
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00037BD4 File Offset: 0x00035DD4
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x00037AE2 File Offset: 0x00035CE2
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00037BE5 File Offset: 0x00035DE5
		public MouseUpEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00037BF8 File Offset: 0x00035DF8
		public new static MouseUpEvent GetPooled(Event systemEvent)
		{
			bool flag = systemEvent != null;
			if (flag)
			{
				PointerDeviceState.ReleaseButton(PointerId.mousePointerId, systemEvent.button);
			}
			return MouseEventBase<MouseUpEvent>.GetPooled(systemEvent);
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00037C2C File Offset: 0x00035E2C
		private static MouseUpEvent MakeFromPointerEvent(IPointerEvent pointerEvent)
		{
			bool flag = pointerEvent != null && pointerEvent.button >= 0;
			if (flag)
			{
				PointerDeviceState.ReleaseButton(PointerId.mousePointerId, pointerEvent.button);
			}
			return MouseEventBase<MouseUpEvent>.GetPooled(pointerEvent);
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x00037C70 File Offset: 0x00035E70
		internal static MouseUpEvent GetPooled(PointerUpEvent pointerEvent)
		{
			return MouseUpEvent.MakeFromPointerEvent(pointerEvent);
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00037C88 File Offset: 0x00035E88
		internal static MouseUpEvent GetPooled(PointerMoveEvent pointerEvent)
		{
			return MouseUpEvent.MakeFromPointerEvent(pointerEvent);
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x00037CA0 File Offset: 0x00035EA0
		internal static MouseUpEvent GetPooled(PointerCancelEvent pointerEvent)
		{
			return MouseUpEvent.MakeFromPointerEvent(pointerEvent);
		}
	}
}
