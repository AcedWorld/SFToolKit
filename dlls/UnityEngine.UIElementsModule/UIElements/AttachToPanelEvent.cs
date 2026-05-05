using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200020B RID: 523
	public class AttachToPanelEvent : PanelChangedEventBase<AttachToPanelEvent>
	{
		// Token: 0x06000F46 RID: 3910 RVA: 0x00038E0C File Offset: 0x0003700C
		static AttachToPanelEvent()
		{
			EventBase<AttachToPanelEvent>.SetCreateFunction(() => new AttachToPanelEvent());
		}
	}
}
