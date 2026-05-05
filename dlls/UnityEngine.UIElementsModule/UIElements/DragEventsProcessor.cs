using System;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements
{
	// Token: 0x02000162 RID: 354
	internal abstract class DragEventsProcessor
	{
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x0002DD58 File Offset: 0x0002BF58
		internal bool isRegistered
		{
			get
			{
				return this.m_IsRegistered;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x0002DD60 File Offset: 0x0002BF60
		internal DragEventsProcessor.DragState dragState
		{
			get
			{
				return this.m_DragState;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0000C907 File Offset: 0x0000AB07
		protected virtual bool supportsDragEvents
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0002DD68 File Offset: 0x0002BF68
		private bool useDragEvents
		{
			get
			{
				return this.isEditorContext && this.supportsDragEvents;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0002DD7B File Offset: 0x0002BF7B
		protected IDragAndDrop dragAndDrop
		{
			get
			{
				return DragAndDropUtility.GetDragAndDrop(this.m_Target.panel);
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0002DD90 File Offset: 0x0002BF90
		internal virtual bool isEditorContext
		{
			get
			{
				Assert.IsNotNull<VisualElement>(this.m_Target);
				Assert.IsNotNull<VisualElement>(this.m_Target.parent);
				return this.m_Target.panel.contextType == ContextType.Editor;
			}
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0002DDD4 File Offset: 0x0002BFD4
		internal DragEventsProcessor(VisualElement target)
		{
			this.m_Target = target;
			this.m_Target.RegisterCallback<AttachToPanelEvent>(new EventCallback<AttachToPanelEvent>(this.RegisterCallbacksFromTarget), TrickleDown.NoTrickleDown);
			this.m_Target.RegisterCallback<DetachFromPanelEvent>(new EventCallback<DetachFromPanelEvent>(this.UnregisterCallbacksFromTarget), TrickleDown.NoTrickleDown);
			this.RegisterCallbacksFromTarget();
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0002DE29 File Offset: 0x0002C029
		private void RegisterCallbacksFromTarget(AttachToPanelEvent evt)
		{
			this.RegisterCallbacksFromTarget();
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0002DE34 File Offset: 0x0002C034
		private void RegisterCallbacksFromTarget()
		{
			bool isRegistered = this.m_IsRegistered;
			if (!isRegistered)
			{
				this.m_IsRegistered = true;
				this.m_Target.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDownEvent), TrickleDown.NoTrickleDown);
				this.m_Target.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUpEvent), TrickleDown.TrickleDown);
				this.m_Target.RegisterCallback<PointerLeaveEvent>(new EventCallback<PointerLeaveEvent>(this.OnPointerLeaveEvent), TrickleDown.NoTrickleDown);
				this.m_Target.RegisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMoveEvent), TrickleDown.NoTrickleDown);
				this.m_Target.RegisterCallback<PointerCancelEvent>(new EventCallback<PointerCancelEvent>(this.OnPointerCancelEvent), TrickleDown.NoTrickleDown);
				this.m_Target.RegisterCallback<PointerCaptureOutEvent>(new EventCallback<PointerCaptureOutEvent>(this.OnPointerCapturedOut), TrickleDown.NoTrickleDown);
			}
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0002DEEE File Offset: 0x0002C0EE
		private void UnregisterCallbacksFromTarget(DetachFromPanelEvent evt)
		{
			this.UnregisterCallbacksFromTarget(false);
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0002DEFC File Offset: 0x0002C0FC
		internal void UnregisterCallbacksFromTarget(bool unregisterPanelEvents = false)
		{
			this.m_IsRegistered = false;
			this.m_Target.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.OnPointerDownEvent), TrickleDown.NoTrickleDown);
			this.m_Target.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.OnPointerUpEvent), TrickleDown.TrickleDown);
			this.m_Target.UnregisterCallback<PointerLeaveEvent>(new EventCallback<PointerLeaveEvent>(this.OnPointerLeaveEvent), TrickleDown.NoTrickleDown);
			this.m_Target.UnregisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.OnPointerMoveEvent), TrickleDown.NoTrickleDown);
			this.m_Target.UnregisterCallback<PointerCancelEvent>(new EventCallback<PointerCancelEvent>(this.OnPointerCancelEvent), TrickleDown.NoTrickleDown);
			this.m_Target.UnregisterCallback<PointerCaptureOutEvent>(new EventCallback<PointerCaptureOutEvent>(this.OnPointerCapturedOut), TrickleDown.NoTrickleDown);
			if (unregisterPanelEvents)
			{
				this.m_Target.UnregisterCallback<AttachToPanelEvent>(new EventCallback<AttachToPanelEvent>(this.RegisterCallbacksFromTarget), TrickleDown.NoTrickleDown);
				this.m_Target.UnregisterCallback<DetachFromPanelEvent>(new EventCallback<DetachFromPanelEvent>(this.UnregisterCallbacksFromTarget), TrickleDown.NoTrickleDown);
			}
		}

		// Token: 0x06000B99 RID: 2969
		protected abstract bool CanStartDrag(Vector3 pointerPosition);

		// Token: 0x06000B9A RID: 2970
		protected internal abstract StartDragArgs StartDrag(Vector3 pointerPosition);

		// Token: 0x06000B9B RID: 2971
		protected internal abstract void UpdateDrag(Vector3 pointerPosition);

		// Token: 0x06000B9C RID: 2972
		protected internal abstract void OnDrop(Vector3 pointerPosition);

		// Token: 0x06000B9D RID: 2973
		protected abstract void ClearDragAndDropUI(bool dragCancelled);

		// Token: 0x06000B9E RID: 2974 RVA: 0x0002DFE0 File Offset: 0x0002C1E0
		private void OnPointerDownEvent(PointerDownEvent evt)
		{
			bool flag;
			if (evt.button == 0)
			{
				VisualElement visualElement = evt.leafTarget as VisualElement;
				flag = (visualElement != null && visualElement.isIMGUIContainer);
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			if (flag2)
			{
				this.m_DragState = DragEventsProcessor.DragState.None;
			}
			else
			{
				bool flag3 = this.CanStartDrag(evt.position);
				if (flag3)
				{
					this.m_DragState = DragEventsProcessor.DragState.CanStartDrag;
					this.m_Start = evt.position;
				}
			}
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0002E044 File Offset: 0x0002C244
		internal void OnPointerUpEvent(PointerUpEvent evt)
		{
			bool flag = !this.useDragEvents && this.m_DragState == DragEventsProcessor.DragState.Dragging;
			if (flag)
			{
				DragEventsProcessor dragEventsProcessor = this.GetDropTarget(evt.position) ?? this;
				dragEventsProcessor.UpdateDrag(evt.position);
				dragEventsProcessor.OnDrop(evt.position);
				dragEventsProcessor.ClearDragAndDropUI(false);
				evt.StopPropagation();
			}
			this.m_Target.ReleasePointer(evt.pointerId);
			this.ClearDragAndDropUI(this.m_DragState == DragEventsProcessor.DragState.Dragging);
			this.dragAndDrop.DragCleanup();
			this.m_DragState = DragEventsProcessor.DragState.None;
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0002E0E1 File Offset: 0x0002C2E1
		private void OnPointerLeaveEvent(PointerLeaveEvent evt)
		{
			this.ClearDragAndDropUI(false);
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0002E0EC File Offset: 0x0002C2EC
		private void OnPointerCancelEvent(PointerCancelEvent evt)
		{
			bool flag = !this.useDragEvents;
			if (flag)
			{
				this.ClearDragAndDropUI(true);
			}
			this.m_Target.ReleasePointer(evt.pointerId);
			this.ClearDragAndDropUI(this.m_DragState == DragEventsProcessor.DragState.Dragging);
			this.dragAndDrop.DragCleanup();
			this.m_DragState = DragEventsProcessor.DragState.None;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0002E144 File Offset: 0x0002C344
		private void OnPointerCapturedOut(PointerCaptureOutEvent evt)
		{
			bool flag = !this.useDragEvents;
			if (flag)
			{
				this.ClearDragAndDropUI(true);
			}
			this.ClearDragAndDropUI(this.m_DragState == DragEventsProcessor.DragState.Dragging);
			this.dragAndDrop.DragCleanup();
			this.m_DragState = DragEventsProcessor.DragState.None;
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0002E18C File Offset: 0x0002C38C
		private void OnPointerMoveEvent(PointerMoveEvent evt)
		{
			bool isHandledByDraggable = evt.isHandledByDraggable;
			if (!isHandledByDraggable)
			{
				bool flag = !this.useDragEvents && this.m_DragState == DragEventsProcessor.DragState.Dragging;
				if (flag)
				{
					DragEventsProcessor dragEventsProcessor = this.GetDropTarget(evt.position) ?? this;
					dragEventsProcessor.UpdateDrag(evt.position);
				}
				else
				{
					bool flag2 = this.m_DragState != DragEventsProcessor.DragState.CanStartDrag;
					if (!flag2)
					{
						bool flag3 = (this.m_Start - evt.position).sqrMagnitude >= 100f;
						if (flag3)
						{
							StartDragArgs args = this.StartDrag(this.m_Start);
							bool flag4 = args.visualMode == DragVisualMode.Rejected;
							if (flag4)
							{
								this.m_DragState = DragEventsProcessor.DragState.None;
							}
							else
							{
								bool flag5 = !this.useDragEvents;
								if (flag5)
								{
									bool supportsDragEvents = this.supportsDragEvents;
									if (supportsDragEvents)
									{
										this.dragAndDrop.StartDrag(args, evt.position);
									}
								}
								else
								{
									bool flag6 = Event.current != null && Event.current.type != EventType.MouseDown && Event.current.type != EventType.MouseDrag;
									if (flag6)
									{
										return;
									}
									this.dragAndDrop.StartDrag(args, evt.position);
								}
								this.m_DragState = DragEventsProcessor.DragState.Dragging;
								this.m_Target.CapturePointer(evt.pointerId);
								evt.isHandledByDraggable = true;
								evt.StopPropagation();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0002E300 File Offset: 0x0002C500
		private DragEventsProcessor GetDropTarget(Vector2 position)
		{
			DragEventsProcessor result = null;
			bool flag = this.m_Target.worldBound.Contains(position);
			if (flag)
			{
				result = this;
			}
			else
			{
				bool supportsDragEvents = this.supportsDragEvents;
				if (supportsDragEvents)
				{
					VisualElement visualElement = this.m_Target.elementPanel.Pick(position);
					BaseVerticalCollectionView baseVerticalCollectionView = (visualElement != null) ? visualElement.GetFirstOfType<BaseVerticalCollectionView>() : null;
					result = ((baseVerticalCollectionView != null) ? baseVerticalCollectionView.dragger : null);
				}
			}
			return result;
		}

		// Token: 0x04000573 RID: 1395
		private bool m_IsRegistered;

		// Token: 0x04000574 RID: 1396
		private DragEventsProcessor.DragState m_DragState;

		// Token: 0x04000575 RID: 1397
		private Vector3 m_Start;

		// Token: 0x04000576 RID: 1398
		protected readonly VisualElement m_Target;

		// Token: 0x02000163 RID: 355
		internal enum DragState
		{
			// Token: 0x04000578 RID: 1400
			None,
			// Token: 0x04000579 RID: 1401
			CanStartDrag,
			// Token: 0x0400057A RID: 1402
			Dragging
		}
	}
}
