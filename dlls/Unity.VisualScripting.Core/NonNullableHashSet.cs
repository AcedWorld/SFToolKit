using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000023 RID: 35
	public class NonNullableHashSet<T> : ISet<T>, ICollection<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00003D08 File Offset: 0x00001F08
		public NonNullableHashSet()
		{
			this.set = new HashSet<T>();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00003D1B File Offset: 0x00001F1B
		public NonNullableHashSet(IEqualityComparer<T> comparer)
		{
			this.set = new HashSet<T>(comparer);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00003D2F File Offset: 0x00001F2F
		public NonNullableHashSet(IEnumerable<T> collection)
		{
			this.set = new HashSet<T>(collection);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00003D43 File Offset: 0x00001F43
		public NonNullableHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
		{
			this.set = new HashSet<T>(collection, comparer);
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00003D58 File Offset: 0x00001F58
		public int Count
		{
			get
			{
				return this.set.Count;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00003D65 File Offset: 0x00001F65
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00003D68 File Offset: 0x00001F68
		public bool Add(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.set.Add(item);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00003D89 File Offset: 0x00001F89
		public void Clear()
		{
			this.set.Clear();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00003D96 File Offset: 0x00001F96
		public bool Contains(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.set.Contains(item);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00003DB7 File Offset: 0x00001FB7
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.set.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00003DC6 File Offset: 0x00001FC6
		public void ExceptWith(IEnumerable<T> other)
		{
			this.set.ExceptWith(other);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00003DD4 File Offset: 0x00001FD4
		public IEnumerator<T> GetEnumerator()
		{
			return this.set.GetEnumerator();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00003DE6 File Offset: 0x00001FE6
		public void IntersectWith(IEnumerable<T> other)
		{
			this.set.IntersectWith(other);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00003DF4 File Offset: 0x00001FF4
		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			return this.set.IsProperSubsetOf(other);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00003E02 File Offset: 0x00002002
		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			return this.set.IsProperSupersetOf(other);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00003E10 File Offset: 0x00002010
		public bool IsSubsetOf(IEnumerable<T> other)
		{
			return this.set.IsSubsetOf(other);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00003E1E File Offset: 0x0000201E
		public bool IsSupersetOf(IEnumerable<T> other)
		{
			return this.set.IsSupersetOf(other);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00003E2C File Offset: 0x0000202C
		public bool Overlaps(IEnumerable<T> other)
		{
			return this.set.Overlaps(other);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00003E3A File Offset: 0x0000203A
		public bool Remove(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.set.Remove(item);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00003E5B File Offset: 0x0000205B
		public bool SetEquals(IEnumerable<T> other)
		{
			return this.set.SetEquals(other);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00003E69 File Offset: 0x00002069
		public void SymmetricExceptWith(IEnumerable<T> other)
		{
			this.set.SymmetricExceptWith(other);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00003E77 File Offset: 0x00002077
		public void UnionWith(IEnumerable<T> other)
		{
			this.set.UnionWith(other);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00003E85 File Offset: 0x00002085
		void ICollection<!0>.Add(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			((ICollection<!0>)this.set).Add(item);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00003EA6 File Offset: 0x000020A6
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.set).GetEnumerator();
		}

		// Token: 0x0400001F RID: 31
		private readonly HashSet<T> set;
	}
}
