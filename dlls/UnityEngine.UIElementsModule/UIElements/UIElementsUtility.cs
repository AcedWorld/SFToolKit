using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x02000380 RID: 896
	internal class UIElementsUtility : IUIElementsUtility
	{
		// Token: 0x06001E46 RID: 7750 RVA: 0x00074E2D File Offset: 0x0007302D
		private UIElementsUtility()
		{
			UIEventRegistration.RegisterUIElementSystem(this);
		}

		// Token: 0x06001E47 RID: 7751 RVA: 0x00074E40 File Offset: 0x00073040
		internal static IMGUIContainer GetCurrentIMGUIContainer()
		{
			bool flag = UIElementsUtility.s_ContainerStack.Count > 0;
			IMGUIContainer result;
			if (flag)
			{
				result = UIElementsUtility.s_ContainerStack.Peek();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001E48 RID: 7752 RVA: 0x00074E74 File Offset: 0x00073074
		bool IUIElementsUtility.MakeCurrentIMGUIContainerDirty()
		{
			bool flag = UIElementsUtility.s_ContainerStack.Count > 0;
			bool result;
			if (flag)
			{
				UIElementsUtility.s_ContainerStack.Peek().MarkDirtyLayout();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001E49 RID: 7753 RVA: 0x00074EB0 File Offset: 0x000730B0
		bool IUIElementsUtility.TakeCapture()
		{
			bool flag = UIElementsUtility.s_ContainerStack.Count > 0;
			bool result;
			if (flag)
			{
				IMGUIContainer handler = UIElementsUtility.s_ContainerStack.Peek();
				handler.CaptureMouse();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001E4A RID: 7754 RVA: 0x00074EEC File Offset: 0x000730EC
		bool IUIElementsUtility.ReleaseCapture()
		{
			return false;
		}

		// Token: 0x06001E4B RID: 7755 RVA: 0x00074F00 File Offset: 0x00073100
		bool IUIElementsUtility.ProcessEvent(int instanceID, IntPtr nativeEventPtr, ref bool eventHandled)
		{
			Panel panel;
			bool flag = nativeEventPtr != IntPtr.Zero && UIElementsUtility.s_UIElementsCache.TryGetValue(instanceID, out panel);
			bool result;
			if (flag)
			{
				bool flag2 = panel.contextType == ContextType.Editor;
				if (flag2)
				{
					UIElementsUtility.s_EventInstance.CopyFromPtr(nativeEventPtr);
					eventHandled = UIElementsUtility.DoDispatch(panel);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001E4C RID: 7756 RVA: 0x00074F5C File Offset: 0x0007315C
		bool IUIElementsUtility.CleanupRoots()
		{
			UIElementsUtility.s_EventInstance = null;
			UIElementsUtility.s_UIElementsCache = null;
			UIElementsUtility.s_ContainerStack = null;
			return false;
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x00074F84 File Offset: 0x00073184
		bool IUIElementsUtility.EndContainerGUIFromException(Exception exception)
		{
			bool flag = UIElementsUtility.s_ContainerStack.Count > 0;
			if (flag)
			{
				GUIUtility.EndContainer();
				UIElementsUtility.s_ContainerStack.Pop();
			}
			return false;
		}

		// Token: 0x06001E4E RID: 7758 RVA: 0x00074FBC File Offset: 0x000731BC
		void IUIElementsUtility.UpdateSchedulers()
		{
			UIElementsUtility.s_PanelsIterationList.Clear();
			UIElementsUtility.GetAllPanels(UIElementsUtility.s_PanelsIterationList, ContextType.Editor);
			foreach (Panel panel in UIElementsUtility.s_PanelsIterationList)
			{
				panel.timerEventScheduler.UpdateScheduledEvents();
				panel.ValidateFocus();
				panel.UpdateAnimations();
				panel.UpdateBindings();
			}
		}

		// Token: 0x06001E4F RID: 7759 RVA: 0x00075044 File Offset: 0x00073244
		void IUIElementsUtility.RequestRepaintForPanels(Action<ScriptableObject> repaintCallback)
		{
			Dictionary<int, Panel>.Enumerator panelsIterator = UIElementsUtility.GetPanelsIterator();
			while (panelsIterator.MoveNext())
			{
				KeyValuePair<int, Panel> keyValuePair = panelsIterator.Current;
				Panel value = keyValuePair.Value;
				bool flag = value.contextType != ContextType.Editor;
				if (!flag)
				{
					bool isDirty = value.isDirty;
					if (isDirty)
					{
						repaintCallback(value.ownerObject);
					}
				}
			}
		}

		// Token: 0x06001E50 RID: 7760 RVA: 0x000750A6 File Offset: 0x000732A6
		public static void RegisterCachedPanel(int instanceID, Panel panel)
		{
			UIElementsUtility.s_UIElementsCache.Add(instanceID, panel);
		}

		// Token: 0x06001E51 RID: 7761 RVA: 0x000750B6 File Offset: 0x000732B6
		public static void RemoveCachedPanel(int instanceID)
		{
			UIElementsUtility.s_UIElementsCache.Remove(instanceID);
		}

		// Token: 0x06001E52 RID: 7762 RVA: 0x000750C8 File Offset: 0x000732C8
		public static bool TryGetPanel(int instanceID, out Panel panel)
		{
			return UIElementsUtility.s_UIElementsCache.TryGetValue(instanceID, out panel);
		}

		// Token: 0x06001E53 RID: 7763 RVA: 0x000750E8 File Offset: 0x000732E8
		internal static void BeginContainerGUI(GUILayoutUtility.LayoutCache cache, Event evt, IMGUIContainer container)
		{
			bool useOwnerObjectGUIState = container.useOwnerObjectGUIState;
			if (useOwnerObjectGUIState)
			{
				GUIUtility.BeginContainerFromOwner(container.elementPanel.ownerObject);
			}
			else
			{
				GUIUtility.BeginContainer(container.guiState);
			}
			UIElementsUtility.s_ContainerStack.Push(container);
			GUIUtility.s_SkinMode = (int)container.contextType;
			GUIUtility.s_OriginalID = container.elementPanel.ownerObject.GetInstanceID();
			bool flag = Event.current == null;
			if (flag)
			{
				Event.current = evt;
			}
			else
			{
				Event.current.CopyFrom(evt);
			}
			GUI.enabled = container.enabledInHierarchy;
			GUILayoutUtility.BeginContainer(cache);
			GUIUtility.ResetGlobalState();
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x00075190 File Offset: 0x00073390
		internal static void EndContainerGUI(Event evt, Rect layoutSize)
		{
			bool flag = Event.current.type == EventType.Layout && UIElementsUtility.s_ContainerStack.Count > 0;
			if (flag)
			{
				GUILayoutUtility.LayoutFromContainer(layoutSize.width, layoutSize.height);
			}
			GUILayoutUtility.SelectIDList(GUIUtility.s_OriginalID, false);
			GUIContent.ClearStaticCache();
			bool flag2 = UIElementsUtility.s_ContainerStack.Count > 0;
			if (flag2)
			{
			}
			evt.CopyFrom(Event.current);
			bool flag3 = UIElementsUtility.s_ContainerStack.Count > 0;
			if (flag3)
			{
				GUIUtility.EndContainer();
				UIElementsUtility.s_ContainerStack.Pop();
			}
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x0007522C File Offset: 0x0007342C
		internal static EventBase CreateEvent(Event systemEvent)
		{
			return UIElementsUtility.CreateEvent(systemEvent, systemEvent.rawType);
		}

		// Token: 0x06001E56 RID: 7766 RVA: 0x0007524C File Offset: 0x0007344C
		internal static EventBase CreateEvent(Event systemEvent, EventType eventType)
		{
			switch (eventType)
			{
			case EventType.MouseDown:
				goto IL_97;
			case EventType.MouseUp:
				goto IL_C2;
			case EventType.MouseMove:
				break;
			case EventType.MouseDrag:
				return PointerEventBase<PointerMoveEvent>.GetPooled(systemEvent);
			case EventType.KeyDown:
				return KeyboardEventBase<KeyDownEvent>.GetPooled(systemEvent);
			case EventType.KeyUp:
				return KeyboardEventBase<KeyUpEvent>.GetPooled(systemEvent);
			case EventType.ScrollWheel:
				return WheelEvent.GetPooled(systemEvent);
			case EventType.Repaint:
			case EventType.Layout:
			case EventType.DragUpdated:
			case EventType.DragPerform:
			case EventType.Ignore:
			case EventType.Used:
			case EventType.DragExited:
			case (EventType)17:
			case (EventType)18:
			case (EventType)19:
				goto IL_134;
			case EventType.ValidateCommand:
				return CommandEventBase<ValidateCommandEvent>.GetPooled(systemEvent);
			case EventType.ExecuteCommand:
				return CommandEventBase<ExecuteCommandEvent>.GetPooled(systemEvent);
			case EventType.ContextClick:
				return MouseEventBase<ContextClickEvent>.GetPooled(systemEvent);
			case EventType.MouseEnterWindow:
				return MouseEventBase<MouseEnterWindowEvent>.GetPooled(systemEvent);
			case EventType.MouseLeaveWindow:
				return MouseLeaveWindowEvent.GetPooled(systemEvent);
			default:
				switch (eventType)
				{
				case EventType.TouchDown:
					goto IL_97;
				case EventType.TouchUp:
					goto IL_C2;
				case EventType.TouchMove:
					break;
				default:
					goto IL_134;
				}
				break;
			}
			return PointerEventBase<PointerMoveEvent>.GetPooled(systemEvent);
			IL_97:
			bool flag = PointerDeviceState.HasAdditionalPressedButtons(PointerId.mousePointerId, systemEvent.button);
			if (flag)
			{
				return PointerEventBase<PointerMoveEvent>.GetPooled(systemEvent);
			}
			return PointerEventBase<PointerDownEvent>.GetPooled(systemEvent);
			IL_C2:
			bool flag2 = PointerDeviceState.HasAdditionalPressedButtons(PointerId.mousePointerId, systemEvent.button);
			if (flag2)
			{
				return PointerEventBase<PointerMoveEvent>.GetPooled(systemEvent);
			}
			return PointerEventBase<PointerUpEvent>.GetPooled(systemEvent);
			IL_134:
			return IMGUIEvent.GetPooled(systemEvent);
		}

		// Token: 0x06001E57 RID: 7767 RVA: 0x00075398 File Offset: 0x00073598
		private static bool DoDispatch(BaseVisualElementPanel panel)
		{
			Debug.Assert(panel.contextType == ContextType.Editor);
			bool result = false;
			bool flag = UIElementsUtility.s_EventInstance.type == EventType.Repaint;
			if (flag)
			{
				Camera current = Camera.current;
				RenderTexture active = RenderTexture.active;
				Camera.SetupCurrent(null);
				RenderTexture.active = null;
				using (UIElementsUtility.s_RepaintProfilerMarker.Auto())
				{
					panel.Repaint(UIElementsUtility.s_EventInstance);
				}
				result = (panel.IMGUIContainersCount > 0);
				Camera.SetupCurrent(current);
				RenderTexture.active = active;
			}
			else
			{
				panel.ValidateLayout();
				using (EventBase eventBase = UIElementsUtility.CreateEvent(UIElementsUtility.s_EventInstance))
				{
					bool flag2 = UIElementsUtility.s_EventInstance.type == EventType.Used || UIElementsUtility.s_EventInstance.type == EventType.Layout || UIElementsUtility.s_EventInstance.type == EventType.ExecuteCommand || UIElementsUtility.s_EventInstance.type == EventType.ValidateCommand;
					using (UIElementsUtility.s_EventProfilerMarker.Auto())
					{
						panel.SendEvent(eventBase, flag2 ? DispatchMode.Immediate : DispatchMode.Default);
					}
					bool isPropagationStopped = eventBase.isPropagationStopped;
					if (isPropagationStopped)
					{
						panel.visualTree.IncrementVersion(VersionChangeType.Repaint);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06001E58 RID: 7768 RVA: 0x00075514 File Offset: 0x00073714
		internal static void GetAllPanels(List<Panel> panels, ContextType contextType)
		{
			Dictionary<int, Panel>.Enumerator panelsIterator = UIElementsUtility.GetPanelsIterator();
			while (panelsIterator.MoveNext())
			{
				KeyValuePair<int, Panel> keyValuePair = panelsIterator.Current;
				bool flag = keyValuePair.Value.contextType == contextType;
				if (flag)
				{
					keyValuePair = panelsIterator.Current;
					panels.Add(keyValuePair.Value);
				}
			}
		}

		// Token: 0x06001E59 RID: 7769 RVA: 0x0007556C File Offset: 0x0007376C
		internal static Dictionary<int, Panel>.Enumerator GetPanelsIterator()
		{
			return UIElementsUtility.s_UIElementsCache.GetEnumerator();
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x00075588 File Offset: 0x00073788
		internal static Panel FindOrCreateEditorPanel(ScriptableObject ownerObject)
		{
			Panel panel;
			bool flag = !UIElementsUtility.s_UIElementsCache.TryGetValue(ownerObject.GetInstanceID(), out panel);
			if (flag)
			{
				panel = Panel.CreateEditorPanel(ownerObject);
				UIElementsUtility.RegisterCachedPanel(ownerObject.GetInstanceID(), panel);
			}
			else
			{
				Debug.Assert(ContextType.Editor == panel.contextType, "Panel is not an editor panel.");
			}
			return panel;
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x000755E4 File Offset: 0x000737E4
		internal static float PixelsPerUnitScaleForElement(VisualElement ve, Sprite sprite)
		{
			bool flag = ve == null || ve.elementPanel == null || sprite == null;
			float result;
			if (flag)
			{
				result = 1f;
			}
			else
			{
				float referenceSpritePixelsPerUnit = ve.elementPanel.referenceSpritePixelsPerUnit;
				float num = sprite.pixelsPerUnit;
				num = Mathf.Max(0.01f, num);
				result = referenceSpritePixelsPerUnit / num;
			}
			return result;
		}

		// Token: 0x06001E5C RID: 7772 RVA: 0x0007563C File Offset: 0x0007383C
		internal static string ParseMenuName(string menuName)
		{
			bool flag = string.IsNullOrEmpty(menuName);
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				string text = menuName.TrimEnd();
				int num = text.LastIndexOf(' ');
				bool flag2 = num > -1;
				if (flag2)
				{
					int num2 = Array.IndexOf<char>(UIElementsUtility.s_Modifiers, text[num + 1]);
					bool flag3 = text.Length > num + 1 && num2 > -1;
					if (flag3)
					{
						text = text.Substring(0, num).TrimEnd();
					}
				}
				result = text;
			}
			return result;
		}

		// Token: 0x04000C90 RID: 3216
		private static Stack<IMGUIContainer> s_ContainerStack = new Stack<IMGUIContainer>();

		// Token: 0x04000C91 RID: 3217
		private static Dictionary<int, Panel> s_UIElementsCache = new Dictionary<int, Panel>();

		// Token: 0x04000C92 RID: 3218
		private static Event s_EventInstance = new Event();

		// Token: 0x04000C93 RID: 3219
		internal static Color editorPlayModeTintColor = Color.white;

		// Token: 0x04000C94 RID: 3220
		internal static float singleLineHeight = 18f;

		// Token: 0x04000C95 RID: 3221
		public const string hiddenClassName = "unity-hidden";

		// Token: 0x04000C96 RID: 3222
		private static UIElementsUtility s_Instance = new UIElementsUtility();

		// Token: 0x04000C97 RID: 3223
		internal static List<Panel> s_PanelsIterationList = new List<Panel>();

		// Token: 0x04000C98 RID: 3224
		internal static readonly string s_RepaintProfilerMarkerName = "UIElementsUtility.DoDispatch(Repaint Event)";

		// Token: 0x04000C99 RID: 3225
		internal static readonly string s_EventProfilerMarkerName = "UIElementsUtility.DoDispatch(Non Repaint Event)";

		// Token: 0x04000C9A RID: 3226
		private static readonly ProfilerMarker s_RepaintProfilerMarker = new ProfilerMarker(UIElementsUtility.s_RepaintProfilerMarkerName);

		// Token: 0x04000C9B RID: 3227
		private static readonly ProfilerMarker s_EventProfilerMarker = new ProfilerMarker(UIElementsUtility.s_EventProfilerMarkerName);

		// Token: 0x04000C9C RID: 3228
		internal static char[] s_Modifiers = new char[]
		{
			'&',
			'%',
			'^',
			'#',
			'_'
		};
	}
}
