using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001D1 RID: 465
	internal class IMGUIEventDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000E14 RID: 3604 RVA: 0x00036684 File Offset: 0x00034884
		public bool CanDispatchEvent(EventBase evt)
		{
			return evt is IMGUIEvent;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x000366A0 File Offset: 0x000348A0
		public void DispatchEvent(EventBase evt, IPanel panel)
		{
			bool flag = panel != null;
			if (flag)
			{
				EventDispatchUtilities.PropagateToIMGUIContainer(panel.visualTree, evt);
			}
			evt.propagateToIMGUI = false;
			evt.stopDispatch = true;
		}
	}
}
