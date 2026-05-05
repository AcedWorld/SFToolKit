using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200023F RID: 575
	public sealed class TransitionCancelEvent : TransitionEventBase<TransitionCancelEvent>
	{
		// Token: 0x0600105C RID: 4188 RVA: 0x0003B623 File Offset: 0x00039823
		static TransitionCancelEvent()
		{
			EventBase<TransitionCancelEvent>.SetCreateFunction(() => new TransitionCancelEvent());
		}
	}
}
