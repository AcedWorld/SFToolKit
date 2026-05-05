using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200004F RID: 79
	internal static class XComparable
	{
		// Token: 0x0600025A RID: 602 RVA: 0x00005FDB File Offset: 0x000041DB
		internal static bool IsLt<T>(this IComparable<T> x, T y)
		{
			return x.CompareTo(y) < 0;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00005FE7 File Offset: 0x000041E7
		internal static bool IsEq<T>(this IComparable<T> x, T y)
		{
			return x.CompareTo(y) == 0;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00005FF3 File Offset: 0x000041F3
		internal static bool IsGt<T>(this IComparable<T> x, T y)
		{
			return x.CompareTo(y) > 0;
		}
	}
}
