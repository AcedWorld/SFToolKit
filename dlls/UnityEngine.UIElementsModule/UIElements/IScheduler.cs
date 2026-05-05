using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002BA RID: 698
	internal interface IScheduler
	{
		// Token: 0x06001434 RID: 5172
		ScheduledItem ScheduleOnce(Action<TimerState> timerUpdateEvent, long delayMs);

		// Token: 0x06001435 RID: 5173
		ScheduledItem ScheduleUntil(Action<TimerState> timerUpdateEvent, long delayMs, long intervalMs, Func<bool> stopCondition = null);

		// Token: 0x06001436 RID: 5174
		ScheduledItem ScheduleForDuration(Action<TimerState> timerUpdateEvent, long delayMs, long intervalMs, long durationMs);

		// Token: 0x06001437 RID: 5175
		void Unschedule(ScheduledItem item);

		// Token: 0x06001438 RID: 5176
		void Schedule(ScheduledItem item);

		// Token: 0x06001439 RID: 5177
		void UpdateScheduledEvents();
	}
}
