using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000140 RID: 320
	internal readonly struct TreeViewItemWrapper
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000A7A RID: 2682 RVA: 0x00029BA8 File Offset: 0x00027DA8
		public int id
		{
			get
			{
				return this.item.id;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x00029BB5 File Offset: 0x00027DB5
		public int parentId
		{
			get
			{
				return this.item.parentId;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000A7C RID: 2684 RVA: 0x00029BC2 File Offset: 0x00027DC2
		public IEnumerable<int> childrenIds
		{
			get
			{
				return this.item.childrenIds;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x00029BCF File Offset: 0x00027DCF
		public bool hasChildren
		{
			get
			{
				return this.item.hasChildren;
			}
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00029BDC File Offset: 0x00027DDC
		public TreeViewItemWrapper(TreeItem item, int depth)
		{
			this.item = item;
			this.depth = depth;
		}

		// Token: 0x040004FF RID: 1279
		public readonly TreeItem item;

		// Token: 0x04000500 RID: 1280
		public readonly int depth;
	}
}
