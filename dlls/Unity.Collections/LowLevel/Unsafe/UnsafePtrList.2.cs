using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200010F RID: 271
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafePtrListTDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct UnsafePtrList<[IsUnmanaged] T> : INativeDisposable, IDisposable, IEnumerable<IntPtr>, IEnumerable where T : struct, ValueType
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x00021446 File Offset: 0x0001F646
		// (set) Token: 0x06000A5D RID: 2653 RVA: 0x00021453 File Offset: 0x0001F653
		public int Length
		{
			get
			{
				return ref this.ListData<T>().Length;
			}
			set
			{
				ref this.ListData<T>().Length = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x00021461 File Offset: 0x0001F661
		// (set) Token: 0x06000A5F RID: 2655 RVA: 0x0002146E File Offset: 0x0001F66E
		public int Capacity
		{
			get
			{
				return ref this.ListData<T>().Capacity;
			}
			set
			{
				ref this.ListData<T>().Capacity = value;
			}
		}

		// Token: 0x17000118 RID: 280
		public unsafe T* this[int index]
		{
			get
			{
				return *(IntPtr*)(this.Ptr + (IntPtr)CollectionHelper.AssumePositive(index) * (IntPtr)sizeof(T*) / (IntPtr)sizeof(T*));
			}
			set
			{
				*(IntPtr*)(this.Ptr + (IntPtr)CollectionHelper.AssumePositive(index) * (IntPtr)sizeof(T*) / (IntPtr)sizeof(T*)) = value;
			}
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x000214AD File Offset: 0x0001F6AD
		public unsafe ref T* ElementAt(int index)
		{
			return ref this.Ptr[(IntPtr)CollectionHelper.AssumePositive(index) * (IntPtr)sizeof(T*) / (IntPtr)sizeof(T*)];
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x000214C4 File Offset: 0x0001F6C4
		public unsafe UnsafePtrList(T** ptr, int length)
		{
			this = default(UnsafePtrList<T>);
			this.Ptr = ptr;
			this.m_length = length;
			this.m_capacity = length;
			this.Allocator = AllocatorManager.None;
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x000214ED File Offset: 0x0001F6ED
		public unsafe UnsafePtrList(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			this = default(UnsafePtrList<T>);
			this.Ptr = null;
			this.m_length = 0;
			this.m_capacity = 0;
			this.Allocator = AllocatorManager.None;
			*ref this.ListData<T>() = new UnsafeList<IntPtr>(initialCapacity, allocator, options);
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0002152A File Offset: 0x0001F72A
		public unsafe static UnsafePtrList<T>* Create(T** ptr, int length)
		{
			UnsafePtrList<T>* ptr2 = AllocatorManager.Allocate<UnsafePtrList<T>>(AllocatorManager.Persistent, 1);
			*ptr2 = new UnsafePtrList<T>(ptr, length);
			return ptr2;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x00021544 File Offset: 0x0001F744
		public unsafe static UnsafePtrList<T>* Create(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			UnsafePtrList<T>* ptr = AllocatorManager.Allocate<UnsafePtrList<T>>(allocator, 1);
			*ptr = new UnsafePtrList<T>(initialCapacity, allocator, options);
			return ptr;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0002155C File Offset: 0x0001F75C
		public unsafe static void Destroy(UnsafePtrList<T>* listData)
		{
			AllocatorManager.AllocatorHandle handle = (ref *listData.ListData<T>().Allocator.Value == AllocatorManager.Invalid.Value) ? AllocatorManager.Persistent : ref *listData.ListData<T>().Allocator;
			listData->Dispose();
			AllocatorManager.Free<UnsafePtrList<T>>(handle, listData, 1);
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x000215A7 File Offset: 0x0001F7A7
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.Length == 0;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x000215BC File Offset: 0x0001F7BC
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x000215CB File Offset: 0x0001F7CB
		public void Dispose()
		{
			ref this.ListData<T>().Dispose();
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x000215D8 File Offset: 0x0001F7D8
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return ref this.ListData<T>().Dispose(inputDeps);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x000215E6 File Offset: 0x0001F7E6
		public void Clear()
		{
			ref this.ListData<T>().Clear();
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x000215F3 File Offset: 0x0001F7F3
		public void Resize(int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			ref this.ListData<T>().Resize(length, options);
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00021602 File Offset: 0x0001F802
		public void SetCapacity(int capacity)
		{
			ref this.ListData<T>().SetCapacity(capacity);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00021610 File Offset: 0x0001F810
		public void TrimExcess()
		{
			ref this.ListData<T>().TrimExcess();
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00021620 File Offset: 0x0001F820
		public unsafe int IndexOf(void* ptr)
		{
			for (int i = 0; i < this.Length; i++)
			{
				if (*(IntPtr*)(this.Ptr + (IntPtr)i * (IntPtr)sizeof(T*) / (IntPtr)sizeof(T*)) == ptr)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00021655 File Offset: 0x0001F855
		public unsafe bool Contains(void* ptr)
		{
			return this.IndexOf(ptr) != -1;
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00021664 File Offset: 0x0001F864
		public unsafe void AddNoResize(void* value)
		{
			ref this.ListData<T>().AddNoResize((IntPtr)value);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00021677 File Offset: 0x0001F877
		public unsafe void AddRangeNoResize(void** ptr, int count)
		{
			ref this.ListData<T>().AddRangeNoResize((void*)ptr, count);
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00021686 File Offset: 0x0001F886
		public unsafe void AddRangeNoResize(UnsafePtrList<T> list)
		{
			ref this.ListData<T>().AddRangeNoResize((void*)list.Ptr, list.Length);
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x000216A0 File Offset: 0x0001F8A0
		public void Add(in IntPtr value)
		{
			ref this.ListData<T>().Add(value);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x000216B0 File Offset: 0x0001F8B0
		public unsafe void Add(void* value)
		{
			ref UnsafeList<IntPtr> ptr = ref ref this.ListData<T>();
			IntPtr intPtr = (IntPtr)value;
			ptr.Add(intPtr);
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000216D1 File Offset: 0x0001F8D1
		public unsafe void AddRange(void* ptr, int length)
		{
			ref this.ListData<T>().AddRange(ptr, length);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000216E0 File Offset: 0x0001F8E0
		public unsafe void AddRange(UnsafePtrList<T> list)
		{
			ref this.ListData<T>().AddRange(*ref list.ListData<T>());
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x000216F9 File Offset: 0x0001F8F9
		public void InsertRangeWithBeginEnd(int begin, int end)
		{
			ref this.ListData<T>().InsertRangeWithBeginEnd(begin, end);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00021708 File Offset: 0x0001F908
		public void RemoveAtSwapBack(int index)
		{
			ref this.ListData<T>().RemoveAtSwapBack(index);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00021716 File Offset: 0x0001F916
		public void RemoveRangeSwapBack(int index, int count)
		{
			ref this.ListData<T>().RemoveRangeSwapBack(index, count);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00021725 File Offset: 0x0001F925
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			ref this.ListData<T>().RemoveRangeSwapBackWithBeginEnd(begin, end);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x00021734 File Offset: 0x0001F934
		public void RemoveAt(int index)
		{
			ref this.ListData<T>().RemoveAt(index);
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00021742 File Offset: 0x0001F942
		public void RemoveRange(int index, int count)
		{
			ref this.ListData<T>().RemoveRange(index, count);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00021751 File Offset: 0x0001F951
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			ref this.ListData<T>().RemoveRangeWithBeginEnd(begin, end);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00021760 File Offset: 0x0001F960
		public UnsafePtrList<T>.ParallelReader AsParallelReader()
		{
			return new UnsafePtrList<T>.ParallelReader(this.Ptr, this.Length);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00021773 File Offset: 0x0001F973
		public unsafe UnsafePtrList<T>.ParallelWriter AsParallelWriter()
		{
			return new UnsafePtrList<T>.ParallelWriter(this.Ptr, (UnsafeList<IntPtr>*)UnsafeUtility.AddressOf<UnsafePtrList<T>>(ref this));
		}

		// Token: 0x0400038A RID: 906
		[NativeDisableUnsafePtrRestriction]
		public unsafe readonly T** Ptr;

		// Token: 0x0400038B RID: 907
		public readonly int m_length;

		// Token: 0x0400038C RID: 908
		public readonly int m_capacity;

		// Token: 0x0400038D RID: 909
		public readonly AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x0400038E RID: 910
		[Obsolete("Use Length property (UnityUpgradable) -> Length", true)]
		public int length;

		// Token: 0x0400038F RID: 911
		[Obsolete("Use Capacity property (UnityUpgradable) -> Capacity", true)]
		public int capacity;

		// Token: 0x02000110 RID: 272
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelReader
		{
			// Token: 0x06000A84 RID: 2692 RVA: 0x00021786 File Offset: 0x0001F986
			internal unsafe ParallelReader(T** ptr, int length)
			{
				this.Ptr = ptr;
				this.Length = length;
			}

			// Token: 0x06000A85 RID: 2693 RVA: 0x00021798 File Offset: 0x0001F998
			public unsafe int IndexOf(void* ptr)
			{
				for (int i = 0; i < this.Length; i++)
				{
					if (*(IntPtr*)(this.Ptr + (IntPtr)i * (IntPtr)sizeof(T*) / (IntPtr)sizeof(T*)) == ptr)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06000A86 RID: 2694 RVA: 0x000217CD File Offset: 0x0001F9CD
			public unsafe bool Contains(void* ptr)
			{
				return this.IndexOf(ptr) != -1;
			}

			// Token: 0x04000390 RID: 912
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly T** Ptr;

			// Token: 0x04000391 RID: 913
			public readonly int Length;
		}

		// Token: 0x02000111 RID: 273
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x06000A87 RID: 2695 RVA: 0x000217DC File Offset: 0x0001F9DC
			internal unsafe ParallelWriter(T** ptr, UnsafeList<IntPtr>* listData)
			{
				this.Ptr = ptr;
				this.ListData = listData;
			}

			// Token: 0x06000A88 RID: 2696 RVA: 0x000217EC File Offset: 0x0001F9EC
			public unsafe void AddNoResize(T* value)
			{
				this.ListData->AddNoResize((IntPtr)((void*)value));
			}

			// Token: 0x06000A89 RID: 2697 RVA: 0x000217FF File Offset: 0x0001F9FF
			public unsafe void AddRangeNoResize(T** ptr, int count)
			{
				this.ListData->AddRangeNoResize((void*)ptr, count);
			}

			// Token: 0x06000A8A RID: 2698 RVA: 0x0002180E File Offset: 0x0001FA0E
			public unsafe void AddRangeNoResize(UnsafePtrList<T> list)
			{
				this.ListData->AddRangeNoResize((void*)list.Ptr, list.Length);
			}

			// Token: 0x04000392 RID: 914
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly T** Ptr;

			// Token: 0x04000393 RID: 915
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList<IntPtr>* ListData;
		}
	}
}
