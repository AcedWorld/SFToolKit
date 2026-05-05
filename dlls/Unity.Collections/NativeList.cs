using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Collections.NotBurstCompatible;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x0200009B RID: 155
	[NativeContainer]
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(NativeListDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct NativeList<[IsUnmanaged] T> : INativeDisposable, IDisposable, INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable where T : struct, ValueType
	{
		// Token: 0x06000677 RID: 1655 RVA: 0x00015BAC File Offset: 0x00013DAC
		public NativeList(AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeList<T>(1, allocator, 2);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00015BB7 File Offset: 0x00013DB7
		public NativeList(int initialCapacity, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeList<T>(initialCapacity, allocator, 2);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00015BC2 File Offset: 0x00013DC2
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal void Initialize<[IsUnmanaged] U>(int initialCapacity, ref U allocator, int disposeSentinelStackDepth) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			this.m_ListData = UnsafeList<T>.Create<U>(initialCapacity, ref allocator, NativeArrayOptions.UninitializedMemory);
			this.m_DeprecatedAllocator = allocator.Handle;
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00015BE4 File Offset: 0x00013DE4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal static NativeList<T> New<[IsUnmanaged] U>(int initialCapacity, ref U allocator, int disposeSentinelStackDepth) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			NativeList<T> result = default(NativeList<T>);
			result.Initialize<U>(initialCapacity, ref allocator, disposeSentinelStackDepth);
			return result;
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00015C04 File Offset: 0x00013E04
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal static NativeList<T> New<[IsUnmanaged] U>(int initialCapacity, ref U allocator) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			return NativeList<T>.New<U>(initialCapacity, ref allocator, 2);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00015C10 File Offset: 0x00013E10
		private NativeList(int initialCapacity, AllocatorManager.AllocatorHandle allocator, int disposeSentinelStackDepth)
		{
			this = default(NativeList<T>);
			AllocatorManager.AllocatorHandle allocatorHandle = allocator;
			this.Initialize<AllocatorManager.AllocatorHandle>(initialCapacity, ref allocatorHandle, disposeSentinelStackDepth);
		}

		// Token: 0x170000B1 RID: 177
		public unsafe T this[int index]
		{
			get
			{
				return (*this.m_ListData)[index];
			}
			set
			{
				(*this.m_ListData)[index] = value;
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00015C4D File Offset: 0x00013E4D
		public unsafe ref T ElementAt(int index)
		{
			return this.m_ListData->ElementAt(index);
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x00015C5B File Offset: 0x00013E5B
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x00015C6D File Offset: 0x00013E6D
		public unsafe int Length
		{
			get
			{
				return CollectionHelper.AssumePositive(this.m_ListData->Length);
			}
			set
			{
				this.m_ListData->Resize(value, NativeArrayOptions.ClearMemory);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x00015C7C File Offset: 0x00013E7C
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x00015C89 File Offset: 0x00013E89
		public unsafe int Capacity
		{
			get
			{
				return this.m_ListData->Capacity;
			}
			set
			{
				this.m_ListData->Capacity = value;
			}
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00015C97 File Offset: 0x00013E97
		public unsafe UnsafeList<T>* GetUnsafeList()
		{
			return this.m_ListData;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00015C9F File Offset: 0x00013E9F
		public unsafe void AddNoResize(T value)
		{
			this.m_ListData->AddNoResize(value);
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00015CAD File Offset: 0x00013EAD
		public unsafe void AddRangeNoResize(void* ptr, int count)
		{
			this.m_ListData->AddRangeNoResize(ptr, count);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00015CBC File Offset: 0x00013EBC
		public unsafe void AddRangeNoResize(NativeList<T> list)
		{
			this.m_ListData->AddRangeNoResize(*list.m_ListData);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00015CD4 File Offset: 0x00013ED4
		public unsafe void Add(in T value)
		{
			this.m_ListData->Add(value);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00015CE2 File Offset: 0x00013EE2
		public void AddRange(NativeArray<T> array)
		{
			this.AddRange(array.GetUnsafeReadOnlyPtr<T>(), array.Length);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00015CF7 File Offset: 0x00013EF7
		public unsafe void AddRange(void* ptr, int count)
		{
			this.m_ListData->AddRange(ptr, CollectionHelper.AssumePositive(count));
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00015D0B File Offset: 0x00013F0B
		public unsafe void InsertRangeWithBeginEnd(int begin, int end)
		{
			this.m_ListData->InsertRangeWithBeginEnd(CollectionHelper.AssumePositive(begin), CollectionHelper.AssumePositive(end));
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00015D24 File Offset: 0x00013F24
		public unsafe void RemoveAtSwapBack(int index)
		{
			this.m_ListData->RemoveAtSwapBack(CollectionHelper.AssumePositive(index));
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00015D37 File Offset: 0x00013F37
		public unsafe void RemoveRangeSwapBack(int index, int count)
		{
			this.m_ListData->RemoveRangeSwapBack(CollectionHelper.AssumePositive(index), CollectionHelper.AssumePositive(count));
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00015D50 File Offset: 0x00013F50
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public unsafe void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.m_ListData->RemoveRangeSwapBackWithBeginEnd(CollectionHelper.AssumePositive(begin), CollectionHelper.AssumePositive(end));
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00015D69 File Offset: 0x00013F69
		public unsafe void RemoveAt(int index)
		{
			this.m_ListData->RemoveAt(CollectionHelper.AssumePositive(index));
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00015D7C File Offset: 0x00013F7C
		public unsafe void RemoveRange(int index, int count)
		{
			this.m_ListData->RemoveRange(index, count);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00015D8B File Offset: 0x00013F8B
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public unsafe void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.m_ListData->RemoveRangeWithBeginEnd(begin, end);
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00015D9A File Offset: 0x00013F9A
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.Length == 0;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x00015DAF File Offset: 0x00013FAF
		public bool IsCreated
		{
			get
			{
				return this.m_ListData != null;
			}
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00015DBE File Offset: 0x00013FBE
		public void Dispose()
		{
			UnsafeList<T>.Destroy(this.m_ListData);
			this.m_ListData = null;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00015DD3 File Offset: 0x00013FD3
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal void Dispose<[IsUnmanaged] U>(ref U allocator) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			UnsafeList<T>.Destroy<U>(this.m_ListData, ref allocator);
			this.m_ListData = null;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00015DEC File Offset: 0x00013FEC
		[NotBurstCompatible]
		public unsafe JobHandle Dispose(JobHandle inputDeps)
		{
			JobHandle result = new NativeListDisposeJob
			{
				Data = new NativeListDispose
				{
					m_ListData = (UntypedUnsafeList*)this.m_ListData
				}
			}.Schedule(inputDeps);
			this.m_ListData = null;
			return result;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00015E2D File Offset: 0x0001402D
		public unsafe void Clear()
		{
			this.m_ListData->Clear();
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00015E3A File Offset: 0x0001403A
		public static implicit operator NativeArray<T>(NativeList<T> nativeList)
		{
			return nativeList.AsArray();
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00015E43 File Offset: 0x00014043
		public unsafe NativeArray<T> AsArray()
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)this.m_ListData->Ptr, this.m_ListData->Length, Allocator.None);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00015E64 File Offset: 0x00014064
		public unsafe NativeArray<T> AsDeferredJobArray()
		{
			byte* ptr = (byte*)this.m_ListData;
			ptr++;
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)ptr, 0, Allocator.Invalid);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00015E84 File Offset: 0x00014084
		[NotBurstCompatible]
		public T[] ToArray()
		{
			return this.ToArrayNBC<T>();
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00015E94 File Offset: 0x00014094
		public NativeArray<T> ToArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> result = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			result.CopyFrom(this);
			return result;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00015EC4 File Offset: 0x000140C4
		public NativeArray<T>.Enumerator GetEnumerator()
		{
			NativeArray<T> nativeArray = this.AsArray();
			return new NativeArray<T>.Enumerator(ref nativeArray);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00015EDF File Offset: 0x000140DF
		[NotBurstCompatible]
		[Obsolete("Please use `CopyFromNBC` from `Unity.Collections.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", false)]
		public void CopyFrom(T[] array)
		{
			this.CopyFromNBC(array);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00015EF0 File Offset: 0x000140F0
		public void CopyFrom(NativeArray<T> array)
		{
			this.Clear();
			this.Resize(array.Length, NativeArrayOptions.UninitializedMemory);
			this.AsArray().CopyFrom(array);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00015F20 File Offset: 0x00014120
		public unsafe void Resize(int length, NativeArrayOptions options)
		{
			this.m_ListData->Resize(length, options);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00015F2F File Offset: 0x0001412F
		public void ResizeUninitialized(int length)
		{
			this.Resize(length, NativeArrayOptions.UninitializedMemory);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00015F39 File Offset: 0x00014139
		public unsafe void SetCapacity(int capacity)
		{
			this.m_ListData->SetCapacity(capacity);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00015F47 File Offset: 0x00014147
		public unsafe void TrimExcess()
		{
			this.m_ListData->TrimExcess();
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00015F54 File Offset: 0x00014154
		public unsafe NativeArray<T>.ReadOnly AsParallelReader()
		{
			return new NativeArray<T>.ReadOnly((void*)this.m_ListData->Ptr, this.m_ListData->Length);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00015F71 File Offset: 0x00014171
		public NativeList<T>.ParallelWriter AsParallelWriter()
		{
			return new NativeList<T>.ParallelWriter(this.m_ListData);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00015F7E File Offset: 0x0001417E
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckInitialCapacity(int initialCapacity)
		{
			if (initialCapacity < 0)
			{
				throw new ArgumentOutOfRangeException("initialCapacity", "Capacity must be >= 0");
			}
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00015F94 File Offset: 0x00014194
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckTotalSize(int initialCapacity, long totalSize)
		{
			if (totalSize > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("initialCapacity", string.Format("Capacity * sizeof(T) cannot exceed {0} bytes", int.MaxValue));
			}
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00015FBE File Offset: 0x000141BE
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckSufficientCapacity(int capacity, int length)
		{
			if (capacity < length)
			{
				throw new Exception(string.Format("Length {0} exceeds capacity Capacity {1}", length, capacity));
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00015FE0 File Offset: 0x000141E0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckIndexInRange(int value, int length)
		{
			if (value < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Value {0} must be positive.", value));
			}
			if (value >= length)
			{
				throw new IndexOutOfRangeException(string.Format("Value {0} is out of range in NativeList of '{1}' Length.", value, length));
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001601C File Offset: 0x0001421C
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckArgPositive(int value)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value {0} must be positive.", value));
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00016038 File Offset: 0x00014238
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private unsafe void CheckHandleMatches(AllocatorManager.AllocatorHandle handle)
		{
			if (this.m_ListData == null)
			{
				throw new ArgumentOutOfRangeException(string.Format("Allocator handle {0} can't match because container is not initialized.", handle));
			}
			if (this.m_ListData->Allocator.Index != handle.Index)
			{
				throw new ArgumentOutOfRangeException(string.Format("Allocator handle {0} can't match because container handle index doesn't match.", handle));
			}
			if (this.m_ListData->Allocator.Version != handle.Version)
			{
				throw new ArgumentOutOfRangeException(string.Format("Allocator handle {0} matches container handle index, but has different version.", handle));
			}
		}

		// Token: 0x04000273 RID: 627
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeList<T>* m_ListData;

		// Token: 0x04000274 RID: 628
		internal AllocatorManager.AllocatorHandle m_DeprecatedAllocator;

		// Token: 0x0200009C RID: 156
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x170000B6 RID: 182
			// (get) Token: 0x060006AE RID: 1710 RVA: 0x000160C1 File Offset: 0x000142C1
			public unsafe readonly void* Ptr
			{
				get
				{
					return (void*)this.ListData->Ptr;
				}
			}

			// Token: 0x060006AF RID: 1711 RVA: 0x000160CE File Offset: 0x000142CE
			internal unsafe ParallelWriter(UnsafeList<T>* listData)
			{
				this.ListData = listData;
			}

			// Token: 0x060006B0 RID: 1712 RVA: 0x000160D8 File Offset: 0x000142D8
			public unsafe void AddNoResize(T value)
			{
				int index = Interlocked.Increment(ref this.ListData->m_length) - 1;
				UnsafeUtility.WriteArrayElement<T>((void*)this.ListData->Ptr, index, value);
			}

			// Token: 0x060006B1 RID: 1713 RVA: 0x0001610C File Offset: 0x0001430C
			public unsafe void AddRangeNoResize(void* ptr, int count)
			{
				int num = Interlocked.Add(ref this.ListData->m_length, count) - count;
				int num2 = sizeof(T);
				void* destination = (void*)(this.ListData->Ptr + num * num2 / sizeof(T));
				UnsafeUtility.MemCpy(destination, ptr, (long)(count * num2));
			}

			// Token: 0x060006B2 RID: 1714 RVA: 0x0001614F File Offset: 0x0001434F
			public unsafe void AddRangeNoResize(UnsafeList<T> list)
			{
				this.AddRangeNoResize((void*)list.Ptr, list.Length);
			}

			// Token: 0x060006B3 RID: 1715 RVA: 0x00016164 File Offset: 0x00014364
			public unsafe void AddRangeNoResize(NativeList<T> list)
			{
				this.AddRangeNoResize(*list.m_ListData);
			}

			// Token: 0x04000275 RID: 629
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList<T>* ListData;
		}
	}
}
