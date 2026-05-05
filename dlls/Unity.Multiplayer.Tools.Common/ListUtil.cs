using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200001B RID: 27
	internal static class ListUtil
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00002DA0 File Offset: 0x00000FA0
		public static void Resize<T>(this List<T> list, int size, T element = default(T))
		{
			int count = list.Count;
			int num = size - count;
			if (num < 0)
			{
				list.RemoveRange(size, count - size);
				return;
			}
			if (num > 0)
			{
				if (size > list.Capacity)
				{
					list.Capacity = size;
				}
				for (int i = 0; i < num; i++)
				{
					list.Add(element);
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public static void Resize<T>(this List<T> list, int size, Func<T> generator)
		{
			int count = list.Count;
			int num = size - count;
			if (num < 0)
			{
				list.RemoveRange(size, count - size);
				return;
			}
			if (num > 0)
			{
				if (size > list.Capacity)
				{
					list.Capacity = size;
				}
				for (int i = 0; i < num; i++)
				{
					list.Add(generator());
				}
			}
		}
	}
}
