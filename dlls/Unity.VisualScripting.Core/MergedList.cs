using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200001F RID: 31
	public class MergedList<T> : IMergedCollection<T>, ICollection<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x000036DF File Offset: 0x000018DF
		public MergedList()
		{
			this.lists = new Dictionary<Type, IList<T>>();
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x000036F4 File Offset: 0x000018F4
		public int Count
		{
			get
			{
				int num = 0;
				foreach (KeyValuePair<Type, IList<T>> keyValuePair in this.lists)
				{
					num += keyValuePair.Value.Count;
				}
				return num;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00003754 File Offset: 0x00001954
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003757 File Offset: 0x00001957
		public virtual void Include<TI>(IList<TI> list) where TI : T
		{
			this.lists.Add(typeof(TI), new VariantList<T, TI>(list));
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003774 File Offset: 0x00001974
		public bool Includes<TI>() where TI : T
		{
			return this.Includes(typeof(TI));
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003786 File Offset: 0x00001986
		public bool Includes(Type elementType)
		{
			return this.GetListForType(elementType, false) != null;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003793 File Offset: 0x00001993
		public IList<TI> ForType<TI>() where TI : T
		{
			return ((VariantList<T, TI>)this.GetListForType(typeof(TI), true)).implementation;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000037B0 File Offset: 0x000019B0
		protected IList<T> GetListForItem(T item)
		{
			Ensure.That("item").IsNotNull<T>(item);
			return this.GetListForType(item.GetType(), true);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000037D8 File Offset: 0x000019D8
		protected IList<T> GetListForType(Type type, bool throwOnFail = true)
		{
			if (this.lists.ContainsKey(type))
			{
				return this.lists[type];
			}
			foreach (KeyValuePair<Type, IList<T>> keyValuePair in this.lists)
			{
				if (keyValuePair.Key.IsAssignableFrom(type))
				{
					return keyValuePair.Value;
				}
			}
			if (throwOnFail)
			{
				throw new InvalidOperationException(string.Format("No sub-collection available for type '{0}'.", type));
			}
			return null;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003870 File Offset: 0x00001A70
		public bool Contains(T item)
		{
			return this.GetListForItem(item).Contains(item);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000387F File Offset: 0x00001A7F
		public virtual void Add(T item)
		{
			this.GetListForItem(item).Add(item);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003890 File Offset: 0x00001A90
		public virtual void Clear()
		{
			foreach (KeyValuePair<Type, IList<T>> keyValuePair in this.lists)
			{
				keyValuePair.Value.Clear();
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000038E8 File Offset: 0x00001AE8
		public virtual bool Remove(T item)
		{
			return this.GetListForItem(item).Remove(item);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000038F8 File Offset: 0x00001AF8
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (array.Length - arrayIndex < this.Count)
			{
				throw new ArgumentException();
			}
			int num = 0;
			foreach (KeyValuePair<Type, IList<T>> keyValuePair in this.lists)
			{
				IList<T> value = keyValuePair.Value;
				value.CopyTo(array, arrayIndex + num);
				num += value.Count;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003994 File Offset: 0x00001B94
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000039A1 File Offset: 0x00001BA1
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000039AE File Offset: 0x00001BAE
		public MergedList<T>.Enumerator GetEnumerator()
		{
			return new MergedList<T>.Enumerator(this);
		}

		// Token: 0x04000019 RID: 25
		protected readonly Dictionary<Type, IList<T>> lists;

		// Token: 0x020001BD RID: 445
		public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x06000BCC RID: 3020 RVA: 0x00031DFC File Offset: 0x0002FFFC
			public Enumerator(MergedList<T> merged)
			{
				this = default(MergedList<T>.Enumerator);
				this.listsEnumerator = merged.lists.GetEnumerator();
			}

			// Token: 0x06000BCD RID: 3021 RVA: 0x00031E16 File Offset: 0x00030016
			public void Dispose()
			{
			}

			// Token: 0x06000BCE RID: 3022 RVA: 0x00031E18 File Offset: 0x00030018
			public bool MoveNext()
			{
				if (this.currentList == null)
				{
					if (!this.listsEnumerator.MoveNext())
					{
						this.currentItem = default(T);
						this.exceeded = true;
						return false;
					}
					KeyValuePair<Type, IList<T>> keyValuePair = this.listsEnumerator.Current;
					this.currentList = keyValuePair.Value;
					if (this.currentList == null)
					{
						throw new InvalidOperationException("Merged sub list is null.");
					}
				}
				if (this.indexInCurrentList < this.currentList.Count)
				{
					this.currentItem = this.currentList[this.indexInCurrentList];
					this.indexInCurrentList++;
					return true;
				}
				while (this.listsEnumerator.MoveNext())
				{
					KeyValuePair<Type, IList<T>> keyValuePair = this.listsEnumerator.Current;
					this.currentList = keyValuePair.Value;
					this.indexInCurrentList = 0;
					if (this.currentList == null)
					{
						throw new InvalidOperationException("Merged sub list is null.");
					}
					if (this.indexInCurrentList < this.currentList.Count)
					{
						this.currentItem = this.currentList[this.indexInCurrentList];
						this.indexInCurrentList++;
						return true;
					}
				}
				this.currentItem = default(T);
				this.exceeded = true;
				return false;
			}

			// Token: 0x17000202 RID: 514
			// (get) Token: 0x06000BCF RID: 3023 RVA: 0x00031F46 File Offset: 0x00030146
			public T Current
			{
				get
				{
					return this.currentItem;
				}
			}

			// Token: 0x17000203 RID: 515
			// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00031F4E File Offset: 0x0003014E
			object IEnumerator.Current
			{
				get
				{
					if (this.exceeded)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			// Token: 0x06000BD1 RID: 3025 RVA: 0x00031F69 File Offset: 0x00030169
			void IEnumerator.Reset()
			{
				throw new InvalidOperationException();
			}

			// Token: 0x040002EE RID: 750
			private Dictionary<Type, IList<T>>.Enumerator listsEnumerator;

			// Token: 0x040002EF RID: 751
			private T currentItem;

			// Token: 0x040002F0 RID: 752
			private IList<T> currentList;

			// Token: 0x040002F1 RID: 753
			private int indexInCurrentList;

			// Token: 0x040002F2 RID: 754
			private bool exceeded;
		}
	}
}
