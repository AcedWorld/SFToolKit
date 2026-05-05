using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001DA RID: 474
	public class KeyUpEvent : KeyboardEventBase<KeyUpEvent>
	{
		// Token: 0x06000E49 RID: 3657 RVA: 0x00036DC8 File Offset: 0x00034FC8
		static KeyUpEvent()
		{
			EventBase<KeyUpEvent>.SetCreateFunction(() => new KeyUpEvent());
		}
	}
}
