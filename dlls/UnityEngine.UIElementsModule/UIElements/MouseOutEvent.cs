using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001F8 RID: 504
	[EventCategory(EventCategory.EnterLeave)]
	public class MouseOutEvent : MouseEventBase<MouseOutEvent>
	{
		// Token: 0x06000EF5 RID: 3829 RVA: 0x000380EE File Offset: 0x000362EE
		static MouseOutEvent()
		{
			EventBase<MouseOutEvent>.SetCreateFunction(() => new MouseOutEvent());
		}
	}
}
