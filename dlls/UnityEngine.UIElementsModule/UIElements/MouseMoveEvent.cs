using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E8 RID: 488
	[EventCategory(EventCategory.PointerMove)]
	public class MouseMoveEvent : MouseEventBase<MouseMoveEvent>
	{
		// Token: 0x06000EB7 RID: 3767 RVA: 0x00037CCB File Offset: 0x00035ECB
		static MouseMoveEvent()
		{
			EventBase<MouseMoveEvent>.SetCreateFunction(() => new MouseMoveEvent());
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00037CE4 File Offset: 0x00035EE4
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00037CF5 File Offset: 0x00035EF5
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00037D00 File Offset: 0x00035F00
		public MouseMoveEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00037D14 File Offset: 0x00035F14
		public new static MouseMoveEvent GetPooled(Event systemEvent)
		{
			MouseMoveEvent pooled = MouseEventBase<MouseMoveEvent>.GetPooled(systemEvent);
			pooled.button = 0;
			return pooled;
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00037D38 File Offset: 0x00035F38
		internal static MouseMoveEvent GetPooled(PointerMoveEvent pointerEvent)
		{
			return MouseEventBase<MouseMoveEvent>.GetPooled(pointerEvent);
		}
	}
}
