using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000252 RID: 594
	internal static class RuntimeEventDispatcher
	{
		// Token: 0x06001111 RID: 4369 RVA: 0x0003DA38 File Offset: 0x0003BC38
		public static EventDispatcher Create()
		{
			return EventDispatcher.CreateForRuntime(new List<IEventDispatchingStrategy>
			{
				new PointerCaptureDispatchingStrategy(),
				new MouseCaptureDispatchingStrategy(),
				new KeyboardEventDispatchingStrategy(),
				new PointerEventDispatchingStrategy(),
				new MouseEventDispatchingStrategy(),
				new NavigationEventDispatchingStrategy(),
				new DefaultDispatchingStrategy()
			});
		}
	}
}
