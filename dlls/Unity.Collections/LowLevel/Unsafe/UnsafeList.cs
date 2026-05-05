using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000DA RID: 218
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[Obsolete("Untyped UnsafeList is deprecated, please use UnsafeList<T> instead. (RemovedAfter 2021-05-18)", false)]
	public struct UnsafeList : INativeDisposable, IDisposable
	{
		// Token: 0x060008AC RID: 2220 RVA: 0x0001BC7D File Offset: 0x00019E7D
		public UnsafeList(Allocator allocator)
		{
			this = default(UnsafeList);
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
			this.Allocator = allocator;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		public unsafe UnsafeList(void* ptr, int length)
		{
			this = default(UnsafeList);
			this.Ptr = ptr;
			this.Length = length;
			this.Capacity = length;
			this.Allocator = Unity.Collections.Allocator.None;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0001BCD4 File Offset: 0x00019ED4
		internal void Initialize<[IsUnmanaged] U>(int sizeOf, int alignOf, int initialCapacity, ref U allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			this.Allocator = allocator.Handle;
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
			if (initialCapacity != 0)
			{
				this.SetCapacity<U>(ref allocator, sizeOf, alignOf, initialCapacity);
			}
			if (options == NativeArrayOptions.ClearMemory && this.Ptr != null)
			{
				UnsafeUtility.MemClear(this.Ptr, (long)(this.Capacity * sizeOf));
			}
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0001BD3C File Offset: 0x00019F3C
		internal static UnsafeList New<[IsUnmanaged] U>(int sizeOf, int alignOf, int initialCapacity, ref U allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			UnsafeList result = default(UnsafeList);
			result.Initialize<U>(sizeOf, alignOf, initialCapacity, ref allocator, options);
			return result;
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0001BD5F File Offset: 0x00019F5F
		public UnsafeList(int sizeOf, int alignOf, int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			this = default(UnsafeList);
			this = default(UnsafeList);
			this.Initialize<AllocatorManager.AllocatorHandle>(sizeOf, alignOf, initialCapacity, ref allocator, options);
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0001BD7C File Offset: 0x00019F7C
		public UnsafeList(int sizeOf, int alignOf, int initialCapacity, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			this = default(UnsafeList);
			this.Allocator = allocator;
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
			if (initialCapacity != 0)
			{
				this.SetCapacity(sizeOf, alignOf, initialCapacity);
			}
			if (options == NativeArrayOptions.ClearMemory && this.Ptr != null)
			{
				UnsafeUtility.MemClear(this.Ptr, (long)(this.Capacity * sizeOf));
			}
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0001BDE4 File Offset: 0x00019FE4
		public unsafe static UnsafeList* Create(int sizeOf, int alignOf, int initialCapacity, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			UnsafeList* ptr = AllocatorManager.Allocate<UnsafeList>(allocator, 1);
			UnsafeUtility.MemClear((void*)ptr, (long)UnsafeUtility.SizeOf<UnsafeList>());
			ptr->Allocator = allocator;
			if (initialCapacity != 0)
			{
				ptr->SetCapacity(sizeOf, alignOf, initialCapacity);
			}
			if (options == NativeArrayOptions.ClearMemory && ptr->Ptr != null)
			{
				UnsafeUtility.MemClear(ptr->Ptr, (long)(ptr->Capacity * sizeOf));
			}
			return ptr;
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0001BE48 File Offset: 0x0001A048
		internal unsafe static UnsafeList* Create<[IsUnmanaged] U>(int sizeOf, int alignOf, int initialCapacity, ref U allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			UnsafeList* ptr = ref allocator.Allocate(default(UnsafeList), 1);
			UnsafeUtility.MemClear((void*)ptr, (long)UnsafeUtility.SizeOf<UnsafeList>());
			ptr->Allocator = allocator.Handle;
			if (initialCapacity != 0)
			{
				ptr->SetCapacity<U>(ref allocator, sizeOf, alignOf, initialCapacity);
			}
			if (options == NativeArrayOptions.ClearMemory && ptr->Ptr != null)
			{
				UnsafeUtility.MemClear(ptr->Ptr, (long)(ptr->Capacity * sizeOf));
			}
			return ptr;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x0001BEB5 File Offset: 0x0001A0B5
		internal unsafe static void Destroy<[IsUnmanaged] U>(UnsafeList* listData, ref U allocator, int sizeOf, int alignOf) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			listData->Dispose<U>(ref allocator, sizeOf, alignOf);
			ref allocator.Free((void*)listData, UnsafeUtility.SizeOf<UnsafeList>(), UnsafeUtility.AlignOf<UnsafeList>(), 1);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0001BED2 File Offset: 0x0001A0D2
		public unsafe static void Destroy(UnsafeList* listData)
		{
			AllocatorManager.AllocatorHandle allocator = listData->Allocator;
			listData->Dispose();
			AllocatorManager.Free<UnsafeList>(allocator, listData, 1);
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0001BEE7 File Offset: 0x0001A0E7
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.Length == 0;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0001BEFC File Offset: 0x0001A0FC
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0001BF0C File Offset: 0x0001A10C
		public void Dispose()
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				AllocatorManager.Free(this.Allocator, this.Ptr);
				this.Allocator = AllocatorManager.Invalid;
			}
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0001BF58 File Offset: 0x0001A158
		internal void Dispose<[IsUnmanaged] U>(ref U allocator, int sizeOf, int alignOf) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			ref allocator.Free(this.Ptr, sizeOf, alignOf, this.Length);
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0001BF84 File Offset: 0x0001A184
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				JobHandle result = new UnsafeDisposeJob
				{
					Ptr = this.Ptr,
					Allocator = (Allocator)this.Allocator.Value
				}.Schedule(inputDeps);
				this.Ptr = null;
				this.Allocator = AllocatorManager.Invalid;
				return result;
			}
			this.Ptr = null;
			return inputDeps;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0001BFEE File Offset: 0x0001A1EE
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0001BFF8 File Offset: 0x0001A1F8
		public unsafe void Resize(int sizeOf, int alignOf, int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			int length2 = this.Length;
			if (length > this.Capacity)
			{
				this.SetCapacity(sizeOf, alignOf, length);
			}
			this.Length = length;
			if (options == NativeArrayOptions.ClearMemory && length2 < length)
			{
				int num = length - length2;
				byte* ptr = (byte*)this.Ptr;
				UnsafeUtility.MemClear((void*)(ptr + length2 * sizeOf), (long)(num * sizeOf));
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0001C047 File Offset: 0x0001A247
		public void Resize<T>(int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where T : struct
		{
			this.Resize(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), length, options);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0001C05C File Offset: 0x0001A25C
		private unsafe void Realloc<[IsUnmanaged] U>(ref U allocator, int sizeOf, int alignOf, int capacity) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			void* ptr = null;
			if (capacity > 0)
			{
				ptr = ref allocator.Allocate(sizeOf, alignOf, capacity);
				if (this.Capacity > 0)
				{
					int num = math.min(capacity, this.Capacity) * sizeOf;
					UnsafeUtility.MemCpy(ptr, this.Ptr, (long)num);
				}
			}
			ref allocator.Free(this.Ptr, sizeOf, alignOf, this.Capacity);
			this.Ptr = ptr;
			this.Capacity = capacity;
			this.Length = math.min(this.Length, capacity);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0001C0D9 File Offset: 0x0001A2D9
		private void Realloc(int sizeOf, int alignOf, int capacity)
		{
			this.Realloc<AllocatorManager.AllocatorHandle>(ref this.Allocator, sizeOf, alignOf, capacity);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0001C0EC File Offset: 0x0001A2EC
		private void SetCapacity<[IsUnmanaged] U>(ref U allocator, int sizeOf, int alignOf, int capacity) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			int num = math.max(capacity, 64 / sizeOf);
			num = math.ceilpow2(num);
			if (num == this.Capacity)
			{
				return;
			}
			this.Realloc<U>(ref allocator, sizeOf, alignOf, num);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0001C120 File Offset: 0x0001A320
		private void SetCapacity(int sizeOf, int alignOf, int capacity)
		{
			this.SetCapacity<AllocatorManager.AllocatorHandle>(ref this.Allocator, sizeOf, alignOf, capacity);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0001C131 File Offset: 0x0001A331
		public void SetCapacity<T>(int capacity) where T : struct
		{
			this.SetCapacity(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), capacity);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0001C144 File Offset: 0x0001A344
		public void TrimExcess<T>() where T : struct
		{
			if (this.Capacity != this.Length)
			{
				this.Realloc(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), this.Length);
			}
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0001C16A File Offset: 0x0001A36A
		public int IndexOf<T>(T value) where T : struct, IEquatable<T>
		{
			return NativeArrayExtensions.IndexOf<T, T>(this.Ptr, this.Length, value);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0001C17E File Offset: 0x0001A37E
		public bool Contains<T>(T value) where T : struct, IEquatable<T>
		{
			return this.IndexOf<T>(value) != -1;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0001C18D File Offset: 0x0001A38D
		public void AddNoResize<T>(T value) where T : struct
		{
			UnsafeUtility.WriteArrayElement<T>(this.Ptr, this.Length, value);
			this.Length++;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0001C1B0 File Offset: 0x0001A3B0
		private unsafe void AddRangeNoResize(int sizeOf, void* ptr, int length)
		{
			void* destination = (void*)((byte*)this.Ptr + this.Length * sizeOf);
			UnsafeUtility.MemCpy(destination, ptr, (long)(length * sizeOf));
			this.Length += length;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0001C1E6 File Offset: 0x0001A3E6
		public unsafe void AddRangeNoResize<T>(void* ptr, int length) where T : struct
		{
			this.AddRangeNoResize(UnsafeUtility.SizeOf<T>(), ptr, length);
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0001C1F5 File Offset: 0x0001A3F5
		public void AddRangeNoResize<T>(UnsafeList list) where T : struct
		{
			this.AddRangeNoResize(UnsafeUtility.SizeOf<T>(), list.Ptr, CollectionHelper.AssumePositive(list.Length));
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0001C214 File Offset: 0x0001A414
		public void Add<T>(T value) where T : struct
		{
			int length = this.Length;
			if (this.Length + 1 > this.Capacity)
			{
				this.Resize<T>(length + 1, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				this.Length++;
			}
			UnsafeUtility.WriteArrayElement<T>(this.Ptr, length, value);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001C260 File Offset: 0x0001A460
		private unsafe void AddRange(int sizeOf, int alignOf, void* ptr, int length)
		{
			int length2 = this.Length;
			if (this.Length + length > this.Capacity)
			{
				this.Resize(sizeOf, alignOf, this.Length + length, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				this.Length += length;
			}
			void* destination = (void*)((byte*)this.Ptr + length2 * sizeOf);
			UnsafeUtility.MemCpy(destination, ptr, (long)(length * sizeOf));
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0001C2BF File Offset: 0x0001A4BF
		public unsafe void AddRange<T>(void* ptr, int length) where T : struct
		{
			this.AddRange(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), ptr, length);
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0001C2D3 File Offset: 0x0001A4D3
		public void AddRange<T>(UnsafeList list) where T : struct
		{
			this.AddRange(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), list.Ptr, list.Length);
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0001C2F4 File Offset: 0x0001A4F4
		private unsafe void InsertRangeWithBeginEnd(int sizeOf, int alignOf, int begin, int end)
		{
			int num = end - begin;
			if (num < 1)
			{
				return;
			}
			int length = this.Length;
			if (this.Length + num > this.Capacity)
			{
				this.Resize(sizeOf, alignOf, this.Length + num, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				this.Length += num;
			}
			int num2 = length - begin;
			if (num2 < 1)
			{
				return;
			}
			int num3 = num2 * sizeOf;
			byte* ptr = (byte*)this.Ptr;
			void* destination = (void*)(ptr + end * sizeOf);
			byte* source = ptr + begin * sizeOf;
			UnsafeUtility.MemMove(destination, (void*)source, (long)num3);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0001C36B File Offset: 0x0001A56B
		public void InsertRangeWithBeginEnd<T>(int begin, int end) where T : struct
		{
			this.InsertRangeWithBeginEnd(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), begin, end);
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0001C380 File Offset: 0x0001A580
		private unsafe void RemoveRangeSwapBackWithBeginEnd(int sizeOf, int begin, int end)
		{
			int num = end - begin;
			if (num > 0)
			{
				int num2 = math.max(this.Length - num, end);
				void* destination = (void*)((byte*)this.Ptr + begin * sizeOf);
				void* source = (void*)((byte*)this.Ptr + num2 * sizeOf);
				UnsafeUtility.MemCpy(destination, source, (long)((this.Length - num2) * sizeOf));
				this.Length -= num;
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0001C3DA File Offset: 0x0001A5DA
		public void RemoveAtSwapBack<T>(int index) where T : struct
		{
			this.RemoveRangeSwapBackWithBeginEnd<T>(index, index + 1);
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0001C3E6 File Offset: 0x0001A5E6
		public void RemoveRangeSwapBackWithBeginEnd<T>(int begin, int end) where T : struct
		{
			this.RemoveRangeSwapBackWithBeginEnd(UnsafeUtility.SizeOf<T>(), begin, end);
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0001C3F8 File Offset: 0x0001A5F8
		private unsafe void RemoveRangeWithBeginEnd(int sizeOf, int begin, int end)
		{
			int num = end - begin;
			if (num > 0)
			{
				int num2 = math.min(begin + num, this.Length);
				void* destination = (void*)((byte*)this.Ptr + begin * sizeOf);
				void* source = (void*)((byte*)this.Ptr + num2 * sizeOf);
				UnsafeUtility.MemCpy(destination, source, (long)((this.Length - num2) * sizeOf));
				this.Length -= num;
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0001C452 File Offset: 0x0001A652
		public void RemoveAt<T>(int index) where T : struct
		{
			this.RemoveRangeWithBeginEnd<T>(index, index + 1);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0001C45E File Offset: 0x0001A65E
		public void RemoveRangeWithBeginEnd<T>(int begin, int end) where T : struct
		{
			this.RemoveRangeWithBeginEnd(UnsafeUtility.SizeOf<T>(), begin, end);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0001C46D File Offset: 0x0001A66D
		public UnsafeList.ParallelReader AsParallelReader()
		{
			return new UnsafeList.ParallelReader(this.Ptr, this.Length);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001C480 File Offset: 0x0001A680
		public unsafe UnsafeList.ParallelWriter AsParallelWriter()
		{
			return new UnsafeList.ParallelWriter(this.Ptr, (UnsafeList*)UnsafeUtility.AddressOf<UnsafeList>(ref this));
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0001C493 File Offset: 0x0001A693
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal unsafe static void CheckNull(void* listData)
		{
			if (listData == null)
			{
				throw new Exception("UnsafeList has yet to be created or has been destroyed!");
			}
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0001C4A5 File Offset: 0x0001A6A5
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckAllocator(Allocator a)
		{
			if (!CollectionHelper.ShouldDeallocate(a))
			{
				throw new Exception("UnsafeList is not initialized, it must be initialized with allocator before use.");
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0001C4BF File Offset: 0x0001A6BF
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckAllocator(AllocatorManager.AllocatorHandle a)
		{
			if (!CollectionHelper.ShouldDeallocate(a))
			{
				throw new Exception("UnsafeList is not initialized, it must be initialized with allocator before use.");
			}
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0001C4D4 File Offset: 0x0001A6D4
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckBeginEnd(int begin, int end)
		{
			if (begin > end)
			{
				throw new ArgumentException(string.Format("Value for begin {0} index must less or equal to end {1}.", begin, end));
			}
			if (begin < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for begin {0} must be positive.", begin));
			}
			if (begin > this.Length)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for begin {0} is out of bounds.", begin));
			}
			if (end > this.Length)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for end {0} is out of bounds.", end));
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNoResizeHasEnoughCapacity(int length)
		{
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001C559 File Offset: 0x0001A759
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNoResizeHasEnoughCapacity(int length, int index)
		{
			if (this.Capacity < index + length)
			{
				throw new Exception(string.Format("AddNoResize assumes that list capacity is sufficient (Capacity {0}, Length {1}), requested length {2}!", this.Capacity, this.Length, length));
			}
		}

		// Token: 0x04000312 RID: 786
		[NativeDisableUnsafePtrRestriction]
		public unsafe void* Ptr;

		// Token: 0x04000313 RID: 787
		public int Length;

		// Token: 0x04000314 RID: 788
		public readonly int unused;

		// Token: 0x04000315 RID: 789
		public int Capacity;

		// Token: 0x04000316 RID: 790
		public AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x020000DB RID: 219
		public struct ParallelReader
		{
			// Token: 0x060008DE RID: 2270 RVA: 0x0001C592 File Offset: 0x0001A792
			internal unsafe ParallelReader(void* ptr, int length)
			{
				this.Ptr = ptr;
				this.Length = length;
			}

			// Token: 0x060008DF RID: 2271 RVA: 0x0001C5A2 File Offset: 0x0001A7A2
			public int IndexOf<T>(T value) where T : struct, IEquatable<T>
			{
				return NativeArrayExtensions.IndexOf<T, T>(this.Ptr, this.Length, value);
			}

			// Token: 0x060008E0 RID: 2272 RVA: 0x0001C5B6 File Offset: 0x0001A7B6
			public bool Contains<T>(T value) where T : struct, IEquatable<T>
			{
				return this.IndexOf<T>(value) != -1;
			}

			// Token: 0x04000317 RID: 791
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly void* Ptr;

			// Token: 0x04000318 RID: 792
			public readonly int Length;
		}

		// Token: 0x020000DC RID: 220
		public struct ParallelWriter
		{
			// Token: 0x060008E1 RID: 2273 RVA: 0x0001C5C5 File Offset: 0x0001A7C5
			internal unsafe ParallelWriter(void* ptr, UnsafeList* listData)
			{
				this.Ptr = ptr;
				this.ListData = listData;
			}

			// Token: 0x060008E2 RID: 2274 RVA: 0x0001C5D8 File Offset: 0x0001A7D8
			public unsafe void AddNoResize<T>(T value) where T : struct
			{
				int index = Interlocked.Increment(ref this.ListData->Length) - 1;
				UnsafeUtility.WriteArrayElement<T>(this.Ptr, index, value);
			}

			// Token: 0x060008E3 RID: 2275 RVA: 0x0001C608 File Offset: 0x0001A808
			private unsafe void AddRangeNoResize(int sizeOf, int alignOf, void* ptr, int length)
			{
				int num = Interlocked.Add(ref this.ListData->Length, length) - length;
				void* destination = (void*)((byte*)this.Ptr + num * sizeOf);
				UnsafeUtility.MemCpy(destination, ptr, (long)(length * sizeOf));
			}

			// Token: 0x060008E4 RID: 2276 RVA: 0x0001C642 File Offset: 0x0001A842
			public unsafe void AddRangeNoResize<T>(void* ptr, int length) where T : struct
			{
				this.AddRangeNoResize(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), ptr, length);
			}

			// Token: 0x060008E5 RID: 2277 RVA: 0x0001C656 File Offset: 0x0001A856
			public void AddRangeNoResize<T>(UnsafeList list) where T : struct
			{
				this.AddRangeNoResize(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), list.Ptr, list.Length);
			}

			// Token: 0x04000319 RID: 793
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly void* Ptr;

			// Token: 0x0400031A RID: 794
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList* ListData;
		}
	}
}
