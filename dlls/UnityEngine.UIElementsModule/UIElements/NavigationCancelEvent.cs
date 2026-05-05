using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000205 RID: 517
	public class NavigationCancelEvent : NavigationEventBase<NavigationCancelEvent>
	{
		// Token: 0x06000F34 RID: 3892 RVA: 0x00038D17 File Offset: 0x00036F17
		static NavigationCancelEvent()
		{
			EventBase<NavigationCancelEvent>.SetCreateFunction(() => new NavigationCancelEvent());
		}
	}
}
