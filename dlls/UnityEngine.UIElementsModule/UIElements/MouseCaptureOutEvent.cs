using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000191 RID: 401
	public class MouseCaptureOutEvent : MouseCaptureEventBase<MouseCaptureOutEvent>
	{
		// Token: 0x06000C73 RID: 3187 RVA: 0x00031ADB File Offset: 0x0002FCDB
		static MouseCaptureOutEvent()
		{
			EventBase<MouseCaptureOutEvent>.SetCreateFunction(() => new MouseCaptureOutEvent());
		}
	}
}
