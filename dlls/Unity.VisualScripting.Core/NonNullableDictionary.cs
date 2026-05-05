using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000022 RID: 34
	public class NonNullableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x00003AEC File Offset: 0x00001CEC
		public NonNullableDictionary()
		{
			this.dictionary = new Dictionary<TKey, TValue>();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00003AFF File Offset: 0x00001CFF
		public NonNullableDictionary(int capacity)
		{
			this.dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003B13 File Offset: 0x00001D13
		public NonNullableDictionary(IEqualityComparer<TKey> comparer)
		{
			this.dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003B27 File Offset: 0x00001D27
		public NonNullableDictionary(IDictionary<TKey, TValue> dictionary)
		{
			this.dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003B3B File Offset: 0x00001D3B
		public NonNullableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			this.dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003B50 File Offset: 0x00001D50
		public NonNullableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			this.dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		// Token: 0x1700002A RID: 42
		public TValue this[TKey key]
		{
			get
			{
				return this.dictionary[key];
			}
			set
			{
				this.dictionary[key] = value;
			}
		}

		// Token: 0x1700002B RID: 43
		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)this.dictionary)[key];
			}
			set
			{
				((IDictionary)this.dictionary)[key] = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00003B9F File Offset: 0x00001D9F
		public int Count
		{
			get
			{
				return this.dictionary.Count;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00003BAC File Offset: 0x00001DAC
		public bool IsSynchronized
		{
			get
			{
				return ((ICollection)this.dictionary).IsSynchronized;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00003BB9 File Offset: 0x00001DB9
		public object SyncRoot
		{
			get
			{
				return ((ICollection)this.dictionary).SyncRoot;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00003BC6 File Offset: 0x00001DC6
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00003BC9 File Offset: 0x00001DC9
		public ICollection<TKey> Keys
		{
			get
			{
				return this.dictionary.Keys;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00003BD6 File Offset: 0x00001DD6
		ICollection IDictionary.Values
		{
			get
			{
				return ((IDictionary)this.dictionary).Values;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00003BE3 File Offset: 0x00001DE3
		ICollection IDictionary.Keys
		{
			get
			{
				return ((IDictionary)this.dictionary).Keys;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public ICollection<TValue> Values
		{
			get
			{
				return this.dictionary.Values;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00003BFD File Offset: 0x00001DFD
		public bool IsFixedSize
		{
			get
			{
				return ((IDictionary)this.dictionary).IsFixedSize;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00003C0A File Offset: 0x00001E0A
		public void CopyTo(Array array, int index)
		{
			((ICollection)this.dictionary).CopyTo(array, index);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00003C19 File Offset: 0x00001E19
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> item)
		{
			((ICollection<KeyValuePair<!0, !1>>)this.dictionary).Add(item);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00003C27 File Offset: 0x00001E27
		public void Add(TKey key, TValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.dictionary.Add(key, value);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003C49 File Offset: 0x00001E49
		public void Add(object key, object value)
		{
			((IDictionary)this.dictionary).Add(key, value);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003C58 File Offset: 0x00001E58
		public void Clear()
		{
			this.dictionary.Clear();
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003C65 File Offset: 0x00001E65
		public bool Contains(object key)
		{
			return ((IDictionary)this.dictionary).Contains(key);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00003C73 File Offset: 0x00001E73
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)this.dictionary).GetEnumerator();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00003C80 File Offset: 0x00001E80
		public void Remove(object key)
		{
			((IDictionary)this.dictionary).Remove(key);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00003C8E File Offset: 0x00001E8E
		bool ICollection<KeyValuePair<!0, !1>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<!0, !1>>)this.dictionary).Contains(item);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00003C9C File Offset: 0x00001E9C
		public bool ContainsKey(TKey key)
		{
			return this.dictionary.ContainsKey(key);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00003CAA File Offset: 0x00001EAA
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<!0, !1>>)this.dictionary).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00003CB9 File Offset: 0x00001EB9
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.dictionary.GetEnumerator();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00003CCB File Offset: 0x00001ECB
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<!0, !1>>)this.dictionary).Remove(item);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00003CD9 File Offset: 0x00001ED9
		public bool Remove(TKey key)
		{
			return this.dictionary.Remove(key);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00003CE7 File Offset: 0x00001EE7
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.dictionary.TryGetValue(key, out value);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00003CF6 File Offset: 0x00001EF6
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.dictionary.GetEnumerator();
		}

		// Token: 0x0400001E RID: 30
		private readonly Dictionary<TKey, TValue> dictionary;
	}
}
