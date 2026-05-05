using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000127 RID: 295
	internal static class UnsafeTextExtensions
	{
		// Token: 0x06000AF7 RID: 2807 RVA: 0x00022A57 File Offset: 0x00020C57
		public static ref UnsafeList<byte> AsUnsafeListOfBytes(this UnsafeText text)
		{
			return UnsafeUtility.As<UntypedUnsafeList, UnsafeList<byte>>(ref text.m_UntypedListData);
		}
	}
}
