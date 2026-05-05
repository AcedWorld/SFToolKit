using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200004C RID: 76
	internal class ReusableListViewItem : ReusableCollectionItem
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000BF28 File Offset: 0x0000A128
		public override VisualElement rootElement
		{
			get
			{
				return this.m_Container ?? base.bindableElement;
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000BF3C File Offset: 0x0000A13C
		public void Init(VisualElement item, bool usesAnimatedDragger)
		{
			base.Init(item);
			VisualElement root = new VisualElement
			{
				name = BaseListView.reorderableItemUssClassName
			};
			this.UpdateHierarchy(root, base.bindableElement, usesAnimatedDragger);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000BF74 File Offset: 0x0000A174
		protected void UpdateHierarchy(VisualElement root, VisualElement item, bool usesAnimatedDragger)
		{
			if (usesAnimatedDragger)
			{
				bool flag = this.m_Container != null;
				if (!flag)
				{
					this.m_Container = root;
					this.m_Container.AddToClassList(BaseListView.reorderableItemUssClassName);
					this.m_DragHandle = new VisualElement
					{
						name = BaseListView.reorderableItemHandleUssClassName
					};
					this.m_DragHandle.AddToClassList(BaseListView.reorderableItemHandleUssClassName);
					VisualElement visualElement = new VisualElement
					{
						name = BaseListView.reorderableItemHandleBarUssClassName
					};
					visualElement.AddToClassList(BaseListView.reorderableItemHandleBarUssClassName);
					this.m_DragHandle.Add(visualElement);
					VisualElement visualElement2 = new VisualElement
					{
						name = BaseListView.reorderableItemHandleBarUssClassName
					};
					visualElement2.AddToClassList(BaseListView.reorderableItemHandleBarUssClassName);
					this.m_DragHandle.Add(visualElement2);
					this.m_ItemContainer = new VisualElement
					{
						name = BaseListView.reorderableItemContainerUssClassName
					};
					this.m_ItemContainer.AddToClassList(BaseListView.reorderableItemContainerUssClassName);
					this.m_ItemContainer.Add(item);
					this.m_Container.Add(this.m_DragHandle);
					this.m_Container.Add(this.m_ItemContainer);
				}
			}
			else
			{
				bool flag2 = this.m_Container == null;
				if (!flag2)
				{
					this.m_Container.RemoveFromHierarchy();
					this.m_Container = null;
				}
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000C0B8 File Offset: 0x0000A2B8
		public void UpdateDragHandle(bool needsDragHandle)
		{
			if (needsDragHandle)
			{
				bool flag = this.m_DragHandle.parent == null;
				if (flag)
				{
					this.rootElement.Insert(0, this.m_DragHandle);
					this.rootElement.AddToClassList(BaseListView.reorderableItemUssClassName);
				}
			}
			else
			{
				VisualElement dragHandle = this.m_DragHandle;
				bool flag2 = ((dragHandle != null) ? dragHandle.parent : null) != null;
				if (flag2)
				{
					this.m_DragHandle.RemoveFromHierarchy();
					this.rootElement.RemoveFromClassList(BaseListView.reorderableItemUssClassName);
				}
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000C141 File Offset: 0x0000A341
		public override void PreAttachElement()
		{
			base.PreAttachElement();
			this.rootElement.AddToClassList(BaseListView.itemUssClassName);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000C15C File Offset: 0x0000A35C
		public override void DetachElement()
		{
			base.DetachElement();
			this.rootElement.RemoveFromClassList(BaseListView.itemUssClassName);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000C178 File Offset: 0x0000A378
		public override void SetDragGhost(bool dragGhost)
		{
			base.SetDragGhost(dragGhost);
			bool flag = this.m_DragHandle != null;
			if (flag)
			{
				this.m_DragHandle.EnableInClassList("unity-hidden", base.isDragGhost);
			}
		}

		// Token: 0x040000F7 RID: 247
		private VisualElement m_Container;

		// Token: 0x040000F8 RID: 248
		private VisualElement m_DragHandle;

		// Token: 0x040000F9 RID: 249
		private VisualElement m_ItemContainer;
	}
}
