using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x0200008F RID: 143
	[NativeContainer]
	[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(NativeHashMapDebuggerTypeProxy<, >))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	public struct NativeHashMap<TKey, TValue> : INativeDisposable, IDisposable, IEnumerable<KeyValue<!0, !1>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x0600060F RID: 1551 RVA: 0x00014C7C File Offset: 0x00012E7C
		public NativeHashMap(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeHashMap<TKey, TValue>(capacity, allocator, 2);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00014C87 File Offset: 0x00012E87
		private NativeHashMap(int capacity, AllocatorManager.AllocatorHandle allocator, int disposeSentinelStackDepth)
		{
			this.m_HashMapData = new UnsafeHashMap<TKey, TValue>(capacity, allocator);
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x00014C96 File Offset: 0x00012E96
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.m_HashMapData.IsEmpty;
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00014CAD File Offset: 0x00012EAD
		public int Count()
		{
			return this.m_HashMapData.Count();
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x00014CBA File Offset: 0x00012EBA
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x00014CC7 File Offset: 0x00012EC7
		public int Capacity
		{
			get
			{
				return this.m_HashMapData.Capacity;
			}
			set
			{
				this.m_HashMapData.Capacity = value;
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00014CD5 File Offset: 0x00012ED5
		public void Clear()
		{
			this.m_HashMapData.Clear();
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00014CE2 File Offset: 0x00012EE2
		public bool TryAdd(TKey key, TValue item)
		{
			return this.m_HashMapData.TryAdd(key, item);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00014CF1 File Offset: 0x00012EF1
		public void Add(TKey key, TValue item)
		{
			this.TryAdd(key, item);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00014CFC File Offset: 0x00012EFC
		public bool Remove(TKey key)
		{
			return this.m_HashMapData.Remove(key);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00014D0A File Offset: 0x00012F0A
		public bool TryGetValue(TKey key, out TValue item)
		{
			return this.m_HashMapData.TryGetValue(key, out item);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00014D19 File Offset: 0x00012F19
		public bool ContainsKey(TKey key)
		{
			return this.m_HashMapData.ContainsKey(key);
		}

		// Token: 0x1700009F RID: 159
		public TValue this[TKey key]
		{
			get
			{
				TValue result;
				if (this.m_HashMapData.TryGetValue(key, out result))
				{
					return result;
				}
				return default(TValue);
			}
			set
			{
				this.m_HashMapData[key] = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x00014D5F File Offset: 0x00012F5F
		public bool IsCreated
		{
			get
			{
				return this.m_HashMapData.IsCreated;
			}
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00014D6C File Offset: 0x00012F6C
		public void Dispose()
		{
			this.m_HashMapData.Dispose();
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00014D7C File Offset: 0x00012F7C
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			JobHandle result = new UnsafeHashMapDataDisposeJob
			{
				Data = new UnsafeHashMapDataDispose
				{
					m_Buffer = this.m_HashMapData.m_Buffer,
					m_AllocatorLabel = this.m_HashMapData.m_AllocatorLabel
				}
			}.Schedule(inputDeps);
			this.m_HashMapData.m_Buffer = null;
			return result;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00014DD9 File Offset: 0x00012FD9
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_HashMapData.GetKeyArray(allocator);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00014DE7 File Offset: 0x00012FE7
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_HashMapData.GetValueArray(allocator);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00014DF5 File Offset: 0x00012FF5
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_HashMapData.GetKeyValueArrays(allocator);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00014E04 File Offset: 0x00013004
		public NativeHashMap<TKey, TValue>.ParallelWriter AsParallelWriter()
		{
			NativeHashMap<TKey, TValue>.ParallelWriter result;
			result.m_Writer = this.m_HashMapData.AsParallelWriter();
			return result;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00014E24 File Offset: 0x00013024
		public NativeHashMap<TKey, TValue>.Enumerator GetEnumerator()
		{
			return new NativeHashMap<TKey, TValue>.Enumerator
			{
				m_Enumerator = new UnsafeHashMapDataEnumerator(this.m_HashMapData.m_Buffer)
			};
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<!0, !1>>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite()
		{
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00014E51 File Offset: 0x00013051
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ThrowKeyNotPresent(TKey key)
		{
			throw new ArgumentException(string.Format("Key: {0} is not present in the NativeHashMap.", key));
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00014E68 File Offset: 0x00013068
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ThrowKeyAlreadyAdded(TKey key)
		{
			throw new ArgumentException("An item with the same key has already been added", "key");
		}

		// Token: 0x0400026B RID: 619
		internal UnsafeHashMap<TKey, TValue> m_HashMapData;

		// Token: 0x02000090 RID: 144
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		[DebuggerDisplay("Capacity = {m_Writer.Capacity}")]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x170000A1 RID: 161
			// (get) Token: 0x0600062B RID: 1579 RVA: 0x00014E79 File Offset: 0x00013079
			public int m_ThreadIndex
			{
				get
				{
					return this.m_Writer.m_ThreadIndex;
				}
			}

			// Token: 0x170000A2 RID: 162
			// (get) Token: 0x0600062C RID: 1580 RVA: 0x00014E86 File Offset: 0x00013086
			public int Capacity
			{
				get
				{
					return this.m_Writer.Capacity;
				}
			}

			// Token: 0x0600062D RID: 1581 RVA: 0x00014E93 File Offset: 0x00013093
			public bool TryAdd(TKey key, TValue item)
			{
				return this.m_Writer.TryAdd(key, item);
			}

			// Token: 0x0400026C RID: 620
			internal UnsafeHashMap<TKey, TValue>.ParallelWriter m_Writer;
		}

		// Token: 0x02000091 RID: 145
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct Enumerator : IEnumerator<KeyValue<TKey, TValue>>, IEnumerator, IDisposable
		{
			// Token: 0x0600062E RID: 1582 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x0600062F RID: 1583 RVA: 0x00014EA2 File Offset: 0x000130A2
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000630 RID: 1584 RVA: 0x00014EAF File Offset: 0x000130AF
			public void Reset()
			{
				this.m_Enumerator.Reset();
			}

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x06000631 RID: 1585 RVA: 0x00014EBC File Offset: 0x000130BC
			public KeyValue<TKey, TValue> Current
			{
				get
				{
					return this.m_Enumerator.GetCurrent<TKey, TValue>();
				}
			}

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x06000632 RID: 1586 RVA: 0x00014EC9 File Offset: 0x000130C9
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400026D RID: 621
			internal UnsafeHashMapDataEnumerator m_Enumerator;
		}
	}
}
