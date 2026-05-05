using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x02000021 RID: 33
	public abstract class NonNullableCollection<T> : Collection<T>
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00003A60 File Offset: 0x00001C60
		protected override void InsertItem(int index, T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			base.InsertItem(index, item);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003A7D File Offset: 0x00001C7D
		protected override void SetItem(int index, T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			base.SetItem(index, item);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00003A9C File Offset: 0x00001C9C
		public void AddRange(IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				base.Add(item);
			}
		}
	}
}
