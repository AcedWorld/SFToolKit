using System;
using System.Diagnostics;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x02000031 RID: 49
	[BurstCompatible]
	internal struct FixedList
	{
		// Token: 0x0600010B RID: 267 RVA: 0x000043F6 File Offset: 0x000025F6
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		internal static int PaddingBytes<T>() where T : struct
		{
			return math.max(0, math.min(6, (1 << math.tzcnt(UnsafeUtility.SizeOf<T>())) - 2));
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00004415 File Offset: 0x00002615
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		internal static int StorageBytes<BUFFER, T>() where BUFFER : struct where T : struct
		{
			return UnsafeUtility.SizeOf<BUFFER>() - FixedList.PaddingBytes<T>();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004422 File Offset: 0x00002622
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		internal static int Capacity<BUFFER, T>() where BUFFER : struct where T : struct
		{
			return FixedList.StorageBytes<BUFFER, T>() / UnsafeUtility.SizeOf<T>();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00004430 File Offset: 0x00002630
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckResize<BUFFER, T>(int newLength) where BUFFER : struct where T : struct
		{
			int num = FixedList.Capacity<BUFFER, T>();
			if (newLength < 0 || newLength > num)
			{
				throw new IndexOutOfRangeException(string.Format("NewLength {0} is out of range of '{1}' Capacity.", newLength, num));
			}
		}
	}
}
