using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200016F RID: 367
	internal readonly struct HandleDragAndDropArgs
	{
		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0002E410 File Offset: 0x0002C610
		public Vector2 position { get; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x0002E418 File Offset: 0x0002C618
		public object target
		{
			get
			{
				return this.m_DragAndDropArgs.target;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0002E425 File Offset: 0x0002C625
		public int insertAtIndex
		{
			get
			{
				return this.m_DragAndDropArgs.insertAtIndex;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0002E432 File Offset: 0x0002C632
		public int parentId
		{
			get
			{
				return this.m_DragAndDropArgs.parentId;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0002E43F File Offset: 0x0002C63F
		public int childIndex
		{
			get
			{
				return this.m_DragAndDropArgs.childIndex;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x0002E44C File Offset: 0x0002C64C
		public DragAndDropPosition dropPosition
		{
			get
			{
				return this.m_DragAndDropArgs.dragAndDropPosition;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x0002E459 File Offset: 0x0002C659
		public DragAndDropData dragAndDropData
		{
			get
			{
				return this.m_DragAndDropArgs.dragAndDropData;
			}
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0002E466 File Offset: 0x0002C666
		internal HandleDragAndDropArgs(Vector2 position, DragAndDropArgs dragAndDropArgs)
		{
			this.position = position;
			this.m_DragAndDropArgs = dragAndDropArgs;
		}

		// Token: 0x04000591 RID: 1425
		private readonly DragAndDropArgs m_DragAndDropArgs;
	}
}
