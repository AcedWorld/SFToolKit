using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace Unity.VisualScripting
{
	// Token: 0x0200014F RID: 335
	public static class UnityThread
	{
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x00027017 File Offset: 0x00025217
		public static bool allowsAPI
		{
			get
			{
				return !Serialization.isUnitySerializing && Thread.CurrentThread == UnityThread.thread;
			}
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0002702E File Offset: 0x0002522E
		internal static void RuntimeInitialize()
		{
			UnityThread.thread = Thread.CurrentThread;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0002703A File Offset: 0x0002523A
		[Conditional("UNITY_EDITOR")]
		public static void EditorAsync(Action action)
		{
			if (UnityThread.editorAsync == null)
			{
				UnityThread.pendingQueue.Enqueue(action);
				return;
			}
			UnityThread.editorAsync(action);
		}

		// Token: 0x04000225 RID: 549
		public static Thread thread = Thread.CurrentThread;

		// Token: 0x04000226 RID: 550
		public static Action<Action> editorAsync;

		// Token: 0x04000227 RID: 551
		public static ConcurrentQueue<Action> pendingQueue = new ConcurrentQueue<Action>();
	}
}
