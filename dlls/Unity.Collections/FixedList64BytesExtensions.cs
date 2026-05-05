using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x0200003A RID: 58
	[BurstCompatible]
	public static class FixedList64BytesExtensions
	{
		// Token: 0x0600019F RID: 415 RVA: 0x00005B60 File Offset: 0x00003D60
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<[IsUnmanaged] T, U>(this FixedList64Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>((void*)list.Buffer, list.Length, value);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00005B74 File Offset: 0x00003D74
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this FixedList64Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return ref list.IndexOf(value) != -1;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005B84 File Offset: 0x00003D84
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Remove<[IsUnmanaged] T, U>(this FixedList64Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			int num = ref list.IndexOf(value);
			if (num < 0)
			{
				return false;
			}
			list.RemoveAt(num);
			return true;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00005BA8 File Offset: 0x00003DA8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool RemoveSwapBack<[IsUnmanaged] T, U>(this FixedList64Bytes<T> list, U value) where T : struct, ValueType, IEquatable<U>
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
