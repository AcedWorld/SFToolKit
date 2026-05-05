using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x02000093 RID: 147
	[BurstCompatible]
	public static class NativeHashMapExtensions
	{
		// Token: 0x06000635 RID: 1589 RVA: 0x00014F70 File Offset: 0x00013170
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static int Unique<T>(this NativeArray<T> array) where T : struct, IEquatable<T>
		{
			if (array.Length == 0)
			{
				return 0;
			}
			int num = 0;
			int length = array.Length;
			int num2 = num;
			while (++num != length)
			{
				T t = array[num2];
				if (!t.Equals(array[num]))
				{
					array[++num2] = array[num];
				}
			}
			return num2 + 1;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00014FD8 File Offset: 0x000131D8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArray<TKey, TValue>(this UnsafeMultiHashMap<TKey, TValue> container, AllocatorManager.AllocatorHandle allocator) where TKey : struct, IEquatable<TKey>, IComparable<TKey> where TValue : struct
		{
			NativeArray<TKey> keyArray = container.GetKeyArray(allocator);
			keyArray.Sort<TKey>();
			int item = keyArray.Unique<TKey>();
			return new ValueTuple<NativeArray<TKey>, int>(keyArray, item);
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00015000 File Offset: 0x00013200
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArray<TKey, TValue>(this NativeMultiHashMap<TKey, TValue> container, AllocatorManager.AllocatorHandle allocator) where TKey : struct, IEquatable<TKey>, IComparable<TKey> where TValue : struct
		{
			NativeArray<TKey> keyArray = container.GetKeyArray(allocator);
			keyArray.Sort<TKey>();
			int item = keyArray.Unique<TKey>();
			return new ValueTuple<NativeArray<TKey>, int>(keyArray, item);
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00015028 File Offset: 0x00013228
		[Obsolete("GetBucketData is deprecated, please use GetUnsafeBucketData instead. (RemovedAfter 2021-07-08) (UnityUpgradable) -> GetUnsafeBucketData<TKey,TValue>(*)", false)]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static UnsafeHashMapBucketData GetBucketData<TKey, TValue>(this NativeHashMap<TKey, TValue> container) where TKey : struct, IEquatable<TKey> where TValue : struct
		{
			return container.m_HashMapData.m_Buffer->GetBucketData();
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00015028 File Offset: 0x00013228
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static UnsafeHashMapBucketData GetUnsafeBucketData<TKey, TValue>(this NativeHashMap<TKey, TValue> container) where TKey : struct, IEquatable<TKey> where TValue : struct
		{
			return container.m_HashMapData.m_Buffer->GetBucketData();
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001503A File Offset: 0x0001323A
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static UnsafeHashMapBucketData GetUnsafeBucketData<TKey, TValue>(this NativeMultiHashMap<TKey, TValue> container) where TKey : struct, IEquatable<TKey> where TValue : struct
		{
			return container.m_MultiHashMapData.m_Buffer->GetBucketData();
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001504C File Offset: 0x0001324C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static void Remove<TKey, TValue>(this NativeMultiHashMap<TKey, TValue> container, TKey key, TValue value) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
			container.m_MultiHashMapData.Remove<TValue>(key, value);
		}
	}
}
