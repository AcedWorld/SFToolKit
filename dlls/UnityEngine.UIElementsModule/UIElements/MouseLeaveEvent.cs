using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001F0 RID: 496
	[EventCategory(EventCategory.EnterLeave)]
	public class MouseLeaveEvent : MouseEventBase<MouseLeaveEvent>
	{
		// Token: 0x06000ED8 RID: 3800 RVA: 0x00037F05 File Offset: 0x00036105
		static MouseLeaveEvent()
		{
			EventBase<MouseLeaveEvent>.SetCreateFunction(() => new MouseLeaveEvent());
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x00037F1E File Offset: 0x0003611E
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x00037ED5 File Offset: 0x000360D5
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.IgnoreCompositeRoots);
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x00037F2F File Offset: 0x0003612F
		public MouseLeaveEvent()
		{
			this.LocalInit();
		}
	}
}
