using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200037D RID: 893
	internal interface IUIElementsUtility
	{
		// Token: 0x06001E2C RID: 7724
		bool TakeCapture();

		// Token: 0x06001E2D RID: 7725
		bool ReleaseCapture();

		// Token: 0x06001E2E RID: 7726
		bool ProcessEvent(int instanceID, IntPtr nativeEventPtr, ref bool eventHandled);

		// Token: 0x06001E2F RID: 7727
		bool CleanupRoots();

		// Token: 0x06001E30 RID: 7728
		bool EndContainerGUIFromException(Exception exception);

		// Token: 0x06001E31 RID: 7729
		bool MakeCurrentIMGUIContainerDirty();

		// Token: 0x06001E32 RID: 7730
		void UpdateSchedulers();

		// Token: 0x06001E33 RID: 7731
		void RequestRepaintForPanels(Action<ScriptableObject> repaintCallback);
	}
}
