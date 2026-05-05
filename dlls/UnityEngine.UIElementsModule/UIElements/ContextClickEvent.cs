using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001EA RID: 490
	public class ContextClickEvent : MouseEventBase<ContextClickEvent>
	{
		// Token: 0x06000EC0 RID: 3776 RVA: 0x00037D63 File Offset: 0x00035F63
		static ContextClickEvent()
		{
			EventBase<ContextClickEvent>.SetCreateFunction(() => new ContextClickEvent());
		}
	}
}
