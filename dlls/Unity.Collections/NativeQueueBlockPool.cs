using System;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000A9 RID: 169
	internal class NativeQueueBlockPool
	{
		// Token: 0x060006E9 RID: 1769 RVA: 0x000166E8 File Offset: 0x000148E8
		internal unsafe static NativeQueueBlockPoolData* GetQueueBlockPool()
		{
			NativeQueueBlockPoolData** unsafeDataPointer = (NativeQueueBlockPoolData**)NativeQueueBlockPool.Data.UnsafeDataPointer;
			NativeQueueBlockPoolData* ptr = *(IntPtr*)unsafeDataPointer;
			if (ptr == null)
			{
				ptr = (NativeQueueBlockPoolData*)Memory.Unmanaged.Allocate((long)UnsafeUtility.SizeOf<NativeQueueBlockPoolData>(), 8, Allocator.Persistent);
				*(IntPtr*)unsafeDataPointer = ptr;
				ptr->m_NumBlocks = (ptr->m_MaxBlocks = 256);
				ptr->m_AllocLock = 0;
				NativeQueueBlockHeader* ptr2 = null;
				for (int i = 0; i < ptr->m_MaxBlocks; i++)
				{
					NativeQueueBlockHeader* ptr3 = (NativeQueueBlockHeader*)Memory.Unmanaged.Allocate(16384L, 16, Allocator.Persistent);
					ptr3->m_NextBlock = ptr2;
					ptr2 = ptr3;
				}
				ptr->m_FirstBlock = (IntPtr)((void*)ptr2);
				NativeQueueBlockPool.AppDomainOnDomainUnload();
			}
			return ptr;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00016783 File Offset: 0x00014983
		[BurstDiscard]
		private static void AppDomainOnDomainUnload()
		{
			AppDomain.CurrentDomain.DomainUnload += NativeQueueBlockPool.OnDomainUnload;
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001679C File Offset: 0x0001499C
		private unsafe static void OnDomainUnload(object sender, EventArgs e)
		{
			NativeQueueBlockPoolData** unsafeDataPointer = (NativeQueueBlockPoolData**)NativeQueueBlockPool.Data.UnsafeDataPointer;
			NativeQueueBlockPoolData* ptr = *(IntPtr*)unsafeDataPointer;
			while (ptr->m_FirstBlock != IntPtr.Zero)
			{
				NativeQueueBlockHeader* ptr2 = (NativeQueueBlockHeader*)((void*)ptr->m_FirstBlock);
				ptr->m_FirstBlock = (IntPtr)((void*)ptr2->m_NextBlock);
				Memory.Unmanaged.Free<NativeQueueBlockHeader>(ptr2, Allocator.Persistent);
				ptr->m_NumBlocks--;
			}
			Memory.Unmanaged.Free<NativeQueueBlockPoolData>(ptr, Allocator.Persistent);
			*(IntPtr*)unsafeDataPointer = (IntPtr)((UIntPtr)0);
		}

		// Token: 0x0400028C RID: 652
		private static readonly SharedStatic<IntPtr> Data = SharedStatic<IntPtr>.GetOrCreateUnsafe(0U, -1167712759576517144L, 0L);
	}
}
