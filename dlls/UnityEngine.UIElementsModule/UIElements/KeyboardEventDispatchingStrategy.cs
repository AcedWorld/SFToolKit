using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001D4 RID: 468
	internal class KeyboardEventDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000E23 RID: 3619 RVA: 0x0003678C File Offset: 0x0003498C
		public bool CanDispatchEvent(EventBase evt)
		{
			return evt is IKeyboardEvent;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x000367A8 File Offset: 0x000349A8
		public void DispatchEvent(EventBase evt, IPanel panel)
		{
			bool flag = panel != null;
			if (flag)
			{
				Focusable leafFocusedElement = panel.focusController.GetLeafFocusedElement();
				bool flag2 = leafFocusedElement != null;
				if (flag2)
				{
					evt.target = leafFocusedElement;
					bool isIMGUIContainer = leafFocusedElement.isIMGUIContainer;
					if (isIMGUIContainer)
					{
						IMGUIContainer imguicontainer = (IMGUIContainer)leafFocusedElement;
						bool flag3 = !evt.Skip(imguicontainer) && imguicontainer.SendEventToIMGUI(evt, true, true);
						if (flag3)
						{
							evt.StopPropagation();
							evt.PreventDefault();
						}
					}
					else
					{
						EventDispatchUtilities.PropagateEvent(evt);
					}
				}
				else
				{
					evt.target = panel.visualTree;
					EventDispatchUtilities.PropagateEvent(evt);
					bool flag4 = !evt.isPropagationStopped;
					if (flag4)
					{
						EventDispatchUtilities.PropagateToIMGUIContainer(panel.visualTree, evt);
					}
				}
			}
			evt.propagateToIMGUI = false;
			evt.stopDispatch = true;
		}
	}
}
