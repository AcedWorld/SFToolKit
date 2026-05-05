using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200011A RID: 282
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafeRingQueueDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct UnsafeRingQueue<[IsUnmanaged] T> : INativeDisposable, IDisposable where T : struct, ValueType
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x00021E5B File Offset: 0x0002005B
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.Length == 0;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x00021E70 File Offset: 0x00020070
		public int Length
		{
			get
			{
				return this.Control.Length;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x00021E7D File Offset: 0x0002007D
		public int Capacity
		{
			get
			{
				return this.Control.Capacity;
			}
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00021E8A File Offset: 0x0002008A
		public unsafe UnsafeRingQueue(T* ptr, int capacity)
		{
			this.Ptr = ptr;
			this.Allocator = AllocatorManager.None;
			this.Control = new RingControl(capacity);
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00021EAC File Offset: 0x000200AC
		public unsafe UnsafeRingQueue(int capacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
		{
			capacity++;
			this.Allocator = allocator;
			this.Control = new RingControl(capacity);
			int num = capacity * UnsafeUtility.SizeOf<T>();
			this.Ptr = (T*)Memory.Unmanaged.Allocate((long)num, 16, allocator);
			if (options == NativeArrayOptions.ClearMemory)
			{
				UnsafeUtility.MemClear((void*)this.Ptr, (long)num);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x00021EFA File Offset: 0x000200FA
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00021F09 File Offset: 0x00020109
		public void Dispose()
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				Memory.Unmanaged.Free<T>(this.Ptr, this.Allocator);
				this.Allocator = AllocatorManager.Invalid;
			}
			this.Ptr = null;
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00021F3C File Offset: 0x0002013C
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

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00021F9C File Offset: 0x0002019C
		public unsafe bool TryEnqueue(T value)
		{
			if (1 != this.Control.Reserve(1))
			{
				return false;
			}
			this.Ptr[(IntPtr)this.Control.Current * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)] = value;
			this.Control.Commit(1);
			return true;
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00021FE8 File Offset: 0x000201E8
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void ThrowQueueFull()
		{
			throw new InvalidOperationException("Trying to enqueue into full queue.");
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00021FF4 File Offset: 0x000201F4
		public void Enqueue(T value)
		{
			this.TryEnqueue(value);
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00021FFE File Offset: 0x000201FE
		public unsafe bool TryDequeue(out T item)
		{
			item = this.Ptr[(IntPtr)this.Control.Read * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
			return 1 == this.Control.Consume(1);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00022034 File Offset: 0x00020234
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void ThrowQueueEmpty()
		{
			throw new InvalidOperationException("Trying to dequeue from an empty queue");
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00022040 File Offset: 0x00020240
		public T Dequeue()
		{
			T result;
			this.TryDequeue(out result);
			return result;
		}

		// Token: 0x040003A4 RID: 932
		[NativeDisableUnsafePtrRestriction]
		public unsafe T* Ptr;

		// Token: 0x040003A5 RID: 933
		public AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x040003A6 RID: 934
		internal RingControl Control;
	}
}
