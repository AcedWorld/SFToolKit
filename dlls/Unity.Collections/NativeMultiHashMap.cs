using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000A1 RID: 161
	[NativeContainer]
	[DebuggerTypeProxy(typeof(NativeMultiHashMapDebuggerTypeProxy<, >))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	public struct NativeMultiHashMap<TKey, TValue> : INativeDisposable, IDisposable, IEnumerable<KeyValue<!0, !1>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x060006B9 RID: 1721 RVA: 0x000161D8 File Offset: 0x000143D8
		public NativeMultiHashMap(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeMultiHashMap<TKey, TValue>(capacity, allocator, 2);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x000161E3 File Offset: 0x000143E3
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal void Initialize<[IsUnmanaged] U>(int capacity, ref U allocator, int disposeSentinelStackDepth) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			this.m_MultiHashMapData = new UnsafeMultiHashMap<TKey, TValue>(capacity, allocator.Handle);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000161FD File Offset: 0x000143FD
		private NativeMultiHashMap(int capacity, AllocatorManager.AllocatorHandle allocator, int disposeSentinelStackDepth)
		{
			this = default(NativeMultiHashMap<TKey, TValue>);
			this.Initialize<AllocatorManager.AllocatorHandle>(capacity, ref allocator, disposeSentinelStackDepth);
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x00016210 File Offset: 0x00014410
		public bool IsEmpty
		{
			get
			{
				return this.m_MultiHashMapData.IsEmpty;
			}
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001621D File Offset: 0x0001441D
		public int Count()
		{
			return this.m_MultiHashMapData.Count();
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x0001622A File Offset: 0x0001442A
		// (set) Token: 0x060006BF RID: 1727 RVA: 0x00016237 File Offset: 0x00014437
		public int Capacity
		{
			get
			{
				return this.m_MultiHashMapData.Capacity;
			}
			set
			{
				this.m_MultiHashMapData.Capacity = value;
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00016245 File Offset: 0x00014445
		public void Clear()
		{
			this.m_MultiHashMapData.Clear();
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00016252 File Offset: 0x00014452
		public void Add(TKey key, TValue item)
		{
			this.m_MultiHashMapData.Add(key, item);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00016261 File Offset: 0x00014461
		public int Remove(TKey key)
		{
			return this.m_MultiHashMapData.Remove(key);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0001626F File Offset: 0x0001446F
		public void Remove(NativeMultiHashMapIterator<TKey> it)
		{
			this.m_MultiHashMapData.Remove(it);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0001627D File Offset: 0x0001447D
		public bool TryGetFirstValue(TKey key, out TValue item, out NativeMultiHashMapIterator<TKey> it)
		{
			return this.m_MultiHashMapData.TryGetFirstValue(key, out item, out it);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001628D File Offset: 0x0001448D
		public bool TryGetNextValue(out TValue item, ref NativeMultiHashMapIterator<TKey> it)
		{
			return this.m_MultiHashMapData.TryGetNextValue(out item, ref it);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001629C File Offset: 0x0001449C
		public bool ContainsKey(TKey key)
		{
			TValue tvalue;
			NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
			return this.TryGetFirstValue(key, out tvalue, out nativeMultiHashMapIterator);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000162B4 File Offset: 0x000144B4
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

		// Token: 0x060006C8 RID: 1736 RVA: 0x000162E5 File Offset: 0x000144E5
		public bool SetValue(TValue item, NativeMultiHashMapIterator<TKey> it)
		{
			return this.m_MultiHashMapData.SetValue(item, it);
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x000162F4 File Offset: 0x000144F4
		public bool IsCreated
		{
			get
			{
				return this.m_MultiHashMapData.IsCreated;
			}
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00016301 File Offset: 0x00014501
		public void Dispose()
		{
			this.m_MultiHashMapData.Dispose();
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00016310 File Offset: 0x00014510
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			JobHandle result = new UnsafeHashMapDataDisposeJob
			{
				Data = new UnsafeHashMapDataDispose
				{
					m_Buffer = this.m_MultiHashMapData.m_Buffer,
					m_AllocatorLabel = this.m_MultiHashMapData.m_AllocatorLabel
				}
			}.Schedule(inputDeps);
			this.m_MultiHashMapData.m_Buffer = null;
			return result;
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001636D File Offset: 0x0001456D
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_MultiHashMapData.GetKeyArray(allocator);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001637B File Offset: 0x0001457B
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_MultiHashMapData.GetValueArray(allocator);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00016389 File Offset: 0x00014589
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_MultiHashMapData.GetKeyValueArrays(allocator);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00016398 File Offset: 0x00014598
		public NativeMultiHashMap<TKey, TValue>.ParallelWriter AsParallelWriter()
		{
			NativeMultiHashMap<TKey, TValue>.ParallelWriter result;
			result.m_Writer = this.m_MultiHashMapData.AsParallelWriter();
			return result;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x000163B8 File Offset: 0x000145B8
		public NativeMultiHashMap<TKey, TValue>.Enumerator GetValuesForKey(TKey key)
		{
			return new NativeMultiHashMap<TKey, TValue>.Enumerator
			{
				hashmap = this,
				key = key,
				isFirst = true
			};
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x000163EC File Offset: 0x000145EC
		public NativeMultiHashMap<TKey, TValue>.KeyValueEnumerator GetEnumerator()
		{
			return new NativeMultiHashMap<TKey, TValue>.KeyValueEnumerator
			{
				m_Enumerator = new UnsafeHashMapDataEnumerator(this.m_MultiHashMapData.m_Buffer)
			};
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<!0, !1>>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite()
		{
		}

		// Token: 0x0400027C RID: 636
		internal UnsafeMultiHashMap<TKey, TValue> m_MultiHashMapData;

		// Token: 0x020000A2 RID: 162
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x170000BB RID: 187
			// (get) Token: 0x060006D6 RID: 1750 RVA: 0x00016419 File Offset: 0x00014619
			public int m_ThreadIndex
			{
				get
				{
					return this.m_Writer.m_ThreadIndex;
				}
			}

			// Token: 0x170000BC RID: 188
			// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00016426 File Offset: 0x00014626
			public int Capacity
			{
				get
				{
					return this.m_Writer.Capacity;
				}
			}

			// Token: 0x060006D8 RID: 1752 RVA: 0x00016433 File Offset: 0x00014633
			public void Add(TKey key, TValue item)
			{
				this.m_Writer.Add(key, item);
			}

			// Token: 0x0400027D RID: 637
			internal UnsafeMultiHashMap<TKey, TValue>.ParallelWriter m_Writer;
		}

		// Token: 0x020000A3 RID: 163
		public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
		{
			// Token: 0x060006D9 RID: 1753 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060006DA RID: 1754 RVA: 0x00016444 File Offset: 0x00014644
			public bool MoveNext()
			{
				if (this.isFirst)
				{
					this.isFirst = false;
					return this.hashmap.TryGetFirstValue(this.key, out this.value, out this.iterator);
				}
				return this.hashmap.TryGetNextValue(out this.value, ref this.iterator);
			}

			// Token: 0x060006DB RID: 1755 RVA: 0x00016495 File Offset: 0x00014695
			public void Reset()
			{
				this.isFirst = true;
			}

			// Token: 0x170000BD RID: 189
			// (get) Token: 0x060006DC RID: 1756 RVA: 0x0001649E File Offset: 0x0001469E
			public TValue Current
			{
				get
				{
					return this.value;
				}
			}

			// Token: 0x170000BE RID: 190
			// (get) Token: 0x060006DD RID: 1757 RVA: 0x000164A6 File Offset: 0x000146A6
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060006DE RID: 1758 RVA: 0x000164B3 File Offset: 0x000146B3
			public NativeMultiHashMap<TKey, TValue>.Enumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x0400027E RID: 638
			internal NativeMultiHashMap<TKey, TValue> hashmap;

			// Token: 0x0400027F RID: 639
			internal TKey key;

			// Token: 0x04000280 RID: 640
			internal bool isFirst;

			// Token: 0x04000281 RID: 641
			private TValue value;

			// Token: 0x04000282 RID: 642
			private NativeMultiHashMapIterator<TKey> iterator;
		}

		// Token: 0x020000A4 RID: 164
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct KeyValueEnumerator : IEnumerator<KeyValue<TKey, TValue>>, IEnumerator, IDisposable
		{
			// Token: 0x060006DF RID: 1759 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060006E0 RID: 1760 RVA: 0x000164BB File Offset: 0x000146BB
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x060006E1 RID: 1761 RVA: 0x000164C8 File Offset: 0x000146C8
			public void Reset()
			{
				this.m_Enumerator.Reset();
			}

			// Token: 0x170000BF RID: 191
			// (get) Token: 0x060006E2 RID: 1762 RVA: 0x000164D5 File Offset: 0x000146D5
			public KeyValue<TKey, TValue> Current
			{
				get
				{
					return this.m_Enumerator.GetCurrent<TKey, TValue>();
				}
			}

			// Token: 0x170000C0 RID: 192
			// (get) Token: 0x060006E3 RID: 1763 RVA: 0x000164E2 File Offset: 0x000146E2
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000283 RID: 643
			internal UnsafeHashMapDataEnumerator m_Enumerator;
		}
	}
}
