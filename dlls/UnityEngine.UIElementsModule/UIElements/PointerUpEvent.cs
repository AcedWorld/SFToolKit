using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000220 RID: 544
	public sealed class PointerUpEvent : PointerEventBase<PointerUpEvent>
	{
		// Token: 0x06000FED RID: 4077 RVA: 0x0003ACB4 File Offset: 0x00038EB4
		static PointerUpEvent()
		{
			EventBase<PointerUpEvent>.SetCreateFunction(() => new PointerUpEvent());
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x0003ACCD File Offset: 0x00038ECD
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x0003A9CE File Offset: 0x00038BCE
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
			((IPointerEventInternal)this).triggeredByOS = true;
			((IPointerEventInternal)this).recomputeTopElementUnderPointer = true;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x0003ACDE File Offset: 0x00038EDE
		public PointerUpEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x0003ACF0 File Offset: 0x00038EF0
		protected internal override void PostDispatch(IPanel panel)
		{
			bool flag = PointerType.IsDirectManipulationDevice(base.pointerType);
			if (flag)
			{
				panel.ReleasePointer(base.pointerId);
				BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
				if (baseVisualElementPanel != null)
				{
					baseVisualElementPanel.ClearCachedElementUnderPointer(base.pointerId, this);
				}
			}
			bool flag2 = panel.ShouldSendCompatibilityMouseEvents(this);
			if (flag2)
			{
				using (MouseUpEvent pooled = MouseUpEvent.GetPooled(this))
				{
					pooled.target = base.target;
					pooled.target.SendEvent(pooled);
				}
			}
			base.PostDispatch(panel);
			panel.ActivateCompatibilityMouseEvents(base.pointerId);
		}
	}
}
