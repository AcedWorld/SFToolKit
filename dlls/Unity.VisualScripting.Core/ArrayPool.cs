using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000BF RID: 191
	public static class ArrayPool<T>
	{
		// Token: 0x060004BA RID: 1210 RVA: 0x0000A620 File Offset: 0x00008820
		public static T[] New(int length)
		{
			object obj = ArrayPool<T>.@lock;
			T[] result;
			lock (obj)
			{
				if (!ArrayPool<T>.free.ContainsKey(length))
				{
					ArrayPool<T>.free.Add(length, new Stack<T[]>());
				}
				if (ArrayPool<T>.free[length].Count == 0)
				{
					ArrayPool<T>.free[length].Push(new T[length]);
				}
				T[] array = ArrayPool<T>.free[length].Pop();
				ArrayPool<T>.busy.Add(array);
				result = array;
			}
			return result;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000A6C0 File Offset: 0x000088C0
		public static void Free(T[] array)
		{
			object obj = ArrayPool<T>.@lock;
			lock (obj)
			{
				if (!ArrayPool<T>.busy.Contains(array))
				{
					throw new ArgumentException("The array to free is not in use by the pool.", "array");
				}
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = default(T);
				}
				ArrayPool<T>.busy.Remove(array);
				ArrayPool<T>.free[array.Length].Push(array);
			}
		}

		// Token: 0x04000104 RID: 260
		private static readonly object @lock = new object();

		// Token: 0x04000105 RID: 261
		private static readonly Dictionary<int, Stack<T[]>> free = new Dictionary<int, Stack<T[]>>();

		// Token: 0x04000106 RID: 262
		private static readonly HashSet<T[]> busy = new HashSet<T[]>();
	}
}
