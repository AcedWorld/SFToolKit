using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000044 RID: 68
	[BurstCompatible]
	public static class FixedList512BytesExtensions
	{
		// Token: 0x06000235 RID: 565 RVA: 0x000072D8 File Offset: 0x000054D8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<[IsUnmanaged] T, U>(this FixedList512Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>((void*)list.Buffer, list.Length, value);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000072EC File Offset: 0x000054EC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this FixedList512Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return ref list.IndexOf(value) != -1;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000072FC File Offset: 0x000054FC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Remove<[IsUnmanaged] T, U>(this FixedList512Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			int num = ref list.IndexOf(value);
			if (num < 0)
			{
				return false;
			}
			list.RemoveAt(num);
			return true;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00007320 File Offset: 0x00005520
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool RemoveSwapBack<[IsUnmanaged] T, U>(this FixedList512Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			int num = ref list.IndexOf(value);
			if (num == -1)
			{
				return false;
			}
			list.RemoveAtSwapBack(num);
			return true;
		}
	}
}
