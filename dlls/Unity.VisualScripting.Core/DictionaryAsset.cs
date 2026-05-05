using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000134 RID: 308
	[IncludeInSettings(false)]
	public sealed class DictionaryAsset : LudiqScriptableObject, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		// Token: 0x1700018B RID: 395
		public object this[string key]
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

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x00025856 File Offset: 0x00023A56
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x0002585E File Offset: 0x00023A5E
		[Serialize]
		public Dictionary<string, object> dictionary { get; private set; } = new Dictionary<string, object>();

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x00025867 File Offset: 0x00023A67
		public int Count
		{
			get
			{
				return this.dictionary.Count;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x00025874 File Offset: 0x00023A74
		public ICollection<string> Keys
		{
			get
			{
				return this.dictionary.Keys;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x00025881 File Offset: 0x00023A81
		public ICollection<object> Values
		{
			get
			{
				return this.dictionary.Values;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0002588E File Offset: 0x00023A8E
		bool ICollection<KeyValuePair<string, object>>.IsReadOnly
		{
			get
			{
				return ((ICollection<KeyValuePair<string, object>>)this.dictionary).IsReadOnly;
			}
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0002589B File Offset: 0x00023A9B
		protected override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();
			if (this.dictionary == null)
			{
				this.dictionary = new Dictionary<string, object>();
			}
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x000258B6 File Offset: 0x00023AB6
		public void Clear()
		{
			this.dictionary.Clear();
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x000258C3 File Offset: 0x00023AC3
		public bool ContainsKey(string key)
		{
			return this.dictionary.ContainsKey(key);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x000258D1 File Offset: 0x00023AD1
		public void Add(string key, object value)
		{
			this.dictionary.Add(key, value);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x000258E0 File Offset: 0x00023AE0
		public void Merge(DictionaryAsset other, bool overwriteExisting = true)
		{
			foreach (string key in other.Keys)
			{
				if (overwriteExisting)
				{
					this.dictionary[key] = other[key];
				}
				else if (!this.dictionary.ContainsKey(key))
				{
					this.dictionary.Add(key, other[key]);
				}
			}
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00025960 File Offset: 0x00023B60
		public bool Remove(string key)
		{
			return this.dictionary.Remove(key);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0002596E File Offset: 0x00023B6E
		public bool TryGetValue(string key, out object value)
		{
			return this.dictionary.TryGetValue(key, out value);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0002597D File Offset: 0x00023B7D
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return this.dictionary.GetEnumerator();
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0002598F File Offset: 0x00023B8F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.dictionary).GetEnumerator();
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0002599C File Offset: 0x00023B9C
		void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
		{
			((ICollection<KeyValuePair<string, object>>)this.dictionary).Add(item);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x000259AA File Offset: 0x00023BAA
		bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
		{
			return ((ICollection<KeyValuePair<string, object>>)this.dictionary).Contains(item);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x000259B8 File Offset: 0x00023BB8
		void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<string, object>>)this.dictionary).CopyTo(array, arrayIndex);
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x000259C7 File Offset: 0x00023BC7
		bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
		{
			return ((ICollection<KeyValuePair<string, object>>)this.dictionary).Remove(item);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x000259D5 File Offset: 0x00023BD5
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}
	}
}
