using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000050 RID: 80
	public static class HashSetPool<T>
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x0000C266 File Offset: 0x0000A466
		public static HashSet<T> Get()
		{
			return HashSetPool<T>.s_Pool.Get();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000C272 File Offset: 0x0000A472
		public static ObjectPool<HashSet<T>>.PooledObject Get(out HashSet<T> value)
		{
			return HashSetPool<T>.s_Pool.Get(out value);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000C27F File Offset: 0x0000A47F
		public static void Release(HashSet<T> toRelease)
		{
			HashSetPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x0400019C RID: 412
		private static readonly ObjectPool<HashSet<T>> s_Pool = new ObjectPool<HashSet<T>>(null, delegate(HashSet<T> l)
		{
			l.Clear();
		}, true);
	}
}
