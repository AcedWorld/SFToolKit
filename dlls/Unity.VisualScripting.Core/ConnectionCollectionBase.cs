using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200002A RID: 42
	public class ConnectionCollectionBase<TConnection, TSource, TDestination, TCollection> : IConnectionCollection<TConnection, TSource, TDestination>, ICollection<TConnection>, IEnumerable<!0>, IEnumerable where TConnection : IConnection<TSource, TDestination> where TCollection : ICollection<TConnection>
	{
		// Token: 0x0600017C RID: 380 RVA: 0x00004720 File Offset: 0x00002920
		public ConnectionCollectionBase(TCollection collection)
		{
			this.collection = collection;
			this.bySource = new Dictionary<TSource, List<TConnection>>();
			this.byDestination = new Dictionary<TDestination, List<TConnection>>();
		}

		// Token: 0x17000048 RID: 72
		public IEnumerable<TConnection> this[TSource source]
		{
			get
			{
				return this.WithSource(source);
			}
		}

		// Token: 0x17000049 RID: 73
		public IEnumerable<TConnection> this[TDestination destination]
		{
			get
			{
				return this.WithDestination(destination);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00004758 File Offset: 0x00002958
		public int Count
		{
			get
			{
				TCollection tcollection = this.collection;
				return tcollection.Count;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00004779 File Offset: 0x00002979
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000477C File Offset: 0x0000297C
		public IEnumerator<TConnection> GetEnumerator()
		{
			TCollection tcollection = this.collection;
			return tcollection.GetEnumerator();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000479D File Offset: 0x0000299D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000047A5 File Offset: 0x000029A5
		public IEnumerable<TConnection> WithSource(TSource source)
		{
			return this.WithSourceNoAlloc(source);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000047B0 File Offset: 0x000029B0
		public List<TConnection> WithSourceNoAlloc(TSource source)
		{
			Ensure.That("source").IsNotNull<TSource>(source);
			List<TConnection> result;
			if (this.bySource.TryGetValue(source, out result))
			{
				return result;
			}
			return Empty<TConnection>.list;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000047E4 File Offset: 0x000029E4
		public TConnection SingleOrDefaultWithSource(TSource source)
		{
			Ensure.That("source").IsNotNull<TSource>(source);
			List<TConnection> list;
			if (!this.bySource.TryGetValue(source, out list))
			{
				return default(TConnection);
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			if (list.Count == 0)
			{
				return default(TConnection);
			}
			throw new InvalidOperationException();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00004843 File Offset: 0x00002A43
		public IEnumerable<TConnection> WithDestination(TDestination destination)
		{
			return this.WithDestinationNoAlloc(destination);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000484C File Offset: 0x00002A4C
		public List<TConnection> WithDestinationNoAlloc(TDestination destination)
		{
			Ensure.That("destination").IsNotNull<TDestination>(destination);
			List<TConnection> result;
			if (this.byDestination.TryGetValue(destination, out result))
			{
				return result;
			}
			return Empty<TConnection>.list;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00004880 File Offset: 0x00002A80
		public TConnection SingleOrDefaultWithDestination(TDestination destination)
		{
			Ensure.That("destination").IsNotNull<TDestination>(destination);
			List<TConnection> list;
			if (!this.byDestination.TryGetValue(destination, out list))
			{
				return default(TConnection);
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			if (list.Count == 0)
			{
				return default(TConnection);
			}
			throw new InvalidOperationException();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000048E0 File Offset: 0x00002AE0
		public void Add(TConnection item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (item.source == null)
			{
				throw new ArgumentNullException("item.source");
			}
			if (item.destination == null)
			{
				throw new ArgumentNullException("item.destination");
			}
			this.BeforeAdd(item);
			TCollection tcollection = this.collection;
			tcollection.Add(item);
			this.AddToDictionaries(item);
			this.AfterAdd(item);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00004968 File Offset: 0x00002B68
		public void Clear()
		{
			TCollection tcollection = this.collection;
			tcollection.Clear();
			this.bySource.Clear();
			this.byDestination.Clear();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000049A0 File Offset: 0x00002BA0
		public bool Contains(TConnection item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			TCollection tcollection = this.collection;
			return tcollection.Contains(item);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000049D8 File Offset: 0x00002BD8
		public void CopyTo(TConnection[] array, int arrayIndex)
		{
			TCollection tcollection = this.collection;
			tcollection.CopyTo(array, arrayIndex);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000049FC File Offset: 0x00002BFC
		public bool Remove(TConnection item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (item.source == null)
			{
				throw new ArgumentNullException("item.source");
			}
			if (item.destination == null)
			{
				throw new ArgumentNullException("item.destination");
			}
			TCollection tcollection = this.collection;
			if (!tcollection.Contains(item))
			{
				return false;
			}
			this.BeforeRemove(item);
			tcollection = this.collection;
			tcollection.Remove(item);
			this.RemoveFromDictionaries(item);
			this.AfterRemove(item);
			return true;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00004A9F File Offset: 0x00002C9F
		protected virtual void BeforeAdd(TConnection item)
		{
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00004AA1 File Offset: 0x00002CA1
		protected virtual void AfterAdd(TConnection item)
		{
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00004AA3 File Offset: 0x00002CA3
		protected virtual void BeforeRemove(TConnection item)
		{
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00004AA5 File Offset: 0x00002CA5
		protected virtual void AfterRemove(TConnection item)
		{
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00004AA8 File Offset: 0x00002CA8
		private void AddToDictionaries(TConnection item)
		{
			if (!this.bySource.ContainsKey(item.source))
			{
				this.bySource.Add(item.source, new List<TConnection>());
			}
			this.bySource[item.source].Add(item);
			if (!this.byDestination.ContainsKey(item.destination))
			{
				this.byDestination.Add(item.destination, new List<TConnection>());
			}
			this.byDestination[item.destination].Add(item);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00004B5F File Offset: 0x00002D5F
		private void RemoveFromDictionaries(TConnection item)
		{
			this.bySource[item.source].Remove(item);
			this.byDestination[item.destination].Remove(item);
		}

		// Token: 0x04000027 RID: 39
		private readonly Dictionary<TDestination, List<TConnection>> byDestination;

		// Token: 0x04000028 RID: 40
		private readonly Dictionary<TSource, List<TConnection>> bySource;

		// Token: 0x04000029 RID: 41
		protected readonly TCollection collection;
	}
}
