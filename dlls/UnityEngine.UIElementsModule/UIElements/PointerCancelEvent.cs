using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000222 RID: 546
	public sealed class PointerCancelEvent : PointerEventBase<PointerCancelEvent>
	{
		// Token: 0x06000FF5 RID: 4085 RVA: 0x0003ADAB File Offset: 0x00038FAB
		static PointerCancelEvent()
		{
			EventBase<PointerCancelEvent>.SetCreateFunction(() => new PointerCancelEvent());
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x0003ADC4 File Offset: 0x00038FC4
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x0003ADD5 File Offset: 0x00038FD5
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.SkipDisabledElements);
			((IPointerEventInternal)this).triggeredByOS = true;
			((IPointerEventInternal)this).recomputeTopElementUnderPointer = true;
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x0003ADF1 File Offset: 0x00038FF1
		public PointerCancelEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x0003AE04 File Offset: 0x00039004
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
					base.target.SendEvent(pooled);
				}
			}
			base.PostDispatch(panel);
			panel.ActivateCompatibilityMouseEvents(base.pointerId);
		}
	}
}
