using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200024B RID: 587
	internal class NavigateFocusRing : IFocusRing
	{
		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x0003C796 File Offset: 0x0003A996
		private FocusController focusController
		{
			get
			{
				return this.m_Root.focusController;
			}
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0003C7A3 File Offset: 0x0003A9A3
		public NavigateFocusRing(VisualElement root)
		{
			this.m_Root = root;
			this.m_Ring = new VisualElementFocusRing(root, VisualElementFocusRing.DefaultFocusOrder.ChildOrder);
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0003C7C4 File Offset: 0x0003A9C4
		public FocusChangeDirection GetFocusChangeDirection(Focusable currentFocusable, EventBase e)
		{
			bool flag = e.eventTypeId == EventBase<PointerDownEvent>.TypeId();
			if (flag)
			{
				Focusable target;
				bool focusableParentForPointerEvent = this.focusController.GetFocusableParentForPointerEvent(e.target as Focusable, out target);
				if (focusableParentForPointerEvent)
				{
					return VisualElementFocusChangeTarget.GetPooled(target);
				}
			}
			bool flag2 = e.eventTypeId == EventBase<NavigationMoveEvent>.TypeId();
			if (flag2)
			{
				switch (((NavigationMoveEvent)e).direction)
				{
				case NavigationMoveEvent.Direction.Left:
					return NavigateFocusRing.Left;
				case NavigationMoveEvent.Direction.Up:
					return NavigateFocusRing.Up;
				case NavigationMoveEvent.Direction.Right:
					return NavigateFocusRing.Right;
				case NavigationMoveEvent.Direction.Down:
					return NavigateFocusRing.Down;
				case NavigationMoveEvent.Direction.Next:
					return NavigateFocusRing.Next;
				case NavigationMoveEvent.Direction.Previous:
					return NavigateFocusRing.Previous;
				}
			}
			return FocusChangeDirection.none;
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0003C890 File Offset: 0x0003AA90
		public virtual Focusable GetNextFocusable(Focusable currentFocusable, FocusChangeDirection direction)
		{
			bool flag = direction == NavigateFocusRing.Up || direction == NavigateFocusRing.Down || direction == NavigateFocusRing.Right || direction == NavigateFocusRing.Left;
			Focusable result;
			if (flag)
			{
				result = this.GetNextFocusable2D(currentFocusable, (NavigateFocusRing.ChangeDirection)direction);
			}
			else
			{
				result = this.m_Ring.GetNextFocusable(currentFocusable, direction);
			}
			return result;
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0003C8E8 File Offset: 0x0003AAE8
		private Focusable GetNextFocusable2D(Focusable currentFocusable, NavigateFocusRing.ChangeDirection direction)
		{
			VisualElement visualElement = currentFocusable as VisualElement;
			bool flag = visualElement == null;
			if (flag)
			{
				visualElement = this.m_Root;
			}
			Rect worldBoundingBox = this.m_Root.worldBoundingBox;
			Rect rect = new Rect(worldBoundingBox.position - Vector2.one, worldBoundingBox.size + Vector2.one * 2f);
			Rect worldBound = visualElement.worldBound;
			Rect validRect = new Rect(worldBound.position - Vector2.one, worldBound.size + Vector2.one * 2f);
			bool flag2 = direction == NavigateFocusRing.Up;
			if (flag2)
			{
				validRect.yMin = rect.yMin;
			}
			else
			{
				bool flag3 = direction == NavigateFocusRing.Down;
				if (flag3)
				{
					validRect.yMax = rect.yMax;
				}
				else
				{
					bool flag4 = direction == NavigateFocusRing.Left;
					if (flag4)
					{
						validRect.xMin = rect.xMin;
					}
					else
					{
						bool flag5 = direction == NavigateFocusRing.Right;
						if (flag5)
						{
							validRect.xMax = rect.xMax;
						}
					}
				}
			}
			NavigateFocusRing.FocusableHierarchyTraversal focusableHierarchyTraversal = default(NavigateFocusRing.FocusableHierarchyTraversal);
			focusableHierarchyTraversal.currentFocusable = visualElement;
			focusableHierarchyTraversal.direction = direction;
			focusableHierarchyTraversal.validRect = validRect;
			focusableHierarchyTraversal.firstPass = true;
			Focusable bestOverall = focusableHierarchyTraversal.GetBestOverall(this.m_Root, null);
			bool flag6 = bestOverall != null;
			Focusable result;
			if (flag6)
			{
				result = bestOverall;
			}
			else
			{
				validRect = new Rect(worldBound.position - Vector2.one, worldBound.size + Vector2.one * 2f);
				bool flag7 = direction == NavigateFocusRing.Down;
				if (flag7)
				{
					validRect.yMin = rect.yMin;
				}
				else
				{
					bool flag8 = direction == NavigateFocusRing.Up;
					if (flag8)
					{
						validRect.yMax = rect.yMax;
					}
					else
					{
						bool flag9 = direction == NavigateFocusRing.Right;
						if (flag9)
						{
							validRect.xMin = rect.xMin;
						}
						else
						{
							bool flag10 = direction == NavigateFocusRing.Left;
							if (flag10)
							{
								validRect.xMax = rect.xMax;
							}
						}
					}
				}
				focusableHierarchyTraversal = default(NavigateFocusRing.FocusableHierarchyTraversal);
				focusableHierarchyTraversal.currentFocusable = visualElement;
				focusableHierarchyTraversal.direction = direction;
				focusableHierarchyTraversal.validRect = validRect;
				focusableHierarchyTraversal.firstPass = false;
				bestOverall = focusableHierarchyTraversal.GetBestOverall(this.m_Root, null);
				bool flag11 = bestOverall != null;
				if (flag11)
				{
					result = bestOverall;
				}
				else
				{
					result = currentFocusable;
				}
			}
			return result;
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x0003CB50 File Offset: 0x0003AD50
		private static bool IsActive(VisualElement v)
		{
			return v.resolvedStyle.display != DisplayStyle.None && v.enabledInHierarchy;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x0003CB7C File Offset: 0x0003AD7C
		private static bool IsNavigable(Focusable focusable)
		{
			return focusable.canGrabFocus && focusable.tabIndex >= 0 && !focusable.delegatesFocus && !focusable.excludeFromFocusRing;
		}

		// Token: 0x04000756 RID: 1878
		public static readonly NavigateFocusRing.ChangeDirection Left = new NavigateFocusRing.ChangeDirection(1);

		// Token: 0x04000757 RID: 1879
		public static readonly NavigateFocusRing.ChangeDirection Right = new NavigateFocusRing.ChangeDirection(2);

		// Token: 0x04000758 RID: 1880
		public static readonly NavigateFocusRing.ChangeDirection Up = new NavigateFocusRing.ChangeDirection(3);

		// Token: 0x04000759 RID: 1881
		public static readonly NavigateFocusRing.ChangeDirection Down = new NavigateFocusRing.ChangeDirection(4);

		// Token: 0x0400075A RID: 1882
		public static readonly FocusChangeDirection Next = VisualElementFocusChangeDirection.right;

		// Token: 0x0400075B RID: 1883
		public static readonly FocusChangeDirection Previous = VisualElementFocusChangeDirection.left;

		// Token: 0x0400075C RID: 1884
		private readonly VisualElement m_Root;

		// Token: 0x0400075D RID: 1885
		private readonly VisualElementFocusRing m_Ring;

		// Token: 0x0200024C RID: 588
		public class ChangeDirection : FocusChangeDirection
		{
			// Token: 0x060010CA RID: 4298 RVA: 0x0003CC01 File Offset: 0x0003AE01
			public ChangeDirection(int i) : base(i)
			{
			}
		}

		// Token: 0x0200024D RID: 589
		private struct FocusableHierarchyTraversal
		{
			// Token: 0x060010CB RID: 4299 RVA: 0x0003CC0C File Offset: 0x0003AE0C
			private bool ValidateHierarchyTraversal(VisualElement v)
			{
				return NavigateFocusRing.IsActive(v) && v.worldBoundingBox.Overlaps(this.validRect);
			}

			// Token: 0x060010CC RID: 4300 RVA: 0x0003CC40 File Offset: 0x0003AE40
			private bool ValidateElement(VisualElement v)
			{
				return NavigateFocusRing.IsNavigable(v) && v.worldBound.Overlaps(this.validRect);
			}

			// Token: 0x060010CD RID: 4301 RVA: 0x0003CC74 File Offset: 0x0003AE74
			private int Order(VisualElement a, VisualElement b)
			{
				Rect worldBound = a.worldBound;
				Rect worldBound2 = b.worldBound;
				int num = this.StrictOrder(worldBound, worldBound2);
				return (num != 0) ? num : this.TieBreaker(worldBound, worldBound2);
			}

			// Token: 0x060010CE RID: 4302 RVA: 0x0003CCAC File Offset: 0x0003AEAC
			private int StrictOrder(VisualElement a, VisualElement b)
			{
				return this.StrictOrder(a.worldBound, b.worldBound);
			}

			// Token: 0x060010CF RID: 4303 RVA: 0x0003CCD0 File Offset: 0x0003AED0
			private int StrictOrder(Rect ra, Rect rb)
			{
				float num = 0f;
				bool flag = this.direction == NavigateFocusRing.Up;
				if (flag)
				{
					num = rb.yMax - ra.yMax;
				}
				else
				{
					bool flag2 = this.direction == NavigateFocusRing.Down;
					if (flag2)
					{
						num = ra.yMin - rb.yMin;
					}
					else
					{
						bool flag3 = this.direction == NavigateFocusRing.Left;
						if (flag3)
						{
							num = rb.xMax - ra.xMax;
						}
						else
						{
							bool flag4 = this.direction == NavigateFocusRing.Right;
							if (flag4)
							{
								num = ra.xMin - rb.xMin;
							}
						}
					}
				}
				bool flag5 = !Mathf.Approximately(num, 0f);
				int result;
				if (flag5)
				{
					result = ((num > 0f) ? 1 : -1);
				}
				else
				{
					result = 0;
				}
				return result;
			}

			// Token: 0x060010D0 RID: 4304 RVA: 0x0003CD9C File Offset: 0x0003AF9C
			private int TieBreaker(Rect ra, Rect rb)
			{
				Rect worldBound = this.currentFocusable.worldBound;
				float num = (ra.min - worldBound.min).sqrMagnitude - (rb.min - worldBound.min).sqrMagnitude;
				bool flag = !Mathf.Approximately(num, 0f);
				int result;
				if (flag)
				{
					result = ((num > 0f) ? 1 : -1);
				}
				else
				{
					result = 0;
				}
				return result;
			}

			// Token: 0x060010D1 RID: 4305 RVA: 0x0003CE18 File Offset: 0x0003B018
			public VisualElement GetBestOverall(VisualElement candidate, VisualElement bestSoFar = null)
			{
				bool flag = !this.ValidateHierarchyTraversal(candidate);
				VisualElement result;
				if (flag)
				{
					result = bestSoFar;
				}
				else
				{
					bool flag2 = this.ValidateElement(candidate);
					if (flag2)
					{
						bool flag3 = (!this.firstPass || this.StrictOrder(candidate, this.currentFocusable) > 0) && (bestSoFar == null || this.Order(bestSoFar, candidate) > 0);
						if (flag3)
						{
							bestSoFar = candidate;
						}
						result = bestSoFar;
					}
					else
					{
						int childCount = candidate.hierarchy.childCount;
						for (int i = 0; i < childCount; i++)
						{
							VisualElement candidate2 = candidate.hierarchy[i];
							bestSoFar = this.GetBestOverall(candidate2, bestSoFar);
						}
						result = bestSoFar;
					}
				}
				return result;
			}

			// Token: 0x0400075E RID: 1886
			public VisualElement currentFocusable;

			// Token: 0x0400075F RID: 1887
			public Rect validRect;

			// Token: 0x04000760 RID: 1888
			public bool firstPass;

			// Token: 0x04000761 RID: 1889
			public NavigateFocusRing.ChangeDirection direction;
		}
	}
}
