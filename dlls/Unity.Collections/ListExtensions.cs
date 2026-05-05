using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000086 RID: 134
	public static class ListExtensions
	{
		// Token: 0x060005D1 RID: 1489 RVA: 0x000144BC File Offset: 0x000126BC
		public static bool RemoveSwapBack<T>(this List<T> list, T value)
		{
			int num = list.IndexOf(value);
			if (num < 0)
			{
				return false;
			}
			list.RemoveAtSwapBack(num);
			return true;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x000144E0 File Offset: 0x000126E0
		public static bool RemoveSwapBack<T>(this List<T> list, Predicate<T> matcher)
		{
			int num = list.FindIndex(matcher);
			if (num < 0)
			{
				return false;
			}
			list.RemoveAtSwapBack(num);
			return true;
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00014504 File Offset: 0x00012704
		public static void RemoveAtSwapBack<T>(this List<T> list, int index)
		{
			int index2 = list.Count - 1;
			list[index] = list[index2];
			list.RemoveAt(index2);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00014530 File Offset: 0x00012730
		public static NativeList<T> ToNativeList<[IsUnmanaged] T>(this List<T> list, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
		{
			NativeList<T> result = new NativeList<T>(list.Count, allocator);
			for (int i = 0; i < list.Count; i++)
			{
				result.AddNoResize(list[i]);
			}
			return result;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001456C File Offset: 0x0001276C
		public static NativeArray<T> ToNativeArray<[IsUnmanaged] T>(this List<T> list, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
		{
			NativeArray<T> result = CollectionHelper.CreateNativeArray<T>(list.Count, allocator, NativeArrayOptions.ClearMemory);
			for (int i = 0; i < list.Count; i++)
			{
				result[i] = list[i];
			}
			return result;
		}
	}
}
