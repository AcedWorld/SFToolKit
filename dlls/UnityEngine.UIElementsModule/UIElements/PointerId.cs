using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000215 RID: 533
	public static class PointerId
	{
		// Token: 0x040006F6 RID: 1782
		public static readonly int maxPointers = 32;

		// Token: 0x040006F7 RID: 1783
		public static readonly int invalidPointerId = -1;

		// Token: 0x040006F8 RID: 1784
		public static readonly int mousePointerId = 0;

		// Token: 0x040006F9 RID: 1785
		public static readonly int touchPointerIdBase = 1;

		// Token: 0x040006FA RID: 1786
		public static readonly int touchPointerCount = 20;

		// Token: 0x040006FB RID: 1787
		public static readonly int penPointerIdBase = PointerId.touchPointerIdBase + PointerId.touchPointerCount;

		// Token: 0x040006FC RID: 1788
		public static readonly int penPointerCount = 2;

		// Token: 0x040006FD RID: 1789
		internal static readonly int[] hoveringPointers = new int[]
		{
			PointerId.mousePointerId
		};
	}
}
