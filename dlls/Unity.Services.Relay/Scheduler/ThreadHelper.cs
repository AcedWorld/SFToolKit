using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Relay.Scheduler
{
	// Token: 0x0200001A RID: 26
	internal static class ThreadHelper
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000029C7 File Offset: 0x00000BC7
		public static SynchronizationContext SynchronizationContext
		{
			get
			{
				return ThreadHelper._unitySynchronizationContext;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000029CE File Offset: 0x00000BCE
		public static TaskScheduler TaskScheduler
		{
			get
			{
				return ThreadHelper._taskScheduler;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000029D5 File Offset: 0x00000BD5
		public static int MainThreadId
		{
			get
			{
				return ThreadHelper._mainThreadId;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000029DC File Offset: 0x00000BDC
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			ThreadHelper._unitySynchronizationContext = SynchronizationContext.Current;
			ThreadHelper._taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			ThreadHelper._mainThreadId = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x0400004D RID: 77
		private static SynchronizationContext _unitySynchronizationContext;

		// Token: 0x0400004E RID: 78
		private static TaskScheduler _taskScheduler;

		// Token: 0x0400004F RID: 79
		private static int _mainThreadId;
	}
}
