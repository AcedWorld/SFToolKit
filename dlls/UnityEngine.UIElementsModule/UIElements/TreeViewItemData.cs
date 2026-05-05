using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000141 RID: 321
	public readonly struct TreeViewItemData<T>
	{
		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x00029BED File Offset: 0x00027DED
		public int id { get; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x00029BF5 File Offset: 0x00027DF5
		public T data
		{
			get
			{
				return this.m_Data;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00029BFD File Offset: 0x00027DFD
		public IEnumerable<TreeViewItemData<T>> children
		{
			get
			{
				return this.m_Children;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00029C05 File Offset: 0x00027E05
		public bool hasChildren
		{
			get
			{
				return this.m_Children != null && this.m_Children.Count > 0;
			}
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00029C20 File Offset: 0x00027E20
		public TreeViewItemData(int id, T data, List<TreeViewItemData<T>> children = null)
		{
			this.id = id;
			this.m_Data = data;
			this.m_Children = (children ?? new List<TreeViewItemData<T>>());
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00029C41 File Offset: 0x00027E41
		internal void AddChild(TreeViewItemData<T> child)
		{
			this.m_Children.Add(child);
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00029C54 File Offset: 0x00027E54
		internal void AddChildren(IList<TreeViewItemData<T>> children)
		{
			foreach (TreeViewItemData<T> child in children)
			{
				this.AddChild(child);
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00029CA0 File Offset: 0x00027EA0
		internal void InsertChild(TreeViewItemData<T> child, int index)
		{
			bool flag = index < 0 || index >= this.m_Children.Count;
			if (flag)
			{
				this.m_Children.Add(child);
			}
			else
			{
				this.m_Children.Insert(index, child);
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00029CE8 File Offset: 0x00027EE8
		internal void RemoveChild(int childId)
		{
			bool flag = this.m_Children == null;
			if (!flag)
			{
				for (int i = 0; i < this.m_Children.Count; i++)
				{
					bool flag2 = childId == this.m_Children[i].id;
					if (flag2)
					{
						this.m_Children.RemoveAt(i);
						break;
					}
				}
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x00029D50 File Offset: 0x00027F50
		internal int GetChildIndex(int itemId)
		{
			int num = 0;
			foreach (TreeViewItemData<T> treeViewItemData in this.m_Children)
			{
				bool flag = treeViewItemData.id == itemId;
				if (flag)
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00029DBC File Offset: 0x00027FBC
		internal void ReplaceChild(TreeViewItemData<T> newChild)
		{
			bool flag = !this.hasChildren;
			if (!flag)
			{
				int num = 0;
				foreach (TreeViewItemData<T> treeViewItemData in this.m_Children)
				{
					bool flag2 = treeViewItemData.id == newChild.id;
					if (flag2)
					{
						this.m_Children.RemoveAt(num);
						this.m_Children.Insert(num, newChild);
						break;
					}
					num++;
				}
			}
		}

		// Token: 0x04000502 RID: 1282
		private readonly T m_Data;

		// Token: 0x04000503 RID: 1283
		private readonly IList<TreeViewItemData<T>> m_Children;
	}
}
