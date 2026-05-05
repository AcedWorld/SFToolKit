using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001CC RID: 460
	public class FocusEvent : FocusEventBase<FocusEvent>
	{
		// Token: 0x06000E08 RID: 3592 RVA: 0x0003610C File Offset: 0x0003430C
		static FocusEvent()
		{
			EventBase<FocusEvent>.SetCreateFunction(() => new FocusEvent());
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00036125 File Offset: 0x00034325
		protected internal override void PreDispatch(IPanel panel)
		{
			base.PreDispatch(panel);
			base.focusController.ProcessPendingFocusChange(base.target as Focusable);
		}
	}
}
