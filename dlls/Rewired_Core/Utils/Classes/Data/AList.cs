using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004F3 RID: 1267
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	[Serializable]
	internal class AList<T> : IList<T>, ICollection<T>, IEnumerable<!0>, IEnumerable, IList, ICollection
	{
		// Token: 0x17000BC0 RID: 3008
		// (get) Token: 0x06003363 RID: 13155 RVA: 0x00027743 File Offset: 0x00025943
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000BC1 RID: 3009
		// (get) Token: 0x06003364 RID: 13156 RVA: 0x0002774B File Offset: 0x0002594B
		public int Capacity
		{
			get
			{
				return this.kigdpseeiNfsLbmCigByEmdmWewNA;
			}
		}

		// Token: 0x17000BC2 RID: 3010
		// (get) Token: 0x06003365 RID: 13157 RVA: 0x00027753 File Offset: 0x00025953
		public int FreeSpace
		{
			get
			{
				return this.RCHhGuDxbrKAROZkwAkeHOLDKmbi - this._count;
			}
		}

		// Token: 0x17000BC3 RID: 3011
		// (get) Token: 0x06003366 RID: 13158 RVA: 0x00027762 File Offset: 0x00025962
		public bool IsFixedSize
		{
			get
			{
				return !this.urxMFaAoIllKUvRpEknskGNytNzA;
			}
		}

		// Token: 0x17000BC4 RID: 3012
		// (get) Token: 0x06003367 RID: 13159 RVA: 0x0002776D File Offset: 0x0002596D
		// (set) Token: 0x06003368 RID: 13160 RVA: 0x00027775 File Offset: 0x00025975
		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return this.wRiPqbOKYWeBexNiZcPbJHUyZrph;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				this.wRiPqbOKYWeBexNiZcPbJHUyZrph = value;
			}
		}

		// Token: 0x17000BC5 RID: 3013
		// (get) Token: 0x06003369 RID: 13161 RVA: 0x00027788 File Offset: 0x00025988
		public int Version
		{
			get
			{
				return this.bdbqzgawlGauyceLbGfQfnxGLcVBA;
			}
		}

		// Token: 0x17000BC6 RID: 3014
		public T this[int index]
		{
			get
			{
				if (index >= this._count)
				{
					throw new IndexOutOfRangeException();
				}
				return this._items[index];
			}
			set
			{
				if (index >= this._count)
				{
					throw new IndexOutOfRangeException();
				}
				this._items[index] = value;
				this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
			}
		}

		// Token: 0x0600336C RID: 13164 RVA: 0x000277D9 File Offset: 0x000259D9
		public AList() : this(0, 0, 0)
		{
		}

		// Token: 0x0600336D RID: 13165 RVA: 0x000277E4 File Offset: 0x000259E4
		public AList(int A_1) : this(A_1, 0, 0)
		{
		}

		// Token: 0x0600336E RID: 13166 RVA: 0x000277EF File Offset: 0x000259EF
		public AList(int A_1, int A_2) : this(A_1, A_2, 0)
		{
		}

		// Token: 0x0600336F RID: 13167 RVA: 0x000B020C File Offset: 0x000AE40C
		public AList(int A_1, int A_2, int A_3)
		{
			this.wRiPqbOKYWeBexNiZcPbJHUyZrph = EqualityComparerNoAlloc<T>.Default;
			base..ctor();
			if (A_1 < 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity cannot be a negative value.");
			}
			if (A_3 < 0)
			{
				A_3 = 0;
			}
			if (A_2 < 0)
			{
				A_2 = 0;
			}
			if (A_1 > 0 && A_2 > 0 && A_2 < A_1)
			{
				throw new ArgumentOutOfRangeException("maxCapacity must be >= startingCapacity or zero for unlimited.");
			}
			if (A_2 == 0 || A_2 > A_1)
			{
				this.urxMFaAoIllKUvRpEknskGNytNzA = true;
			}
			if (!this.urxMFaAoIllKUvRpEknskGNytNzA && A_1 == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (this.urxMFaAoIllKUvRpEknskGNytNzA && A_3 == 0)
			{
				this.RKWdaSwypbivaoYUFKXskNJUFLCg = true;
				A_3 = 1;
			}
			this.xYGjcaeqBotfeRmnrYvpiCxybSYs = A_3;
			this.kigdpseeiNfsLbmCigByEmdmWewNA = A_1;
			this.RCHhGuDxbrKAROZkwAkeHOLDKmbi = ((A_2 == 0) ? int.MaxValue : A_2);
			this._count = 0;
			if (this.kigdpseeiNfsLbmCigByEmdmWewNA == 0)
			{
				this._items = AList<T>.TrOOHiiijzapRdkXlIGhDXKYbEhDA;
				return;
			}
			this._items = new T[A_1];
		}

		// Token: 0x06003370 RID: 13168 RVA: 0x000277FA File Offset: 0x000259FA
		public AList(IEnumerable<T> A_1) : this(A_1, 0, 0)
		{
		}

		// Token: 0x06003371 RID: 13169 RVA: 0x000B02E0 File Offset: 0x000AE4E0
		public AList(IEnumerable<T> A_1, int A_2, int A_3)
		{
			this.wRiPqbOKYWeBexNiZcPbJHUyZrph = EqualityComparerNoAlloc<T>.Default;
			base..ctor();
			if (A_1 == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (A_3 < 0)
			{
				A_3 = 0;
			}
			if (A_2 < 0)
			{
				A_2 = 0;
			}
			T[] array = null;
			ICollection<T> collection = A_1 as ICollection<!0>;
			if (collection != null)
			{
				int count = collection.Count;
				if (count == 0)
				{
					array = AList<T>.TrOOHiiijzapRdkXlIGhDXKYbEhDA;
				}
				else
				{
					array = new T[count];
					collection.CopyTo(array, 0);
				}
			}
			else
			{
				using (IEnumerator<T> enumerator = A_1.GetEnumerator())
				{
					List<T> list = new List<T>();
					while (enumerator.MoveNext())
					{
						!0 item = enumerator.Current;
						list.Add(item);
					}
					if (list.Count > 0)
					{
						array = list.ToArray();
					}
				}
			}
			int num = (array != null) ? array.Length : 0;
			if (num > 0 && A_2 > 0 && A_2 < num)
			{
				throw new ArgumentOutOfRangeException("maxCapacity must be >= startingCapacity or zero for unlimited.");
			}
			if (A_2 == 0 || A_2 > num)
			{
				this.urxMFaAoIllKUvRpEknskGNytNzA = true;
			}
			if (!this.urxMFaAoIllKUvRpEknskGNytNzA && num == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (this.urxMFaAoIllKUvRpEknskGNytNzA && A_3 == 0)
			{
				this.RKWdaSwypbivaoYUFKXskNJUFLCg = true;
				A_3 = 1;
			}
			this.xYGjcaeqBotfeRmnrYvpiCxybSYs = A_3;
			this.kigdpseeiNfsLbmCigByEmdmWewNA = num;
			this.RCHhGuDxbrKAROZkwAkeHOLDKmbi = ((A_2 == 0) ? int.MaxValue : A_2);
			this._items = ((array != null) ? array : AList<T>.TrOOHiiijzapRdkXlIGhDXKYbEhDA);
			this._count = num;
		}

		// Token: 0x06003372 RID: 13170 RVA: 0x000B0434 File Offset: 0x000AE634
		public T GetRandom()
		{
			if (this._count == 0)
			{
				return default(T);
			}
			return this._items[Random.Range(0, this._count)];
		}

		// Token: 0x06003373 RID: 13171 RVA: 0x000B046C File Offset: 0x000AE66C
		public int Add(T item)
		{
			if (this._count == this.kigdpseeiNfsLbmCigByEmdmWewNA && this.fiPidBhptvIgLmkqOtjMdaEGtdVc(this.xYGjcaeqBotfeRmnrYvpiCxybSYs, false) == 0)
			{
				return -1;
			}
			int count = this._count;
			this._items[count] = item;
			this._count++;
			return count;
		}

		// Token: 0x06003374 RID: 13172 RVA: 0x000B04BC File Offset: 0x000AE6BC
		public bool Add(T[] items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			if (items == null || items.Length == 0)
			{
				return true;
			}
			if (startIndex >= items.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count + startIndex > items.Length)
			{
				throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the array.");
			}
			if (count <= 0)
			{
				count = items.Length - startIndex;
			}
			if (count == 0)
			{
				return true;
			}
			int num = this.kigdpseeiNfsLbmCigByEmdmWewNA - this._count;
			if (count > num)
			{
				int num2 = this.fiPidBhptvIgLmkqOtjMdaEGtdVc(Math.Max(num, this.xYGjcaeqBotfeRmnrYvpiCxybSYs), true);
				if (num2 == 0)
				{
					return false;
				}
				if (num2 < count && !allowPartialAdd)
				{
					return false;
				}
				count = this.fiPidBhptvIgLmkqOtjMdaEGtdVc(Math.Max(num, this.xYGjcaeqBotfeRmnrYvpiCxybSYs), false);
			}
			Array.Copy(items, startIndex, this._items, this._count, count);
			this._count += count;
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
			return true;
		}

		// Token: 0x06003375 RID: 13173 RVA: 0x000B0584 File Offset: 0x000AE784
		public bool Add(AList<T> items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			if (items == null || items._count == 0)
			{
				return true;
			}
			if (startIndex >= items._count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count + startIndex > items._count)
			{
				throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the list.");
			}
			if (count <= 0)
			{
				count = items._count - startIndex;
			}
			if (count == 0)
			{
				return true;
			}
			int num = this.kigdpseeiNfsLbmCigByEmdmWewNA - this._count;
			if (count > num)
			{
				int num2 = this.fiPidBhptvIgLmkqOtjMdaEGtdVc(Math.Max(num, this.xYGjcaeqBotfeRmnrYvpiCxybSYs), true);
				if (num2 == 0)
				{
					return false;
				}
				if (num2 < count && !allowPartialAdd)
				{
					return false;
				}
				count = this.fiPidBhptvIgLmkqOtjMdaEGtdVc(Math.Max(num, this.xYGjcaeqBotfeRmnrYvpiCxybSYs), false);
			}
			Array.Copy(items._items, startIndex, this._items, this._count, count);
			this._count += count;
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
			return true;
		}

		// Token: 0x06003376 RID: 13174 RVA: 0x000B065C File Offset: 0x000AE85C
		public int AddIfUnique(T item)
		{
			int num = this.IndexOf(item);
			if (num >= 0)
			{
				return num;
			}
			return this.Add(item);
		}

		// Token: 0x06003377 RID: 13175 RVA: 0x000B0680 File Offset: 0x000AE880
		public int AddToFirstOpenSpace(T item)
		{
			T y = default(T);
			for (int i = 0; i < this._count; i++)
			{
				if (this.wRiPqbOKYWeBexNiZcPbJHUyZrph.Equals(this._items[i], y))
				{
					this._items[i] = item;
					return i;
				}
			}
			if (this._count < this.RCHhGuDxbrKAROZkwAkeHOLDKmbi)
			{
				return this.Add(item);
			}
			return -1;
		}

		// Token: 0x06003378 RID: 13176 RVA: 0x000B06E8 File Offset: 0x000AE8E8
		public int AddToFirstOpenSpace(T item, T openSpaceEquals)
		{
			for (int i = 0; i < this._count; i++)
			{
				if (this.wRiPqbOKYWeBexNiZcPbJHUyZrph.Equals(this._items[i], openSpaceEquals))
				{
					this._items[i] = item;
					return i;
				}
			}
			if (this._count < this.RCHhGuDxbrKAROZkwAkeHOLDKmbi)
			{
				return this.Add(item);
			}
			return -1;
		}

		// Token: 0x06003379 RID: 13177 RVA: 0x000B0748 File Offset: 0x000AE948
		public bool Insert(int index, T item)
		{
			if (index < 0 || index > this._count)
			{
				throw new IndexOutOfRangeException();
			}
			if (this._count == this.kigdpseeiNfsLbmCigByEmdmWewNA && this.fiPidBhptvIgLmkqOtjMdaEGtdVc(this.xYGjcaeqBotfeRmnrYvpiCxybSYs, false) == 0)
			{
				return false;
			}
			if (index < this._count)
			{
				Array.Copy(this._items, index, this._items, index + 1, this._count - index);
			}
			this._items[index] = item;
			this._count++;
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
			return true;
		}

		// Token: 0x0600337A RID: 13178 RVA: 0x000B07D8 File Offset: 0x000AE9D8
		public bool Remove(T item)
		{
			int num = this.IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			this.RemoveAt(num);
			return true;
		}

		// Token: 0x0600337B RID: 13179 RVA: 0x000B07FC File Offset: 0x000AE9FC
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this._count)
			{
				throw new IndexOutOfRangeException();
			}
			this._count--;
			if (index < this._count)
			{
				Array.Copy(this._items, index + 1, this._items, index, this._count - index);
			}
			this._items[this._count] = default(T);
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
		}

		// Token: 0x0600337C RID: 13180 RVA: 0x00027805 File Offset: 0x00025A05
		public bool Contains(T item)
		{
			return this.Contains(item, this.wRiPqbOKYWeBexNiZcPbJHUyZrph);
		}

		// Token: 0x0600337D RID: 13181 RVA: 0x000B0878 File Offset: 0x000AEA78
		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			for (int i = 0; i < this._count; i++)
			{
				if (comparer.Equals(this._items[i], item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x00027814 File Offset: 0x00025A14
		public int IndexOf(T item)
		{
			return this.IndexOf(item, this.wRiPqbOKYWeBexNiZcPbJHUyZrph);
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x00027823 File Offset: 0x00025A23
		public int IndexOf(T item, int index)
		{
			return this.IndexOf(item, index, this.wRiPqbOKYWeBexNiZcPbJHUyZrph);
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x00027833 File Offset: 0x00025A33
		public int IndexOf(T item, int index, int count)
		{
			return this.IndexOf(item, index, count, this.wRiPqbOKYWeBexNiZcPbJHUyZrph);
		}

		// Token: 0x06003381 RID: 13185 RVA: 0x000B08BC File Offset: 0x000AEABC
		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			for (int i = 0; i < this._count; i++)
			{
				if (comparer.Equals(this._items[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003382 RID: 13186 RVA: 0x000B0900 File Offset: 0x000AEB00
		public int IndexOf(T item, int index, IEqualityComparer<T> comparer)
		{
			if (index < 0 || index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			for (int i = index; i < this._count; i++)
			{
				if (comparer.Equals(this._items[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003383 RID: 13187 RVA: 0x000B0950 File Offset: 0x000AEB50
		public int IndexOf(T item, int index, int count, IEqualityComparer<T> comparer)
		{
			if (index < 0 || index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index + count > this._count)
			{
				throw new ArgumentOutOfRangeException();
			}
			int num = index + count;
			for (int i = index; i < num; i++)
			{
				if (comparer.Equals(this._items[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003384 RID: 13188 RVA: 0x00027844 File Offset: 0x00025A44
		public void Reverse()
		{
			this.Reverse(0, this.Count);
		}

		// Token: 0x06003385 RID: 13189 RVA: 0x000B09C0 File Offset: 0x000AEBC0
		public void Reverse(int index, int count)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this._count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			Array.Reverse<T>(this._items, index, count);
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x00027853 File Offset: 0x00025A53
		public void Sort()
		{
			this.Sort(0, this.Count, null);
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x00027863 File Offset: 0x00025A63
		public void Sort(IComparer<T> comparer)
		{
			this.Sort(0, this.Count, comparer);
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x000B0A18 File Offset: 0x000AEC18
		public void Sort(int index, int count, IComparer<T> comparer)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this._count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			Array.Sort<T>(this._items, index, count, comparer);
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x000B0A70 File Offset: 0x000AEC70
		public List<T> GetRange(int index, int count)
		{
			if (index < 0 || index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this._count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			T[] array = new T[count];
			Array.Copy(this._items, index, array, 0, count);
			return new List<T>(array);
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x00027873 File Offset: 0x00025A73
		public ReadOnlyCollection<T> AsReadOnly()
		{
			return new ReadOnlyCollection<T>(this);
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x0002787B File Offset: 0x00025A7B
		public bool Exists(Predicate<T> match)
		{
			return this.FindIndex(match) != -1;
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x000B0AD4 File Offset: 0x000AECD4
		public T Find(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			for (int i = 0; i < this._count; i++)
			{
				if (match(this._items[i]))
				{
					return this._items[i];
				}
			}
			return default(T);
		}

		// Token: 0x0600338D RID: 13197 RVA: 0x000B0B2C File Offset: 0x000AED2C
		public List<T> FindAll(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			List<T> list = new List<T>();
			for (int i = 0; i < this._count; i++)
			{
				if (match(this._items[i]))
				{
					list.Add(this._items[i]);
				}
			}
			return list;
		}

		// Token: 0x0600338E RID: 13198 RVA: 0x0002788A File Offset: 0x00025A8A
		public int FindIndex(Predicate<T> match)
		{
			return this.FindIndex(0, this._count, match);
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x0002789A File Offset: 0x00025A9A
		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return this.FindIndex(startIndex, this._count - startIndex, match);
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x000B0B88 File Offset: 0x000AED88
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			if (startIndex > this._count)
			{
				throw new ArgumentNullException("startIndex");
			}
			if (count < 0 || startIndex > this._count - count)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++)
			{
				if (match(this._items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003391 RID: 13201 RVA: 0x000B0BF4 File Offset: 0x000AEDF4
		public T FindLast(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			for (int i = this._count - 1; i >= 0; i--)
			{
				if (match(this._items[i]))
				{
					return this._items[i];
				}
			}
			return default(T);
		}

		// Token: 0x06003392 RID: 13202 RVA: 0x000278AC File Offset: 0x00025AAC
		public int FindLastIndex(Predicate<T> match)
		{
			return this.FindLastIndex(this._count - 1, this._count, match);
		}

		// Token: 0x06003393 RID: 13203 RVA: 0x000278C3 File Offset: 0x00025AC3
		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return this.FindLastIndex(startIndex, startIndex + 1, match);
		}

		// Token: 0x06003394 RID: 13204 RVA: 0x000B0C4C File Offset: 0x000AEE4C
		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			if (this._count == 0)
			{
				if (startIndex != -1)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
			}
			else if (startIndex >= this._count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count < 0 || startIndex - count + 1 < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			int num = startIndex - count;
			for (int i = startIndex; i > num; i--)
			{
				if (match(this._items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003395 RID: 13205 RVA: 0x000B0CCC File Offset: 0x000AEECC
		public void ForEach(Action<T> action)
		{
			if (this._count == 0)
			{
				return;
			}
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			int num = this.bdbqzgawlGauyceLbGfQfnxGLcVBA;
			int num2 = 0;
			while (num2 < this._count && num == this.bdbqzgawlGauyceLbGfQfnxGLcVBA)
			{
				action(this._items[num2]);
				num2++;
			}
			if (num != this.bdbqzgawlGauyceLbGfQfnxGLcVBA)
			{
				throw new Exception("List was changed.");
			}
		}

		// Token: 0x06003396 RID: 13206 RVA: 0x000278D0 File Offset: 0x00025AD0
		public int LastIndexOf(T item)
		{
			if (this._count == 0)
			{
				return -1;
			}
			return this.LastIndexOf(item, this._count - 1, this._count);
		}

		// Token: 0x06003397 RID: 13207 RVA: 0x000278F1 File Offset: 0x00025AF1
		public int LastIndexOf(T item, int index)
		{
			if (index < 0 || index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return this.LastIndexOf(item, index, index + 1);
		}

		// Token: 0x06003398 RID: 13208 RVA: 0x000B0D38 File Offset: 0x000AEF38
		public int LastIndexOf(T item, int index, int count)
		{
			if (this._count != 0 && index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._count != 0 && count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this._count == 0)
			{
				return -1;
			}
			if (index >= this._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count > index + 1)
			{
				throw new ArgumentOutOfRangeException();
			}
			return Array.LastIndexOf<T>(this._items, item, index, count);
		}

		// Token: 0x06003399 RID: 13209 RVA: 0x000B0DAC File Offset: 0x000AEFAC
		public int RemoveAll(Predicate<T> match)
		{
			if (this._count == 0)
			{
				return 0;
			}
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			int num = 0;
			while (num < this._count && !match(this._items[num]))
			{
				num++;
			}
			if (num >= this._count)
			{
				return 0;
			}
			int i = num + 1;
			while (i < this._count)
			{
				while (i < this._count && match(this._items[i]))
				{
					i++;
				}
				if (i < this._count)
				{
					this._items[num++] = this._items[i++];
				}
			}
			Array.Clear(this._items, num, this._count - num);
			int result = this._count - num;
			this._count = num;
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
			return result;
		}

		// Token: 0x0600339A RID: 13210 RVA: 0x000B0E8C File Offset: 0x000AF08C
		public bool TrueForAll(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			for (int i = 0; i < this._count; i++)
			{
				if (!match(this._items[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600339B RID: 13211 RVA: 0x000B0ED0 File Offset: 0x000AF0D0
		public T[] ToArray()
		{
			T[] array = new T[this._count];
			Array.Copy(this._items, 0, array, 0, this._count);
			return array;
		}

		// Token: 0x0600339C RID: 13212 RVA: 0x00027916 File Offset: 0x00025B16
		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			if (this._count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			Array.Copy(this._items, index, array, arrayIndex, count);
		}

		// Token: 0x0600339D RID: 13213 RVA: 0x0002793A File Offset: 0x00025B3A
		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(this._items, 0, array, arrayIndex, this._count);
		}

		// Token: 0x0600339E RID: 13214 RVA: 0x00027950 File Offset: 0x00025B50
		public void Clear()
		{
			Array.Clear(this._items, 0, this._count);
			this._count = 0;
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
		}

		// Token: 0x0600339F RID: 13215 RVA: 0x00027979 File Offset: 0x00025B79
		public void TrimExcess()
		{
			if (!this.urxMFaAoIllKUvRpEknskGNytNzA)
			{
				return;
			}
			if (this._count == this.kigdpseeiNfsLbmCigByEmdmWewNA)
			{
				return;
			}
			this.TpzYAdUYvRnGroPEMTRvnlevAcyU(this._count, false);
			this.bdbqzgawlGauyceLbGfQfnxGLcVBA++;
		}

		// Token: 0x060033A0 RID: 13216 RVA: 0x000B0F00 File Offset: 0x000AF100
		private int fiPidBhptvIgLmkqOtjMdaEGtdVc(int A_1, bool A_2 = false)
		{
			if (!this.urxMFaAoIllKUvRpEknskGNytNzA)
			{
				return 0;
			}
			if (this.kigdpseeiNfsLbmCigByEmdmWewNA >= this.RCHhGuDxbrKAROZkwAkeHOLDKmbi)
			{
				return 0;
			}
			if (this.RKWdaSwypbivaoYUFKXskNJUFLCg)
			{
				A_1 = this.TQBYkZdgUzClHYMkxndDPOUnTxCC(this.kigdpseeiNfsLbmCigByEmdmWewNA, A_1);
			}
			A_1 = Math.Min(A_1, this.RCHhGuDxbrKAROZkwAkeHOLDKmbi - this.kigdpseeiNfsLbmCigByEmdmWewNA);
			if (A_1 <= 0)
			{
				return 0;
			}
			if (!this.TpzYAdUYvRnGroPEMTRvnlevAcyU(this.kigdpseeiNfsLbmCigByEmdmWewNA + A_1, false))
			{
				return 0;
			}
			return A_1;
		}

		// Token: 0x060033A1 RID: 13217 RVA: 0x000B0F70 File Offset: 0x000AF170
		private int TQBYkZdgUzClHYMkxndDPOUnTxCC(int A_1, int A_2)
		{
			int num = A_1 + A_2;
			if (num < 4)
			{
				num = 4;
			}
			uint num2 = MathTools.RoundUpToPowerOf2((uint)num);
			if (num2 > 2147483647U)
			{
				num2 = 2147483647U;
			}
			return (int)(num2 - (uint)A_1);
		}

		// Token: 0x060033A2 RID: 13218 RVA: 0x000B0FA0 File Offset: 0x000AF1A0
		private bool TpzYAdUYvRnGroPEMTRvnlevAcyU(int A_1, bool A_2 = false)
		{
			if (A_1 < 0)
			{
				A_1 = 0;
			}
			if (A_1 > this.RCHhGuDxbrKAROZkwAkeHOLDKmbi)
			{
				return false;
			}
			if (A_1 == this.kigdpseeiNfsLbmCigByEmdmWewNA)
			{
				return true;
			}
			if (A_2)
			{
				return true;
			}
			int num = this.kigdpseeiNfsLbmCigByEmdmWewNA;
			T[] array = new T[A_1];
			if (A_1 != 0)
			{
				Array.Copy(this._items, array, Math.Min(A_1, this.kigdpseeiNfsLbmCigByEmdmWewNA));
			}
			this.kigdpseeiNfsLbmCigByEmdmWewNA = A_1;
			if (this._count > A_1)
			{
				this._count = A_1;
			}
			this._items = array;
			return true;
		}

		// Token: 0x060033A3 RID: 13219 RVA: 0x000279AF File Offset: 0x00025BAF
		void IList<!0>.WumFccHRTTMbdRevGKAlCQgnsfavA(int A_1, T A_2)
		{
			this.Insert(A_1, A_2);
		}

		// Token: 0x060033A4 RID: 13220 RVA: 0x000279BA File Offset: 0x00025BBA
		void ICollection<!0>.YBvDnmblHHyLzjTiOgduhOGJCvXeA(T A_1)
		{
			if (this.Add(A_1) < 0)
			{
				throw new Exception("List has no more space. Cannot add item.");
			}
		}

		// Token: 0x060033A5 RID: 13221 RVA: 0x000279D1 File Offset: 0x00025BD1
		void ICollection<!0>.RGaztETAWoPeZAwaOSUKuuKvkAIi(T[] A_1, int A_2)
		{
			if (A_1 != null && A_1.Rank != 1)
			{
				throw new ArgumentException("Multi-dimensional arrays are not supported.");
			}
			Array.Copy(this._items, 0, A_1, A_2, this._count);
		}

		// Token: 0x060033A6 RID: 13222 RVA: 0x000B1018 File Offset: 0x000AF218
		void ICollection.CopyTo(Array array, int index)
		{
			if (array != null && array.Rank != 1)
			{
				throw new ArgumentException("Multi-dimensional arrays are not supported.");
			}
			try
			{
				Array.Copy(this._items, 0, array, index, this._count);
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException("Invalid array type.");
			}
		}

		// Token: 0x17000BC7 RID: 3015
		// (get) Token: 0x060033A7 RID: 13223 RVA: 0x00003E2B File Offset: 0x0000202B
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000BC8 RID: 3016
		// (get) Token: 0x060033A8 RID: 13224 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IList.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060033A9 RID: 13225 RVA: 0x000279FE File Offset: 0x00025BFE
		IEnumerator<T> IEnumerable<!0>.FkxQZdiQduCfaybgdZEyBfKBLbHq()
		{
			return new AList<T>.dgbixqhoceXTCNLRNgkWTxbKJrSx(this);
		}

		// Token: 0x060033AA RID: 13226 RVA: 0x000279FE File Offset: 0x00025BFE
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new AList<T>.dgbixqhoceXTCNLRNgkWTxbKJrSx(this);
		}

		// Token: 0x060033AB RID: 13227 RVA: 0x00027A0B File Offset: 0x00025C0B
		int IList.Add(object value)
		{
			if (!AList<T>.CtxRHaXbfwdPPGZXTdBqailJdkNP(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return this.Add((T)((object)value));
		}

		// Token: 0x060033AC RID: 13228 RVA: 0x00027A2C File Offset: 0x00025C2C
		bool IList.Contains(object value)
		{
			if (!AList<T>.CtxRHaXbfwdPPGZXTdBqailJdkNP(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return this.Contains((T)((object)value));
		}

		// Token: 0x060033AD RID: 13229 RVA: 0x00027A4D File Offset: 0x00025C4D
		int IList.IndexOf(object value)
		{
			if (!AList<T>.CtxRHaXbfwdPPGZXTdBqailJdkNP(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return this.IndexOf((T)((object)value));
		}

		// Token: 0x060033AE RID: 13230 RVA: 0x00027A6E File Offset: 0x00025C6E
		void IList.Insert(int index, object value)
		{
			if (!AList<T>.CtxRHaXbfwdPPGZXTdBqailJdkNP(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			this.Insert(index, (T)((object)value));
		}

		// Token: 0x060033AF RID: 13231 RVA: 0x00027A91 File Offset: 0x00025C91
		void IList.Remove(object value)
		{
			if (!AList<T>.CtxRHaXbfwdPPGZXTdBqailJdkNP(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			this.Remove((T)((object)value));
		}

		// Token: 0x17000BC9 RID: 3017
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (!AList<T>.CtxRHaXbfwdPPGZXTdBqailJdkNP(value))
				{
					throw new ArgumentException("value is an incompatible type.");
				}
				this[index] = (T)((object)value);
			}
		}

		// Token: 0x17000BCA RID: 3018
		// (get) Token: 0x060033B2 RID: 13234 RVA: 0x00027743 File Offset: 0x00025943
		int ICollection.Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000BCB RID: 3019
		// (get) Token: 0x060033B3 RID: 13235 RVA: 0x00003E2B File Offset: 0x0000202B
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000BCC RID: 3020
		// (get) Token: 0x060033B4 RID: 13236 RVA: 0x00027AE3 File Offset: 0x00025CE3
		object ICollection.SyncRoot
		{
			get
			{
				if (this.FizmOAYPsHJfozOrRjRBbNoGcgwD == null)
				{
					Interlocked.CompareExchange<object>(ref this.FizmOAYPsHJfozOrRjRBbNoGcgwD, new object(), null);
				}
				return this.FizmOAYPsHJfozOrRjRBbNoGcgwD;
			}
		}

		// Token: 0x060033B5 RID: 13237 RVA: 0x00027B05 File Offset: 0x00025D05
		public static AList<T> CreateFixedLengthList(int capacity)
		{
			return new AList<T>(capacity, capacity, 0);
		}

		// Token: 0x060033B6 RID: 13238 RVA: 0x000B1070 File Offset: 0x000AF270
		private static bool CtxRHaXbfwdPPGZXTdBqailJdkNP(object A_0)
		{
			return A_0 is T || (A_0 == null && default(T) == null);
		}

		// Token: 0x04001BBB RID: 7099
		private const int QgSApSBoTUiSRDkXiTJUYWTohbKtA = 4;

		// Token: 0x04001BBC RID: 7100
		private static readonly T[] TrOOHiiijzapRdkXlIGhDXKYbEhDA = new T[0];

		// Token: 0x04001BBD RID: 7101
		private IEqualityComparer<T> wRiPqbOKYWeBexNiZcPbJHUyZrph;

		// Token: 0x04001BBE RID: 7102
		public T[] _items;

		// Token: 0x04001BBF RID: 7103
		private int kigdpseeiNfsLbmCigByEmdmWewNA;

		// Token: 0x04001BC0 RID: 7104
		public int _count;

		// Token: 0x04001BC1 RID: 7105
		private int xYGjcaeqBotfeRmnrYvpiCxybSYs;

		// Token: 0x04001BC2 RID: 7106
		private bool RKWdaSwypbivaoYUFKXskNJUFLCg;

		// Token: 0x04001BC3 RID: 7107
		private readonly int RCHhGuDxbrKAROZkwAkeHOLDKmbi;

		// Token: 0x04001BC4 RID: 7108
		private readonly bool urxMFaAoIllKUvRpEknskGNytNzA;

		// Token: 0x04001BC5 RID: 7109
		private int bdbqzgawlGauyceLbGfQfnxGLcVBA;

		// Token: 0x04001BC6 RID: 7110
		[NonSerialized]
		private object FizmOAYPsHJfozOrRjRBbNoGcgwD;

		// Token: 0x020004F4 RID: 1268
		[Serializable]
		public struct dgbixqhoceXTCNLRNgkWTxbKJrSx : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x060033B8 RID: 13240 RVA: 0x00027B1C File Offset: 0x00025D1C
			internal dgbixqhoceXTCNLRNgkWTxbKJrSx(AList<\u0001> A_1)
			{
				this.list = A_1;
				this.index = 0;
				this.version = A_1.bdbqzgawlGauyceLbGfQfnxGLcVBA;
				this.current = default(\u0001);
			}

			// Token: 0x060033B9 RID: 13241 RVA: 0x00002FF9 File Offset: 0x000011F9
			public void Dispose()
			{
			}

			// Token: 0x060033BA RID: 13242 RVA: 0x000B10A0 File Offset: 0x000AF2A0
			public bool MoveNext()
			{
				AList<\u0001> alist = this.list;
				if (this.version == alist.bdbqzgawlGauyceLbGfQfnxGLcVBA && this.index < alist._count)
				{
					this.current = alist._items[this.index];
					this.index++;
					return true;
				}
				return this.SMqbnhubDKGsTHWVgcbHpcGgmIxc();
			}

			// Token: 0x060033BB RID: 13243 RVA: 0x00027B44 File Offset: 0x00025D44
			private bool SMqbnhubDKGsTHWVgcbHpcGgmIxc()
			{
				if (this.version != this.list.bdbqzgawlGauyceLbGfQfnxGLcVBA)
				{
					throw new InvalidOperationException("List was changed.");
				}
				this.index = this.list._count + 1;
				this.current = default(\u0001);
				return false;
			}

			// Token: 0x17000BCD RID: 3021
			// (get) Token: 0x060033BC RID: 13244 RVA: 0x00027B84 File Offset: 0x00025D84
			public \u0001 Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000BCE RID: 3022
			// (get) Token: 0x060033BD RID: 13245 RVA: 0x00027B8C File Offset: 0x00025D8C
			object IEnumerator.Current
			{
				get
				{
					if (this.index == 0 || this.index == this.list._count + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			// Token: 0x060033BE RID: 13246 RVA: 0x00027BBC File Offset: 0x00025DBC
			void IEnumerator.Reset()
			{
				if (this.version != this.list.bdbqzgawlGauyceLbGfQfnxGLcVBA)
				{
					throw new InvalidOperationException("List was changed.");
				}
				this.index = 0;
				this.current = default(\u0001);
			}

			// Token: 0x04001BC7 RID: 7111
			private AList<\u0001> list;

			// Token: 0x04001BC8 RID: 7112
			private int index;

			// Token: 0x04001BC9 RID: 7113
			private int version;

			// Token: 0x04001BCA RID: 7114
			private \u0001 current;
		}
	}
}
