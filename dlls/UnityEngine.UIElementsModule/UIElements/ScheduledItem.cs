using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002BB RID: 699
	internal abstract class ScheduledItem
	{
		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x0600143A RID: 5178 RVA: 0x00047E68 File Offset: 0x00046068
		// (set) Token: 0x0600143B RID: 5179 RVA: 0x00047E70 File Offset: 0x00046070
		public long startMs { get; set; }

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x0600143C RID: 5180 RVA: 0x00047E79 File Offset: 0x00046079
		// (set) Token: 0x0600143D RID: 5181 RVA: 0x00047E81 File Offset: 0x00046081
		public long delayMs { get; set; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x0600143E RID: 5182 RVA: 0x00047E8A File Offset: 0x0004608A
		// (set) Token: 0x0600143F RID: 5183 RVA: 0x00047E92 File Offset: 0x00046092
		public long intervalMs { get; set; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06001440 RID: 5184 RVA: 0x00047E9B File Offset: 0x0004609B
		// (set) Token: 0x06001441 RID: 5185 RVA: 0x00047EA3 File Offset: 0x000460A3
		public long endTimeMs { get; private set; }

		// Token: 0x06001442 RID: 5186 RVA: 0x00047EAC File Offset: 0x000460AC
		public ScheduledItem()
		{
			this.ResetStartTime();
			this.timerUpdateStopCondition = ScheduledItem.OnceCondition;
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x00047EC8 File Offset: 0x000460C8
		protected void ResetStartTime()
		{
			this.startMs = Panel.TimeSinceStartupMs();
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x00047ED7 File Offset: 0x000460D7
		public void SetDuration(long durationMs)
		{
			this.endTimeMs = this.startMs + durationMs;
		}

		// Token: 0x06001445 RID: 5189
		public abstract void PerformTimerUpdate(TimerState state);

		// Token: 0x06001446 RID: 5190 RVA: 0x00003CD2 File Offset: 0x00001ED2
		internal virtual void OnItemUnscheduled()
		{
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x00047EEC File Offset: 0x000460EC
		public virtual bool ShouldUnschedule()
		{
			bool flag = this.timerUpdateStopCondition != null;
			return flag && this.timerUpdateStopCondition();
		}

		// Token: 0x04000967 RID: 2407
		public Func<bool> timerUpdateStopCondition;

		// Token: 0x04000968 RID: 2408
		public static readonly Func<bool> OnceCondition = () => true;

		// Token: 0x04000969 RID: 2409
		public static readonly Func<bool> ForeverCondition = () => false;
	}
}
