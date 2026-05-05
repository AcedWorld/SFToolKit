using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x02000298 RID: 664
	internal class Panel : BaseVisualElementPanel
	{
		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x060012C6 RID: 4806 RVA: 0x00041D04 File Offset: 0x0003FF04
		public sealed override VisualElement visualTree
		{
			get
			{
				return this.m_RootContainer;
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x060012C7 RID: 4807 RVA: 0x00041D1C File Offset: 0x0003FF1C
		// (set) Token: 0x060012C8 RID: 4808 RVA: 0x00041D24 File Offset: 0x0003FF24
		public sealed override EventDispatcher dispatcher { get; set; }

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x060012C9 RID: 4809 RVA: 0x00041D30 File Offset: 0x0003FF30
		public TimerEventScheduler timerEventScheduler
		{
			get
			{
				TimerEventScheduler result;
				if ((result = this.m_Scheduler) == null)
				{
					result = (this.m_Scheduler = new TimerEventScheduler());
				}
				return result;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x060012CA RID: 4810 RVA: 0x00041D5C File Offset: 0x0003FF5C
		internal override IScheduler scheduler
		{
			get
			{
				return this.timerEventScheduler;
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x060012CB RID: 4811 RVA: 0x00041D74 File Offset: 0x0003FF74
		internal VisualTreeUpdater visualTreeUpdater
		{
			get
			{
				return this.m_VisualTreeUpdater;
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x060012CC RID: 4812 RVA: 0x00041D8C File Offset: 0x0003FF8C
		// (set) Token: 0x060012CD RID: 4813 RVA: 0x00041D94 File Offset: 0x0003FF94
		internal override IStylePropertyAnimationSystem styleAnimationSystem
		{
			get
			{
				return this.m_StylePropertyAnimationSystem;
			}
			set
			{
				bool flag = this.m_StylePropertyAnimationSystem == value;
				if (!flag)
				{
					IStylePropertyAnimationSystem stylePropertyAnimationSystem = this.m_StylePropertyAnimationSystem;
					if (stylePropertyAnimationSystem != null)
					{
						stylePropertyAnimationSystem.CancelAllAnimations();
					}
					this.m_StylePropertyAnimationSystem = value;
				}
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x060012CE RID: 4814 RVA: 0x00041DCA File Offset: 0x0003FFCA
		// (set) Token: 0x060012CF RID: 4815 RVA: 0x00041DD2 File Offset: 0x0003FFD2
		public override ScriptableObject ownerObject { get; protected set; }

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x060012D0 RID: 4816 RVA: 0x00041DDB File Offset: 0x0003FFDB
		// (set) Token: 0x060012D1 RID: 4817 RVA: 0x00041DE3 File Offset: 0x0003FFE3
		public override ContextType contextType { get; protected set; }

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x060012D2 RID: 4818 RVA: 0x00041DEC File Offset: 0x0003FFEC
		// (set) Token: 0x060012D3 RID: 4819 RVA: 0x00041DF4 File Offset: 0x0003FFF4
		public override SavePersistentViewData saveViewData { get; set; }

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x060012D4 RID: 4820 RVA: 0x00041DFD File Offset: 0x0003FFFD
		// (set) Token: 0x060012D5 RID: 4821 RVA: 0x00041E05 File Offset: 0x00040005
		public override GetViewDataDictionary getViewDataDictionary { get; set; }

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x060012D6 RID: 4822 RVA: 0x00041E0E File Offset: 0x0004000E
		// (set) Token: 0x060012D7 RID: 4823 RVA: 0x00041E16 File Offset: 0x00040016
		public sealed override FocusController focusController { get; set; }

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x060012D8 RID: 4824 RVA: 0x00041E1F File Offset: 0x0004001F
		// (set) Token: 0x060012D9 RID: 4825 RVA: 0x00041E27 File Offset: 0x00040027
		public override EventInterests IMGUIEventInterests { get; set; }

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x060012DA RID: 4826 RVA: 0x00041E30 File Offset: 0x00040030
		// (set) Token: 0x060012DB RID: 4827 RVA: 0x00041E37 File Offset: 0x00040037
		internal static LoadResourceFunction loadResourceFunc { private get; set; }

		// Token: 0x060012DC RID: 4828 RVA: 0x00041E40 File Offset: 0x00040040
		internal static Object LoadResource(string pathName, Type type, float dpiScaling)
		{
			bool flag = Panel.loadResourceFunc != null;
			Object result;
			if (flag)
			{
				result = Panel.loadResourceFunc(pathName, type, dpiScaling);
			}
			else
			{
				result = Resources.Load(pathName, type);
			}
			return result;
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x00041E7D File Offset: 0x0004007D
		internal void Focus()
		{
			this.m_JustReceivedFocus = true;
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x00041E87 File Offset: 0x00040087
		internal void Blur()
		{
			FocusController focusController = this.focusController;
			if (focusController != null)
			{
				focusController.BlurLastFocusedElement();
			}
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x00041E9C File Offset: 0x0004009C
		public override void ValidateFocus()
		{
			bool justReceivedFocus = this.m_JustReceivedFocus;
			if (justReceivedFocus)
			{
				this.m_JustReceivedFocus = false;
				FocusController focusController = this.focusController;
				if (focusController != null)
				{
					focusController.SetFocusToLastFocusedElement();
				}
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x060012E0 RID: 4832 RVA: 0x00041ED0 File Offset: 0x000400D0
		// (set) Token: 0x060012E1 RID: 4833 RVA: 0x00041EE8 File Offset: 0x000400E8
		internal string name
		{
			get
			{
				return this.m_PanelName;
			}
			set
			{
				this.m_PanelName = value;
				this.CreateMarkers();
			}
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x00041EFC File Offset: 0x000400FC
		private void CreateMarkers()
		{
			bool flag = !string.IsNullOrEmpty(this.m_PanelName);
			if (flag)
			{
				this.m_MarkerBeforeUpdate = new ProfilerMarker("Panel.BeforeUpdate." + this.m_PanelName);
				this.m_MarkerUpdate = new ProfilerMarker("Panel.Update." + this.m_PanelName);
				this.m_MarkerLayout = new ProfilerMarker("Panel.Layout." + this.m_PanelName);
				this.m_MarkerBindings = new ProfilerMarker("Panel.Bindings." + this.m_PanelName);
				this.m_MarkerAnimations = new ProfilerMarker("Panel.Animations." + this.m_PanelName);
			}
			else
			{
				this.m_MarkerBeforeUpdate = new ProfilerMarker("Panel.BeforeUpdate");
				this.m_MarkerUpdate = new ProfilerMarker("Panel.Update");
				this.m_MarkerLayout = new ProfilerMarker("Panel.Layout");
				this.m_MarkerBindings = new ProfilerMarker("Panel.Bindings");
				this.m_MarkerAnimations = new ProfilerMarker("Panel.Animations");
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x00041FFC File Offset: 0x000401FC
		// (set) Token: 0x060012E4 RID: 4836 RVA: 0x00042003 File Offset: 0x00040203
		internal static TimeMsFunction TimeSinceStartup { private get; set; }

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x0004200B File Offset: 0x0004020B
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x00042013 File Offset: 0x00040213
		public override int IMGUIContainersCount { get; set; }

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x0004201C File Offset: 0x0004021C
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x00042024 File Offset: 0x00040224
		public override IMGUIContainer rootIMGUIContainer { get; set; }

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x0004202D File Offset: 0x0004022D
		internal override uint version
		{
			get
			{
				return this.m_Version;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x00042035 File Offset: 0x00040235
		internal override uint repaintVersion
		{
			get
			{
				return this.m_RepaintVersion;
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x0004203D File Offset: 0x0004023D
		internal override uint hierarchyVersion
		{
			get
			{
				return this.m_HierarchyVersion;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x060012EC RID: 4844 RVA: 0x00042048 File Offset: 0x00040248
		// (set) Token: 0x060012ED RID: 4845 RVA: 0x00042060 File Offset: 0x00040260
		internal override Shader standardShader
		{
			get
			{
				return this.m_StandardShader;
			}
			set
			{
				bool flag = this.m_StandardShader != value;
				if (flag)
				{
					this.m_StandardShader = value;
					base.InvokeStandardShaderChanged();
				}
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x060012EE RID: 4846 RVA: 0x00042090 File Offset: 0x00040290
		// (set) Token: 0x060012EF RID: 4847 RVA: 0x000420A8 File Offset: 0x000402A8
		public override AtlasBase atlas
		{
			get
			{
				return this.m_Atlas;
			}
			set
			{
				bool flag = this.m_Atlas != value;
				if (flag)
				{
					AtlasBase atlas = this.m_Atlas;
					if (atlas != null)
					{
						atlas.InvokeRemovedFromPanel(this);
					}
					this.m_Atlas = value;
					base.InvokeAtlasChanged();
					AtlasBase atlas2 = this.m_Atlas;
					if (atlas2 != null)
					{
						atlas2.InvokeAssignedToPanel(this);
					}
				}
			}
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x000420FC File Offset: 0x000402FC
		internal static Panel CreateEditorPanel(ScriptableObject ownerObject)
		{
			return new Panel(ownerObject, ContextType.Editor, EventDispatcher.CreateDefault());
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x0004211C File Offset: 0x0004031C
		public Panel(ScriptableObject ownerObject, ContextType contextType, EventDispatcher dispatcher)
		{
			this.ownerObject = ownerObject;
			this.contextType = contextType;
			this.dispatcher = dispatcher;
			this.repaintData = new RepaintData();
			this.cursorManager = new CursorManager();
			base.contextualMenuManager = null;
			this.m_VisualTreeUpdater = new VisualTreeUpdater(this);
			this.m_RootContainer = new VisualElement
			{
				name = VisualElementUtils.GetUniqueName("unity-panel-container"),
				viewDataKey = "PanelContainer",
				pickingMode = ((contextType == ContextType.Editor) ? PickingMode.Position : PickingMode.Ignore),
				eventCallbackCategories = int.MinValue
			};
			this.visualTree.SetPanel(this);
			this.focusController = new FocusController(new VisualElementFocusRing(this.visualTree, VisualElementFocusRing.DefaultFocusOrder.ChildOrder));
			this.styleAnimationSystem = new StylePropertyAnimationSystem();
			this.CreateMarkers();
			base.InvokeHierarchyChanged(this.visualTree, HierarchyChangeType.Add);
			this.atlas = new DynamicAtlas();
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x00042228 File Offset: 0x00040428
		protected override void Dispose(bool disposing)
		{
			bool disposed = base.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.atlas = null;
					this.m_VisualTreeUpdater.Dispose();
				}
				base.Dispose(disposing);
			}
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x00042268 File Offset: 0x00040468
		public static long TimeSinceStartupMs()
		{
			TimeMsFunction timeSinceStartup = Panel.TimeSinceStartup;
			return (timeSinceStartup != null) ? timeSinceStartup() : Panel.DefaultTimeSinceStartupMs();
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x00042290 File Offset: 0x00040490
		internal static long DefaultTimeSinceStartupMs()
		{
			return (long)(Time.realtimeSinceStartup * 1000f);
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000422B0 File Offset: 0x000404B0
		internal static VisualElement PickAllWithoutValidatingLayout(VisualElement root, Vector2 point)
		{
			return Panel.PickAll(root, point, null, false);
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x000422CC File Offset: 0x000404CC
		private static VisualElement PickAll(VisualElement root, Vector2 point, List<VisualElement> picked = null, bool includeIgnoredElement = false)
		{
			return Panel.PerformPick(root, point, picked, includeIgnoredElement);
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000422EC File Offset: 0x000404EC
		private static VisualElement PerformPick(VisualElement root, Vector2 point, List<VisualElement> picked = null, bool includeIgnoredElement = false)
		{
			bool flag = root.resolvedStyle.display == DisplayStyle.None;
			VisualElement result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = root.pickingMode == PickingMode.Ignore && root.hierarchy.childCount == 0 && !includeIgnoredElement;
				if (flag2)
				{
					result = null;
				}
				else
				{
					bool flag3 = !root.worldBoundingBox.Contains(point);
					if (flag3)
					{
						result = null;
					}
					else
					{
						Vector2 localPoint = root.WorldToLocal(point);
						bool flag4 = root.ContainsPoint(localPoint);
						bool flag5 = !flag4 && root.ShouldClip();
						if (flag5)
						{
							result = null;
						}
						else
						{
							VisualElement visualElement = null;
							int childCount = root.hierarchy.childCount;
							for (int i = childCount - 1; i >= 0; i--)
							{
								VisualElement root2 = root.hierarchy[i];
								VisualElement visualElement2 = Panel.PerformPick(root2, point, picked, includeIgnoredElement);
								bool flag6 = visualElement == null && visualElement2 != null;
								if (flag6)
								{
									bool flag7 = picked == null;
									if (flag7)
									{
										return visualElement2;
									}
									visualElement = visualElement2;
								}
							}
							bool flag8 = root.visible && (root.pickingMode == PickingMode.Position || includeIgnoredElement) && flag4;
							if (flag8)
							{
								if (picked != null)
								{
									picked.Add(root);
								}
								bool flag9 = visualElement == null;
								if (flag9)
								{
									visualElement = root;
								}
							}
							result = visualElement;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00042448 File Offset: 0x00040648
		public override VisualElement PickAll(Vector2 point, List<VisualElement> picked)
		{
			this.ValidateLayout();
			bool flag = picked != null;
			if (flag)
			{
				picked.Clear();
			}
			return Panel.PickAll(this.visualTree, point, picked, false);
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x00042480 File Offset: 0x00040680
		public override VisualElement Pick(Vector2 point)
		{
			this.ValidateLayout();
			Vector2 p;
			bool flag;
			VisualElement topElementUnderPointer = this.m_TopElementUnderPointers.GetTopElementUnderPointer(PointerId.mousePointerId, out p, out flag);
			bool flag2 = !flag && Panel.<Pick>g__PixelOf|101_0(p) == Panel.<Pick>g__PixelOf|101_0(point);
			VisualElement result;
			if (flag2)
			{
				result = topElementUnderPointer;
			}
			else
			{
				result = Panel.PickAll(this.visualTree, point, null, false);
			}
			return result;
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x000424E0 File Offset: 0x000406E0
		public override void ValidateLayout()
		{
			bool flag = !this.m_ValidatingLayout;
			if (flag)
			{
				this.m_ValidatingLayout = true;
				this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Styles);
				this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Layout);
				this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.TransformClip);
				this.m_ValidatingLayout = false;
			}
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00042532 File Offset: 0x00040732
		public override void UpdateAnimations()
		{
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Animation);
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x00042542 File Offset: 0x00040742
		public override void UpdateBindings()
		{
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Bindings);
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x00042552 File Offset: 0x00040752
		public override void ApplyStyles()
		{
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Styles);
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x00042564 File Offset: 0x00040764
		private void UpdateForRepaint()
		{
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.ViewData);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Styles);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Layout);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.TransformClip);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Repaint);
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x000425B4 File Offset: 0x000407B4
		internal void UpdateWithoutRepaint()
		{
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.ViewData);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Bindings);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Animation);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Styles);
			this.m_VisualTreeUpdater.UpdateVisualTreePhase(VisualTreeUpdatePhase.Layout);
		}

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06001300 RID: 4864 RVA: 0x00042604 File Offset: 0x00040804
		// (remove) Token: 0x06001301 RID: 4865 RVA: 0x00042638 File Offset: 0x00040838
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal static event Action<Panel> beforeAnyRepaint;

		// Token: 0x06001302 RID: 4866 RVA: 0x0004266C File Offset: 0x0004086C
		public override void Repaint(Event e)
		{
			this.m_RepaintVersion = this.version;
			bool flag = this.contextType == ContextType.Editor;
			if (flag)
			{
				base.pixelsPerPoint = GUIUtility.pixelsPerPoint;
			}
			this.repaintData.repaintEvent = e;
			using (this.m_MarkerBeforeUpdate.Auto())
			{
				base.InvokeBeforeUpdate();
			}
			Action<Panel> action = Panel.beforeAnyRepaint;
			if (action != null)
			{
				action(this);
			}
			using (this.m_MarkerUpdate.Auto())
			{
				this.UpdateForRepaint();
			}
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x00042728 File Offset: 0x00040928
		internal override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			this.m_Version += 1U;
			this.m_VisualTreeUpdater.OnVersionChanged(ve, versionChangeType);
			bool flag = (versionChangeType & VersionChangeType.Hierarchy) == VersionChangeType.Hierarchy;
			if (flag)
			{
				this.m_HierarchyVersion += 1U;
			}
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x0004276A File Offset: 0x0004096A
		internal override void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase)
		{
			this.m_VisualTreeUpdater.SetUpdater(updater, phase);
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x0004277C File Offset: 0x0004097C
		internal override IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase)
		{
			return this.m_VisualTreeUpdater.GetUpdater(phase);
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x000427AB File Offset: 0x000409AB
		[CompilerGenerated]
		internal static Vector2Int <Pick>g__PixelOf|101_0(Vector2 p)
		{
			return Vector2Int.FloorToInt(p);
		}

		// Token: 0x04000885 RID: 2181
		private VisualElement m_RootContainer;

		// Token: 0x04000886 RID: 2182
		private VisualTreeUpdater m_VisualTreeUpdater;

		// Token: 0x04000887 RID: 2183
		private IStylePropertyAnimationSystem m_StylePropertyAnimationSystem;

		// Token: 0x04000888 RID: 2184
		private string m_PanelName;

		// Token: 0x04000889 RID: 2185
		private uint m_Version = 0U;

		// Token: 0x0400088A RID: 2186
		private uint m_RepaintVersion = 0U;

		// Token: 0x0400088B RID: 2187
		private uint m_HierarchyVersion = 0U;

		// Token: 0x0400088C RID: 2188
		private ProfilerMarker m_MarkerBeforeUpdate;

		// Token: 0x0400088D RID: 2189
		private ProfilerMarker m_MarkerUpdate;

		// Token: 0x0400088E RID: 2190
		private ProfilerMarker m_MarkerLayout;

		// Token: 0x0400088F RID: 2191
		private ProfilerMarker m_MarkerBindings;

		// Token: 0x04000890 RID: 2192
		private ProfilerMarker m_MarkerAnimations;

		// Token: 0x04000891 RID: 2193
		private static ProfilerMarker s_MarkerPickAll = new ProfilerMarker("Panel.PickAll");

		// Token: 0x04000893 RID: 2195
		private TimerEventScheduler m_Scheduler;

		// Token: 0x0400089B RID: 2203
		private bool m_JustReceivedFocus;

		// Token: 0x0400089F RID: 2207
		private Shader m_StandardShader;

		// Token: 0x040008A0 RID: 2208
		private AtlasBase m_Atlas;

		// Token: 0x040008A1 RID: 2209
		private bool m_ValidatingLayout = false;
	}
}
