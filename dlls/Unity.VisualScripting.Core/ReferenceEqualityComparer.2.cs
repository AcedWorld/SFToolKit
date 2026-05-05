using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.VisualScripting
{
	// Token: 0x02000164 RID: 356
	public class ReferenceEqualityComparer<T> : IEqualityComparer<T>
	{
		// Token: 0x0600096B RID: 2411 RVA: 0x0002874B File Offset: 0x0002694B
		private ReferenceEqualityComparer()
		{
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00028753 File Offset: 0x00026953
		bool IEqualityComparer<!0>.Equals(T a, T b)
		{
			return a == b;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00028763 File Offset: 0x00026963
		int IEqualityComparer<!0>.GetHashCode(T a)
		{
			return ReferenceEqualityComparer<T>.GetHashCode(a);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0002876B File Offset: 0x0002696B
		public static int GetHashCode(T a)
		{
			return RuntimeHelpers.GetHashCode(a);
		}

		// Token: 0x0400023F RID: 575
		public static readonly ReferenceEqualityComparer<T> Instance = new ReferenceEqualityComparer<T>();
	}
}
