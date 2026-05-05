using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001FE RID: 510
	internal class NavigationEventDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000F0B RID: 3851 RVA: 0x00038940 File Offset: 0x00036B40
		public bool CanDispatchEvent(EventBase evt)
		{
			return evt is INavigationEvent;
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x0003895C File Offset: 0x00036B5C
		public void DispatchEvent(EventBase evt, IPanel panel)
		{
			bool flag = panel != null;
			if (flag)
			{
				if (evt.target == null)
				{
					evt.target = (panel.focusController.GetLeafFocusedElement() ?? panel.visualTree);
				}
				EventDispatchUtilities.PropagateEvent(evt);
			}
			evt.propagateToIMGUI = false;
			evt.stopDispatch = true;
		}
	}
}
