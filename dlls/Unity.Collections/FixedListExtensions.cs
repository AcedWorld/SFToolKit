using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000069 RID: 105
	public static class FixedListExtensions
	{
		// Token: 0x060002A4 RID: 676 RVA: 0x000080C0 File Offset: 0x000062C0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void Sort<[IsUnmanaged] T>(this FixedList32Bytes<T> list) where T : struct, ValueType, IComparable<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length);
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x000080F4 File Offset: 0x000062F4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(this FixedList32Bytes<T> list, U comp) where T : struct, ValueType, IComparable<T> where U : IComparer<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T, U>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length, comp);
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000812C File Offset: 0x0000632C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void Sort<[IsUnmanaged] T>(this FixedList64Bytes<T> list) where T : struct, ValueType, IComparable<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length);
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00008160 File Offset: 0x00006360
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(this FixedList64Bytes<T> list, U comp) where T : struct, ValueType, IComparable<T> where U : IComparer<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T, U>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length, comp);
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00008198 File Offset: 0x00006398
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void Sort<[IsUnmanaged] T>(this FixedList128Bytes<T> list) where T : struct, ValueType, IComparable<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000081CC File Offset: 0x000063CC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(this FixedList128Bytes<T> list, U comp) where T : struct, ValueType, IComparable<T> where U : IComparer<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T, U>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length, comp);
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00008204 File Offset: 0x00006404
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void Sort<[IsUnmanaged] T>(this FixedList512Bytes<T> list) where T : struct, ValueType, IComparable<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length);
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00008238 File Offset: 0x00006438
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(this FixedList512Bytes<T> list, U comp) where T : struct, ValueType, IComparable<T> where U : IComparer<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T, U>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length, comp);
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00008270 File Offset: 0x00006470
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void Sort<[IsUnmanaged] T>(this FixedList4096Bytes<T> list) where T : struct, ValueType, IComparable<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length);
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000082A4 File Offset: 0x000064A4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(this FixedList4096Bytes<T> list, U comp) where T : struct, ValueType, IComparable<T> where U : IComparer<T>
		{
			fixed (byte* ptr = &list.buffer.offset0000.byte0000)
			{
				NativeSortExtension.Sort<T, U>((T*)ptr + FixedList.PaddingBytes<T>() / sizeof(T), list.Length, comp);
			}
		}
	}
}
