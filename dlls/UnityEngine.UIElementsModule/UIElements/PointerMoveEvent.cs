using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200021C RID: 540
	[EventCategory(EventCategory.PointerMove)]
	public sealed class PointerMoveEvent : PointerEventBase<PointerMoveEvent>
	{
		// Token: 0x06000FDC RID: 4060 RVA: 0x0003AA93 File Offset: 0x00038C93
		static PointerMoveEvent()
		{
			EventBase<PointerMoveEvent>.SetCreateFunction(() => new PointerMoveEvent());
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000FDD RID: 4061 RVA: 0x0003AAAC File Offset: 0x00038CAC
		// (set) Token: 0x06000FDE RID: 4062 RVA: 0x0003AAB4 File Offset: 0x00038CB4
		internal bool isHandledByDraggable { get; set; }

		// Token: 0x06000FDF RID: 4063 RVA: 0x0003AABD File Offset: 0x00038CBD
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x0003AACE File Offset: 0x00038CCE
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
			((IPointerEventInternal)this).triggeredByOS = true;
			((IPointerEventInternal)this).recomputeTopElementUnderPointer = true;
			this.isHandledByDraggable = false;
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x0003AAF1 File Offset: 0x00038CF1
		public PointerMoveEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x0003AB04 File Offset: 0x00038D04
		protected internal override void PostDispatch(IPanel panel)
		{
			bool flag = panel.ShouldSendCompatibilityMouseEvents(this);
			if (flag)
			{
				bool flag2 = base.imguiEvent != null && base.imguiEvent.rawType == EventType.MouseDown;
				if (flag2)
				{
					using (MouseDownEvent pooled = MouseDownEvent.GetPooled(this))
					{
						pooled.target = base.target;
						pooled.target.SendEvent(pooled);
					}
				}
				else
				{
					bool flag3 = base.imguiEvent != null && base.imguiEvent.rawType == EventType.MouseUp;
					if (flag3)
					{
						using (MouseUpEvent pooled2 = MouseUpEvent.GetPooled(this))
						{
							pooled2.target = base.target;
							pooled2.target.SendEvent(pooled2);
						}
					}
					else
					{
						using (MouseMoveEvent pooled3 = MouseMoveEvent.GetPooled(this))
						{
							pooled3.target = base.target;
							pooled3.target.SendEvent(pooled3);
						}
					}
				}
			}
			base.PostDispatch(panel);
		}
	}
}
