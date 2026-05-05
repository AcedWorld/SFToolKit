using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Profiling;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x0200037A RID: 890
	internal static class UIElementsRuntimeUtility
	{
		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06001DFF RID: 7679 RVA: 0x00074018 File Offset: 0x00072218
		// (remove) Token: 0x06001E00 RID: 7680 RVA: 0x0007404C File Offset: 0x0007224C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event Action s_onRepaintOverlayPanels;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06001E01 RID: 7681 RVA: 0x00074080 File Offset: 0x00072280
		// (remove) Token: 0x06001E02 RID: 7682 RVA: 0x000740AC File Offset: 0x000722AC
		internal static event Action onRepaintOverlayPanels
		{
			add
			{
				bool flag = UIElementsRuntimeUtility.s_onRepaintOverlayPanels == null;
				if (flag)
				{
					UIElementsRuntimeUtility.RegisterPlayerloopCallback();
				}
				UIElementsRuntimeUtility.s_onRepaintOverlayPanels += value;
			}
			remove
			{
				UIElementsRuntimeUtility.s_onRepaintOverlayPanels -= value;
				bool flag = UIElementsRuntimeUtility.s_onRepaintOverlayPanels == null;
				if (flag)
				{
					UIElementsRuntimeUtility.UnregisterPlayerloopCallback();
				}
			}
		}

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x06001E03 RID: 7683 RVA: 0x000740D8 File Offset: 0x000722D8
		// (remove) Token: 0x06001E04 RID: 7684 RVA: 0x0007410C File Offset: 0x0007230C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<BaseRuntimePanel> onCreatePanel;

		// Token: 0x06001E05 RID: 7685 RVA: 0x00074140 File Offset: 0x00072340
		static UIElementsRuntimeUtility()
		{
			UIElementsRuntimeUtilityNative.RepaintOverlayPanelsCallback = delegate()
			{
			};
			UIElementsRuntimeUtilityNative.RepaintOffscreenPanelsCallback = new Action(UIElementsRuntimeUtility.RepaintOffscreenPanels);
			Canvas.externBeginRenderOverlays = new Action<int>(UIElementsRuntimeUtility.BeginRenderOverlays);
			Canvas.externRenderOverlaysBefore = delegate(int displayIndex, int sortOrder)
			{
				UIElementsRuntimeUtility.RenderOverlaysBeforePriority(displayIndex, (float)sortOrder);
			};
			Canvas.externEndRenderOverlays = new Action<int>(UIElementsRuntimeUtility.EndRenderOverlays);
		}

		// Token: 0x06001E06 RID: 7686 RVA: 0x000741F4 File Offset: 0x000723F4
		public static EventBase CreateEvent(Event systemEvent)
		{
			return UIElementsUtility.CreateEvent(systemEvent, systemEvent.rawType);
		}

		// Token: 0x06001E07 RID: 7687 RVA: 0x00074214 File Offset: 0x00072414
		public static BaseRuntimePanel FindOrCreateRuntimePanel(ScriptableObject ownerObject, UIElementsRuntimeUtility.CreateRuntimePanelDelegate createDelegate)
		{
			Panel panel;
			bool flag = UIElementsUtility.TryGetPanel(ownerObject.GetInstanceID(), out panel);
			if (flag)
			{
				BaseRuntimePanel baseRuntimePanel = panel as BaseRuntimePanel;
				bool flag2 = baseRuntimePanel != null;
				if (flag2)
				{
					return baseRuntimePanel;
				}
				UIElementsRuntimeUtility.RemoveCachedPanelInternal(ownerObject.GetInstanceID());
			}
			BaseRuntimePanel baseRuntimePanel2 = createDelegate(ownerObject);
			baseRuntimePanel2.IMGUIEventInterests = new EventInterests
			{
				wantsMouseMove = true,
				wantsMouseEnterLeaveWindow = true
			};
			UIElementsRuntimeUtility.RegisterCachedPanelInternal(ownerObject.GetInstanceID(), baseRuntimePanel2);
			Action<BaseRuntimePanel> action = UIElementsRuntimeUtility.onCreatePanel;
			if (action != null)
			{
				action(baseRuntimePanel2);
			}
			return baseRuntimePanel2;
		}

		// Token: 0x06001E08 RID: 7688 RVA: 0x000742A8 File Offset: 0x000724A8
		public static void DisposeRuntimePanel(ScriptableObject ownerObject)
		{
			Panel panel;
			bool flag = UIElementsUtility.TryGetPanel(ownerObject.GetInstanceID(), out panel);
			if (flag)
			{
				panel.Dispose();
				UIElementsRuntimeUtility.RemoveCachedPanelInternal(ownerObject.GetInstanceID());
			}
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x000742DC File Offset: 0x000724DC
		private static void RegisterCachedPanelInternal(int instanceID, IPanel panel)
		{
			UIElementsUtility.RegisterCachedPanel(instanceID, panel as Panel);
			UIElementsRuntimeUtility.s_PanelOrderingDirty = true;
			bool flag = !UIElementsRuntimeUtility.s_RegisteredPlayerloopCallback;
			if (flag)
			{
				UIElementsRuntimeUtility.s_RegisteredPlayerloopCallback = true;
				UIElementsRuntimeUtility.RegisterPlayerloopCallback();
				Canvas.SetExternalCanvasEnabled(true);
			}
		}

		// Token: 0x06001E0A RID: 7690 RVA: 0x00074320 File Offset: 0x00072520
		private static void RemoveCachedPanelInternal(int instanceID)
		{
			UIElementsUtility.RemoveCachedPanel(instanceID);
			UIElementsRuntimeUtility.s_PanelOrderingDirty = true;
			UIElementsRuntimeUtility.s_SortedRuntimePanels.Clear();
			UIElementsUtility.GetAllPanels(UIElementsRuntimeUtility.s_SortedRuntimePanels, ContextType.Player);
			bool flag = UIElementsRuntimeUtility.s_SortedRuntimePanels.Count == 0;
			if (flag)
			{
				UIElementsRuntimeUtility.s_RegisteredPlayerloopCallback = false;
				UIElementsRuntimeUtility.UnregisterPlayerloopCallback();
				Canvas.SetExternalCanvasEnabled(false);
			}
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x00074378 File Offset: 0x00072578
		public static void RepaintOverlayPanels()
		{
			foreach (Panel panel in UIElementsRuntimeUtility.GetSortedPlayerPanels())
			{
				BaseRuntimePanel baseRuntimePanel = (BaseRuntimePanel)panel;
				bool flag = !baseRuntimePanel.drawToCameras;
				if (flag)
				{
					UIElementsRuntimeUtility.RepaintOverlayPanel(baseRuntimePanel);
				}
			}
			bool flag2 = UIElementsRuntimeUtility.s_onRepaintOverlayPanels != null;
			if (flag2)
			{
				UIElementsRuntimeUtility.s_onRepaintOverlayPanels();
			}
		}

		// Token: 0x06001E0C RID: 7692 RVA: 0x000743FC File Offset: 0x000725FC
		public static void RepaintOffscreenPanels()
		{
			foreach (Panel panel in UIElementsRuntimeUtility.GetSortedPlayerPanels())
			{
				BaseRuntimePanel baseRuntimePanel = (BaseRuntimePanel)panel;
				bool flag = baseRuntimePanel.targetTexture != null;
				if (flag)
				{
					UIElementsRuntimeUtility.RepaintOverlayPanel(baseRuntimePanel);
				}
			}
		}

		// Token: 0x06001E0D RID: 7693 RVA: 0x0007446C File Offset: 0x0007266C
		public static void RepaintOverlayPanel(BaseRuntimePanel panel)
		{
			Camera current = Camera.current;
			RenderTexture active = RenderTexture.active;
			using (UIElementsRuntimeUtility.s_RepaintProfilerMarker.Auto())
			{
				panel.Repaint(Event.current);
			}
			Camera.SetupCurrent(current);
			RenderTexture.active = active;
		}

		// Token: 0x06001E0E RID: 7694 RVA: 0x000744D0 File Offset: 0x000726D0
		internal static void BeginRenderOverlays(int displayIndex)
		{
			UIElementsRuntimeUtility.currentOverlayIndex = 0;
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x000744DC File Offset: 0x000726DC
		internal static void RenderOverlaysBeforePriority(int displayIndex, float maxPriority)
		{
			bool flag = UIElementsRuntimeUtility.currentOverlayIndex < 0;
			if (!flag)
			{
				List<Panel> sortedPlayerPanels = UIElementsRuntimeUtility.GetSortedPlayerPanels();
				while (UIElementsRuntimeUtility.currentOverlayIndex < sortedPlayerPanels.Count)
				{
					BaseRuntimePanel baseRuntimePanel = sortedPlayerPanels[UIElementsRuntimeUtility.currentOverlayIndex] as BaseRuntimePanel;
					bool flag2 = baseRuntimePanel != null;
					if (flag2)
					{
						bool flag3 = baseRuntimePanel.sortingPriority >= maxPriority;
						if (flag3)
						{
							break;
						}
						bool flag4 = baseRuntimePanel.targetDisplay == displayIndex;
						if (flag4)
						{
							UIElementsRuntimeUtility.RepaintOverlayPanel(baseRuntimePanel);
						}
					}
					UIElementsRuntimeUtility.currentOverlayIndex++;
				}
			}
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x00074568 File Offset: 0x00072768
		internal static void EndRenderOverlays(int displayIndex)
		{
			UIElementsRuntimeUtility.RenderOverlaysBeforePriority(displayIndex, float.MaxValue);
			UIElementsRuntimeUtility.currentOverlayIndex = -1;
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06001E11 RID: 7697 RVA: 0x0007457D File Offset: 0x0007277D
		// (set) Token: 0x06001E12 RID: 7698 RVA: 0x00074584 File Offset: 0x00072784
		internal static Object activeEventSystem { get; private set; }

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06001E13 RID: 7699 RVA: 0x0007458C File Offset: 0x0007278C
		internal static bool useDefaultEventSystem
		{
			get
			{
				return UIElementsRuntimeUtility.activeEventSystem == null;
			}
		}

		// Token: 0x06001E14 RID: 7700 RVA: 0x0007459C File Offset: 0x0007279C
		public static void RegisterEventSystem(Object eventSystem)
		{
			bool flag = UIElementsRuntimeUtility.activeEventSystem != null && UIElementsRuntimeUtility.activeEventSystem != eventSystem && eventSystem.GetType().Name == "EventSystem";
			if (flag)
			{
				Debug.LogWarning("There can be only one active Event System.");
			}
			UIElementsRuntimeUtility.activeEventSystem = eventSystem;
		}

		// Token: 0x06001E15 RID: 7701 RVA: 0x000745F4 File Offset: 0x000727F4
		public static void UnregisterEventSystem(Object eventSystem)
		{
			bool flag = UIElementsRuntimeUtility.activeEventSystem == eventSystem;
			if (flag)
			{
				UIElementsRuntimeUtility.activeEventSystem = null;
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x06001E16 RID: 7702 RVA: 0x00074618 File Offset: 0x00072818
		internal static DefaultEventSystem defaultEventSystem
		{
			get
			{
				DefaultEventSystem result;
				if ((result = UIElementsRuntimeUtility.s_DefaultEventSystem) == null)
				{
					result = (UIElementsRuntimeUtility.s_DefaultEventSystem = new DefaultEventSystem());
				}
				return result;
			}
		}

		// Token: 0x06001E17 RID: 7703 RVA: 0x00074630 File Offset: 0x00072830
		public static void UpdateRuntimePanels()
		{
			UIElementsRuntimeUtility.RemoveUnusedPanels();
			UIRenderDevice.ProcessDeviceFreeQueue();
			foreach (Panel panel in UIElementsRuntimeUtility.GetSortedPlayerPanels())
			{
				BaseRuntimePanel baseRuntimePanel = (BaseRuntimePanel)panel;
				baseRuntimePanel.Update();
			}
			bool flag = Application.isPlaying && UIElementsRuntimeUtility.useDefaultEventSystem;
			if (flag)
			{
				UIElementsRuntimeUtility.defaultEventSystem.Update(DefaultEventSystem.UpdateMode.IgnoreIfAppNotFocused);
			}
		}

		// Token: 0x06001E18 RID: 7704 RVA: 0x000746BC File Offset: 0x000728BC
		internal static void MarkPotentiallyEmpty(PanelSettings settings)
		{
			bool flag = !UIElementsRuntimeUtility.s_PotentiallyEmptyPanelSettings.Contains(settings);
			if (flag)
			{
				UIElementsRuntimeUtility.s_PotentiallyEmptyPanelSettings.Add(settings);
			}
		}

		// Token: 0x06001E19 RID: 7705 RVA: 0x000746E8 File Offset: 0x000728E8
		internal static void RemoveUnusedPanels()
		{
			foreach (PanelSettings panelSettings in UIElementsRuntimeUtility.s_PotentiallyEmptyPanelSettings)
			{
				UIDocumentList attachedUIDocumentsList = panelSettings.m_AttachedUIDocumentsList;
				bool flag = attachedUIDocumentsList == null || attachedUIDocumentsList.m_AttachedUIDocuments.Count == 0;
				if (flag)
				{
					panelSettings.DisposePanel();
				}
			}
			UIElementsRuntimeUtility.s_PotentiallyEmptyPanelSettings.Clear();
		}

		// Token: 0x06001E1A RID: 7706 RVA: 0x0007476C File Offset: 0x0007296C
		public static void RegisterPlayerloopCallback()
		{
			UIElementsRuntimeUtilityNative.RegisterPlayerloopCallback();
			UIElementsRuntimeUtilityNative.UpdateRuntimePanelsCallback = new Action(UIElementsRuntimeUtility.UpdateRuntimePanels);
		}

		// Token: 0x06001E1B RID: 7707 RVA: 0x00074786 File Offset: 0x00072986
		public static void UnregisterPlayerloopCallback()
		{
			UIElementsRuntimeUtilityNative.UnregisterPlayerloopCallback();
			UIElementsRuntimeUtilityNative.UpdateRuntimePanelsCallback = null;
		}

		// Token: 0x06001E1C RID: 7708 RVA: 0x00074795 File Offset: 0x00072995
		internal static void SetPanelOrderingDirty()
		{
			UIElementsRuntimeUtility.s_PanelOrderingDirty = true;
		}

		// Token: 0x06001E1D RID: 7709 RVA: 0x000747A0 File Offset: 0x000729A0
		internal static List<Panel> GetSortedPlayerPanels()
		{
			bool flag = UIElementsRuntimeUtility.s_PanelOrderingDirty;
			if (flag)
			{
				UIElementsRuntimeUtility.SortPanels();
			}
			return UIElementsRuntimeUtility.s_SortedRuntimePanels;
		}

		// Token: 0x06001E1E RID: 7710 RVA: 0x000747C8 File Offset: 0x000729C8
		private static void SortPanels()
		{
			UIElementsRuntimeUtility.s_SortedRuntimePanels.Clear();
			UIElementsUtility.GetAllPanels(UIElementsRuntimeUtility.s_SortedRuntimePanels, ContextType.Player);
			UIElementsRuntimeUtility.s_SortedRuntimePanels.Sort(delegate(Panel a, Panel b)
			{
				BaseRuntimePanel baseRuntimePanel2 = a as BaseRuntimePanel;
				BaseRuntimePanel baseRuntimePanel3 = b as BaseRuntimePanel;
				bool flag2 = baseRuntimePanel2 == null || baseRuntimePanel3 == null;
				int result;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					float num = baseRuntimePanel2.sortingPriority - baseRuntimePanel3.sortingPriority;
					bool flag3 = Mathf.Approximately(0f, num);
					if (flag3)
					{
						result = baseRuntimePanel2.m_RuntimePanelCreationIndex.CompareTo(baseRuntimePanel3.m_RuntimePanelCreationIndex);
					}
					else
					{
						result = ((num < 0f) ? -1 : 1);
					}
				}
				return result;
			});
			for (int i = 0; i < UIElementsRuntimeUtility.s_SortedRuntimePanels.Count; i++)
			{
				BaseRuntimePanel baseRuntimePanel = UIElementsRuntimeUtility.s_SortedRuntimePanels[i] as BaseRuntimePanel;
				bool flag = baseRuntimePanel != null;
				if (flag)
				{
					baseRuntimePanel.resolvedSortingIndex = i;
				}
			}
			UIElementsRuntimeUtility.s_ResolvedSortingIndexMax = UIElementsRuntimeUtility.s_SortedRuntimePanels.Count - 1;
			UIElementsRuntimeUtility.s_PanelOrderingDirty = false;
		}

		// Token: 0x06001E1F RID: 7711 RVA: 0x0007486C File Offset: 0x00072A6C
		internal static Vector2 MultiDisplayBottomLeftToPanelPosition(Vector2 position, out int? targetDisplay)
		{
			Vector2 position2 = UIElementsRuntimeUtility.MultiDisplayToLocalScreenPosition(position, out targetDisplay);
			return UIElementsRuntimeUtility.ScreenBottomLeftToPanelPosition(position2, targetDisplay.GetValueOrDefault());
		}

		// Token: 0x06001E20 RID: 7712 RVA: 0x00074894 File Offset: 0x00072A94
		internal static Vector2 MultiDisplayToLocalScreenPosition(Vector2 position, out int? targetDisplay)
		{
			Vector3 vector = Display.RelativeMouseAt(position);
			bool flag = vector != Vector3.zero;
			Vector2 result;
			if (flag)
			{
				targetDisplay = new int?((int)vector.z);
				result = vector;
			}
			else
			{
				targetDisplay = null;
				result = position;
			}
			return result;
		}

		// Token: 0x06001E21 RID: 7713 RVA: 0x000748E8 File Offset: 0x00072AE8
		internal static Vector2 ScreenBottomLeftToPanelPosition(Vector2 position, int targetDisplay)
		{
			int num = Screen.height;
			bool flag = targetDisplay > 0 && targetDisplay < Display.displays.Length;
			if (flag)
			{
				num = Display.displays[targetDisplay].systemHeight;
			}
			position.y = (float)num - position.y;
			return position;
		}

		// Token: 0x06001E22 RID: 7714 RVA: 0x00074934 File Offset: 0x00072B34
		internal static Vector2 ScreenBottomLeftToPanelDelta(Vector2 delta)
		{
			delta.y = -delta.y;
			return delta;
		}

		// Token: 0x04000C82 RID: 3202
		private static bool s_RegisteredPlayerloopCallback = false;

		// Token: 0x04000C83 RID: 3203
		private static List<Panel> s_SortedRuntimePanels = new List<Panel>();

		// Token: 0x04000C84 RID: 3204
		private static bool s_PanelOrderingDirty = true;

		// Token: 0x04000C85 RID: 3205
		internal static int s_ResolvedSortingIndexMax = 0;

		// Token: 0x04000C86 RID: 3206
		internal static readonly string s_RepaintProfilerMarkerName = "UIElementsRuntimeUtility.DoDispatch(Repaint Event)";

		// Token: 0x04000C87 RID: 3207
		private static readonly ProfilerMarker s_RepaintProfilerMarker = new ProfilerMarker(UIElementsRuntimeUtility.s_RepaintProfilerMarkerName);

		// Token: 0x04000C88 RID: 3208
		private static int currentOverlayIndex = -1;

		// Token: 0x04000C8A RID: 3210
		private static DefaultEventSystem s_DefaultEventSystem;

		// Token: 0x04000C8B RID: 3211
		private static List<PanelSettings> s_PotentiallyEmptyPanelSettings = new List<PanelSettings>();

		// Token: 0x0200037B RID: 891
		// (Invoke) Token: 0x06001E24 RID: 7716
		public delegate BaseRuntimePanel CreateRuntimePanelDelegate(ScriptableObject ownerObject);
	}
}
