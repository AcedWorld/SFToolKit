using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200010D RID: 269
	[BurstCompatible]
	public static class UnsafeListExtensions
	{
		// Token: 0x06000A55 RID: 2645 RVA: 0x0002134C File Offset: 0x0001F54C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<[IsUnmanaged] T, U>(this UnsafeList<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>((void*)list.Ptr, list.Length, value);
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00021361 File Offset: 0x0001F561
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this UnsafeList<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return list.IndexOf(value) != -1;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00021370 File Offset: 0x0001F570
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<[IsUnmanaged] T, U>(this UnsafeList<T>.ParallelReader list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>((void*)list.Ptr, list.Length, value);
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00021384 File Offset: 0x0001F584
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this UnsafeList<T>.ParallelReader list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return list.IndexOf(value) != -1;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00021394 File Offset: 0x0001F594
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static bool ArraysEqual<[IsUnmanaged] T>(this UnsafeList<T> array, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			if (array.Length != other.Length)
			{
				return false;
			}
			for (int num = 0; num != array.Length; num++)
			{
				T t = array[num];
				if (!t.Equals(other[num]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
