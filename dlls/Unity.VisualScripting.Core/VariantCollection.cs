using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000025 RID: 37
	public class VariantCollection<TBase, TImplementation> : ICollection<!0>, IEnumerable<!0>, IEnumerable where TImplementation : TBase
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00004104 File Offset: 0x00002304
		public VariantCollection(ICollection<TImplementation> implementation)
		{
			if (implementation == null)
			{
				throw new ArgumentNullException("implementation");
			}
			this.implementation = implementation;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00004121 File Offset: 0x00002321
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00004129 File Offset: 0x00002329
		public ICollection<TImplementation> implementation { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00004132 File Offset: 0x00002332
		public int Count
		{
			get
			{
				return this.implementation.Count;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600014F RID: 335 RVA: 0x0000413F File Offset: 0x0000233F
		public bool IsReadOnly
		{
			get
			{
				return this.implementation.IsReadOnly;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000414C File Offset: 0x0000234C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004154 File Offset: 0x00002354
		public IEnumerator<TBase> GetEnumerator()
		{
			foreach (TImplementation timplementation in this.implementation)
			{
				yield return (TBase)((object)timplementation);
			}
			IEnumerator<TImplementation> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004163 File Offset: 0x00002363
		public void Add(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			this.implementation.Add((TImplementation)((object)item));
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000418E File Offset: 0x0000238E
		public void Clear()
		{
			this.implementation.Clear();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000419B File Offset: 0x0000239B
		public bool Contains(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			return this.implementation.Contains((TImplementation)((object)item));
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000041C6 File Offset: 0x000023C6
		public bool Remove(TBase item)
		{
			if (!(item is TImplementation))
			{
				throw new NotSupportedException();
			}
			return this.implementation.Remove((TImplementation)((object)item));
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000041F4 File Offset: 0x000023F4
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
	}
}
