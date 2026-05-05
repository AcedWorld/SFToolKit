using System;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x02000028 RID: 40
	public class WatchedList<T> : Collection<T>, INotifyCollectionChanged<T>
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000171 RID: 369 RVA: 0x00004534 File Offset: 0x00002734
		// (remove) Token: 0x06000172 RID: 370 RVA: 0x0000456C File Offset: 0x0000276C
		public event Action<T> ItemAdded;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000173 RID: 371 RVA: 0x000045A4 File Offset: 0x000027A4
		// (remove) Token: 0x06000174 RID: 372 RVA: 0x000045DC File Offset: 0x000027DC
		public event Action<T> ItemRemoved;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000175 RID: 373 RVA: 0x00004614 File Offset: 0x00002814
		// (remove) Token: 0x06000176 RID: 374 RVA: 0x0000464C File Offset: 0x0000284C
		public event Action CollectionChanged;

		// Token: 0x06000177 RID: 375 RVA: 0x00004681 File Offset: 0x00002881
		protected override void InsertItem(int index, T item)
		{
			base.InsertItem(index, item);
			Action<T> itemAdded = this.ItemAdded;
			if (itemAdded != null)
			{
				itemAdded(item);
			}
			Action collectionChanged = this.CollectionChanged;
			if (collectionChanged == null)
			{
				return;
			}
			collectionChanged();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000046B0 File Offset: 0x000028B0
		protected override void RemoveItem(int index)
		{
			if (index < base.Count)
			{
				T obj = base[index];
				base.RemoveItem(index);
				Action<T> itemRemoved = this.ItemRemoved;
				if (itemRemoved != null)
				{
					itemRemoved(obj);
				}
				Action collectionChanged = this.CollectionChanged;
				if (collectionChanged == null)
				{
					return;
				}
				collectionChanged();
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000046F7 File Offset: 0x000028F7
		protected override void ClearItems()
		{
			while (base.Count > 0)
			{
				this.RemoveItem(0);
			}
		}
	}
}
