using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	// Token: 0x0200006D RID: 109
	[Obsolete("TouchInputModule is no longer required as Touch input is now handled in StandaloneInputModule.")]
	[AddComponentMenu("Event/Touch Input Module")]
	public class TouchInputModule : PointerInputModule
	{
		// Token: 0x0600065C RID: 1628 RVA: 0x0001B043 File Offset: 0x00019243
		protected TouchInputModule()
		{
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0001B04B File Offset: 0x0001924B
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x0001B053 File Offset: 0x00019253
		[Obsolete("allowActivationOnStandalone has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive")]
		public bool allowActivationOnStandalone
		{
			get
			{
				return this.m_ForceModuleActive;
			}
			set
			{
				this.m_ForceModuleActive = value;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x0001B05C File Offset: 0x0001925C
		// (set) Token: 0x06000660 RID: 1632 RVA: 0x0001B064 File Offset: 0x00019264
		public bool forceModuleActive
		{
			get
			{
				return this.m_ForceModuleActive;
			}
			set
			{
				this.m_ForceModuleActive = value;
			}
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001B070 File Offset: 0x00019270
		public override void UpdateModule()
		{
			if (!base.eventSystem.isFocused)
			{
				if (this.m_InputPointerEvent != null && this.m_InputPointerEvent.pointerDrag != null && this.m_InputPointerEvent.dragging)
				{
					ExecuteEvents.Execute<IEndDragHandler>(this.m_InputPointerEvent.pointerDrag, this.m_InputPointerEvent, ExecuteEvents.endDragHandler);
				}
				this.m_InputPointerEvent = null;
			}
			this.m_LastMousePosition = this.m_MousePosition;
			this.m_MousePosition = base.input.mousePosition;
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0001B0F2 File Offset: 0x000192F2
		public override bool IsModuleSupported()
		{
			return this.forceModuleActive || base.input.touchSupported;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0001B10C File Offset: 0x0001930C
		public override bool ShouldActivateModule()
		{
			if (!base.ShouldActivateModule())
			{
				return false;
			}
			if (this.m_ForceModuleActive)
			{
				return true;
			}
			if (this.UseFakeInput())
			{
				return base.input.GetMouseButtonDown(0) | (this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0f;
			}
			return base.input.touchCount > 0;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001B171 File Offset: 0x00019371
		private bool UseFakeInput()
		{
			return !base.input.touchSupported;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001B181 File Offset: 0x00019381
		public override void Process()
		{
			if (this.UseFakeInput())
			{
				this.FakeTouches();
				return;
			}
			this.ProcessTouchEvents();
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001B198 File Offset: 0x00019398
		private void FakeTouches()
		{
			PointerInputModule.MouseButtonEventData eventData = this.GetMousePointerEventData(0).GetButtonState(PointerEventData.InputButton.Left).eventData;
			if (eventData.PressedThisFrame())
			{
				eventData.buttonData.delta = Vector2.zero;
			}
			this.ProcessTouchPress(eventData.buttonData, eventData.PressedThisFrame(), eventData.ReleasedThisFrame());
			if (base.input.GetMouseButton(0))
			{
				this.ProcessMove(eventData.buttonData);
				this.ProcessDrag(eventData.buttonData);
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0001B210 File Offset: 0x00019410
		private void ProcessTouchEvents()
		{
			for (int i = 0; i < base.input.touchCount; i++)
			{
				Touch touch = base.input.GetTouch(i);
				if (touch.type != TouchType.Indirect)
				{
					bool pressed;
					bool flag;
					PointerEventData touchPointerEventData = base.GetTouchPointerEventData(touch, out pressed, out flag);
					this.ProcessTouchPress(touchPointerEventData, pressed, flag);
					if (!flag)
					{
						this.ProcessMove(touchPointerEventData);
						this.ProcessDrag(touchPointerEventData);
					}
					else
					{
						base.RemovePointerData(touchPointerEventData);
					}
				}
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001B280 File Offset: 0x00019480
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
			GameObject gameObject = pointerEvent.pointerCurrentRaycast.gameObject;
			if (pressed)
			{
				pointerEvent.eligibleForClick = true;
				pointerEvent.delta = Vector2.zero;
				pointerEvent.dragging = false;
				pointerEvent.useDragThreshold = true;
				pointerEvent.pressPosition = pointerEvent.position;
				pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;
				base.DeselectIfSelectionChanged(gameObject, pointerEvent);
				if (pointerEvent.pointerEnter != gameObject)
				{
					base.HandlePointerExitAndEnter(pointerEvent, gameObject);
					pointerEvent.pointerEnter = gameObject;
				}
				GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);
				if (gameObject2 == null)
				{
					gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				}
				float unscaledTime = Time.unscaledTime;
				if (gameObject2 == pointerEvent.lastPress)
				{
					if (unscaledTime - pointerEvent.clickTime < 0.3f)
					{
						int clickCount = pointerEvent.clickCount + 1;
						pointerEvent.clickCount = clickCount;
					}
					else
					{
						pointerEvent.clickCount = 1;
					}
					pointerEvent.clickTime = unscaledTime;
				}
				else
				{
					pointerEvent.clickCount = 1;
				}
				pointerEvent.pointerPress = gameObject2;
				pointerEvent.rawPointerPress = gameObject;
				pointerEvent.clickTime = unscaledTime;
				pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject);
				if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute<IInitializePotentialDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
				}
				this.m_InputPointerEvent = pointerEvent;
			}
			if (released)
			{
				ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				if (pointerEvent.pointerPress == eventHandler && pointerEvent.eligibleForClick)
				{
					ExecuteEvents.Execute<IPointerClickHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
				}
				else if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
				{
					ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject, pointerEvent, ExecuteEvents.dropHandler);
				}
				pointerEvent.eligibleForClick = false;
				pointerEvent.pointerPress = null;
				pointerEvent.rawPointerPress = null;
				if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
				{
					ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
				}
				pointerEvent.dragging = false;
				pointerEvent.pointerDrag = null;
				ExecuteEvents.ExecuteHierarchy<IPointerExitHandler>(pointerEvent.pointerEnter, pointerEvent, ExecuteEvents.pointerExitHandler);
				pointerEvent.pointerEnter = null;
				this.m_InputPointerEvent = pointerEvent;
			}
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001B48B File Offset: 0x0001968B
		public override void DeactivateModule()
		{
			base.DeactivateModule();
			base.ClearSelection();
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001B49C File Offset: 0x0001969C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(this.UseFakeInput() ? "Input: Faked" : "Input: Touch");
			if (this.UseFakeInput())
			{
				PointerEventData lastPointerEventData = base.GetLastPointerEventData(-1);
				if (lastPointerEventData != null)
				{
					stringBuilder.AppendLine(lastPointerEventData.ToString());
				}
			}
			else
			{
				foreach (KeyValuePair<int, PointerEventData> keyValuePair in this.m_PointerData)
				{
					stringBuilder.AppendLine(keyValuePair.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000225 RID: 549
		private Vector2 m_LastMousePosition;

		// Token: 0x04000226 RID: 550
		private Vector2 m_MousePosition;

		// Token: 0x04000227 RID: 551
		private PointerEventData m_InputPointerEvent;

		// Token: 0x04000228 RID: 552
		[SerializeField]
		[FormerlySerializedAs("m_AllowActivationOnStandalone")]
		private bool m_ForceModuleActive;
	}
}
