using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000112 RID: 274
	[BurstCompatible]
	internal static class UnsafePtrListTExtensions
	{
		// Token: 0x06000A8B RID: 2699 RVA: 0x00021828 File Offset: 0x0001FA28
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static ref UnsafeList<IntPtr> ListData<[IsUnmanaged] T>(this UnsafePtrList<T> from) where T : struct, ValueType
		{
			return UnsafeUtility.As<UnsafePtrList<T>, UnsafeList<IntPtr>>(ref from);
		}
	}
}
