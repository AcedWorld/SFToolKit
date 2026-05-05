using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.VisualScripting
{
	// Token: 0x02000163 RID: 355
	public class ReferenceEqualityComparer : IEqualityComparer<object>
	{
		// Token: 0x06000966 RID: 2406 RVA: 0x00028721 File Offset: 0x00026921
		private ReferenceEqualityComparer()
		{
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00028729 File Offset: 0x00026929
		bool IEqualityComparer<object>.Equals(object a, object b)
		{
			return a == b;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0002872F File Offset: 0x0002692F
		int IEqualityComparer<object>.GetHashCode(object a)
		{
			return ReferenceEqualityComparer.GetHashCode(a);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00028737 File Offset: 0x00026937
		public static int GetHashCode(object a)
		{
			return RuntimeHelpers.GetHashCode(a);
		}

		// Token: 0x0400023E RID: 574
		public static readonly ReferenceEqualityComparer Instance = new ReferenceEqualityComparer();
	}
}
