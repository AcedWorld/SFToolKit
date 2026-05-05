using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000169 RID: 361
	internal struct DragAndDropArgs : IListDragAndDropArgs
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x0002E373 File Offset: 0x0002C573
		// (set) Token: 0x06000BBC RID: 3004 RVA: 0x0002E37B File Offset: 0x0002C57B
		public object target { readonly get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x0002E384 File Offset: 0x0002C584
		// (set) Token: 0x06000BBE RID: 3006 RVA: 0x0002E38C File Offset: 0x0002C58C
		public int insertAtIndex { readonly get; set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x0002E395 File Offset: 0x0002C595
		// (set) Token: 0x06000BC0 RID: 3008 RVA: 0x0002E39D File Offset: 0x0002C59D
		public int parentId { readonly get; set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x0002E3A6 File Offset: 0x0002C5A6
		// (set) Token: 0x06000BC2 RID: 3010 RVA: 0x0002E3AE File Offset: 0x0002C5AE
		public int childIndex { readonly get; set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x0002E3B7 File Offset: 0x0002C5B7
		// (set) Token: 0x06000BC4 RID: 3012 RVA: 0x0002E3BF File Offset: 0x0002C5BF
		public DragAndDropPosition dragAndDropPosition { readonly get; set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0002E3C8 File Offset: 0x0002C5C8
		// (set) Token: 0x06000BC6 RID: 3014 RVA: 0x0002E3D0 File Offset: 0x0002C5D0
		public DragAndDropData dragAndDropData { readonly get; set; }
	}
}
