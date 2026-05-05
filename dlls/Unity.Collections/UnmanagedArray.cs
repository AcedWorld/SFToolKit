using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x020000C3 RID: 195
	internal struct UnmanagedArray<[IsUnmanaged] T> : IDisposable where T : struct, ValueType
	{
		// Token: 0x06000808 RID: 2056 RVA: 0x00018FFE File Offset: 0x000171FE
		public unsafe UnmanagedArray(int length, AllocatorManager.AllocatorHandle allocator)
		{
			this.m_pointer = (IntPtr)((void*)Memory.Unmanaged.Array.Allocate<T>((long)length, allocator));
			this.m_length = length;
			this.m_allocator = allocator;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00019021 File Offset: 0x00017221
		public unsafe void Dispose()
		{
			Memory.Unmanaged.Free<T>((T*)((void*)this.m_pointer), Allocator.Persistent);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00019039 File Offset: 0x00017239
		public unsafe T* GetUnsafePointer()
		{
			return (T*)((void*)this.m_pointer);
		}

		// Token: 0x170000DB RID: 219
		public unsafe T this[int index]
		{
			get
			{
				return ref *(T*)((byte*)((void*)this.m_pointer) + (IntPtr)index * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x040002C3 RID: 707
		private IntPtr m_pointer;

		// Token: 0x040002C4 RID: 708
		private int m_length;

		// Token: 0x040002C5 RID: 709
		private AllocatorManager.AllocatorHandle m_allocator;
	}
}
