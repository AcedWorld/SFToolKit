using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000114 RID: 276
	[DebuggerTypeProxy(typeof(UnsafeMultiHashMapDebuggerTypeProxy<, >))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	public struct UnsafeMultiHashMap<TKey, TValue> : INativeDisposable, IDisposable, IEnumerable<KeyValue<TKey, TValue>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x06000A8E RID: 2702 RVA: 0x00021886 File Offset: 0x0001FA86
		public UnsafeMultiHashMap(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this.m_AllocatorLabel = allocator;
			UnsafeHashMapData.AllocateHashMap<TKey, TValue>(capacity, capacity * 2, allocator, out this.m_Buffer);
			this.Clear();
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x000218A5 File Offset: 0x0001FAA5
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || UnsafeHashMapData.IsEmpty(this.m_Buffer);
			}
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x000218BC File Offset: 0x0001FABC
		public unsafe int Count()
		{
			if (this.m_Buffer->allocatedIndexLength <= 0)
			{
				return 0;
			}
			return UnsafeHashMapData.GetCount(this.m_Buffer);
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x000218D9 File Offset: 0x0001FAD9
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x000218E6 File Offset: 0x0001FAE6
		public unsafe int Capacity
		{
			get
			{
				return this.m_Buffer->keyCapacity;
			}
			set
			{
				UnsafeHashMapData.ReallocateHashMap<TKey, TValue>(this.m_Buffer, value, UnsafeHashMapData.GetBucketSize(value), this.m_AllocatorLabel);
			}
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00021900 File Offset: 0x0001FB00
		public void Clear()
		{
			UnsafeHashMapBase<TKey, TValue>.Clear(this.m_Buffer);
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0002190D File Offset: 0x0001FB0D
		public void Add(TKey key, TValue item)
		{
			UnsafeHashMapBase<TKey, TValue>.TryAdd(this.m_Buffer, key, item, true, this.m_AllocatorLabel);
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00021924 File Offset: 0x0001FB24
		public int Remove(TKey key)
		{
			return UnsafeHashMapBase<TKey, TValue>.Remove(this.m_Buffer, key, true);
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00021933 File Offset: 0x0001FB33
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public void Remove<TValueEQ>(TKey key, TValueEQ value) where TValueEQ : struct, IEquatable<TValueEQ>
		{
			UnsafeHashMapBase<TKey, TValueEQ>.RemoveKeyValue<TValueEQ>(this.m_Buffer, key, value);
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00021942 File Offset: 0x0001FB42
		public void Remove(NativeMultiHashMapIterator<TKey> it)
		{
			UnsafeHashMapBase<TKey, TValue>.Remove(this.m_Buffer, it);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00021950 File Offset: 0x0001FB50
		public bool TryGetFirstValue(TKey key, out TValue item, out NativeMultiHashMapIterator<TKey> it)
		{
			return UnsafeHashMapBase<TKey, TValue>.TryGetFirstValueAtomic(this.m_Buffer, key, out item, out it);
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x00021960 File Offset: 0x0001FB60
		public bool TryGetNextValue(out TValue item, ref NativeMultiHashMapIterator<TKey> it)
		{
			return UnsafeHashMapBase<TKey, TValue>.TryGetNextValueAtomic(this.m_Buffer, out item, ref it);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00021970 File Offset: 0x0001FB70
		public bool ContainsKey(TKey key)
		{
			TValue tvalue;
			NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
			return this.TryGetFirstValue(key, out tvalue, out nativeMultiHashMapIterator);
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00021988 File Offset: 0x0001FB88
		public int CountValuesForKey(TKey key)
		{
			TValue tvalue;
			NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
			if (!this.TryGetFirstValue(key, out tvalue, out nativeMultiHashMapIterator))
			{
				return 0;
			}
			int num = 1;
			while (this.TryGetNextValue(out tvalue, ref nativeMultiHashMapIterator))
			{
				num++;
			}
			return num;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x000219B9 File Offset: 0x0001FBB9
		public bool SetValue(TValue item, NativeMultiHashMapIterator<TKey> it)
		{
			return UnsafeHashMapBase<TKey, TValue>.SetValue(this.m_Buffer, ref it, ref item);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x000219CA File Offset: 0x0001FBCA
		public bool IsCreated
		{
			get
			{
				return this.m_Buffer != null;
			}
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x000219D9 File Offset: 0x0001FBD9
		public void Dispose()
		{
			UnsafeHashMapData.DeallocateHashMap(this.m_Buffer, this.m_AllocatorLabel);
			this.m_Buffer = null;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x000219F4 File Offset: 0x0001FBF4
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			JobHandle result = new UnsafeHashMapDisposeJob
			{
				Data = this.m_Buffer,
				Allocator = this.m_AllocatorLabel
			}.Schedule(inputDeps);
			this.m_Buffer = null;
			return result;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00021A34 File Offset: 0x0001FC34
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<TKey> result = CollectionHelper.CreateNativeArray<TKey>(this.Count(), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeHashMapData.GetKeyArray<TKey>(this.m_Buffer, result);
			return result;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00021A5C File Offset: 0x0001FC5C
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<TValue> result = CollectionHelper.CreateNativeArray<TValue>(this.Count(), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeHashMapData.GetValueArray<TValue>(this.m_Buffer, result);
			return result;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00021A84 File Offset: 0x0001FC84
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator)
		{
			NativeKeyValueArrays<TKey, TValue> result = new NativeKeyValueArrays<TKey, TValue>(this.Count(), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeHashMapData.GetKeyValueArrays<TKey, TValue>(this.m_Buffer, result);
			return result;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00021AB0 File Offset: 0x0001FCB0
		public UnsafeMultiHashMap<TKey, TValue>.Enumerator GetValuesForKey(TKey key)
		{
			return new UnsafeMultiHashMap<TKey, TValue>.Enumerator
			{
				hashmap = this,
				key = key,
				isFirst = true
			};
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00021AE4 File Offset: 0x0001FCE4
		public UnsafeMultiHashMap<TKey, TValue>.ParallelWriter AsParallelWriter()
		{
			UnsafeMultiHashMap<TKey, TValue>.ParallelWriter result;
			result.m_ThreadIndex = 0;
			result.m_Buffer = this.m_Buffer;
			return result;
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00021B08 File Offset: 0x0001FD08
		public UnsafeMultiHashMap<TKey, TValue>.KeyValueEnumerator GetEnumerator()
		{
			return new UnsafeMultiHashMap<TKey, TValue>.KeyValueEnumerator
			{
				m_Enumerator = new UnsafeHashMapDataEnumerator(this.m_Buffer)
			};
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<!0, !1>>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000395 RID: 917
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeHashMapData* m_Buffer;

		// Token: 0x04000396 RID: 918
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;

		// Token: 0x02000115 RID: 277
		public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
		{
			// Token: 0x06000AA8 RID: 2728 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000AA9 RID: 2729 RVA: 0x00021B30 File Offset: 0x0001FD30
			public bool MoveNext()
			{
				if (this.isFirst)
				{
					this.isFirst = false;
					return this.hashmap.TryGetFirstValue(this.key, out this.value, out this.iterator);
				}
				return this.hashmap.TryGetNextValue(out this.value, ref this.iterator);
			}

			// Token: 0x06000AAA RID: 2730 RVA: 0x00021B81 File Offset: 0x0001FD81
			public void Reset()
			{
				this.isFirst = true;
			}

			// Token: 0x1700011F RID: 287
			// (get) Token: 0x06000AAB RID: 2731 RVA: 0x00021B8A File Offset: 0x0001FD8A
			public TValue Current
			{
				get
				{
					return this.value;
				}
			}

			// Token: 0x17000120 RID: 288
			// (get) Token: 0x06000AAC RID: 2732 RVA: 0x00021B92 File Offset: 0x0001FD92
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000AAD RID: 2733 RVA: 0x00021B9F File Offset: 0x0001FD9F
			public UnsafeMultiHashMap<TKey, TValue>.Enumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x04000397 RID: 919
			internal UnsafeMultiHashMap<TKey, TValue> hashmap;

			// Token: 0x04000398 RID: 920
			internal TKey key;

			// Token: 0x04000399 RID: 921
			internal bool isFirst;

			// Token: 0x0400039A RID: 922
			private TValue value;

			// Token: 0x0400039B RID: 923
			private NativeMultiHashMapIterator<TKey> iterator;
		}

		// Token: 0x02000116 RID: 278
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x17000121 RID: 289
			// (get) Token: 0x06000AAE RID: 2734 RVA: 0x00021BA7 File Offset: 0x0001FDA7
			public unsafe int Capacity
			{
				get
				{
					return this.m_Buffer->keyCapacity;
				}
			}

			// Token: 0x06000AAF RID: 2735 RVA: 0x00021BB4 File Offset: 0x0001FDB4
			public void Add(TKey key, TValue item)
			{
				UnsafeHashMapBase<TKey, TValue>.AddAtomicMulti(this.m_Buffer, key, item, this.m_ThreadIndex);
			}

			// Token: 0x0400039C RID: 924
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeHashMapData* m_Buffer;

			// Token: 0x0400039D RID: 925
			[NativeSetThreadIndex]
			internal int m_ThreadIndex;
		}

		// Token: 0x02000117 RID: 279
		public struct KeyValueEnumerator : IEnumerator<KeyValue<TKey, TValue>>, IEnumerator, IDisposable
		{
			// Token: 0x06000AB0 RID: 2736 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000AB1 RID: 2737 RVA: 0x00021BC9 File Offset: 0x0001FDC9
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000AB2 RID: 2738 RVA: 0x00021BD6 File Offset: 0x0001FDD6
			public void Reset()
			{
				this.m_Enumerator.Reset();
			}

			// Token: 0x17000122 RID: 290
			// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x00021BE3 File Offset: 0x0001FDE3
			public KeyValue<TKey, TValue> Current
			{
				get
				{
					return this.m_Enumerator.GetCurrent<TKey, TValue>();
				}
			}

			// Token: 0x17000123 RID: 291
			// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x00021BF0 File Offset: 0x0001FDF0
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400039E RID: 926
			internal UnsafeHashMapDataEnumerator m_Enumerator;
		}
	}
}
