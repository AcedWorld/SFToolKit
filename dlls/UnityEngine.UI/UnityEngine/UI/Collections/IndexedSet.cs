using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.UI.Collections
{
	// Token: 0x02000046 RID: 70
	internal class IndexedSet<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x00016E89 File Offset: 0x00015089
		public void Add(T item)
		{
			this.Add(item, true);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00016E93 File Offset: 0x00015093
		public void Add(T item, bool isActive)
		{
			this.m_List.Add(item);
			this.m_Dictionary.Add(item, this.m_List.Count - 1);
			if (isActive)
			{
				this.EnableItem(item);
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00016EC5 File Offset: 0x000150C5
		public bool AddUnique(T item, bool isActive = true)
		{
			if (this.m_Dictionary.ContainsKey(item))
			{
				if (isActive)
				{
					this.EnableItem(item);
				}
				else
				{
					this.DisableItem(item);
				}
				return false;
			}
			this.Add(item, isActive);
			return true;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00016EF8 File Offset: 0x000150F8
		public bool EnableItem(T item)
		{
			int num;
			if (!this.m_Dictionary.TryGetValue(item, out num))
			{
				return false;
			}
			if (num < this.m_EnabledObjectCount)
			{
				return true;
			}
			if (num > this.m_EnabledObjectCount)
			{
				this.Swap(this.m_EnabledObjectCount, num);
			}
			this.m_EnabledObjectCount++;
			return true;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00016F48 File Offset: 0x00015148
		public bool DisableItem(T item)
		{
			int num;
			if (!this.m_Dictionary.TryGetValue(item, out num))
			{
				return false;
			}
			if (num >= this.m_EnabledObjectCount)
			{
				return true;
			}
			if (num < this.m_EnabledObjectCount - 1)
			{
				this.Swap(num, this.m_EnabledObjectCount - 1);
			}
			this.m_EnabledObjectCount--;
			return true;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00016F9C File Offset: 0x0001519C
		public bool Remove(T item)
		{
			int index = -1;
			if (!this.m_Dictionary.TryGetValue(item, out index))
			{
				return false;
			}
			this.RemoveAt(index);
			return true;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00016FC5 File Offset: 0x000151C5
		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00016FCC File Offset: 0x000151CC
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00016FD4 File Offset: 0x000151D4
		public void Clear()
		{
			this.m_List.Clear();
			this.m_Dictionary.Clear();
			this.m_EnabledObjectCount = 0;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00016FF3 File Offset: 0x000151F3
		public bool Contains(T item)
		{
			return this.m_Dictionary.ContainsKey(item);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00017001 File Offset: 0x00015201
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.m_List.CopyTo(array, arrayIndex);
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00017010 File Offset: 0x00015210
		public int Count
		{
			get
			{
				return this.m_EnabledObjectCount;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00017018 File Offset: 0x00015218
		public int Capacity
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00017025 File Offset: 0x00015225
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00017028 File Offset: 0x00015228
		public int IndexOf(T item)
		{
			int result = -1;
			if (this.m_Dictionary.TryGetValue(item, out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0001704A File Offset: 0x0001524A
		public void Insert(int index, T item)
		{
			throw new NotSupportedException("Random Insertion is semantically invalid, since this structure does not guarantee ordering.");
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00017058 File Offset: 0x00015258
		public void RemoveAt(int index)
		{
			T key = this.m_List[index];
			if (index == this.m_List.Count - 1)
			{
				if (this.m_EnabledObjectCount == this.m_List.Count)
				{
					this.m_EnabledObjectCount--;
				}
				this.m_List.RemoveAt(index);
			}
			else
			{
				int num = this.m_List.Count - 1;
				if (index < this.m_EnabledObjectCount - 1)
				{
					int num2 = this.m_EnabledObjectCount - 1;
					this.m_EnabledObjectCount = num2;
					this.Swap(num2, index);
					index = this.m_EnabledObjectCount;
				}
				else if (index == this.m_EnabledObjectCount - 1)
				{
					this.m_EnabledObjectCount--;
				}
				this.Swap(num, index);
				this.m_List.RemoveAt(num);
			}
			this.m_Dictionary.Remove(key);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00017128 File Offset: 0x00015328
		private void Swap(int index1, int index2)
		{
			if (index1 == index2)
			{
				return;
			}
			T t = this.m_List[index1];
			T t2 = this.m_List[index2];
			this.m_List[index1] = t2;
			this.m_List[index2] = t;
			this.m_Dictionary[t2] = index1;
			this.m_Dictionary[t] = index2;
		}

		// Token: 0x17000148 RID: 328
		public T this[int index]
		{
			get
			{
				if (index >= this.m_EnabledObjectCount)
				{
					throw new IndexOutOfRangeException();
				}
				return this.m_List[index];
			}
			set
			{
				T key = this.m_List[index];
				this.m_Dictionary.Remove(key);
				this.m_List[index] = value;
				this.m_Dictionary.Add(value, index);
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000171EC File Offset: 0x000153EC
		public void RemoveAll(Predicate<T> match)
		{
			int i = 0;
			while (i < this.m_List.Count)
			{
				T t = this.m_List[i];
				if (match(t))
				{
					this.Remove(t);
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00017230 File Offset: 0x00015430
		public void Sort(Comparison<T> sortLayoutFunction)
		{
			this.m_List.Sort(sortLayoutFunction);
			for (int i = 0; i < this.m_List.Count; i++)
			{
				T key = this.m_List[i];
				this.m_Dictionary[key] = i;
			}
		}

		// Token: 0x04000195 RID: 405
		private readonly List<T> m_List = new List<T>();

		// Token: 0x04000196 RID: 406
		private Dictionary<T, int> m_Dictionary = new Dictionary<T, int>();

		// Token: 0x04000197 RID: 407
		private int m_EnabledObjectCount;
	}
}
