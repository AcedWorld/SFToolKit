using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000228 RID: 552
	[EventCategory(EventCategory.EnterLeave)]
	public sealed class PointerLeaveEvent : PointerEventBase<PointerLeaveEvent>
	{
		// Token: 0x0600100C RID: 4108 RVA: 0x0003AF8B File Offset: 0x0003918B
		static PointerLeaveEvent()
		{
			EventBase<PointerLeaveEvent>.SetCreateFunction(() => new PointerLeaveEvent());
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0003AFA4 File Offset: 0x000391A4
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x0003AF5B File Offset: 0x0003915B
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.IgnoreCompositeRoots);
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x0003AFB5 File Offset: 0x000391B5
		public PointerLeaveEvent()
		{
			this.LocalInit();
		}
	}
}
