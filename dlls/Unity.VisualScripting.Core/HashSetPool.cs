using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C3 RID: 195
	public static class HashSetPool<T>
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x0000AA3C File Offset: 0x00008C3C
		public static HashSet<T> New()
		{
			object obj = HashSetPool<T>.@lock;
			HashSet<T> result;
			lock (obj)
			{
				if (HashSetPool<T>.free.Count == 0)
				{
					HashSetPool<T>.free.Push(new HashSet<T>());
				}
				HashSet<T> hashSet = HashSetPool<T>.free.Pop();
				HashSetPool<T>.busy.Add(hashSet);
				result = hashSet;
			}
			return result;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000AAAC File Offset: 0x00008CAC
		public static void Free(HashSet<T> hashSet)
		{
			object obj = HashSetPool<T>.@lock;
			lock (obj)
			{
				if (!HashSetPool<T>.busy.Remove(hashSet))
				{
					throw new ArgumentException("The hash set to free is not in use by the pool.", "hashSet");
				}
				hashSet.Clear();
				HashSetPool<T>.free.Push(hashSet);
			}
		}

		// Token: 0x0400010D RID: 269
		private static readonly object @lock = new object();

		// Token: 0x0400010E RID: 270
		private static readonly Stack<HashSet<T>> free = new Stack<HashSet<T>>();

		// Token: 0x0400010F RID: 271
		private static readonly HashSet<HashSet<T>> busy = new HashSet<HashSet<T>>();
	}
}
