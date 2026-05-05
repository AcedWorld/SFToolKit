using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000ED RID: 237
	[BurstCompatible]
	public static class NativeReferenceUnsafeUtility
	{
		// Token: 0x06000946 RID: 2374 RVA: 0x0001D36A File Offset: 0x0001B56A
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void* GetUnsafePtr<[IsUnmanaged] T>(this NativeReference<T> reference) where T : struct, ValueType
		{
			return reference.m_Data;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0001D36A File Offset: 0x0001B56A
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void* GetUnsafeReadOnlyPtr<[IsUnmanaged] T>(this NativeReference<T> reference) where T : struct, ValueType
		{
			return reference.m_Data;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0001D36A File Offset: 0x0001B56A
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void* GetUnsafePtrWithoutChecks<[IsUnmanaged] T>(this NativeReference<T> reference) where T : struct, ValueType
		{
			return reference.m_Data;
		}
	}
}
