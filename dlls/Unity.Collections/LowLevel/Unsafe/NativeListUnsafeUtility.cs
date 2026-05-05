using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000EC RID: 236
	[BurstCompatible]
	public static class NativeListUnsafeUtility
	{
		// Token: 0x06000943 RID: 2371 RVA: 0x0001D355 File Offset: 0x0001B555
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void* GetUnsafePtr<[IsUnmanaged] T>(this NativeList<T> list) where T : struct, ValueType
		{
			return (void*)list.m_ListData->Ptr;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0001D355 File Offset: 0x0001B555
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void* GetUnsafeReadOnlyPtr<[IsUnmanaged] T>(this NativeList<T> list) where T : struct, ValueType
		{
			return (void*)list.m_ListData->Ptr;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0001D362 File Offset: 0x0001B562
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void* GetInternalListDataPtrUnchecked<[IsUnmanaged] T>(ref NativeList<T> list) where T : struct, ValueType
		{
			return (void*)list.m_ListData;
		}
	}
}
