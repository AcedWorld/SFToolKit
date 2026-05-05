using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001EE RID: 494
	[EventCategory(EventCategory.EnterLeave)]
	public class MouseEnterEvent : MouseEventBase<MouseEnterEvent>
	{
		// Token: 0x06000ED1 RID: 3793 RVA: 0x00037EAB File Offset: 0x000360AB
		static MouseEnterEvent()
		{
			EventBase<MouseEnterEvent>.SetCreateFunction(() => new MouseEnterEvent());
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x00037EC4 File Offset: 0x000360C4
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x00037ED5 File Offset: 0x000360D5
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.IgnoreCompositeRoots);
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x00037EE1 File Offset: 0x000360E1
		public MouseEnterEvent()
		{
			this.LocalInit();
		}
	}
}
