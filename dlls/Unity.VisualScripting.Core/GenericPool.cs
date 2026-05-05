using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C2 RID: 194
	public static class GenericPool<T> where T : class, IPoolable
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x0000A92C File Offset: 0x00008B2C
		public static T New(Func<T> constructor)
		{
			object obj = GenericPool<T>.@lock;
			T result;
			lock (obj)
			{
				if (GenericPool<T>.free.Count == 0)
				{
					GenericPool<T>.free.Push(constructor());
				}
				T t = GenericPool<T>.free.Pop();
				t.New();
				GenericPool<T>.busy.Add(t);
				result = t;
			}
			return result;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000A9A8 File Offset: 0x00008BA8
		public static void Free(T item)
		{
			object obj = GenericPool<T>.@lock;
			lock (obj)
			{
				if (!GenericPool<T>.busy.Remove(item))
				{
					throw new ArgumentException("The item to free is not in use by the pool.", "item");
				}
				item.Free();
				GenericPool<T>.free.Push(item);
			}
		}

		// Token: 0x0400010A RID: 266
		private static readonly object @lock = new object();

		// Token: 0x0400010B RID: 267
		private static readonly Stack<T> free = new Stack<T>();

		// Token: 0x0400010C RID: 268
		private static readonly HashSet<T> busy = new HashSet<T>(ReferenceEqualityComparer<T>.Instance);
	}
}
