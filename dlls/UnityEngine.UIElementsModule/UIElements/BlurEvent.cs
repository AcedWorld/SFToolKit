using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C8 RID: 456
	public class BlurEvent : FocusEventBase<BlurEvent>
	{
		// Token: 0x06000DFB RID: 3579 RVA: 0x00036055 File Offset: 0x00034255
		static BlurEvent()
		{
			EventBase<BlurEvent>.SetCreateFunction(() => new BlurEvent());
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00036070 File Offset: 0x00034270
		protected internal override void PreDispatch(IPanel panel)
		{
			base.PreDispatch(panel);
			bool flag = base.relatedTarget == null;
			if (flag)
			{
				base.focusController.ProcessPendingFocusChange(null);
			}
		}
	}
}
