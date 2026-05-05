using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000067 RID: 103
	internal class Multimap<TKey, TValue> : IDictionary<TKey, IList<TValue>>, ICollection<KeyValuePair<TKey, IList<TValue>>>, IEnumerable<KeyValuePair<TKey, IList<TValue>>>, IEnumerable
	{
		// Token: 0x1700009A RID: 154
		public IList<TValue> this[TKey key]
		{
			get
			{
				return this._dictionary[key];
			}
			set
			{
				this._dictionary[key] = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000074A8 File Offset: 0x000056A8
		public ICollection<TKey> Keys
		{
			get
			{
				return this._dictionary.Keys;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000074B5 File Offset: 0x000056B5
		public ICollection<IList<TValue>> Values
		{
			get
			{
				return this._dictionary.Values;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x000074C2 File Offset: 0x000056C2
		public int Count
		{
			get
			{
				return this._dictionary.Count;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x000074CF File Offset: 0x000056CF
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x000074D2 File Offset: 0x000056D2
		public Multimap()
		{
			this._dictionary = new Dictionary<TKey, IList<TValue>>();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000074E5 File Offset: 0x000056E5
		public Multimap(IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, IList<TValue>>(comparer);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000074F9 File Offset: 0x000056F9
		public IEnumerator<KeyValuePair<TKey, IList<TValue>>> GetEnumerator()
		{
			return this._dictionary.GetEnumerator();
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000750B File Offset: 0x0000570B
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._dictionary.GetEnumerator();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000751D File Offset: 0x0000571D
		public void Add(KeyValuePair<TKey, IList<TValue>> item)
		{
			if (!this.TryAdd(item.Key, item.Value))
			{
				throw new InvalidOperationException("Could not add values to Multimap.");
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00007540 File Offset: 0x00005740
		public void Add(Multimap<TKey, TValue> multimap)
		{
			foreach (KeyValuePair<TKey, IList<TValue>> keyValuePair in multimap)
			{
				if (!this.TryAdd(keyValuePair.Key, keyValuePair.Value))
				{
					throw new InvalidOperationException("Could not add values to Multimap.");
				}
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x000075A4 File Offset: 0x000057A4
		public void Clear()
		{
			this._dictionary.Clear();
		}

		// Token: 0x060002DF RID: 735 RVA: 0x000075B1 File Offset: 0x000057B1
		public bool Contains(KeyValuePair<TKey, IList<TValue>> item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000075B8 File Offset: 0x000057B8
		public void CopyTo(KeyValuePair<TKey, IList<TValue>>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000075BF File Offset: 0x000057BF
		public bool Remove(KeyValuePair<TKey, IList<TValue>> item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000075C8 File Offset: 0x000057C8
		public void Add(TKey key, IList<TValue> value)
		{
			if (value != null && value.Count > 0)
			{
				IList<TValue> list;
				if (this._dictionary.TryGetValue(key, out list))
				{
					using (IEnumerator<TValue> enumerator = value.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							TValue item = enumerator.Current;
							list.Add(item);
						}
						return;
					}
				}
				list = new List<TValue>(value);
				if (!this.TryAdd(key, list))
				{
					throw new InvalidOperationException("Could not add values to Multimap.");
				}
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00007648 File Offset: 0x00005848
		public bool ContainsKey(TKey key)
		{
			return this._dictionary.ContainsKey(key);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00007658 File Offset: 0x00005858
		public bool Remove(TKey key)
		{
			IList<TValue> list;
			return this.TryRemove(key, out list);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000766E File Offset: 0x0000586E
		public bool TryGetValue(TKey key, out IList<TValue> value)
		{
			return this._dictionary.TryGetValue(key, out value);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000767D File Offset: 0x0000587D
		public void CopyTo(Array array, int index)
		{
			((ICollection)this._dictionary).CopyTo(array, index);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000768C File Offset: 0x0000588C
		public void Add(TKey key, TValue value)
		{
			if (value != null)
			{
				IList<TValue> list;
				if (this._dictionary.TryGetValue(key, out list))
				{
					list.Add(value);
					return;
				}
				list = new List<TValue>
				{
					value
				};
				if (!this.TryAdd(key, list))
				{
					throw new InvalidOperationException("Could not add value to Multimap.");
				}
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000076DB File Offset: 0x000058DB
		private bool TryRemove(TKey key, out IList<TValue> value)
		{
			this._dictionary.TryGetValue(key, out value);
			return this._dictionary.Remove(key);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x000076F8 File Offset: 0x000058F8
		private bool TryAdd(TKey key, IList<TValue> value)
		{
			try
			{
				this._dictionary.Add(key, value);
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0400014B RID: 331
		private readonly Dictionary<TKey, IList<TValue>> _dictionary;
	}
}
