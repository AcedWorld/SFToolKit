using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C6 RID: 198
	public static class ListPool<T>
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x0000AB8C File Offset: 0x00008D8C
		public static List<T> New()
		{
			object obj = ListPool<T>.@lock;
			List<T> result;
			lock (obj)
			{
				if (ListPool<T>.free.Count == 0)
				{
					ListPool<T>.free.Push(new List<T>());
				}
				List<T> list = ListPool<T>.free.Pop();
				ListPool<T>.busy.Add(list);
				result = list;
			}
			return result;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000ABFC File Offset: 0x00008DFC
		public static void Free(List<T> list)
		{
			object obj = ListPool<T>.@lock;
			lock (obj)
			{
				if (!ListPool<T>.busy.Contains(list))
				{
					throw new ArgumentException("The list to free is not in use by the pool.", "list");
				}
				list.Clear();
				ListPool<T>.busy.Remove(list);
				ListPool<T>.free.Push(list);
			}
		}

		// Token: 0x04000110 RID: 272
		private static readonly object @lock = new object();

		// Token: 0x04000111 RID: 273
		private static readonly Stack<List<T>> free = new Stack<List<T>>();

		// Token: 0x04000112 RID: 274
		private static readonly HashSet<List<T>> busy = new HashSet<List<T>>();
	}
}
