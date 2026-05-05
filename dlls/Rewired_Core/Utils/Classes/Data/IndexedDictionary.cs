using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004E8 RID: 1256
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IndexedDictionary<TKey, TValue> : IDictionary<!0, !1>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<!0, !1>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x060032AC RID: 12972 RVA: 0x00026DC9 File Offset: 0x00024FC9
		public int Count
		{
			get
			{
				return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
			}
		}

		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x060032AD RID: 12973 RVA: 0x00026DD6 File Offset: 0x00024FD6
		public bool ContainsDuplicateKeys
		{
			get
			{
				return this.BiTzfeyJInNGwJnmmelMdAiXlzpE && this.nLcEXKeLyEBJkENhAdwUmcqChWscc._count < this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
			}
		}

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x060032AE RID: 12974 RVA: 0x00026DFA File Offset: 0x00024FFA
		// (set) Token: 0x060032AF RID: 12975 RVA: 0x00026E02 File Offset: 0x00025002
		public bool AllowDuplicateKeys
		{
			get
			{
				return this.BiTzfeyJInNGwJnmmelMdAiXlzpE;
			}
			set
			{
				if (this.BiTzfeyJInNGwJnmmelMdAiXlzpE == value)
				{
					return;
				}
				this.BiTzfeyJInNGwJnmmelMdAiXlzpE = value;
				if (!value && this.ContainsDuplicateKeys)
				{
					throw new Exception("The dictionary contains duplicate keys and cannot be changed unless the keys are removed.");
				}
			}
		}

		// Token: 0x060032B0 RID: 12976 RVA: 0x00026E2B File Offset: 0x0002502B
		public IndexedDictionary() : this(0, false)
		{
		}

		// Token: 0x060032B1 RID: 12977 RVA: 0x00026E35 File Offset: 0x00025035
		public IndexedDictionary(int A_1) : this(A_1, false)
		{
		}

		// Token: 0x060032B2 RID: 12978 RVA: 0x00026E3F File Offset: 0x0002503F
		public IndexedDictionary(bool A_1) : this(0, A_1)
		{
		}

		// Token: 0x060032B3 RID: 12979 RVA: 0x000AE9F4 File Offset: 0x000ACBF4
		public IndexedDictionary(int A_1, bool A_2)
		{
			if (A_1 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			this.BiTzfeyJInNGwJnmmelMdAiXlzpE = A_2;
			this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA = new AList<IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy>(A_1);
			this.nLcEXKeLyEBJkENhAdwUmcqChWscc = new ADictionary<TKey, int>(A_1);
		}

		// Token: 0x060032B4 RID: 12980 RVA: 0x00026E49 File Offset: 0x00025049
		public IndexedDictionary(IDictionary<TKey, TValue> A_1) : this(A_1, false)
		{
		}

		// Token: 0x060032B5 RID: 12981 RVA: 0x000AEA4C File Offset: 0x000ACC4C
		public IndexedDictionary(IDictionary<TKey, TValue> A_1, bool A_2) : this(0, A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (ReflectionTools.DoesTypeImplement(A_1.GetType(), typeof(IndexedDictionary<TKey, TValue>)))
			{
				IndexedDictionary<TKey, TValue> indexedDictionary = (IndexedDictionary<TKey, TValue>)A_1;
				for (int i = 0; i < indexedDictionary.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count; i++)
				{
					this.Add(indexedDictionary.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA, indexedDictionary.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl);
				}
				return;
			}
			foreach (KeyValuePair<TKey, TValue> keyValuePair in A_1)
			{
				this.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x17000B90 RID: 2960
		public TValue this[int index]
		{
			get
			{
				if (index >= this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[index].IJSoOyhwKDltQGHjONzvDvMUCpgl;
			}
			set
			{
				if (index >= this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[index].IJSoOyhwKDltQGHjONzvDvMUCpgl = value;
			}
		}

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x060032B8 RID: 12984 RVA: 0x00026EB6 File Offset: 0x000250B6
		// (set) Token: 0x060032B9 RID: 12985 RVA: 0x00026EBE File Offset: 0x000250BE
		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return this.pfTyFvbLgvMuBgkZChhkWiyKjmHH;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				this.pfTyFvbLgvMuBgkZChhkWiyKjmHH = value;
			}
		}

		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x060032BA RID: 12986 RVA: 0x00026ED1 File Offset: 0x000250D1
		// (set) Token: 0x060032BB RID: 12987 RVA: 0x00026ED9 File Offset: 0x000250D9
		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return this.HlWGmhNZYUjYNWKMnheOEAVPUJYU;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				this.HlWGmhNZYUjYNWKMnheOEAVPUJYU = value;
			}
		}

		// Token: 0x060032BC RID: 12988 RVA: 0x00026EEC File Offset: 0x000250EC
		public TValue GetValue(TKey key)
		{
			return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[this.nLcEXKeLyEBJkENhAdwUmcqChWscc[key]].IJSoOyhwKDltQGHjONzvDvMUCpgl;
		}

		// Token: 0x060032BD RID: 12989 RVA: 0x000AEB20 File Offset: 0x000ACD20
		public bool TryGetValue(TKey key, out TValue value)
		{
			int num;
			if (!this.nLcEXKeLyEBJkENhAdwUmcqChWscc.TryGetValue(key, out num))
			{
				value = default(TValue);
				return false;
			}
			value = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[num].IJSoOyhwKDltQGHjONzvDvMUCpgl;
			return true;
		}

		// Token: 0x060032BE RID: 12990 RVA: 0x00026F0F File Offset: 0x0002510F
		public TKey GetKeyAt(int index)
		{
			if (index >= this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA[index].KJdhyQqwpXjyITZzOljCvmgXFqfeA;
		}

		// Token: 0x060032BF RID: 12991 RVA: 0x000AEB64 File Offset: 0x000ACD64
		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA[this.nLcEXKeLyEBJkENhAdwUmcqChWscc[key]].mxOnxTKejphnmcygZzczUvYgrctWA();
		}

		// Token: 0x060032C0 RID: 12992 RVA: 0x000AEB90 File Offset: 0x000ACD90
		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if (index >= this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA[index].mxOnxTKejphnmcygZzczUvYgrctWA();
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x000AEBCC File Offset: 0x000ACDCC
		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			int index;
			if (!this.nLcEXKeLyEBJkENhAdwUmcqChWscc.TryGetValue(key, out index))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA[index].mxOnxTKejphnmcygZzczUvYgrctWA();
			return true;
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x000AEC10 File Offset: 0x000ACE10
		public void Add(TKey key, TValue value)
		{
			bool flag = this.nLcEXKeLyEBJkENhAdwUmcqChWscc.ContainsKey(key);
			if (flag && !this.BiTzfeyJInNGwJnmmelMdAiXlzpE)
			{
				string str = "Key \"";
				TKey tkey = key;
				throw new ArgumentException(str + ((tkey != null) ? tkey.ToString() : null) + "\" is already in use.");
			}
			int value2 = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Add(new IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy(key, value));
			if (flag)
			{
				this.nLcEXKeLyEBJkENhAdwUmcqChWscc[key] = value2;
				return;
			}
			this.nLcEXKeLyEBJkENhAdwUmcqChWscc.Add(key, value2);
		}

		// Token: 0x060032C3 RID: 12995 RVA: 0x000AEC94 File Offset: 0x000ACE94
		public void SetValue(TKey key, TValue value)
		{
			int num;
			if (this.nLcEXKeLyEBJkENhAdwUmcqChWscc.TryGetValue(key, out num))
			{
				this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[num].IJSoOyhwKDltQGHjONzvDvMUCpgl = value;
				this.nLcEXKeLyEBJkENhAdwUmcqChWscc[key] = num;
				return;
			}
			this.Add(key, value);
		}

		// Token: 0x060032C4 RID: 12996 RVA: 0x000AECE0 File Offset: 0x000ACEE0
		public bool Remove(TKey key)
		{
			this.nLcEXKeLyEBJkENhAdwUmcqChWscc.Remove(key);
			if (this.BiTzfeyJInNGwJnmmelMdAiXlzpE)
			{
				bool result = false;
				for (int i = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count - 1; i >= 0; i--)
				{
					if (this.pfTyFvbLgvMuBgkZChhkWiyKjmHH.Equals(this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA, key))
					{
						this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.RemoveAt(i);
						result = true;
					}
				}
				return result;
			}
			int num = this.IndexOfKey(key);
			if (num < 0)
			{
				return false;
			}
			this.RemoveAt(num);
			return true;
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x000AED68 File Offset: 0x000ACF68
		public void RemoveAt(int index)
		{
			if (index >= this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey kjdhyQqwpXjyITZzOljCvmgXFqfeA = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[index].KJdhyQqwpXjyITZzOljCvmgXFqfeA;
			if (index < this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count - 1)
			{
				for (int i = index + 1; i < this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Count; i++)
				{
					this.nLcEXKeLyEBJkENhAdwUmcqChWscc[this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA] = i - 1;
				}
			}
			this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.RemoveAt(index);
			this.nLcEXKeLyEBJkENhAdwUmcqChWscc.Remove(kjdhyQqwpXjyITZzOljCvmgXFqfeA);
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x000AEE0C File Offset: 0x000AD00C
		public void RemoveValue(TValue value)
		{
			int num = this.IndexOfValue(value);
			if (num < 0)
			{
				return;
			}
			IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy[] items = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items;
			this.RemoveAt(num);
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x000AEE40 File Offset: 0x000AD040
		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int i = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count - 1; i >= 0; i--)
			{
				IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy[] items = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items;
				if (this.HlWGmhNZYUjYNWKMnheOEAVPUJYU.Equals(this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl, value))
				{
					this.RemoveAt(i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x000AEEAC File Offset: 0x000AD0AC
		public int IndexOfKey(TKey key)
		{
			if (!IndexedDictionary<TKey, TValue>.StsbfyFCjdTghAEDyoFxqnatrNpu && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
			for (int i = 0; i < count; i++)
			{
				if (this.pfTyFvbLgvMuBgkZChhkWiyKjmHH.Equals(this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA, key))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060032C9 RID: 13001 RVA: 0x000AEF14 File Offset: 0x000AD114
		public int IndexOfValue(TValue value)
		{
			int count = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
			for (int i = 0; i < count; i++)
			{
				if (this.HlWGmhNZYUjYNWKMnheOEAVPUJYU.Equals(this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl, value))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060032CA RID: 13002 RVA: 0x00026F3B File Offset: 0x0002513B
		public bool ContainsKey(TKey key)
		{
			return this.nLcEXKeLyEBJkENhAdwUmcqChWscc.ContainsKey(key);
		}

		// Token: 0x060032CB RID: 13003 RVA: 0x00026F49 File Offset: 0x00025149
		public bool ContainsValue(TValue value)
		{
			return this.IndexOfValue(value) >= 0;
		}

		// Token: 0x060032CC RID: 13004 RVA: 0x00026F58 File Offset: 0x00025158
		public void Clear()
		{
			this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Clear();
			this.nLcEXKeLyEBJkENhAdwUmcqChWscc.Clear();
		}

		// Token: 0x060032CD RID: 13005 RVA: 0x00026F70 File Offset: 0x00025170
		public void TrimExcess()
		{
			this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.TrimExcess();
		}

		// Token: 0x17000B93 RID: 2963
		// (get) Token: 0x060032CE RID: 13006 RVA: 0x00026F7D File Offset: 0x0002517D
		public ICollection<TKey> Keys
		{
			get
			{
				return new IndexedDictionary<TKey, TValue>.KeyCollection(this);
			}
		}

		// Token: 0x17000B94 RID: 2964
		// (get) Token: 0x060032CF RID: 13007 RVA: 0x00026F85 File Offset: 0x00025185
		public ICollection<TValue> Values
		{
			get
			{
				return new IndexedDictionary<TKey, TValue>.ValueCollection(this);
			}
		}

		// Token: 0x060032D0 RID: 13008 RVA: 0x00026F8D File Offset: 0x0002518D
		void ICollection<KeyValuePair<!0, !1>>.RsJJjFtbWHzXCXpKMeuHWGbWBXQy(KeyValuePair<TKey, TValue> A_1)
		{
			this.Add(A_1.Key, A_1.Value);
		}

		// Token: 0x060032D1 RID: 13009 RVA: 0x000AEF60 File Offset: 0x000AD160
		bool ICollection<KeyValuePair<!0, !1>>.rPmSgpdgQKkLtRojWgLvhafXCTAx(KeyValuePair<TKey, TValue> A_1)
		{
			int num = this.IndexOfKey(A_1.Key);
			if (num < 0)
			{
				return false;
			}
			IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy rjxayHgQJcfjxIdKDssMrTyokZsy = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[num];
			return this.HlWGmhNZYUjYNWKMnheOEAVPUJYU.Equals(A_1.Value, rjxayHgQJcfjxIdKDssMrTyokZsy.IJSoOyhwKDltQGHjONzvDvMUCpgl);
		}

		// Token: 0x060032D2 RID: 13010 RVA: 0x000AEFAC File Offset: 0x000AD1AC
		void ICollection<KeyValuePair<!0, !1>>.YXUZjezFxGQBemYQehIYpxilkfHA(KeyValuePair<TKey, TValue>[] A_1, int A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (A_2 < 0 || A_2 > A_1.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (A_1.Length - A_2 < this.Count)
			{
				throw new Exception();
			}
			int count = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
			for (int i = 0; i < count; i++)
			{
				A_1[A_2++] = new KeyValuePair<TKey, TValue>(this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA, this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl);
			}
		}

		// Token: 0x17000B95 RID: 2965
		// (get) Token: 0x060032D3 RID: 13011 RVA: 0x00003E2B File Offset: 0x0000202B
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060032D4 RID: 13012 RVA: 0x000AF044 File Offset: 0x000AD244
		bool ICollection<KeyValuePair<!0, !1>>.avHDDGjbKyAoLfmqJILsWLPbyHzTB(KeyValuePair<TKey, TValue> A_1)
		{
			if (this.BiTzfeyJInNGwJnmmelMdAiXlzpE)
			{
				bool result = false;
				for (int i = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count - 1; i >= 0; i--)
				{
					IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy rjxayHgQJcfjxIdKDssMrTyokZsy = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i];
					if (this.HlWGmhNZYUjYNWKMnheOEAVPUJYU.Equals(A_1.Value, rjxayHgQJcfjxIdKDssMrTyokZsy.IJSoOyhwKDltQGHjONzvDvMUCpgl))
					{
						this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.RemoveAt(i);
						result = true;
					}
				}
				return result;
			}
			int num = this.IndexOfKey(A_1.Key);
			if (num < 0)
			{
				return false;
			}
			IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy rjxayHgQJcfjxIdKDssMrTyokZsy2 = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[num];
			if (!this.HlWGmhNZYUjYNWKMnheOEAVPUJYU.Equals(A_1.Value, rjxayHgQJcfjxIdKDssMrTyokZsy2.IJSoOyhwKDltQGHjONzvDvMUCpgl))
			{
				return false;
			}
			this.RemoveAt(num);
			return true;
		}

		// Token: 0x060032D5 RID: 13013 RVA: 0x00026FA3 File Offset: 0x000251A3
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new IndexedDictionary<TKey, TValue>.Enumerator(this, 1);
		}

		// Token: 0x060032D6 RID: 13014 RVA: 0x00026FA3 File Offset: 0x000251A3
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new IndexedDictionary<TKey, TValue>.Enumerator(this, 1);
		}

		// Token: 0x17000B96 RID: 2966
		TValue IDictionary<!0, !1>.this[TKey]
		{
			get
			{
				int num = this.IndexOfKey(A_1);
				if (num < 0)
				{
					string str = "Key \"";
					TKey tkey = A_1;
					throw new KeyNotFoundException(str + ((tkey != null) ? tkey.ToString() : null) + "\" does not exist.");
				}
				return this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[num].IJSoOyhwKDltQGHjONzvDvMUCpgl;
			}
			set
			{
				this.SetValue(A_1, value);
			}
		}

		// Token: 0x060032D9 RID: 13017 RVA: 0x00026FBB File Offset: 0x000251BB
		void IDictionary.Add(object key, object value)
		{
			this.Add((TKey)((object)key), (TValue)((object)value));
		}

		// Token: 0x060032DA RID: 13018 RVA: 0x00026FCF File Offset: 0x000251CF
		bool IDictionary.Contains(object key)
		{
			return this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x060032DB RID: 13019 RVA: 0x00026FDD File Offset: 0x000251DD
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new IndexedDictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x17000B97 RID: 2967
		// (get) Token: 0x060032DC RID: 13020 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IDictionary.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000B98 RID: 2968
		// (get) Token: 0x060032DD RID: 13021 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IDictionary.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000B99 RID: 2969
		// (get) Token: 0x060032DE RID: 13022 RVA: 0x00026F7D File Offset: 0x0002517D
		ICollection IDictionary.Keys
		{
			get
			{
				return new IndexedDictionary<TKey, TValue>.KeyCollection(this);
			}
		}

		// Token: 0x060032DF RID: 13023 RVA: 0x00026FEB File Offset: 0x000251EB
		void IDictionary.Remove(object key)
		{
			this.Remove((TKey)((object)key));
		}

		// Token: 0x17000B9A RID: 2970
		// (get) Token: 0x060032E0 RID: 13024 RVA: 0x00026F85 File Offset: 0x00025185
		ICollection IDictionary.Values
		{
			get
			{
				return new IndexedDictionary<TKey, TValue>.ValueCollection(this);
			}
		}

		// Token: 0x17000B9B RID: 2971
		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary<!0, !1>)this)[(TKey)((object)key)];
			}
			set
			{
				((IDictionary<!0, !1>)this)[(TKey)((object)key)] = (TValue)((object)value);
			}
		}

		// Token: 0x060032E3 RID: 13027 RVA: 0x000AF15C File Offset: 0x000AD35C
		void ICollection.CopyTo(Array array, int index)
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
			int count = this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA, this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl), index++);
			}
		}

		// Token: 0x17000B9C RID: 2972
		// (get) Token: 0x060032E4 RID: 13028 RVA: 0x00027021 File Offset: 0x00025221
		bool ICollection.IsSynchronized
		{
			get
			{
				return ((ICollection)this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA).IsSynchronized;
			}
		}

		// Token: 0x17000B9D RID: 2973
		// (get) Token: 0x060032E5 RID: 13029 RVA: 0x0002702E File Offset: 0x0002522E
		object ICollection.SyncRoot
		{
			get
			{
				return ((ICollection)this.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA).SyncRoot;
			}
		}

		// Token: 0x17000B9E RID: 2974
		TValue Rewired.Utils.Interfaces.IReadOnlyList<!1>.this[int]
		{
			get
			{
				return this[A_1];
			}
		}

		// Token: 0x060032E7 RID: 13031 RVA: 0x00027044 File Offset: 0x00025244
		int Rewired.Utils.Interfaces.IReadOnlyList<!1>.vsxnEpnasvJCFLjuwuFBZDIaXExU(TValue A_1)
		{
			return this.IndexOfValue(A_1);
		}

		// Token: 0x060032E8 RID: 13032 RVA: 0x0002704D File Offset: 0x0002524D
		bool Rewired.Utils.Interfaces.IReadOnlyList<!1>.qblGaMxNGXDSWwDsgRvSHcdtoKXA(TValue A_1)
		{
			return this.ContainsValue(A_1);
		}

		// Token: 0x17000B9F RID: 2975
		// (get) Token: 0x060032E9 RID: 13033 RVA: 0x00027056 File Offset: 0x00025256
		int IReadOnlyList.Count
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x17000BA0 RID: 2976
		object IReadOnlyList.this[int]
		{
			get
			{
				return this[A_1];
			}
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x0002706C File Offset: 0x0002526C
		int IReadOnlyList.zUMepijVNdxDJxrvCBTERLmlyOZo(object A_1)
		{
			return this.IndexOfValue((TValue)((object)A_1));
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x0002707A File Offset: 0x0002527A
		bool IReadOnlyList.DmhGykimKXjfMMMwNdnFjiIgvqdlB(object A_1)
		{
			return this.ContainsValue((TValue)((object)A_1));
		}

		// Token: 0x04001B8E RID: 7054
		private static readonly bool StsbfyFCjdTghAEDyoFxqnatrNpu = ReflectionTools.IsValueType(typeof(TKey));

		// Token: 0x04001B8F RID: 7055
		private static readonly bool yrqPtqUJFUNdvXwkRGRkpHOjslhW = ReflectionTools.IsValueType(typeof(TValue));

		// Token: 0x04001B90 RID: 7056
		private IEqualityComparer<TKey> pfTyFvbLgvMuBgkZChhkWiyKjmHH = EqualityComparerNoAlloc<TKey>.Default;

		// Token: 0x04001B91 RID: 7057
		private IEqualityComparer<TValue> HlWGmhNZYUjYNWKMnheOEAVPUJYU = EqualityComparerNoAlloc<TValue>.Default;

		// Token: 0x04001B92 RID: 7058
		private readonly AList<IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy> HVTdMFWGJXIvFwxGrdIAGAAoUnyUA;

		// Token: 0x04001B93 RID: 7059
		private readonly ADictionary<TKey, int> nLcEXKeLyEBJkENhAdwUmcqChWscc;

		// Token: 0x04001B94 RID: 7060
		private bool BiTzfeyJInNGwJnmmelMdAiXlzpE;

		// Token: 0x020004E9 RID: 1257
		private struct RJXayHgQJcfjxIdKDssMrTyokZsy
		{
			// Token: 0x060032EE RID: 13038 RVA: 0x000270B2 File Offset: 0x000252B2
			public RJXayHgQJcfjxIdKDssMrTyokZsy(\u0001 A_1, \u0002 A_2)
			{
				this.KJdhyQqwpXjyITZzOljCvmgXFqfeA = A_1;
				this.IJSoOyhwKDltQGHjONzvDvMUCpgl = A_2;
			}

			// Token: 0x060032EF RID: 13039 RVA: 0x000270C2 File Offset: 0x000252C2
			public KeyValuePair<\u0001, \u0002> mxOnxTKejphnmcygZzczUvYgrctWA()
			{
				return new KeyValuePair<\u0001, \u0002>(this.KJdhyQqwpXjyITZzOljCvmgXFqfeA, this.IJSoOyhwKDltQGHjONzvDvMUCpgl);
			}

			// Token: 0x04001B95 RID: 7061
			public \u0001 KJdhyQqwpXjyITZzOljCvmgXFqfeA;

			// Token: 0x04001B96 RID: 7062
			public \u0002 IJSoOyhwKDltQGHjONzvDvMUCpgl;
		}

		// Token: 0x020004EA RID: 1258
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		[Serializable]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			// Token: 0x060032F0 RID: 13040 RVA: 0x000270D5 File Offset: 0x000252D5
			internal Enumerator(IndexedDictionary<TKey, TValue> A_1, int A_2)
			{
				this.aPjcEpAQReYsTgMUzHUMZYpTgaDR = A_1;
				this.QjittoPkCzGoNcygABtQgNfbmBbZB = A_1.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version;
				this.OwZidbLqrPIdzRqjWmZxJMWGmUOb = 0;
				this.CgzLMgEjAthYqgKqMdUEOuxCrDAbA = A_2;
				this.UqzDUiDztCNnpuYxrVAlrdVoqLUj = default(KeyValuePair<TKey, TValue>);
			}

			// Token: 0x060032F1 RID: 13041 RVA: 0x000AF200 File Offset: 0x000AD400
			public bool MoveNext()
			{
				if (this.QjittoPkCzGoNcygABtQgNfbmBbZB != this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version)
				{
					throw new Exception();
				}
				if (this.OwZidbLqrPIdzRqjWmZxJMWGmUOb < this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
				{
					this.UqzDUiDztCNnpuYxrVAlrdVoqLUj = new KeyValuePair<TKey, TValue>(this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[this.OwZidbLqrPIdzRqjWmZxJMWGmUOb].KJdhyQqwpXjyITZzOljCvmgXFqfeA, this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[this.OwZidbLqrPIdzRqjWmZxJMWGmUOb].IJSoOyhwKDltQGHjONzvDvMUCpgl);
					this.OwZidbLqrPIdzRqjWmZxJMWGmUOb++;
					return true;
				}
				this.OwZidbLqrPIdzRqjWmZxJMWGmUOb = this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1;
				this.UqzDUiDztCNnpuYxrVAlrdVoqLUj = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			// Token: 0x17000BA1 RID: 2977
			// (get) Token: 0x060032F2 RID: 13042 RVA: 0x00027109 File Offset: 0x00025309
			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					return this.UqzDUiDztCNnpuYxrVAlrdVoqLUj;
				}
			}

			// Token: 0x060032F3 RID: 13043 RVA: 0x00002FF9 File Offset: 0x000011F9
			public void Dispose()
			{
			}

			// Token: 0x17000BA2 RID: 2978
			// (get) Token: 0x060032F4 RID: 13044 RVA: 0x000AF2C4 File Offset: 0x000AD4C4
			object IEnumerator.Current
			{
				get
				{
					if (this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == 0 || this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1)
					{
						throw new Exception();
					}
					if (this.CgzLMgEjAthYqgKqMdUEOuxCrDAbA == 1)
					{
						return new DictionaryEntry(this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Key, this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Value);
					}
					return new KeyValuePair<TKey, TValue>(this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Key, this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Value);
				}
			}

			// Token: 0x060032F5 RID: 13045 RVA: 0x00027111 File Offset: 0x00025311
			void IEnumerator.Reset()
			{
				if (this.QjittoPkCzGoNcygABtQgNfbmBbZB != this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version)
				{
					throw new Exception();
				}
				this.OwZidbLqrPIdzRqjWmZxJMWGmUOb = 0;
				this.UqzDUiDztCNnpuYxrVAlrdVoqLUj = default(KeyValuePair<TKey, TValue>);
			}

			// Token: 0x17000BA3 RID: 2979
			// (get) Token: 0x060032F6 RID: 13046 RVA: 0x000AF350 File Offset: 0x000AD550
			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == 0 || this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Key, this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Value);
				}
			}

			// Token: 0x17000BA4 RID: 2980
			// (get) Token: 0x060032F7 RID: 13047 RVA: 0x00027144 File Offset: 0x00025344
			object IDictionaryEnumerator.Key
			{
				get
				{
					if (this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == 0 || this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1)
					{
						throw new Exception();
					}
					return this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Key;
				}
			}

			// Token: 0x17000BA5 RID: 2981
			// (get) Token: 0x060032F8 RID: 13048 RVA: 0x0002717E File Offset: 0x0002537E
			object IDictionaryEnumerator.Value
			{
				get
				{
					if (this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == 0 || this.OwZidbLqrPIdzRqjWmZxJMWGmUOb == this.aPjcEpAQReYsTgMUzHUMZYpTgaDR.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1)
					{
						throw new Exception();
					}
					return this.UqzDUiDztCNnpuYxrVAlrdVoqLUj.Value;
				}
			}

			// Token: 0x04001B97 RID: 7063
			private IndexedDictionary<TKey, TValue> aPjcEpAQReYsTgMUzHUMZYpTgaDR;

			// Token: 0x04001B98 RID: 7064
			private int QjittoPkCzGoNcygABtQgNfbmBbZB;

			// Token: 0x04001B99 RID: 7065
			private int OwZidbLqrPIdzRqjWmZxJMWGmUOb;

			// Token: 0x04001B9A RID: 7066
			private KeyValuePair<TKey, TValue> UqzDUiDztCNnpuYxrVAlrdVoqLUj;

			// Token: 0x04001B9B RID: 7067
			private int CgzLMgEjAthYqgKqMdUEOuxCrDAbA;

			// Token: 0x04001B9C RID: 7068
			internal const int DictEntry = 1;

			// Token: 0x04001B9D RID: 7069
			internal const int KeyValuePair = 2;
		}

		// Token: 0x020004EB RID: 1259
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		[Serializable]
		public sealed class KeyCollection : ICollection<!0>, IEnumerable<!0>, IEnumerable, ICollection
		{
			// Token: 0x060032F9 RID: 13049 RVA: 0x000271B8 File Offset: 0x000253B8
			public KeyCollection(IndexedDictionary<TKey, TValue> A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA = A_1;
			}

			// Token: 0x060032FA RID: 13050 RVA: 0x000271D5 File Offset: 0x000253D5
			public IndexedDictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator()
			{
				return new IndexedDictionary<TKey, TValue>.KeyCollection.Enumerator(this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA);
			}

			// Token: 0x060032FB RID: 13051 RVA: 0x000AF3AC File Offset: 0x000AD5AC
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
				if (array.Length - index < this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.Count)
				{
					throw new Exception();
				}
				int count = this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
				IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy[] items = this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA;
				}
			}

			// Token: 0x17000BA6 RID: 2982
			// (get) Token: 0x060032FC RID: 13052 RVA: 0x000271E2 File Offset: 0x000253E2
			public int Count
			{
				get
				{
					return this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.Count;
				}
			}

			// Token: 0x17000BA7 RID: 2983
			// (get) Token: 0x060032FD RID: 13053 RVA: 0x000042E2 File Offset: 0x000024E2
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060032FE RID: 13054 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!0>.oTslKThupKRiCUbaMfGkqjIeAIJX(TKey A_1)
			{
				throw new Exception();
			}

			// Token: 0x060032FF RID: 13055 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!0>.IYTDPJflaoSkyYnpNzTYiGRuOyBTA()
			{
				throw new Exception();
			}

			// Token: 0x06003300 RID: 13056 RVA: 0x000271EF File Offset: 0x000253EF
			bool ICollection<!0>.oPgLIKAkcyMuNhAlqUrWJjTdFFLU(TKey A_1)
			{
				return this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.ContainsKey(A_1);
			}

			// Token: 0x06003301 RID: 13057 RVA: 0x00026C15 File Offset: 0x00024E15
			bool ICollection<!0>.fxjXtCiEazCITvaolXdExEkOxhMd(TKey A_1)
			{
				throw new Exception();
			}

			// Token: 0x06003302 RID: 13058 RVA: 0x000271FD File Offset: 0x000253FD
			IEnumerator<TKey> IEnumerable<!0>.HPCljaKuTOirUGCWLtYGiEbJfqjDA()
			{
				return new IndexedDictionary<TKey, TValue>.KeyCollection.Enumerator(this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA);
			}

			// Token: 0x06003303 RID: 13059 RVA: 0x000271FD File Offset: 0x000253FD
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new IndexedDictionary<TKey, TValue>.KeyCollection.Enumerator(this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA);
			}

			// Token: 0x06003304 RID: 13060 RVA: 0x000AF43C File Offset: 0x000AD63C
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
				if (array.Length - index < this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.Count)
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
				int count = this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
				IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy[] items = this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].KJdhyQqwpXjyITZzOljCvmgXFqfeA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}

			// Token: 0x17000BA8 RID: 2984
			// (get) Token: 0x06003305 RID: 13061 RVA: 0x00003E2B File Offset: 0x0000202B
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000BA9 RID: 2985
			// (get) Token: 0x06003306 RID: 13062 RVA: 0x0002720F File Offset: 0x0002540F
			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)this.IxUwBgbNDeivOlBPEaAhKaHDgdNjA).SyncRoot;
				}
			}

			// Token: 0x04001B9E RID: 7070
			private IndexedDictionary<TKey, TValue> IxUwBgbNDeivOlBPEaAhKaHDgdNjA;

			// Token: 0x020004EC RID: 1260
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			[Serializable]
			public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable
			{
				// Token: 0x06003307 RID: 13063 RVA: 0x0002721C File Offset: 0x0002541C
				internal Enumerator(IndexedDictionary<TKey, TValue> A_1)
				{
					this.nwNsQdHxMMJuOuajPZUWkgVMslAe = A_1;
					this.HRLfggUpNoANbDMGdSuKeHFoJPCQA = A_1.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version;
					this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ = 0;
					this.iSwfLalYlIBhNgrgjEGdIaaqbGhP = default(TKey);
				}

				// Token: 0x06003308 RID: 13064 RVA: 0x00002FF9 File Offset: 0x000011F9
				public void Dispose()
				{
				}

				// Token: 0x06003309 RID: 13065 RVA: 0x000AF52C File Offset: 0x000AD72C
				public bool MoveNext()
				{
					if (this.HRLfggUpNoANbDMGdSuKeHFoJPCQA != this.nwNsQdHxMMJuOuajPZUWkgVMslAe.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version)
					{
						throw new Exception();
					}
					if (this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ < this.nwNsQdHxMMJuOuajPZUWkgVMslAe.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
					{
						this.iSwfLalYlIBhNgrgjEGdIaaqbGhP = this.nwNsQdHxMMJuOuajPZUWkgVMslAe.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ].KJdhyQqwpXjyITZzOljCvmgXFqfeA;
						this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ++;
						return true;
					}
					this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ = this.nwNsQdHxMMJuOuajPZUWkgVMslAe.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1;
					this.iSwfLalYlIBhNgrgjEGdIaaqbGhP = default(TKey);
					return false;
				}

				// Token: 0x17000BAA RID: 2986
				// (get) Token: 0x0600330A RID: 13066 RVA: 0x00027249 File Offset: 0x00025449
				public TKey Current
				{
					get
					{
						return this.iSwfLalYlIBhNgrgjEGdIaaqbGhP;
					}
				}

				// Token: 0x17000BAB RID: 2987
				// (get) Token: 0x0600330B RID: 13067 RVA: 0x00027251 File Offset: 0x00025451
				object IEnumerator.Current
				{
					get
					{
						if (this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ == 0 || this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ == this.nwNsQdHxMMJuOuajPZUWkgVMslAe.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1)
						{
							throw new Exception();
						}
						return this.iSwfLalYlIBhNgrgjEGdIaaqbGhP;
					}
				}

				// Token: 0x0600330C RID: 13068 RVA: 0x00027286 File Offset: 0x00025486
				void IEnumerator.Reset()
				{
					if (this.HRLfggUpNoANbDMGdSuKeHFoJPCQA != this.nwNsQdHxMMJuOuajPZUWkgVMslAe.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version)
					{
						throw new Exception();
					}
					this.qrKJcYmHaHLwjfxmjstTEzcSPgDJ = 0;
					this.iSwfLalYlIBhNgrgjEGdIaaqbGhP = default(TKey);
				}

				// Token: 0x04001B9F RID: 7071
				private IndexedDictionary<TKey, TValue> nwNsQdHxMMJuOuajPZUWkgVMslAe;

				// Token: 0x04001BA0 RID: 7072
				private int qrKJcYmHaHLwjfxmjstTEzcSPgDJ;

				// Token: 0x04001BA1 RID: 7073
				private int HRLfggUpNoANbDMGdSuKeHFoJPCQA;

				// Token: 0x04001BA2 RID: 7074
				private TKey iSwfLalYlIBhNgrgjEGdIaaqbGhP;
			}
		}

		// Token: 0x020004ED RID: 1261
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		[Serializable]
		public sealed class ValueCollection : ICollection<!1>, IEnumerable<!1>, IEnumerable, ICollection
		{
			// Token: 0x0600330D RID: 13069 RVA: 0x000272B9 File Offset: 0x000254B9
			public ValueCollection(IndexedDictionary<TKey, TValue> A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				this.dAkahIzQiJGCWGjNckeBYyVzzMxKA = A_1;
			}

			// Token: 0x0600330E RID: 13070 RVA: 0x000272D6 File Offset: 0x000254D6
			public IndexedDictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator()
			{
				return new IndexedDictionary<TKey, TValue>.ValueCollection.Enumerator(this.dAkahIzQiJGCWGjNckeBYyVzzMxKA);
			}

			// Token: 0x0600330F RID: 13071 RVA: 0x000AF5CC File Offset: 0x000AD7CC
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
				if (array.Length - index < this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.Count)
				{
					throw new Exception();
				}
				int count = this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
				IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy[] items = this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl;
				}
			}

			// Token: 0x17000BAC RID: 2988
			// (get) Token: 0x06003310 RID: 13072 RVA: 0x000272E3 File Offset: 0x000254E3
			public int Count
			{
				get
				{
					return this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.Count;
				}
			}

			// Token: 0x17000BAD RID: 2989
			// (get) Token: 0x06003311 RID: 13073 RVA: 0x000042E2 File Offset: 0x000024E2
			bool ICollection<!1>.IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06003312 RID: 13074 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!1>.HJXDftiqNWsaVGbqMKxMhETvunqVA(TValue A_1)
			{
				throw new Exception();
			}

			// Token: 0x06003313 RID: 13075 RVA: 0x00026C15 File Offset: 0x00024E15
			bool ICollection<!1>.YSNGnPhIsJmtkeNKNEVbAhEbBMNrb(TValue A_1)
			{
				throw new Exception();
			}

			// Token: 0x06003314 RID: 13076 RVA: 0x00026C15 File Offset: 0x00024E15
			void ICollection<!1>.AbFcKtReYhpSTwhMRykTDDQGmvjp()
			{
				throw new Exception();
			}

			// Token: 0x06003315 RID: 13077 RVA: 0x000272F0 File Offset: 0x000254F0
			bool ICollection<!1>.nnqDamBeVsBPQgHrmpZUeiKnuSmo(TValue A_1)
			{
				return this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.ContainsValue(A_1);
			}

			// Token: 0x06003316 RID: 13078 RVA: 0x000272FE File Offset: 0x000254FE
			IEnumerator<TValue> IEnumerable<!1>.thVZIozAZbUmWgXnVOWkIsDmZkgL()
			{
				return new IndexedDictionary<TKey, TValue>.ValueCollection.Enumerator(this.dAkahIzQiJGCWGjNckeBYyVzzMxKA);
			}

			// Token: 0x06003317 RID: 13079 RVA: 0x000272FE File Offset: 0x000254FE
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new IndexedDictionary<TKey, TValue>.ValueCollection.Enumerator(this.dAkahIzQiJGCWGjNckeBYyVzzMxKA);
			}

			// Token: 0x06003318 RID: 13080 RVA: 0x000AF658 File Offset: 0x000AD858
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
				if (array.Length - index < this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.Count)
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
				int count = this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count;
				IndexedDictionary<TKey, TValue>.RJXayHgQJcfjxIdKDssMrTyokZsy[] items = this.dAkahIzQiJGCWGjNckeBYyVzzMxKA.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].IJSoOyhwKDltQGHjONzvDvMUCpgl;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}

			// Token: 0x17000BAE RID: 2990
			// (get) Token: 0x06003319 RID: 13081 RVA: 0x00003E2B File Offset: 0x0000202B
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000BAF RID: 2991
			// (get) Token: 0x0600331A RID: 13082 RVA: 0x00027310 File Offset: 0x00025510
			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)this.dAkahIzQiJGCWGjNckeBYyVzzMxKA).SyncRoot;
				}
			}

			// Token: 0x04001BA3 RID: 7075
			private IndexedDictionary<TKey, TValue> dAkahIzQiJGCWGjNckeBYyVzzMxKA;

			// Token: 0x020004EE RID: 1262
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			[Serializable]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				// Token: 0x0600331B RID: 13083 RVA: 0x0002731D File Offset: 0x0002551D
				internal Enumerator(IndexedDictionary<TKey, TValue> A_1)
				{
					this.sozmDcnGhznawMgXtLdhPlYMyeCd = A_1;
					this.MiMRBAyovmySKCRycXukiwpaYNkG = A_1.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version;
					this.bGkcHenSNSkdTHoQbFnCCObfeFpUA = 0;
					this.vKeRmkSuRLWWucbCPrKfEQhSEqAIA = default(TValue);
				}

				// Token: 0x0600331C RID: 13084 RVA: 0x00002FF9 File Offset: 0x000011F9
				public void Dispose()
				{
				}

				// Token: 0x0600331D RID: 13085 RVA: 0x000AF748 File Offset: 0x000AD948
				public bool MoveNext()
				{
					if (this.MiMRBAyovmySKCRycXukiwpaYNkG != this.sozmDcnGhznawMgXtLdhPlYMyeCd.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version)
					{
						throw new Exception();
					}
					if (this.bGkcHenSNSkdTHoQbFnCCObfeFpUA < this.sozmDcnGhznawMgXtLdhPlYMyeCd.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count)
					{
						this.vKeRmkSuRLWWucbCPrKfEQhSEqAIA = this.sozmDcnGhznawMgXtLdhPlYMyeCd.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._items[this.bGkcHenSNSkdTHoQbFnCCObfeFpUA].IJSoOyhwKDltQGHjONzvDvMUCpgl;
						this.bGkcHenSNSkdTHoQbFnCCObfeFpUA++;
						return true;
					}
					this.bGkcHenSNSkdTHoQbFnCCObfeFpUA = this.sozmDcnGhznawMgXtLdhPlYMyeCd.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1;
					this.vKeRmkSuRLWWucbCPrKfEQhSEqAIA = default(TValue);
					return false;
				}

				// Token: 0x17000BB0 RID: 2992
				// (get) Token: 0x0600331E RID: 13086 RVA: 0x0002734A File Offset: 0x0002554A
				public TValue Current
				{
					get
					{
						return this.vKeRmkSuRLWWucbCPrKfEQhSEqAIA;
					}
				}

				// Token: 0x17000BB1 RID: 2993
				// (get) Token: 0x0600331F RID: 13087 RVA: 0x00027352 File Offset: 0x00025552
				object IEnumerator.Current
				{
					get
					{
						if (this.bGkcHenSNSkdTHoQbFnCCObfeFpUA == 0 || this.bGkcHenSNSkdTHoQbFnCCObfeFpUA == this.sozmDcnGhznawMgXtLdhPlYMyeCd.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA._count + 1)
						{
							throw new Exception();
						}
						return this.vKeRmkSuRLWWucbCPrKfEQhSEqAIA;
					}
				}

				// Token: 0x06003320 RID: 13088 RVA: 0x00027387 File Offset: 0x00025587
				void IEnumerator.Reset()
				{
					if (this.MiMRBAyovmySKCRycXukiwpaYNkG != this.sozmDcnGhznawMgXtLdhPlYMyeCd.HVTdMFWGJXIvFwxGrdIAGAAoUnyUA.Version)
					{
						throw new Exception();
					}
					this.bGkcHenSNSkdTHoQbFnCCObfeFpUA = 0;
					this.vKeRmkSuRLWWucbCPrKfEQhSEqAIA = default(TValue);
				}

				// Token: 0x04001BA4 RID: 7076
				private IndexedDictionary<TKey, TValue> sozmDcnGhznawMgXtLdhPlYMyeCd;

				// Token: 0x04001BA5 RID: 7077
				private int bGkcHenSNSkdTHoQbFnCCObfeFpUA;

				// Token: 0x04001BA6 RID: 7078
				private int MiMRBAyovmySKCRycXukiwpaYNkG;

				// Token: 0x04001BA7 RID: 7079
				private TValue vKeRmkSuRLWWucbCPrKfEQhSEqAIA;
			}
		}
	}
}
