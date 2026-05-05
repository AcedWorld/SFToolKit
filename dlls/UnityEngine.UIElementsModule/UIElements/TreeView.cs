using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000138 RID: 312
	public class TreeView : BaseTreeView
	{
		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00028DD6 File Offset: 0x00026FD6
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x00028DE0 File Offset: 0x00026FE0
		public new Func<VisualElement> makeItem
		{
			get
			{
				return this.m_MakeItem;
			}
			set
			{
				bool flag = value != this.m_MakeItem;
				if (flag)
				{
					this.m_MakeItem = value;
					base.Rebuild();
				}
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00028E0E File Offset: 0x0002700E
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x00028E18 File Offset: 0x00027018
		public new Action<VisualElement, int> bindItem
		{
			get
			{
				return this.m_BindItem;
			}
			set
			{
				bool flag = value != this.m_BindItem;
				if (flag)
				{
					this.m_BindItem = value;
					base.RefreshItems();
				}
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x00028E46 File Offset: 0x00027046
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x00028E4E File Offset: 0x0002704E
		public new Action<VisualElement, int> unbindItem { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x00028E57 File Offset: 0x00027057
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x00028E5F File Offset: 0x0002705F
		public new Action<VisualElement> destroyItem { get; set; }

		// Token: 0x06000A49 RID: 2633 RVA: 0x00028E68 File Offset: 0x00027068
		internal override void SetRootItemsInternal<T>(IList<TreeViewItemData<T>> rootItems)
		{
			TreeViewHelpers<T, DefaultTreeViewController<T>>.SetRootItems(this, rootItems, () => new DefaultTreeViewController<T>());
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00028E94 File Offset: 0x00027094
		internal override bool HasValidDataAndBindings()
		{
			return base.HasValidDataAndBindings() && this.makeItem != null == (this.bindItem != null);
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00028EC5 File Offset: 0x000270C5
		public new TreeViewController viewController
		{
			get
			{
				return base.viewController as TreeViewController;
			}
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00028ED2 File Offset: 0x000270D2
		protected override CollectionViewController CreateViewController()
		{
			return new DefaultTreeViewController<object>();
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00028ED9 File Offset: 0x000270D9
		public TreeView() : this(null, null)
		{
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00028EE5 File Offset: 0x000270E5
		public TreeView(Func<VisualElement> makeItem, Action<VisualElement, int> bindItem) : base(-1)
		{
			this.makeItem = makeItem;
			this.bindItem = bindItem;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00028F00 File Offset: 0x00027100
		public TreeView(int itemHeight, Func<VisualElement> makeItem, Action<VisualElement, int> bindItem) : this(makeItem, bindItem)
		{
			base.fixedItemHeight = (float)itemHeight;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00028F18 File Offset: 0x00027118
		private protected override IEnumerable<TreeViewItemData<T>> GetSelectedItemsInternal<T>()
		{
			return TreeViewHelpers<T, DefaultTreeViewController<T>>.GetSelectedItems(this);
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00028F30 File Offset: 0x00027130
		private protected override T GetItemDataForIndexInternal<T>(int index)
		{
			return TreeViewHelpers<T, DefaultTreeViewController<T>>.GetItemDataForIndex(this, index);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00028F4C File Offset: 0x0002714C
		private protected override T GetItemDataForIdInternal<T>(int id)
		{
			return TreeViewHelpers<T, DefaultTreeViewController<T>>.GetItemDataForId(this, id);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00028F65 File Offset: 0x00027165
		private protected override void AddItemInternal<T>(TreeViewItemData<T> item, int parentId, int childIndex, bool rebuildTree)
		{
			TreeViewHelpers<T, DefaultTreeViewController<T>>.AddItem(this, item, parentId, childIndex, rebuildTree);
		}

		// Token: 0x040004E8 RID: 1256
		private Func<VisualElement> m_MakeItem;

		// Token: 0x040004E9 RID: 1257
		private Action<VisualElement, int> m_BindItem;

		// Token: 0x02000139 RID: 313
		public new class UxmlFactory : UxmlFactory<TreeView, TreeView.UxmlTraits>
		{
		}

		// Token: 0x0200013A RID: 314
		public new class UxmlTraits : BaseTreeView.UxmlTraits
		{
		}
	}
}
