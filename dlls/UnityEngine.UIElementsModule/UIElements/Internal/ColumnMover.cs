using System;
using System.Diagnostics;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004C6 RID: 1222
	internal class ColumnMover : PointerManipulator
	{
		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x06002627 RID: 9767 RVA: 0x0009F775 File Offset: 0x0009D975
		// (set) Token: 0x06002628 RID: 9768 RVA: 0x0009F77D File Offset: 0x0009D97D
		public ColumnLayout columnLayout { get; set; }

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06002629 RID: 9769 RVA: 0x0009F786 File Offset: 0x0009D986
		// (set) Token: 0x0600262A RID: 9770 RVA: 0x0009F790 File Offset: 0x0009D990
		public bool active
		{
			get
			{
				return this.m_Active;
			}
			set
			{
				bool flag = this.m_Active == value;
				if (!flag)
				{
					this.m_Active = value;
					Action<ColumnMover> action = this.activeChanged;
					if (action != null)
					{
						action(this);
					}
				}
			}
		}

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x0600262B RID: 9771 RVA: 0x0009F7C7 File Offset: 0x0009D9C7
		// (set) Token: 0x0600262C RID: 9772 RVA: 0x0009F7D0 File Offset: 0x0009D9D0
		public bool moving
		{
			get
			{
				return this.m_Moving;
			}
			set
			{
				bool flag = this.m_Moving == value;
				if (!flag)
				{
					this.m_Moving = value;
					Action<ColumnMover> action = this.movingChanged;
					if (action != null)
					{
						action(this);
					}
				}
			}
		}

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x0600262D RID: 9773 RVA: 0x0009F808 File Offset: 0x0009DA08
		// (remove) Token: 0x0600262E RID: 9774 RVA: 0x0009F840 File Offset: 0x0009DA40
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<ColumnMover> activeChanged;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x0600262F RID: 9775 RVA: 0x0009F878 File Offset: 0x0009DA78
		// (remove) Token: 0x06002630 RID: 9776 RVA: 0x0009F8B0 File Offset: 0x0009DAB0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<ColumnMover> movingChanged;

		// Token: 0x06002631 RID: 9777 RVA: 0x0009F8E8 File Offset: 0x0009DAE8
		public ColumnMover()
		{
			base.activators.Add(new ManipulatorActivationFilter
			{
				button = MouseButton.LeftMouse
			});
		}

		// Token: 0x06002632 RID: 9778 RVA: 0x0009F91C File Offset: 0x0009DB1C
		protected override void RegisterCallbacksOnTarget()
		{
			base.target.RegisterCallback<MouseDownEvent>(new EventCallback<MouseDownEvent>(this.OnMouseDown), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<MouseMoveEvent>(new EventCallback<MouseMoveEvent>(this.OnMouseMove), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<MouseUpEvent>(new EventCallback<MouseUpEvent>(this.OnMouseUp), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<MouseCaptureOutEvent>(new EventCallback<MouseCaptureOutEvent>(this.OnMouseCaptureOut), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDown), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMove), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUp), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerCancelEvent>(new EventCallback<PointerCancelEvent>(this.OnPointerCancel), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerCaptureOutEvent>(new EventCallback<PointerCaptureOutEvent>(this.OnPointerCaptureOut), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06002633 RID: 9779 RVA: 0x0009FA24 File Offset: 0x0009DC24
		protected override void UnregisterCallbacksFromTarget()
		{
			base.target.UnregisterCallback<MouseDownEvent>(new EventCallback<MouseDownEvent>(this.OnMouseDown), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<MouseMoveEvent>(new EventCallback<MouseMoveEvent>(this.OnMouseMove), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<MouseUpEvent>(new EventCallback<MouseUpEvent>(this.OnMouseUp), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<MouseCaptureOutEvent>(new EventCallback<MouseCaptureOutEvent>(this.OnMouseCaptureOut), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDown), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMove), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUp), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerCancelEvent>(new EventCallback<PointerCancelEvent>(this.OnPointerCancel), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerCaptureOutEvent>(new EventCallback<PointerCaptureOutEvent>(this.OnPointerCaptureOut), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06002634 RID: 9780 RVA: 0x0009FB2C File Offset: 0x0009DD2C
		protected void OnMouseDown(MouseDownEvent evt)
		{
			bool flag = base.CanStartManipulation(evt);
			if (flag)
			{
				this.ProcessDownEvent(evt, evt.localMousePosition, PointerId.mousePointerId);
			}
		}

		// Token: 0x06002635 RID: 9781 RVA: 0x0009FB58 File Offset: 0x0009DD58
		protected void OnMouseMove(MouseMoveEvent evt)
		{
			bool active = this.active;
			if (active)
			{
				this.ProcessMoveEvent(evt, evt.localMousePosition);
			}
		}

		// Token: 0x06002636 RID: 9782 RVA: 0x0009FB80 File Offset: 0x0009DD80
		protected void OnMouseUp(MouseUpEvent evt)
		{
			bool flag = this.active && base.CanStopManipulation(evt);
			if (flag)
			{
				this.ProcessUpEvent(evt, evt.localMousePosition, PointerId.mousePointerId);
			}
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x0009FBB8 File Offset: 0x0009DDB8
		private void OnMouseCaptureOut(MouseCaptureOutEvent evt)
		{
			bool active = this.active;
			if (active)
			{
				this.ProcessCancelEvent(evt, PointerId.mousePointerId);
			}
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x0009FBE0 File Offset: 0x0009DDE0
		private void OnPointerDown(PointerDownEvent evt)
		{
			bool flag = !base.CanStartManipulation(evt);
			if (!flag)
			{
				bool flag2 = evt.pointerId != PointerId.mousePointerId;
				if (flag2)
				{
					this.ProcessDownEvent(evt, evt.localPosition, evt.pointerId);
					base.target.panel.PreventCompatibilityMouseEvents(evt.pointerId);
				}
				else
				{
					evt.StopImmediatePropagation();
				}
			}
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x0009FC50 File Offset: 0x0009DE50
		private void OnPointerMove(PointerMoveEvent evt)
		{
			bool flag = !this.active;
			if (!flag)
			{
				bool flag2 = evt.pointerId != PointerId.mousePointerId;
				if (flag2)
				{
					this.ProcessMoveEvent(evt, evt.localPosition);
					base.target.panel.PreventCompatibilityMouseEvents(evt.pointerId);
				}
				else
				{
					evt.StopPropagation();
				}
			}
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x0009FCB8 File Offset: 0x0009DEB8
		private void OnPointerUp(PointerUpEvent evt)
		{
			bool flag = !this.active || !base.CanStopManipulation(evt);
			if (!flag)
			{
				bool flag2 = evt.pointerId != PointerId.mousePointerId;
				if (flag2)
				{
					this.ProcessUpEvent(evt, evt.localPosition, evt.pointerId);
					base.target.panel.PreventCompatibilityMouseEvents(evt.pointerId);
				}
				else
				{
					evt.StopPropagation();
				}
			}
		}

		// Token: 0x0600263B RID: 9787 RVA: 0x0009FD34 File Offset: 0x0009DF34
		private void OnPointerCancel(PointerCancelEvent evt)
		{
			bool flag = !this.active || !base.CanStopManipulation(evt);
			if (!flag)
			{
				bool flag2 = ColumnMover.IsNotMouseEvent(evt.pointerId);
				if (flag2)
				{
					this.ProcessCancelEvent(evt, evt.pointerId);
				}
			}
		}

		// Token: 0x0600263C RID: 9788 RVA: 0x0009FD7C File Offset: 0x0009DF7C
		private void OnPointerCaptureOut(PointerCaptureOutEvent evt)
		{
			bool flag = !this.active;
			if (!flag)
			{
				bool flag2 = ColumnMover.IsNotMouseEvent(evt.pointerId);
				if (flag2)
				{
					this.ProcessCancelEvent(evt, evt.pointerId);
				}
			}
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x0009FDB8 File Offset: 0x0009DFB8
		private static bool IsNotMouseEvent(int pointerId)
		{
			return pointerId != PointerId.mousePointerId;
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x0009FDD8 File Offset: 0x0009DFD8
		protected void ProcessCancelEvent(EventBase evt, int pointerId)
		{
			this.active = false;
			base.target.ReleasePointer(pointerId);
			bool flag = !(evt is IPointerEvent);
			if (flag)
			{
				base.target.panel.ProcessPointerCapture(pointerId);
			}
			bool moving = this.moving;
			if (moving)
			{
				this.EndDragMove(true);
			}
			evt.StopPropagation();
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x0009FE38 File Offset: 0x0009E038
		private void OnKeyDown(KeyDownEvent e)
		{
			bool flag = e.keyCode == KeyCode.Escape && this.moving;
			if (flag)
			{
				this.EndDragMove(true);
			}
		}

		// Token: 0x06002640 RID: 9792 RVA: 0x0009FE68 File Offset: 0x0009E068
		private void ProcessDownEvent(EventBase evt, Vector2 localPosition, int pointerId)
		{
			bool active = this.active;
			if (active)
			{
				evt.StopImmediatePropagation();
			}
			else
			{
				base.target.CapturePointer(pointerId);
				bool flag = !(evt is IPointerEvent);
				if (flag)
				{
					base.target.panel.ProcessPointerCapture(pointerId);
				}
				VisualElement visualElement = evt.currentTarget as VisualElement;
				MultiColumnCollectionHeader firstAncestorOfType = visualElement.GetFirstAncestorOfType<MultiColumnCollectionHeader>();
				bool flag2 = !firstAncestorOfType.columns.reorderable;
				if (!flag2)
				{
					this.m_Header = firstAncestorOfType;
					Vector2 vector = visualElement.ChangeCoordinatesTo(this.m_Header, localPosition);
					this.columnLayout = this.m_Header.columnLayout;
					this.m_Cancelled = false;
					this.m_StartPos = vector.x;
					this.active = true;
					evt.StopPropagation();
				}
			}
		}

		// Token: 0x06002641 RID: 9793 RVA: 0x0009FF30 File Offset: 0x0009E130
		private void ProcessMoveEvent(EventBase e, Vector2 localPosition)
		{
			bool cancelled = this.m_Cancelled;
			if (!cancelled)
			{
				VisualElement src = e.currentTarget as VisualElement;
				Vector2 vector = src.ChangeCoordinatesTo(this.m_Header, localPosition);
				bool flag = !this.moving && Mathf.Abs(this.m_StartPos - vector.x) > 5f;
				if (flag)
				{
					this.BeginDragMove(this.m_StartPos);
				}
				bool moving = this.moving;
				if (moving)
				{
					this.DragMove(vector.x);
				}
				e.StopPropagation();
			}
		}

		// Token: 0x06002642 RID: 9794 RVA: 0x0009FFC0 File Offset: 0x0009E1C0
		private void ProcessUpEvent(EventBase evt, Vector2 localPosition, int pointerId)
		{
			this.active = false;
			base.target.ReleasePointer(pointerId);
			bool flag = !(evt is IPointerEvent);
			if (flag)
			{
				base.target.panel.ProcessPointerCapture(pointerId);
			}
			bool flag2 = this.moving || this.m_Cancelled;
			this.EndDragMove(false);
			bool flag3 = flag2;
			if (flag3)
			{
				evt.StopImmediatePropagation();
			}
			else
			{
				evt.StopPropagation();
			}
		}

		// Token: 0x06002643 RID: 9795 RVA: 0x000A0034 File Offset: 0x0009E234
		private void BeginDragMove(float pos)
		{
			float num = 0f;
			Columns columns = this.columnLayout.columns;
			foreach (Column column in columns.visibleList)
			{
				num += this.columnLayout.GetDesiredWidth(column);
				bool flag = this.m_ColumnToMove == null;
				if (flag)
				{
					bool flag2 = num > pos;
					if (flag2)
					{
						this.m_ColumnToMove = column;
					}
				}
			}
			this.moving = true;
			this.m_LastPos = pos;
			this.m_PreviewElement = new MultiColumnHeaderColumnMovePreview();
			this.m_LocationPreviewElement = new MultiColumnHeaderColumnMoveLocationPreview();
			this.m_Header.hierarchy.Add(this.m_PreviewElement);
			ScrollView firstAncestorOfType = this.m_Header.GetFirstAncestorOfType<ScrollView>();
			VisualElement visualElement = ((firstAncestorOfType != null) ? firstAncestorOfType.parent : null) ?? this.m_Header;
			visualElement.hierarchy.Add(this.m_LocationPreviewElement);
			this.m_ColumnToMovePos = this.columnLayout.GetDesiredPosition(this.m_ColumnToMove);
			this.m_ColumnToMoveWidth = this.columnLayout.GetDesiredWidth(this.m_ColumnToMove);
			this.UpdateMoveLocation();
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x000A0174 File Offset: 0x0009E374
		internal void DragMove(float pos)
		{
			this.m_LastPos = pos;
			this.UpdateMoveLocation();
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x000A0188 File Offset: 0x0009E388
		private void UpdatePreviewPosition()
		{
			this.m_PreviewElement.style.left = this.m_ColumnToMovePos + this.m_LastPos - this.m_StartPos;
			this.m_PreviewElement.style.width = this.m_ColumnToMoveWidth;
			bool flag = this.m_DestinationColumn != null;
			if (flag)
			{
				this.m_LocationPreviewElement.style.left = this.columnLayout.GetDesiredPosition(this.m_DestinationColumn) + ((!this.m_MoveBeforeDestination) ? this.columnLayout.GetDesiredWidth(this.m_DestinationColumn) : 0f);
			}
		}

		// Token: 0x06002646 RID: 9798 RVA: 0x000A0234 File Offset: 0x0009E434
		private void UpdateMoveLocation()
		{
			float num = 0f;
			this.m_DestinationColumn = null;
			this.m_MoveBeforeDestination = false;
			foreach (Column destinationColumn in this.columnLayout.columns.visibleList)
			{
				this.m_DestinationColumn = destinationColumn;
				float desiredWidth = this.columnLayout.GetDesiredWidth(this.m_DestinationColumn);
				float num2 = num + desiredWidth / 2f;
				num += desiredWidth;
				bool flag = num > this.m_LastPos;
				if (flag)
				{
					this.m_MoveBeforeDestination = (this.m_LastPos < num2);
					break;
				}
			}
			this.UpdatePreviewPosition();
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x000A02F0 File Offset: 0x0009E4F0
		private void EndDragMove(bool cancelled)
		{
			bool flag = !this.moving || this.m_Cancelled;
			if (!flag)
			{
				this.m_Cancelled = cancelled;
				bool flag2 = !cancelled;
				if (flag2)
				{
					int num = this.m_DestinationColumn.displayIndex;
					bool flag3 = !this.m_MoveBeforeDestination;
					if (flag3)
					{
						num++;
					}
					bool flag4 = this.m_ColumnToMove.displayIndex < num;
					if (flag4)
					{
						num--;
					}
					bool flag5 = this.m_ColumnToMove.displayIndex != num;
					if (flag5)
					{
						this.columnLayout.columns.ReorderDisplay(this.m_ColumnToMove.displayIndex, num);
					}
				}
				VisualElement previewElement = this.m_PreviewElement;
				if (previewElement != null)
				{
					previewElement.RemoveFromHierarchy();
				}
				this.m_PreviewElement = null;
				MultiColumnHeaderColumnMoveLocationPreview locationPreviewElement = this.m_LocationPreviewElement;
				if (locationPreviewElement != null)
				{
					locationPreviewElement.RemoveFromHierarchy();
				}
				this.m_LocationPreviewElement = null;
				this.m_ColumnToMove = null;
				this.moving = false;
			}
		}

		// Token: 0x04001251 RID: 4689
		private const float k_StartDragDistance = 5f;

		// Token: 0x04001252 RID: 4690
		private float m_StartPos;

		// Token: 0x04001253 RID: 4691
		private float m_LastPos;

		// Token: 0x04001254 RID: 4692
		private bool m_Active;

		// Token: 0x04001255 RID: 4693
		private bool m_Moving;

		// Token: 0x04001256 RID: 4694
		private bool m_Cancelled;

		// Token: 0x04001257 RID: 4695
		private MultiColumnCollectionHeader m_Header;

		// Token: 0x04001258 RID: 4696
		private VisualElement m_PreviewElement;

		// Token: 0x04001259 RID: 4697
		private MultiColumnHeaderColumnMoveLocationPreview m_LocationPreviewElement;

		// Token: 0x0400125A RID: 4698
		private Column m_ColumnToMove;

		// Token: 0x0400125B RID: 4699
		private float m_ColumnToMovePos;

		// Token: 0x0400125C RID: 4700
		private float m_ColumnToMoveWidth;

		// Token: 0x0400125D RID: 4701
		private Column m_DestinationColumn;

		// Token: 0x0400125E RID: 4702
		private bool m_MoveBeforeDestination;
	}
}
