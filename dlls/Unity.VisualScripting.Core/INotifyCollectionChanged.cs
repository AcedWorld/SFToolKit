using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001A RID: 26
	public interface INotifyCollectionChanged<T>
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600009B RID: 155
		// (remove) Token: 0x0600009C RID: 156
		event Action<T> ItemAdded;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600009D RID: 157
		// (remove) Token: 0x0600009E RID: 158
		event Action<T> ItemRemoved;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600009F RID: 159
		// (remove) Token: 0x060000A0 RID: 160
		event Action CollectionChanged;
	}
}
