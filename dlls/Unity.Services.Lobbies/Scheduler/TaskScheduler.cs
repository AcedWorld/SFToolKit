using System;
using UnityEngine;

namespace Unity.Services.Lobbies.Scheduler
{
	// Token: 0x0200002D RID: 45
	public abstract class TaskScheduler : MonoBehaviour
	{
		// Token: 0x06000146 RID: 326
		public abstract void ScheduleBackgroundTask(Action task);

		// Token: 0x06000147 RID: 327
		public abstract bool IsMainThread();

		// Token: 0x06000148 RID: 328
		public abstract void ScheduleMainThreadTask(Action task);

		// Token: 0x06000149 RID: 329 RVA: 0x00006273 File Offset: 0x00004473
		public void ScheduleOrExecuteOnMain(Action action)
		{
			if (this.IsMainThread())
			{
				if (action != null)
				{
					action();
					return;
				}
			}
			else
			{
				this.ScheduleMainThreadTask(action);
			}
		}
	}
}
