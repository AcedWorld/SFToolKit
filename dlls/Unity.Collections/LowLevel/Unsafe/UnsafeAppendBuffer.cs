using System;
using System.Diagnostics;
using Unity.Collections.LowLevel.Unsafe.NotBurstCompatible;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000EE RID: 238
	[BurstCompatible]
	public struct UnsafeAppendBuffer : INativeDisposable, IDisposable
	{
		// Token: 0x06000949 RID: 2377 RVA: 0x0001D372 File Offset: 0x0001B572
		public UnsafeAppendBuffer(int initialCapacity, int alignment, AllocatorManager.AllocatorHandle allocator)
		{
			this.Alignment = alignment;
			this.Allocator = allocator;
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
			this.SetCapacity(initialCapacity);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0001D39F File Offset: 0x0001B59F
		public unsafe UnsafeAppendBuffer(void* ptr, int length)
		{
			this.Alignment = 0;
			this.Allocator = AllocatorManager.None;
			this.Ptr = (byte*)ptr;
			this.Length = 0;
			this.Capacity = length;
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x0001D3C8 File Offset: 0x0001B5C8
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0001D3D3 File Offset: 0x0001B5D3
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0001D3E4 File Offset: 0x0001B5E4
		public void Dispose()
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				Memory.Unmanaged.Free<byte>(this.Ptr, this.Allocator);
				this.Allocator = AllocatorManager.Invalid;
			}
			this.Ptr = null;
			this.Length = 0;
			this.Capacity = 0;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0001D430 File Offset: 0x0001B630
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

		// Token: 0x0600094F RID: 2383 RVA: 0x0001D490 File Offset: 0x0001B690
		public void Reset()
		{
			this.Length = 0;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0001D49C File Offset: 0x0001B69C
		public unsafe void SetCapacity(int capacity)
		{
			if (capacity <= this.Capacity)
			{
				return;
			}
			capacity = math.max(64, math.ceilpow2(capacity));
			byte* ptr = (byte*)Memory.Unmanaged.Allocate((long)capacity, this.Alignment, this.Allocator);
			if (this.Ptr != null)
			{
				UnsafeUtility.MemCpy((void*)ptr, (void*)this.Ptr, (long)this.Length);
				Memory.Unmanaged.Free<byte>(this.Ptr, this.Allocator);
			}
			this.Ptr = ptr;
			this.Capacity = capacity;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0001D512 File Offset: 0x0001B712
		public void ResizeUninitialized(int length)
		{
			this.SetCapacity(length);
			this.Length = length;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0001D524 File Offset: 0x0001B724
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe void Add<T>(T value) where T : struct
		{
			int num = UnsafeUtility.SizeOf<T>();
			this.SetCapacity(this.Length + num);
			UnsafeUtility.CopyStructureToPtr<T>(ref value, (void*)(this.Ptr + this.Length));
			this.Length += num;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0001D567 File Offset: 0x0001B767
		public unsafe void Add(void* ptr, int structSize)
		{
			this.SetCapacity(this.Length + structSize);
			UnsafeUtility.MemCpy((void*)(this.Ptr + this.Length), ptr, (long)structSize);
			this.Length += structSize;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0001D59A File Offset: 0x0001B79A
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe void AddArray<T>(void* ptr, int length) where T : struct
		{
			this.Add<int>(length);
			if (length != 0)
			{
				this.Add(ptr, length * UnsafeUtility.SizeOf<T>());
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0001D5B4 File Offset: 0x0001B7B4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public void Add<T>(NativeArray<T> value) where T : struct
		{
			this.Add<int>(value.Length);
			this.Add(value.GetUnsafeReadOnlyPtr<T>(), UnsafeUtility.SizeOf<T>() * value.Length);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0001D5DC File Offset: 0x0001B7DC
		[NotBurstCompatible]
		[Obsolete("Please use `AddNBC` from `Unity.Collections.LowLevel.Unsafe.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", false)]
		public void Add(string value)
		{
			ref this.AddNBC(value);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001D5E8 File Offset: 0x0001B7E8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe T Pop<T>() where T : struct
		{
			int num = UnsafeUtility.SizeOf<T>();
			byte* ptr = this.Ptr;
			long num2 = (long)this.Length;
			T result = UnsafeUtility.ReadArrayElement<T>((void*)((byte*)((byte*)ptr + num2) - (long)num), 0);
			this.Length -= num;
			return result;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001D624 File Offset: 0x0001B824
		public unsafe void Pop(void* ptr, int structSize)
		{
			long num = this.Ptr;
			long num2 = (long)this.Length;
			long num3 = num + num2 - (long)structSize;
			UnsafeUtility.MemCpy(ptr, num3, (long)structSize);
			this.Length -= structSize;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001D65E File Offset: 0x0001B85E
		[NotBurstCompatible]
		[Obsolete("Please use `ToBytesNBC` from `Unity.Collections.LowLevel.Unsafe.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", false)]
		public byte[] ToBytes()
		{
			return ref this.ToBytesNBC();
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001D666 File Offset: 0x0001B866
		public UnsafeAppendBuffer.Reader AsReader()
		{
			return new UnsafeAppendBuffer.Reader(ref this);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001D670 File Offset: 0x0001B870
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckAlignment(int alignment)
		{
			int num = (alignment == 0) ? 1 : 0;
			bool flag = (alignment - 1 & alignment) == 0;
			if (num != 0 || !flag)
			{
				throw new ArgumentException(string.Format("Specified alignment must be non-zero positive power of two. Requested: {0}", alignment));
			}
		}

		// Token: 0x04000340 RID: 832
		[NativeDisableUnsafePtrRestriction]
		public unsafe byte* Ptr;

		// Token: 0x04000341 RID: 833
		public int Length;

		// Token: 0x04000342 RID: 834
		public int Capacity;

		// Token: 0x04000343 RID: 835
		public AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x04000344 RID: 836
		public readonly int Alignment;

		// Token: 0x020000EF RID: 239
		[BurstCompatible]
		public struct Reader
		{
			// Token: 0x0600095C RID: 2396 RVA: 0x0001D6A7 File Offset: 0x0001B8A7
			public Reader(ref UnsafeAppendBuffer buffer)
			{
				this.Ptr = buffer.Ptr;
				this.Size = buffer.Length;
				this.Offset = 0;
			}

			// Token: 0x0600095D RID: 2397 RVA: 0x0001D6C8 File Offset: 0x0001B8C8
			public unsafe Reader(void* ptr, int length)
			{
				this.Ptr = (byte*)ptr;
				this.Size = length;
				this.Offset = 0;
			}

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x0600095E RID: 2398 RVA: 0x0001D6DF File Offset: 0x0001B8DF
			public bool EndOfBuffer
			{
				get
				{
					return this.Offset == this.Size;
				}
			}

			// Token: 0x0600095F RID: 2399 RVA: 0x0001D6F0 File Offset: 0x0001B8F0
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void ReadNext<T>(out T value) where T : struct
			{
				int num = UnsafeUtility.SizeOf<T>();
				UnsafeUtility.CopyPtrToStructure<T>((void*)(this.Ptr + this.Offset), out value);
				this.Offset += num;
			}

			// Token: 0x06000960 RID: 2400 RVA: 0x0001D724 File Offset: 0x0001B924
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe T ReadNext<T>() where T : struct
			{
				int num = UnsafeUtility.SizeOf<T>();
				T result = UnsafeUtility.ReadArrayElement<T>((void*)(this.Ptr + this.Offset), 0);
				this.Offset += num;
				return result;
			}

			// Token: 0x06000961 RID: 2401 RVA: 0x0001D758 File Offset: 0x0001B958
			public unsafe void* ReadNext(int structSize)
			{
				void* result = (void*)((IntPtr)((void*)this.Ptr) + this.Offset);
				this.Offset += structSize;
				return result;
			}

			// Token: 0x06000962 RID: 2402 RVA: 0x0001D784 File Offset: 0x0001B984
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void ReadNext<T>(out NativeArray<T> value, AllocatorManager.AllocatorHandle allocator) where T : struct
			{
				int num = this.ReadNext<int>();
				value = CollectionHelper.CreateNativeArray<T>(num, allocator, NativeArrayOptions.ClearMemory);
				int num2 = num * UnsafeUtility.SizeOf<T>();
				if (num2 > 0)
				{
					void* source = this.ReadNext(num2);
					UnsafeUtility.MemCpy(value.GetUnsafePtr<T>(), source, (long)num2);
				}
			}

			// Token: 0x06000963 RID: 2403 RVA: 0x0001D7CD File Offset: 0x0001B9CD
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void* ReadNextArray<T>(out int length) where T : struct
			{
				length = this.ReadNext<int>();
				if (length != 0)
				{
					return this.ReadNext(length * UnsafeUtility.SizeOf<T>());
				}
				return null;
			}

			// Token: 0x06000964 RID: 2404 RVA: 0x0001D7EC File Offset: 0x0001B9EC
			[NotBurstCompatible]
			[Obsolete("Please use `ReadNextNBC` from `Unity.Collections.LowLevel.Unsafe.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", false)]
			public void ReadNext(out string value)
			{
				ref this.ReadNextNBC(out value);
			}

			// Token: 0x06000965 RID: 2405 RVA: 0x0001D7F5 File Offset: 0x0001B9F5
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckBounds(int structSize)
			{
				if (this.Offset + structSize > this.Size)
				{
					throw new ArgumentException(string.Format("Requested value outside bounds of UnsafeAppendOnlyBuffer. Remaining bytes: {0} Requested: {1}", this.Size - this.Offset, structSize));
				}
			}

			// Token: 0x04000345 RID: 837
			public unsafe readonly byte* Ptr;

			// Token: 0x04000346 RID: 838
			public readonly int Size;

			// Token: 0x04000347 RID: 839
			public int Offset;
		}
	}
}
