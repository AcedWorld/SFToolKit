using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000027 RID: 39
	public class VariantList<TBase, TImplementation> : IList<TBase>, ICollection<TBase>, IEnumerable<TBase>, IEnumerable where TImplementation : TBase
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00004310 File Offset: 0x00002510
		public VariantList(IList<TImplementation> implementation)
		{
			if (implementation == null)
			{
				throw new ArgumentNullException("implementation");
			}
			this.implementation = implementation;
		}

		// Token: 0x17000044 RID: 68
		public TBase this[int index]
		{
			get
			{
				return (TBase)((object)this.implementation[index]);
			}
			set
			{
				if (!(value is TImplementation))
				{
					throw new NotSupportedException();
				}
				this.implementation[index] = (TImplementation)((object)value);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00004371 File Offset: 0x00002571
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00004379 File Offset: 0x00002579
		public IList<TImplementation> implementation { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00004382 File Offset: 0x00002582
		public int Count
		{
			get
			{
				return this.implementation.Count;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000165 RID: 357 RVA: 0x0000438F File Offset: 0x0000258F
		public bool IsReadOnly
		{
			get
			{
				return this.implementation.IsReadOnly;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000439C File Offset: 0x0000259C
		public void Add(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			this.implementation.Add((TImplementation)((object)item));
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000043C7 File Offset: 0x000025C7
		public void Clear()
		{
			this.implementation.Clear();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000043D4 File Offset: 0x000025D4
		public bool Contains(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			return this.implementation.Contains((TImplementation)((object)item));
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000043FF File Offset: 0x000025FF
		public bool Remove(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			return this.implementation.Remove((TImplementation)((object)item));
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000442C File Offset: 0x0000262C
		public void CopyTo(TBase[] array, int arrayIndex)
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
			TImplementation[] array2 = new TImplementation[this.Count];
			this.implementation.CopyTo(array2, 0);
			for (int i = 0; i < this.Count; i++)
			{
				array[i + arrayIndex] = (TBase)((object)array2[i]);
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000044AD File Offset: 0x000026AD
		public int IndexOf(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			return this.implementation.IndexOf((TImplementation)((object)item));
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000044D8 File Offset: 0x000026D8
		public void Insert(int index, TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			this.implementation.Insert(index, (TImplementation)((object)item));
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00004504 File Offset: 0x00002704
		public void RemoveAt(int index)
		{
			this.implementation.RemoveAt(index);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00004512 File Offset: 0x00002712
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000451F File Offset: 0x0000271F
		IEnumerator<TBase> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000452C File Offset: 0x0000272C
		public NoAllocEnumerator<TBase> GetEnumerator()
		{
			return new NoAllocEnumerator<TBase>(this);
		}
	}
}
