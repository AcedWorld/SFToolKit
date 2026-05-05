using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000DE RID: 222
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafePtrListDebugView))]
	[Obsolete("Untyped UnsafePtrList is deprecated, please use UnsafePtrList<T> instead. (RemovedAfter 2021-05-18)", false)]
	public struct UnsafePtrList : INativeDisposable, IDisposable, INativeList<IntPtr>, IIndexable<IntPtr>, IEnumerable<IntPtr>, IEnumerable
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x0001C74E File Offset: 0x0001A94E
		// (set) Token: 0x060008F0 RID: 2288 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Length
		{
			get
			{
				return this.length;
			}
			set
			{
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x0001C756 File Offset: 0x0001A956
		// (set) Token: 0x060008F2 RID: 2290 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return this.capacity;
			}
			set
			{
			}
		}

		// Token: 0x170000EC RID: 236
		public unsafe IntPtr this[int index]
		{
			get
			{
				return new IntPtr(*(IntPtr*)(this.Ptr + (IntPtr)index * (IntPtr)sizeof(void*) / (IntPtr)sizeof(void*)));
			}
			set
			{
				*(IntPtr*)(this.Ptr + (IntPtr)index * (IntPtr)sizeof(void*) / (IntPtr)sizeof(void*)) = (void*)value;
			}
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0001C78F File Offset: 0x0001A98F
		public unsafe ref IntPtr ElementAt(int index)
		{
			return ref *(IntPtr*)(this.Ptr + (IntPtr)index * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(void*));
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0001C7A1 File Offset: 0x0001A9A1
		public unsafe UnsafePtrList(void** ptr, int length)
		{
			this = default(UnsafePtrList);
			this.Ptr = ptr;
			this.length = length;
			this.capacity = length;
			this.Allocator = AllocatorManager.None;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0001C7CC File Offset: 0x0001A9CC
		public unsafe UnsafePtrList(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			this = default(UnsafePtrList);
			this.Ptr = null;
			this.length = 0;
			this.capacity = 0;
			this.Allocator = AllocatorManager.None;
			int size = IntPtr.Size;
			*ref this.ListData() = new UnsafeList(size, size, initialCapacity, allocator, options);
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0001C81C File Offset: 0x0001AA1C
		public unsafe UnsafePtrList(int initialCapacity, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			this = default(UnsafePtrList);
			this.Ptr = null;
			this.length = 0;
			this.capacity = 0;
			this.Allocator = AllocatorManager.None;
			int size = IntPtr.Size;
			*ref this.ListData() = new UnsafeList(size, size, initialCapacity, allocator, options);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0001C86C File Offset: 0x0001AA6C
		public unsafe static UnsafePtrList* Create(void** ptr, int length)
		{
			UnsafePtrList* ptr2 = AllocatorManager.Allocate<UnsafePtrList>(AllocatorManager.Persistent, 1);
			*ptr2 = new UnsafePtrList(ptr, length);
			return ptr2;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0001C886 File Offset: 0x0001AA86
		public unsafe static UnsafePtrList* Create(int initialCapacity, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			UnsafePtrList* ptr = AllocatorManager.Allocate<UnsafePtrList>(allocator, 1);
			*ptr = new UnsafePtrList(initialCapacity, allocator, options);
			return ptr;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0001C8A4 File Offset: 0x0001AAA4
		public unsafe static void Destroy(UnsafePtrList* listData)
		{
			AllocatorManager.AllocatorHandle handle = (ref *listData.ListData().Allocator.Value == AllocatorManager.Invalid.Value) ? AllocatorManager.Persistent : ref *listData.ListData().Allocator;
			listData->Dispose();
			AllocatorManager.Free<UnsafePtrList>(handle, listData, 1);
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0001C8EF File Offset: 0x0001AAEF
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.Length == 0;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0001C904 File Offset: 0x0001AB04
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0001C913 File Offset: 0x0001AB13
		public void Dispose()
		{
			ref this.ListData().Dispose();
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0001C920 File Offset: 0x0001AB20
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return ref this.ListData().Dispose(inputDeps);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0001C92E File Offset: 0x0001AB2E
		public void Clear()
		{
			ref this.ListData().Clear();
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0001C93B File Offset: 0x0001AB3B
		public void Resize(int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			ref this.ListData().Resize<IntPtr>(length, options);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x0001C94A File Offset: 0x0001AB4A
		public void SetCapacity(int capacity)
		{
			ref this.ListData().SetCapacity<IntPtr>(capacity);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0001C958 File Offset: 0x0001AB58
		public void TrimExcess()
		{
			ref this.ListData().TrimExcess<IntPtr>();
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0001C968 File Offset: 0x0001AB68
		public unsafe int IndexOf(void* value)
		{
			for (int i = 0; i < this.Length; i++)
			{
				if (*(IntPtr*)(this.Ptr + (IntPtr)i * (IntPtr)sizeof(void*) / (IntPtr)sizeof(void*)) == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0001C99D File Offset: 0x0001AB9D
		public unsafe bool Contains(void* value)
		{
			return this.IndexOf(value) != -1;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		public unsafe void AddNoResize(void* value)
		{
			ref this.ListData().AddNoResize<IntPtr>((IntPtr)value);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0001C9BF File Offset: 0x0001ABBF
		public unsafe void AddRangeNoResize(void** ptr, int length)
		{
			ref this.ListData().AddRangeNoResize<IntPtr>((void*)ptr, length);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0001C9CE File Offset: 0x0001ABCE
		public unsafe void AddRangeNoResize(UnsafePtrList list)
		{
			ref this.ListData().AddRangeNoResize<IntPtr>((void*)list.Ptr, list.Length);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0001C9E8 File Offset: 0x0001ABE8
		public void Add(in IntPtr value)
		{
			ref this.ListData().Add<IntPtr>(value);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0001C9F7 File Offset: 0x0001ABF7
		public unsafe void Add(void* value)
		{
			ref this.ListData().Add<IntPtr>((IntPtr)value);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0001CA0A File Offset: 0x0001AC0A
		public unsafe void AddRange(void* ptr, int length)
		{
			ref this.ListData().AddRange<IntPtr>(ptr, length);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0001CA19 File Offset: 0x0001AC19
		public unsafe void AddRange(UnsafePtrList list)
		{
			ref this.ListData().AddRange<IntPtr>(*ref list.ListData());
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0001CA32 File Offset: 0x0001AC32
		public void InsertRangeWithBeginEnd(int begin, int end)
		{
			ref this.ListData().InsertRangeWithBeginEnd<IntPtr>(begin, end);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0001CA41 File Offset: 0x0001AC41
		public void RemoveAtSwapBack(int index)
		{
			ref this.ListData().RemoveAtSwapBack<IntPtr>(index);
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0001CA4F File Offset: 0x0001AC4F
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			ref this.ListData().RemoveRangeSwapBackWithBeginEnd<IntPtr>(begin, end);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0001CA5E File Offset: 0x0001AC5E
		public void RemoveAt(int index)
		{
			ref this.ListData().RemoveAt<IntPtr>(index);
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0001CA6C File Offset: 0x0001AC6C
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			ref this.ListData().RemoveRangeWithBeginEnd<IntPtr>(begin, end);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0001CA7B File Offset: 0x0001AC7B
		public UnsafePtrList.ParallelReader AsParallelReader()
		{
			return new UnsafePtrList.ParallelReader(this.Ptr, this.Length);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0001CA8E File Offset: 0x0001AC8E
		public unsafe UnsafePtrList.ParallelWriter AsParallelWriter()
		{
			return new UnsafePtrList.ParallelWriter((void*)this.Ptr, (UnsafeList*)UnsafeUtility.AddressOf<UnsafePtrList>(ref this));
		}

		// Token: 0x0400031B RID: 795
		[NativeDisableUnsafePtrRestriction]
		public unsafe readonly void** Ptr;

		// Token: 0x0400031C RID: 796
		public readonly int length;

		// Token: 0x0400031D RID: 797
		public readonly int unused;

		// Token: 0x0400031E RID: 798
		public readonly int capacity;

		// Token: 0x0400031F RID: 799
		public readonly AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x020000DF RID: 223
		public struct ParallelReader
		{
			// Token: 0x06000916 RID: 2326 RVA: 0x0001CAA1 File Offset: 0x0001ACA1
			internal unsafe ParallelReader(void** ptr, int length)
			{
				this.Ptr = ptr;
				this.Length = length;
			}

			// Token: 0x06000917 RID: 2327 RVA: 0x0001CAB4 File Offset: 0x0001ACB4
			public unsafe int IndexOf(void* value)
			{
				for (int i = 0; i < this.Length; i++)
				{
					if (*(IntPtr*)(this.Ptr + (IntPtr)i * (IntPtr)sizeof(void*) / (IntPtr)sizeof(void*)) == value)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06000918 RID: 2328 RVA: 0x0001CAE9 File Offset: 0x0001ACE9
			public unsafe bool Contains(void* value)
			{
				return this.IndexOf(value) != -1;
			}

			// Token: 0x04000320 RID: 800
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly void** Ptr;

			// Token: 0x04000321 RID: 801
			public readonly int Length;
		}

		// Token: 0x020000E0 RID: 224
		public struct ParallelWriter
		{
			// Token: 0x06000919 RID: 2329 RVA: 0x0001CAF8 File Offset: 0x0001ACF8
			internal unsafe ParallelWriter(void* ptr, UnsafeList* listData)
			{
				this.Ptr = ptr;
				this.ListData = listData;
			}

			// Token: 0x0600091A RID: 2330 RVA: 0x0001CB08 File Offset: 0x0001AD08
			public unsafe void AddNoResize(void* value)
			{
				this.ListData->AddNoResize<IntPtr>((IntPtr)value);
			}

			// Token: 0x0600091B RID: 2331 RVA: 0x0001CB1B File Offset: 0x0001AD1B
			public unsafe void AddRangeNoResize(void** ptr, int length)
			{
				this.ListData->AddRangeNoResize<IntPtr>((void*)ptr, length);
			}

			// Token: 0x0600091C RID: 2332 RVA: 0x0001CB2A File Offset: 0x0001AD2A
			public unsafe void AddRangeNoResize(UnsafePtrList list)
			{
				this.ListData->AddRangeNoResize<IntPtr>((void*)list.Ptr, list.Length);
			}

			// Token: 0x04000322 RID: 802
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly void* Ptr;

			// Token: 0x04000323 RID: 803
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList* ListData;
		}
	}
}
