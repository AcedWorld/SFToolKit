using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000277 RID: 631
	public static class MouseCaptureController
	{
		// Token: 0x060011DA RID: 4570 RVA: 0x00040B94 File Offset: 0x0003ED94
		public static bool IsMouseCaptured()
		{
			bool flag = !MouseCaptureController.m_IsMouseCapturedWarningEmitted;
			if (flag)
			{
				Debug.LogError("MouseCaptureController.IsMouseCaptured() can not be used in playmode. Please use PointerCaptureHelper.GetCapturingElement() instead.");
				MouseCaptureController.m_IsMouseCapturedWarningEmitted = true;
			}
			return false;
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x00040BC8 File Offset: 0x0003EDC8
		public static bool HasMouseCapture(this IEventHandler handler)
		{
			VisualElement handler2 = handler as VisualElement;
			return handler2.HasPointerCapture(PointerId.mousePointerId);
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x00040BEC File Offset: 0x0003EDEC
		public static void CaptureMouse(this IEventHandler handler)
		{
			VisualElement visualElement = handler as VisualElement;
			bool flag = visualElement != null;
			if (flag)
			{
				visualElement.CapturePointer(PointerId.mousePointerId);
				visualElement.panel.ProcessPointerCapture(PointerId.mousePointerId);
			}
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x00040C28 File Offset: 0x0003EE28
		public static void ReleaseMouse(this IEventHandler handler)
		{
			VisualElement visualElement = handler as VisualElement;
			bool flag = visualElement != null;
			if (flag)
			{
				visualElement.ReleasePointer(PointerId.mousePointerId);
				visualElement.panel.ProcessPointerCapture(PointerId.mousePointerId);
			}
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x00040C64 File Offset: 0x0003EE64
		public static void ReleaseMouse()
		{
			bool flag = !MouseCaptureController.m_ReleaseMouseWarningEmitted;
			if (flag)
			{
				Debug.LogError("MouseCaptureController.ReleaseMouse() can not be used in playmode. Please use PointerCaptureHelper.GetCapturingElement() instead.");
				MouseCaptureController.m_ReleaseMouseWarningEmitted = true;
			}
		}

		// Token: 0x040007E9 RID: 2025
		private static bool m_IsMouseCapturedWarningEmitted;

		// Token: 0x040007EA RID: 2026
		private static bool m_ReleaseMouseWarningEmitted;
	}
}
