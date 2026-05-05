using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003F2 RID: 1010
	internal static class VisualElementListPool
	{
		// Token: 0x060020BB RID: 8379 RVA: 0x0007BE78 File Offset: 0x0007A078
		public static List<VisualElement> Copy(List<VisualElement> elements)
		{
			List<VisualElement> list = VisualElementListPool.pool.Get();
			list.AddRange(elements);
			return list;
		}

		// Token: 0x060020BC RID: 8380 RVA: 0x0007BEA0 File Offset: 0x0007A0A0
		public static List<VisualElement> Get(int initialCapacity = 0)
		{
			List<VisualElement> list = VisualElementListPool.pool.Get();
			bool flag = initialCapacity > 0 && list.Capacity < initialCapacity;
			if (flag)
			{
				list.Capacity = initialCapacity;
			}
			return list;
		}

		// Token: 0x060020BD RID: 8381 RVA: 0x0007BEDC File Offset: 0x0007A0DC
		public static void Release(List<VisualElement> elements)
		{
			elements.Clear();
			VisualElementListPool.pool.Release(elements);
		}

		// Token: 0x04000DBF RID: 3519
		private static ObjectPool<List<VisualElement>> pool = new ObjectPool<List<VisualElement>>(() => new List<VisualElement>(), 20);
	}
}
