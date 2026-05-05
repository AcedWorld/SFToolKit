using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C8 RID: 200
	public static class ManualPool<T> where T : class
	{
		// Token: 0x060004D1 RID: 1233 RVA: 0x0000ACE8 File Offset: 0x00008EE8
		public static T New(Func<T> constructor)
		{
			object obj = ManualPool<T>.@lock;
			T result;
			lock (obj)
			{
				if (ManualPool<T>.free.Count == 0)
				{
					ManualPool<T>.free.Push(constructor());
				}
				T t = ManualPool<T>.free.Pop();
				ManualPool<T>.busy.Add(t);
				result = t;
			}
			return result;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000AD58 File Offset: 0x00008F58
		public static void Free(T item)
		{
			object obj = ManualPool<T>.@lock;
			lock (obj)
			{
				if (!ManualPool<T>.busy.Contains(item))
				{
					throw new ArgumentException("The item to free is not in use by the pool.", "item");
				}
				ManualPool<T>.busy.Remove(item);
				ManualPool<T>.free.Push(item);
			}
		}

		// Token: 0x04000113 RID: 275
		private static readonly object @lock = new object();

		// Token: 0x04000114 RID: 276
		private static readonly Stack<T> free = new Stack<T>();

		// Token: 0x04000115 RID: 277
		private static readonly HashSet<T> busy = new HashSet<T>();
	}
}
