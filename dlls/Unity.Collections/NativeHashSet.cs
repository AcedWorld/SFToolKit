using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x02000094 RID: 148
	[DebuggerTypeProxy(typeof(NativeHashSetDebuggerTypeProxy<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct NativeHashSet<[IsUnmanaged] T> : INativeDisposable, IDisposable, IEnumerable<T>, IEnumerable where T : struct, ValueType, IEquatable<T>
	{
		// Token: 0x0600063C RID: 1596 RVA: 0x0001505C File Offset: 0x0001325C
		public NativeHashSet(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this.m_Data = new NativeHashMap<T, bool>(capacity, allocator);
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0001506B File Offset: 0x0001326B
		public bool IsEmpty
		{
			get
			{
				return this.m_Data.IsEmpty;
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00015078 File Offset: 0x00013278
		public int Count()
		{
			return this.m_Data.Count();
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00015085 File Offset: 0x00013285
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x00015092 File Offset: 0x00013292
		public int Capacity
		{
			get
			{
				return this.m_Data.Capacity;
			}
			set
			{
				this.m_Data.Capacity = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x000150A0 File Offset: 0x000132A0
		public bool IsCreated
		{
			get
			{
				return this.m_Data.IsCreated;
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x000150AD File Offset: 0x000132AD
		public void Dispose()
		{
			this.m_Data.Dispose();
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x000150BA File Offset: 0x000132BA
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return this.m_Data.Dispose(inputDeps);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x000150C8 File Offset: 0x000132C8
		public void Clear()
		{
			this.m_Data.Clear();
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x000150D5 File Offset: 0x000132D5
		public bool Add(T item)
		{
			return this.m_Data.TryAdd(item, false);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000150E4 File Offset: 0x000132E4
		public bool Remove(T item)
		{
			return this.m_Data.Remove(item);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000150F2 File Offset: 0x000132F2
		public bool Contains(T item)
		{
			return this.m_Data.ContainsKey(item);
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00015100 File Offset: 0x00013300
		public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_Data.GetKeyArray(allocator);
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00015110 File Offset: 0x00013310
		public NativeHashSet<T>.ParallelWriter AsParallelWriter()
		{
			NativeHashSet<T>.ParallelWriter result;
			result.m_Data = this.m_Data.AsParallelWriter();
			return result;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00015130 File Offset: 0x00013330
		public NativeHashSet<T>.Enumerator GetEnumerator()
		{
			return new NativeHashSet<T>.Enumerator
			{
				m_Enumerator = new UnsafeHashMapDataEnumerator(this.m_Data.m_HashMapData.m_Buffer)
			};
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400026F RID: 623
		internal NativeHashMap<T, bool> m_Data;

		// Token: 0x02000095 RID: 149
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x170000A9 RID: 169
			// (get) Token: 0x0600064D RID: 1613 RVA: 0x00015162 File Offset: 0x00013362
			public int Capacity
			{
				get
				{
					return this.m_Data.Capacity;
				}
			}

			// Token: 0x0600064E RID: 1614 RVA: 0x0001516F File Offset: 0x0001336F
			public bool Add(T item)
			{
				return this.m_Data.TryAdd(item, false);
			}

			// Token: 0x04000270 RID: 624
			internal NativeHashMap<T, bool>.ParallelWriter m_Data;
		}

		// Token: 0x02000096 RID: 150
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x0600064F RID: 1615 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000650 RID: 1616 RVA: 0x0001517E File Offset: 0x0001337E
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000651 RID: 1617 RVA: 0x0001518B File Offset: 0x0001338B
			public void Reset()
			{
				this.m_Enumerator.Reset();
			}

			// Token: 0x170000AA RID: 170
			// (get) Token: 0x06000652 RID: 1618 RVA: 0x00015198 File Offset: 0x00013398
			public T Current
			{
				get
				{
					return this.m_Enumerator.GetCurrentKey<T>();
				}
			}

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x06000653 RID: 1619 RVA: 0x000151A5 File Offset: 0x000133A5
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000271 RID: 625
			internal UnsafeHashMapDataEnumerator m_Enumerator;
		}
	}
}
