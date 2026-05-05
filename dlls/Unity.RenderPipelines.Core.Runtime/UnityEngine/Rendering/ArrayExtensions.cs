using System;
using Unity.Collections;
using UnityEngine.Jobs;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C4 RID: 196
	public static class ArrayExtensions
	{
		// Token: 0x0600061B RID: 1563 RVA: 0x0001EFCC File Offset: 0x0001D1CC
		public static void ResizeArray<T>(this NativeArray<T> array, int capacity) where T : struct
		{
			NativeArray<T> nativeArray = new NativeArray<T>(capacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			if (array.IsCreated)
			{
				NativeArray<T>.Copy(array, nativeArray, array.Length);
				array.Dispose();
			}
			array = nativeArray;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0001F00C File Offset: 0x0001D20C
		public static void ResizeArray(this TransformAccessArray array, int capacity)
		{
			TransformAccessArray transformAccessArray = new TransformAccessArray(capacity, -1);
			if (array.isCreated)
			{
				for (int i = 0; i < array.length; i++)
				{
					transformAccessArray.Add(array[i]);
				}
				array.Dispose();
			}
			array = transformAccessArray;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001F056 File Offset: 0x0001D256
		public static void ResizeArray<T>(ref T[] array, int capacity)
		{
			if (array == null)
			{
				array = new T[capacity];
				return;
			}
			Array.Resize<T>(ref array, capacity);
		}
	}
}
