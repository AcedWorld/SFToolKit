using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200037E RID: 894
	internal static class UIEventRegistration
	{
		// Token: 0x06001E34 RID: 7732 RVA: 0x000749E4 File Offset: 0x00072BE4
		static UIEventRegistration()
		{
			GUIUtility.takeCapture = (Action)Delegate.Combine(GUIUtility.takeCapture, new Action(delegate()
			{
				UIEventRegistration.TakeCapture();
			}));
			GUIUtility.releaseCapture = (Action)Delegate.Combine(GUIUtility.releaseCapture, new Action(delegate()
			{
				UIEventRegistration.ReleaseCapture();
			}));
			GUIUtility.processEvent = (Func<int, IntPtr, bool>)Delegate.Combine(GUIUtility.processEvent, new Func<int, IntPtr, bool>((int i, IntPtr ptr) => UIEventRegistration.ProcessEvent(i, ptr)));
			GUIUtility.cleanupRoots = (Action)Delegate.Combine(GUIUtility.cleanupRoots, new Action(delegate()
			{
				UIEventRegistration.CleanupRoots();
			}));
			GUIUtility.endContainerGUIFromException = (Func<Exception, bool>)Delegate.Combine(GUIUtility.endContainerGUIFromException, new Func<Exception, bool>((Exception exception) => UIEventRegistration.EndContainerGUIFromException(exception)));
			GUIUtility.guiChanged = (Action)Delegate.Combine(GUIUtility.guiChanged, new Action(delegate()
			{
				UIEventRegistration.MakeCurrentIMGUIContainerDirty();
			}));
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x00074AD4 File Offset: 0x00072CD4
		internal static void RegisterUIElementSystem(IUIElementsUtility utility)
		{
			UIEventRegistration.s_Utilities.Insert(0, utility);
		}

		// Token: 0x06001E36 RID: 7734 RVA: 0x00074AE4 File Offset: 0x00072CE4
		private static void TakeCapture()
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				bool flag = iuielementsUtility.TakeCapture();
				if (flag)
				{
					break;
				}
			}
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x00074B40 File Offset: 0x00072D40
		private static void ReleaseCapture()
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				bool flag = iuielementsUtility.ReleaseCapture();
				if (flag)
				{
					break;
				}
			}
		}

		// Token: 0x06001E38 RID: 7736 RVA: 0x00074B9C File Offset: 0x00072D9C
		private static bool EndContainerGUIFromException(Exception exception)
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				bool flag = iuielementsUtility.EndContainerGUIFromException(exception);
				if (flag)
				{
					return true;
				}
			}
			return GUIUtility.ShouldRethrowException(exception);
		}

		// Token: 0x06001E39 RID: 7737 RVA: 0x00074C08 File Offset: 0x00072E08
		private static bool ProcessEvent(int instanceID, IntPtr nativeEventPtr)
		{
			bool result = false;
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				bool flag = iuielementsUtility.ProcessEvent(instanceID, nativeEventPtr, ref result);
				if (flag)
				{
					return result;
				}
			}
			return false;
		}

		// Token: 0x06001E3A RID: 7738 RVA: 0x00074C78 File Offset: 0x00072E78
		private static void CleanupRoots()
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				bool flag = iuielementsUtility.CleanupRoots();
				if (flag)
				{
					break;
				}
			}
		}

		// Token: 0x06001E3B RID: 7739 RVA: 0x00074CD4 File Offset: 0x00072ED4
		internal static void MakeCurrentIMGUIContainerDirty()
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				bool flag = iuielementsUtility.MakeCurrentIMGUIContainerDirty();
				if (flag)
				{
					break;
				}
			}
		}

		// Token: 0x06001E3C RID: 7740 RVA: 0x00074D30 File Offset: 0x00072F30
		internal static void UpdateSchedulers()
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				iuielementsUtility.UpdateSchedulers();
			}
		}

		// Token: 0x06001E3D RID: 7741 RVA: 0x00074D88 File Offset: 0x00072F88
		internal static void RequestRepaintForPanels(Action<ScriptableObject> repaintCallback)
		{
			foreach (IUIElementsUtility iuielementsUtility in UIEventRegistration.s_Utilities)
			{
				iuielementsUtility.RequestRepaintForPanels(repaintCallback);
			}
		}

		// Token: 0x04000C8E RID: 3214
		private static List<IUIElementsUtility> s_Utilities = new List<IUIElementsUtility>();
	}
}
