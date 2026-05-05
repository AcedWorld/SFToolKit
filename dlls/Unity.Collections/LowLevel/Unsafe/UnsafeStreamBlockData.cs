using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000120 RID: 288
	[BurstCompatible]
	internal struct UnsafeStreamBlockData
	{
		// Token: 0x06000AD4 RID: 2772 RVA: 0x000221A4 File Offset: 0x000203A4
		internal unsafe UnsafeStreamBlock* Allocate(UnsafeStreamBlock* oldBlock, int threadIndex)
		{
			UnsafeStreamBlock* ptr = (UnsafeStreamBlock*)Memory.Unmanaged.Allocate(4096L, 16, this.Allocator);
			ptr->Next = null;
			if (oldBlock == null)
			{
				ptr->Next = *(IntPtr*)(this.Blocks + (IntPtr)threadIndex * (IntPtr)sizeof(UnsafeStreamBlock*) / (IntPtr)sizeof(UnsafeStreamBlock*));
				*(IntPtr*)(this.Blocks + (IntPtr)threadIndex * (IntPtr)sizeof(UnsafeStreamBlock*) / (IntPtr)sizeof(UnsafeStreamBlock*)) = ptr;
			}
			else
			{
				oldBlock->Next = ptr;
			}
			return ptr;
		}

		// Token: 0x040003B3 RID: 947
		internal const int AllocationSize = 4096;

		// Token: 0x040003B4 RID: 948
		internal AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x040003B5 RID: 949
		internal unsafe UnsafeStreamBlock** Blocks;

		// Token: 0x040003B6 RID: 950
		internal int BlockCount;

		// Token: 0x040003B7 RID: 951
		internal unsafe UnsafeStreamBlock* Free;

		// Token: 0x040003B8 RID: 952
		internal unsafe UnsafeStreamRange* Ranges;

		// Token: 0x040003B9 RID: 953
		internal int RangeCount;
	}
}
