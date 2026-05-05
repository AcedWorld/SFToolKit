using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000A6 RID: 166
	[BurstCompatible]
	public static class NativeMultiHashMapExtensions
	{
		// Token: 0x060006E6 RID: 1766 RVA: 0x000165B8 File Offset: 0x000147B8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int),
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal static void Initialize<TKey, TValue, [IsUnmanaged] U>(this NativeMultiHashMap<TKey, TValue> nativeMultiHashMap, int capacity, ref U allocator, int disposeSentinelStackDepth = 2) where TKey : struct, IEquatable<TKey> where TValue : struct where U : struct, ValueType, AllocatorManager.IAllocator
		{
			nativeMultiHashMap.m_MultiHashMapData = new UnsafeMultiHashMap<TKey, TValue>(capacity, allocator.Handle);
		}
	}
}
