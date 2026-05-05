using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200004A RID: 74
	internal class FixedHeightVirtualizationController<T> : VerticalVirtualizationController<T> where T : ReusableCollectionItem, new()
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600031F RID: 799 RVA: 0x0000B573 File Offset: 0x00009773
		private float resolvedItemHeight
		{
			get
			{
				return this.m_CollectionView.ResolveItemHeight(-1f);
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000B588 File Offset: 0x00009788
		protected override bool VisibleItemPredicate(T i)
		{
			return true;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000B59B File Offset: 0x0000979B
		public FixedHeightVirtualizationController(BaseVerticalCollectionView collectionView) : base(collectionView)
		{
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000B5A8 File Offset: 0x000097A8
		public override int GetIndexFromPosition(Vector2 position)
		{
			return (int)(position.y / this.resolvedItemHeight);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000B5C8 File Offset: 0x000097C8
		public override float GetExpectedItemHeight(int index)
		{
			return this.resolvedItemHeight;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000B5E0 File Offset: 0x000097E0
		public override float GetExpectedContentHeight()
		{
			return (float)base.itemsCount * this.resolvedItemHeight;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000B600 File Offset: 0x00009800
		public override void ScrollToItem(int index)
		{
			bool flag = this.visibleItemCount == 0 || index < -1;
			if (!flag)
			{
				float resolvedItemHeight = this.resolvedItemHeight;
				bool flag2 = index == -1;
				if (flag2)
				{
					int num = (int)(base.lastHeight / resolvedItemHeight);
					bool flag3 = base.itemsCount < num;
					if (flag3)
					{
						this.m_ScrollView.scrollOffset = new Vector2(0f, 0f);
					}
					else
					{
						this.m_ScrollView.scrollOffset = new Vector2(0f, (float)(base.itemsCount + 1) * resolvedItemHeight);
					}
				}
				else
				{
					bool flag4 = this.firstVisibleIndex >= index;
					if (flag4)
					{
						this.m_ScrollView.scrollOffset = Vector2.up * (resolvedItemHeight * (float)index);
					}
					else
					{
						int num2 = (int)(base.lastHeight / resolvedItemHeight);
						bool flag5 = index < this.firstVisibleIndex + num2;
						if (!flag5)
						{
							int num3 = index - num2 + 1;
							float num4 = resolvedItemHeight - (base.lastHeight - (float)num2 * resolvedItemHeight);
							float y = resolvedItemHeight * (float)num3 + num4;
							this.m_ScrollView.scrollOffset = new Vector2(this.m_ScrollView.scrollOffset.x, y);
						}
					}
				}
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000B72C File Offset: 0x0000992C
		public override void Resize(Vector2 size)
		{
			float resolvedItemHeight = this.resolvedItemHeight;
			float expectedContentHeight = this.GetExpectedContentHeight();
			this.m_ScrollView.contentContainer.style.height = expectedContentHeight;
			float num = Mathf.Max(0f, expectedContentHeight - this.m_ScrollView.contentViewport.layout.height);
			float num2 = Mathf.Min(base.serializedData.scrollOffset.y, num);
			this.m_ScrollView.verticalScroller.slider.SetHighValueWithoutNotify(num);
			this.m_ScrollView.verticalScroller.slider.SetValueWithoutNotify(num2);
			int num3 = (int)(this.m_CollectionView.ResolveItemHeight(size.y) / resolvedItemHeight);
			bool flag = num3 > 0;
			if (flag)
			{
				num3 += 2;
			}
			int num4 = Mathf.Min(num3, base.itemsCount);
			bool flag2 = this.visibleItemCount != num4;
			if (flag2)
			{
				int visibleItemCount = this.visibleItemCount;
				bool flag3 = this.visibleItemCount > num4;
				if (flag3)
				{
					int num5 = visibleItemCount - num4;
					for (int i = 0; i < num5; i++)
					{
						int activeItemsIndex = this.m_ActiveItems.Count - 1;
						this.ReleaseItem(activeItemsIndex);
					}
				}
				else
				{
					int num6 = num4 - this.visibleItemCount;
					for (int j = 0; j < num6; j++)
					{
						int newIndex = j + this.firstVisibleIndex + visibleItemCount;
						T orMakeItemAtIndex = this.GetOrMakeItemAtIndex(-1, -1);
						base.Setup(orMakeItemAtIndex, newIndex);
					}
				}
			}
			this.OnScroll(new Vector2(0f, num2));
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000B8CC File Offset: 0x00009ACC
		public override void OnScroll(Vector2 scrollOffset)
		{
			float num = Mathf.Max(0f, scrollOffset.y);
			float resolvedItemHeight = this.resolvedItemHeight;
			int num2 = (int)(num / resolvedItemHeight);
			this.m_ScrollView.contentContainer.style.paddingTop = (float)num2 * resolvedItemHeight;
			this.m_ScrollView.contentContainer.style.height = (float)base.itemsCount * resolvedItemHeight;
			base.serializedData.scrollOffset.y = scrollOffset.y;
			bool flag = num2 != this.firstVisibleIndex;
			if (flag)
			{
				this.firstVisibleIndex = num2;
				bool flag2 = this.m_ActiveItems.Count > 0;
				if (flag2)
				{
					bool flag3 = this.firstVisibleIndex < this.m_ActiveItems[0].index;
					if (flag3)
					{
						int num3 = this.m_ActiveItems[0].index - this.firstVisibleIndex;
						List<T> scrollInsertionList = this.m_ScrollInsertionList;
						int num4 = 0;
						while (num4 < num3 && this.m_ActiveItems.Count > 0)
						{
							List<T> activeItems = this.m_ActiveItems;
							T t = activeItems[activeItems.Count - 1];
							scrollInsertionList.Add(t);
							this.m_ActiveItems.RemoveAt(this.m_ActiveItems.Count - 1);
							t.rootElement.SendToBack();
							num4++;
						}
						this.m_ActiveItems.InsertRange(0, scrollInsertionList);
						this.m_ScrollInsertionList.Clear();
					}
					else
					{
						int firstVisibleIndex = this.firstVisibleIndex;
						List<T> activeItems2 = this.m_ActiveItems;
						bool flag4 = firstVisibleIndex < activeItems2[activeItems2.Count - 1].index;
						if (flag4)
						{
							List<T> scrollInsertionList2 = this.m_ScrollInsertionList;
							int num5 = 0;
							while (this.firstVisibleIndex > this.m_ActiveItems[num5].index)
							{
								T t2 = this.m_ActiveItems[num5];
								scrollInsertionList2.Add(t2);
								num5++;
								t2.rootElement.BringToFront();
							}
							this.m_ActiveItems.RemoveRange(0, num5);
							this.m_ActiveItems.AddRange(scrollInsertionList2);
							scrollInsertionList2.Clear();
						}
					}
					for (int i = 0; i < this.m_ActiveItems.Count; i++)
					{
						int newIndex = i + this.firstVisibleIndex;
						base.Setup(this.m_ActiveItems[i], newIndex);
					}
				}
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000BB6C File Offset: 0x00009D6C
		internal override T GetOrMakeItemAtIndex(int activeItemIndex = -1, int scrollViewIndex = -1)
		{
			T orMakeItemAtIndex = base.GetOrMakeItemAtIndex(activeItemIndex, scrollViewIndex);
			orMakeItemAtIndex.rootElement.style.height = this.resolvedItemHeight;
			return orMakeItemAtIndex;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000BBAC File Offset: 0x00009DAC
		internal override void EndDrag(int dropIndex)
		{
			this.m_DraggedItem.rootElement.style.height = this.resolvedItemHeight;
			bool flag = this.firstVisibleIndex > this.m_DraggedItem.index;
			if (flag)
			{
				this.m_ScrollView.verticalScroller.value = base.serializedData.scrollOffset.y - this.resolvedItemHeight;
			}
			base.EndDrag(dropIndex);
		}
	}
}
