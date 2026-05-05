using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200022C RID: 556
	[EventCategory(EventCategory.EnterLeave)]
	public sealed class PointerOutEvent : PointerEventBase<PointerOutEvent>
	{
		// Token: 0x06001018 RID: 4120 RVA: 0x0003B00E File Offset: 0x0003920E
		static PointerOutEvent()
		{
			EventBase<PointerOutEvent>.SetCreateFunction(() => new PointerOutEvent());
		}
	}
}
