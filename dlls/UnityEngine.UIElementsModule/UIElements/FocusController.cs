using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000248 RID: 584
	public class FocusController
	{
		// Token: 0x06001098 RID: 4248 RVA: 0x0003BE63 File Offset: 0x0003A063
		public FocusController(IFocusRing focusRing)
		{
			this.focusRing = focusRing;
			this.imguiKeyboardControl = 0;
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06001099 RID: 4249 RVA: 0x0003BE8E File Offset: 0x0003A08E
		private IFocusRing focusRing { get; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x0600109A RID: 4250 RVA: 0x0003BE96 File Offset: 0x0003A096
		// (set) Token: 0x0600109B RID: 4251 RVA: 0x0003BEA0 File Offset: 0x0003A0A0
		internal TextElement selectedTextElement
		{
			get
			{
				return this.m_SelectedTextElement;
			}
			set
			{
				bool flag = this.m_SelectedTextElement == value;
				if (!flag)
				{
					TextElement selectedTextElement = this.m_SelectedTextElement;
					if (selectedTextElement != null)
					{
						selectedTextElement.selection.SelectNone();
					}
					this.m_SelectedTextElement = value;
				}
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x0600109C RID: 4252 RVA: 0x0003BEDC File Offset: 0x0003A0DC
		public Focusable focusedElement
		{
			get
			{
				Focusable retargetedFocusedElement = this.GetRetargetedFocusedElement(null);
				return this.IsLocalElement(retargetedFocusedElement) ? retargetedFocusedElement : null;
			}
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x0003BF04 File Offset: 0x0003A104
		internal bool IsFocused(Focusable f)
		{
			bool flag = !this.IsLocalElement(f);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				foreach (FocusController.FocusedElement focusedElement in this.m_FocusedElements)
				{
					bool flag2 = focusedElement.m_FocusedElement == f;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x0003BF80 File Offset: 0x0003A180
		internal Focusable GetRetargetedFocusedElement(VisualElement retargetAgainst)
		{
			VisualElement visualElement = (retargetAgainst != null) ? retargetAgainst.hierarchy.parent : null;
			bool flag = visualElement == null;
			if (flag)
			{
				bool flag2 = this.m_FocusedElements.Count > 0;
				if (flag2)
				{
					return this.m_FocusedElements[this.m_FocusedElements.Count - 1].m_FocusedElement;
				}
			}
			else
			{
				while (!visualElement.isCompositeRoot && visualElement.hierarchy.parent != null)
				{
					visualElement = visualElement.hierarchy.parent;
				}
				foreach (FocusController.FocusedElement focusedElement in this.m_FocusedElements)
				{
					bool flag3 = focusedElement.m_SubTreeRoot == visualElement;
					if (flag3)
					{
						return focusedElement.m_FocusedElement;
					}
				}
			}
			return null;
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x0003C088 File Offset: 0x0003A288
		internal Focusable GetLeafFocusedElement()
		{
			bool flag = this.m_FocusedElements.Count > 0;
			Focusable result;
			if (flag)
			{
				Focusable focusedElement = this.m_FocusedElements[0].m_FocusedElement;
				result = (this.IsLocalElement(focusedElement) ? focusedElement : null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x0003C0D0 File Offset: 0x0003A2D0
		private bool IsLocalElement(Focusable f)
		{
			return ((f != null) ? f.focusController : null) == this;
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x0003C0F1 File Offset: 0x0003A2F1
		internal void ClearPendingFocusEvents()
		{
			this.m_PendingFocusCount = 0;
			this.m_LastPendingFocusedElement = null;
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x0003C104 File Offset: 0x0003A304
		internal bool IsPendingFocus(Focusable f)
		{
			for (VisualElement visualElement = this.m_LastPendingFocusedElement as VisualElement; visualElement != null; visualElement = visualElement.hierarchy.parent)
			{
				bool flag = f == visualElement;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x0003C14C File Offset: 0x0003A34C
		internal void SetFocusToLastFocusedElement()
		{
			bool flag = this.m_LastFocusedElement != null && !(this.m_LastFocusedElement is IMGUIContainer);
			if (flag)
			{
				this.m_LastFocusedElement.Focus();
			}
		}

		// Token: 0x060010A4 RID: 4260 RVA: 0x0003C188 File Offset: 0x0003A388
		internal void BlurLastFocusedElement()
		{
			this.selectedTextElement = null;
			bool flag = this.m_LastFocusedElement != null && !(this.m_LastFocusedElement is IMGUIContainer);
			if (flag)
			{
				Focusable lastFocusedElement = this.m_LastFocusedElement;
				this.m_LastFocusedElement.Blur();
				this.m_LastFocusedElement = lastFocusedElement;
			}
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x0003C1DC File Offset: 0x0003A3DC
		internal void DoFocusChange(Focusable f)
		{
			this.m_FocusedElements.Clear();
			for (VisualElement visualElement = f as VisualElement; visualElement != null; visualElement = visualElement.hierarchy.parent)
			{
				bool flag = visualElement.hierarchy.parent == null || visualElement.isCompositeRoot;
				if (flag)
				{
					this.m_FocusedElements.Add(new FocusController.FocusedElement
					{
						m_SubTreeRoot = visualElement,
						m_FocusedElement = f
					});
					f = visualElement;
				}
			}
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x0003C264 File Offset: 0x0003A464
		internal void ProcessPendingFocusChange(Focusable f)
		{
			this.m_PendingFocusCount--;
			bool flag = this.m_PendingFocusCount == 0;
			if (flag)
			{
				this.m_LastPendingFocusedElement = null;
			}
			this.DoFocusChange(f);
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x0003C29C File Offset: 0x0003A49C
		internal Focusable FocusNextInDirection(FocusChangeDirection direction)
		{
			Focusable nextFocusable = this.focusRing.GetNextFocusable(this.GetLeafFocusedElement(), direction);
			direction.ApplyTo(this, nextFocusable);
			return nextFocusable;
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x0003C2CC File Offset: 0x0003A4CC
		private void AboutToReleaseFocus(Focusable focusable, Focusable willGiveFocusTo, FocusChangeDirection direction, DispatchMode dispatchMode)
		{
			using (FocusOutEvent pooled = FocusEventBase<FocusOutEvent>.GetPooled(focusable, willGiveFocusTo, direction, this, false))
			{
				focusable.SendEvent(pooled, dispatchMode);
			}
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x0003C310 File Offset: 0x0003A510
		private void ReleaseFocus(Focusable focusable, Focusable willGiveFocusTo, FocusChangeDirection direction, DispatchMode dispatchMode)
		{
			using (BlurEvent pooled = FocusEventBase<BlurEvent>.GetPooled(focusable, willGiveFocusTo, direction, this, false))
			{
				focusable.SendEvent(pooled, dispatchMode);
			}
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0003C354 File Offset: 0x0003A554
		private void AboutToGrabFocus(Focusable focusable, Focusable willTakeFocusFrom, FocusChangeDirection direction, DispatchMode dispatchMode)
		{
			using (FocusInEvent pooled = FocusEventBase<FocusInEvent>.GetPooled(focusable, willTakeFocusFrom, direction, this, false))
			{
				focusable.SendEvent(pooled, dispatchMode);
			}
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0003C398 File Offset: 0x0003A598
		private void GrabFocus(Focusable focusable, Focusable willTakeFocusFrom, FocusChangeDirection direction, bool bIsFocusDelegated, DispatchMode dispatchMode)
		{
			using (FocusEvent pooled = FocusEventBase<FocusEvent>.GetPooled(focusable, willTakeFocusFrom, direction, this, bIsFocusDelegated))
			{
				focusable.SendEvent(pooled, dispatchMode);
			}
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x0003C3DC File Offset: 0x0003A5DC
		internal void Blur(Focusable focusable, bool bIsFocusDelegated = false, DispatchMode dispatchMode = DispatchMode.Default)
		{
			bool flag = (this.m_PendingFocusCount > 0) ? this.IsPendingFocus(focusable) : this.IsFocused(focusable);
			bool flag2 = flag;
			if (flag2)
			{
				this.SwitchFocus(null, bIsFocusDelegated, dispatchMode);
			}
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x0003C415 File Offset: 0x0003A615
		internal void SwitchFocus(Focusable newFocusedElement, bool bIsFocusDelegated = false, DispatchMode dispatchMode = DispatchMode.Default)
		{
			this.SwitchFocus(newFocusedElement, FocusChangeDirection.unspecified, bIsFocusDelegated, dispatchMode);
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0003C428 File Offset: 0x0003A628
		internal void SwitchFocus(Focusable newFocusedElement, FocusChangeDirection direction, bool bIsFocusDelegated = false, DispatchMode dispatchMode = DispatchMode.Default)
		{
			this.m_LastFocusedElement = newFocusedElement;
			Focusable focusable = (this.m_PendingFocusCount > 0) ? this.m_LastPendingFocusedElement : this.GetLeafFocusedElement();
			bool flag = focusable == newFocusedElement;
			if (!flag)
			{
				bool flag2 = newFocusedElement == null || !newFocusedElement.canGrabFocus;
				if (flag2)
				{
					bool flag3 = focusable != null;
					if (flag3)
					{
						this.m_LastPendingFocusedElement = null;
						this.m_PendingFocusCount++;
						this.AboutToReleaseFocus(focusable, null, direction, dispatchMode);
						this.ReleaseFocus(focusable, null, direction, dispatchMode);
					}
				}
				else
				{
					bool flag4 = newFocusedElement != focusable;
					if (flag4)
					{
						VisualElement visualElement = newFocusedElement as VisualElement;
						Focusable willGiveFocusTo = ((visualElement != null) ? visualElement.RetargetElement(focusable as VisualElement) : null) ?? newFocusedElement;
						VisualElement visualElement2 = focusable as VisualElement;
						Focusable willTakeFocusFrom = ((visualElement2 != null) ? visualElement2.RetargetElement(newFocusedElement as VisualElement) : null) ?? focusable;
						this.m_LastPendingFocusedElement = newFocusedElement;
						this.m_PendingFocusCount++;
						bool flag5 = focusable != null;
						if (flag5)
						{
							this.AboutToReleaseFocus(focusable, willGiveFocusTo, direction, dispatchMode);
						}
						this.AboutToGrabFocus(newFocusedElement, willTakeFocusFrom, direction, dispatchMode);
						bool flag6 = focusable != null;
						if (flag6)
						{
							this.ReleaseFocus(focusable, willGiveFocusTo, direction, dispatchMode);
						}
						this.GrabFocus(newFocusedElement, willTakeFocusFrom, direction, bIsFocusDelegated, dispatchMode);
					}
				}
			}
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0003C568 File Offset: 0x0003A768
		internal void SwitchFocusOnEvent(EventBase e)
		{
			bool processedByFocusController = e.processedByFocusController;
			if (!processedByFocusController)
			{
				using (FocusChangeDirection focusChangeDirection = this.focusRing.GetFocusChangeDirection(this.GetLeafFocusedElement(), e))
				{
					bool flag = focusChangeDirection != FocusChangeDirection.none;
					if (flag)
					{
						this.FocusNextInDirection(focusChangeDirection);
						e.processedByFocusController = true;
					}
				}
			}
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x0003C5D8 File Offset: 0x0003A7D8
		internal void ReevaluateFocus()
		{
			VisualElement visualElement = this.focusedElement as VisualElement;
			bool flag = visualElement != null;
			if (flag)
			{
				bool flag2 = !visualElement.isHierarchyDisplayed || !visualElement.visible;
				if (flag2)
				{
					visualElement.Blur();
				}
			}
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x0003C61C File Offset: 0x0003A81C
		internal bool GetFocusableParentForPointerEvent(Focusable target, out Focusable effectiveTarget)
		{
			bool flag = target == null || !target.focusable;
			bool result;
			if (flag)
			{
				effectiveTarget = target;
				result = (target != null);
			}
			else
			{
				effectiveTarget = target;
				for (;;)
				{
					VisualElement visualElement = effectiveTarget as VisualElement;
					bool flag2 = visualElement != null && (!visualElement.enabledInHierarchy || !visualElement.focusable) && visualElement.hierarchy.parent != null;
					if (!flag2)
					{
						break;
					}
					effectiveTarget = visualElement.hierarchy.parent;
				}
				result = !this.IsFocused(effectiveTarget);
			}
			return result;
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060010B2 RID: 4274 RVA: 0x0003C6A3 File Offset: 0x0003A8A3
		// (set) Token: 0x060010B3 RID: 4275 RVA: 0x0003C6AB File Offset: 0x0003A8AB
		internal int imguiKeyboardControl { get; set; }

		// Token: 0x060010B4 RID: 4276 RVA: 0x0003C6B4 File Offset: 0x0003A8B4
		internal void SyncIMGUIFocus(int imguiKeyboardControlID, Focusable imguiContainerHavingKeyboardControl, bool forceSwitch)
		{
			this.imguiKeyboardControl = imguiKeyboardControlID;
			bool flag = forceSwitch || this.imguiKeyboardControl != 0;
			if (flag)
			{
				this.SwitchFocus(imguiContainerHavingKeyboardControl, FocusChangeDirection.unspecified, false, DispatchMode.Default);
			}
			else
			{
				this.SwitchFocus(null, FocusChangeDirection.unspecified, false, DispatchMode.Default);
			}
		}

		// Token: 0x04000749 RID: 1865
		private TextElement m_SelectedTextElement;

		// Token: 0x0400074A RID: 1866
		private List<FocusController.FocusedElement> m_FocusedElements = new List<FocusController.FocusedElement>();

		// Token: 0x0400074B RID: 1867
		private Focusable m_LastFocusedElement;

		// Token: 0x0400074C RID: 1868
		internal Focusable m_LastPendingFocusedElement;

		// Token: 0x0400074D RID: 1869
		private int m_PendingFocusCount = 0;

		// Token: 0x02000249 RID: 585
		private struct FocusedElement
		{
			// Token: 0x0400074F RID: 1871
			public VisualElement m_SubTreeRoot;

			// Token: 0x04000750 RID: 1872
			public Focusable m_FocusedElement;
		}
	}
}
