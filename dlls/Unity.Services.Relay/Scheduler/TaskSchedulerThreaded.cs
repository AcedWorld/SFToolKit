using System;
using System.Collections.Generic;
using System.Threading;

namespace Unity.Services.Relay.Scheduler
{
	// Token: 0x02000018 RID: 24
	public sealed class TaskSchedulerThreaded : TaskScheduler
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000283E File Offset: 0x00000A3E
		private void Start()
		{
			this.m_mainThread = Thread.CurrentThread;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000284B File Offset: 0x00000A4B
		public override bool IsMainThread()
		{
			return this.m_mainThread == Thread.CurrentThread;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000285A File Offset: 0x00000A5A
		public override void ScheduleBackgroundTask(Action task)
		{
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				task();
			});
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000287C File Offset: 0x00000A7C
		public override void ScheduleMainThreadTask(Action task)
		{
			object @lock = this.m_lock;
			lock (@lock)
			{
				this.m_mainThreadTaskQueue.Enqueue(task);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000028C4 File Offset: 0x00000AC4
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

		// Token: 0x04000049 RID: 73
		private Queue<Action> m_mainThreadTaskQueue = new Queue<Action>();

		// Token: 0x0400004A RID: 74
		private object m_lock = new object();

		// Token: 0x0400004B RID: 75
		private Thread m_mainThread;
	}
}
