using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003F4 RID: 1012
	internal class ObjectListPool<T>
	{
		// Token: 0x060020C2 RID: 8386 RVA: 0x0007BF24 File Offset: 0x0007A124
		public static List<T> Get()
		{
			return ObjectListPool<T>.pool.Get();
		}

		// Token: 0x060020C3 RID: 8387 RVA: 0x0007BF40 File Offset: 0x0007A140
		public static void Release(List<T> elements)
		{
			elements.Clear();
			ObjectListPool<T>.pool.Release(elements);
		}

		// Token: 0x04000DC1 RID: 3521
		private static ObjectPool<List<T>> pool = new ObjectPool<List<T>>(() => new List<T>(), 20);
	}
}
