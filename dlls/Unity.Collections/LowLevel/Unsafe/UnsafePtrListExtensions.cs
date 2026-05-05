using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000E1 RID: 225
	internal static class UnsafePtrListExtensions
	{
		// Token: 0x0600091D RID: 2333 RVA: 0x0001CB44 File Offset: 0x0001AD44
		public static ref UnsafeList ListData(this UnsafePtrList from)
		{
			return UnsafeUtility.As<UnsafePtrList, UnsafeList>(ref from);
		}
	}
}
