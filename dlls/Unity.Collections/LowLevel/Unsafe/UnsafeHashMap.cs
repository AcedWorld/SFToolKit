using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000FC RID: 252
	[DebuggerDisplay("Count = {Count()}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafeHashMapDebuggerTypeProxy<, >))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	public struct UnsafeHashMap<TKey, TValue> : INativeDisposable, IDisposable, IEnumerable<KeyValue<!0, !1>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x060009B7 RID: 2487 RVA: 0x0001F4F2 File Offset: 0x0001D6F2
		public UnsafeHashMap(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this.m_AllocatorLabel = allocator;
			UnsafeHashMapData.AllocateHashMap<TKey, TValue>(capacity, capacity * 2, allocator, out this.m_Buffer);
			this.Clear();
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0001F511 File Offset: 0x0001D711
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || UnsafeHashMapData.IsEmpty(this.m_Buffer);
			}
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0001F528 File Offset: 0x0001D728
		public int Count()
		{
			return UnsafeHashMapData.GetCount(this.m_Buffer);
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x0001F535 File Offset: 0x0001D735
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x0001F542 File Offset: 0x0001D742
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

		// Token: 0x060009BC RID: 2492 RVA: 0x0001F55C File Offset: 0x0001D75C
		public void Clear()
		{
			UnsafeHashMapBase<TKey, TValue>.Clear(this.m_Buffer);
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0001F569 File Offset: 0x0001D769
		public bool TryAdd(TKey key, TValue item)
		{
			return UnsafeHashMapBase<TKey, TValue>.TryAdd(this.m_Buffer, key, item, false, this.m_AllocatorLabel);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0001F57F File Offset: 0x0001D77F
		public void Add(TKey key, TValue item)
		{
			this.TryAdd(key, item);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0001F58A File Offset: 0x0001D78A
		public bool Remove(TKey key)
		{
			return UnsafeHashMapBase<TKey, TValue>.Remove(this.m_Buffer, key, false) != 0;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0001F59C File Offset: 0x0001D79C
		public bool TryGetValue(TKey key, out TValue item)
		{
			NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
			return UnsafeHashMapBase<TKey, TValue>.TryGetFirstValueAtomic(this.m_Buffer, key, out item, out nativeMultiHashMapIterator);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0001F5B8 File Offset: 0x0001D7B8
		public bool ContainsKey(TKey key)
		{
			TValue tvalue;
			NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
			return UnsafeHashMapBase<TKey, TValue>.TryGetFirstValueAtomic(this.m_Buffer, key, out tvalue, out nativeMultiHashMapIterator);
		}

		// Token: 0x17000100 RID: 256
		public TValue this[TKey key]
		{
			get
			{
				TValue result;
				this.TryGetValue(key, out result);
				return result;
			}
			set
			{
				TValue tvalue;
				NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
				if (UnsafeHashMapBase<TKey, TValue>.TryGetFirstValueAtomic(this.m_Buffer, key, out tvalue, out nativeMultiHashMapIterator))
				{
					UnsafeHashMapBase<TKey, TValue>.SetValue(this.m_Buffer, ref nativeMultiHashMapIterator, ref value);
					return;
				}
				UnsafeHashMapBase<TKey, TValue>.TryAdd(this.m_Buffer, key, value, false, this.m_AllocatorLabel);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0001F635 File Offset: 0x0001D835
		public bool IsCreated
		{
			get
			{
				return this.m_Buffer != null;
			}
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0001F644 File Offset: 0x0001D844
		public void Dispose()
		{
			UnsafeHashMapData.DeallocateHashMap(this.m_Buffer, this.m_AllocatorLabel);
			this.m_Buffer = null;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0001F660 File Offset: 0x0001D860
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

		// Token: 0x060009C7 RID: 2503 RVA: 0x0001F6A0 File Offset: 0x0001D8A0
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<TKey> result = CollectionHelper.CreateNativeArray<TKey>(UnsafeHashMapData.GetCount(this.m_Buffer), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeHashMapData.GetKeyArray<TKey>(this.m_Buffer, result);
			return result;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0001F6D0 File Offset: 0x0001D8D0
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<TValue> result = CollectionHelper.CreateNativeArray<TValue>(UnsafeHashMapData.GetCount(this.m_Buffer), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeHashMapData.GetValueArray<TValue>(this.m_Buffer, result);
			return result;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0001F700 File Offset: 0x0001D900
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator)
		{
			NativeKeyValueArrays<TKey, TValue> result = new NativeKeyValueArrays<TKey, TValue>(UnsafeHashMapData.GetCount(this.m_Buffer), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeHashMapData.GetKeyValueArrays<TKey, TValue>(this.m_Buffer, result);
			return result;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0001F730 File Offset: 0x0001D930
		public UnsafeHashMap<TKey, TValue>.ParallelWriter AsParallelWriter()
		{
			UnsafeHashMap<TKey, TValue>.ParallelWriter result;
			result.m_ThreadIndex = 0;
			result.m_Buffer = this.m_Buffer;
			return result;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0001F754 File Offset: 0x0001D954
		public UnsafeHashMap<TKey, TValue>.Enumerator GetEnumerator()
		{
			return new UnsafeHashMap<TKey, TValue>.Enumerator
			{
				m_Enumerator = new UnsafeHashMapDataEnumerator(this.m_Buffer)
			};
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<!0, !1>>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000367 RID: 871
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeHashMapData* m_Buffer;

		// Token: 0x04000368 RID: 872
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;

		// Token: 0x020000FD RID: 253
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x17000102 RID: 258
			// (get) Token: 0x060009CE RID: 2510 RVA: 0x0001F77C File Offset: 0x0001D97C
			public unsafe int Capacity
			{
				get
				{
					return this.m_Buffer->keyCapacity;
				}
			}

			// Token: 0x060009CF RID: 2511 RVA: 0x0001F789 File Offset: 0x0001D989
			public bool TryAdd(TKey key, TValue item)
			{
				return UnsafeHashMapBase<TKey, TValue>.TryAddAtomic(this.m_Buffer, key, item, this.m_ThreadIndex);
			}

			// Token: 0x04000369 RID: 873
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeHashMapData* m_Buffer;

			// Token: 0x0400036A RID: 874
			[NativeSetThreadIndex]
			internal int m_ThreadIndex;
		}

		// Token: 0x020000FE RID: 254
		public struct Enumerator : IEnumerator<KeyValue<TKey, TValue>>, IEnumerator, IDisposable
		{
			// Token: 0x060009D0 RID: 2512 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060009D1 RID: 2513 RVA: 0x0001F79E File Offset: 0x0001D99E
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x060009D2 RID: 2514 RVA: 0x0001F7AB File Offset: 0x0001D9AB
			public void Reset()
			{
				this.m_Enumerator.Reset();
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0001F7B8 File Offset: 0x0001D9B8
			public KeyValue<TKey, TValue> Current
			{
				get
				{
					return this.m_Enumerator.GetCurrent<TKey, TValue>();
				}
			}

			// Token: 0x17000104 RID: 260
			// (get) Token: 0x060009D4 RID: 2516 RVA: 0x0001F7C5 File Offset: 0x0001D9C5
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400036B RID: 875
			internal UnsafeHashMapDataEnumerator m_Enumerator;
		}
	}
}
