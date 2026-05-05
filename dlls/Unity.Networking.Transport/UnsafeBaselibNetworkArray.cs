using System;
using Unity.Baselib.LowLevel;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Networking.Transport
{
	// Token: 0x02000007 RID: 7
	internal struct UnsafeBaselibNetworkArray : IDisposable
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002300 File Offset: 0x00000500
		public unsafe UnsafeBaselibNetworkArray(int capacity, int typeSize)
		{
			long num = (long)typeSize;
			this.m_BufferPool = new UnsafePtrList<Binding.Baselib_RegisteredNetwork_Buffer>(capacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			Binding.Baselib_Memory_PageSizeInfo* ptr = stackalloc Binding.Baselib_Memory_PageSizeInfo[checked(unchecked((UIntPtr)1) * (UIntPtr)sizeof(Binding.Baselib_Memory_PageSizeInfo))];
			Binding.Baselib_Memory_GetPageSizeInfo(ptr);
			ulong defaultPageSize = ptr->defaultPageSize;
			for (int i = 0; i < capacity; i++)
			{
				ulong pageCount = 1UL;
				if (num > (long)defaultPageSize)
				{
					pageCount = (ulong)math.ceil((double)num / defaultPageSize);
				}
				Binding.Baselib_RegisteredNetwork_Buffer* ptr2 = (Binding.Baselib_RegisteredNetwork_Buffer*)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<Binding.Baselib_RegisteredNetwork_Buffer>(), UnsafeUtility.AlignOf<Binding.Baselib_RegisteredNetwork_Buffer>(), Allocator.Persistent);
				Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
				Binding.Baselib_Memory_PageAllocation baselib_Memory_PageAllocation = Binding.Baselib_Memory_AllocatePages(ptr->defaultPageSize, pageCount, 1UL, Binding.Baselib_Memory_PageState.ReadWrite, &baselib_ErrorState);
				if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
				{
					return;
				}
				UnsafeUtility.MemSet((void*)baselib_Memory_PageAllocation.ptr, 0, (long)(baselib_Memory_PageAllocation.pageCount * baselib_Memory_PageAllocation.pageSize));
				*ptr2 = Binding.Baselib_RegisteredNetwork_Buffer_Register(baselib_Memory_PageAllocation, &baselib_ErrorState);
				if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
				{
					Binding.Baselib_Memory_ReleasePages(baselib_Memory_PageAllocation, &baselib_ErrorState);
					*ptr2 = default(Binding.Baselib_RegisteredNetwork_Buffer);
				}
				this.m_BufferPool.Add((void*)ptr2);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002400 File Offset: 0x00000600
		public unsafe void Dispose()
		{
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			for (int i = 0; i < this.m_BufferPool.Length; i++)
			{
				Binding.Baselib_RegisteredNetwork_Buffer* ptr = this.m_BufferPool[i];
				Binding.Baselib_Memory_PageAllocation allocation = ptr->allocation;
				Binding.Baselib_RegisteredNetwork_Buffer_Deregister(*ptr);
				Binding.Baselib_Memory_ReleasePages(allocation, &baselib_ErrorState);
				UnsafeUtility.Free((void*)ptr, Allocator.Persistent);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002458 File Offset: 0x00000658
		public unsafe Binding.Baselib_RegisteredNetwork_BufferSlice AtIndexAsSlice(int index, uint elementSize)
		{
			uint offset = 0U;
			Binding.Baselib_RegisteredNetwork_Buffer* ptr = null;
			ptr = this.m_BufferPool[index];
			IntPtr data = (IntPtr)((void*)ptr->allocation.ptr);
			Binding.Baselib_RegisteredNetwork_BufferSlice result;
			result.id = ptr->id;
			result.data = data;
			result.offset = offset;
			result.size = elementSize;
			return result;
		}

		// Token: 0x04000006 RID: 6
		[NativeDisableUnsafePtrRestriction]
		private UnsafePtrList<Binding.Baselib_RegisteredNetwork_Buffer> m_BufferPool;
	}
}
