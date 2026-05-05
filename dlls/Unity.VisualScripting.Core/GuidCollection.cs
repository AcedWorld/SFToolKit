using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x02000016 RID: 22
	public class GuidCollection<T> : KeyedCollection<Guid, T>, IKeyedCollection<Guid, !0>, ICollection<T>, IEnumerable<!0>, IEnumerable where T : IIdentifiable
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00002F2A File Offset: 0x0000112A
		protected override Guid GetKeyForItem(T item)
		{
			return item.guid;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002F39 File Offset: 0x00001139
		protected override void InsertItem(int index, T item)
		{
			Ensure.That("item").IsNotNull<T>(item);
			base.InsertItem(index, item);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00002F53 File Offset: 0x00001153
		protected override void SetItem(int index, T item)
		{
			Ensure.That("item").IsNotNull<T>(item);
			base.SetItem(index, item);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002F6D File Offset: 0x0000116D
		public new bool TryGetValue(Guid key, out T value)
		{
			if (base.Dictionary == null)
			{
				value = default(T);
				return false;
			}
			return base.Dictionary.TryGetValue(key, out value);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002F95 File Offset: 0x00001195
		T IKeyedCollection<Guid, !0>.get_Item(Guid key)
		{
			return base[key];
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002F9E File Offset: 0x0000119E
		bool IKeyedCollection<Guid, !0>.Contains(Guid key)
		{
			return base.Contains(key);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002FA7 File Offset: 0x000011A7
		bool IKeyedCollection<Guid, !0>.Remove(Guid key)
		{
			return base.Remove(key);
		}
	}
}
