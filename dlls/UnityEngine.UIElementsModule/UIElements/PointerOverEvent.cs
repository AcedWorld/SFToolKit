using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200022A RID: 554
	[EventCategory(EventCategory.EnterLeave)]
	public sealed class PointerOverEvent : PointerEventBase<PointerOverEvent>
	{
		// Token: 0x06001013 RID: 4115 RVA: 0x0003AFD9 File Offset: 0x000391D9
		static PointerOverEvent()
		{
			EventBase<PointerOverEvent>.SetCreateFunction(() => new PointerOverEvent());
		}
	}
}
