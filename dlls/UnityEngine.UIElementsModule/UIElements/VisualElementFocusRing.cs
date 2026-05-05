using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000405 RID: 1029
	public class VisualElementFocusRing : IFocusRing
	{
		// Token: 0x060020ED RID: 8429 RVA: 0x0007C581 File Offset: 0x0007A781
		public VisualElementFocusRing(VisualElement root, VisualElementFocusRing.DefaultFocusOrder dfo = VisualElementFocusRing.DefaultFocusOrder.ChildOrder)
		{
			this.defaultFocusOrder = dfo;
			this.root = root;
			this.m_FocusRing = new List<VisualElementFocusRing.FocusRingRecord>();
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x060020EE RID: 8430 RVA: 0x0007C5A5 File Offset: 0x0007A7A5
		private FocusController focusController
		{
			get
			{
				return this.root.focusController;
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x060020EF RID: 8431 RVA: 0x0007C5B2 File Offset: 0x0007A7B2
		// (set) Token: 0x060020F0 RID: 8432 RVA: 0x0007C5BA File Offset: 0x0007A7BA
		public VisualElementFocusRing.DefaultFocusOrder defaultFocusOrder { get; set; }

		// Token: 0x060020F1 RID: 8433 RVA: 0x0007C5C4 File Offset: 0x0007A7C4
		private int FocusRingAutoIndexSort(VisualElementFocusRing.FocusRingRecord a, VisualElementFocusRing.FocusRingRecord b)
		{
			int result;
			switch (this.defaultFocusOrder)
			{
			default:
				result = Comparer<int>.Default.Compare(a.m_AutoIndex, b.m_AutoIndex);
				break;
			case VisualElementFocusRing.DefaultFocusOrder.PositionXY:
			{
				VisualElement visualElement = a.m_Focusable as VisualElement;
				VisualElement visualElement2 = b.m_Focusable as VisualElement;
				bool flag = visualElement != null && visualElement2 != null;
				if (flag)
				{
					bool flag2 = visualElement.layout.position.x < visualElement2.layout.position.x;
					if (flag2)
					{
						result = -1;
						break;
					}
					bool flag3 = visualElement.layout.position.x > visualElement2.layout.position.x;
					if (flag3)
					{
						result = 1;
						break;
					}
					bool flag4 = visualElement.layout.position.y < visualElement2.layout.position.y;
					if (flag4)
					{
						result = -1;
						break;
					}
					bool flag5 = visualElement.layout.position.y > visualElement2.layout.position.y;
					if (flag5)
					{
						result = 1;
						break;
					}
				}
				result = Comparer<int>.Default.Compare(a.m_AutoIndex, b.m_AutoIndex);
				break;
			}
			case VisualElementFocusRing.DefaultFocusOrder.PositionYX:
			{
				VisualElement visualElement3 = a.m_Focusable as VisualElement;
				VisualElement visualElement4 = b.m_Focusable as VisualElement;
				bool flag6 = visualElement3 != null && visualElement4 != null;
				if (flag6)
				{
					bool flag7 = visualElement3.layout.position.y < visualElement4.layout.position.y;
					if (flag7)
					{
						result = -1;
						break;
					}
					bool flag8 = visualElement3.layout.position.y > visualElement4.layout.position.y;
					if (flag8)
					{
						result = 1;
						break;
					}
					bool flag9 = visualElement3.layout.position.x < visualElement4.layout.position.x;
					if (flag9)
					{
						result = -1;
						break;
					}
					bool flag10 = visualElement3.layout.position.x > visualElement4.layout.position.x;
					if (flag10)
					{
						result = 1;
						break;
					}
				}
				result = Comparer<int>.Default.Compare(a.m_AutoIndex, b.m_AutoIndex);
				break;
			}
			}
			return result;
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x0007C870 File Offset: 0x0007AA70
		private int FocusRingSort(VisualElementFocusRing.FocusRingRecord a, VisualElementFocusRing.FocusRingRecord b)
		{
			bool flag = a.m_Focusable.tabIndex == 0 && b.m_Focusable.tabIndex == 0;
			int result;
			if (flag)
			{
				result = this.FocusRingAutoIndexSort(a, b);
			}
			else
			{
				bool flag2 = a.m_Focusable.tabIndex == 0;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = b.m_Focusable.tabIndex == 0;
					if (flag3)
					{
						result = -1;
					}
					else
					{
						int num = Comparer<int>.Default.Compare(a.m_Focusable.tabIndex, b.m_Focusable.tabIndex);
						bool flag4 = num == 0;
						if (flag4)
						{
							num = this.FocusRingAutoIndexSort(a, b);
						}
						result = num;
					}
				}
			}
			return result;
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x0007C91C File Offset: 0x0007AB1C
		private void DoUpdate()
		{
			this.m_FocusRing.Clear();
			bool flag = this.root != null;
			if (flag)
			{
				List<VisualElementFocusRing.FocusRingRecord> list = new List<VisualElementFocusRing.FocusRingRecord>();
				int num = 0;
				this.BuildRingForScopeRecursive(this.root, ref num, list);
				this.SortAndFlattenScopeLists(list);
			}
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x0007C968 File Offset: 0x0007AB68
		private void BuildRingForScopeRecursive(VisualElement ve, ref int scopeIndex, List<VisualElementFocusRing.FocusRingRecord> scopeList)
		{
			int childCount = ve.hierarchy.childCount;
			for (int i = 0; i < childCount; i++)
			{
				VisualElement visualElement = ve.hierarchy[i];
				bool flag = visualElement.parent != null && visualElement == visualElement.parent.contentContainer;
				bool flag2 = visualElement.isCompositeRoot || flag;
				if (flag2)
				{
					VisualElementFocusRing.FocusRingRecord focusRingRecord = new VisualElementFocusRing.FocusRingRecord();
					int num = scopeIndex;
					scopeIndex = num + 1;
					focusRingRecord.m_AutoIndex = num;
					focusRingRecord.m_Focusable = visualElement;
					focusRingRecord.m_IsSlot = flag;
					focusRingRecord.m_ScopeNavigationOrder = new List<VisualElementFocusRing.FocusRingRecord>();
					VisualElementFocusRing.FocusRingRecord focusRingRecord2 = focusRingRecord;
					scopeList.Add(focusRingRecord2);
					int num2 = 0;
					this.BuildRingForScopeRecursive(visualElement, ref num2, focusRingRecord2.m_ScopeNavigationOrder);
				}
				else
				{
					bool flag3 = visualElement.canGrabFocus && visualElement.isHierarchyDisplayed && visualElement.tabIndex >= 0;
					if (flag3)
					{
						VisualElementFocusRing.FocusRingRecord focusRingRecord3 = new VisualElementFocusRing.FocusRingRecord();
						int num = scopeIndex;
						scopeIndex = num + 1;
						focusRingRecord3.m_AutoIndex = num;
						focusRingRecord3.m_Focusable = visualElement;
						focusRingRecord3.m_IsSlot = false;
						focusRingRecord3.m_ScopeNavigationOrder = null;
						scopeList.Add(focusRingRecord3);
					}
					this.BuildRingForScopeRecursive(visualElement, ref scopeIndex, scopeList);
				}
			}
		}

		// Token: 0x060020F5 RID: 8437 RVA: 0x0007CA94 File Offset: 0x0007AC94
		private void SortAndFlattenScopeLists(List<VisualElementFocusRing.FocusRingRecord> rootScopeList)
		{
			bool flag = rootScopeList != null;
			if (flag)
			{
				rootScopeList.Sort(new Comparison<VisualElementFocusRing.FocusRingRecord>(this.FocusRingSort));
				foreach (VisualElementFocusRing.FocusRingRecord focusRingRecord in rootScopeList)
				{
					bool flag2 = focusRingRecord.m_Focusable.canGrabFocus && focusRingRecord.m_Focusable.tabIndex >= 0;
					if (flag2)
					{
						bool flag3 = !focusRingRecord.m_Focusable.excludeFromFocusRing;
						if (flag3)
						{
							this.m_FocusRing.Add(focusRingRecord);
						}
						this.SortAndFlattenScopeLists(focusRingRecord.m_ScopeNavigationOrder);
					}
					else
					{
						bool isSlot = focusRingRecord.m_IsSlot;
						if (isSlot)
						{
							this.SortAndFlattenScopeLists(focusRingRecord.m_ScopeNavigationOrder);
						}
					}
					focusRingRecord.m_ScopeNavigationOrder = null;
				}
			}
		}

		// Token: 0x060020F6 RID: 8438 RVA: 0x0007CB84 File Offset: 0x0007AD84
		private int GetFocusableInternalIndex(Focusable f)
		{
			bool flag = f != null;
			if (flag)
			{
				for (int i = 0; i < this.m_FocusRing.Count; i++)
				{
					bool flag2 = f == this.m_FocusRing[i].m_Focusable;
					if (flag2)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x0007CBDC File Offset: 0x0007ADDC
		public FocusChangeDirection GetFocusChangeDirection(Focusable currentFocusable, EventBase e)
		{
			bool flag = e == null;
			if (flag)
			{
				throw new ArgumentNullException("e");
			}
			bool flag2 = e.eventTypeId == EventBase<PointerDownEvent>.TypeId();
			if (flag2)
			{
				Focusable target;
				bool focusableParentForPointerEvent = this.focusController.GetFocusableParentForPointerEvent(e.target as Focusable, out target);
				if (focusableParentForPointerEvent)
				{
					return VisualElementFocusChangeTarget.GetPooled(target);
				}
			}
			bool flag3 = currentFocusable is IMGUIContainer;
			FocusChangeDirection result;
			if (flag3)
			{
				result = FocusChangeDirection.none;
			}
			else
			{
				bool flag4 = e.eventTypeId == EventBase<NavigationMoveEvent>.TypeId();
				if (flag4)
				{
					NavigationMoveEvent.Direction direction = ((NavigationMoveEvent)e).direction;
					result = ((direction == NavigationMoveEvent.Direction.Next) ? VisualElementFocusChangeDirection.right : ((direction == NavigationMoveEvent.Direction.Previous) ? VisualElementFocusChangeDirection.left : FocusChangeDirection.none));
				}
				else
				{
					result = FocusChangeDirection.none;
				}
			}
			return result;
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x0007CCA0 File Offset: 0x0007AEA0
		public Focusable GetNextFocusable(Focusable currentFocusable, FocusChangeDirection direction)
		{
			bool flag = direction == FocusChangeDirection.none || direction == FocusChangeDirection.unspecified;
			Focusable result;
			if (flag)
			{
				result = currentFocusable;
			}
			else
			{
				VisualElementFocusChangeTarget visualElementFocusChangeTarget = direction as VisualElementFocusChangeTarget;
				bool flag2 = visualElementFocusChangeTarget != null;
				if (flag2)
				{
					result = visualElementFocusChangeTarget.target;
				}
				else
				{
					this.DoUpdate();
					bool flag3 = this.m_FocusRing.Count == 0;
					if (flag3)
					{
						result = null;
					}
					else
					{
						int num = 0;
						bool flag4 = direction == VisualElementFocusChangeDirection.right;
						if (flag4)
						{
							num = this.GetFocusableInternalIndex(currentFocusable) + 1;
							bool flag5 = currentFocusable != null && num == 0;
							if (flag5)
							{
								return VisualElementFocusRing.GetNextFocusableInTree(currentFocusable as VisualElement);
							}
							bool flag6 = num == this.m_FocusRing.Count;
							if (flag6)
							{
								num = 0;
							}
							while (this.m_FocusRing[num].m_Focusable.delegatesFocus)
							{
								num++;
								bool flag7 = num == this.m_FocusRing.Count;
								if (flag7)
								{
									return null;
								}
							}
						}
						else
						{
							bool flag8 = direction == VisualElementFocusChangeDirection.left;
							if (flag8)
							{
								num = this.GetFocusableInternalIndex(currentFocusable) - 1;
								bool flag9 = currentFocusable != null && num == -2;
								if (flag9)
								{
									return VisualElementFocusRing.GetPreviousFocusableInTree(currentFocusable as VisualElement);
								}
								bool flag10 = num < 0;
								if (flag10)
								{
									num = this.m_FocusRing.Count - 1;
								}
								while (this.m_FocusRing[num].m_Focusable.delegatesFocus)
								{
									num--;
									bool flag11 = num == -1;
									if (flag11)
									{
										return null;
									}
								}
							}
						}
						result = this.m_FocusRing[num].m_Focusable;
					}
				}
			}
			return result;
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x0007CE48 File Offset: 0x0007B048
		internal static Focusable GetNextFocusableInTree(VisualElement currentFocusable)
		{
			bool flag = currentFocusable == null;
			Focusable result;
			if (flag)
			{
				result = null;
			}
			else
			{
				VisualElement nextElementDepthFirst = currentFocusable.GetNextElementDepthFirst();
				while (!nextElementDepthFirst.canGrabFocus || nextElementDepthFirst.tabIndex < 0 || nextElementDepthFirst.excludeFromFocusRing)
				{
					nextElementDepthFirst = nextElementDepthFirst.GetNextElementDepthFirst();
					bool flag2 = nextElementDepthFirst == null;
					if (flag2)
					{
						nextElementDepthFirst = currentFocusable.GetRoot();
					}
					bool flag3 = nextElementDepthFirst == currentFocusable;
					if (flag3)
					{
						return currentFocusable;
					}
				}
				result = nextElementDepthFirst;
			}
			return result;
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x0007CEBC File Offset: 0x0007B0BC
		internal static Focusable GetPreviousFocusableInTree(VisualElement currentFocusable)
		{
			bool flag = currentFocusable == null;
			Focusable result;
			if (flag)
			{
				result = null;
			}
			else
			{
				VisualElement visualElement = currentFocusable.GetPreviousElementDepthFirst();
				while (!visualElement.canGrabFocus || visualElement.tabIndex < 0 || visualElement.excludeFromFocusRing)
				{
					visualElement = visualElement.GetPreviousElementDepthFirst();
					bool flag2 = visualElement == null;
					if (flag2)
					{
						visualElement = currentFocusable.GetRoot();
						while (visualElement.childCount > 0)
						{
							visualElement = visualElement.hierarchy.ElementAt(visualElement.childCount - 1);
						}
					}
					bool flag3 = visualElement == currentFocusable;
					if (flag3)
					{
						return currentFocusable;
					}
				}
				result = visualElement;
			}
			return result;
		}

		// Token: 0x04000DEC RID: 3564
		private readonly VisualElement root;

		// Token: 0x04000DEE RID: 3566
		private List<VisualElementFocusRing.FocusRingRecord> m_FocusRing;

		// Token: 0x02000406 RID: 1030
		public enum DefaultFocusOrder
		{
			// Token: 0x04000DF0 RID: 3568
			ChildOrder,
			// Token: 0x04000DF1 RID: 3569
			PositionXY,
			// Token: 0x04000DF2 RID: 3570
			PositionYX
		}

		// Token: 0x02000407 RID: 1031
		private class FocusRingRecord
		{
			// Token: 0x04000DF3 RID: 3571
			public int m_AutoIndex;

			// Token: 0x04000DF4 RID: 3572
			public Focusable m_Focusable;

			// Token: 0x04000DF5 RID: 3573
			public bool m_IsSlot;

			// Token: 0x04000DF6 RID: 3574
			public List<VisualElementFocusRing.FocusRingRecord> m_ScopeNavigationOrder;
		}
	}
}
