using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000153 RID: 339
	public static class Empty<T>
	{
		// Token: 0x0400022B RID: 555
		public static readonly T[] array = new T[0];

		// Token: 0x0400022C RID: 556
		public static readonly List<T> list = new List<T>(0);

		// Token: 0x0400022D RID: 557
		public static readonly HashSet<T> hashSet = new HashSet<T>();
	}
}
