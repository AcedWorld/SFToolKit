using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000035 RID: 53
	[BurstCompatible]
	public static class FixedList32BytesExtensions
	{
		// Token: 0x06000154 RID: 340 RVA: 0x00004FA3 File Offset: 0x000031A3
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<[IsUnmanaged] T, U>(this FixedList32Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>((void*)list.Buffer, list.Length, value);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00004FB7 File Offset: 0x000031B7
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this FixedList32Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return ref list.IndexOf(value) != -1;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004FC8 File Offset: 0x000031C8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Remove<[IsUnmanaged] T, U>(this FixedList32Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			int num = ref list.IndexOf(value);
			if (num < 0)
			{
				return false;
			}
			list.RemoveAt(num);
			return true;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004FEC File Offset: 0x000031EC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool RemoveSwapBack<[IsUnmanaged] T, U>(this FixedList32Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
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
