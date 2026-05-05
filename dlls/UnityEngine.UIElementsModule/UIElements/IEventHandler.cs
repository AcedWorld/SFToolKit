using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C2 RID: 450
	public interface IEventHandler
	{
		// Token: 0x06000DCD RID: 3533
		void SendEvent(EventBase e);

		// Token: 0x06000DCE RID: 3534
		void HandleEvent(EventBase evt);

		// Token: 0x06000DCF RID: 3535
		bool HasTrickleDownHandlers();

		// Token: 0x06000DD0 RID: 3536
		bool HasBubbleUpHandlers();
	}
}
