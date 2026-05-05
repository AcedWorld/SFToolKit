using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Qos.Scheduler
{
	// Token: 0x0200004B RID: 75
	internal static class ThreadHelper
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000163 RID: 355 RVA: 0x0000614F File Offset: 0x0000434F
		public static SynchronizationContext SynchronizationContext
		{
			get
			{
				return ThreadHelper._unitySynchronizationContext;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00006156 File Offset: 0x00004356
		public static TaskScheduler TaskScheduler
		{
			get
			{
				return ThreadHelper._taskScheduler;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000165 RID: 357 RVA: 0x0000615D File Offset: 0x0000435D
		public static int MainThreadId
		{
			get
			{
				return ThreadHelper._mainThreadId;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006164 File Offset: 0x00004364
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			ThreadHelper._unitySynchronizationContext = SynchronizationContext.Current;
			ThreadHelper._taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			ThreadHelper._mainThreadId = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x040000AD RID: 173
		private static SynchronizationContext _unitySynchronizationContext;

		// Token: 0x040000AE RID: 174
		private static TaskScheduler _taskScheduler;

		// Token: 0x040000AF RID: 175
		private static int _mainThreadId;
	}
}
