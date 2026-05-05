using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000C1 RID: 193
	public static class DictionaryPool<TKey, TValue>
	{
		// Token: 0x060004BF RID: 1215 RVA: 0x0000A7D8 File Offset: 0x000089D8
		public static Dictionary<TKey, TValue> New(Dictionary<TKey, TValue> source = null)
		{
			object obj = DictionaryPool<TKey, TValue>.@lock;
			Dictionary<TKey, TValue> result;
			lock (obj)
			{
				if (DictionaryPool<TKey, TValue>.free.Count == 0)
				{
					DictionaryPool<TKey, TValue>.free.Push(new Dictionary<TKey, TValue>());
				}
				Dictionary<TKey, TValue> dictionary = DictionaryPool<TKey, TValue>.free.Pop();
				DictionaryPool<TKey, TValue>.busy.Add(dictionary);
				if (source != null)
				{
					foreach (KeyValuePair<TKey, TValue> keyValuePair in source)
					{
						dictionary.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
				result = dictionary;
			}
			return result;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000A898 File Offset: 0x00008A98
		public static void Free(Dictionary<TKey, TValue> dictionary)
		{
			object obj = DictionaryPool<TKey, TValue>.@lock;
			lock (obj)
			{
				if (!DictionaryPool<TKey, TValue>.busy.Contains(dictionary))
				{
					throw new ArgumentException("The dictionary to free is not in use by the pool.", "dictionary");
				}
				dictionary.Clear();
				DictionaryPool<TKey, TValue>.busy.Remove(dictionary);
				DictionaryPool<TKey, TValue>.free.Push(dictionary);
			}
		}

		// Token: 0x04000107 RID: 263
		private static readonly object @lock = new object();

		// Token: 0x04000108 RID: 264
		private static readonly Stack<Dictionary<TKey, TValue>> free = new Stack<Dictionary<TKey, TValue>>();

		// Token: 0x04000109 RID: 265
		private static readonly HashSet<Dictionary<TKey, TValue>> busy = new HashSet<Dictionary<TKey, TValue>>();
	}
}
