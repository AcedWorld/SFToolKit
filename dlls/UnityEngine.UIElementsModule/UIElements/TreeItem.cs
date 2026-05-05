using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x0200013F RID: 319
	internal readonly struct TreeItem
	{
		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x00029B60 File Offset: 0x00027D60
		public int id { get; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00029B68 File Offset: 0x00027D68
		public int parentId { get; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00029B70 File Offset: 0x00027D70
		public IEnumerable<int> childrenIds { get; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000A78 RID: 2680 RVA: 0x00029B78 File Offset: 0x00027D78
		public bool hasChildren
		{
			get
			{
				return this.childrenIds != null && this.childrenIds.Any<int>();
			}
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00029B90 File Offset: 0x00027D90
		public TreeItem(int id, int parentId = -1, IEnumerable<int> childrenIds = null)
		{
			this.id = id;
			this.parentId = parentId;
			this.childrenIds = childrenIds;
		}

		// Token: 0x040004FB RID: 1275
		public const int invalidId = -1;
	}
}
