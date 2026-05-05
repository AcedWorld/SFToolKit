using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200023D RID: 573
	public sealed class TransitionEndEvent : TransitionEventBase<TransitionEndEvent>
	{
		// Token: 0x06001057 RID: 4183 RVA: 0x0003B5EE File Offset: 0x000397EE
		static TransitionEndEvent()
		{
			EventBase<TransitionEndEvent>.SetCreateFunction(() => new TransitionEndEvent());
		}
	}
}
