using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000147 RID: 327
	internal class TwoPaneSplitViewResizer : PointerManipulator
	{
		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x0002B0FB File Offset: 0x000292FB
		private TwoPaneSplitViewOrientation orientation
		{
			get
			{
				return this.m_SplitView.orientation;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x0002B108 File Offset: 0x00029308
		private VisualElement fixedPane
		{
			get
			{
				return this.m_SplitView.fixedPane;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x0002B115 File Offset: 0x00029315
		private VisualElement flexedPane
		{
			get
			{
				return this.m_SplitView.flexedPane;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0002B124 File Offset: 0x00029324
		private float fixedPaneMinDimension
		{
			get
			{
				bool flag = this.orientation == TwoPaneSplitViewOrientation.Horizontal;
				float value;
				if (flag)
				{
					value = this.fixedPane.resolvedStyle.minWidth.value;
				}
				else
				{
					value = this.fixedPane.resolvedStyle.minHeight.value;
				}
				return value;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0002B178 File Offset: 0x00029378
		private float fixedPaneMargins
		{
			get
			{
				bool flag = this.orientation == TwoPaneSplitViewOrientation.Horizontal;
				float result;
				if (flag)
				{
					result = this.fixedPane.resolvedStyle.marginLeft + this.fixedPane.resolvedStyle.marginRight;
				}
				else
				{
					result = this.fixedPane.resolvedStyle.marginTop + this.fixedPane.resolvedStyle.marginBottom;
				}
				return result;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x0002B1DC File Offset: 0x000293DC
		private float flexedPaneMinDimension
		{
			get
			{
				bool flag = this.orientation == TwoPaneSplitViewOrientation.Horizontal;
				float value;
				if (flag)
				{
					value = this.flexedPane.resolvedStyle.minWidth.value;
				}
				else
				{
					value = this.flexedPane.resolvedStyle.minHeight.value;
				}
				return value;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x0002B230 File Offset: 0x00029430
		private float flexedPaneMargin
		{
			get
			{
				bool flag = this.orientation == TwoPaneSplitViewOrientation.Horizontal;
				float result;
				if (flag)
				{
					result = this.flexedPane.resolvedStyle.marginLeft + this.flexedPane.resolvedStyle.marginRight;
				}
				else
				{
					result = this.flexedPane.resolvedStyle.marginTop + this.flexedPane.resolvedStyle.marginBottom;
				}
				return result;
			}
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0002B294 File Offset: 0x00029494
		public TwoPaneSplitViewResizer(TwoPaneSplitView splitView, int dir)
		{
			this.m_SplitView = splitView;
			this.m_Direction = dir;
			base.activators.Add(new ManipulatorActivationFilter
			{
				button = MouseButton.LeftMouse
			});
			this.m_Active = false;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0002B2DC File Offset: 0x000294DC
		protected override void RegisterCallbacksOnTarget()
		{
			base.target.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDown), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMove), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUp), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0002B338 File Offset: 0x00029538
		protected override void UnregisterCallbacksFromTarget()
		{
			base.target.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDown), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMove), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUp), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0002B394 File Offset: 0x00029594
		public void ApplyDelta(float delta)
		{
			float num = (this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? this.fixedPane.resolvedStyle.width : this.fixedPane.resolvedStyle.height;
			float num2 = num + delta;
			float num3 = this.fixedPaneMinDimension;
			bool flag = this.m_SplitView.fixedPaneIndex == 1;
			if (flag)
			{
				num3 += ((this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? (base.target.worldBound.width + Math.Abs(this.m_SplitView.dragLine.resolvedStyle.left)) : (base.target.worldBound.height + Math.Abs(this.m_SplitView.dragLine.resolvedStyle.top)));
			}
			bool flag2 = num2 < num && num2 < num3;
			if (flag2)
			{
				num2 = num3;
			}
			float num4 = (this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? this.m_SplitView.resolvedStyle.width : this.m_SplitView.resolvedStyle.height;
			num4 -= this.flexedPaneMinDimension + this.flexedPaneMargin + this.fixedPaneMargins;
			bool flag3 = this.m_SplitView.fixedPaneIndex == 0;
			if (flag3)
			{
				num4 -= ((this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? Math.Abs(base.target.worldBound.width - (this.m_SplitView.dragLine.resolvedStyle.width - Math.Abs(this.m_SplitView.dragLine.resolvedStyle.left))) : Math.Abs(base.target.worldBound.height - (this.m_SplitView.dragLine.resolvedStyle.height - Math.Abs(this.m_SplitView.dragLine.resolvedStyle.top))));
			}
			bool flag4 = num2 > num && num2 > num4;
			if (flag4)
			{
				num2 = num4;
			}
			bool flag5 = this.orientation == TwoPaneSplitViewOrientation.Horizontal;
			if (flag5)
			{
				this.fixedPane.style.width = num2;
				bool flag6 = this.m_SplitView.fixedPaneIndex == 0;
				if (flag6)
				{
					base.target.style.left = num2 + this.fixedPaneMargins;
				}
				else
				{
					float num5 = this.m_SplitView.resolvedStyle.width - num2 - this.fixedPaneMargins;
					bool flag7 = num5 >= this.flexedPaneMinDimension + this.flexedPaneMargin;
					if (flag7)
					{
						base.target.style.left = num5;
					}
				}
			}
			else
			{
				this.fixedPane.style.height = num2;
				bool flag8 = this.m_SplitView.fixedPaneIndex == 0;
				if (flag8)
				{
					base.target.style.top = num2 + this.fixedPaneMargins;
				}
				else
				{
					float num6 = this.m_SplitView.resolvedStyle.height - num2 - this.fixedPaneMargins;
					bool flag9 = num6 >= this.flexedPaneMinDimension + this.flexedPaneMargin;
					if (flag9)
					{
						base.target.style.top = num6;
					}
				}
			}
			this.m_SplitView.fixedPaneDimension = num2;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0002B6D4 File Offset: 0x000298D4
		protected void OnPointerDown(PointerDownEvent e)
		{
			bool active = this.m_Active;
			if (active)
			{
				e.StopImmediatePropagation();
			}
			else
			{
				bool flag = base.CanStartManipulation(e);
				if (flag)
				{
					this.m_Start = e.localPosition;
					this.m_Active = true;
					base.target.CapturePointer(e.pointerId);
					e.StopPropagation();
				}
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0002B730 File Offset: 0x00029930
		protected void OnPointerMove(PointerMoveEvent e)
		{
			bool flag = !this.m_Active || !base.target.HasPointerCapture(e.pointerId);
			if (!flag)
			{
				bool flag2 = (this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? (this.m_SplitView.dragLine.worldBound.x < base.target.worldBound.x) : (this.m_SplitView.dragLine.worldBound.y < base.target.worldBound.y);
				float num = (this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? Math.Abs(base.target.worldBound.x - this.m_SplitView.dragLine.worldBound.x) : Math.Abs(base.target.worldBound.y - this.m_SplitView.dragLine.worldBound.y);
				float value = (this.orientation == TwoPaneSplitViewOrientation.Horizontal) ? this.m_SplitView.dragLine.resolvedStyle.left : this.m_SplitView.dragLine.resolvedStyle.top;
				bool flag3 = flag2 && Math.Abs(value) + 1f <= num;
				if (flag3)
				{
					this.InterruptPointerMove(e);
				}
				else
				{
					Vector2 vector = e.localPosition - this.m_Start;
					float num2 = vector.x;
					bool flag4 = this.orientation == TwoPaneSplitViewOrientation.Vertical;
					if (flag4)
					{
						num2 = vector.y;
					}
					float delta = (float)this.m_Direction * num2;
					this.ApplyDelta(delta);
					e.StopPropagation();
				}
			}
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0002B8F4 File Offset: 0x00029AF4
		protected void OnPointerUp(PointerUpEvent e)
		{
			bool flag = !this.m_Active || !base.target.HasPointerCapture(e.pointerId) || !base.CanStopManipulation(e);
			if (!flag)
			{
				this.m_Active = false;
				base.target.ReleasePointer(e.pointerId);
				e.StopPropagation();
			}
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0002B950 File Offset: 0x00029B50
		protected void InterruptPointerMove(PointerMoveEvent e)
		{
			bool flag = !base.CanStopManipulation(e);
			if (!flag)
			{
				this.m_Active = false;
				base.target.ReleasePointer(e.pointerId);
				e.StopPropagation();
			}
		}

		// Token: 0x04000527 RID: 1319
		private const float k_DragLineTolerance = 1f;

		// Token: 0x04000528 RID: 1320
		private Vector3 m_Start;

		// Token: 0x04000529 RID: 1321
		protected bool m_Active;

		// Token: 0x0400052A RID: 1322
		private TwoPaneSplitView m_SplitView;

		// Token: 0x0400052B RID: 1323
		private int m_Direction;
	}
}
