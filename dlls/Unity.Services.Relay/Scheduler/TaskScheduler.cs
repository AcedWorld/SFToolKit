using System;
using UnityEngine;

namespace Unity.Services.Relay.Scheduler
{
	// Token: 0x02000017 RID: 23
	public abstract class TaskScheduler : MonoBehaviour
	{
		// Token: 0x06000041 RID: 65
		public abstract void ScheduleBackgroundTask(Action task);

		// Token: 0x06000042 RID: 66
		public abstract bool IsMainThread();

		// Token: 0x06000043 RID: 67
		public abstract void ScheduleMainThreadTask(Action task);

		// Token: 0x06000044 RID: 68 RVA: 0x0000281B File Offset: 0x00000A1B
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
