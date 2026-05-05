using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000014 RID: 20
	public class DebugDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection
	{
		// Token: 0x1700000F RID: 15
		public TValue this[TKey key]
		{
			get
			{
				return this.dictionary[key];
			}
			set
			{
				this.Debug(string.Format("Set: {0} => {1}", key, value));
				this.dictionary[key] = value;
			}
		}

		// Token: 0x17000010 RID: 16
		object IDictionary.this[object key]
		{
			get
			{
				return this[(TKey)((object)key)];
			}
			set
			{
				this[(TKey)((object)key)] = (TValue)((object)value);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002CD2 File Offset: 0x00000ED2
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002CDA File Offset: 0x00000EDA
		public string label { get; set; } = "Dictionary";

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002CE3 File Offset: 0x00000EE3
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002CEB File Offset: 0x00000EEB
		public bool debug { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public int Count
		{
			get
			{
				return this.dictionary.Count;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002D01 File Offset: 0x00000F01
		object ICollection.SyncRoot
		{
			get
			{
				return ((ICollection)this.dictionary).SyncRoot;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002D0E File Offset: 0x00000F0E
		bool ICollection.IsSynchronized
		{
			get
			{
				return ((ICollection)this.dictionary).IsSynchronized;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002D1B File Offset: 0x00000F1B
		ICollection IDictionary.Values
		{
			get
			{
				return ((IDictionary)this.dictionary).Values;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002D28 File Offset: 0x00000F28
		bool IDictionary.IsReadOnly
		{
			get
			{
				return ((IDictionary)this.dictionary).IsReadOnly;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002D35 File Offset: 0x00000F35
		bool IDictionary.IsFixedSize
		{
			get
			{
				return ((IDictionary)this.dictionary).IsFixedSize;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002D42 File Offset: 0x00000F42
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			get
			{
				return ((ICollection<KeyValuePair<!0, !1>>)this.dictionary).IsReadOnly;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002D4F File Offset: 0x00000F4F
		public ICollection<TKey> Keys
		{
			get
			{
				return this.dictionary.Keys;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002D5C File Offset: 0x00000F5C
		ICollection IDictionary.Keys
		{
			get
			{
				return ((IDictionary)this.dictionary).Keys;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002D69 File Offset: 0x00000F69
		public ICollection<TValue> Values
		{
			get
			{
				return this.dictionary.Values;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002D76 File Offset: 0x00000F76
		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection)this.dictionary).CopyTo(array, index);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002D85 File Offset: 0x00000F85
		private void Debug(string message)
		{
			if (!this.debug)
			{
				return;
			}
			if (!string.IsNullOrEmpty(this.label))
			{
				message = "[" + this.label + "] " + message;
			}
			UnityEngine.Debug.Log(message + "\n");
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002DC5 File Offset: 0x00000FC5
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.dictionary).GetEnumerator();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002DD2 File Offset: 0x00000FD2
		void IDictionary.Remove(object key)
		{
			this.Remove((TKey)((object)key));
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002DE1 File Offset: 0x00000FE1
		bool IDictionary.Contains(object key)
		{
			return this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002DEF File Offset: 0x00000FEF
		void IDictionary.Add(object key, object value)
		{
			this.Add((TKey)((object)key), (TValue)((object)value));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002E03 File Offset: 0x00001003
		public void Clear()
		{
			this.Debug("Clear");
			this.dictionary.Clear();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002E1B File Offset: 0x0000101B
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)this.dictionary).GetEnumerator();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002E28 File Offset: 0x00001028
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return this.dictionary.Contains(item);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002E36 File Offset: 0x00001036
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> item)
		{
			((ICollection<KeyValuePair<!0, !1>>)this.dictionary).Add(item);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002E44 File Offset: 0x00001044
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<!0, !1>>)this.dictionary).CopyTo(array, arrayIndex);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002E53 File Offset: 0x00001053
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<!0, !1>>)this.dictionary).Remove(item);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002E61 File Offset: 0x00001061
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.dictionary.GetEnumerator();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002E73 File Offset: 0x00001073
		public bool ContainsKey(TKey key)
		{
			return this.dictionary.ContainsKey(key);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002E81 File Offset: 0x00001081
		public void Add(TKey key, TValue value)
		{
			this.Debug(string.Format("Add: {0} => {1}", key, value));
			this.dictionary.Add(key, value);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002EAC File Offset: 0x000010AC
		public bool Remove(TKey key)
		{
			this.Debug(string.Format("Remove: {0}", key));
			return this.dictionary.Remove(key);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002ED0 File Offset: 0x000010D0
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.dictionary.TryGetValue(key, out value);
		}

		// Token: 0x04000013 RID: 19
		private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
	}
}
