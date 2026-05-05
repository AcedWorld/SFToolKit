using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C4 RID: 452
	public interface IFocusEvent
	{
		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000DE6 RID: 3558
		Focusable relatedTarget { get; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000DE7 RID: 3559
		FocusChangeDirection direction { get; }
	}
}
