using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000109 RID: 265
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafeListTDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct UnsafeList<[IsUnmanaged] T> : INativeDisposable, IDisposable, INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable where T : struct, ValueType
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x0002089B File Offset: 0x0001EA9B
		// (set) Token: 0x06000A18 RID: 2584 RVA: 0x000208A8 File Offset: 0x0001EAA8
		public int Length
		{
			get
			{
				return CollectionHelper.AssumePositive(this.m_length);
			}
			set
			{
				if (value > this.Capacity)
				{
					this.Resize(value, NativeArrayOptions.UninitializedMemory);
					return;
				}
				this.m_length = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x000208C3 File Offset: 0x0001EAC3
		// (set) Token: 0x06000A1A RID: 2586 RVA: 0x000208D0 File Offset: 0x0001EAD0
		public int Capacity
		{
			get
			{
				return CollectionHelper.AssumePositive(this.m_capacity);
			}
			set
			{
				this.SetCapacity(value);
			}
		}

		// Token: 0x1700010F RID: 271
		public unsafe T this[int index]
		{
			get
			{
				return this.Ptr[(IntPtr)CollectionHelper.AssumePositive(index) * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
			}
			set
			{
				this.Ptr[(IntPtr)CollectionHelper.AssumePositive(index) * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)] = value;
			}
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00020912 File Offset: 0x0001EB12
		public unsafe ref T ElementAt(int index)
		{
			return ref this.Ptr[(IntPtr)CollectionHelper.AssumePositive(index) * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00020929 File Offset: 0x0001EB29
		public unsafe UnsafeList(T* ptr, int length)
		{
			this = default(UnsafeList<T>);
			this.Ptr = ptr;
			this.m_length = length;
			this.m_capacity = 0;
			this.Allocator = AllocatorManager.None;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00020954 File Offset: 0x0001EB54
		public unsafe UnsafeList(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			this = default(UnsafeList<T>);
			this.Ptr = null;
			this.m_length = 0;
			this.m_capacity = 0;
			this.Allocator = allocator;
			if (initialCapacity != 0)
			{
				this.SetCapacity(initialCapacity);
			}
			if (options == NativeArrayOptions.ClearMemory && this.Ptr != null)
			{
				int num = sizeof(T);
				UnsafeUtility.MemClear((void*)this.Ptr, (long)(this.Capacity * num));
			}
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000209B8 File Offset: 0x0001EBB8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal void Initialize<[IsUnmanaged] U>(int initialCapacity, ref U allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			this.Ptr = null;
			this.m_length = 0;
			this.m_capacity = 0;
			this.Allocator = AllocatorManager.None;
			this.Initialize<U>(initialCapacity, ref allocator, options);
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x000209E4 File Offset: 0x0001EBE4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal static UnsafeList<T> New<[IsUnmanaged] U>(int initialCapacity, ref U allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			UnsafeList<T> result = default(UnsafeList<T>);
			result.Initialize<U>(initialCapacity, ref allocator, options);
			return result;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00020A04 File Offset: 0x0001EC04
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal unsafe static UnsafeList<T>* Create<[IsUnmanaged] U>(int initialCapacity, ref U allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			UnsafeList<T>* ptr = ref allocator.Allocate(default(UnsafeList<T>), 1);
			UnsafeUtility.MemClear((void*)ptr, (long)sizeof(UnsafeList<T>));
			ptr->Allocator = allocator.Handle;
			if (initialCapacity != 0)
			{
				ptr->SetCapacity<U>(ref allocator, initialCapacity);
			}
			if (options == NativeArrayOptions.ClearMemory && ptr->Ptr != null)
			{
				int num = sizeof(T);
				UnsafeUtility.MemClear((void*)ptr->Ptr, (long)(ptr->Capacity * num));
			}
			return ptr;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x00020A76 File Offset: 0x0001EC76
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal unsafe static void Destroy<[IsUnmanaged] U>(UnsafeList<T>* listData, ref U allocator) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			listData->Dispose<U>(ref allocator);
			ref allocator.Free((void*)listData, sizeof(UnsafeList<T>), UnsafeUtility.AlignOf<UnsafeList<T>>(), 1);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00020A92 File Offset: 0x0001EC92
		public unsafe static UnsafeList<T>* Create(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			UnsafeList<T>* ptr = AllocatorManager.Allocate<UnsafeList<T>>(allocator, 1);
			*ptr = new UnsafeList<T>(initialCapacity, allocator, options);
			return ptr;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00020AA9 File Offset: 0x0001ECA9
		public unsafe static void Destroy(UnsafeList<T>* listData)
		{
			AllocatorManager.AllocatorHandle allocator = listData->Allocator;
			listData->Dispose();
			AllocatorManager.Free<UnsafeList<T>>(allocator, listData, 1);
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x00020ABE File Offset: 0x0001ECBE
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.m_length == 0;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x00020AD3 File Offset: 0x0001ECD3
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00020AE2 File Offset: 0x0001ECE2
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal void Dispose<[IsUnmanaged] U>(ref U allocator) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			ref allocator.Free(this.Ptr, this.m_length);
			this.Ptr = null;
			this.m_length = 0;
			this.m_capacity = 0;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00020B0C File Offset: 0x0001ED0C
		public void Dispose()
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				AllocatorManager.Free<T>(this.Allocator, this.Ptr, 1);
				this.Allocator = AllocatorManager.Invalid;
			}
			this.Ptr = null;
			this.m_length = 0;
			this.m_capacity = 0;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00020B5C File Offset: 0x0001ED5C
		[NotBurstCompatible]
		public unsafe JobHandle Dispose(JobHandle inputDeps)
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				JobHandle result = new UnsafeDisposeJob
				{
					Ptr = (void*)this.Ptr,
					Allocator = this.Allocator
				}.Schedule(inputDeps);
				this.Ptr = null;
				this.Allocator = AllocatorManager.Invalid;
				return result;
			}
			this.Ptr = null;
			return inputDeps;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00020BBC File Offset: 0x0001EDBC
		public void Clear()
		{
			this.m_length = 0;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00020BC8 File Offset: 0x0001EDC8
		public unsafe void Resize(int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory)
		{
			int num = this.m_length;
			if (length > this.Capacity)
			{
				this.SetCapacity(length);
			}
			this.m_length = length;
			if (options == NativeArrayOptions.ClearMemory && num < length)
			{
				int num2 = length - num;
				byte* ptr = (byte*)this.Ptr;
				int num3 = sizeof(T);
				UnsafeUtility.MemClear((void*)(ptr + num * num3), (long)(num2 * num3));
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00020C1C File Offset: 0x0001EE1C
		private unsafe void Realloc<[IsUnmanaged] U>(ref U allocator, int newCapacity) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			T* ptr = null;
			int alignOf = UnsafeUtility.AlignOf<T>();
			int num = sizeof(T);
			if (newCapacity > 0)
			{
				ptr = (T*)ref allocator.Allocate(num, alignOf, newCapacity);
				if (this.m_capacity > 0)
				{
					int num2 = math.min(newCapacity, this.Capacity) * num;
					UnsafeUtility.MemCpy((void*)ptr, (void*)this.Ptr, (long)num2);
				}
			}
			ref allocator.Free(this.Ptr, this.Capacity);
			this.Ptr = ptr;
			this.m_capacity = newCapacity;
			this.m_length = math.min(this.m_length, newCapacity);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00020C9F File Offset: 0x0001EE9F
		private void Realloc(int capacity)
		{
			this.Realloc<AllocatorManager.AllocatorHandle>(ref this.Allocator, capacity);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00020CB0 File Offset: 0x0001EEB0
		private void SetCapacity<[IsUnmanaged] U>(ref U allocator, int capacity) where U : struct, ValueType, AllocatorManager.IAllocator
		{
			int num = sizeof(T);
			int num2 = math.max(capacity, 64 / num);
			num2 = math.ceilpow2(num2);
			if (num2 == this.Capacity)
			{
				return;
			}
			this.Realloc<U>(ref allocator, num2);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00020CE8 File Offset: 0x0001EEE8
		public void SetCapacity(int capacity)
		{
			this.SetCapacity<AllocatorManager.AllocatorHandle>(ref this.Allocator, capacity);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00020CF7 File Offset: 0x0001EEF7
		public void TrimExcess()
		{
			if (this.Capacity != this.m_length)
			{
				this.Realloc(this.m_length);
			}
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00020D13 File Offset: 0x0001EF13
		public unsafe void AddNoResize(T value)
		{
			UnsafeUtility.WriteArrayElement<T>((void*)this.Ptr, this.m_length, value);
			this.m_length++;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00020D38 File Offset: 0x0001EF38
		public unsafe void AddRangeNoResize(void* ptr, int count)
		{
			int num = sizeof(T);
			void* destination = (void*)(this.Ptr + this.m_length * num / sizeof(T));
			UnsafeUtility.MemCpy(destination, ptr, (long)(count * num));
			this.m_length += count;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00020D75 File Offset: 0x0001EF75
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe void AddRangeNoResize(UnsafeList<T> list)
		{
			this.AddRangeNoResize((void*)list.Ptr, CollectionHelper.AssumePositive(list.m_length));
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00020D90 File Offset: 0x0001EF90
		public unsafe void Add(in T value)
		{
			int num = this.m_length;
			if (this.m_length + 1 > this.Capacity)
			{
				this.Resize(num + 1, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				this.m_length++;
			}
			UnsafeUtility.WriteArrayElement<T>((void*)this.Ptr, num, value);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00020DE0 File Offset: 0x0001EFE0
		public unsafe void AddRange(void* ptr, int count)
		{
			int num = this.m_length;
			if (this.m_length + count > this.Capacity)
			{
				this.Resize(this.m_length + count, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				this.m_length += count;
			}
			int num2 = sizeof(T);
			void* destination = (void*)(this.Ptr + num * num2 / sizeof(T));
			UnsafeUtility.MemCpy(destination, ptr, (long)(count * num2));
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00020E40 File Offset: 0x0001F040
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe void AddRange(UnsafeList<T> list)
		{
			this.AddRange((void*)list.Ptr, list.Length);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00020E58 File Offset: 0x0001F058
		public unsafe void InsertRangeWithBeginEnd(int begin, int end)
		{
			int num = end - begin;
			if (num < 1)
			{
				return;
			}
			int num2 = this.m_length;
			if (this.m_length + num > this.Capacity)
			{
				this.Resize(this.m_length + num, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				this.m_length += num;
			}
			int num3 = num2 - begin;
			if (num3 < 1)
			{
				return;
			}
			int num4 = sizeof(T);
			int num5 = num3 * num4;
			byte* ptr = (byte*)this.Ptr;
			void* destination = (void*)(ptr + end * num4);
			byte* source = ptr + begin * num4;
			UnsafeUtility.MemMove(destination, (void*)source, (long)num5);
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00020ED5 File Offset: 0x0001F0D5
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00020EE0 File Offset: 0x0001F0E0
		public unsafe void RemoveRangeSwapBack(int index, int count)
		{
			if (count > 0)
			{
				int num = math.max(this.m_length - count, index + count);
				int num2 = sizeof(T);
				void* destination = (void*)(this.Ptr + index * num2 / sizeof(T));
				void* source = (void*)(this.Ptr + num * num2 / sizeof(T));
				UnsafeUtility.MemCpy(destination, source, (long)((this.m_length - num) * num2));
				this.m_length -= count;
			}
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00020F40 File Offset: 0x0001F140
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public unsafe void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			int num = end - begin;
			if (num > 0)
			{
				int num2 = math.max(this.m_length - num, end);
				int num3 = sizeof(T);
				void* destination = (void*)(this.Ptr + begin * num3 / sizeof(T));
				void* source = (void*)(this.Ptr + num2 * num3 / sizeof(T));
				UnsafeUtility.MemCpy(destination, source, (long)((this.m_length - num2) * num3));
				this.m_length -= num;
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00020FA3 File Offset: 0x0001F1A3
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00020FB0 File Offset: 0x0001F1B0
		public unsafe void RemoveRange(int index, int count)
		{
			if (count > 0)
			{
				int num = math.min(index + count, this.m_length);
				int num2 = sizeof(T);
				void* destination = (void*)(this.Ptr + index * num2 / sizeof(T));
				void* source = (void*)(this.Ptr + num * num2 / sizeof(T));
				UnsafeUtility.MemCpy(destination, source, (long)((this.m_length - num) * num2));
				this.m_length -= count;
			}
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00021010 File Offset: 0x0001F210
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public unsafe void RemoveRangeWithBeginEnd(int begin, int end)
		{
			int num = end - begin;
			if (num > 0)
			{
				int num2 = math.min(begin + num, this.m_length);
				int num3 = sizeof(T);
				void* destination = (void*)(this.Ptr + begin * num3 / sizeof(T));
				void* source = (void*)(this.Ptr + num2 * num3 / sizeof(T));
				UnsafeUtility.MemCpy(destination, source, (long)((this.m_length - num2) * num3));
				this.m_length -= num;
			}
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00021073 File Offset: 0x0001F273
		public UnsafeList<T>.ParallelReader AsParallelReader()
		{
			return new UnsafeList<T>.ParallelReader(this.Ptr, this.Length);
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00021086 File Offset: 0x0001F286
		public unsafe UnsafeList<T>.ParallelWriter AsParallelWriter()
		{
			return new UnsafeList<T>.ParallelWriter((UnsafeList<T>*)UnsafeUtility.AddressOf<UnsafeList<T>>(ref this));
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00021093 File Offset: 0x0001F293
		public unsafe void CopyFrom(UnsafeList<T> array)
		{
			this.Resize(array.Length, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy((void*)this.Ptr, (void*)array.Ptr, (long)(UnsafeUtility.SizeOf<T>() * this.Length));
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x000210C4 File Offset: 0x0001F2C4
		public UnsafeList<T>.Enumerator GetEnumerator()
		{
			return new UnsafeList<T>.Enumerator
			{
				m_Ptr = this.Ptr,
				m_Length = this.Length,
				m_Index = -1
			};
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0001C493 File Offset: 0x0001A693
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal unsafe static void CheckNull(void* listData)
		{
			if (listData == null)
			{
				throw new Exception("UnsafeList has yet to be created or has been destroyed!");
			}
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x000210FC File Offset: 0x0001F2FC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexCount(int index, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for cound {0} must be positive.", count));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for index {0} must be positive.", index));
			}
			if (index > this.Length)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for index {0} is out of bounds.", index));
			}
			if (index + count > this.Length)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value for count {0} is out of bounds.", count));
			}
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00021180 File Offset: 0x0001F380
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

		// Token: 0x06000A48 RID: 2632 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNoResizeHasEnoughCapacity(int length)
		{
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00021205 File Offset: 0x0001F405
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNoResizeHasEnoughCapacity(int length, int index)
		{
			if (this.Capacity < index + length)
			{
				throw new Exception(string.Format("AddNoResize assumes that list capacity is sufficient (Capacity {0}, Length {1}), requested length {2}!", this.Capacity, this.Length, length));
			}
		}

		// Token: 0x0400037D RID: 893
		[NativeDisableUnsafePtrRestriction]
		public unsafe T* Ptr;

		// Token: 0x0400037E RID: 894
		public int m_length;

		// Token: 0x0400037F RID: 895
		public int m_capacity;

		// Token: 0x04000380 RID: 896
		public AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x04000381 RID: 897
		[Obsolete("Use Length property (UnityUpgradable) -> Length", true)]
		public int length;

		// Token: 0x04000382 RID: 898
		[Obsolete("Use Capacity property (UnityUpgradable) -> Capacity", true)]
		public int capacity;

		// Token: 0x0200010A RID: 266
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelReader
		{
			// Token: 0x06000A4A RID: 2634 RVA: 0x0002123E File Offset: 0x0001F43E
			internal unsafe ParallelReader(T* ptr, int length)
			{
				this.Ptr = ptr;
				this.Length = length;
			}

			// Token: 0x04000383 RID: 899
			[NativeDisableUnsafePtrRestriction]
			public unsafe readonly T* Ptr;

			// Token: 0x04000384 RID: 900
			public readonly int Length;
		}

		// Token: 0x0200010B RID: 267
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x17000112 RID: 274
			// (get) Token: 0x06000A4B RID: 2635 RVA: 0x0002124E File Offset: 0x0001F44E
			public unsafe readonly void* Ptr
			{
				get
				{
					return (void*)this.ListData->Ptr;
				}
			}

			// Token: 0x06000A4C RID: 2636 RVA: 0x0002125B File Offset: 0x0001F45B
			internal unsafe ParallelWriter(UnsafeList<T>* listData)
			{
				this.ListData = listData;
			}

			// Token: 0x06000A4D RID: 2637 RVA: 0x00021264 File Offset: 0x0001F464
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void AddNoResize(T value)
			{
				int index = Interlocked.Increment(ref this.ListData->m_length) - 1;
				UnsafeUtility.WriteArrayElement<T>((void*)this.ListData->Ptr, index, value);
			}

			// Token: 0x06000A4E RID: 2638 RVA: 0x00021298 File Offset: 0x0001F498
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void AddRangeNoResize(void* ptr, int count)
			{
				int num = Interlocked.Add(ref this.ListData->m_length, count) - count;
				void* destination = (void*)(this.ListData->Ptr + num * sizeof(T) / sizeof(T));
				UnsafeUtility.MemCpy(destination, ptr, (long)(count * sizeof(T)));
			}

			// Token: 0x06000A4F RID: 2639 RVA: 0x000212DE File Offset: 0x0001F4DE
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void AddRangeNoResize(UnsafeList<T> list)
			{
				this.AddRangeNoResize((void*)list.Ptr, list.Length);
			}

			// Token: 0x04000385 RID: 901
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList<T>* ListData;
		}

		// Token: 0x0200010C RID: 268
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x06000A50 RID: 2640 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000A51 RID: 2641 RVA: 0x000212F4 File Offset: 0x0001F4F4
			public bool MoveNext()
			{
				int num = this.m_Index + 1;
				this.m_Index = num;
				return num < this.m_Length;
			}

			// Token: 0x06000A52 RID: 2642 RVA: 0x0002131A File Offset: 0x0001F51A
			public void Reset()
			{
				this.m_Index = -1;
			}

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00021323 File Offset: 0x0001F523
			public unsafe T Current
			{
				get
				{
					return this.m_Ptr[(IntPtr)this.m_Index * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
				}
			}

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0002133F File Offset: 0x0001F53F
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000386 RID: 902
			internal unsafe T* m_Ptr;

			// Token: 0x04000387 RID: 903
			internal int m_Length;

			// Token: 0x04000388 RID: 904
			internal int m_Index;
		}
	}
}
