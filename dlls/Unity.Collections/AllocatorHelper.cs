using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x0200001C RID: 28
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(AllocatorManager.AllocatorHandle)
	})]
	public struct AllocatorHelper<[IsUnmanaged] T> : IDisposable where T : struct, ValueType, AllocatorManager.IAllocator
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000030D2 File Offset: 0x000012D2
		public unsafe ref T Allocator
		{
			get
			{
				return UnsafeUtility.AsRef<T>((void*)this.m_allocator);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000030E0 File Offset: 0x000012E0
		[NotBurstCompatible]
		public unsafe AllocatorHelper(AllocatorManager.AllocatorHandle backingAllocator)
		{
			ref T output = ref AllocatorManager.CreateAllocator<T>(backingAllocator);
			this.m_allocator = (T*)UnsafeUtility.AddressOf<T>(ref output);
			this.m_backingAllocator = backingAllocator;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003107 File Offset: 0x00001307
		[NotBurstCompatible]
		public unsafe void Dispose()
		{
			UnsafeUtility.AsRef<T>((void*)this.m_allocator).DestroyAllocator(this.m_backingAllocator);
		}

		// Token: 0x04000067 RID: 103
		private unsafe readonly T* m_allocator;

		// Token: 0x04000068 RID: 104
		private AllocatorManager.AllocatorHandle m_backingAllocator;
	}
}
