using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C4 RID: 196
	public static class XHashSetPool
	{
		// Token: 0x060004C8 RID: 1224 RVA: 0x0000AB34 File Offset: 0x00008D34
		public static HashSet<T> ToHashSetPooled<T>(this IEnumerable<T> source)
		{
			HashSet<T> hashSet = HashSetPool<T>.New();
			foreach (T item in source)
			{
				hashSet.Add(item);
			}
			return hashSet;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000AB84 File Offset: 0x00008D84
		public static void Free<T>(this HashSet<T> hashSet)
		{
			HashSetPool<T>.Free(hashSet);
		}
	}
}
