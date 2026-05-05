using System;
using System.Diagnostics;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000AB RID: 171
	[NativeContainer]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct NativeQueue<T> : INativeDisposable, IDisposable where T : struct
	{
		// Token: 0x060006F3 RID: 1779 RVA: 0x000169A5 File Offset: 0x00014BA5
		public NativeQueue(AllocatorManager.AllocatorHandle allocator)
		{
			this.m_QueuePool = NativeQueueBlockPool.GetQueueBlockPool();
			this.m_AllocatorLabel = allocator;
			NativeQueueData.AllocateQueue<T>(allocator, out this.m_Buffer);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x000169C8 File Offset: 0x00014BC8
		public unsafe bool IsEmpty()
		{
			if (!this.IsCreated)
			{
				return true;
			}
			int num = 0;
			int currentRead = this.m_Buffer->m_CurrentRead;
			for (NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_Buffer->m_FirstBlock); ptr != null; ptr = ptr->m_NextBlock)
			{
				num += ptr->m_NumItems;
				if (num > currentRead)
				{
					return false;
				}
			}
			return num == currentRead;
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00016A20 File Offset: 0x00014C20
		public unsafe int Count
		{
			get
			{
				int num = 0;
				for (NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_Buffer->m_FirstBlock); ptr != null; ptr = ptr->m_NextBlock)
				{
					num += ptr->m_NumItems;
				}
				return num - this.m_Buffer->m_CurrentRead;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00016A64 File Offset: 0x00014C64
		// (set) Token: 0x060006F7 RID: 1783 RVA: 0x00016A70 File Offset: 0x00014C70
		internal unsafe static int PersistentMemoryBlockCount
		{
			get
			{
				return NativeQueueBlockPool.GetQueueBlockPool()->m_MaxBlocks;
			}
			set
			{
				Interlocked.Exchange(ref NativeQueueBlockPool.GetQueueBlockPool()->m_MaxBlocks, value);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x00016A83 File Offset: 0x00014C83
		internal static int MemoryBlockSize
		{
			get
			{
				return 16384;
			}
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00016A8C File Offset: 0x00014C8C
		public unsafe T Peek()
		{
			NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_Buffer->m_FirstBlock);
			return UnsafeUtility.ReadArrayElement<T>((void*)(ptr + 1), this.m_Buffer->m_CurrentRead);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00016AC4 File Offset: 0x00014CC4
		public unsafe void Enqueue(T value)
		{
			NativeQueueBlockHeader* ptr = NativeQueueData.AllocateWriteBlockMT<T>(this.m_Buffer, this.m_QueuePool, 0);
			UnsafeUtility.WriteArrayElement<T>((void*)(ptr + 1), ptr->m_NumItems, value);
			ptr->m_NumItems++;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00016B04 File Offset: 0x00014D04
		public T Dequeue()
		{
			T result;
			this.TryDequeue(out result);
			return result;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00016B1C File Offset: 0x00014D1C
		public unsafe bool TryDequeue(out T item)
		{
			NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_Buffer->m_FirstBlock);
			if (ptr == null)
			{
				item = default(T);
				return false;
			}
			NativeQueueData* buffer = this.m_Buffer;
			int currentRead = buffer->m_CurrentRead;
			buffer->m_CurrentRead = currentRead + 1;
			int index = currentRead;
			item = UnsafeUtility.ReadArrayElement<T>((void*)(ptr + 1), index);
			if (this.m_Buffer->m_CurrentRead >= ptr->m_NumItems)
			{
				this.m_Buffer->m_CurrentRead = 0;
				this.m_Buffer->m_FirstBlock = (IntPtr)((void*)ptr->m_NextBlock);
				if (this.m_Buffer->m_FirstBlock == IntPtr.Zero)
				{
					this.m_Buffer->m_LastBlock = IntPtr.Zero;
				}
				for (int i = 0; i < 128; i++)
				{
					if (this.m_Buffer->GetCurrentWriteBlockTLS(i) == ptr)
					{
						this.m_Buffer->SetCurrentWriteBlockTLS(i, null);
					}
				}
				this.m_QueuePool->FreeBlock(ptr);
			}
			return true;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00016C0C File Offset: 0x00014E0C
		public unsafe NativeArray<T> ToArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_Buffer->m_FirstBlock);
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Count, allocator, NativeArrayOptions.ClearMemory);
			NativeQueueBlockHeader* ptr2 = ptr;
			byte* unsafePtr = (byte*)nativeArray.GetUnsafePtr<T>();
			int num = UnsafeUtility.SizeOf<T>();
			int num2 = 0;
			int num3 = this.m_Buffer->m_CurrentRead * num;
			int num4 = this.m_Buffer->m_CurrentRead;
			while (ptr2 != null)
			{
				int num5 = (ptr2->m_NumItems - num4) * num;
				UnsafeUtility.MemCpy((void*)(unsafePtr + num2), (void*)(ptr2 + 1 + num3 / sizeof(NativeQueueBlockHeader)), (long)num5);
				num4 = (num3 = 0);
				num2 += num5;
				ptr2 = ptr2->m_NextBlock;
			}
			return nativeArray;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00016CAC File Offset: 0x00014EAC
		public unsafe void Clear()
		{
			NativeQueueBlockHeader* nextBlock;
			for (NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_Buffer->m_FirstBlock); ptr != null; ptr = nextBlock)
			{
				nextBlock = ptr->m_NextBlock;
				this.m_QueuePool->FreeBlock(ptr);
			}
			this.m_Buffer->m_FirstBlock = IntPtr.Zero;
			this.m_Buffer->m_LastBlock = IntPtr.Zero;
			this.m_Buffer->m_CurrentRead = 0;
			for (int i = 0; i < 128; i++)
			{
				this.m_Buffer->SetCurrentWriteBlockTLS(i, null);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00016D2E File Offset: 0x00014F2E
		public bool IsCreated
		{
			get
			{
				return this.m_Buffer != null;
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00016D3D File Offset: 0x00014F3D
		public void Dispose()
		{
			NativeQueueData.DeallocateQueue(this.m_Buffer, this.m_QueuePool, this.m_AllocatorLabel);
			this.m_Buffer = null;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00016D60 File Offset: 0x00014F60
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			JobHandle result = new NativeQueueDisposeJob
			{
				Data = new NativeQueueDispose
				{
					m_Buffer = this.m_Buffer,
					m_QueuePool = this.m_QueuePool,
					m_AllocatorLabel = this.m_AllocatorLabel
				}
			}.Schedule(inputDeps);
			this.m_Buffer = null;
			return result;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00016DBC File Offset: 0x00014FBC
		public NativeQueue<T>.ParallelWriter AsParallelWriter()
		{
			NativeQueue<T>.ParallelWriter result;
			result.m_Buffer = this.m_Buffer;
			result.m_QueuePool = this.m_QueuePool;
			result.m_ThreadIndex = 0;
			return result;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00016DEC File Offset: 0x00014FEC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private unsafe void CheckReadNotEmpty()
		{
			this.m_Buffer->m_FirstBlock == (IntPtr)0;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite()
		{
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00016E05 File Offset: 0x00015005
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void ThrowEmpty()
		{
			throw new InvalidOperationException("Trying to read from an empty queue.");
		}

		// Token: 0x04000292 RID: 658
		[NativeDisableUnsafePtrRestriction]
		private unsafe NativeQueueData* m_Buffer;

		// Token: 0x04000293 RID: 659
		[NativeDisableUnsafePtrRestriction]
		private unsafe NativeQueueBlockPoolData* m_QueuePool;

		// Token: 0x04000294 RID: 660
		private AllocatorManager.AllocatorHandle m_AllocatorLabel;

		// Token: 0x020000AC RID: 172
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ParallelWriter
		{
			// Token: 0x06000707 RID: 1799 RVA: 0x00016E14 File Offset: 0x00015014
			public unsafe void Enqueue(T value)
			{
				NativeQueueBlockHeader* ptr = NativeQueueData.AllocateWriteBlockMT<T>(this.m_Buffer, this.m_QueuePool, this.m_ThreadIndex);
				UnsafeUtility.WriteArrayElement<T>((void*)(ptr + 1), ptr->m_NumItems, value);
				ptr->m_NumItems++;
			}

			// Token: 0x04000295 RID: 661
			[NativeDisableUnsafePtrRestriction]
			internal unsafe NativeQueueData* m_Buffer;

			// Token: 0x04000296 RID: 662
			[NativeDisableUnsafePtrRestriction]
			internal unsafe NativeQueueBlockPoolData* m_QueuePool;

			// Token: 0x04000297 RID: 663
			[NativeSetThreadIndex]
			internal int m_ThreadIndex;
		}
	}
}
