using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000409 RID: 1033
	public interface IVisualElementScheduler
	{
		// Token: 0x06002105 RID: 8453
		IVisualElementScheduledItem Execute(Action<TimerState> timerUpdateEvent);

		// Token: 0x06002106 RID: 8454
		IVisualElementScheduledItem Execute(Action updateEvent);
	}
}
