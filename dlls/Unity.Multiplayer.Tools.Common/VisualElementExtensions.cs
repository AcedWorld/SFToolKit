using System;
using UnityEngine.UIElements;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200001F RID: 31
	internal static class VisualElementExtensions
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00002F4F File Offset: 0x0000114F
		public static void AddEventLifecycle(this VisualElement visualElement, EventCallback<AttachToPanelEvent> onAttach, EventCallback<DetachFromPanelEvent> onDetach)
		{
			visualElement.RegisterCallback<AttachToPanelEvent>(onAttach, TrickleDown.NoTrickleDown);
			visualElement.RegisterCallback<DetachFromPanelEvent>(onDetach, TrickleDown.NoTrickleDown);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002F61 File Offset: 0x00001161
		public static void SetInclude(this VisualElement visualElement, bool includeInLayout)
		{
			visualElement.style.display = (includeInLayout ? DisplayStyle.Flex : DisplayStyle.None);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002F7C File Offset: 0x0000117C
		public static bool GetInclude(this VisualElement visualElement)
		{
			return visualElement.style.display.value == DisplayStyle.Flex;
		}
	}
}
