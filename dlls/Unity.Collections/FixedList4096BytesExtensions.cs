using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000049 RID: 73
	[BurstCompatible]
	public static class FixedList4096BytesExtensions
	{
		// Token: 0x06000280 RID: 640 RVA: 0x00007E94 File Offset: 0x00006094
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<[IsUnmanaged] T, U>(this FixedList4096Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>((void*)list.Buffer, list.Length, value);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00007EA8 File Offset: 0x000060A8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this FixedList4096Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return ref list.IndexOf(value) != -1;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00007EB8 File Offset: 0x000060B8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Remove<[IsUnmanaged] T, U>(this FixedList4096Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			int num = ref list.IndexOf(value);
			if (num < 0)
			{
				return false;
			}
			list.RemoveAt(num);
			return true;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00007EDC File Offset: 0x000060DC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool RemoveSwapBack<[IsUnmanaged] T, U>(this FixedList4096Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
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
