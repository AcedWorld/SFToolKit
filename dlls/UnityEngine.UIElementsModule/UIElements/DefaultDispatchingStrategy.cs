using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001A0 RID: 416
	internal class DefaultDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000CA2 RID: 3234 RVA: 0x00031E8C File Offset: 0x0003008C
		public bool CanDispatchEvent(EventBase evt)
		{
			return !(evt is IMGUIEvent);
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x00031EAC File Offset: 0x000300AC
		public void DispatchEvent(EventBase evt, IPanel panel)
		{
			VisualElement visualElement = evt.target as VisualElement;
			bool flag = visualElement != null && visualElement.panel == panel;
			if (flag)
			{
				evt.propagateToIMGUI = visualElement.isIMGUIContainer;
				EventDispatchUtilities.PropagateEvent(evt);
			}
			else
			{
				bool flag2 = !evt.isPropagationStopped && panel != null;
				if (flag2)
				{
					bool flag3 = evt.propagateToIMGUI || evt.eventTypeId == EventBase<MouseEnterWindowEvent>.TypeId() || evt.eventTypeId == EventBase<MouseLeaveWindowEvent>.TypeId();
					if (flag3)
					{
						EventDispatchUtilities.PropagateToIMGUIContainer(panel.visualTree, evt);
					}
				}
			}
			evt.stopDispatch = true;
		}
	}
}
