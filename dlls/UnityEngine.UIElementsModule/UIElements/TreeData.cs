using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace UnityEngine.UIElements
{
	// Token: 0x0200013E RID: 318
	internal readonly struct TreeData<T>
	{
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x0002953B File Offset: 0x0002773B
		public IEnumerable<int> rootItemIds
		{
			get
			{
				return this.m_RootItemIds;
			}
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00029543 File Offset: 0x00027743
		public TreeData(IList<TreeViewItemData<T>> rootItems)
		{
			this.m_RootItemIds = new List<int>();
			this.m_Tree = new Dictionary<int, TreeViewItemData<T>>();
			this.m_ParentIds = new Dictionary<int, int>();
			this.m_ChildrenIds = new Dictionary<int, List<int>>();
			this.RefreshTree(rootItems);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0002957C File Offset: 0x0002777C
		public TreeViewItemData<T> GetDataForId(int id)
		{
			TreeViewItemData<T> treeViewItemData;
			bool flag = this.m_Tree.TryGetValue(id, out treeViewItemData);
			TreeViewItemData<T> result;
			if (flag)
			{
				result = treeViewItemData;
			}
			else
			{
				result = default(TreeViewItemData<T>);
			}
			return result;
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x000295B0 File Offset: 0x000277B0
		public int GetParentId(int id)
		{
			int num;
			bool flag = this.m_ParentIds.TryGetValue(id, out num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x000295DC File Offset: 0x000277DC
		public void AddItem(TreeViewItemData<T> item, int parentId, int childIndex)
		{
			List<TreeViewItemData<T>> list = CollectionPool<List<TreeViewItemData<T>>, TreeViewItemData<T>>.Get();
			list.Add(item);
			this.BuildTree(list, false);
			this.AddItemToParent(item, parentId, childIndex);
			CollectionPool<List<TreeViewItemData<T>>, TreeViewItemData<T>>.Release(list);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00029614 File Offset: 0x00027814
		public bool TryRemove(int id)
		{
			int parentId;
			bool flag = this.m_ParentIds.TryGetValue(id, out parentId);
			if (flag)
			{
				this.RemoveFromParent(id, parentId);
			}
			else
			{
				this.m_RootItemIds.Remove(id);
			}
			return this.TryRemoveChildrenIds(id);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0002965C File Offset: 0x0002785C
		public void Move(int id, int newParentId, int childIndex)
		{
			TreeViewItemData<T> item;
			bool flag = !this.m_Tree.TryGetValue(id, out item);
			if (!flag)
			{
				int num;
				bool flag2 = this.m_ParentIds.TryGetValue(id, out num);
				if (flag2)
				{
					bool flag3 = num == newParentId;
					if (flag3)
					{
						int childIndex2 = this.m_Tree[num].GetChildIndex(id);
						bool flag4 = childIndex2 < childIndex;
						if (flag4)
						{
							childIndex--;
						}
					}
					this.RemoveFromParent(item.id, num);
				}
				else
				{
					int num2 = this.m_RootItemIds.IndexOf(id);
					bool flag5 = newParentId == -1 && num2 < childIndex;
					if (flag5)
					{
						childIndex--;
					}
					this.m_RootItemIds.Remove(id);
				}
				this.AddItemToParent(item, newParentId, childIndex);
			}
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0002971C File Offset: 0x0002791C
		public bool HasAncestor(int childId, int ancestorId)
		{
			bool flag = childId == -1 || ancestorId == -1;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int id = childId;
				int parentId;
				while ((parentId = this.GetParentId(id)) != -1)
				{
					bool flag2 = ancestorId == parentId;
					if (flag2)
					{
						return true;
					}
					id = parentId;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00029770 File Offset: 0x00027970
		private void AddItemToParent(TreeViewItemData<T> item, int parentId, int childIndex)
		{
			bool flag = parentId == -1;
			if (flag)
			{
				this.m_ParentIds.Remove(item.id);
				bool flag2 = childIndex < 0 || childIndex >= this.m_RootItemIds.Count;
				if (flag2)
				{
					this.m_RootItemIds.Add(item.id);
				}
				else
				{
					this.m_RootItemIds.Insert(childIndex, item.id);
				}
			}
			else
			{
				TreeViewItemData<T> treeViewItemData = this.m_Tree[parentId];
				treeViewItemData.InsertChild(item, childIndex);
				this.m_Tree[parentId] = treeViewItemData;
				this.m_ParentIds[item.id] = parentId;
				this.UpdateParentTree(treeViewItemData);
			}
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00029824 File Offset: 0x00027A24
		private void RemoveFromParent(int id, int parentId)
		{
			TreeViewItemData<T> treeViewItemData = this.m_Tree[parentId];
			treeViewItemData.RemoveChild(id);
			this.m_Tree[parentId] = treeViewItemData;
			List<int> list;
			bool flag = this.m_ChildrenIds.TryGetValue(parentId, out list);
			if (flag)
			{
				list.Remove(id);
			}
			this.UpdateParentTree(treeViewItemData);
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00029878 File Offset: 0x00027A78
		private void UpdateParentTree(TreeViewItemData<T> current)
		{
			for (;;)
			{
				int key;
				bool flag = this.m_ParentIds.TryGetValue(current.id, out key);
				if (!flag)
				{
					break;
				}
				TreeViewItemData<T> treeViewItemData = this.m_Tree[key];
				treeViewItemData.ReplaceChild(current);
				this.m_Tree[key] = treeViewItemData;
				current = treeViewItemData;
			}
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x000298CC File Offset: 0x00027ACC
		private bool TryRemoveChildrenIds(int id)
		{
			TreeViewItemData<T> treeViewItemData;
			bool flag = this.m_Tree.TryGetValue(id, out treeViewItemData) && treeViewItemData.children != null;
			if (flag)
			{
				foreach (TreeViewItemData<T> treeViewItemData2 in treeViewItemData.children)
				{
					this.TryRemoveChildrenIds(treeViewItemData2.id);
				}
			}
			List<int> toRelease;
			bool flag2 = this.m_ChildrenIds.TryGetValue(id, out toRelease);
			if (flag2)
			{
				CollectionPool<List<int>, int>.Release(toRelease);
			}
			bool flag3 = false;
			flag3 |= this.m_RootItemIds.Remove(id);
			flag3 |= this.m_ChildrenIds.Remove(id);
			flag3 |= this.m_ParentIds.Remove(id);
			flag3 |= this.m_Tree.Remove(id);
			return flag3 | this.m_RootItemIds.Remove(id);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x000299C0 File Offset: 0x00027BC0
		private void RefreshTree(IList<TreeViewItemData<T>> rootItems)
		{
			this.m_Tree.Clear();
			this.m_ParentIds.Clear();
			this.m_ChildrenIds.Clear();
			this.m_RootItemIds.Clear();
			this.BuildTree(rootItems, true);
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x000299FC File Offset: 0x00027BFC
		private void BuildTree(IEnumerable<TreeViewItemData<T>> items, bool isRoot)
		{
			bool flag = items == null;
			if (!flag)
			{
				foreach (TreeViewItemData<T> value in items)
				{
					this.m_Tree.Add(value.id, value);
					if (isRoot)
					{
						this.m_RootItemIds.Add(value.id);
					}
					bool flag2 = value.children != null;
					if (flag2)
					{
						List<int> list;
						bool flag3 = !this.m_ChildrenIds.TryGetValue(value.id, out list);
						if (flag3)
						{
							this.m_ChildrenIds.Add(value.id, list = CollectionPool<List<int>, int>.Get());
						}
						foreach (TreeViewItemData<T> treeViewItemData in value.children)
						{
							this.m_ParentIds.Add(treeViewItemData.id, value.id);
							list.Add(treeViewItemData.id);
						}
						this.BuildTree(value.children, false);
					}
				}
			}
		}

		// Token: 0x040004F7 RID: 1271
		private readonly IList<int> m_RootItemIds;

		// Token: 0x040004F8 RID: 1272
		private readonly Dictionary<int, TreeViewItemData<T>> m_Tree;

		// Token: 0x040004F9 RID: 1273
		private readonly Dictionary<int, int> m_ParentIds;

		// Token: 0x040004FA RID: 1274
		private readonly Dictionary<int, List<int>> m_ChildrenIds;
	}
}
