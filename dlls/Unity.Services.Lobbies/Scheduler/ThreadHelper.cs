using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Lobbies.Scheduler
{
	// Token: 0x02000030 RID: 48
	internal static class ThreadHelper
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000156 RID: 342 RVA: 0x0000641F File Offset: 0x0000461F
		public static SynchronizationContext SynchronizationContext
		{
			get
			{
				return ThreadHelper._unitySynchronizationContext;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00006426 File Offset: 0x00004626
		public static TaskScheduler TaskScheduler
		{
			get
			{
				return ThreadHelper._taskScheduler;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000158 RID: 344 RVA: 0x0000642D File Offset: 0x0000462D
		public static int MainThreadId
		{
			get
			{
				return ThreadHelper._mainThreadId;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00006434 File Offset: 0x00004634
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			ThreadHelper._unitySynchronizationContext = SynchronizationContext.Current;
			ThreadHelper._taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			ThreadHelper._mainThreadId = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x040000B2 RID: 178
		private static SynchronizationContext _unitySynchronizationContext;

		// Token: 0x040000B3 RID: 179
		private static TaskScheduler _taskScheduler;

		// Token: 0x040000B4 RID: 180
		private static int _mainThreadId;
	}
}
