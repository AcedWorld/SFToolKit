using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x02000065 RID: 101
	public abstract class BaseTreeView : BaseVerticalCollectionView
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00010F4A File Offset: 0x0000F14A
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00010F57 File Offset: 0x0000F157
		public new IList itemsSource
		{
			get
			{
				return this.viewController.itemsSource;
			}
			internal set
			{
				base.GetOrCreateViewController().itemsSource = value;
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00010F66 File Offset: 0x0000F166
		public void SetRootItems<T>(IList<TreeViewItemData<T>> rootItems)
		{
			this.SetRootItemsInternal<T>(rootItems);
		}

		// Token: 0x0600044C RID: 1100
		internal abstract void SetRootItemsInternal<T>(IList<TreeViewItemData<T>> rootItems);

		// Token: 0x0600044D RID: 1101 RVA: 0x00010F74 File Offset: 0x0000F174
		public IEnumerable<int> GetRootIds()
		{
			return this.viewController.GetRootItemIds();
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00010F94 File Offset: 0x0000F194
		public int GetTreeCount()
		{
			return this.viewController.GetTreeItemsCount();
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x00010FB1 File Offset: 0x0000F1B1
		public new BaseTreeViewController viewController
		{
			get
			{
				return base.viewController as BaseTreeViewController;
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00010FBE File Offset: 0x0000F1BE
		private protected override void CreateVirtualizationController()
		{
			base.CreateVirtualizationController<ReusableTreeViewItem>();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00010FC8 File Offset: 0x0000F1C8
		public override void SetViewController(CollectionViewController controller)
		{
			bool flag = this.viewController != null;
			if (flag)
			{
				this.viewController.itemIndexChanged -= this.OnItemIndexChanged;
			}
			base.SetViewController(controller);
			bool flag2 = this.viewController != null;
			if (flag2)
			{
				this.viewController.itemIndexChanged += this.OnItemIndexChanged;
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0001102C File Offset: 0x0000F22C
		private void OnItemIndexChanged(int srcIndex, int dstIndex)
		{
			base.RefreshItems();
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00011036 File Offset: 0x0000F236
		internal override ICollectionDragAndDropController CreateDragAndDropController()
		{
			return new TreeViewReorderableDragAndDropController(this);
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x0001103E File Offset: 0x0000F23E
		// (set) Token: 0x06000455 RID: 1109 RVA: 0x00011046 File Offset: 0x0000F246
		public bool autoExpand
		{
			get
			{
				return this.m_AutoExpand;
			}
			set
			{
				this.m_AutoExpand = value;
				BaseTreeViewController viewController = this.viewController;
				if (viewController != null)
				{
					viewController.RegenerateWrappers();
				}
				base.RefreshItems();
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x00011069 File Offset: 0x0000F269
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x00011071 File Offset: 0x0000F271
		internal List<int> expandedItemIds
		{
			get
			{
				return this.m_ExpandedItemIds;
			}
			set
			{
				this.m_ExpandedItemIds = value;
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0001107A File Offset: 0x0000F27A
		public BaseTreeView() : this(-1)
		{
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00011085 File Offset: 0x0000F285
		public BaseTreeView(int itemHeight) : base(null, (float)itemHeight)
		{
			this.m_ExpandedItemIds = new List<int>();
			base.AddToClassList(BaseTreeView.ussClassName);
			base.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnTreeViewPointerUp), TrickleDown.TrickleDown);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x000110C0 File Offset: 0x0000F2C0
		public int GetIdForIndex(int index)
		{
			return this.viewController.GetIdForIndex(index);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000110E0 File Offset: 0x0000F2E0
		public int GetParentIdForIndex(int index)
		{
			return this.viewController.GetParentId(this.GetIdForIndex(index));
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00011104 File Offset: 0x0000F304
		public IEnumerable<int> GetChildrenIdsForIndex(int index)
		{
			return this.viewController.GetChildrenIdsByIndex(index);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00011124 File Offset: 0x0000F324
		public IEnumerable<TreeViewItemData<T>> GetSelectedItems<T>()
		{
			return this.GetSelectedItemsInternal<T>();
		}

		// Token: 0x0600045E RID: 1118
		private protected abstract IEnumerable<TreeViewItemData<T>> GetSelectedItemsInternal<T>();

		// Token: 0x0600045F RID: 1119 RVA: 0x0001113C File Offset: 0x0000F33C
		public T GetItemDataForIndex<T>(int index)
		{
			return this.GetItemDataForIndexInternal<T>(index);
		}

		// Token: 0x06000460 RID: 1120
		private protected abstract T GetItemDataForIndexInternal<T>(int index);

		// Token: 0x06000461 RID: 1121 RVA: 0x00011158 File Offset: 0x0000F358
		public T GetItemDataForId<T>(int id)
		{
			return this.GetItemDataForIdInternal<T>(id);
		}

		// Token: 0x06000462 RID: 1122
		private protected abstract T GetItemDataForIdInternal<T>(int id);

		// Token: 0x06000463 RID: 1123 RVA: 0x00011171 File Offset: 0x0000F371
		public void AddItem<T>(TreeViewItemData<T> item, int parentId = -1, int childIndex = -1, bool rebuildTree = true)
		{
			this.AddItemInternal<T>(item, parentId, childIndex, rebuildTree);
		}

		// Token: 0x06000464 RID: 1124
		private protected abstract void AddItemInternal<T>(TreeViewItemData<T> item, int parentId, int childIndex, bool rebuildTree);

		// Token: 0x06000465 RID: 1125 RVA: 0x00011180 File Offset: 0x0000F380
		public bool TryRemoveItem(int id)
		{
			bool flag = this.viewController.TryRemoveItem(id, true);
			bool result;
			if (flag)
			{
				base.RefreshItems();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000111B0 File Offset: 0x0000F3B0
		internal override void OnViewDataReady()
		{
			base.OnViewDataReady();
			bool flag = this.viewController != null;
			if (flag)
			{
				this.viewController.RebuildTree();
				base.RefreshItems();
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000111E8 File Offset: 0x0000F3E8
		private protected override bool HandleItemNavigation(bool moveIn, bool altPressed)
		{
			int num = 1;
			bool flag = false;
			foreach (int id in base.selectedIds)
			{
				int indexForId = this.viewController.GetIndexForId(id);
				bool flag2 = !this.viewController.HasChildrenByIndex(indexForId);
				if (flag2)
				{
					break;
				}
				bool flag3 = moveIn && !this.IsExpandedByIndex(indexForId);
				if (flag3)
				{
					this.ExpandItemByIndex(indexForId, altPressed);
					flag = true;
				}
				else
				{
					bool flag4 = !moveIn && this.IsExpandedByIndex(indexForId);
					if (flag4)
					{
						this.CollapseItemByIndex(indexForId, altPressed);
						flag = true;
					}
				}
			}
			bool flag5 = flag;
			bool result;
			if (flag5)
			{
				result = true;
			}
			else
			{
				bool flag6 = !moveIn;
				if (flag6)
				{
					int idForIndex = this.viewController.GetIdForIndex(base.selectedIndex);
					int parentId = this.viewController.GetParentId(idForIndex);
					bool flag7 = parentId != -1;
					if (flag7)
					{
						this.SetSelectionById(parentId);
						base.ScrollToItemById(parentId);
						return true;
					}
					num = -1;
				}
				int num2 = base.selectedIndex;
				bool flag8;
				do
				{
					num2 += num;
					flag8 = this.viewController.HasChildrenByIndex(num2);
				}
				while (!flag8 && num2 >= 0 && num2 < this.itemsSource.Count);
				bool flag9 = flag8;
				if (flag9)
				{
					base.SetSelection(num2);
					base.ScrollToItem(num2);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00011374 File Offset: 0x0000F574
		public void SetSelectionById(int id)
		{
			this.SetSelectionById(new int[]
			{
				id
			});
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00011388 File Offset: 0x0000F588
		public void SetSelectionById(IEnumerable<int> ids)
		{
			this.SetSelectionInternalById(ids, true);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00011394 File Offset: 0x0000F594
		public void SetSelectionByIdWithoutNotify(IEnumerable<int> ids)
		{
			this.SetSelectionInternalById(ids, false);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x000113A0 File Offset: 0x0000F5A0
		internal void SetSelectionInternalById(IEnumerable<int> ids, bool sendNotification)
		{
			bool flag = ids == null;
			if (!flag)
			{
				List<int> indices = (from id in ids
				select this.GetItemIndex(id, true)).ToList<int>();
				base.SetSelectionInternal(indices, sendNotification);
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000113DC File Offset: 0x0000F5DC
		public void AddToSelectionById(int id)
		{
			int itemIndex = this.GetItemIndex(id, true);
			base.Rebuild();
			base.AddToSelection(itemIndex);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00011404 File Offset: 0x0000F604
		public void RemoveFromSelectionById(int id)
		{
			int itemIndex = this.GetItemIndex(id, false);
			base.RemoveFromSelection(itemIndex);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00011424 File Offset: 0x0000F624
		private int GetItemIndex(int id, bool expand = false)
		{
			if (expand)
			{
				for (int parentId = this.viewController.GetParentId(id); parentId != -1; parentId = this.viewController.GetParentId(parentId))
				{
					bool flag = !this.m_ExpandedItemIds.Contains(parentId);
					if (flag)
					{
						this.viewController.ExpandItem(parentId, false, true);
					}
				}
			}
			return this.viewController.GetIndexForId(id);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00011498 File Offset: 0x0000F698
		internal void CopyExpandedStates(int sourceId, int targetId)
		{
			bool flag = this.IsExpanded(sourceId);
			if (flag)
			{
				this.ExpandItem(targetId, false);
				bool flag2 = this.viewController.HasChildren(sourceId);
				if (flag2)
				{
					bool flag3 = this.viewController.GetChildrenIds(sourceId).Count<int>() != this.viewController.GetChildrenIds(targetId).Count<int>();
					if (flag3)
					{
						Debug.LogWarning("Source and target hierarchies are not the same");
					}
					else
					{
						for (int i = 0; i < this.viewController.GetChildrenIds(sourceId).Count<int>(); i++)
						{
							int sourceId2 = this.viewController.GetChildrenIds(sourceId).ElementAt(i);
							int targetId2 = this.viewController.GetChildrenIds(targetId).ElementAt(i);
							this.CopyExpandedStates(sourceId2, targetId2);
						}
					}
				}
			}
			else
			{
				this.CollapseItem(targetId, false);
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00011574 File Offset: 0x0000F774
		public bool IsExpanded(int id)
		{
			return this.viewController.IsExpanded(id);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00011592 File Offset: 0x0000F792
		public void CollapseItem(int id, bool collapseAllChildren = false)
		{
			this.viewController.CollapseItem(id, collapseAllChildren);
			base.RefreshItems();
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x000115AA File Offset: 0x0000F7AA
		public void ExpandItem(int id, bool expandAllChildren = false)
		{
			this.viewController.ExpandItem(id, expandAllChildren, true);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x000115BC File Offset: 0x0000F7BC
		public void ExpandRootItems()
		{
			foreach (int id in this.viewController.GetRootItemIds())
			{
				this.viewController.ExpandItem(id, false, false);
			}
			base.RefreshItems();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00011620 File Offset: 0x0000F820
		public void ExpandAll()
		{
			this.viewController.ExpandAll();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001162F File Offset: 0x0000F82F
		public void CollapseAll()
		{
			this.viewController.CollapseAll();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001163E File Offset: 0x0000F83E
		private void OnTreeViewPointerUp(PointerUpEvent evt)
		{
			base.scrollView.contentContainer.Focus();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00011654 File Offset: 0x0000F854
		private bool IsExpandedByIndex(int index)
		{
			return this.viewController.IsExpandedByIndex(index);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00011674 File Offset: 0x0000F874
		private void CollapseItemByIndex(int index, bool collapseAll)
		{
			bool flag = !this.viewController.HasChildrenByIndex(index);
			if (!flag)
			{
				this.viewController.CollapseItemByIndex(index, collapseAll);
				base.RefreshItems();
				base.SaveViewData();
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000116B4 File Offset: 0x0000F8B4
		private void ExpandItemByIndex(int index, bool expandAll)
		{
			bool flag = !this.viewController.HasChildrenByIndex(index);
			if (!flag)
			{
				this.viewController.ExpandItemByIndex(index, expandAll, true);
				base.RefreshItems();
				base.SaveViewData();
			}
		}

		// Token: 0x04000199 RID: 409
		public new static readonly string ussClassName = "unity-tree-view";

		// Token: 0x0400019A RID: 410
		public new static readonly string itemUssClassName = BaseTreeView.ussClassName + "__item";

		// Token: 0x0400019B RID: 411
		public static readonly string itemToggleUssClassName = BaseTreeView.ussClassName + "__item-toggle";

		// Token: 0x0400019C RID: 412
		public static readonly string itemIndentsContainerUssClassName = BaseTreeView.ussClassName + "__item-indents";

		// Token: 0x0400019D RID: 413
		public static readonly string itemIndentUssClassName = BaseTreeView.ussClassName + "__item-indent";

		// Token: 0x0400019E RID: 414
		public static readonly string itemContentContainerUssClassName = BaseTreeView.ussClassName + "__item-content";

		// Token: 0x0400019F RID: 415
		private bool m_AutoExpand;

		// Token: 0x040001A0 RID: 416
		[SerializeField]
		private List<int> m_ExpandedItemIds;

		// Token: 0x02000066 RID: 102
		public new class UxmlTraits : BaseVerticalCollectionView.UxmlTraits
		{
			// Token: 0x170000CF RID: 207
			// (get) Token: 0x0600047C RID: 1148 RVA: 0x0001177C File Offset: 0x0000F97C
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield break;
				}
			}

			// Token: 0x0600047D RID: 1149 RVA: 0x0001179C File Offset: 0x0000F99C
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				BaseTreeView baseTreeView = (BaseTreeView)ve;
				baseTreeView.autoExpand = this.m_AutoExpand.GetValueFromBag(bag, cc);
			}

			// Token: 0x040001A1 RID: 417
			private readonly UxmlBoolAttributeDescription m_AutoExpand = new UxmlBoolAttributeDescription
			{
				name = "auto-expand",
				defaultValue = false
			};
		}
	}
}
