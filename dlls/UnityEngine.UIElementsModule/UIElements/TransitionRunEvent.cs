using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000239 RID: 569
	public sealed class TransitionRunEvent : TransitionEventBase<TransitionRunEvent>
	{
		// Token: 0x0600104D RID: 4173 RVA: 0x0003B584 File Offset: 0x00039784
		static TransitionRunEvent()
		{
			EventBase<TransitionRunEvent>.SetCreateFunction(() => new TransitionRunEvent());
		}
	}
}
