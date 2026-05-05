using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000226 RID: 550
	[EventCategory(EventCategory.EnterLeave)]
	public sealed class PointerEnterEvent : PointerEventBase<PointerEnterEvent>
	{
		// Token: 0x06001005 RID: 4101 RVA: 0x0003AF31 File Offset: 0x00039131
		static PointerEnterEvent()
		{
			EventBase<PointerEnterEvent>.SetCreateFunction(() => new PointerEnterEvent());
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x0003AF4A File Offset: 0x0003914A
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x0003AF5B File Offset: 0x0003915B
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.IgnoreCompositeRoots);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x0003AF67 File Offset: 0x00039167
		public PointerEnterEvent()
		{
			this.LocalInit();
		}
	}
}
