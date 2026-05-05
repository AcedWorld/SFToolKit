using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020002BD RID: 701
	internal class TimerEventScheduler : IScheduler
	{
		// Token: 0x0600144D RID: 5197 RVA: 0x00047F54 File Offset: 0x00046154
		public void Schedule(ScheduledItem item)
		{
			bool flag = item == null;
			if (!flag)
			{
				bool flag2 = item == null;
				if (flag2)
				{
					throw new NotSupportedException("Scheduled Item type is not supported by this scheduler");
				}
				bool transactionMode = this.m_TransactionMode;
				if (transactionMode)
				{
					bool flag3 = this.m_UnscheduleTransactions.Remove(item);
					if (!flag3)
					{
						bool flag4 = this.m_ScheduledItems.Contains(item) || this.m_ScheduleTransactions.Contains(item);
						if (flag4)
						{
							throw new ArgumentException("Cannot schedule function " + item + " more than once");
						}
						this.m_ScheduleTransactions.Add(item);
					}
				}
				else
				{
					bool flag5 = this.m_ScheduledItems.Contains(item);
					if (flag5)
					{
						throw new ArgumentException("Cannot schedule function " + item + " more than once");
					}
					this.m_ScheduledItems.Add(item);
				}
			}
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x0004802C File Offset: 0x0004622C
		public ScheduledItem ScheduleOnce(Action<TimerState> timerUpdateEvent, long delayMs)
		{
			TimerEventScheduler.TimerEventSchedulerItem timerEventSchedulerItem = new TimerEventScheduler.TimerEventSchedulerItem(timerUpdateEvent)
			{
				delayMs = delayMs
			};
			this.Schedule(timerEventSchedulerItem);
			return timerEventSchedulerItem;
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x00048058 File Offset: 0x00046258
		public ScheduledItem ScheduleUntil(Action<TimerState> timerUpdateEvent, long delayMs, long intervalMs, Func<bool> stopCondition)
		{
			TimerEventScheduler.TimerEventSchedulerItem timerEventSchedulerItem = new TimerEventScheduler.TimerEventSchedulerItem(timerUpdateEvent)
			{
				delayMs = delayMs,
				intervalMs = intervalMs,
				timerUpdateStopCondition = stopCondition
			};
			this.Schedule(timerEventSchedulerItem);
			return timerEventSchedulerItem;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x00048094 File Offset: 0x00046294
		public ScheduledItem ScheduleForDuration(Action<TimerState> timerUpdateEvent, long delayMs, long intervalMs, long durationMs)
		{
			TimerEventScheduler.TimerEventSchedulerItem timerEventSchedulerItem = new TimerEventScheduler.TimerEventSchedulerItem(timerUpdateEvent)
			{
				delayMs = delayMs,
				intervalMs = intervalMs,
				timerUpdateStopCondition = null
			};
			timerEventSchedulerItem.SetDuration(durationMs);
			this.Schedule(timerEventSchedulerItem);
			return timerEventSchedulerItem;
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x000480D8 File Offset: 0x000462D8
		private bool RemovedScheduledItemAt(int index)
		{
			bool flag = index >= 0;
			bool result;
			if (flag)
			{
				bool flag2 = index <= this.m_LastUpdatedIndex;
				if (flag2)
				{
					this.m_LastUpdatedIndex--;
				}
				this.m_ScheduledItems.RemoveAt(index);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x00048128 File Offset: 0x00046328
		public void Unschedule(ScheduledItem item)
		{
			bool flag = item != null;
			if (flag)
			{
				bool transactionMode = this.m_TransactionMode;
				if (transactionMode)
				{
					bool flag2 = this.m_UnscheduleTransactions.Contains(item);
					if (flag2)
					{
						throw new ArgumentException("Cannot unschedule scheduled function twice" + ((item != null) ? item.ToString() : null));
					}
					bool flag3 = this.m_ScheduleTransactions.Remove(item);
					if (!flag3)
					{
						bool flag4 = this.m_ScheduledItems.Contains(item);
						if (!flag4)
						{
							throw new ArgumentException("Cannot unschedule unknown scheduled function " + ((item != null) ? item.ToString() : null));
						}
						this.m_UnscheduleTransactions.Add(item);
					}
				}
				else
				{
					bool flag5 = !this.PrivateUnSchedule(item);
					if (flag5)
					{
						throw new ArgumentException("Cannot unschedule unknown scheduled function " + ((item != null) ? item.ToString() : null));
					}
				}
				item.OnItemUnscheduled();
			}
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x00048214 File Offset: 0x00046414
		private bool PrivateUnSchedule(ScheduledItem sItem)
		{
			return this.m_ScheduleTransactions.Remove(sItem) || this.RemovedScheduledItemAt(this.m_ScheduledItems.IndexOf(sItem));
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x0004824C File Offset: 0x0004644C
		public void UpdateScheduledEvents()
		{
			try
			{
				this.m_TransactionMode = true;
				long num = Panel.TimeSinceStartupMs();
				int count = this.m_ScheduledItems.Count;
				int num2 = this.m_LastUpdatedIndex + 1;
				bool flag = num2 >= count;
				if (flag)
				{
					num2 = 0;
				}
				for (int i = 0; i < count; i++)
				{
					int num3 = num2 + i;
					bool flag2 = num3 >= count;
					if (flag2)
					{
						num3 -= count;
					}
					ScheduledItem scheduledItem = this.m_ScheduledItems[num3];
					bool flag3 = false;
					bool flag4 = num - scheduledItem.delayMs >= scheduledItem.startMs;
					if (flag4)
					{
						TimerState state = new TimerState
						{
							start = scheduledItem.startMs,
							now = num
						};
						bool flag5 = !this.m_UnscheduleTransactions.Contains(scheduledItem);
						if (flag5)
						{
							scheduledItem.PerformTimerUpdate(state);
						}
						scheduledItem.startMs = num;
						scheduledItem.delayMs = scheduledItem.intervalMs;
						bool flag6 = scheduledItem.ShouldUnschedule();
						if (flag6)
						{
							flag3 = true;
						}
					}
					bool flag7 = flag3 || (scheduledItem.endTimeMs > 0L && num > scheduledItem.endTimeMs);
					if (flag7)
					{
						bool flag8 = !this.m_UnscheduleTransactions.Contains(scheduledItem);
						if (flag8)
						{
							this.Unschedule(scheduledItem);
						}
					}
					this.m_LastUpdatedIndex = num3;
				}
			}
			finally
			{
				this.m_TransactionMode = false;
				foreach (ScheduledItem sItem in this.m_UnscheduleTransactions)
				{
					this.PrivateUnSchedule(sItem);
				}
				this.m_UnscheduleTransactions.Clear();
				foreach (ScheduledItem item in this.m_ScheduleTransactions)
				{
					this.Schedule(item);
				}
				this.m_ScheduleTransactions.Clear();
			}
		}

		// Token: 0x0400096F RID: 2415
		private readonly List<ScheduledItem> m_ScheduledItems = new List<ScheduledItem>();

		// Token: 0x04000970 RID: 2416
		private bool m_TransactionMode;

		// Token: 0x04000971 RID: 2417
		private readonly List<ScheduledItem> m_ScheduleTransactions = new List<ScheduledItem>();

		// Token: 0x04000972 RID: 2418
		private readonly HashSet<ScheduledItem> m_UnscheduleTransactions = new HashSet<ScheduledItem>();

		// Token: 0x04000973 RID: 2419
		internal bool disableThrottling = false;

		// Token: 0x04000974 RID: 2420
		private int m_LastUpdatedIndex = -1;

		// Token: 0x020002BE RID: 702
		private class TimerEventSchedulerItem : ScheduledItem
		{
			// Token: 0x06001456 RID: 5206 RVA: 0x000484DC File Offset: 0x000466DC
			public TimerEventSchedulerItem(Action<TimerState> updateEvent)
			{
				this.m_TimerUpdateEvent = updateEvent;
			}

			// Token: 0x06001457 RID: 5207 RVA: 0x000484ED File Offset: 0x000466ED
			public override void PerformTimerUpdate(TimerState state)
			{
				Action<TimerState> timerUpdateEvent = this.m_TimerUpdateEvent;
				if (timerUpdateEvent != null)
				{
					timerUpdateEvent(state);
				}
			}

			// Token: 0x06001458 RID: 5208 RVA: 0x00048504 File Offset: 0x00046704
			public override string ToString()
			{
				return this.m_TimerUpdateEvent.ToString();
			}

			// Token: 0x04000975 RID: 2421
			private readonly Action<TimerState> m_TimerUpdateEvent;
		}
	}
}
