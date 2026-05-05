using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001CF RID: 463
	internal interface IEventDispatchingStrategy
	{
		// Token: 0x06000E0E RID: 3598
		bool CanDispatchEvent(EventBase evt);

		// Token: 0x06000E0F RID: 3599
		void DispatchEvent(EventBase evt, IPanel panel);
	}
}
