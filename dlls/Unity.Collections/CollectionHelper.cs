using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x02000027 RID: 39
	[BurstCompatible]
	public static class CollectionHelper
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x00003A57 File Offset: 0x00001C57
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void CheckAllocator(AllocatorManager.AllocatorHandle allocator)
		{
			if (!CollectionHelper.ShouldDeallocate(allocator))
			{
				throw new ArgumentException(string.Format("Allocator {0} must not be None or Invalid", allocator));
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003A77 File Offset: 0x00001C77
		public static int Log2Floor(int value)
		{
			return 31 - math.lzcnt((uint)value);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003A82 File Offset: 0x00001C82
		public static int Log2Ceil(int value)
		{
			return 32 - math.lzcnt((uint)(value - 1));
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003A8F File Offset: 0x00001C8F
		public static int Align(int size, int alignmentPowerOfTwo)
		{
			if (alignmentPowerOfTwo == 0)
			{
				return size;
			}
			return size + alignmentPowerOfTwo - 1 & ~(alignmentPowerOfTwo - 1);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003AA0 File Offset: 0x00001CA0
		public static ulong Align(ulong size, ulong alignmentPowerOfTwo)
		{
			if (alignmentPowerOfTwo == 0UL)
			{
				return size;
			}
			return size + alignmentPowerOfTwo - 1UL & ~(alignmentPowerOfTwo - 1UL);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003AB3 File Offset: 0x00001CB3
		public unsafe static bool IsAligned(void* p, int alignmentPowerOfTwo)
		{
			return ((byte*)p & (byte*)((long)alignmentPowerOfTwo) - 1L) == null;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003AC1 File Offset: 0x00001CC1
		public static bool IsAligned(ulong offset, int alignmentPowerOfTwo)
		{
			return (offset & (ulong)((long)alignmentPowerOfTwo - 1L)) == 0UL;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003ACE File Offset: 0x00001CCE
		public static bool IsPowerOfTwo(int value)
		{
			return (value & value - 1) == 0;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003AD8 File Offset: 0x00001CD8
		public unsafe static uint Hash(void* ptr, int bytes)
		{
			ulong num = 5381UL;
			while (bytes > 0)
			{
				int num2 = --bytes;
				ulong num3 = (ulong)((byte*)ptr)[num2];
				num = (num << 5) + num + num3;
			}
			return (uint)num;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003B0C File Offset: 0x00001D0C
		[NotBurstCompatible]
		internal static void WriteLayout(Type type)
		{
			Console.WriteLine(string.Format("   Offset | Bytes  | Name     Layout: {0}", 0), type.Name);
			foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				Console.WriteLine("   {0, 6} | {1, 6} | {2}", Marshal.OffsetOf(type, fieldInfo.Name), Marshal.SizeOf(fieldInfo.FieldType), fieldInfo.Name);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003B80 File Offset: 0x00001D80
		internal static bool ShouldDeallocate(AllocatorManager.AllocatorHandle allocator)
		{
			return allocator.ToAllocator > Allocator.None;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003B8C File Offset: 0x00001D8C
		[return: AssumeRange(0L, 2147483647L)]
		internal static int AssumePositive(int value)
		{
			return value;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003B8F File Offset: 0x00001D8F
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[BurstDiscard]
		[NotBurstCompatible]
		internal static void CheckIsUnmanaged<T>()
		{
			if (!UnsafeUtility.IsValidNativeContainerElementType<T>())
			{
				throw new ArgumentException(string.Format("{0} used in native collection is not blittable, not primitive, or contains a type tagged as NativeContainer", typeof(T)));
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003BB2 File Offset: 0x00001DB2
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void CheckIntPositivePowerOfTwo(int value)
		{
			if (value <= 0 || (value & value - 1) != 0)
			{
				throw new ArgumentException(string.Format("Alignment requested: {0} is not a non-zero, positive power of two.", value));
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003BDB File Offset: 0x00001DDB
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void CheckUlongPositivePowerOfTwo(ulong value)
		{
			if (value <= 0UL || (value & value - 1UL) != 0UL)
			{
				throw new ArgumentException(string.Format("Alignment requested: {0} is not a non-zero, positive power of two.", value));
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003C07 File Offset: 0x00001E07
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckIndexInRange(int index, int length)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= length)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in container of '{1}' Length.", index, length));
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003C43 File Offset: 0x00001E43
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckCapacityInRange(int capacity, int length)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} must be positive.", capacity));
			}
			if (capacity < length)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} is out of range in container of '{1}' Length.", capacity, length));
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003C80 File Offset: 0x00001E80
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(AllocatorManager.AllocatorHandle)
		})]
		public static NativeArray<T> CreateNativeArray<T, [IsUnmanaged] U>(int length, ref U allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct where U : struct, ValueType, AllocatorManager.IAllocator
		{
			NativeArray<T> result;
			if (!allocator.IsCustomAllocator)
			{
				result = new NativeArray<T>(length, allocator.ToAllocator, options);
			}
			else
			{
				result = default(NativeArray<T>);
				ref result.Initialize(length, ref allocator, options);
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003CC8 File Offset: 0x00001EC8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static NativeArray<T> CreateNativeArray<T>(int length, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct
		{
			NativeArray<T> result;
			if (!AllocatorManager.IsCustomAllocator(allocator))
			{
				result = new NativeArray<T>(length, allocator.ToAllocator, options);
			}
			else
			{
				result = default(NativeArray<T>);
				ref result.Initialize(length, allocator, options);
			}
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003D04 File Offset: 0x00001F04
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static NativeArray<T> CreateNativeArray<T>(NativeArray<T> array, AllocatorManager.AllocatorHandle allocator) where T : struct
		{
			NativeArray<T> result;
			if (!AllocatorManager.IsCustomAllocator(allocator))
			{
				result = new NativeArray<T>(array, allocator.ToAllocator);
			}
			else
			{
				result = default(NativeArray<T>);
				ref result.Initialize(array.Length, allocator, NativeArrayOptions.UninitializedMemory);
				result.CopyFrom(array);
			}
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003D4C File Offset: 0x00001F4C
		[NotBurstCompatible]
		public static NativeArray<T> CreateNativeArray<T>(T[] array, AllocatorManager.AllocatorHandle allocator) where T : struct
		{
			NativeArray<T> result;
			if (!AllocatorManager.IsCustomAllocator(allocator))
			{
				result = new NativeArray<T>(array, allocator.ToAllocator);
			}
			else
			{
				result = default(NativeArray<T>);
				ref result.Initialize(array.Length, allocator, NativeArrayOptions.UninitializedMemory);
				result.CopyFrom(array);
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003D90 File Offset: 0x00001F90
		[NotBurstCompatible]
		public static NativeArray<T> CreateNativeArray<T, [IsUnmanaged] U>(T[] array, ref U allocator) where T : struct where U : struct, ValueType, AllocatorManager.IAllocator
		{
			NativeArray<T> result;
			if (!allocator.IsCustomAllocator)
			{
				result = new NativeArray<T>(array, allocator.ToAllocator);
			}
			else
			{
				result = default(NativeArray<T>);
				ref result.Initialize(array.Length, ref allocator, NativeArrayOptions.ClearMemory);
				result.CopyFrom(array);
			}
			return result;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003DE0 File Offset: 0x00001FE0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int),
			typeof(AllocatorManager.AllocatorHandle)
		})]
		public static NativeMultiHashMap<TKey, TValue> CreateNativeMultiHashMap<TKey, TValue, [IsUnmanaged] U>(int length, ref U allocator) where TKey : struct, IEquatable<TKey> where TValue : struct where U : struct, ValueType, AllocatorManager.IAllocator
		{
			NativeMultiHashMap<TKey, TValue> result = default(NativeMultiHashMap<TKey, TValue>);
			ref result.Initialize(length, ref allocator, 2);
			return result;
		}

		// Token: 0x04000074 RID: 116
		public const int CacheLineSize = 64;

		// Token: 0x02000028 RID: 40
		[StructLayout(LayoutKind.Explicit)]
		internal struct LongDoubleUnion
		{
			// Token: 0x04000075 RID: 117
			[FieldOffset(0)]
			internal long longValue;

			// Token: 0x04000076 RID: 118
			[FieldOffset(0)]
			internal double doubleValue;
		}
	}
}
