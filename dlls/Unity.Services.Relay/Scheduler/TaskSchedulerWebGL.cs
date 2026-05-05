using System;
using System.Collections.Generic;

namespace Unity.Services.Relay.Scheduler
{
	// Token: 0x02000019 RID: 25
	public sealed class TaskSchedulerWebGL : TaskScheduler
	{
		// Token: 0x0600004C RID: 76 RVA: 0x00002972 File Offset: 0x00000B72
		public override void ScheduleBackgroundTask(Action task)
		{
			this.ScheduleMainThreadTask(task);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000297B File Offset: 0x00000B7B
		public override bool IsMainThread()
		{
			return false;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000297E File Offset: 0x00000B7E
		public override void ScheduleMainThreadTask(Action task)
		{
			this.m_mainThreadTaskQueue.Enqueue(task);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000298C File Offset: 0x00000B8C
		private void Update()
		{
			Action action = (this.m_mainThreadTaskQueue.Count > 0) ? this.m_mainThreadTaskQueue.Dequeue() : null;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0400004C RID: 76
		private Queue<Action> m_mainThreadTaskQueue = new Queue<Action>();
	}
}
