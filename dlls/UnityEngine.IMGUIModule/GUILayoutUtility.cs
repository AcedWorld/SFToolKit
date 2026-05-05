using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine.Bindings;
using UnityEngineInternal;

namespace UnityEngine
{
	// Token: 0x02000022 RID: 34
	[NativeHeader("Modules/IMGUI/GUILayoutUtility.bindings.h")]
	public class GUILayoutUtility
	{
		// Token: 0x06000256 RID: 598 RVA: 0x00009660 File Offset: 0x00007860
		private static Rect Internal_GetWindowRect(int windowID)
		{
			Rect result;
			GUILayoutUtility.Internal_GetWindowRect_Injected(windowID, out result);
			return result;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00009676 File Offset: 0x00007876
		private static void Internal_MoveWindow(int windowID, Rect r)
		{
			GUILayoutUtility.Internal_MoveWindow_Injected(windowID, ref r);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00009680 File Offset: 0x00007880
		internal static Rect GetWindowsBounds()
		{
			Rect result;
			GUILayoutUtility.GetWindowsBounds_Injected(out result);
			return result;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00009695 File Offset: 0x00007895
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0000969C File Offset: 0x0000789C
		internal static int unbalancedgroupscount { get; set; }

		// Token: 0x0600025B RID: 603 RVA: 0x000096A4 File Offset: 0x000078A4
		internal static void CleanupRoots()
		{
			GUILayoutUtility.s_SpaceStyle = null;
			GUILayoutUtility.s_StoredLayouts.Clear();
			GUILayoutUtility.s_StoredWindows.Clear();
			GUILayoutUtility.current = new GUILayoutUtility.LayoutCache(-1);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000096D0 File Offset: 0x000078D0
		internal static GUILayoutUtility.LayoutCache GetLayoutCache(int instanceID, bool isWindow)
		{
			Dictionary<int, GUILayoutUtility.LayoutCache> dictionary = isWindow ? GUILayoutUtility.s_StoredWindows : GUILayoutUtility.s_StoredLayouts;
			GUILayoutUtility.LayoutCache result;
			dictionary.TryGetValue(instanceID, out result);
			return result;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00009700 File Offset: 0x00007900
		internal static GUILayoutUtility.LayoutCache SelectIDList(int instanceID, bool isWindow)
		{
			Dictionary<int, GUILayoutUtility.LayoutCache> dictionary = isWindow ? GUILayoutUtility.s_StoredWindows : GUILayoutUtility.s_StoredLayouts;
			GUILayoutUtility.LayoutCache layoutCache = GUILayoutUtility.GetLayoutCache(instanceID, isWindow);
			bool flag = layoutCache == null;
			if (flag)
			{
				layoutCache = new GUILayoutUtility.LayoutCache(instanceID);
				dictionary[instanceID] = layoutCache;
			}
			GUILayoutUtility.current.topLevel = layoutCache.topLevel;
			GUILayoutUtility.current.layoutGroups = layoutCache.layoutGroups;
			GUILayoutUtility.current.windows = layoutCache.windows;
			return layoutCache;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00009778 File Offset: 0x00007978
		internal static void RemoveSelectedIdList(int instanceID, bool isWindow)
		{
			Dictionary<int, GUILayoutUtility.LayoutCache> dictionary = isWindow ? GUILayoutUtility.s_StoredWindows : GUILayoutUtility.s_StoredLayouts;
			bool flag = dictionary.ContainsKey(instanceID);
			if (flag)
			{
				dictionary.Remove(instanceID);
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000097AC File Offset: 0x000079AC
		internal static void Begin(int instanceID)
		{
			GUILayoutUtility.LayoutCache layoutCache = GUILayoutUtility.SelectIDList(instanceID, false);
			bool flag = Event.current.type == EventType.Layout;
			if (flag)
			{
				GUILayoutUtility.current.topLevel = (layoutCache.topLevel = new GUILayoutGroup());
				GUILayoutUtility.current.layoutGroups.Clear();
				GUILayoutUtility.current.layoutGroups.Push(GUILayoutUtility.current.topLevel);
				GUILayoutUtility.current.windows = (layoutCache.windows = new GUILayoutGroup());
			}
			else
			{
				GUILayoutUtility.current.topLevel = layoutCache.topLevel;
				GUILayoutUtility.current.layoutGroups = layoutCache.layoutGroups;
				GUILayoutUtility.current.windows = layoutCache.windows;
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00009864 File Offset: 0x00007A64
		internal static void BeginContainer(GUILayoutUtility.LayoutCache cache)
		{
			bool flag = Event.current.type == EventType.Layout;
			if (flag)
			{
				cache.topLevel = new GUILayoutGroup();
				cache.layoutGroups.Clear();
				cache.layoutGroups.Push(cache.topLevel);
				cache.windows = new GUILayoutGroup();
			}
			GUILayoutUtility.current.topLevel = cache.topLevel;
			GUILayoutUtility.current.layoutGroups = cache.layoutGroups;
			GUILayoutUtility.current.windows = cache.windows;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000098EC File Offset: 0x00007AEC
		internal static void BeginWindow(int windowID, GUIStyle style, GUILayoutOption[] options)
		{
			GUILayoutUtility.LayoutCache layoutCache = GUILayoutUtility.SelectIDList(windowID, true);
			bool flag = Event.current.type == EventType.Layout;
			if (flag)
			{
				GUILayoutUtility.current.topLevel = (layoutCache.topLevel = new GUILayoutGroup());
				GUILayoutUtility.current.topLevel.style = style;
				GUILayoutUtility.current.topLevel.windowID = windowID;
				bool flag2 = options != null;
				if (flag2)
				{
					GUILayoutUtility.current.topLevel.ApplyOptions(options);
				}
				GUILayoutUtility.current.layoutGroups.Clear();
				GUILayoutUtility.current.layoutGroups.Push(GUILayoutUtility.current.topLevel);
				GUILayoutUtility.current.windows = (layoutCache.windows = new GUILayoutGroup());
			}
			else
			{
				GUILayoutUtility.current.topLevel = layoutCache.topLevel;
				GUILayoutUtility.current.layoutGroups = layoutCache.layoutGroups;
				GUILayoutUtility.current.windows = layoutCache.windows;
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00002221 File Offset: 0x00000421
		[Obsolete("BeginGroup has no effect and will be removed", false)]
		public static void BeginGroup(string GroupName)
		{
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00002221 File Offset: 0x00000421
		[Obsolete("EndGroup has no effect and will be removed", false)]
		public static void EndGroup(string groupName)
		{
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000099E0 File Offset: 0x00007BE0
		internal static void Layout()
		{
			bool flag = GUILayoutUtility.current.topLevel.windowID == -1;
			if (flag)
			{
				GUILayoutUtility.current.topLevel.CalcWidth();
				GUILayoutUtility.current.topLevel.SetHorizontal(0f, Mathf.Min((float)Screen.width / GUIUtility.pixelsPerPoint, GUILayoutUtility.current.topLevel.maxWidth));
				GUILayoutUtility.current.topLevel.CalcHeight();
				GUILayoutUtility.current.topLevel.SetVertical(0f, Mathf.Min((float)Screen.height / GUIUtility.pixelsPerPoint, GUILayoutUtility.current.topLevel.maxHeight));
				GUILayoutUtility.LayoutFreeGroup(GUILayoutUtility.current.windows);
			}
			else
			{
				GUILayoutUtility.LayoutSingleGroup(GUILayoutUtility.current.topLevel);
				GUILayoutUtility.LayoutFreeGroup(GUILayoutUtility.current.windows);
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00009AC8 File Offset: 0x00007CC8
		internal static void LayoutFromEditorWindow()
		{
			bool flag = GUILayoutUtility.current.topLevel != null;
			if (flag)
			{
				GUILayoutUtility.current.topLevel.CalcWidth();
				GUILayoutUtility.current.topLevel.SetHorizontal(0f, (float)Screen.width / GUIUtility.pixelsPerPoint);
				GUILayoutUtility.current.topLevel.CalcHeight();
				GUILayoutUtility.current.topLevel.SetVertical(0f, (float)Screen.height / GUIUtility.pixelsPerPoint);
				GUILayoutUtility.LayoutFreeGroup(GUILayoutUtility.current.windows);
			}
			else
			{
				Debug.LogError("GUILayout state invalid. Verify that all layout begin/end calls match.");
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00009B6C File Offset: 0x00007D6C
		internal static void LayoutFromContainer(float w, float h)
		{
			bool flag = GUILayoutUtility.current.topLevel != null;
			if (flag)
			{
				GUILayoutUtility.current.topLevel.CalcWidth();
				GUILayoutUtility.current.topLevel.SetHorizontal(0f, w);
				GUILayoutUtility.current.topLevel.CalcHeight();
				GUILayoutUtility.current.topLevel.SetVertical(0f, h);
				GUILayoutUtility.LayoutFreeGroup(GUILayoutUtility.current.windows);
			}
			else
			{
				Debug.LogError("GUILayout state invalid. Verify that all layout begin/end calls match.");
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00009BF8 File Offset: 0x00007DF8
		internal static float LayoutFromInspector(float width)
		{
			bool flag = GUILayoutUtility.current.topLevel != null && GUILayoutUtility.current.topLevel.windowID == -1;
			float result;
			if (flag)
			{
				GUILayoutUtility.current.topLevel.CalcWidth();
				GUILayoutUtility.current.topLevel.SetHorizontal(0f, width);
				GUILayoutUtility.current.topLevel.CalcHeight();
				GUILayoutUtility.current.topLevel.SetVertical(0f, Mathf.Min((float)Screen.height / GUIUtility.pixelsPerPoint, GUILayoutUtility.current.topLevel.maxHeight));
				float minHeight = GUILayoutUtility.current.topLevel.minHeight;
				GUILayoutUtility.LayoutFreeGroup(GUILayoutUtility.current.windows);
				result = minHeight;
			}
			else
			{
				bool flag2 = GUILayoutUtility.current.topLevel != null;
				if (flag2)
				{
					GUILayoutUtility.LayoutSingleGroup(GUILayoutUtility.current.topLevel);
				}
				result = 0f;
			}
			return result;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00009CE8 File Offset: 0x00007EE8
		internal static void LayoutFreeGroup(GUILayoutGroup toplevel)
		{
			foreach (GUILayoutEntry guilayoutEntry in toplevel.entries)
			{
				GUILayoutGroup i = (GUILayoutGroup)guilayoutEntry;
				GUILayoutUtility.LayoutSingleGroup(i);
			}
			toplevel.ResetCursor();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00009D4C File Offset: 0x00007F4C
		private static void LayoutSingleGroup(GUILayoutGroup i)
		{
			bool flag = !i.isWindow;
			if (flag)
			{
				float minWidth = i.minWidth;
				float maxWidth = i.maxWidth;
				i.CalcWidth();
				i.SetHorizontal(i.rect.x, Mathf.Clamp(i.maxWidth, minWidth, maxWidth));
				float minHeight = i.minHeight;
				float maxHeight = i.maxHeight;
				i.CalcHeight();
				i.SetVertical(i.rect.y, Mathf.Clamp(i.maxHeight, minHeight, maxHeight));
			}
			else
			{
				i.CalcWidth();
				Rect rect = GUILayoutUtility.Internal_GetWindowRect(i.windowID);
				i.SetHorizontal(rect.x, Mathf.Clamp(rect.width, i.minWidth, i.maxWidth));
				i.CalcHeight();
				i.SetVertical(rect.y, Mathf.Clamp(rect.height, i.minHeight, i.maxHeight));
				GUILayoutUtility.Internal_MoveWindow(i.windowID, i.rect);
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00009E50 File Offset: 0x00008050
		[SecuritySafeCritical]
		private static GUILayoutGroup CreateGUILayoutGroupInstanceOfType(Type LayoutType)
		{
			bool flag = !typeof(GUILayoutGroup).IsAssignableFrom(LayoutType);
			if (flag)
			{
				throw new ArgumentException("LayoutType needs to be of type GUILayoutGroup", "LayoutType");
			}
			return (GUILayoutGroup)Activator.CreateInstance(LayoutType);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00009E94 File Offset: 0x00008094
		internal static GUILayoutGroup BeginLayoutGroup(GUIStyle style, GUILayoutOption[] options, Type layoutType)
		{
			GUILayoutUtility.unbalancedgroupscount++;
			EventType type = Event.current.type;
			EventType eventType = type;
			GUILayoutGroup guilayoutGroup;
			if (eventType != EventType.Layout && eventType != EventType.Used)
			{
				guilayoutGroup = (GUILayoutUtility.current.topLevel.GetNext() as GUILayoutGroup);
				bool flag = guilayoutGroup == null;
				if (flag)
				{
					throw new ExitGUIException("GUILayout: Mismatched LayoutGroup." + Event.current.type.ToString());
				}
				guilayoutGroup.ResetCursor();
			}
			else
			{
				guilayoutGroup = GUILayoutUtility.CreateGUILayoutGroupInstanceOfType(layoutType);
				guilayoutGroup.style = style;
				bool flag2 = options != null;
				if (flag2)
				{
					guilayoutGroup.ApplyOptions(options);
				}
				GUILayoutUtility.current.topLevel.Add(guilayoutGroup);
			}
			GUILayoutUtility.current.layoutGroups.Push(guilayoutGroup);
			GUILayoutUtility.current.topLevel = guilayoutGroup;
			return guilayoutGroup;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00009F70 File Offset: 0x00008170
		internal static void EndLayoutGroup()
		{
			GUILayoutUtility.unbalancedgroupscount--;
			bool flag = GUILayoutUtility.current.layoutGroups.Count == 0;
			if (flag)
			{
				Debug.LogError("EndLayoutGroup: BeginLayoutGroup must be called first.");
			}
			else
			{
				GUILayoutUtility.current.layoutGroups.Pop();
				bool flag2 = 0 < GUILayoutUtility.current.layoutGroups.Count;
				if (flag2)
				{
					GUILayoutUtility.current.topLevel = (GUILayoutGroup)GUILayoutUtility.current.layoutGroups.Peek();
				}
				else
				{
					GUILayoutUtility.current.topLevel = new GUILayoutGroup();
				}
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A004 File Offset: 0x00008204
		internal static GUILayoutGroup BeginLayoutArea(GUIStyle style, Type layoutType)
		{
			GUILayoutUtility.unbalancedgroupscount++;
			EventType type = Event.current.type;
			EventType eventType = type;
			GUILayoutGroup guilayoutGroup;
			if (eventType != EventType.Layout && eventType != EventType.Used)
			{
				guilayoutGroup = (GUILayoutUtility.current.windows.GetNext() as GUILayoutGroup);
				bool flag = guilayoutGroup == null;
				if (flag)
				{
					throw new ExitGUIException("GUILayout: Mismatched LayoutGroup." + Event.current.type.ToString());
				}
				guilayoutGroup.ResetCursor();
			}
			else
			{
				guilayoutGroup = GUILayoutUtility.CreateGUILayoutGroupInstanceOfType(layoutType);
				guilayoutGroup.style = style;
				GUILayoutUtility.current.windows.Add(guilayoutGroup);
			}
			GUILayoutUtility.current.layoutGroups.Push(guilayoutGroup);
			GUILayoutUtility.current.topLevel = guilayoutGroup;
			return guilayoutGroup;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000A0CD File Offset: 0x000082CD
		internal static void EndLayoutArea()
		{
			GUILayoutUtility.unbalancedgroupscount--;
			GUILayoutUtility.current.layoutGroups.Pop();
			GUILayoutUtility.current.topLevel = (GUILayoutGroup)GUILayoutUtility.current.layoutGroups.Peek();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000A10C File Offset: 0x0000830C
		internal static GUILayoutGroup DoBeginLayoutArea(GUIStyle style, Type layoutType)
		{
			return GUILayoutUtility.BeginLayoutArea(style, layoutType);
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000A125 File Offset: 0x00008325
		internal static GUILayoutGroup topLevel
		{
			get
			{
				return GUILayoutUtility.current.topLevel;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000A134 File Offset: 0x00008334
		public static Rect GetRect(GUIContent content, GUIStyle style)
		{
			return GUILayoutUtility.DoGetRect(content, style, null);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000A150 File Offset: 0x00008350
		public static Rect GetRect(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetRect(content, style, options);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A16C File Offset: 0x0000836C
		private static Rect DoGetRect(GUIContent content, GUIStyle style, GUILayoutOption[] options)
		{
			GUIUtility.CheckOnGUI();
			EventType type = Event.current.type;
			EventType eventType = type;
			Rect rect;
			if (eventType != EventType.Layout)
			{
				if (eventType != EventType.Used)
				{
					GUILayoutEntry next = GUILayoutUtility.current.topLevel.GetNext();
					rect = next.rect;
				}
				else
				{
					rect = GUILayoutUtility.kDummyRect;
				}
			}
			else
			{
				bool isHeightDependantOnWidth = style.isHeightDependantOnWidth;
				if (isHeightDependantOnWidth)
				{
					GUILayoutUtility.current.topLevel.Add(new GUIWordWrapSizer(style, content, options));
				}
				else
				{
					Vector2 constraints = new Vector2(0f, 0f);
					bool flag = options != null;
					if (flag)
					{
						foreach (GUILayoutOption guilayoutOption in options)
						{
							GUILayoutOption.Type type2 = guilayoutOption.type;
							GUILayoutOption.Type type3 = type2;
							if (type3 != GUILayoutOption.Type.maxWidth)
							{
								if (type3 == GUILayoutOption.Type.maxHeight)
								{
									constraints.y = (float)guilayoutOption.value;
								}
							}
							else
							{
								constraints.x = (float)guilayoutOption.value;
							}
						}
					}
					Vector2 vector = style.CalcSizeWithConstraints(content, constraints);
					vector.x = Mathf.Ceil(vector.x);
					vector.y = Mathf.Ceil(vector.y);
					GUILayoutUtility.current.topLevel.Add(new GUILayoutEntry(vector.x, vector.x, vector.y, vector.y, style, options));
				}
				rect = GUILayoutUtility.kDummyRect;
			}
			return rect;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000A2E0 File Offset: 0x000084E0
		public static Rect GetRect(float width, float height)
		{
			return GUILayoutUtility.DoGetRect(width, width, height, height, GUIStyle.none, null);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000A304 File Offset: 0x00008504
		public static Rect GetRect(float width, float height, GUIStyle style)
		{
			return GUILayoutUtility.DoGetRect(width, width, height, height, style, null);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000A324 File Offset: 0x00008524
		public static Rect GetRect(float width, float height, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetRect(width, width, height, height, GUIStyle.none, options);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000A348 File Offset: 0x00008548
		public static Rect GetRect(float width, float height, GUIStyle style, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetRect(width, width, height, height, style, options);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000A368 File Offset: 0x00008568
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight)
		{
			return GUILayoutUtility.DoGetRect(minWidth, maxWidth, minHeight, maxHeight, GUIStyle.none, null);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000A38C File Offset: 0x0000858C
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style)
		{
			return GUILayoutUtility.DoGetRect(minWidth, maxWidth, minHeight, maxHeight, style, null);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000A3AC File Offset: 0x000085AC
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetRect(minWidth, maxWidth, minHeight, maxHeight, GUIStyle.none, options);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000A3D0 File Offset: 0x000085D0
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetRect(minWidth, maxWidth, minHeight, maxHeight, style, options);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000A3F0 File Offset: 0x000085F0
		private static Rect DoGetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style, GUILayoutOption[] options)
		{
			EventType type = Event.current.type;
			EventType eventType = type;
			Rect result;
			if (eventType != EventType.Layout)
			{
				if (eventType != EventType.Used)
				{
					result = GUILayoutUtility.current.topLevel.GetNext().rect;
				}
				else
				{
					result = GUILayoutUtility.kDummyRect;
				}
			}
			else
			{
				GUILayoutUtility.current.topLevel.Add(new GUILayoutEntry(minWidth, maxWidth, minHeight, maxHeight, style, options));
				result = new Rect(0f, 0f, maxWidth, maxHeight);
			}
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000A46C File Offset: 0x0000866C
		public static Rect GetLastRect()
		{
			EventType type = Event.current.type;
			EventType eventType = type;
			Rect last;
			if (eventType != EventType.Layout && eventType != EventType.Used)
			{
				last = GUILayoutUtility.current.topLevel.GetLast();
			}
			else
			{
				last = GUILayoutUtility.kDummyRect;
			}
			return last;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000A4B0 File Offset: 0x000086B0
		public static Rect GetAspectRect(float aspect)
		{
			return GUILayoutUtility.DoGetAspectRect(aspect, null);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000A4CC File Offset: 0x000086CC
		public static Rect GetAspectRect(float aspect, GUIStyle style)
		{
			return GUILayoutUtility.DoGetAspectRect(aspect, null);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000A4E8 File Offset: 0x000086E8
		public static Rect GetAspectRect(float aspect, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetAspectRect(aspect, options);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000A504 File Offset: 0x00008704
		public static Rect GetAspectRect(float aspect, GUIStyle style, params GUILayoutOption[] options)
		{
			return GUILayoutUtility.DoGetAspectRect(aspect, options);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000A520 File Offset: 0x00008720
		private static Rect DoGetAspectRect(float aspect, GUILayoutOption[] options)
		{
			EventType type = Event.current.type;
			EventType eventType = type;
			Rect rect;
			if (eventType != EventType.Layout)
			{
				if (eventType != EventType.Used)
				{
					rect = GUILayoutUtility.current.topLevel.GetNext().rect;
				}
				else
				{
					rect = GUILayoutUtility.kDummyRect;
				}
			}
			else
			{
				GUILayoutUtility.current.topLevel.Add(new GUIAspectSizer(aspect, options));
				rect = GUILayoutUtility.kDummyRect;
			}
			return rect;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0000A588 File Offset: 0x00008788
		internal static GUIStyle spaceStyle
		{
			get
			{
				bool flag = GUILayoutUtility.s_SpaceStyle == null;
				if (flag)
				{
					GUILayoutUtility.s_SpaceStyle = new GUIStyle();
				}
				GUILayoutUtility.s_SpaceStyle.stretchWidth = false;
				return GUILayoutUtility.s_SpaceStyle;
			}
		}

		// Token: 0x06000286 RID: 646
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetWindowRect_Injected(int windowID, out Rect ret);

		// Token: 0x06000287 RID: 647
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_MoveWindow_Injected(int windowID, ref Rect r);

		// Token: 0x06000288 RID: 648
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetWindowsBounds_Injected(out Rect ret);

		// Token: 0x04000094 RID: 148
		private static readonly Dictionary<int, GUILayoutUtility.LayoutCache> s_StoredLayouts = new Dictionary<int, GUILayoutUtility.LayoutCache>();

		// Token: 0x04000095 RID: 149
		private static readonly Dictionary<int, GUILayoutUtility.LayoutCache> s_StoredWindows = new Dictionary<int, GUILayoutUtility.LayoutCache>();

		// Token: 0x04000096 RID: 150
		internal static GUILayoutUtility.LayoutCache current = new GUILayoutUtility.LayoutCache(-1);

		// Token: 0x04000097 RID: 151
		internal static readonly Rect kDummyRect = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x04000099 RID: 153
		private static GUIStyle s_SpaceStyle;

		// Token: 0x02000023 RID: 35
		internal readonly struct LayoutCacheState
		{
			// Token: 0x06000289 RID: 649 RVA: 0x0000A600 File Offset: 0x00008800
			public LayoutCacheState(GUILayoutUtility.LayoutCache cache)
			{
				this.id = cache.id;
				this.topLevel = cache.topLevel;
				this.layoutGroups = cache.layoutGroups;
				this.windows = cache.windows;
			}

			// Token: 0x0400009A RID: 154
			public readonly int id;

			// Token: 0x0400009B RID: 155
			public readonly GUILayoutGroup topLevel;

			// Token: 0x0400009C RID: 156
			public readonly GenericStack layoutGroups;

			// Token: 0x0400009D RID: 157
			public readonly GUILayoutGroup windows;
		}

		// Token: 0x02000024 RID: 36
		[DebuggerDisplay("id={id}, groups={layoutGroups.Count}")]
		internal sealed class LayoutCache
		{
			// Token: 0x17000044 RID: 68
			// (get) Token: 0x0600028A RID: 650 RVA: 0x0000A633 File Offset: 0x00008833
			// (set) Token: 0x0600028B RID: 651 RVA: 0x0000A63B File Offset: 0x0000883B
			internal int id { get; private set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x0600028C RID: 652 RVA: 0x0000A644 File Offset: 0x00008844
			public GUILayoutUtility.LayoutCacheState State
			{
				get
				{
					return new GUILayoutUtility.LayoutCacheState(this);
				}
			}

			// Token: 0x0600028D RID: 653 RVA: 0x0000A64C File Offset: 0x0000884C
			internal LayoutCache(int instanceID = -1)
			{
				this.id = instanceID;
				this.layoutGroups.Push(this.topLevel);
			}

			// Token: 0x0600028E RID: 654 RVA: 0x0000A69C File Offset: 0x0000889C
			internal void CopyState(GUILayoutUtility.LayoutCacheState other)
			{
				this.id = other.id;
				this.topLevel = other.topLevel;
				this.layoutGroups = other.layoutGroups;
				this.windows = other.windows;
			}

			// Token: 0x0600028F RID: 655 RVA: 0x0000A6D0 File Offset: 0x000088D0
			public void ResetCursor()
			{
				this.windows.ResetCursor();
				this.topLevel.ResetCursor();
				foreach (object obj in this.layoutGroups)
				{
					((GUILayoutGroup)obj).ResetCursor();
				}
			}

			// Token: 0x0400009F RID: 159
			internal GUILayoutGroup topLevel = new GUILayoutGroup();

			// Token: 0x040000A0 RID: 160
			internal GenericStack layoutGroups = new GenericStack();

			// Token: 0x040000A1 RID: 161
			internal GUILayoutGroup windows = new GUILayoutGroup();
		}
	}
}
