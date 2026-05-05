using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000218 RID: 536
	internal static class PointerEventHelper
	{
		// Token: 0x06000F90 RID: 3984 RVA: 0x000395BC File Offset: 0x000377BC
		public static EventBase GetPooled(EventType eventType, Vector3 mousePosition, Vector2 delta, int button, int clickCount, EventModifiers modifiers)
		{
			bool flag = eventType == EventType.MouseDown && !PointerDeviceState.HasAdditionalPressedButtons(PointerId.mousePointerId, button);
			EventBase pooled;
			if (flag)
			{
				pooled = PointerEventBase<PointerDownEvent>.GetPooled(eventType, mousePosition, delta, button, clickCount, modifiers);
			}
			else
			{
				bool flag2 = eventType == EventType.MouseUp && !PointerDeviceState.HasAdditionalPressedButtons(PointerId.mousePointerId, button);
				if (flag2)
				{
					pooled = PointerEventBase<PointerUpEvent>.GetPooled(eventType, mousePosition, delta, button, clickCount, modifiers);
				}
				else
				{
					pooled = PointerEventBase<PointerMoveEvent>.GetPooled(eventType, mousePosition, delta, button, clickCount, modifiers);
				}
			}
			return pooled;
		}
	}
}
