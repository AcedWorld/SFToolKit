using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Core
{
	// Token: 0x02000010 RID: 16
	internal static class UnityThreadUtils
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000024D3 File Offset: 0x000006D3
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000024DA File Offset: 0x000006DA
		internal static TaskScheduler UnityThreadScheduler { get; private set; }

		// Token: 0x06000043 RID: 67 RVA: 0x000024E2 File Offset: 0x000006E2
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void CaptureUnityThreadInfo()
		{
			UnityThreadUtils.s_UnityThreadId = Thread.CurrentThread.ManagedThreadId;
			UnityThreadUtils.UnityThreadScheduler = TaskScheduler.FromCurrentSynchronizationContext();
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000024FD File Offset: 0x000006FD
		public static bool IsRunningOnUnityThread
		{
			get
			{
				return Thread.CurrentThread.ManagedThreadId == UnityThreadUtils.s_UnityThreadId;
			}
		}

		// Token: 0x0400001E RID: 30
		private static int s_UnityThreadId;
	}
}
