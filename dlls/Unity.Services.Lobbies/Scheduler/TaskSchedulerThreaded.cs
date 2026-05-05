using System;
using System.Collections.Generic;
using System.Threading;

namespace Unity.Services.Lobbies.Scheduler
{
	// Token: 0x0200002E RID: 46
	public sealed class TaskSchedulerThreaded : TaskScheduler
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00006296 File Offset: 0x00004496
		private void Start()
		{
			this.m_mainThread = Thread.CurrentThread;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000062A3 File Offset: 0x000044A3
		public override bool IsMainThread()
		{
			return this.m_mainThread == Thread.CurrentThread;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000062B2 File Offset: 0x000044B2
		public override void ScheduleBackgroundTask(Action task)
		{
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				task();
			});
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000062D4 File Offset: 0x000044D4
		public override void ScheduleMainThreadTask(Action task)
		{
			object @lock = this.m_lock;
			lock (@lock)
			{
				this.m_mainThreadTaskQueue.Enqueue(task);
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000631C File Offset: 0x0000451C
		private void Update()
		{
			Queue<Action> queue = null;
			object @lock = this.m_lock;
			lock (@lock)
			{
				queue = new Queue<Action>(this.m_mainThreadTaskQueue);
				this.m_mainThreadTaskQueue.Clear();
			}
			foreach (Action action in queue)
			{
				action();
			}
		}

		// Token: 0x040000AE RID: 174
		private Queue<Action> m_mainThreadTaskQueue = new Queue<Action>();

		// Token: 0x040000AF RID: 175
		private object m_lock = new object();

		// Token: 0x040000B0 RID: 176
		private Thread m_mainThread;
	}
}
