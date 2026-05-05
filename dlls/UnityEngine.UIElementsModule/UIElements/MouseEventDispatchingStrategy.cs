using System;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E0 RID: 480
	internal class MouseEventDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000E5F RID: 3679 RVA: 0x00037120 File Offset: 0x00035320
		public bool CanDispatchEvent(EventBase evt)
		{
			return evt is IMouseEvent;
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x0003713C File Offset: 0x0003533C
		public void DispatchEvent(EventBase evt, IPanel iPanel)
		{
			bool flag = iPanel != null;
			if (flag)
			{
				Assert.IsTrue(iPanel is BaseVisualElementPanel);
				BaseVisualElementPanel panel = (BaseVisualElementPanel)iPanel;
				MouseEventDispatchingStrategy.SetBestTargetForEvent(evt, panel);
				MouseEventDispatchingStrategy.SendEventToTarget(evt, panel);
			}
			evt.stopDispatch = true;
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00037184 File Offset: 0x00035384
		private static bool SendEventToTarget(EventBase evt, BaseVisualElementPanel panel)
		{
			return MouseEventDispatchingStrategy.SendEventToRegularTarget(evt, panel) || MouseEventDispatchingStrategy.SendEventToIMGUIContainer(evt, panel);
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x000371AC File Offset: 0x000353AC
		private static bool SendEventToRegularTarget(EventBase evt, BaseVisualElementPanel panel)
		{
			VisualElement visualElement = evt.target as VisualElement;
			bool flag = visualElement == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = visualElement.panel == panel;
				if (flag2)
				{
					EventDispatchUtilities.PropagateEvent(evt);
				}
				result = MouseEventDispatchingStrategy.IsDone(evt);
			}
			return result;
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x000371F4 File Offset: 0x000353F4
		private static bool SendEventToIMGUIContainer(EventBase evt, BaseVisualElementPanel panel)
		{
			bool flag = evt.imguiEvent == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				IMGUIContainer rootIMGUIContainer = panel.rootIMGUIContainer;
				bool flag2 = rootIMGUIContainer == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = evt.propagateToIMGUI || evt.eventTypeId == EventBase<MouseEnterWindowEvent>.TypeId() || evt.eventTypeId == EventBase<MouseLeaveWindowEvent>.TypeId();
					if (flag3)
					{
						evt.skipElements.Add(evt.target);
						EventDispatchUtilities.PropagateToIMGUIContainer(panel.visualTree, evt);
					}
					result = MouseEventDispatchingStrategy.IsDone(evt);
				}
			}
			return result;
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x0003727C File Offset: 0x0003547C
		private static void SetBestTargetForEvent(EventBase evt, BaseVisualElementPanel panel)
		{
			VisualElement visualElement;
			MouseEventDispatchingStrategy.UpdateElementUnderMouse(evt, panel, out visualElement);
			bool flag = evt.target != null;
			if (flag)
			{
				evt.propagateToIMGUI = false;
			}
			else
			{
				bool flag2 = visualElement != null;
				if (flag2)
				{
					evt.propagateToIMGUI = false;
					evt.target = visualElement;
				}
				else
				{
					evt.target = ((panel != null) ? panel.visualTree : null);
				}
			}
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x000372E0 File Offset: 0x000354E0
		private static void UpdateElementUnderMouse(EventBase evt, BaseVisualElementPanel panel, out VisualElement elementUnderMouse)
		{
			IMouseEventInternal mouseEventInternal = evt as IMouseEventInternal;
			elementUnderMouse = ((mouseEventInternal == null || mouseEventInternal.recomputeTopElementUnderMouse) ? panel.RecomputeTopElementUnderPointer(PointerId.mousePointerId, ((IMouseEvent)evt).mousePosition, evt) : panel.GetTopElementUnderPointer(PointerId.mousePointerId));
			bool flag = evt.eventTypeId == EventBase<MouseLeaveWindowEvent>.TypeId() && (evt as MouseLeaveWindowEvent).pressedButtons == 0;
			if (flag)
			{
				panel.ClearCachedElementUnderPointer(PointerId.mousePointerId, evt);
			}
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x0003735C File Offset: 0x0003555C
		private static bool IsDone(EventBase evt)
		{
			Event imguiEvent = evt.imguiEvent;
			bool flag = imguiEvent != null && imguiEvent.rawType == EventType.Used;
			if (flag)
			{
				evt.StopPropagation();
			}
			return evt.isPropagationStopped;
		}
	}
}
