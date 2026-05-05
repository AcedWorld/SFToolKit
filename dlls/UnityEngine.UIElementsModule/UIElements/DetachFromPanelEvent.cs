using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200020D RID: 525
	public class DetachFromPanelEvent : PanelChangedEventBase<DetachFromPanelEvent>
	{
		// Token: 0x06000F4B RID: 3915 RVA: 0x00038E41 File Offset: 0x00037041
		static DetachFromPanelEvent()
		{
			EventBase<DetachFromPanelEvent>.SetCreateFunction(() => new DetachFromPanelEvent());
		}
	}
}
