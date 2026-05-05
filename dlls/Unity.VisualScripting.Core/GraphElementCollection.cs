using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000062 RID: 98
	public sealed class GraphElementCollection<TElement> : GuidCollection<TElement>, IGraphElementCollection<TElement>, IKeyedCollection<Guid, !0>, ICollection<TElement>, IEnumerable<!0>, IEnumerable, INotifyCollectionChanged<TElement>, IProxyableNotifyCollectionChanged<TElement> where TElement : IGraphElement
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x000070A1 File Offset: 0x000052A1
		public GraphElementCollection(IGraph graph)
		{
			Ensure.That("graph").IsNotNull<IGraph>(graph);
			this.graph = graph;
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x000070C0 File Offset: 0x000052C0
		public IGraph graph { get; }

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060002D9 RID: 729 RVA: 0x000070C8 File Offset: 0x000052C8
		// (remove) Token: 0x060002DA RID: 730 RVA: 0x00007100 File Offset: 0x00005300
		public event Action<TElement> ItemAdded;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060002DB RID: 731 RVA: 0x00007138 File Offset: 0x00005338
		// (remove) Token: 0x060002DC RID: 732 RVA: 0x00007170 File Offset: 0x00005370
		public event Action<TElement> ItemRemoved;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060002DD RID: 733 RVA: 0x000071A8 File Offset: 0x000053A8
		// (remove) Token: 0x060002DE RID: 734 RVA: 0x000071E0 File Offset: 0x000053E0
		public event Action CollectionChanged;

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00007215 File Offset: 0x00005415
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000721D File Offset: 0x0000541D
		public bool ProxyCollectionChange { get; set; }

		// Token: 0x060002E1 RID: 737 RVA: 0x00007228 File Offset: 0x00005428
		public void BeforeAdd(TElement element)
		{
			if (element.graph == null)
			{
				element.graph = this.graph;
				element.BeforeAdd();
				return;
			}
			if (element.graph == this.graph)
			{
				throw new InvalidOperationException("Graph elements cannot be added multiple time into the same graph.");
			}
			throw new InvalidOperationException("Graph elements cannot be shared across graphs.");
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000728F File Offset: 0x0000548F
		public void AfterAdd(TElement element)
		{
			element.AfterAdd();
			Action<TElement> itemAdded = this.ItemAdded;
			if (itemAdded != null)
			{
				itemAdded(element);
			}
			Action collectionChanged = this.CollectionChanged;
			if (collectionChanged == null)
			{
				return;
			}
			collectionChanged();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000072C0 File Offset: 0x000054C0
		public void BeforeRemove(TElement element)
		{
			element.BeforeRemove();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000072CF File Offset: 0x000054CF
		public void AfterRemove(TElement element)
		{
			element.graph = null;
			element.AfterRemove();
			Action<TElement> itemRemoved = this.ItemRemoved;
			if (itemRemoved != null)
			{
				itemRemoved(element);
			}
			Action collectionChanged = this.CollectionChanged;
			if (collectionChanged == null)
			{
				return;
			}
			collectionChanged();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000730E File Offset: 0x0000550E
		protected override void InsertItem(int index, TElement element)
		{
			Ensure.That("element").IsNotNull<TElement>(element);
			if (!this.ProxyCollectionChange)
			{
				this.BeforeAdd(element);
			}
			base.InsertItem(index, element);
			if (!this.ProxyCollectionChange)
			{
				this.AfterAdd(element);
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00007348 File Offset: 0x00005548
		protected override void RemoveItem(int index)
		{
			TElement telement = base[index];
			if (!base.Contains(telement))
			{
				throw new ArgumentOutOfRangeException("element");
			}
			if (!this.ProxyCollectionChange)
			{
				this.BeforeRemove(telement);
			}
			base.RemoveItem(index);
			if (!this.ProxyCollectionChange)
			{
				this.AfterRemove(telement);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00007398 File Offset: 0x00005598
		protected override void ClearItems()
		{
			List<TElement> list = ListPool<TElement>.New();
			foreach (TElement item in this)
			{
				list.Add(item);
			}
			list.Sort((TElement a, TElement b) => b.dependencyOrder.CompareTo(a.dependencyOrder));
			foreach (TElement item2 in list)
			{
				base.Remove(item2);
			}
			ListPool<TElement>.Free(list);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00007458 File Offset: 0x00005658
		protected override void SetItem(int index, TElement item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000745F File Offset: 0x0000565F
		public new NoAllocEnumerator<TElement> GetEnumerator()
		{
			return new NoAllocEnumerator<TElement>(this);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00007467 File Offset: 0x00005667
		TElement IKeyedCollection<Guid, !0>.get_Item(Guid key)
		{
			return base[key];
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00007470 File Offset: 0x00005670
		bool IKeyedCollection<Guid, !0>.Contains(Guid key)
		{
			return base.Contains(key);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00007479 File Offset: 0x00005679
		bool IKeyedCollection<Guid, !0>.Remove(Guid key)
		{
			return base.Remove(key);
		}
	}
}
