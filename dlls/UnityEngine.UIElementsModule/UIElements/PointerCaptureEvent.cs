using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200018D RID: 397
	public class PointerCaptureEvent : PointerCaptureEventBase<PointerCaptureEvent>
	{
		// Token: 0x06000C6A RID: 3178 RVA: 0x00031A6E File Offset: 0x0002FC6E
		static PointerCaptureEvent()
		{
			EventBase<PointerCaptureEvent>.SetCreateFunction(() => new PointerCaptureEvent());
		}
	}
}
