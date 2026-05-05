using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000174 RID: 372
	internal static class ListViewDraggerExtension
	{
		// Token: 0x06000BFF RID: 3071 RVA: 0x0002F8A4 File Offset: 0x0002DAA4
		public static ReusableCollectionItem GetRecycledItemFromId(this BaseVerticalCollectionView listView, int id)
		{
			foreach (ReusableCollectionItem reusableCollectionItem in listView.activeItems)
			{
				bool flag = reusableCollectionItem.id.Equals(id);
				if (flag)
				{
					return reusableCollectionItem;
				}
			}
			return null;
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0002F910 File Offset: 0x0002DB10
		public static ReusableCollectionItem GetRecycledItemFromIndex(this BaseVerticalCollectionView listView, int index)
		{
			foreach (ReusableCollectionItem reusableCollectionItem in listView.activeItems)
			{
				bool flag = reusableCollectionItem.index.Equals(index);
				if (flag)
				{
					return reusableCollectionItem;
				}
			}
			return null;
		}
	}
}
