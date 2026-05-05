using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200023B RID: 571
	public sealed class TransitionStartEvent : TransitionEventBase<TransitionStartEvent>
	{
		// Token: 0x06001052 RID: 4178 RVA: 0x0003B5B9 File Offset: 0x000397B9
		static TransitionStartEvent()
		{
			EventBase<TransitionStartEvent>.SetCreateFunction(() => new TransitionStartEvent());
		}
	}
}
