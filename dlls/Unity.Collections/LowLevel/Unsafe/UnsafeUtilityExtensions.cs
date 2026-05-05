using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000129 RID: 297
	[BurstCompatible]
	public static class UnsafeUtilityExtensions
	{
		// Token: 0x06000B0B RID: 2827 RVA: 0x00022C44 File Offset: 0x00020E44
		internal unsafe static void MemSwap(void* ptr, void* otherPtr, long size)
		{
			byte* ptr2 = (byte*)ptr;
			byte* ptr3 = (byte*)otherPtr;
			byte* ptr4 = stackalloc byte[(UIntPtr)1024];
			while (size > 0L)
			{
				long num = math.min(size, 1024L);
				UnsafeUtility.MemCpy((void*)ptr4, (void*)ptr2, num);
				UnsafeUtility.MemCpy((void*)ptr2, (void*)ptr3, num);
				UnsafeUtility.MemCpy((void*)ptr3, (void*)ptr4, num);
				size -= num;
				ptr3 += num;
				ptr2 += num;
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00022C99 File Offset: 0x00020E99
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static T ReadArrayElementBoundsChecked<T>(void* source, int index, int capacity)
		{
			return UnsafeUtility.ReadArrayElement<T>(source, index);
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x00022CA2 File Offset: 0x00020EA2
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void WriteArrayElementBoundsChecked<T>(void* destination, int index, T value, int capacity)
		{
			UnsafeUtility.WriteArrayElement<T>(destination, index, value);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00022CAC File Offset: 0x00020EAC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* AddressOf<T>(in T value) where T : struct
		{
			return ILSupport.AddressOf<T>(value);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00022CB4 File Offset: 0x00020EB4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T AsRef<T>(in T value) where T : struct
		{
			return ILSupport.AsRef<T>(value);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00022CBC File Offset: 0x00020EBC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private unsafe static void CheckMemSwapOverlap(byte* dst, byte* src, long size)
		{
			if (dst + size != src && src + size != dst)
			{
				throw new InvalidOperationException("MemSwap memory blocks are overlapped.");
			}
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00022CD7 File Offset: 0x00020ED7
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckIndexRange(int index, int capacity)
		{
			if (index > capacity - 1 || index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Attempt to read or write from array index {0}, which is out of bounds. Array capacity is {1}. ", index, capacity) + "This may lead to a crash, data corruption, or reading invalid data.");
			}
		}
	}
}
