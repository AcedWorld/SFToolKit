using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004E1 RID: 1249
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>
	{
		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x0600322A RID: 12842 RVA: 0x000267A6 File Offset: 0x000249A6
		public int Count
		{
			get
			{
				return this._count - this.ehxOMXoMHhgjHvbnoCLKgUEnwrAY;
			}
		}

		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x0600322B RID: 12843 RVA: 0x000267B5 File Offset: 0x000249B5
		public int TotalCount
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x0600322C RID: 12844 RVA: 0x000267BD File Offset: 0x000249BD
		public ADictionary<TKey, TValue>.KeyCollection Keys
		{
			get
			{
				if (this.DUdVJilVGeMWjLRgzlXRqMgpVOhi == null)
				{
					this.DUdVJilVGeMWjLRgzlXRqMgpVOhi = new ADictionary<TKey, TValue>.KeyCollection(this);
				}
				return this.DUdVJilVGeMWjLRgzlXRqMgpVOhi;
			}
		}

		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x0600322D RID: 12845 RVA: 0x000267D9 File Offset: 0x000249D9
		public ADictionary<TKey, TValue>.ValueCollection Values
		{
			get
			{
				if (this.WCwuEtGqIFRmlcOiTXONHjOKDnvt == null)
				{
					this.WCwuEtGqIFRmlcOiTXONHjOKDnvt = new ADictionary<TKey, TValue>.ValueCollection(this);
				}
				return this.WCwuEtGqIFRmlcOiTXONHjOKDnvt;
			}
		}

		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x0600322E RID: 12846 RVA: 0x000267F5 File Offset: 0x000249F5
		// (set) Token: 0x0600322F RID: 12847 RVA: 0x000267FD File Offset: 0x000249FD
		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return this.nPXlLMKiZMONUWKiYNbBVRNqPyNA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				this.nPXlLMKiZMONUWKiYNbBVRNqPyNA = value;
			}
		}

		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x06003230 RID: 12848 RVA: 0x00026810 File Offset: 0x00024A10
		// (set) Token: 0x06003231 RID: 12849 RVA: 0x00026818 File Offset: 0x00024A18
		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return this.JQOiuhxzAXnqoWpsOdJkBKGZhOVq;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				this.JQOiuhxzAXnqoWpsOdJkBKGZhOVq = value;
			}
		}

		// Token: 0x17000B6D RID: 2925
		public TValue this[TKey key]
		{
			get
			{
				int num = this.IndexOfKey(key);
				if (num < 0)
				{
					string str = "Key \"";
					TKey tkey = key;
					throw new KeyNotFoundException(str + ((tkey != null) ? tkey.ToString() : null) + " does not exist.");
				}
				return this._entries[num].value;
			}
			set
			{
				this.BqcfHlhIHKrkJJrCqNbNMnNNoqAo(key, value, false);
			}
		}

		// Token: 0x06003234 RID: 12852 RVA: 0x00026836 File Offset: 0x00024A36
		public ADictionary() : this(0, null, null)
		{
		}

		// Token: 0x06003235 RID: 12853 RVA: 0x00026841 File Offset: 0x00024A41
		public ADictionary(IEqualityComparer<TKey> A_1) : this(0, A_1, null)
		{
		}

		// Token: 0x06003236 RID: 12854 RVA: 0x0002684C File Offset: 0x00024A4C
		public ADictionary(IEqualityComparer<TKey> A_1, IEqualityComparer<TValue> A_2) : this(0, A_1, A_2)
		{
		}

		// Token: 0x06003237 RID: 12855 RVA: 0x00026857 File Offset: 0x00024A57
		public ADictionary(int A_1) : this(A_1, null, null)
		{
		}

		// Token: 0x06003238 RID: 12856 RVA: 0x00026862 File Offset: 0x00024A62
		public ADictionary(int A_1, IEqualityComparer<TKey> A_2) : this(A_1, A_2, null)
		{
		}

		// Token: 0x06003239 RID: 12857 RVA: 0x000AD390 File Offset: 0x000AB590
		public ADictionary(int A_1, IEqualityComparer<TKey> A_2, IEqualityComparer<TValue> A_3)
		{
			if (A_1 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (A_1 > 0)
			{
				this.KQqDXNxWCFRGUEWUTfuJPeoLUEQf(A_1);
			}
			this.nPXlLMKiZMONUWKiYNbBVRNqPyNA = (A_2 ?? EqualityComparerNoAlloc<TKey>.Default);
			this.JQOiuhxzAXnqoWpsOdJkBKGZhOVq = (A_3 ?? EqualityComparerNoAlloc<TValue>.Default);
		}

		// Token: 0x0600323A RID: 12858 RVA: 0x0002686D File Offset: 0x00024A6D
		public ADictionary(IDictionary<TKey, TValue> A_1) : this(A_1, null, null)
		{
		}

		// Token: 0x0600323B RID: 12859 RVA: 0x00026878 File Offset: 0x00024A78
		public ADictionary(IDictionary<TKey, TValue> A_1, IEqualityComparer<TKey> A_2) : this(A_1, A_2, null)
		{
		}

		// Token: 0x0600323C RID: 12860 RVA: 0x000AD3E8 File Offset: 0x000AB5E8
		public ADictionary(IDictionary<TKey, TValue> A_1, IEqualityComparer<TKey> A_2, IEqualityComparer<TValue> A_3) : this((A_1 != null) ? A_1.Count : 0, A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> keyValuePair in A_1)
			{
				this.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x0600323D RID: 12861 RVA: 0x00026883 File Offset: 0x00024A83
		public void Add(TKey key, TValue value)
		{
			this.BqcfHlhIHKrkJJrCqNbNMnNNoqAo(key, value, true);
		}

		// Token: 0x0600323E RID: 12862 RVA: 0x000AD460 File Offset: 0x000AB660
		public void Clear()
		{
			if (this._count > 0)
			{
				for (int i = 0; i < this.ttCDhkqHbeINsbThsfVDBhiAcrkl.Length; i++)
				{
					this.ttCDhkqHbeINsbThsfVDBhiAcrkl[i] = -1;
				}
				Array.Clear(this._entries, 0, this._count);
				this.qXsaJWXwDAghudpBgobQvciLUqMqA = -1;
				this._count = 0;
				this.ehxOMXoMHhgjHvbnoCLKgUEnwrAY = 0;
				this.teAEuNYGfChLjchPxnQuduVgMwHKA++;
				this.iXaCXiuqEpVjWILwghixuVRTanb++;
			}
		}

		// Token: 0x0600323F RID: 12863 RVA: 0x0002688E File Offset: 0x00024A8E
		public bool ContainsKey(TKey key)
		{
			return this.IndexOfKey(key) >= 0;
		}

		// Token: 0x06003240 RID: 12864 RVA: 0x0002689D File Offset: 0x00024A9D
		public bool ContainsValue(TValue value)
		{
			return this.IndexOfValue(value) >= 0;
		}

		// Token: 0x06003241 RID: 12865 RVA: 0x000268AC File Offset: 0x00024AAC
		public ADictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return new ADictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x06003242 RID: 12866 RVA: 0x000AD4D8 File Offset: 0x000AB6D8
		public bool Remove(TKey key)
		{
			if (!ADictionary<TKey, TValue>.VeYeathdBaarvTQdCUNsPMlkhtlH && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (this.ttCDhkqHbeINsbThsfVDBhiAcrkl != null)
			{
				int num = this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.GetHashCode(key) & int.MaxValue;
				int num2 = num % this.ttCDhkqHbeINsbThsfVDBhiAcrkl.Length;
				int num3 = -1;
				for (int i = this.ttCDhkqHbeINsbThsfVDBhiAcrkl[num2]; i >= 0; i = this._entries[i].next)
				{
					if (this._entries[i].hashCode == num && this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.Equals(this._entries[i].key, key))
					{
						if (num3 < 0)
						{
							this.ttCDhkqHbeINsbThsfVDBhiAcrkl[num2] = this._entries[i].next;
						}
						else
						{
							this._entries[num3].next = this._entries[i].next;
						}
						this._entries[i].hashCode = -1;
						this._entries[i].next = this.qXsaJWXwDAghudpBgobQvciLUqMqA;
						this._entries[i].key = default(TKey);
						this._entries[i].value = default(TValue);
						this.qXsaJWXwDAghudpBgobQvciLUqMqA = i;
						this.ehxOMXoMHhgjHvbnoCLKgUEnwrAY++;
						this.teAEuNYGfChLjchPxnQuduVgMwHKA++;
						return true;
					}
					num3 = i;
				}
			}
			return false;
		}

		// Token: 0x06003243 RID: 12867 RVA: 0x000AD64C File Offset: 0x000AB84C
		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = this.IndexOfKey(key);
			if (num >= 0)
			{
				value = this._entries[num].value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06003244 RID: 12868 RVA: 0x000AD688 File Offset: 0x000AB888
		public TValue GetValueSafe(TKey key)
		{
			int num = this.IndexOfKey(key);
			if (num >= 0)
			{
				return this._entries[num].value;
			}
			return default(TValue);
		}

		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x06003245 RID: 12869 RVA: 0x000AD6BC File Offset: 0x000AB8BC
		public int IndexOfFirst
		{
			get
			{
				for (int i = 0; i < this._count; i++)
				{
					if (this._entries[i].hashCode >= 0)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x06003246 RID: 12870 RVA: 0x000AD6F4 File Offset: 0x000AB8F4
		public int IndexOfLast
		{
			get
			{
				for (int i = this._count - 1; i >= 0; i--)
				{
					if (this._entries[i].hashCode >= 0)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x06003247 RID: 12871 RVA: 0x000AD72C File Offset: 0x000AB92C
		public int IndexOfKey(TKey key)
		{
			if (!ADictionary<TKey, TValue>.VeYeathdBaarvTQdCUNsPMlkhtlH && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (this.ttCDhkqHbeINsbThsfVDBhiAcrkl != null)
			{
				int num = this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.GetHashCode(key) & int.MaxValue;
				for (int i = this.ttCDhkqHbeINsbThsfVDBhiAcrkl[num % this.ttCDhkqHbeINsbThsfVDBhiAcrkl.Length]; i >= 0; i = this._entries[i].next)
				{
					if (this._entries[i].hashCode == num && this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.Equals(this._entries[i].key, key))
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003248 RID: 12872 RVA: 0x000AD7D0 File Offset: 0x000AB9D0
		public int IndexOfValue(TValue value)
		{
			ADictionary<TKey, TValue>.Entry[] entries = this._entries;
			if (!ADictionary<TKey, TValue>.rmDbQROSTcpBWWDSJfjcFDdMCLgr && value == null)
			{
				for (int i = 0; i < this._count; i++)
				{
					if (entries[i].hashCode >= 0 && entries[i].value == null)
					{
						return i;
					}
				}
			}
			else
			{
				IEqualityComparer<TValue> jqoiuhxzAXnqoWpsOdJkBKGZhOVq = this.JQOiuhxzAXnqoWpsOdJkBKGZhOVq;
				for (int j = 0; j < this._count; j++)
				{
					if (entries[j].hashCode >= 0 && jqoiuhxzAXnqoWpsOdJkBKGZhOVq.Equals(entries[j].value, value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003249 RID: 12873 RVA: 0x000268B5 File Offset: 0x00024AB5
		public bool IsValidAt(int index)
		{
			return index < this._count && this._entries[index].hashCode >= 0;
		}

		// Token: 0x0600324A RID: 12874 RVA: 0x000AD86C File Offset: 0x000ABA6C
		public TKey GetKeyAt(int index)
		{
			if (index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return this._entries[index].key;
		}

		// Token: 0x0600324B RID: 12875 RVA: 0x000AD8C0 File Offset: 0x000ABAC0
		public TValue GetValueAt(int index)
		{
			if (index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return this._entries[index].value;
		}

		// Token: 0x0600324C RID: 12876 RVA: 0x000AD914 File Offset: 0x000ABB14
		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if (index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return new KeyValuePair<TKey, TValue>(this._entries[index].key, this._entries[index].value);
		}

		// Token: 0x0600324D RID: 12877 RVA: 0x000268D9 File Offset: 0x00024AD9
		public bool TryGetKeyAt(int index, out TKey key)
		{
			if (index >= this._count || this._entries[index].hashCode < 0)
			{
				key = default(TKey);
				return false;
			}
			key = this._entries[index].key;
			return true;
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x00026919 File Offset: 0x00024B19
		public bool TryGetValueAt(int index, out TValue value)
		{
			if (index >= this._count || this._entries[index].hashCode < 0)
			{
				value = default(TValue);
				return false;
			}
			value = this._entries[index].value;
			return true;
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x000AD97C File Offset: 0x000ABB7C
		public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
		{
			if (index >= this._count || this._entries[index].hashCode < 0)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = new KeyValuePair<TKey, TValue>(this._entries[index].key, this._entries[index].value);
			return true;
		}

		// Token: 0x06003250 RID: 12880 RVA: 0x00026959 File Offset: 0x00024B59
		public bool GetNextIndex(ref int index)
		{
			index++;
			if (index >= this._count)
			{
				return false;
			}
			while (index < this._count)
			{
				if (this._entries[index].hashCode >= 0)
				{
					return true;
				}
				index++;
			}
			return false;
		}

		// Token: 0x06003251 RID: 12881 RVA: 0x00026995 File Offset: 0x00024B95
		public int GetNextIndex(int index)
		{
			index++;
			if (index >= this._count)
			{
				return -1;
			}
			while (index < this._count)
			{
				if (this._entries[index].hashCode >= 0)
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		// Token: 0x06003252 RID: 12882 RVA: 0x000AD9E0 File Offset: 0x000ABBE0
		public bool GetNextKey(ref int index, out TKey key)
		{
			index++;
			if (index >= this._count)
			{
				key = default(TKey);
				return false;
			}
			while (index < this._count)
			{
				if (this._entries[index].hashCode >= 0)
				{
					key = this._entries[index].key;
					return true;
				}
				index++;
			}
			key = default(TKey);
			return false;
		}

		// Token: 0x06003253 RID: 12883 RVA: 0x000ADA50 File Offset: 0x000ABC50
		public bool GetNextValue(ref int index, out TValue value)
		{
			index++;
			if (index >= this._count)
			{
				value = default(TValue);
				return false;
			}
			while (index < this._count)
			{
				if (this._entries[index].hashCode >= 0)
				{
					value = this._entries[index].value;
					return true;
				}
				index++;
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06003254 RID: 12884 RVA: 0x000ADAC0 File Offset: 0x000ABCC0
		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index++;
			if (index >= this._count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index < this._count)
			{
				if (this._entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(this._entries[index].key, this._entries[index].value);
					return true;
				}
				index++;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x000269CC File Offset: 0x00024BCC
		public bool GetPreviousIndex(ref int index)
		{
			index--;
			if (index >= this._count)
			{
				return false;
			}
			while (index >= 0)
			{
				if (this._entries[index].hashCode >= 0)
				{
					return true;
				}
				index--;
			}
			return false;
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x00026A03 File Offset: 0x00024C03
		public int GetPreviousIndex(int index)
		{
			index--;
			if (index >= this._count)
			{
				return -1;
			}
			while (index >= 0)
			{
				if (this._entries[index].hashCode >= 0)
				{
					return index;
				}
				index--;
			}
			return -1;
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x000ADB44 File Offset: 0x000ABD44
		public bool GetPreviousKey(ref int index, out TKey key)
		{
			index--;
			if (index >= this._count)
			{
				key = default(TKey);
				return false;
			}
			while (index >= 0)
			{
				if (this._entries[index].hashCode >= 0)
				{
					key = this._entries[index].key;
					return true;
				}
				index--;
			}
			key = default(TKey);
			return false;
		}

		// Token: 0x06003258 RID: 12888 RVA: 0x000ADBAC File Offset: 0x000ABDAC
		public bool GetPreviousValue(ref int index, out TValue value)
		{
			index--;
			if (index >= this._count)
			{
				value = default(TValue);
				return false;
			}
			while (index >= 0)
			{
				if (this._entries[index].hashCode >= 0)
				{
					value = this._entries[index].value;
					return true;
				}
				index--;
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06003259 RID: 12889 RVA: 0x000ADC14 File Offset: 0x000ABE14
		public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index--;
			if (index >= this._count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index >= 0)
			{
				if (this._entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(this._entries[index].key, this._entries[index].value);
					return true;
				}
				index--;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		// Token: 0x0600325A RID: 12890 RVA: 0x000ADC94 File Offset: 0x000ABE94
		public bool RemoveAt(int index)
		{
			if (index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._entries[index].hashCode < 0)
			{
				return false;
			}
			this.Remove(this._entries[index].key);
			return true;
		}

		// Token: 0x0600325B RID: 12891 RVA: 0x000ADCE4 File Offset: 0x000ABEE4
		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			int count = this._count;
			ADictionary<TKey, TValue>.Entry[] entries = this._entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array[index++] = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
				}
			}
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x000ADD7C File Offset: 0x000ABF7C
		private void KQqDXNxWCFRGUEWUTfuJPeoLUEQf(int A_1)
		{
			int num = RTfWGsWObFJqairHlGsgazIhRZQr.UDYvUFmBNbGCFjvYZfgoTbkyGwcFb(A_1);
			this.ttCDhkqHbeINsbThsfVDBhiAcrkl = new int[num];
			for (int i = 0; i < this.ttCDhkqHbeINsbThsfVDBhiAcrkl.Length; i++)
			{
				this.ttCDhkqHbeINsbThsfVDBhiAcrkl[i] = -1;
			}
			this._entries = new ADictionary<TKey, TValue>.Entry[num];
			this.qXsaJWXwDAghudpBgobQvciLUqMqA = -1;
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x000ADDCC File Offset: 0x000ABFCC
		private void BqcfHlhIHKrkJJrCqNbNMnNNoqAo(TKey A_1, TValue A_2, bool A_3)
		{
			if (!ADictionary<TKey, TValue>.VeYeathdBaarvTQdCUNsPMlkhtlH && A_1 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (this.ttCDhkqHbeINsbThsfVDBhiAcrkl == null)
			{
				this.KQqDXNxWCFRGUEWUTfuJPeoLUEQf(0);
			}
			int num = this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.GetHashCode(A_1) & int.MaxValue;
			int num2 = num % this.ttCDhkqHbeINsbThsfVDBhiAcrkl.Length;
			int i = this.ttCDhkqHbeINsbThsfVDBhiAcrkl[num2];
			while (i >= 0)
			{
				if (this._entries[i].hashCode == num && this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.Equals(this._entries[i].key, A_1))
				{
					if (A_3)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					this._entries[i].value = A_2;
					this.teAEuNYGfChLjchPxnQuduVgMwHKA++;
					return;
				}
				else
				{
					i = this._entries[i].next;
				}
			}
			int count;
			if (this.ehxOMXoMHhgjHvbnoCLKgUEnwrAY > 0)
			{
				count = this.qXsaJWXwDAghudpBgobQvciLUqMqA;
				this.qXsaJWXwDAghudpBgobQvciLUqMqA = this._entries[count].next;
				this.ehxOMXoMHhgjHvbnoCLKgUEnwrAY--;
			}
			else
			{
				if (this._count == this._entries.Length)
				{
					this.JMeDEzzTUjhxCAtdIHRxoGXTwpJG();
					num2 = num % this.ttCDhkqHbeINsbThsfVDBhiAcrkl.Length;
				}
				count = this._count;
				this._count++;
			}
			this._entries[count].hashCode = num;
			this._entries[count].next = this.ttCDhkqHbeINsbThsfVDBhiAcrkl[num2];
			this._entries[count].key = A_1;
			this._entries[count].value = A_2;
			this.ttCDhkqHbeINsbThsfVDBhiAcrkl[num2] = count;
			this.teAEuNYGfChLjchPxnQuduVgMwHKA++;
			this.iXaCXiuqEpVjWILwghixuVRTanb++;
		}

		// Token: 0x0600325E RID: 12894 RVA: 0x00026A35 File Offset: 0x00024C35
		private void JMeDEzzTUjhxCAtdIHRxoGXTwpJG()
		{
			this.VUJKBDRVrcPRBHtzjdiEpbYrXjuu(RTfWGsWObFJqairHlGsgazIhRZQr.kUzpkdUNdwlsKlkWifATGnbYgNoHA(this._count), false);
		}

		// Token: 0x0600325F RID: 12895 RVA: 0x000ADF84 File Offset: 0x000AC184
		private void VUJKBDRVrcPRBHtzjdiEpbYrXjuu(int A_1, bool A_2)
		{
			int[] array = new int[A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			ADictionary<TKey, TValue>.Entry[] array2 = new ADictionary<TKey, TValue>.Entry[A_1];
			Array.Copy(this._entries, 0, array2, 0, this._count);
			if (A_2)
			{
				for (int j = 0; j < this._count; j++)
				{
					if (array2[j].hashCode != -1)
					{
						array2[j].hashCode = (this.nPXlLMKiZMONUWKiYNbBVRNqPyNA.GetHashCode(array2[j].key) & int.MaxValue);
					}
				}
			}
			for (int k = 0; k < this._count; k++)
			{
				if (array2[k].hashCode >= 0)
				{
					int num = array2[k].hashCode % A_1;
					array2[k].next = array[num];
					array[num] = k;
				}
			}
			this.ttCDhkqHbeINsbThsfVDBhiAcrkl = array;
			this._entries = array2;
		}

		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x06003260 RID: 12896 RVA: 0x000267BD File Offset: 0x000249BD
		ICollection<TKey> IDictionary<!0, !1>.Keys
		{
			get
			{
				if (this.DUdVJilVGeMWjLRgzlXRqMgpVOhi == null)
				{
					this.DUdVJilVGeMWjLRgzlXRqMgpVOhi = new ADictionary<TKey, TValue>.KeyCollection(this);
				}
				return this.DUdVJilVGeMWjLRgzlXRqMgpVOhi;
			}
		}

		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x06003261 RID: 12897 RVA: 0x000267D9 File Offset: 0x000249D9
		ICollection<TValue> IDictionary<!0, !1>.Values
		{
			get
			{
				if (this.WCwuEtGqIFRmlcOiTXONHjOKDnvt == null)
				{
					this.WCwuEtGqIFRmlcOiTXONHjOKDnvt = new ADictionary<TKey, TValue>.ValueCollection(this);
				}
				return this.WCwuEtGqIFRmlcOiTXONHjOKDnvt;
			}
		}

		// Token: 0x06003262 RID: 12898 RVA: 0x00026A49 File Offset: 0x00024C49
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.TGNDVlbFphkklCTYrLFlmdSOWpZsA()
		{
			return new ADictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x06003263 RID: 12899 RVA: 0x00026A57 File Offset: 0x00024C57
		void ICollection<KeyValuePair<!0, !1>>.FspMFVkBUDwYwccfarEoiWcHUKLp(KeyValuePair<TKey, TValue> A_1)
		{
			this.Add(A_1.Key, A_1.Value);
		}

		// Token: 0x06003264 RID: 12900 RVA: 0x000AE06C File Offset: 0x000AC26C
		bool ICollection<KeyValuePair<!0, !1>>.BEAwbenKhFepGRbUGfWXeicdPfzJA(KeyValuePair<TKey, TValue> A_1)
		{
			int num = this.IndexOfKey(A_1.Key);
			return num >= 0 && this.JQOiuhxzAXnqoWpsOdJkBKGZhOVq.Equals(this._entries[num].value, A_1.Value);
		}

		// Token: 0x06003265 RID: 12901 RVA: 0x000AE0B4 File Offset: 0x000AC2B4
		bool ICollection<KeyValuePair<!0, !1>>.LpLTijINrmDLNuPtPFNMBcZUkgZcb(KeyValuePair<TKey, TValue> A_1)
		{
			int num = this.IndexOfKey(A_1.Key);
			if (num >= 0 && this.JQOiuhxzAXnqoWpsOdJkBKGZhOVq.Equals(this._entries[num].value, A_1.Value))
			{
				this.Remove(A_1.Key);
				return true;
			}
			return false;
		}

		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x06003266 RID: 12902 RVA: 0x00003E2B File Offset: 0x0000202B
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x00026A6D File Offset: 0x00024C6D
		void ICollection<KeyValuePair<!0, !1>>.gqrscFggZYkHfqarFjkOtWgmHuFM(KeyValuePair<TKey, TValue>[] A_1, int A_2)
		{
			this.CopyTo(A_1, A_2);
		}

		// Token: 0x06003268 RID: 12904 RVA: 0x000AE10C File Offset: 0x000AC30C
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new Exception();
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new Exception();
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			KeyValuePair<TKey, TValue>[] array2 = array as KeyValuePair<TKey, TValue>[];
			if (array2 != null)
			{
				this.CopyTo(array2, index);
				return;
			}
			if (array is DictionaryEntry[])
			{
				DictionaryEntry[] array3 = array as DictionaryEntry[];
				ADictionary<TKey, TValue>.Entry[] entries = this._entries;
				for (int i = 0; i < this._count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array3[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
					}
				}
				return;
			}
			object[] array4 = array as object[];
			if (array4 == null)
			{
				throw new Exception();
			}
			try
			{
				int count = this._count;
				ADictionary<TKey, TValue>.Entry[] entries2 = this._entries;
				for (int j = 0; j < count; j++)
				{
					if (entries2[j].hashCode >= 0)
					{
						array4[index++] = new KeyValuePair<TKey, TValue>(entries2[j].key, entries2[j].value);
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}

		// Token: 0x06003269 RID: 12905 RVA: 0x00026A49 File Offset: 0x00024C49
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ADictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x0600326A RID: 12906 RVA: 0x00003E2B File Offset: 0x0000202B
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000B74 RID: 2932
		// (get) Token: 0x0600326B RID: 12907 RVA: 0x00026A77 File Offset: 0x00024C77
		object ICollection.SyncRoot
		{
			get
			{
				return this.LGUYtnZYHAYMqYasmCNMizVxrlDX;
			}
		}

		// Token: 0x17000B75 RID: 2933
		// (get) Token: 0x0600326C RID: 12908 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IDictionary.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000B76 RID: 2934
		// (get) Token: 0x0600326D RID: 12909 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IDictionary.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000B77 RID: 2935
		// (get) Token: 0x0600326E RID: 12910 RVA: 0x00026A7F File Offset: 0x00024C7F
		ICollection IDictionary.Keys
		{
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x17000B78 RID: 2936
		// (get) Token: 0x0600326F RID: 12911 RVA: 0x00026A87 File Offset: 0x00024C87
		ICollection IDictionary.Values
		{
			get
			{
				return this.Values;
			}
		}

		// Token: 0x17000B79 RID: 2937
		object IDictionary.this[object key]
		{
			get
			{
				if (ADictionary<TKey, TValue>.pRGAofHdgAiyQdKHnLBieUDspGnwA(key))
				{
					int num = this.IndexOfKey((TKey)((object)key));
					if (num >= 0)
					{
						return this._entries[num].value;
					}
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				ADictionary<TKey, TValue>.nPvvYoWnsrGrxuikxePHJDwfzFTQ<TValue>(value, "value");
				try
				{
					TKey key2 = (TKey)((object)key);
					try
					{
						this[key2] = (TValue)((object)value);
					}
					catch (InvalidCastException)
					{
						throw new Exception();
					}
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
		}

		// Token: 0x06003272 RID: 12914 RVA: 0x000AE328 File Offset: 0x000AC528
		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			ADictionary<TKey, TValue>.nPvvYoWnsrGrxuikxePHJDwfzFTQ<TValue>(value, "value");
			try
			{
				TKey key2 = (TKey)((object)key);
				try
				{
					this.Add(key2, (TValue)((object)value));
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
			catch (InvalidCastException)
			{
				throw new Exception();
			}
		}

		// Token: 0x06003273 RID: 12915 RVA: 0x00026A8F File Offset: 0x00024C8F
		bool IDictionary.Contains(object key)
		{
			return ADictionary<TKey, TValue>.pRGAofHdgAiyQdKHnLBieUDspGnwA(key) && this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x06003274 RID: 12916 RVA: 0x00026AA7 File Offset: 0x00024CA7
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new ADictionary<TKey, TValue>.Enumerator(this, 1);
		}

		// Token: 0x06003275 RID: 12917 RVA: 0x00026AB5 File Offset: 0x00024CB5
		void IDictionary.Remove(object key)
		{
			if (ADictionary<TKey, TValue>.pRGAofHdgAiyQdKHnLBieUDspGnwA(key))
			{
				this.Remove((TKey)((object)key));
			}
		}

		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x06003276 RID: 12918 RVA: 0x00026A7F File Offset: 0x00024C7F
		ICollection<TKey> Rewired.Utils.Interfaces.IReadOnlyDictionary<!0, !1>.Keys
		{
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x06003277 RID: 12919 RVA: 0x00026A87 File Offset: 0x00024C87
		ICollection<TValue> Rewired.Utils.Interfaces.IReadOnlyDictionary<!0, !1>.Values
		{
			get
			{
				return this.Values;
			}
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x00026ACC File Offset: 0x00024CCC
		private static bool pRGAofHdgAiyQdKHnLBieUDspGnwA(object A_0)
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return A_0 is TKey;
		}

		// Token: 0x06003279 RID: 12921 RVA: 0x000AE390 File Offset: 0x000AC590
		private static void nPvvYoWnsrGrxuikxePHJDwfzFTQ<\u0001>(object A_0, string A_1)
		{
			if (A_0 == null && default(\u0001) != null)
			{
				throw new ArgumentNullException(A_1);
			}
		}

		// Token: 0x04001B67 RID: 7015
		private int[] ttCDhkqHbeINsbThsfVDBhiAcrkl;

		// Token: 0x04001B68 RID: 7016
		internal ADictionary<TKey, TValue>.Entry[] _entries;

		// Token: 0x04001B69 RID: 7017
		internal int _count;

		// Token: 0x04001B6A RID: 7018
		private int teAEuNYGfChLjchPxnQuduVgMwHKA;

		// Token: 0x04001B6B RID: 7019
		private int iXaCXiuqEpVjWILwghixuVRTanb;

		// Token: 0x04001B6C RID: 7020
		private int qXsaJWXwDAghudpBgobQvciLUqMqA;

		// Token: 0x04001B6D RID: 7021
		private int ehxOMXoMHhgjHvbnoCLKgUEnwrAY;

		// Token: 0x04001B6E RID: 7022
		private IEqualityComparer<TKey> nPXlLMKiZMONUWKiYNbBVRNqPyNA;

		// Token: 0x04001B6F RID: 7023
		private IEqualityComparer<TValue> JQOiuhxzAXnqoWpsOdJkBKGZhOVq;

		// Token: 0x04001B70 RID: 7024
		private ADictionary<TKey, TValue>.KeyCollection DUdVJilVGeMWjLRgzlXRqMgpVOhi;

		// Token: 0x04001B71 RID: 7025
		private ADictionary<TKey, TValue>.ValueCollection WCwuEtGqIFRmlcOiTXONHjOKDnvt;

		// Token: 0x04001B72 RID: 7026
		private readonly object LGUYtnZYHAYMqYasmCNMizVxrlDX = new object();

		// Token: 0x04001B73 RID: 7027
		private static readonly bool VeYeathdBaarvTQdCUNsPMlkhtlH = ReflectionTools.IsValueType(typeof(TKey));

		// Token: 0x04001B74 RID: 7028
		private static readonly bool rmDbQROSTcpBWWDSJfjcFDdMCLgr = ReflectionTools.IsValueType(typeof(TValue));

		// Token: 0x04001B75 RID: 7029
		private const string IbcDVUhCWmPzKHehnOOTmTBQqXAN = "Version";

		// Token: 0x04001B76 RID: 7030
		private const string QoJutcGsBwAXVhNoiEYbuWDHwHjp = "HashSize";

		// Token: 0x04001B77 RID: 7031
		private const string VccaoCQWyOvVBdtticnyVFcAgSro = "KeyValuePairs";

		// Token: 0x04001B78 RID: 7032
		private const string terdVIbdoiEXcjWYEtvxqooNDeEFb = "Comparer";

		// Token: 0x020004E2 RID: 1250
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal struct Entry
		{
			// Token: 0x04001B79 RID: 7033
			public int hashCode;

			// Token: 0x04001B7A RID: 7034
			public int next;

			// Token: 0x04001B7B RID: 7035
			public TKey key;

			// Token: 0x04001B7C RID: 7036
			public TValue value;
		}

		// Token: 0x020004E3 RID: 1251
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		[Serializable]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			// Token: 0x0600327B RID: 12923 RVA: 0x00026B0F File Offset: 0x00024D0F
			internal Enumerator(ADictionary<TKey, TValue> A_1, int A_2)
			{
				this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr = A_1;
				this.JEhbYcTCuMrOIeonbmMdIGkOcTpK = A_1.teAEuNYGfChLjchPxnQuduVgMwHKA;
				this.ZiUccFKttLMFghNzIYusElHdVULnB = 0;
				this.NBfWKAjViEZbbulmuPExzVohHqwl = A_2;
				this.CmTVPhWsngidaSTwvqLxHEmXFxBGA = default(KeyValuePair<TKey, TValue>);
			}

			// Token: 0x0600327C RID: 12924 RVA: 0x000AE3B8 File Offset: 0x000AC5B8
			public bool MoveNext()
			{
				if (this.JEhbYcTCuMrOIeonbmMdIGkOcTpK != this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr.teAEuNYGfChLjchPxnQuduVgMwHKA)
				{
					throw new Exception();
				}
				while (this.ZiUccFKttLMFghNzIYusElHdVULnB < this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._count)
				{
					if (this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._entries[this.ZiUccFKttLMFghNzIYusElHdVULnB].hashCode >= 0)
					{
						this.CmTVPhWsngidaSTwvqLxHEmXFxBGA = new KeyValuePair<TKey, TValue>(this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._entries[this.ZiUccFKttLMFghNzIYusElHdVULnB].key, this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._entries[this.ZiUccFKttLMFghNzIYusElHdVULnB].value);
						this.ZiUccFKttLMFghNzIYusElHdVULnB++;
						return true;
					}
					this.ZiUccFKttLMFghNzIYusElHdVULnB++;
				}
				this.ZiUccFKttLMFghNzIYusElHdVULnB = this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._count + 1;
				this.CmTVPhWsngidaSTwvqLxHEmXFxBGA = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			// Token: 0x17000B7C RID: 2940
			// (get) Token: 0x0600327D RID: 12925 RVA: 0x00026B3E File Offset: 0x00024D3E
			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					return this.CmTVPhWsngidaSTwvqLxHEmXFxBGA;
				}
			}

			// Token: 0x0600327E RID: 12926 RVA: 0x00002FF9 File Offset: 0x000011F9
			public void Dispose()
			{
			}

			// Token: 0x17000B7D RID: 2941
			// (get) Token: 0x0600327F RID: 12927 RVA: 0x000AE494 File Offset: 0x000AC694
			object IEnumerator.Current
			{
				get
				{
					if (this.ZiUccFKttLMFghNzIYusElHdVULnB == 0 || this.ZiUccFKttLMFghNzIYusElHdVULnB == this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._count + 1)
					{
						throw new Exception();
					}
					if (this.NBfWKAjViEZbbulmuPExzVohHqwl == 1)
					{
						return new DictionaryEntry(this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Key, this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Value);
					}
					return new KeyValuePair<TKey, TValue>(this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Key, this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Value);
				}
			}

			// Token: 0x06003280 RID: 12928 RVA: 0x00026B46 File Offset: 0x00024D46
			void IEnumerator.Reset()
			{
				if (this.JEhbYcTCuMrOIeonbmMdIGkOcTpK != this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr.teAEuNYGfChLjchPxnQuduVgMwHKA)
				{
					throw new Exception();
				}
				this.ZiUccFKttLMFghNzIYusElHdVULnB = 0;
				this.CmTVPhWsngidaSTwvqLxHEmXFxBGA = default(KeyValuePair<TKey, TValue>);
			}

			// Token: 0x17000B7E RID: 2942
			// (get) Token: 0x06003281 RID: 12929 RVA: 0x000AE518 File Offset: 0x000AC718
			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (this.ZiUccFKttLMFghNzIYusElHdVULnB == 0 || this.ZiUccFKttLMFghNzIYusElHdVULnB == this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Key, this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Value);
				}
			}

			// Token: 0x17000B7F RID: 2943
			// (get) Token: 0x06003282 RID: 12930 RVA: 0x00026B74 File Offset: 0x00024D74
			object IDictionaryEnumerator.Key
			{
				get
				{
					if (this.ZiUccFKttLMFghNzIYusElHdVULnB == 0 || this.ZiUccFKttLMFghNzIYusElHdVULnB == this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._count + 1)
					{
						throw new Exception();
					}
					return this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Key;
				}
			}

			// Token: 0x17000B80 RID: 2944
			// (get) Token: 0x06003283 RID: 12931 RVA: 0x00026BA9 File Offset: 0x00024DA9
			object IDictionaryEnumerator.Value
			{
				get
				{
					if (this.ZiUccFKttLMFghNzIYusElHdVULnB == 0 || this.ZiUccFKttLMFghNzIYusElHdVULnB == this.QwMwsdyzgBCmFrMcuKGjLRDgDqAr._count + 1)
					{
						throw new Exception();
					}
					return this.CmTVPhWsngidaSTwvqLxHEmXFxBGA.Value;
				}
			}

			// Token: 0x04001B7D RID: 7037
			private ADictionary<TKey, TValue> QwMwsdyzgBCmFrMcuKGjLRDgDqAr;

			// Token: 0x04001B7E RID: 7038
			private int JEhbYcTCuMrOIeonbmMdIGkOcTpK;

			// Token: 0x04001B7F RID: 7039
			private int ZiUccFKttLMFghNzIYusElHdVULnB;

			// Token: 0x04001B80 RID: 7040
			private KeyValuePair<TKey, TValue> CmTVPhWsngidaSTwvqLxHEmXFxBGA;

			// Token: 0x04001B81 RID: 7041
			private int NBfWKAjViEZbbulmuPExzVohHqwl;

			// Token: 0x04001B82 RID: 7042
			internal const int DictEntry = 1;

			// Token: 0x04001B83 RID: 7043
			internal const int KeyValuePair = 2;
		}

		// Token: 0x020004E4 RID: 1252
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		[Serializable]
		public sealed class KeyCollection : ICollection<!0>, IEnumerable<!0>, IEnumerable, ICollection
		{
			// Token: 0x06003284 RID: 12932 RVA: 0x00026BDE File Offset: 0x00024DDE
			public KeyCollection(ADictionary<TKey, TValue> A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx = A_1;
			}

			// Token: 0x06003285 RID: 12933 RVA: 0x00026BFB File Offset: 0x00024DFB
			public ADictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator()
			{
				return new ADictionary<TKey, TValue>.KeyCollection.Enumerator(this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx);
			}

			// Token: 0x06003286 RID: 12934 RVA: 0x000AE570 File Offset: 0x000AC770
			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (array.Length - index < this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx.Count)
				{
					throw new Exception();
				}
				int count = this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx._count;
				ADictionary<TKey, TValue>.Entry[] entries = this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			// Token: 0x17000B81 RID: 2945
			// (get) Token: 0x06003287 RID: 12935 RVA: 0x00026C08 File Offset: 0x00024E08
			public int Count
			{
				get
				{
					return this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx.Count;
				}
			}

			// Token: 0x17000B82 RID: 2946
			// (get) Token: 0x06003288 RID: 12936 RVA: 0x000042E2 File Offset: 0x000024E2
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06003289 RID: 12937 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!0>.iwHXWsipQbecFPQWAjByhIWYmsKg(TKey A_1)
			{
				throw new Exception();
			}

			// Token: 0x0600328A RID: 12938 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!0>.zVCEzXfgRBbNoxaSwVVULVyODYwmA()
			{
				throw new Exception();
			}

			// Token: 0x0600328B RID: 12939 RVA: 0x00026C1C File Offset: 0x00024E1C
			bool ICollection<!0>.niZGvYTyjQLBvxZZbsjajfgQGWM(TKey A_1)
			{
				return this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx.ContainsKey(A_1);
			}

			// Token: 0x0600328C RID: 12940 RVA: 0x00026C15 File Offset: 0x00024E15
			bool ICollection<!0>.uzfsBvVXAXjlPbgkGLctmeIohCAh(TKey A_1)
			{
				throw new Exception();
			}

			// Token: 0x0600328D RID: 12941 RVA: 0x00026C2A File Offset: 0x00024E2A
			IEnumerator<TKey> IEnumerable<!0>.FBCahydPVwepqXEFJDMHQVrupCBgb()
			{
				return new ADictionary<TKey, TValue>.KeyCollection.Enumerator(this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx);
			}

			// Token: 0x0600328E RID: 12942 RVA: 0x00026C2A File Offset: 0x00024E2A
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new ADictionary<TKey, TValue>.KeyCollection.Enumerator(this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx);
			}

			// Token: 0x0600328F RID: 12943 RVA: 0x000AE604 File Offset: 0x000AC804
			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx.Count)
				{
					throw new Exception();
				}
				TKey[] array2 = array as TKey[];
				if (array2 != null)
				{
					this.CopyTo(array2, index);
					return;
				}
				object[] array3 = array as object[];
				if (array3 == null)
				{
					throw new Exception();
				}
				int count = this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx._count;
				ADictionary<TKey, TValue>.Entry[] entries = this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].key;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}

			// Token: 0x17000B83 RID: 2947
			// (get) Token: 0x06003290 RID: 12944 RVA: 0x00003E2B File Offset: 0x0000202B
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000B84 RID: 2948
			// (get) Token: 0x06003291 RID: 12945 RVA: 0x00026C3C File Offset: 0x00024E3C
			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)this.wQMPgWnfwwkvlfwoRtSxFMrAvgAx).SyncRoot;
				}
			}

			// Token: 0x04001B84 RID: 7044
			private ADictionary<TKey, TValue> wQMPgWnfwwkvlfwoRtSxFMrAvgAx;

			// Token: 0x020004E5 RID: 1253
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			[Serializable]
			public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable
			{
				// Token: 0x06003292 RID: 12946 RVA: 0x00026C49 File Offset: 0x00024E49
				internal Enumerator(ADictionary<TKey, TValue> A_1)
				{
					this.NdsZENhdSpXevvwjDNNKBIuxSUvL = A_1;
					this.cYZDuNFZOJEIXaMZAVoGTAFLHhGPA = A_1.teAEuNYGfChLjchPxnQuduVgMwHKA;
					this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ = 0;
					this.ZzXukbEvyqRBcsrcfiKRfqfveVzc = default(TKey);
				}

				// Token: 0x06003293 RID: 12947 RVA: 0x00002FF9 File Offset: 0x000011F9
				public void Dispose()
				{
				}

				// Token: 0x06003294 RID: 12948 RVA: 0x000AE6FC File Offset: 0x000AC8FC
				public bool MoveNext()
				{
					if (this.cYZDuNFZOJEIXaMZAVoGTAFLHhGPA != this.NdsZENhdSpXevvwjDNNKBIuxSUvL.teAEuNYGfChLjchPxnQuduVgMwHKA)
					{
						throw new Exception();
					}
					while (this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ < this.NdsZENhdSpXevvwjDNNKBIuxSUvL._count)
					{
						if (this.NdsZENhdSpXevvwjDNNKBIuxSUvL._entries[this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ].hashCode >= 0)
						{
							this.ZzXukbEvyqRBcsrcfiKRfqfveVzc = this.NdsZENhdSpXevvwjDNNKBIuxSUvL._entries[this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ].key;
							this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ++;
							return true;
						}
						this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ++;
					}
					this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ = this.NdsZENhdSpXevvwjDNNKBIuxSUvL._count + 1;
					this.ZzXukbEvyqRBcsrcfiKRfqfveVzc = default(TKey);
					return false;
				}

				// Token: 0x17000B85 RID: 2949
				// (get) Token: 0x06003295 RID: 12949 RVA: 0x00026C71 File Offset: 0x00024E71
				public TKey Current
				{
					get
					{
						return this.ZzXukbEvyqRBcsrcfiKRfqfveVzc;
					}
				}

				// Token: 0x17000B86 RID: 2950
				// (get) Token: 0x06003296 RID: 12950 RVA: 0x00026C79 File Offset: 0x00024E79
				object IEnumerator.Current
				{
					get
					{
						if (this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ == 0 || this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ == this.NdsZENhdSpXevvwjDNNKBIuxSUvL._count + 1)
						{
							throw new Exception();
						}
						return this.ZzXukbEvyqRBcsrcfiKRfqfveVzc;
					}
				}

				// Token: 0x06003297 RID: 12951 RVA: 0x00026CA9 File Offset: 0x00024EA9
				void IEnumerator.Reset()
				{
					if (this.cYZDuNFZOJEIXaMZAVoGTAFLHhGPA != this.NdsZENhdSpXevvwjDNNKBIuxSUvL.teAEuNYGfChLjchPxnQuduVgMwHKA)
					{
						throw new Exception();
					}
					this.ZMywlgsIuVEXyUPhwgEGWWyyFVgQ = 0;
					this.ZzXukbEvyqRBcsrcfiKRfqfveVzc = default(TKey);
				}

				// Token: 0x04001B85 RID: 7045
				private ADictionary<TKey, TValue> NdsZENhdSpXevvwjDNNKBIuxSUvL;

				// Token: 0x04001B86 RID: 7046
				private int ZMywlgsIuVEXyUPhwgEGWWyyFVgQ;

				// Token: 0x04001B87 RID: 7047
				private int cYZDuNFZOJEIXaMZAVoGTAFLHhGPA;

				// Token: 0x04001B88 RID: 7048
				private TKey ZzXukbEvyqRBcsrcfiKRfqfveVzc;
			}
		}

		// Token: 0x020004E6 RID: 1254
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		[Serializable]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			// Token: 0x06003298 RID: 12952 RVA: 0x00026CD7 File Offset: 0x00024ED7
			public ValueCollection(ADictionary<TKey, TValue> A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU = A_1;
			}

			// Token: 0x06003299 RID: 12953 RVA: 0x00026CF4 File Offset: 0x00024EF4
			public ADictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator()
			{
				return new ADictionary<TKey, TValue>.ValueCollection.Enumerator(this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU);
			}

			// Token: 0x0600329A RID: 12954 RVA: 0x000AE7B4 File Offset: 0x000AC9B4
			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU.Count)
				{
					throw new Exception();
				}
				int count = this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU._count;
				ADictionary<TKey, TValue>.Entry[] entries = this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			// Token: 0x17000B87 RID: 2951
			// (get) Token: 0x0600329B RID: 12955 RVA: 0x00026D01 File Offset: 0x00024F01
			public int Count
			{
				get
				{
					return this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU.Count;
				}
			}

			// Token: 0x17000B88 RID: 2952
			// (get) Token: 0x0600329C RID: 12956 RVA: 0x000042E2 File Offset: 0x000024E2
			bool ICollection<!1>.IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x0600329D RID: 12957 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!1>.SGBtfEDeGJzPAZbzJqAkfgNFMiTJ(TValue A_1)
			{
				throw new Exception();
			}

			// Token: 0x0600329E RID: 12958 RVA: 0x00026C15 File Offset: 0x00024E15
			bool ICollection<!1>.BtzBCkYmOwSgpriYcxGcdjqQWCIn(TValue A_1)
			{
				throw new Exception();
			}

			// Token: 0x0600329F RID: 12959 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!1>.tyTbjgNtdllmNKVMIkdlNCkinonj()
			{
				throw new Exception();
			}

			// Token: 0x060032A0 RID: 12960 RVA: 0x00026D0E File Offset: 0x00024F0E
			bool ICollection<!1>.ZipcFDrQpMIrvBuoKknhyxaNgFkTA(TValue A_1)
			{
				return this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU.ContainsValue(A_1);
			}

			// Token: 0x060032A1 RID: 12961 RVA: 0x00026D1C File Offset: 0x00024F1C
			IEnumerator<TValue> IEnumerable<!1>.BBVZjsMBEixmNNMQlurLYothLPTJ()
			{
				return new ADictionary<TKey, TValue>.ValueCollection.Enumerator(this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU);
			}

			// Token: 0x060032A2 RID: 12962 RVA: 0x00026D1C File Offset: 0x00024F1C
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new ADictionary<TKey, TValue>.ValueCollection.Enumerator(this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU);
			}

			// Token: 0x060032A3 RID: 12963 RVA: 0x000AE844 File Offset: 0x000ACA44
			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU.Count)
				{
					throw new Exception();
				}
				TValue[] array2 = array as TValue[];
				if (array2 != null)
				{
					this.CopyTo(array2, index);
					return;
				}
				object[] array3 = array as object[];
				if (array3 == null)
				{
					throw new Exception();
				}
				int count = this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU._count;
				ADictionary<TKey, TValue>.Entry[] entries = this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].value;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}

			// Token: 0x17000B89 RID: 2953
			// (get) Token: 0x060032A4 RID: 12964 RVA: 0x00003E2B File Offset: 0x0000202B
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000B8A RID: 2954
			// (get) Token: 0x060032A5 RID: 12965 RVA: 0x00026D2E File Offset: 0x00024F2E
			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)this.rLaiTQeBDMiMYQJxnzxBHGqrhVKU).SyncRoot;
				}
			}

			// Token: 0x04001B89 RID: 7049
			private ADictionary<TKey, TValue> rLaiTQeBDMiMYQJxnzxBHGqrhVKU;

			// Token: 0x020004E7 RID: 1255
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			[Serializable]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				// Token: 0x060032A6 RID: 12966 RVA: 0x00026D3B File Offset: 0x00024F3B
				internal Enumerator(ADictionary<TKey, TValue> A_1)
				{
					this.WekpyjxgBNrIRlmNkGFurUDihFccA = A_1;
					this.aodrDRBboCqOpKbuyxXnmgvnooHb = A_1.teAEuNYGfChLjchPxnQuduVgMwHKA;
					this.RJhZZzxoEpdCWsOHAYQtNcyCttEH = 0;
					this.odskmMgcnAJjgyepcMOjkPriVDek = default(TValue);
				}

				// Token: 0x060032A7 RID: 12967 RVA: 0x00002FF9 File Offset: 0x000011F9
				public void Dispose()
				{
				}

				// Token: 0x060032A8 RID: 12968 RVA: 0x000AE93C File Offset: 0x000ACB3C
				public bool MoveNext()
				{
					if (this.aodrDRBboCqOpKbuyxXnmgvnooHb != this.WekpyjxgBNrIRlmNkGFurUDihFccA.teAEuNYGfChLjchPxnQuduVgMwHKA)
					{
						throw new Exception();
					}
					while (this.RJhZZzxoEpdCWsOHAYQtNcyCttEH < this.WekpyjxgBNrIRlmNkGFurUDihFccA._count)
					{
						if (this.WekpyjxgBNrIRlmNkGFurUDihFccA._entries[this.RJhZZzxoEpdCWsOHAYQtNcyCttEH].hashCode >= 0)
						{
							this.odskmMgcnAJjgyepcMOjkPriVDek = this.WekpyjxgBNrIRlmNkGFurUDihFccA._entries[this.RJhZZzxoEpdCWsOHAYQtNcyCttEH].value;
							this.RJhZZzxoEpdCWsOHAYQtNcyCttEH++;
							return true;
						}
						this.RJhZZzxoEpdCWsOHAYQtNcyCttEH++;
					}
					this.RJhZZzxoEpdCWsOHAYQtNcyCttEH = this.WekpyjxgBNrIRlmNkGFurUDihFccA._count + 1;
					this.odskmMgcnAJjgyepcMOjkPriVDek = default(TValue);
					return false;
				}

				// Token: 0x17000B8B RID: 2955
				// (get) Token: 0x060032A9 RID: 12969 RVA: 0x00026D63 File Offset: 0x00024F63
				public TValue Current
				{
					get
					{
						return this.odskmMgcnAJjgyepcMOjkPriVDek;
					}
				}

				// Token: 0x17000B8C RID: 2956
				// (get) Token: 0x060032AA RID: 12970 RVA: 0x00026D6B File Offset: 0x00024F6B
				object IEnumerator.Current
				{
					get
					{
						if (this.RJhZZzxoEpdCWsOHAYQtNcyCttEH == 0 || this.RJhZZzxoEpdCWsOHAYQtNcyCttEH == this.WekpyjxgBNrIRlmNkGFurUDihFccA._count + 1)
						{
							throw new Exception();
						}
						return this.odskmMgcnAJjgyepcMOjkPriVDek;
					}
				}

				// Token: 0x060032AB RID: 12971 RVA: 0x00026D9B File Offset: 0x00024F9B
				void IEnumerator.Reset()
				{
					if (this.aodrDRBboCqOpKbuyxXnmgvnooHb != this.WekpyjxgBNrIRlmNkGFurUDihFccA.teAEuNYGfChLjchPxnQuduVgMwHKA)
					{
						throw new Exception();
					}
					this.RJhZZzxoEpdCWsOHAYQtNcyCttEH = 0;
					this.odskmMgcnAJjgyepcMOjkPriVDek = default(TValue);
				}

				// Token: 0x04001B8A RID: 7050
				private ADictionary<TKey, TValue> WekpyjxgBNrIRlmNkGFurUDihFccA;

				// Token: 0x04001B8B RID: 7051
				private int RJhZZzxoEpdCWsOHAYQtNcyCttEH;

				// Token: 0x04001B8C RID: 7052
				private int aodrDRBboCqOpKbuyxXnmgvnooHb;

				// Token: 0x04001B8D RID: 7053
				private TValue odskmMgcnAJjgyepcMOjkPriVDek;
			}
		}
	}
}
