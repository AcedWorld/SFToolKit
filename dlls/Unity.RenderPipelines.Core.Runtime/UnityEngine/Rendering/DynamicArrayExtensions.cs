using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000040 RID: 64
	public static class DynamicArrayExtensions
	{
		// Token: 0x06000255 RID: 597 RVA: 0x0000B3F4 File Offset: 0x000095F4
		private static int Partition<T>(T[] data, int left, int right) where T : IComparable<T>, new()
		{
			T other = data[left];
			left--;
			right++;
			for (;;)
			{
				T t = default(T);
				int num;
				do
				{
					left++;
					t = data[left];
					num = t.CompareTo(other);
				}
				while (num < 0);
				T t2 = default(T);
				do
				{
					right--;
					t2 = data[right];
					num = t2.CompareTo(other);
				}
				while (num > 0);
				if (left >= right)
				{
					break;
				}
				data[right] = t;
				data[left] = t2;
			}
			return right;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000B47C File Offset: 0x0000967C
		private static void QuickSort<T>(T[] data, int left, int right) where T : IComparable<T>, new()
		{
			if (left < right)
			{
				int num = DynamicArrayExtensions.Partition<T>(data, left, right);
				if (num >= 1)
				{
					DynamicArrayExtensions.QuickSort<T>(data, left, num);
				}
				if (num + 1 < right)
				{
					DynamicArrayExtensions.QuickSort<T>(data, num + 1, right);
				}
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000B4B2 File Offset: 0x000096B2
		public static void QuickSort<T>(this DynamicArray<T> array) where T : IComparable<T>, new()
		{
			DynamicArrayExtensions.QuickSort<T>(array, 0, array.size - 1);
			array.BumpVersion();
		}
	}
}
