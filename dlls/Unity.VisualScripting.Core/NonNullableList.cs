using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000024 RID: 36
	public class NonNullableList<T> : IList<T>, ICollection<!0>, IEnumerable<!0>, IEnumerable, IList, ICollection
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00003EB3 File Offset: 0x000020B3
		public NonNullableList()
		{
			this.list = new List<T>();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00003EC6 File Offset: 0x000020C6
		public NonNullableList(int capacity)
		{
			this.list = new List<T>(capacity);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00003EDA File Offset: 0x000020DA
		public NonNullableList(IEnumerable<T> collection)
		{
			this.list = new List<T>(collection);
		}

		// Token: 0x17000037 RID: 55
		public T this[int index]
		{
			get
			{
				return this.list[index];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.list[index] = value;
			}
		}

		// Token: 0x17000038 RID: 56
		object IList.this[int index]
		{
			get
			{
				return ((IList)this.list)[index];
			}
			set
			{
				((IList)this.list)[index] = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00003F3B File Offset: 0x0000213B
		public int Count
		{
			get
			{
				return this.list.Count;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00003F48 File Offset: 0x00002148
		public bool IsSynchronized
		{
			get
			{
				return ((ICollection)this.list).IsSynchronized;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00003F55 File Offset: 0x00002155
		public object SyncRoot
		{
			get
			{
				return ((ICollection)this.list).SyncRoot;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00003F62 File Offset: 0x00002162
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00003F65 File Offset: 0x00002165
		public bool IsFixedSize
		{
			get
			{
				return ((IList)this.list).IsFixedSize;
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00003F72 File Offset: 0x00002172
		public void CopyTo(Array array, int index)
		{
			((ICollection)this.list).CopyTo(array, index);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00003F81 File Offset: 0x00002181
		public void Add(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.list.Add(item);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00003FA2 File Offset: 0x000021A2
		public int Add(object value)
		{
			return ((IList)this.list).Add(value);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00003FB0 File Offset: 0x000021B0
		public void Clear()
		{
			this.list.Clear();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00003FBD File Offset: 0x000021BD
		public bool Contains(object value)
		{
			return ((IList)this.list).Contains(value);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00003FCB File Offset: 0x000021CB
		public int IndexOf(object value)
		{
			return ((IList)this.list).IndexOf(value);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00003FD9 File Offset: 0x000021D9
		public void Insert(int index, object value)
		{
			((IList)this.list).Insert(index, value);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00003FE8 File Offset: 0x000021E8
		public void Remove(object value)
		{
			((IList)this.list).Remove(value);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00003FF6 File Offset: 0x000021F6
		public bool Contains(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.list.Contains(item);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004017 File Offset: 0x00002217
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.list.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004026 File Offset: 0x00002226
		public IEnumerator<T> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004038 File Offset: 0x00002238
		public int IndexOf(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.list.IndexOf(item);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00004059 File Offset: 0x00002259
		public void Insert(int index, T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.list.Insert(index, item);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000407B File Offset: 0x0000227B
		public bool Remove(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.list.Remove(item);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000409C File Offset: 0x0000229C
		public void RemoveAt(int index)
		{
			this.list.RemoveAt(index);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000040AA File Offset: 0x000022AA
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000040BC File Offset: 0x000022BC
		public void AddRange(IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				this.Add(item);
			}
		}

		// Token: 0x04000020 RID: 32
		private readonly List<T> list;
	}
}
