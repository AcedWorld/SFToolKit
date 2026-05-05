using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004C8 RID: 1224
	internal class ColumnResizer : PointerManipulator
	{
		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x0600264A RID: 9802 RVA: 0x000A044D File Offset: 0x0009E64D
		// (set) Token: 0x0600264B RID: 9803 RVA: 0x000A0455 File Offset: 0x0009E655
		public ColumnLayout columnLayout { get; set; }

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x0600264C RID: 9804 RVA: 0x000A045E File Offset: 0x0009E65E
		// (set) Token: 0x0600264D RID: 9805 RVA: 0x000A0466 File Offset: 0x0009E666
		public bool preview { get; set; }

		// Token: 0x0600264E RID: 9806 RVA: 0x000A0470 File Offset: 0x0009E670
		public ColumnResizer(Column column)
		{
			this.m_Column = column;
			base.activators.Add(new ManipulatorActivationFilter
			{
				button = MouseButton.LeftMouse
			});
			this.m_Active = false;
		}

		// Token: 0x0600264F RID: 9807 RVA: 0x000A04B4 File Offset: 0x0009E6B4
		protected override void RegisterCallbacksOnTarget()
		{
			base.target.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDown), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMove), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUp), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06002650 RID: 9808 RVA: 0x000A0528 File Offset: 0x0009E728
		protected override void UnregisterCallbacksFromTarget()
		{
			base.target.UnregisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDown), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMove), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUp), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06002651 RID: 9809 RVA: 0x000A059C File Offset: 0x0009E79C
		private void OnKeyDown(KeyDownEvent e)
		{
			bool flag = e.keyCode == KeyCode.Escape && this.m_Resizing && this.preview;
			if (flag)
			{
				this.EndDragResize(0f, true);
			}
		}

		// Token: 0x06002652 RID: 9810 RVA: 0x000A05D8 File Offset: 0x0009E7D8
		private void OnPointerDown(PointerDownEvent e)
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
					VisualElement visualElement = e.currentTarget as VisualElement;
					this.m_Header = visualElement.GetFirstAncestorOfType<MultiColumnCollectionHeader>();
					this.preview = this.m_Column.collection.resizePreview;
					bool preview = this.preview;
					if (preview)
					{
						bool flag2 = this.m_PreviewElement == null;
						if (flag2)
						{
							this.m_PreviewElement = new MultiColumnHeaderColumnResizePreview();
						}
						ScrollView firstAncestorOfType = this.m_Header.GetFirstAncestorOfType<ScrollView>();
						VisualElement visualElement2 = ((firstAncestorOfType != null) ? firstAncestorOfType.parent : null) ?? this.m_Header.parent;
						visualElement2.hierarchy.Add(this.m_PreviewElement);
					}
					this.columnLayout = this.m_Header.columnLayout;
					this.m_Start = visualElement.ChangeCoordinatesTo(this.m_Header, e.localPosition);
					this.BeginDragResize(this.m_Start.x);
					this.m_Active = true;
					base.target.CaptureMouse();
					e.StopPropagation();
				}
			}
		}

		// Token: 0x06002653 RID: 9811 RVA: 0x000A06FC File Offset: 0x0009E8FC
		private void OnPointerMove(PointerMoveEvent e)
		{
			bool flag = !this.m_Active || !base.target.HasPointerCapture(e.pointerId);
			if (!flag)
			{
				VisualElement src = e.currentTarget as VisualElement;
				Vector2 vector = src.ChangeCoordinatesTo(this.m_Header, e.localPosition);
				this.DragResize(vector.x);
				e.StopPropagation();
			}
		}

		// Token: 0x06002654 RID: 9812 RVA: 0x000A0768 File Offset: 0x0009E968
		private void OnPointerUp(PointerUpEvent e)
		{
			bool flag = !this.m_Active || !base.target.HasPointerCapture(e.pointerId) || !base.CanStopManipulation(e);
			if (!flag)
			{
				VisualElement src = e.currentTarget as VisualElement;
				Vector2 vector = src.ChangeCoordinatesTo(this.m_Header, e.localPosition);
				this.EndDragResize(vector.x, false);
				this.m_Active = false;
				base.target.ReleasePointer(e.pointerId);
				e.StopPropagation();
			}
		}

		// Token: 0x06002655 RID: 9813 RVA: 0x000A07F8 File Offset: 0x0009E9F8
		private void BeginDragResize(float pos)
		{
			this.m_Resizing = true;
			ColumnLayout columnLayout = this.columnLayout;
			if (columnLayout != null)
			{
				columnLayout.BeginDragResize(this.m_Column, this.m_Start.x, this.preview);
			}
			bool preview = this.preview;
			if (preview)
			{
				this.UpdatePreviewPosition();
			}
		}

		// Token: 0x06002656 RID: 9814 RVA: 0x000A084C File Offset: 0x0009EA4C
		private void DragResize(float pos)
		{
			bool flag = !this.m_Resizing;
			if (!flag)
			{
				ColumnLayout columnLayout = this.columnLayout;
				if (columnLayout != null)
				{
					columnLayout.DragResize(this.m_Column, pos);
				}
				bool preview = this.preview;
				if (preview)
				{
					this.UpdatePreviewPosition();
				}
			}
		}

		// Token: 0x06002657 RID: 9815 RVA: 0x000A0895 File Offset: 0x0009EA95
		private void UpdatePreviewPosition()
		{
			this.m_PreviewElement.style.left = this.columnLayout.GetDesiredPosition(this.m_Column) + this.columnLayout.GetDesiredWidth(this.m_Column);
		}

		// Token: 0x06002658 RID: 9816 RVA: 0x000A08D4 File Offset: 0x0009EAD4
		private void EndDragResize(float pos, bool cancelled)
		{
			bool flag = !this.m_Resizing;
			if (!flag)
			{
				bool preview = this.preview;
				if (preview)
				{
					VisualElement previewElement = this.m_PreviewElement;
					if (previewElement != null)
					{
						previewElement.RemoveFromHierarchy();
					}
					this.m_PreviewElement = null;
				}
				ColumnLayout columnLayout = this.columnLayout;
				if (columnLayout != null)
				{
					columnLayout.EndDragResize(this.m_Column, cancelled);
				}
				this.m_Resizing = false;
			}
		}

		// Token: 0x04001264 RID: 4708
		private Vector2 m_Start;

		// Token: 0x04001265 RID: 4709
		protected bool m_Active;

		// Token: 0x04001266 RID: 4710
		private bool m_Resizing;

		// Token: 0x04001267 RID: 4711
		private MultiColumnCollectionHeader m_Header;

		// Token: 0x04001268 RID: 4712
		private Column m_Column;

		// Token: 0x04001269 RID: 4713
		private VisualElement m_PreviewElement;
	}
}
