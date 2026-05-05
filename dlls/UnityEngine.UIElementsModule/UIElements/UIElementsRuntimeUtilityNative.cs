using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.UIElements
{
	// Token: 0x02000287 RID: 647
	[VisibleToOtherModules(new string[]
	{
		"Unity.UIElements"
	})]
	[NativeHeader("ModuleOverrides/com.unity.ui/Core/Native/UIElementsRuntimeUtilityNative.h")]
	internal static class UIElementsRuntimeUtilityNative
	{
		// Token: 0x0600122F RID: 4655 RVA: 0x000411F9 File Offset: 0x0003F3F9
		[RequiredByNativeCode]
		public static void RepaintOverlayPanels()
		{
			Action repaintOverlayPanelsCallback = UIElementsRuntimeUtilityNative.RepaintOverlayPanelsCallback;
			if (repaintOverlayPanelsCallback != null)
			{
				repaintOverlayPanelsCallback();
			}
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0004120D File Offset: 0x0003F40D
		[RequiredByNativeCode]
		public static void UpdateRuntimePanels()
		{
			Action updateRuntimePanelsCallback = UIElementsRuntimeUtilityNative.UpdateRuntimePanelsCallback;
			if (updateRuntimePanelsCallback != null)
			{
				updateRuntimePanelsCallback();
			}
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00041221 File Offset: 0x0003F421
		[RequiredByNativeCode]
		public static void RepaintOffscreenPanels()
		{
			Action repaintOffscreenPanelsCallback = UIElementsRuntimeUtilityNative.RepaintOffscreenPanelsCallback;
			if (repaintOffscreenPanelsCallback != null)
			{
				repaintOffscreenPanelsCallback();
			}
		}

		// Token: 0x06001232 RID: 4658
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void RegisterPlayerloopCallback();

		// Token: 0x06001233 RID: 4659
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void UnregisterPlayerloopCallback();

		// Token: 0x06001234 RID: 4660
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VisualElementCreation();

		// Token: 0x04000834 RID: 2100
		internal static Action RepaintOverlayPanelsCallback;

		// Token: 0x04000835 RID: 2101
		internal static Action UpdateRuntimePanelsCallback;

		// Token: 0x04000836 RID: 2102
		internal static Action RepaintOffscreenPanelsCallback;
	}
}
