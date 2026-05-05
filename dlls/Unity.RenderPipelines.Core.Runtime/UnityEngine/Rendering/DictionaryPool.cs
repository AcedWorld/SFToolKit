using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000051 RID: 81
	public static class DictionaryPool<TKey, TValue>
	{
		// Token: 0x060002A7 RID: 679 RVA: 0x0000C2AA File Offset: 0x0000A4AA
		public static Dictionary<TKey, TValue> Get()
		{
			return DictionaryPool<TKey, TValue>.s_Pool.Get();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000C2B6 File Offset: 0x0000A4B6
		public static ObjectPool<Dictionary<TKey, TValue>>.PooledObject Get(out Dictionary<TKey, TValue> value)
		{
			return DictionaryPool<TKey, TValue>.s_Pool.Get(out value);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000C2C3 File Offset: 0x0000A4C3
		public static void Release(Dictionary<TKey, TValue> toRelease)
		{
			DictionaryPool<TKey, TValue>.s_Pool.Release(toRelease);
		}

		// Token: 0x0400019D RID: 413
		private static readonly ObjectPool<Dictionary<TKey, TValue>> s_Pool = new ObjectPool<Dictionary<TKey, TValue>>(null, delegate(Dictionary<TKey, TValue> l)
		{
			l.Clear();
		}, true);
	}
}
