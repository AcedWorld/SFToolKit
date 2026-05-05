using System;
using System.Threading;

namespace Unity.Collections
{
	// Token: 0x020000A8 RID: 168
	[BurstCompatible]
	internal struct NativeQueueBlockPoolData
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x000165D4 File Offset: 0x000147D4
		public unsafe NativeQueueBlockHeader* AllocateBlock()
		{
			while (Interlocked.CompareExchange(ref this.m_AllocLock, 1, 0) != 0)
			{
			}
			NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_FirstBlock);
			NativeQueueBlockHeader* ptr2;
			for (;;)
			{
				ptr2 = ptr;
				if (ptr2 == null)
				{
					break;
				}
				ptr = (NativeQueueBlockHeader*)((void*)Interlocked.CompareExchange(ref this.m_FirstBlock, (IntPtr)((void*)ptr2->m_NextBlock), (IntPtr)((void*)ptr2)));
				if (ptr == ptr2)
				{
					goto Block_2;
				}
			}
			Interlocked.Exchange(ref this.m_AllocLock, 0);
			Interlocked.Increment(ref this.m_NumBlocks);
			return (NativeQueueBlockHeader*)Memory.Unmanaged.Allocate(16384L, 16, Allocator.Persistent);
			Block_2:
			Interlocked.Exchange(ref this.m_AllocLock, 0);
			return ptr2;
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00016668 File Offset: 0x00014868
		public unsafe void FreeBlock(NativeQueueBlockHeader* block)
		{
			if (this.m_NumBlocks > this.m_MaxBlocks)
			{
				if (Interlocked.Decrement(ref this.m_NumBlocks) + 1 > this.m_MaxBlocks)
				{
					Memory.Unmanaged.Free<NativeQueueBlockHeader>(block, Allocator.Persistent);
					return;
				}
				Interlocked.Increment(ref this.m_NumBlocks);
			}
			NativeQueueBlockHeader* ptr = (NativeQueueBlockHeader*)((void*)this.m_FirstBlock);
			NativeQueueBlockHeader* ptr2;
			do
			{
				ptr2 = ptr;
				block->m_NextBlock = ptr;
				ptr = (NativeQueueBlockHeader*)((void*)Interlocked.CompareExchange(ref this.m_FirstBlock, (IntPtr)((void*)block), (IntPtr)((void*)ptr)));
			}
			while (ptr != ptr2);
		}

		// Token: 0x04000287 RID: 647
		internal IntPtr m_FirstBlock;

		// Token: 0x04000288 RID: 648
		internal int m_NumBlocks;

		// Token: 0x04000289 RID: 649
		internal int m_MaxBlocks;

		// Token: 0x0400028A RID: 650
		internal const int m_BlockSize = 16384;

		// Token: 0x0400028B RID: 651
		internal int m_AllocLock;
	}
}
