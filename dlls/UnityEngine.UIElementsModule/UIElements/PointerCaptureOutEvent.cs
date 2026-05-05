using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200018B RID: 395
	public class PointerCaptureOutEvent : PointerCaptureEventBase<PointerCaptureOutEvent>
	{
		// Token: 0x06000C65 RID: 3173 RVA: 0x00031A39 File Offset: 0x0002FC39
		static PointerCaptureOutEvent()
		{
			EventBase<PointerCaptureOutEvent>.SetCreateFunction(() => new PointerCaptureOutEvent());
		}
	}
}
