using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000207 RID: 519
	public class NavigationSubmitEvent : NavigationEventBase<NavigationSubmitEvent>
	{
		// Token: 0x06000F39 RID: 3897 RVA: 0x00038D4C File Offset: 0x00036F4C
		static NavigationSubmitEvent()
		{
			EventBase<NavigationSubmitEvent>.SetCreateFunction(() => new NavigationSubmitEvent());
		}
	}
}
