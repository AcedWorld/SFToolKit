using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200002B RID: 43
	public class GraphConnectionCollection<TConnection, TSource, TDestination> : ConnectionCollectionBase<TConnection, TSource, TDestination, GraphElementCollection<TConnection>>, IGraphElementCollection<TConnection>, IKeyedCollection<Guid, TConnection>, ICollection<TConnection>, IEnumerable<!0>, IEnumerable, INotifyCollectionChanged<TConnection> where TConnection : IConnection<TSource, TDestination>, IGraphElement
	{
		// Token: 0x06000194 RID: 404 RVA: 0x00004B9F File Offset: 0x00002D9F
		public GraphConnectionCollection(IGraph graph) : base(new GraphElementCollection<TConnection>(graph))
		{
			this.collection.ProxyCollectionChange = true;
		}

		// Token: 0x1700004C RID: 76
		TConnection IKeyedCollection<Guid, !0>.this[Guid key]
		{
			get
			{
				return this.collection[key];
			}
		}

		// Token: 0x1700004D RID: 77
		TConnection IKeyedCollection<Guid, !0>.this[int index]
		{
			get
			{
				return this.collection[index];
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00004BD5 File Offset: 0x00002DD5
		public bool TryGetValue(Guid key, out TConnection value)
		{
			return this.collection.TryGetValue(key, out value);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00004BE4 File Offset: 0x00002DE4
		public bool Contains(Guid key)
		{
			return this.collection.Contains(key);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00004BF2 File Offset: 0x00002DF2
		public bool Remove(Guid key)
		{
			return this.Contains(key) && base.Remove(this.collection[key]);
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600019A RID: 410 RVA: 0x00004C11 File Offset: 0x00002E11
		// (remove) Token: 0x0600019B RID: 411 RVA: 0x00004C1F File Offset: 0x00002E1F
		public event Action<TConnection> ItemAdded
		{
			add
			{
				this.collection.ItemAdded += value;
			}
			remove
			{
				this.collection.ItemAdded -= value;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600019C RID: 412 RVA: 0x00004C2D File Offset: 0x00002E2D
		// (remove) Token: 0x0600019D RID: 413 RVA: 0x00004C3B File Offset: 0x00002E3B
		public event Action<TConnection> ItemRemoved
		{
			add
			{
				this.collection.ItemRemoved += value;
			}
			remove
			{
				this.collection.ItemRemoved -= value;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600019E RID: 414 RVA: 0x00004C49 File Offset: 0x00002E49
		// (remove) Token: 0x0600019F RID: 415 RVA: 0x00004C57 File Offset: 0x00002E57
		public event Action CollectionChanged
		{
			add
			{
				this.collection.CollectionChanged += value;
			}
			remove
			{
				this.collection.CollectionChanged -= value;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00004C65 File Offset: 0x00002E65
		protected override void BeforeAdd(TConnection item)
		{
			this.collection.BeforeAdd(item);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00004C73 File Offset: 0x00002E73
		protected override void AfterAdd(TConnection item)
		{
			this.collection.AfterAdd(item);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00004C81 File Offset: 0x00002E81
		protected override void BeforeRemove(TConnection item)
		{
			this.collection.BeforeRemove(item);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00004C8F File Offset: 0x00002E8F
		protected override void AfterRemove(TConnection item)
		{
			this.collection.AfterRemove(item);
		}
	}
}
