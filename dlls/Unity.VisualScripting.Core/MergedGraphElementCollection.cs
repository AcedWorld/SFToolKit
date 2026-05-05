using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200007B RID: 123
	public sealed class MergedGraphElementCollection : MergedKeyedCollection<Guid, IGraphElement>, INotifyCollectionChanged<IGraphElement>
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060003B0 RID: 944 RVA: 0x000091C0 File Offset: 0x000073C0
		// (remove) Token: 0x060003B1 RID: 945 RVA: 0x000091F8 File Offset: 0x000073F8
		public event Action<IGraphElement> ItemAdded;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060003B2 RID: 946 RVA: 0x00009230 File Offset: 0x00007430
		// (remove) Token: 0x060003B3 RID: 947 RVA: 0x00009268 File Offset: 0x00007468
		public event Action<IGraphElement> ItemRemoved;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060003B4 RID: 948 RVA: 0x000092A0 File Offset: 0x000074A0
		// (remove) Token: 0x060003B5 RID: 949 RVA: 0x000092D8 File Offset: 0x000074D8
		public event Action CollectionChanged;

		// Token: 0x060003B6 RID: 950 RVA: 0x00009310 File Offset: 0x00007510
		public override void Include<TSubItem>(IKeyedCollection<Guid, TSubItem> collection)
		{
			base.Include<TSubItem>(collection);
			IGraphElementCollection<TSubItem> graphElementCollection = collection as IGraphElementCollection<TSubItem>;
			if (graphElementCollection != null)
			{
				graphElementCollection.ItemAdded += delegate(TSubItem element)
				{
					Action<IGraphElement> itemAdded = this.ItemAdded;
					if (itemAdded == null)
					{
						return;
					}
					itemAdded(element);
				};
				graphElementCollection.ItemRemoved += delegate(TSubItem element)
				{
					Action<IGraphElement> itemRemoved = this.ItemRemoved;
					if (itemRemoved == null)
					{
						return;
					}
					itemRemoved(element);
				};
				graphElementCollection.CollectionChanged += delegate()
				{
					Action collectionChanged = this.CollectionChanged;
					if (collectionChanged == null)
					{
						return;
					}
					collectionChanged();
				};
			}
		}
	}
}
