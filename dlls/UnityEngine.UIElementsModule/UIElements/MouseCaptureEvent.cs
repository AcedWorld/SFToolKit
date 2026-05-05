using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000193 RID: 403
	public class MouseCaptureEvent : MouseCaptureEventBase<MouseCaptureEvent>
	{
		// Token: 0x06000C78 RID: 3192 RVA: 0x00031B10 File Offset: 0x0002FD10
		static MouseCaptureEvent()
		{
			EventBase<MouseCaptureEvent>.SetCreateFunction(() => new MouseCaptureEvent());
		}
	}
}
