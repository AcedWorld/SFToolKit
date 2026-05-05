using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200029D RID: 669
	public static class PointerCaptureHelper
	{
		// Token: 0x06001328 RID: 4904 RVA: 0x00042D40 File Offset: 0x00040F40
		private static PointerDispatchState GetStateFor(IEventHandler handler)
		{
			VisualElement visualElement = handler as VisualElement;
			PointerDispatchState result;
			if (visualElement == null)
			{
				result = null;
			}
			else
			{
				IPanel panel = visualElement.panel;
				if (panel == null)
				{
					result = null;
				}
				else
				{
					EventDispatcher dispatcher = panel.dispatcher;
					result = ((dispatcher != null) ? dispatcher.pointerState : null);
				}
			}
			return result;
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x00042D80 File Offset: 0x00040F80
		public static bool HasPointerCapture(this IEventHandler handler, int pointerId)
		{
			PointerDispatchState stateFor = PointerCaptureHelper.GetStateFor(handler);
			return stateFor != null && stateFor.HasPointerCapture(handler, pointerId);
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x00042DA6 File Offset: 0x00040FA6
		public static void CapturePointer(this IEventHandler handler, int pointerId)
		{
			PointerDispatchState stateFor = PointerCaptureHelper.GetStateFor(handler);
			if (stateFor != null)
			{
				stateFor.CapturePointer(handler, pointerId);
			}
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x00042DBD File Offset: 0x00040FBD
		public static void ReleasePointer(this IEventHandler handler, int pointerId)
		{
			PointerDispatchState stateFor = PointerCaptureHelper.GetStateFor(handler);
			if (stateFor != null)
			{
				stateFor.ReleasePointer(handler, pointerId);
			}
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x00042DD4 File Offset: 0x00040FD4
		public static IEventHandler GetCapturingElement(this IPanel panel, int pointerId)
		{
			IEventHandler result;
			if (panel == null)
			{
				result = null;
			}
			else
			{
				EventDispatcher dispatcher = panel.dispatcher;
				result = ((dispatcher != null) ? dispatcher.pointerState.GetCapturingElement(pointerId) : null);
			}
			return result;
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x00042E04 File Offset: 0x00041004
		public static void ReleasePointer(this IPanel panel, int pointerId)
		{
			if (panel != null)
			{
				EventDispatcher dispatcher = panel.dispatcher;
				if (dispatcher != null)
				{
					dispatcher.pointerState.ReleasePointer(pointerId);
				}
			}
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x00042E24 File Offset: 0x00041024
		internal static void ActivateCompatibilityMouseEvents(this IPanel panel, int pointerId)
		{
			if (panel != null)
			{
				EventDispatcher dispatcher = panel.dispatcher;
				if (dispatcher != null)
				{
					dispatcher.pointerState.ActivateCompatibilityMouseEvents(pointerId);
				}
			}
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x00042E44 File Offset: 0x00041044
		internal static void PreventCompatibilityMouseEvents(this IPanel panel, int pointerId)
		{
			if (panel != null)
			{
				EventDispatcher dispatcher = panel.dispatcher;
				if (dispatcher != null)
				{
					dispatcher.pointerState.PreventCompatibilityMouseEvents(pointerId);
				}
			}
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x00042E64 File Offset: 0x00041064
		internal static bool ShouldSendCompatibilityMouseEvents(this IPanel panel, IPointerEvent evt)
		{
			bool? flag;
			if (panel == null)
			{
				flag = null;
			}
			else
			{
				EventDispatcher dispatcher = panel.dispatcher;
				flag = ((dispatcher != null) ? new bool?(dispatcher.pointerState.ShouldSendCompatibilityMouseEvents(evt)) : null);
			}
			return flag ?? true;
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x00042EBD File Offset: 0x000410BD
		internal static void ProcessPointerCapture(this IPanel panel, int pointerId)
		{
			if (panel != null)
			{
				EventDispatcher dispatcher = panel.dispatcher;
				if (dispatcher != null)
				{
					dispatcher.pointerState.ProcessPointerCapture(pointerId);
				}
			}
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x00042EDD File Offset: 0x000410DD
		internal static void ResetPointerDispatchState(this IPanel panel)
		{
			if (panel != null)
			{
				EventDispatcher dispatcher = panel.dispatcher;
				if (dispatcher != null)
				{
					dispatcher.pointerState.Reset();
				}
			}
		}
	}
}
