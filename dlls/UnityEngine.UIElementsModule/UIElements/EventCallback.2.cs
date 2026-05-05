using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001A8 RID: 424
	// (Invoke) Token: 0x06000D0C RID: 3340
	public delegate void EventCallback<in TEventType, in TCallbackArgs>(TEventType evt, TCallbackArgs userArgs);
}
