using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000247 RID: 583
	public interface IFocusRing
	{
		// Token: 0x06001096 RID: 4246
		FocusChangeDirection GetFocusChangeDirection(Focusable currentFocusable, EventBase e);

		// Token: 0x06001097 RID: 4247
		Focusable GetNextFocusable(Focusable currentFocusable, FocusChangeDirection direction);
	}
}
