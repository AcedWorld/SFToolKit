using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Utils
{
	// Token: 0x0200048F RID: 1167
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class CollectionTools
	{
		// Token: 0x06002E3E RID: 11838 RVA: 0x000A1FA0 File Offset: 0x000A01A0
		public static Dictionary<TValue, TKey> CreateInverseDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
		{
			if (dict == null)
			{
				return null;
			}
			Dictionary<TValue, TKey> dictionary = new Dictionary<TValue, TKey>();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in dict)
			{
				if (!dictionary.ContainsKey(keyValuePair.Value))
				{
					dictionary.Add(keyValuePair.Value, keyValuePair.Key);
				}
			}
			return dictionary;
		}

		// Token: 0x06002E3F RID: 11839 RVA: 0x000A2018 File Offset: 0x000A0218
		public static TReturn GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key)
		{
			bool flag;
			return CollectionTools.GetDictionaryValueSafe<TReturn>(dictionary, key, out flag);
		}

		// Token: 0x06002E40 RID: 11840 RVA: 0x000A2030 File Offset: 0x000A0230
		public static TReturn GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key, out bool success)
		{
			success = false;
			if (dictionary == null)
			{
				return default(TReturn);
			}
			object obj;
			if (!dictionary.TryGetValue(key, out obj))
			{
				return default(TReturn);
			}
			if (!(obj is TReturn))
			{
				return default(TReturn);
			}
			success = true;
			return (TReturn)((object)obj);
		}

		// Token: 0x06002E41 RID: 11841 RVA: 0x000A2080 File Offset: 0x000A0280
		public static TValue GetDictionaryValueSafe<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key)
		{
			bool flag;
			return CollectionTools.GetDictionaryValueSafe<TKey, TValue>(dictionary, key, out flag);
		}

		// Token: 0x06002E42 RID: 11842 RVA: 0x000A2098 File Offset: 0x000A0298
		public static TValue GetDictionaryValueSafe<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, out bool success)
		{
			success = false;
			if (dictionary == null)
			{
				return default(TValue);
			}
			TValue result;
			if (!dictionary.TryGetValue(key, out result))
			{
				return default(TValue);
			}
			success = true;
			return result;
		}

		// Token: 0x06002E43 RID: 11843 RVA: 0x000A20D0 File Offset: 0x000A02D0
		public static bool GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key, ref TReturn value)
		{
			if (dictionary == null)
			{
				return false;
			}
			object obj;
			if (!dictionary.TryGetValue(key, out obj))
			{
				return false;
			}
			if (obj == null)
			{
				try
				{
					value = (TReturn)((object)obj);
				}
				catch
				{
					return false;
				}
			}
			if (!(obj is TReturn))
			{
				return false;
			}
			value = (TReturn)((object)obj);
			return true;
		}

		// Token: 0x06002E44 RID: 11844 RVA: 0x000A2130 File Offset: 0x000A0330
		public static bool GetDictionaryValueSafe(Dictionary<string, object> dictionary, string key, Type type, ref object value)
		{
			if (dictionary == null || type == null)
			{
				return false;
			}
			object obj;
			if (!dictionary.TryGetValue(key, out obj))
			{
				return false;
			}
			if (obj == null)
			{
				value = obj;
				return true;
			}
			if (!ReflectionTools.DoesTypeImplement(obj.GetType(), type))
			{
				return false;
			}
			value = obj;
			return true;
		}

		// Token: 0x06002E45 RID: 11845 RVA: 0x000A2174 File Offset: 0x000A0374
		public static bool GetDictionaryValueSafe_float(Dictionary<string, object> dictionary, string key, ref float value)
		{
			if (dictionary == null)
			{
				return false;
			}
			object obj;
			if (!dictionary.TryGetValue(key, out obj))
			{
				return false;
			}
			if (obj is float)
			{
				value = (float)obj;
				return true;
			}
			if (obj is int)
			{
				value = (float)((int)obj);
				return true;
			}
			if (obj is double)
			{
				value = (float)((double)obj);
				return true;
			}
			return false;
		}

		// Token: 0x06002E46 RID: 11846 RVA: 0x000A21CC File Offset: 0x000A03CC
		public static bool GetDictionaryValueSafe_int(Dictionary<string, object> dictionary, string key, ref int value)
		{
			if (dictionary == null)
			{
				return false;
			}
			object obj;
			if (!dictionary.TryGetValue(key, out obj))
			{
				return false;
			}
			if (obj is float)
			{
				value = (int)((float)obj);
				return true;
			}
			if (obj is int)
			{
				value = (int)obj;
				return true;
			}
			if (obj is double)
			{
				value = (int)((double)obj);
				return true;
			}
			return false;
		}

		// Token: 0x06002E47 RID: 11847 RVA: 0x000237A9 File Offset: 0x000219A9
		public static void AddValueSafe(Dictionary<string, object> data, string key, object value)
		{
			if (data == null || string.IsNullOrEmpty(key))
			{
				return;
			}
			if (value == null)
			{
				if (data.ContainsKey(key))
				{
					data.Remove(key);
				}
				return;
			}
			if (data.ContainsKey(key))
			{
				data[key] = value;
				return;
			}
			data.Add(key, value);
		}

		// Token: 0x06002E48 RID: 11848 RVA: 0x000A2224 File Offset: 0x000A0424
		public static T GetValue<T>(IEnumerable<T> enumerable, int index)
		{
			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				if (num == index)
				{
					return enumerator.Current;
				}
				num++;
			}
			return default(T);
		}

		// Token: 0x06002E49 RID: 11849 RVA: 0x000A225C File Offset: 0x000A045C
		public static T GetValue<T>(IEnumerable enumerable, int index)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				if (num == index)
				{
					return (T)((object)enumerator.Current);
				}
				num++;
			}
			return default(T);
		}

		// Token: 0x06002E4A RID: 11850 RVA: 0x000A229C File Offset: 0x000A049C
		public static void Enqueue<T>(IObjectPool<T> pool, RingBuffer<T> buffer, T item, out bool overrun)
		{
			int count = buffer.Count;
			int capacity = buffer.Capacity;
			if (count == capacity)
			{
				pool.Return(buffer.Dequeue());
				overrun = true;
			}
			else
			{
				overrun = false;
			}
			buffer.Enqueue(item);
		}

		// Token: 0x06002E4B RID: 11851 RVA: 0x000A22D8 File Offset: 0x000A04D8
		public static void Clear<T>(IObjectPool<T> pool, RingBuffer<T> buffer)
		{
			int count = buffer.Count;
			for (int i = 0; i < count; i++)
			{
				pool.Return(buffer[i]);
			}
			buffer.Clear();
		}
	}
}
