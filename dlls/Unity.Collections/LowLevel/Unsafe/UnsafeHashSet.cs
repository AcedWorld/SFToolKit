using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000102 RID: 258
	[DebuggerTypeProxy(typeof(UnsafeHashSetDebuggerTypeProxy<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct UnsafeHashSet<[IsUnmanaged] T> : INativeDisposable, IDisposable, IEnumerable<!0>, IEnumerable where T : struct, ValueType, IEquatable<T>
	{
		// Token: 0x060009D8 RID: 2520 RVA: 0x0001F878 File Offset: 0x0001DA78
		public UnsafeHashSet(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this.m_Data = new UnsafeHashMap<T, bool>(capacity, allocator);
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x0001F887 File Offset: 0x0001DA87
		public bool IsEmpty
		{
			get
			{
				return this.m_Data.IsEmpty;
			}
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0001F894 File Offset: 0x0001DA94
		public int Count()
		{
			return this.m_Data.Count();
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x0001F8A1 File Offset: 0x0001DAA1
		// (set) Token: 0x060009DC RID: 2524 RVA: 0x0001F8AE File Offset: 0x0001DAAE
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

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x0001F8BC File Offset: 0x0001DABC
		public bool IsCreated
		{
			get
			{
				return this.m_Data.IsCreated;
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0001F8C9 File Offset: 0x0001DAC9
		public void Dispose()
		{
			this.m_Data.Dispose();
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0001F8D6 File Offset: 0x0001DAD6
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return this.m_Data.Dispose(inputDeps);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0001F8E4 File Offset: 0x0001DAE4
		public void Clear()
		{
			this.m_Data.Clear();
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0001F8F1 File Offset: 0x0001DAF1
		public bool Add(T item)
		{
			return this.m_Data.TryAdd(item, false);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0001F900 File Offset: 0x0001DB00
		public bool Remove(T item)
		{
			return this.m_Data.Remove(item);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0001F90E File Offset: 0x0001DB0E
		public bool Contains(T item)
		{
			return this.m_Data.ContainsKey(item);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0001F91C File Offset: 0x0001DB1C
		public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			return this.m_Data.GetKeyArray(allocator);
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0001F92C File Offset: 0x0001DB2C
		public UnsafeHashSet<T>.ParallelWriter AsParallelWriter()
		{
			return new UnsafeHashSet<T>.ParallelWriter
			{
				m_Data = this.m_Data.AsParallelWriter()
			};
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0001F954 File Offset: 0x0001DB54
		public UnsafeHashSet<T>.Enumerator GetEnumerator()
		{
			return new UnsafeHashSet<T>.Enumerator
			{
				m_Enumerator = new UnsafeHashMapDataEnumerator(this.m_Data.m_Buffer)
			};
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000371 RID: 881
		internal UnsafeHashMap<T, bool> m_Data;

		// Token: 0x02000103 RID: 259
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x17000109 RID: 265
			// (get) Token: 0x060009E9 RID: 2537 RVA: 0x0001F981 File Offset: 0x0001DB81
			public int Capacity
			{
				get
				{
					return this.m_Data.Capacity;
				}
			}

			// Token: 0x060009EA RID: 2538 RVA: 0x0001F98E File Offset: 0x0001DB8E
			public bool Add(T item)
			{
				return this.m_Data.TryAdd(item, false);
			}

			// Token: 0x04000372 RID: 882
			internal UnsafeHashMap<T, bool>.ParallelWriter m_Data;
		}

		// Token: 0x02000104 RID: 260
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x060009EB RID: 2539 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060009EC RID: 2540 RVA: 0x0001F99D File Offset: 0x0001DB9D
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x060009ED RID: 2541 RVA: 0x0001F9AA File Offset: 0x0001DBAA
			public void Reset()
			{
				this.m_Enumerator.Reset();
			}

			// Token: 0x1700010A RID: 266
			// (get) Token: 0x060009EE RID: 2542 RVA: 0x0001F9B7 File Offset: 0x0001DBB7
			public T Current
			{
				get
				{
					return this.m_Enumerator.GetCurrentKey<T>();
				}
			}

			// Token: 0x1700010B RID: 267
			// (get) Token: 0x060009EF RID: 2543 RVA: 0x0001F9C4 File Offset: 0x0001DBC4
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000373 RID: 883
			internal UnsafeHashMapDataEnumerator m_Enumerator;
		}
	}
}
