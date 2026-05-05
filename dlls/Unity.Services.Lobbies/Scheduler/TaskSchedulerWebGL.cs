using System;
using System.Collections.Generic;

namespace Unity.Services.Lobbies.Scheduler
{
	// Token: 0x0200002F RID: 47
	public sealed class TaskSchedulerWebGL : TaskScheduler
	{
		// Token: 0x06000151 RID: 337 RVA: 0x000063CA File Offset: 0x000045CA
		public override void ScheduleBackgroundTask(Action task)
		{
			this.ScheduleMainThreadTask(task);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000063D3 File Offset: 0x000045D3
		public override bool IsMainThread()
		{
			return false;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000063D6 File Offset: 0x000045D6
		public override void ScheduleMainThreadTask(Action task)
		{
			this.m_mainThreadTaskQueue.Enqueue(task);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000063E4 File Offset: 0x000045E4
		private void Update()
		{
			Action action = (this.m_mainThreadTaskQueue.Count > 0) ? this.m_mainThreadTaskQueue.Dequeue() : null;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x040000B1 RID: 177
		private Queue<Action> m_mainThreadTaskQueue = new Queue<Action>();
	}
}
