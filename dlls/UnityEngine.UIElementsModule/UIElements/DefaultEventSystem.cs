using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements
{
	// Token: 0x02000157 RID: 343
	internal class DefaultEventSystem
	{
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x0002C445 File Offset: 0x0002A645
		private bool isAppFocused
		{
			get
			{
				return Application.isFocused;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000B0F RID: 2831 RVA: 0x0002C44C File Offset: 0x0002A64C
		// (set) Token: 0x06000B10 RID: 2832 RVA: 0x0002C472 File Offset: 0x0002A672
		internal DefaultEventSystem.IInput input
		{
			get
			{
				DefaultEventSystem.IInput result;
				if ((result = this.m_Input) == null)
				{
					result = (this.m_Input = this.GetDefaultInput());
				}
				return result;
			}
			set
			{
				this.m_Input = value;
			}
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0002C47C File Offset: 0x0002A67C
		private DefaultEventSystem.IInput GetDefaultInput()
		{
			DefaultEventSystem.IInput input = new DefaultEventSystem.Input();
			try
			{
				input.GetAxisRaw(this.m_HorizontalAxis);
			}
			catch (InvalidOperationException)
			{
				input = new DefaultEventSystem.NoInput();
				Debug.LogWarning("UI Toolkit is currently relying on the legacy Input Manager for its active input source, but the legacy Input Manager is not available using your current Project Settings. Some UI Toolkit functionality might be missing or not working properly as a result. To fix this problem, you can enable \"Input Manager (old)\" or \"Both\" in the Active Input Source setting of the Player section. UI Toolkit is using its internal default event system to process input. Alternatively, you may activate new Input System support with UI Toolkit by adding an EventSystem component to your active scene.");
			}
			return input;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0002C4CC File Offset: 0x0002A6CC
		private bool ShouldIgnoreEventsOnAppNotFocused()
		{
			OperatingSystemFamily operatingSystemFamily = SystemInfo.operatingSystemFamily;
			OperatingSystemFamily operatingSystemFamily2 = operatingSystemFamily;
			return operatingSystemFamily2 - OperatingSystemFamily.MacOSX <= 2;
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0002C4F3 File Offset: 0x0002A6F3
		// (set) Token: 0x06000B14 RID: 2836 RVA: 0x0002C4FC File Offset: 0x0002A6FC
		public BaseRuntimePanel focusedPanel
		{
			get
			{
				return this.m_FocusedPanel;
			}
			set
			{
				bool flag = this.m_FocusedPanel != value;
				if (flag)
				{
					BaseRuntimePanel focusedPanel = this.m_FocusedPanel;
					if (focusedPanel != null)
					{
						focusedPanel.Blur();
					}
					this.m_FocusedPanel = value;
					BaseRuntimePanel focusedPanel2 = this.m_FocusedPanel;
					if (focusedPanel2 != null)
					{
						focusedPanel2.Focus();
					}
				}
			}
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0002C548 File Offset: 0x0002A748
		public void Reset()
		{
			this.m_LastMousePressButton = -1;
			this.m_NextMousePressTime = 0f;
			this.m_LastMouseClickCount = 0;
			this.m_LastMousePosition = Vector2.zero;
			this.m_MouseProcessedAtLeastOnce = false;
			this.m_ConsecutiveMoveCount = 0;
			this.m_IsMoveFromKeyboard = false;
			this.m_FocusedPanel = null;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0002C598 File Offset: 0x0002A798
		public void Update(DefaultEventSystem.UpdateMode updateMode = DefaultEventSystem.UpdateMode.Always)
		{
			bool flag = !this.isAppFocused && this.ShouldIgnoreEventsOnAppNotFocused() && updateMode == DefaultEventSystem.UpdateMode.IgnoreIfAppNotFocused;
			if (!flag)
			{
				this.m_SendingPenEvent = this.ProcessPenEvents();
				bool flag2 = !this.m_SendingPenEvent;
				if (flag2)
				{
					this.m_SendingTouchEvents = this.ProcessTouchEvents();
				}
				bool flag3 = !this.m_SendingPenEvent && !this.m_SendingTouchEvents;
				if (flag3)
				{
					this.ProcessMouseEvents();
				}
				else
				{
					this.m_MouseProcessedAtLeastOnce = false;
				}
				using (this.FocusBasedEventSequence())
				{
					this.SendIMGUIEvents();
					this.SendInputEvents();
				}
			}
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0002C648 File Offset: 0x0002A848
		internal DefaultEventSystem.FocusBasedEventSequenceContext FocusBasedEventSequence()
		{
			return new DefaultEventSystem.FocusBasedEventSequenceContext(this);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0002C660 File Offset: 0x0002A860
		private void SendIMGUIEvents()
		{
			bool flag = true;
			while (Event.PopEvent(this.m_Event))
			{
				bool flag2 = this.m_Event.type == EventType.Ignore || this.m_Event.type == EventType.Repaint || this.m_Event.type == EventType.Layout;
				if (!flag2)
				{
					this.m_CurrentModifiers = (flag ? this.m_Event.modifiers : (this.m_CurrentModifiers | this.m_Event.modifiers));
					flag = false;
					bool flag3 = this.m_Event.type == EventType.KeyUp || this.m_Event.type == EventType.KeyDown;
					if (flag3)
					{
						this.SendFocusBasedEvent<DefaultEventSystem>((DefaultEventSystem self) => UIElementsRuntimeUtility.CreateEvent(self.m_Event), this);
						this.ProcessTabEvent(this.m_Event, this.m_CurrentModifiers);
					}
					else
					{
						bool flag4 = this.m_Event.type == EventType.ScrollWheel;
						if (flag4)
						{
							int? targetDisplay;
							Vector2 vector = UIElementsRuntimeUtility.MultiDisplayBottomLeftToPanelPosition(this.input.mousePosition, out targetDisplay);
							Vector2 v = vector - this.m_LastMousePosition;
							Vector2 delta = this.m_Event.delta;
							this.SendPositionBasedEvent<ValueTuple<EventModifiers, Vector2>>(vector, v, PointerId.mousePointerId, targetDisplay, (Vector3 panelPosition, Vector3 _, [TupleElementNames(new string[]
							{
								"modifiers",
								"scrollDelta"
							})] ValueTuple<EventModifiers, Vector2> t) => WheelEvent.GetPooled(t.Item2, panelPosition, t.Item1), new ValueTuple<EventModifiers, Vector2>(this.m_CurrentModifiers, delta), false);
						}
						else
						{
							bool flag5 = (!this.m_SendingTouchEvents && !this.m_SendingPenEvent && this.m_Event.pointerType != PointerType.Mouse) || this.m_Event.type == EventType.MouseEnterWindow || this.m_Event.type == EventType.MouseLeaveWindow;
							if (flag5)
							{
								int pointerId = (this.m_Event.pointerType == PointerType.Mouse) ? PointerId.mousePointerId : ((this.m_Event.pointerType == PointerType.Touch) ? PointerId.touchPointerIdBase : PointerId.penPointerIdBase);
								int? targetDisplay2;
								Vector3 mousePosition = UIElementsRuntimeUtility.MultiDisplayToLocalScreenPosition(this.m_Event.mousePosition, out targetDisplay2);
								Vector2 delta2 = this.m_Event.delta;
								this.SendPositionBasedEvent<Event>(mousePosition, delta2, pointerId, targetDisplay2, delegate(Vector3 panelPosition, Vector3 panelDelta, Event evt)
								{
									evt.mousePosition = panelPosition;
									evt.delta = panelDelta;
									return UIElementsRuntimeUtility.CreateEvent(evt);
								}, this.m_Event, this.m_Event.type == EventType.MouseDown || this.m_Event.type == EventType.TouchDown);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0002C8E4 File Offset: 0x0002AAE4
		private void ProcessMouseEvents()
		{
			bool flag = !this.input.mousePresent;
			if (!flag)
			{
				int? targetDisplay;
				Vector2 vector = UIElementsRuntimeUtility.MultiDisplayBottomLeftToPanelPosition(this.input.mousePosition, out targetDisplay);
				Vector2 vector2 = vector - this.m_LastMousePosition;
				bool flag2 = !this.m_MouseProcessedAtLeastOnce;
				if (flag2)
				{
					vector2 = Vector2.zero;
					this.m_LastMousePosition = vector;
					this.m_MouseProcessedAtLeastOnce = true;
				}
				else
				{
					bool flag3 = !Mathf.Approximately(vector2.x, 0f) || !Mathf.Approximately(vector2.y, 0f);
					if (flag3)
					{
						this.m_LastMousePosition = vector;
						this.SendPositionBasedEvent<DefaultEventSystem>(vector, vector2, PointerId.mousePointerId, targetDisplay, (Vector3 panelPosition, Vector3 panelDelta, DefaultEventSystem self) => PointerEventBase<PointerMoveEvent>.GetPooled(EventType.MouseMove, panelPosition, panelDelta, -1, 0, self.m_CurrentModifiers), this, false);
					}
				}
				int mouseButtonCount = this.input.mouseButtonCount;
				for (int i = 0; i < mouseButtonCount; i++)
				{
					bool mouseButtonDown = this.input.GetMouseButtonDown(i);
					if (mouseButtonDown)
					{
						bool flag4 = this.m_LastMousePressButton != i || this.input.unscaledTime >= this.m_NextMousePressTime;
						if (flag4)
						{
							this.m_LastMousePressButton = i;
							this.m_LastMouseClickCount = 0;
						}
						int num = this.m_LastMouseClickCount + 1;
						this.m_LastMouseClickCount = num;
						int item = num;
						this.m_NextMousePressTime = this.input.unscaledTime + this.input.doubleClickTime;
						this.SendPositionBasedEvent<ValueTuple<int, int, EventModifiers>>(vector, vector2, PointerId.mousePointerId, targetDisplay, (Vector3 panelPosition, Vector3 panelDelta, [TupleElementNames(new string[]
						{
							"button",
							"clickCount",
							"modifiers"
						})] ValueTuple<int, int, EventModifiers> t) => PointerEventHelper.GetPooled(EventType.MouseDown, panelPosition, panelDelta, t.Item1, t.Item2, t.Item3), new ValueTuple<int, int, EventModifiers>(i, item, this.m_CurrentModifiers), true);
					}
					bool mouseButtonUp = this.input.GetMouseButtonUp(i);
					if (mouseButtonUp)
					{
						int lastMouseClickCount = this.m_LastMouseClickCount;
						this.SendPositionBasedEvent<ValueTuple<int, int, EventModifiers>>(vector, vector2, PointerId.mousePointerId, targetDisplay, (Vector3 panelPosition, Vector3 panelDelta, [TupleElementNames(new string[]
						{
							"button",
							"clickCount",
							"modifiers"
						})] ValueTuple<int, int, EventModifiers> t) => PointerEventHelper.GetPooled(EventType.MouseUp, panelPosition, panelDelta, t.Item1, t.Item2, t.Item3), new ValueTuple<int, int, EventModifiers>(i, lastMouseClickCount, this.m_CurrentModifiers), false);
					}
				}
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0002CB28 File Offset: 0x0002AD28
		private void SendInputEvents()
		{
			bool flag = this.ShouldSendMoveFromInput();
			bool flag2 = flag;
			if (flag2)
			{
				this.SendFocusBasedEvent<DefaultEventSystem>((DefaultEventSystem self) => NavigationMoveEvent.GetPooled(self.GetRawMoveVector(), self.m_IsMoveFromKeyboard ? NavigationDeviceType.Keyboard : NavigationDeviceType.NonKeyboard, self.m_CurrentModifiers), this);
			}
			bool buttonDown = this.input.GetButtonDown(this.m_SubmitButton);
			if (buttonDown)
			{
				this.SendFocusBasedEvent<DefaultEventSystem>((DefaultEventSystem self) => NavigationEventBase<NavigationSubmitEvent>.GetPooled(self.input.anyKey ? NavigationDeviceType.Keyboard : NavigationDeviceType.NonKeyboard, self.m_CurrentModifiers), this);
			}
			bool buttonDown2 = this.input.GetButtonDown(this.m_CancelButton);
			if (buttonDown2)
			{
				this.SendFocusBasedEvent<DefaultEventSystem>((DefaultEventSystem self) => NavigationEventBase<NavigationCancelEvent>.GetPooled(self.input.anyKey ? NavigationDeviceType.Keyboard : NavigationDeviceType.NonKeyboard, self.m_CurrentModifiers), this);
			}
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0002CBE7 File Offset: 0x0002ADE7
		internal void OnFocusEvent(RuntimePanel panel, FocusEvent evt)
		{
			this.focusedPanel = panel;
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0002CBF4 File Offset: 0x0002ADF4
		internal void SendFocusBasedEvent<TArg>(Func<TArg, EventBase> evtFactory, TArg arg)
		{
			bool flag = this.m_PreviousFocusedPanel != null;
			if (flag)
			{
				using (EventBase eventBase = evtFactory(arg))
				{
					eventBase.target = (this.m_PreviousFocusedElement ?? this.m_PreviousFocusedPanel.visualTree);
					this.m_PreviousFocusedPanel.visualTree.SendEvent(eventBase);
					this.UpdateFocusedPanel(this.m_PreviousFocusedPanel);
					return;
				}
			}
			List<Panel> sortedPlayerPanels = UIElementsRuntimeUtility.GetSortedPlayerPanels();
			for (int i = sortedPlayerPanels.Count - 1; i >= 0; i--)
			{
				Panel panel = sortedPlayerPanels[i];
				BaseRuntimePanel baseRuntimePanel = panel as BaseRuntimePanel;
				bool flag2 = baseRuntimePanel != null;
				if (flag2)
				{
					using (EventBase eventBase2 = evtFactory(arg))
					{
						eventBase2.target = baseRuntimePanel.visualTree;
						baseRuntimePanel.visualTree.SendEvent(eventBase2);
						bool flag3 = baseRuntimePanel.focusController.focusedElement != null;
						if (flag3)
						{
							this.focusedPanel = baseRuntimePanel;
							break;
						}
						bool isPropagationStopped = eventBase2.isPropagationStopped;
						if (isPropagationStopped)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0002CD34 File Offset: 0x0002AF34
		internal void SendPositionBasedEvent<TArg>(Vector3 mousePosition, Vector3 delta, int pointerId, Func<Vector3, Vector3, TArg, EventBase> evtFactory, TArg arg, bool deselectIfNoTarget = false)
		{
			this.SendPositionBasedEvent<TArg>(mousePosition, delta, pointerId, null, evtFactory, arg, deselectIfNoTarget);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0002CD5C File Offset: 0x0002AF5C
		private void SendPositionBasedEvent<TArg>(Vector3 mousePosition, Vector3 delta, int pointerId, int? targetDisplay, Func<Vector3, Vector3, TArg, EventBase> evtFactory, TArg arg, bool deselectIfNoTarget = false)
		{
			bool flag = this.focusedPanel != null;
			if (flag)
			{
				this.UpdateFocusedPanel(this.focusedPanel);
			}
			IPanel panel = PointerDeviceState.GetPlayerPanelWithSoftPointerCapture(pointerId);
			IEventHandler capturingElement = RuntimePanel.s_EventDispatcher.pointerState.GetCapturingElement(pointerId);
			VisualElement visualElement = capturingElement as VisualElement;
			bool flag2 = visualElement != null;
			if (flag2)
			{
				panel = visualElement.panel;
			}
			BaseRuntimePanel baseRuntimePanel = null;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			BaseRuntimePanel baseRuntimePanel2 = panel as BaseRuntimePanel;
			bool flag3 = baseRuntimePanel2 != null;
			if (flag3)
			{
				baseRuntimePanel = baseRuntimePanel2;
				baseRuntimePanel.ScreenToPanel(mousePosition, delta, out zero, out zero2, false);
			}
			else
			{
				List<Panel> sortedPlayerPanels = UIElementsRuntimeUtility.GetSortedPlayerPanels();
				for (int i = sortedPlayerPanels.Count - 1; i >= 0; i--)
				{
					BaseRuntimePanel baseRuntimePanel3 = sortedPlayerPanels[i] as BaseRuntimePanel;
					bool flag4;
					if (baseRuntimePanel3 != null)
					{
						if (targetDisplay != null)
						{
							int targetDisplay2 = baseRuntimePanel3.targetDisplay;
							int? num = targetDisplay;
							flag4 = (targetDisplay2 == num.GetValueOrDefault() & num != null);
						}
						else
						{
							flag4 = true;
						}
					}
					else
					{
						flag4 = false;
					}
					bool flag5 = flag4;
					if (flag5)
					{
						bool flag6 = baseRuntimePanel3.ScreenToPanel(mousePosition, delta, out zero, out zero2, false) && baseRuntimePanel3.Pick(zero) != null;
						if (flag6)
						{
							baseRuntimePanel = baseRuntimePanel3;
							break;
						}
					}
				}
			}
			BaseRuntimePanel baseRuntimePanel4 = PointerDeviceState.GetPanel(pointerId, ContextType.Player) as BaseRuntimePanel;
			bool flag7 = baseRuntimePanel4 != baseRuntimePanel;
			if (flag7)
			{
				if (baseRuntimePanel4 != null)
				{
					baseRuntimePanel4.PointerLeavesPanel(pointerId, baseRuntimePanel4.ScreenToPanel(mousePosition));
				}
				if (baseRuntimePanel != null)
				{
					baseRuntimePanel.PointerEntersPanel(pointerId, zero);
				}
			}
			bool flag8 = baseRuntimePanel != null;
			if (flag8)
			{
				using (EventBase eventBase = evtFactory(zero, zero2, arg))
				{
					baseRuntimePanel.visualTree.SendEvent(eventBase);
					bool processedByFocusController = eventBase.processedByFocusController;
					if (processedByFocusController)
					{
						this.UpdateFocusedPanel(baseRuntimePanel);
					}
					bool flag9 = eventBase.eventTypeId == EventBase<PointerDownEvent>.TypeId();
					if (flag9)
					{
						PointerDeviceState.SetPlayerPanelWithSoftPointerCapture(pointerId, baseRuntimePanel);
					}
					else
					{
						bool flag10 = eventBase.eventTypeId == EventBase<PointerUpEvent>.TypeId() && ((PointerUpEvent)eventBase).pressedButtons == 0;
						if (flag10)
						{
							PointerDeviceState.SetPlayerPanelWithSoftPointerCapture(pointerId, null);
						}
					}
				}
			}
			else if (deselectIfNoTarget)
			{
				this.focusedPanel = null;
			}
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0002CFC8 File Offset: 0x0002B1C8
		private void UpdateFocusedPanel(BaseRuntimePanel runtimePanel)
		{
			bool flag = runtimePanel.focusController.focusedElement != null;
			if (flag)
			{
				this.focusedPanel = runtimePanel;
			}
			else
			{
				bool flag2 = this.focusedPanel == runtimePanel;
				if (flag2)
				{
					this.focusedPanel = null;
				}
			}
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0002D00C File Offset: 0x0002B20C
		private static EventBase MakeTouchEvent(Touch touch, EventModifiers modifiers)
		{
			EventBase result;
			switch (touch.phase)
			{
			case TouchPhase.Began:
				result = PointerEventBase<PointerDownEvent>.GetPooled(touch, modifiers);
				break;
			case TouchPhase.Moved:
				result = PointerEventBase<PointerMoveEvent>.GetPooled(touch, modifiers);
				break;
			case TouchPhase.Stationary:
				result = PointerEventBase<PointerStationaryEvent>.GetPooled(touch, modifiers);
				break;
			case TouchPhase.Ended:
				result = PointerEventBase<PointerUpEvent>.GetPooled(touch, modifiers);
				break;
			case TouchPhase.Canceled:
				result = PointerEventBase<PointerCancelEvent>.GetPooled(touch, modifiers);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0002D078 File Offset: 0x0002B278
		private static EventBase MakePenEvent(PenData pen, EventModifiers modifiers)
		{
			switch (pen.contactType)
			{
			case PenEventType.PenDown:
				return PointerEventBase<PointerDownEvent>.GetPooled(pen, modifiers);
			case PenEventType.PenUp:
				return PointerEventBase<PointerUpEvent>.GetPooled(pen, modifiers);
			}
			return null;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0002D0BC File Offset: 0x0002B2BC
		private bool ProcessTouchEvents()
		{
			for (int i = 0; i < this.input.touchCount; i++)
			{
				Touch touch = this.input.GetTouch(i);
				bool flag = touch.type == TouchType.Indirect;
				if (!flag)
				{
					int? targetDisplay;
					touch.position = UIElementsRuntimeUtility.MultiDisplayBottomLeftToPanelPosition(touch.position, out targetDisplay);
					int? num;
					touch.rawPosition = UIElementsRuntimeUtility.MultiDisplayBottomLeftToPanelPosition(touch.rawPosition, out num);
					touch.deltaPosition = UIElementsRuntimeUtility.ScreenBottomLeftToPanelDelta(touch.deltaPosition);
					this.SendPositionBasedEvent<Touch>(touch.position, touch.deltaPosition, PointerId.touchPointerIdBase + touch.fingerId, targetDisplay, delegate(Vector3 panelPosition, Vector3 panelDelta, Touch _touch)
					{
						_touch.position = panelPosition;
						_touch.deltaPosition = panelDelta;
						return DefaultEventSystem.MakeTouchEvent(_touch, EventModifiers.None);
					}, touch, false);
				}
			}
			return this.input.touchCount > 0;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0002D1B0 File Offset: 0x0002B3B0
		private bool ProcessPenEvents()
		{
			PenData lastPenContactEvent = this.input.GetLastPenContactEvent();
			bool flag = lastPenContactEvent.contactType == PenEventType.NoContact;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.SendPositionBasedEvent<PenData>(lastPenContactEvent.position, lastPenContactEvent.deltaPos, PointerId.penPointerIdBase, null, delegate(Vector3 panelPosition, Vector3 panelDelta, PenData _pen)
				{
					_pen.position = panelPosition;
					_pen.deltaPos = panelDelta;
					return DefaultEventSystem.MakePenEvent(_pen, EventModifiers.None);
				}, lastPenContactEvent, false);
				this.input.ClearLastPenContactEvent();
				result = true;
			}
			return result;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0002D238 File Offset: 0x0002B438
		private Vector2 GetRawMoveVector()
		{
			Vector2 zero = Vector2.zero;
			zero.x = this.input.GetAxisRaw(this.m_HorizontalAxis);
			zero.y = this.input.GetAxisRaw(this.m_VerticalAxis);
			bool buttonDown = this.input.GetButtonDown(this.m_HorizontalAxis);
			if (buttonDown)
			{
				bool flag = zero.x < 0f;
				if (flag)
				{
					zero.x = -1f;
				}
				bool flag2 = zero.x > 0f;
				if (flag2)
				{
					zero.x = 1f;
				}
			}
			bool buttonDown2 = this.input.GetButtonDown(this.m_VerticalAxis);
			if (buttonDown2)
			{
				bool flag3 = zero.y < 0f;
				if (flag3)
				{
					zero.y = -1f;
				}
				bool flag4 = zero.y > 0f;
				if (flag4)
				{
					zero.y = 1f;
				}
			}
			return zero;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0002D32C File Offset: 0x0002B52C
		private bool ShouldSendMoveFromInput()
		{
			float unscaledTime = this.input.unscaledTime;
			Vector2 rawMoveVector = this.GetRawMoveVector();
			bool flag = Mathf.Approximately(rawMoveVector.x, 0f) && Mathf.Approximately(rawMoveVector.y, 0f);
			bool result;
			if (flag)
			{
				this.m_ConsecutiveMoveCount = 0;
				this.m_IsMoveFromKeyboard = false;
				result = false;
			}
			else
			{
				bool flag2 = this.input.GetButtonDown(this.m_HorizontalAxis) || this.input.GetButtonDown(this.m_VerticalAxis);
				bool flag3 = Vector2.Dot(rawMoveVector, this.m_LastMoveVector) > 0f;
				bool flag4 = !flag2;
				if (flag4)
				{
					bool flag5 = flag3 && this.m_ConsecutiveMoveCount == 1;
					if (flag5)
					{
						flag2 = (unscaledTime > this.m_PrevActionTime + this.m_RepeatDelay);
					}
					else
					{
						flag2 = (unscaledTime > this.m_PrevActionTime + 1f / this.m_InputActionsPerSecond);
					}
				}
				bool flag6 = !flag2;
				if (flag6)
				{
					result = false;
				}
				else
				{
					NavigationMoveEvent.Direction direction = NavigationMoveEvent.DetermineMoveDirection(rawMoveVector.x, rawMoveVector.y, 0.6f);
					bool flag7 = direction > NavigationMoveEvent.Direction.None;
					if (flag7)
					{
						bool flag8 = !flag3;
						if (flag8)
						{
							this.m_ConsecutiveMoveCount = 0;
						}
						this.m_ConsecutiveMoveCount++;
						this.m_PrevActionTime = unscaledTime;
						this.m_LastMoveVector = rawMoveVector;
						this.m_IsMoveFromKeyboard |= this.input.anyKey;
					}
					else
					{
						this.m_ConsecutiveMoveCount = 0;
						this.m_IsMoveFromKeyboard = false;
					}
					result = (direction > NavigationMoveEvent.Direction.None);
				}
			}
			return result;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0002D4B0 File Offset: 0x0002B6B0
		private void ProcessTabEvent(Event e, EventModifiers modifiers)
		{
			bool flag = e.ShouldSendNavigationMoveEventRuntime();
			if (flag)
			{
				NavigationMoveEvent.Direction item = e.shift ? NavigationMoveEvent.Direction.Previous : NavigationMoveEvent.Direction.Next;
				this.SendFocusBasedEvent<ValueTuple<NavigationMoveEvent.Direction, EventModifiers, DefaultEventSystem.IInput>>(([TupleElementNames(new string[]
				{
					"direction",
					"modifiers",
					"input"
				})] ValueTuple<NavigationMoveEvent.Direction, EventModifiers, DefaultEventSystem.IInput> t) => NavigationMoveEvent.GetPooled(t.Item1, t.Item3.anyKey ? NavigationDeviceType.Keyboard : NavigationDeviceType.NonKeyboard, t.Item2), new ValueTuple<NavigationMoveEvent.Direction, EventModifiers, DefaultEventSystem.IInput>(item, modifiers, this.input));
			}
		}

		// Token: 0x04000540 RID: 1344
		internal static Func<bool> IsEditorRemoteConnected = () => false;

		// Token: 0x04000541 RID: 1345
		private DefaultEventSystem.IInput m_Input;

		// Token: 0x04000542 RID: 1346
		private readonly string m_HorizontalAxis = "Horizontal";

		// Token: 0x04000543 RID: 1347
		private readonly string m_VerticalAxis = "Vertical";

		// Token: 0x04000544 RID: 1348
		private readonly string m_SubmitButton = "Submit";

		// Token: 0x04000545 RID: 1349
		private readonly string m_CancelButton = "Cancel";

		// Token: 0x04000546 RID: 1350
		private readonly float m_InputActionsPerSecond = 10f;

		// Token: 0x04000547 RID: 1351
		private readonly float m_RepeatDelay = 0.5f;

		// Token: 0x04000548 RID: 1352
		private bool m_SendingTouchEvents;

		// Token: 0x04000549 RID: 1353
		private bool m_SendingPenEvent;

		// Token: 0x0400054A RID: 1354
		private Event m_Event = new Event();

		// Token: 0x0400054B RID: 1355
		private BaseRuntimePanel m_FocusedPanel;

		// Token: 0x0400054C RID: 1356
		private BaseRuntimePanel m_PreviousFocusedPanel;

		// Token: 0x0400054D RID: 1357
		private Focusable m_PreviousFocusedElement;

		// Token: 0x0400054E RID: 1358
		private EventModifiers m_CurrentModifiers;

		// Token: 0x0400054F RID: 1359
		private int m_LastMousePressButton = -1;

		// Token: 0x04000550 RID: 1360
		private float m_NextMousePressTime = 0f;

		// Token: 0x04000551 RID: 1361
		private int m_LastMouseClickCount = 0;

		// Token: 0x04000552 RID: 1362
		private Vector2 m_LastMousePosition = Vector2.zero;

		// Token: 0x04000553 RID: 1363
		private bool m_MouseProcessedAtLeastOnce;

		// Token: 0x04000554 RID: 1364
		private int m_ConsecutiveMoveCount;

		// Token: 0x04000555 RID: 1365
		private Vector2 m_LastMoveVector;

		// Token: 0x04000556 RID: 1366
		private float m_PrevActionTime;

		// Token: 0x04000557 RID: 1367
		private bool m_IsMoveFromKeyboard;

		// Token: 0x02000158 RID: 344
		public enum UpdateMode
		{
			// Token: 0x04000559 RID: 1369
			Always,
			// Token: 0x0400055A RID: 1370
			IgnoreIfAppNotFocused
		}

		// Token: 0x02000159 RID: 345
		internal struct FocusBasedEventSequenceContext : IDisposable
		{
			// Token: 0x06000B29 RID: 2857 RVA: 0x0002D5A8 File Offset: 0x0002B7A8
			public FocusBasedEventSequenceContext(DefaultEventSystem es)
			{
				this.es = es;
				es.m_PreviousFocusedPanel = es.focusedPanel;
				BaseRuntimePanel focusedPanel = es.focusedPanel;
				es.m_PreviousFocusedElement = ((focusedPanel != null) ? focusedPanel.focusController.GetLeafFocusedElement() : null);
			}

			// Token: 0x06000B2A RID: 2858 RVA: 0x0002D5DB File Offset: 0x0002B7DB
			public void Dispose()
			{
				this.es.m_PreviousFocusedPanel = null;
				this.es.m_PreviousFocusedElement = null;
			}

			// Token: 0x0400055B RID: 1371
			private DefaultEventSystem es;
		}

		// Token: 0x0200015A RID: 346
		internal interface IInput
		{
			// Token: 0x06000B2B RID: 2859
			bool GetButtonDown(string button);

			// Token: 0x06000B2C RID: 2860
			float GetAxisRaw(string axis);

			// Token: 0x06000B2D RID: 2861
			void ResetPenEvents();

			// Token: 0x06000B2E RID: 2862
			void ClearLastPenContactEvent();

			// Token: 0x17000222 RID: 546
			// (get) Token: 0x06000B2F RID: 2863
			int penEventCount { get; }

			// Token: 0x06000B30 RID: 2864
			PenData GetPenEvent(int index);

			// Token: 0x06000B31 RID: 2865
			PenData GetLastPenContactEvent();

			// Token: 0x17000223 RID: 547
			// (get) Token: 0x06000B32 RID: 2866
			int touchCount { get; }

			// Token: 0x06000B33 RID: 2867
			Touch GetTouch(int index);

			// Token: 0x17000224 RID: 548
			// (get) Token: 0x06000B34 RID: 2868
			bool mousePresent { get; }

			// Token: 0x06000B35 RID: 2869
			bool GetMouseButtonDown(int button);

			// Token: 0x06000B36 RID: 2870
			bool GetMouseButtonUp(int button);

			// Token: 0x17000225 RID: 549
			// (get) Token: 0x06000B37 RID: 2871
			Vector3 mousePosition { get; }

			// Token: 0x17000226 RID: 550
			// (get) Token: 0x06000B38 RID: 2872
			Vector2 mouseScrollDelta { get; }

			// Token: 0x17000227 RID: 551
			// (get) Token: 0x06000B39 RID: 2873
			int mouseButtonCount { get; }

			// Token: 0x17000228 RID: 552
			// (get) Token: 0x06000B3A RID: 2874
			bool anyKey { get; }

			// Token: 0x17000229 RID: 553
			// (get) Token: 0x06000B3B RID: 2875
			float unscaledTime { get; }

			// Token: 0x1700022A RID: 554
			// (get) Token: 0x06000B3C RID: 2876
			float doubleClickTime { get; }
		}

		// Token: 0x0200015B RID: 347
		private class Input : DefaultEventSystem.IInput
		{
			// Token: 0x06000B3D RID: 2877 RVA: 0x0002D5F6 File Offset: 0x0002B7F6
			public bool GetButtonDown(string button)
			{
				return UnityEngine.Input.GetButtonDown(button);
			}

			// Token: 0x06000B3E RID: 2878 RVA: 0x0002D5FE File Offset: 0x0002B7FE
			public float GetAxisRaw(string axis)
			{
				return UnityEngine.Input.GetAxis(axis);
			}

			// Token: 0x06000B3F RID: 2879 RVA: 0x0002D606 File Offset: 0x0002B806
			public void ResetPenEvents()
			{
				UnityEngine.Input.ResetPenEvents();
			}

			// Token: 0x06000B40 RID: 2880 RVA: 0x0002D60E File Offset: 0x0002B80E
			public void ClearLastPenContactEvent()
			{
				UnityEngine.Input.ClearLastPenContactEvent();
			}

			// Token: 0x1700022B RID: 555
			// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0002D616 File Offset: 0x0002B816
			public int penEventCount
			{
				get
				{
					return UnityEngine.Input.penEventCount;
				}
			}

			// Token: 0x06000B42 RID: 2882 RVA: 0x0002D61D File Offset: 0x0002B81D
			public PenData GetPenEvent(int index)
			{
				return UnityEngine.Input.GetPenEvent(index);
			}

			// Token: 0x06000B43 RID: 2883 RVA: 0x0002D625 File Offset: 0x0002B825
			public PenData GetLastPenContactEvent()
			{
				return UnityEngine.Input.GetLastPenContactEvent();
			}

			// Token: 0x1700022C RID: 556
			// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0002D62C File Offset: 0x0002B82C
			public int touchCount
			{
				get
				{
					return UnityEngine.Input.touchCount;
				}
			}

			// Token: 0x06000B45 RID: 2885 RVA: 0x0002D633 File Offset: 0x0002B833
			public Touch GetTouch(int index)
			{
				return UnityEngine.Input.GetTouch(index);
			}

			// Token: 0x1700022D RID: 557
			// (get) Token: 0x06000B46 RID: 2886 RVA: 0x0002D63B File Offset: 0x0002B83B
			public bool mousePresent
			{
				get
				{
					return UnityEngine.Input.mousePresent;
				}
			}

			// Token: 0x06000B47 RID: 2887 RVA: 0x0002D642 File Offset: 0x0002B842
			public bool GetMouseButtonDown(int button)
			{
				return UnityEngine.Input.GetMouseButtonDown(button);
			}

			// Token: 0x06000B48 RID: 2888 RVA: 0x0002D64A File Offset: 0x0002B84A
			public bool GetMouseButtonUp(int button)
			{
				return UnityEngine.Input.GetMouseButtonUp(button);
			}

			// Token: 0x1700022E RID: 558
			// (get) Token: 0x06000B49 RID: 2889 RVA: 0x0002D652 File Offset: 0x0002B852
			public Vector3 mousePosition
			{
				get
				{
					return UnityEngine.Input.mousePosition;
				}
			}

			// Token: 0x1700022F RID: 559
			// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0002D659 File Offset: 0x0002B859
			public Vector2 mouseScrollDelta
			{
				get
				{
					return UnityEngine.Input.mouseScrollDelta;
				}
			}

			// Token: 0x17000230 RID: 560
			// (get) Token: 0x06000B4B RID: 2891 RVA: 0x0002D660 File Offset: 0x0002B860
			public int mouseButtonCount
			{
				get
				{
					return 3;
				}
			}

			// Token: 0x17000231 RID: 561
			// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0002D663 File Offset: 0x0002B863
			public bool anyKey
			{
				get
				{
					return UnityEngine.Input.anyKey;
				}
			}

			// Token: 0x17000232 RID: 562
			// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0002D66A File Offset: 0x0002B86A
			public float unscaledTime
			{
				get
				{
					return Time.unscaledTime;
				}
			}

			// Token: 0x17000233 RID: 563
			// (get) Token: 0x06000B4E RID: 2894 RVA: 0x0002D671 File Offset: 0x0002B871
			public float doubleClickTime
			{
				get
				{
					return (float)Event.GetDoubleClickTime() * 0.001f;
				}
			}
		}

		// Token: 0x0200015C RID: 348
		private class NoInput : DefaultEventSystem.IInput
		{
			// Token: 0x06000B50 RID: 2896 RVA: 0x0000960A File Offset: 0x0000780A
			public bool GetButtonDown(string button)
			{
				return false;
			}

			// Token: 0x06000B51 RID: 2897 RVA: 0x0002D67F File Offset: 0x0002B87F
			public float GetAxisRaw(string axis)
			{
				return 0f;
			}

			// Token: 0x17000234 RID: 564
			// (get) Token: 0x06000B52 RID: 2898 RVA: 0x0000960A File Offset: 0x0000780A
			public int touchCount
			{
				get
				{
					return 0;
				}
			}

			// Token: 0x06000B53 RID: 2899 RVA: 0x0002D688 File Offset: 0x0002B888
			public Touch GetTouch(int index)
			{
				return default(Touch);
			}

			// Token: 0x06000B54 RID: 2900 RVA: 0x00003CD2 File Offset: 0x00001ED2
			public void ResetPenEvents()
			{
			}

			// Token: 0x06000B55 RID: 2901 RVA: 0x00003CD2 File Offset: 0x00001ED2
			public void ClearLastPenContactEvent()
			{
			}

			// Token: 0x17000235 RID: 565
			// (get) Token: 0x06000B56 RID: 2902 RVA: 0x0000960A File Offset: 0x0000780A
			public int penEventCount
			{
				get
				{
					return 0;
				}
			}

			// Token: 0x06000B57 RID: 2903 RVA: 0x0002D6A0 File Offset: 0x0002B8A0
			public PenData GetPenEvent(int index)
			{
				return default(PenData);
			}

			// Token: 0x06000B58 RID: 2904 RVA: 0x0002D6B8 File Offset: 0x0002B8B8
			public PenData GetLastPenContactEvent()
			{
				return default(PenData);
			}

			// Token: 0x17000236 RID: 566
			// (get) Token: 0x06000B59 RID: 2905 RVA: 0x0000960A File Offset: 0x0000780A
			public bool mousePresent
			{
				get
				{
					return false;
				}
			}

			// Token: 0x06000B5A RID: 2906 RVA: 0x0000960A File Offset: 0x0000780A
			public bool GetMouseButtonDown(int button)
			{
				return false;
			}

			// Token: 0x06000B5B RID: 2907 RVA: 0x0000960A File Offset: 0x0000780A
			public bool GetMouseButtonUp(int button)
			{
				return false;
			}

			// Token: 0x17000237 RID: 567
			// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0002D6D0 File Offset: 0x0002B8D0
			public Vector3 mousePosition
			{
				get
				{
					return default(Vector3);
				}
			}

			// Token: 0x17000238 RID: 568
			// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0002D6E8 File Offset: 0x0002B8E8
			public Vector2 mouseScrollDelta
			{
				get
				{
					return default(Vector2);
				}
			}

			// Token: 0x17000239 RID: 569
			// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0000960A File Offset: 0x0000780A
			public int mouseButtonCount
			{
				get
				{
					return 0;
				}
			}

			// Token: 0x1700023A RID: 570
			// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0000960A File Offset: 0x0000780A
			public bool anyKey
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700023B RID: 571
			// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0002D67F File Offset: 0x0002B87F
			public float unscaledTime
			{
				get
				{
					return 0f;
				}
			}

			// Token: 0x1700023C RID: 572
			// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0002D6FE File Offset: 0x0002B8FE
			public float doubleClickTime
			{
				get
				{
					return float.PositiveInfinity;
				}
			}
		}
	}
}
