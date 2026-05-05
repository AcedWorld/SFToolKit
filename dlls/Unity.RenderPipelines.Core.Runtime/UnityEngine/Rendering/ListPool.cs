using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x0200004F RID: 79
	public static class ListPool<T>
	{
		// Token: 0x0600029F RID: 671 RVA: 0x0000C222 File Offset: 0x0000A422
		public static List<T> Get()
		{
			return ListPool<T>.s_Pool.Get();
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000C22E File Offset: 0x0000A42E
		public static ObjectPool<List<T>>.PooledObject Get(out List<T> value)
		{
			return ListPool<T>.s_Pool.Get(out value);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000C23B File Offset: 0x0000A43B
		public static void Release(List<T> toRelease)
		{
			ListPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x0400019B RID: 411
		private static readonly ObjectPool<List<T>> s_Pool = new ObjectPool<List<T>>(null, delegate(List<T> l)
		{
			l.Clear();
		}, true);
	}
}
