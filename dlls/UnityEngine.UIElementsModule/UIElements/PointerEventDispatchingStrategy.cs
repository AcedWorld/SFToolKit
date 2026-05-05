using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000213 RID: 531
	internal class PointerEventDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000F69 RID: 3945 RVA: 0x0003933C File Offset: 0x0003753C
		public bool CanDispatchEvent(EventBase evt)
		{
			return evt is IPointerEvent;
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00039357 File Offset: 0x00037557
		public virtual void DispatchEvent(EventBase evt, IPanel panel)
		{
			PointerEventDispatchingStrategy.SetBestTargetForEvent(evt, panel);
			PointerEventDispatchingStrategy.SendEventToTarget(evt, panel);
			evt.stopDispatch = true;
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00039374 File Offset: 0x00037574
		private static void SendEventToTarget(EventBase evt, IPanel panel)
		{
			VisualElement visualElement = evt.target as VisualElement;
			bool flag = visualElement != null && visualElement.panel == panel;
			if (flag)
			{
				EventDispatchUtilities.PropagateEvent(evt);
			}
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x000393AC File Offset: 0x000375AC
		private static void SetBestTargetForEvent(EventBase evt, IPanel panel)
		{
			VisualElement visualElement;
			PointerEventDispatchingStrategy.UpdateElementUnderPointer(evt, panel, out visualElement);
			bool flag = evt.target == null && visualElement != null;
			if (flag)
			{
				evt.propagateToIMGUI = false;
				evt.target = visualElement;
			}
			else
			{
				bool flag2 = evt.target == null && visualElement == null;
				if (flag2)
				{
					bool flag3 = panel != null && panel.contextType == ContextType.Editor && evt.eventTypeId == EventBase<PointerUpEvent>.TypeId();
					if (flag3)
					{
						Panel panel2 = panel as Panel;
						evt.target = ((panel2 != null) ? panel2.rootIMGUIContainer : null);
					}
					else
					{
						evt.target = ((panel != null) ? panel.visualTree : null);
					}
				}
				else
				{
					bool flag4 = evt.target != null;
					if (flag4)
					{
						evt.propagateToIMGUI = false;
					}
				}
			}
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x0003946C File Offset: 0x0003766C
		private static void UpdateElementUnderPointer(EventBase evt, IPanel panel, out VisualElement elementUnderPointer)
		{
			IPointerEvent pointerEvent = evt as IPointerEvent;
			BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
			IPointerEventInternal pointerEventInternal = evt as IPointerEventInternal;
			elementUnderPointer = ((pointerEventInternal == null || pointerEventInternal.recomputeTopElementUnderPointer) ? ((baseVisualElementPanel != null) ? baseVisualElementPanel.RecomputeTopElementUnderPointer(pointerEvent.pointerId, pointerEvent.position, evt) : null) : ((baseVisualElementPanel != null) ? baseVisualElementPanel.GetTopElementUnderPointer(pointerEvent.pointerId) : null));
		}
	}
}
