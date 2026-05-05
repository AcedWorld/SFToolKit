using System;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000AA RID: 170
	[BurstCompatible]
	internal struct NativeQueueData
	{
		// Token: 0x060006EE RID: 1774 RVA: 0x00016830 File Offset: 0x00014A30
		internal unsafe NativeQueueBlockHeader* GetCurrentWriteBlockTLS(int threadIndex)
		{
			NativeQueueBlockHeader** ptr = (NativeQueueBlockHeader**)(this.m_CurrentWriteBlockTLS + threadIndex * 64);
			return *(IntPtr*)ptr;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001684C File Offset: 0x00014A4C
		internal unsafe void SetCurrentWriteBlockTLS(int threadIndex, NativeQueueBlockHeader* currentWriteBlock)
		{
			NativeQueueBlockHeader** ptr = (NativeQueueBlockHeader**)(this.m_CurrentWriteBlockTLS + threadIndex * 64);
			*(IntPtr*)ptr = currentWriteBlock;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001686C File Offset: 0x00014A6C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static NativeQueueBlockHeader* AllocateWriteBlockMT<T>(NativeQueueData* data, NativeQueueBlockPoolData* pool, int threadIndex) where T : struct
		{
			NativeQueueBlockHeader* ptr = data->GetCurrentWriteBlockTLS(threadIndex);
			if (ptr != null && ptr->m_NumItems == data->m_MaxItems)
			{
				ptr = null;
			}
			if (ptr == null)
			{
				ptr = pool->AllocateBlock();
				ptr->m_NextBlock = null;
				ptr->m_NumItems = 0;
				NativeQueueBlockHeader* ptr2 = (NativeQueueBlockHeader*)((void*)Interlocked.Exchange(ref data->m_LastBlock, (IntPtr)((void*)ptr)));
				if (ptr2 == null)
				{
					data->m_FirstBlock = (IntPtr)((void*)ptr);
				}
				else
				{
					ptr2->m_NextBlock = ptr;
				}
				data->SetCurrentWriteBlockTLS(threadIndex, ptr);
			}
			return ptr;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000168EC File Offset: 0x00014AEC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void AllocateQueue<T>(AllocatorManager.AllocatorHandle label, out NativeQueueData* outBuf) where T : struct
		{
			int num = CollectionHelper.Align(UnsafeUtility.SizeOf<NativeQueueData>(), 64);
			NativeQueueData* ptr = (NativeQueueData*)Memory.Unmanaged.Allocate((long)(num + 8192), 64, label);
			ptr->m_CurrentWriteBlockTLS = (byte*)(ptr + num / sizeof(NativeQueueData));
			ptr->m_FirstBlock = IntPtr.Zero;
			ptr->m_LastBlock = IntPtr.Zero;
			ptr->m_MaxItems = (16384 - UnsafeUtility.SizeOf<NativeQueueBlockHeader>()) / UnsafeUtility.SizeOf<T>();
			ptr->m_CurrentRead = 0;
			for (int i = 0; i < 128; i++)
			{
				ptr->SetCurrentWriteBlockTLS(i, null);
			}
			outBuf = ptr;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00016970 File Offset: 0x00014B70
		public unsafe static void DeallocateQueue(NativeQueueData* data, NativeQueueBlockPoolData* pool, AllocatorManager.AllocatorHandle allocation)
		{
			NativeQueueBlockHeader* nextBlock;
			for (NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)data->m_FirstBlock); ptr != null; ptr = nextBlock)
			{
				nextBlock = ptr->m_NextBlock;
				pool->FreeBlock(ptr);
			}
			Memory.Unmanaged.Free<NativeQueueData>(data, allocation);
		}

		// Token: 0x0400028D RID: 653
		public IntPtr m_FirstBlock;

		// Token: 0x0400028E RID: 654
		public IntPtr m_LastBlock;

		// Token: 0x0400028F RID: 655
		public int m_MaxItems;

		// Token: 0x04000290 RID: 656
		public int m_CurrentRead;

		// Token: 0x04000291 RID: 657
		public unsafe byte* m_CurrentWriteBlockTLS;
	}
}
