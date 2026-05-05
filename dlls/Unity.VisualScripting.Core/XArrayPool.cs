using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000C0 RID: 192
	public static class XArrayPool
	{
		// Token: 0x060004BD RID: 1213 RVA: 0x0000A774 File Offset: 0x00008974
		public static T[] ToArrayPooled<T>(this IEnumerable<T> source)
		{
			T[] array = ArrayPool<T>.New(source.Count<T>());
			int num = 0;
			foreach (T t in source)
			{
				array[num++] = t;
			}
			return array;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000A7D0 File Offset: 0x000089D0
		public static void Free<T>(this T[] array)
		{
			ArrayPool<T>.Free(array);
		}
	}
}
