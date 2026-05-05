using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Qos.V2.Scheduler
{
	// Token: 0x02000023 RID: 35
	internal static class ThreadHelper
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000088 RID: 136 RVA: 0x000040D5 File Offset: 0x000022D5
		public static SynchronizationContext SynchronizationContext
		{
			get
			{
				return ThreadHelper._unitySynchronizationContext;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000040DC File Offset: 0x000022DC
		public static TaskScheduler TaskScheduler
		{
			get
			{
				return ThreadHelper._taskScheduler;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000040E3 File Offset: 0x000022E3
		public static int MainThreadId
		{
			get
			{
				return ThreadHelper._mainThreadId;
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000040EA File Offset: 0x000022EA
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			ThreadHelper._unitySynchronizationContext = SynchronizationContext.Current;
			ThreadHelper._taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			ThreadHelper._mainThreadId = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x04000070 RID: 112
		private static SynchronizationContext _unitySynchronizationContext;

		// Token: 0x04000071 RID: 113
		private static TaskScheduler _taskScheduler;

		// Token: 0x04000072 RID: 114
		private static int _mainThreadId;
	}
}
