using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001F6 RID: 502
	[EventCategory(EventCategory.EnterLeave)]
	public class MouseOverEvent : MouseEventBase<MouseOverEvent>
	{
		// Token: 0x06000EF0 RID: 3824 RVA: 0x000380B9 File Offset: 0x000362B9
		static MouseOverEvent()
		{
			EventBase<MouseOverEvent>.SetCreateFunction(() => new MouseOverEvent());
		}
	}
}
