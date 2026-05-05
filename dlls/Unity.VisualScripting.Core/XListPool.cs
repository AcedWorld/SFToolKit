using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C7 RID: 199
	public static class XListPool
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x0000AC90 File Offset: 0x00008E90
		public static List<T> ToListPooled<T>(this IEnumerable<T> source)
		{
			List<T> list = ListPool<T>.New();
			foreach (T item in source)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000ACE0 File Offset: 0x00008EE0
		public static void Free<T>(this List<T> list)
		{
			ListPool<T>.Free(list);
		}
	}
}
