using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200021A RID: 538
	public sealed class PointerDownEvent : PointerEventBase<PointerDownEvent>
	{
		// Token: 0x06000FD4 RID: 4052 RVA: 0x0003A9A4 File Offset: 0x00038BA4
		static PointerDownEvent()
		{
			EventBase<PointerDownEvent>.SetCreateFunction(() => new PointerDownEvent());
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x0003A9BD File Offset: 0x00038BBD
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x0003A9CE File Offset: 0x00038BCE
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
			((IPointerEventInternal)this).triggeredByOS = true;
			((IPointerEventInternal)this).recomputeTopElementUnderPointer = true;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x0003A9EA File Offset: 0x00038BEA
		public PointerDownEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x0003A9FC File Offset: 0x00038BFC
		protected internal override void PostDispatch(IPanel panel)
		{
			bool flag = !base.isDefaultPrevented;
			if (flag)
			{
				bool flag2 = panel.ShouldSendCompatibilityMouseEvents(this);
				if (flag2)
				{
					using (MouseDownEvent pooled = MouseDownEvent.GetPooled(this))
					{
						pooled.target = base.target;
						pooled.target.SendEvent(pooled);
					}
				}
			}
			else
			{
				panel.PreventCompatibilityMouseEvents(base.pointerId);
			}
			base.PostDispatch(panel);
		}
	}
}
