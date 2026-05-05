using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x02000244 RID: 580
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class FieldMouseDragger<T> : BaseFieldMouseDragger
	{
		// Token: 0x0600106C RID: 4204 RVA: 0x0003B6EE File Offset: 0x000398EE
		public FieldMouseDragger(IValueField<T> drivenField)
		{
			this.m_DrivenField = drivenField;
			this.m_DragElement = null;
			this.m_DragHotZone = new Rect(0f, 0f, -1f, -1f);
			this.dragging = false;
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x0600106D RID: 4205 RVA: 0x0003B72D File Offset: 0x0003992D
		// (set) Token: 0x0600106E RID: 4206 RVA: 0x0003B735 File Offset: 0x00039935
		public bool dragging { get; set; }

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x0003B73E File Offset: 0x0003993E
		// (set) Token: 0x06001070 RID: 4208 RVA: 0x0003B746 File Offset: 0x00039946
		public T startValue { get; set; }

		// Token: 0x06001071 RID: 4209 RVA: 0x0003B750 File Offset: 0x00039950
		public sealed override void SetDragZone(VisualElement dragElement, Rect hotZone)
		{
			bool flag = this.m_DragElement != null;
			if (flag)
			{
				this.m_DragElement.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.UpdateValueOnPointerDown), TrickleDown.NoTrickleDown);
				this.m_DragElement.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.UpdateValueOnPointerUp), TrickleDown.NoTrickleDown);
				this.m_DragElement.UnregisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.UpdateValueOnKeyDown), TrickleDown.NoTrickleDown);
			}
			this.m_DragElement = dragElement;
			this.m_DragHotZone = hotZone;
			bool flag2 = this.m_DragElement != null;
			if (flag2)
			{
				this.dragging = false;
				this.m_DragElement.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(this.UpdateValueOnPointerDown), TrickleDown.NoTrickleDown);
				this.m_DragElement.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(this.UpdateValueOnPointerUp), TrickleDown.NoTrickleDown);
				this.m_DragElement.RegisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.UpdateValueOnKeyDown), TrickleDown.NoTrickleDown);
			}
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0003B828 File Offset: 0x00039A28
		private bool CanStartDrag(int button, Vector2 localPosition)
		{
			return button == 0 && (this.m_DragHotZone.width < 0f || this.m_DragHotZone.height < 0f || this.m_DragHotZone.Contains(this.m_DragElement.WorldToLocal(localPosition)));
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x0003B880 File Offset: 0x00039A80
		private void UpdateValueOnPointerDown(PointerDownEvent evt)
		{
			bool flag = this.CanStartDrag(evt.button, evt.localPosition);
			if (flag)
			{
				bool flag2 = evt.pointerType == PointerType.mouse;
				if (flag2)
				{
					this.m_DragElement.CaptureMouse();
					this.ProcessDownEvent(evt);
				}
				else
				{
					bool flag3 = this.m_DragElement.panel.contextType == ContextType.Editor;
					if (flag3)
					{
						evt.PreventDefault();
						this.m_DragElement.CapturePointer(evt.pointerId);
						this.ProcessDownEvent(evt);
					}
				}
			}
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0003B914 File Offset: 0x00039B14
		private void ProcessDownEvent(EventBase evt)
		{
			evt.StopPropagation();
			this.dragging = true;
			this.m_DragElement.RegisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.UpdateValueOnPointerMove), TrickleDown.NoTrickleDown);
			this.startValue = this.m_DrivenField.value;
			this.m_DrivenField.StartDragging();
			BaseVisualElementPanel baseVisualElementPanel = this.m_DragElement.panel as BaseVisualElementPanel;
			if (baseVisualElementPanel != null)
			{
				UIElementsBridge uiElementsBridge = baseVisualElementPanel.uiElementsBridge;
				if (uiElementsBridge != null)
				{
					uiElementsBridge.SetWantsMouseJumping(1);
				}
			}
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0003B990 File Offset: 0x00039B90
		private void UpdateValueOnPointerMove(PointerMoveEvent evt)
		{
			this.ProcessMoveEvent(evt.shiftKey, evt.altKey, evt.deltaPosition);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0003B9B4 File Offset: 0x00039BB4
		private void ProcessMoveEvent(bool shiftKey, bool altKey, Vector2 deltaPosition)
		{
			bool dragging = this.dragging;
			if (dragging)
			{
				DeltaSpeed speed = shiftKey ? DeltaSpeed.Fast : (altKey ? DeltaSpeed.Slow : DeltaSpeed.Normal);
				this.m_DrivenField.ApplyInputDeviceDelta(deltaPosition, speed, this.startValue);
			}
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x0003B9F5 File Offset: 0x00039BF5
		private void UpdateValueOnPointerUp(PointerUpEvent evt)
		{
			this.ProcessUpEvent(evt, evt.pointerId);
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x0003BA08 File Offset: 0x00039C08
		private void ProcessUpEvent(EventBase evt, int pointerId)
		{
			bool dragging = this.dragging;
			if (dragging)
			{
				this.dragging = false;
				this.m_DragElement.UnregisterCallback<PointerMoveEvent>(new EventCallback<PointerMoveEvent>(this.UpdateValueOnPointerMove), TrickleDown.NoTrickleDown);
				this.m_DragElement.ReleasePointer(pointerId);
				bool flag = evt is IMouseEvent;
				if (flag)
				{
					this.m_DragElement.panel.ProcessPointerCapture(PointerId.mousePointerId);
				}
				BaseVisualElementPanel baseVisualElementPanel = this.m_DragElement.panel as BaseVisualElementPanel;
				if (baseVisualElementPanel != null)
				{
					UIElementsBridge uiElementsBridge = baseVisualElementPanel.uiElementsBridge;
					if (uiElementsBridge != null)
					{
						uiElementsBridge.SetWantsMouseJumping(0);
					}
				}
				this.m_DrivenField.StopDragging();
			}
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x0003BAAC File Offset: 0x00039CAC
		private void UpdateValueOnKeyDown(KeyDownEvent evt)
		{
			bool flag = this.dragging && evt.keyCode == KeyCode.Escape;
			if (flag)
			{
				this.dragging = false;
				this.m_DrivenField.value = this.startValue;
				this.m_DrivenField.StopDragging();
				VisualElement visualElement = evt.target as VisualElement;
				IPanel panel = (visualElement != null) ? visualElement.panel : null;
				panel.ReleasePointer(PointerId.mousePointerId);
				BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
				if (baseVisualElementPanel != null)
				{
					UIElementsBridge uiElementsBridge = baseVisualElementPanel.uiElementsBridge;
					if (uiElementsBridge != null)
					{
						uiElementsBridge.SetWantsMouseJumping(0);
					}
				}
			}
		}

		// Token: 0x0400073B RID: 1851
		private readonly IValueField<T> m_DrivenField;

		// Token: 0x0400073C RID: 1852
		private VisualElement m_DragElement;

		// Token: 0x0400073D RID: 1853
		private Rect m_DragHotZone;
	}
}
