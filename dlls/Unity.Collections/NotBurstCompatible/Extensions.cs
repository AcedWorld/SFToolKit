using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections.NotBurstCompatible
{
	// Token: 0x020000D9 RID: 217
	public static class Extensions
	{
		// Token: 0x060008A7 RID: 2215 RVA: 0x0001BBF4 File Offset: 0x00019DF4
		[NotBurstCompatible]
		public static T[] ToArray<[IsUnmanaged] T>(this NativeHashSet<T> set) where T : struct, ValueType, IEquatable<T>
		{
			NativeArray<T> nativeArray = set.ToNativeArray(Allocator.TempJob);
			T[] result = nativeArray.ToArray();
			nativeArray.Dispose();
			return result;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0001BC20 File Offset: 0x00019E20
		[NotBurstCompatible]
		public static T[] ToArrayNBC<[IsUnmanaged] T>(this NativeList<T> list) where T : struct, ValueType
		{
			return list.AsArray().ToArray();
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0001BC3C File Offset: 0x00019E3C
		[NotBurstCompatible]
		public static void CopyFromNBC<[IsUnmanaged] T>(this NativeList<T> list, T[] array) where T : struct, ValueType
		{
			list.Clear();
			list.Resize(array.Length, NativeArrayOptions.UninitializedMemory);
			list.AsArray().CopyFrom(array);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0001BC6B File Offset: 0x00019E6B
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		[Obsolete("Burst now supports tuple, please use `GetUniqueKeyArray` method from `Unity.Collections.UnsafeMultiHashMap` instead.", false)]
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArrayNBC<TKey, TValue>(this UnsafeMultiHashMap<TKey, TValue> hashmap, AllocatorManager.AllocatorHandle allocator) where TKey : struct, IEquatable<TKey>, IComparable<TKey> where TValue : struct
		{
			return hashmap.GetUniqueKeyArray(allocator);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0001BC74 File Offset: 0x00019E74
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		[Obsolete("Burst now supports tuple, please use `GetUniqueKeyArray` method from `Unity.Collections.NativeMultiHashMap` instead.", false)]
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArrayNBC<TKey, TValue>(this NativeMultiHashMap<TKey, TValue> hashmap, AllocatorManager.AllocatorHandle allocator) where TKey : struct, IEquatable<TKey>, IComparable<TKey> where TValue : struct
		{
			return hashmap.GetUniqueKeyArray(allocator);
		}
	}
}
