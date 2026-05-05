using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Yoga;

namespace UnityEngine.UIElements
{
	// Token: 0x02000293 RID: 659
	internal abstract class BaseVisualElementPanel : IPanel, IDisposable, IGroupBox
	{
		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06001254 RID: 4692
		// (set) Token: 0x06001255 RID: 4693
		public abstract EventInterests IMGUIEventInterests { get; set; }

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06001256 RID: 4694
		// (set) Token: 0x06001257 RID: 4695
		public abstract ScriptableObject ownerObject { get; protected set; }

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06001258 RID: 4696
		// (set) Token: 0x06001259 RID: 4697
		public abstract SavePersistentViewData saveViewData { get; set; }

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x0600125A RID: 4698
		// (set) Token: 0x0600125B RID: 4699
		public abstract GetViewDataDictionary getViewDataDictionary { get; set; }

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x0600125C RID: 4700
		// (set) Token: 0x0600125D RID: 4701
		public abstract int IMGUIContainersCount { get; set; }

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x0600125E RID: 4702
		// (set) Token: 0x0600125F RID: 4703
		public abstract FocusController focusController { get; set; }

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06001260 RID: 4704
		// (set) Token: 0x06001261 RID: 4705
		public abstract IMGUIContainer rootIMGUIContainer { get; set; }

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06001262 RID: 4706 RVA: 0x00041424 File Offset: 0x0003F624
		// (remove) Token: 0x06001263 RID: 4707 RVA: 0x0004145C File Offset: 0x0003F65C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<BaseVisualElementPanel> panelDisposed;

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06001264 RID: 4708 RVA: 0x00041494 File Offset: 0x0003F694
		// (set) Token: 0x06001265 RID: 4709 RVA: 0x000414C4 File Offset: 0x0003F6C4
		internal UIElementsBridge uiElementsBridge
		{
			get
			{
				bool flag = this.m_UIElementsBridge != null;
				if (flag)
				{
					return this.m_UIElementsBridge;
				}
				throw new Exception("Panel has no UIElementsBridge.");
			}
			set
			{
				this.m_UIElementsBridge = value;
			}
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x000414D0 File Offset: 0x0003F6D0
		protected BaseVisualElementPanel()
		{
			this.yogaConfig = new YogaConfig();
			this.yogaConfig.UseWebDefaults = YogaConfig.Default.UseWebDefaults;
			this.m_UIElementsBridge = new RuntimeUIElementsBridge();
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00041568 File Offset: 0x0003F768
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x0004157C File Offset: 0x0003F77C
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					bool flag = this.ownerObject != null;
					if (flag)
					{
						UIElementsUtility.RemoveCachedPanel(this.ownerObject.GetInstanceID());
					}
					PointerDeviceState.RemovePanelData(this);
				}
				Action<BaseVisualElementPanel> action = this.panelDisposed;
				if (action != null)
				{
					action(this);
				}
				this.yogaConfig = null;
				this.disposed = true;
			}
		}

		// Token: 0x06001269 RID: 4713
		public abstract void Repaint(Event e);

		// Token: 0x0600126A RID: 4714
		public abstract void ValidateFocus();

		// Token: 0x0600126B RID: 4715
		public abstract void ValidateLayout();

		// Token: 0x0600126C RID: 4716
		public abstract void UpdateAnimations();

		// Token: 0x0600126D RID: 4717
		public abstract void UpdateBindings();

		// Token: 0x0600126E RID: 4718
		public abstract void ApplyStyles();

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x0600126F RID: 4719 RVA: 0x000415EC File Offset: 0x0003F7EC
		// (set) Token: 0x06001270 RID: 4720 RVA: 0x00041604 File Offset: 0x0003F804
		internal float scale
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				bool flag = !Mathf.Approximately(this.m_Scale, value);
				if (flag)
				{
					this.m_Scale = value;
					this.visualTree.IncrementVersion(VersionChangeType.Layout);
					this.yogaConfig.PointScaleFactor = this.scaledPixelsPerPoint;
					this.visualTree.IncrementVersion(VersionChangeType.StyleSheet);
				}
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06001271 RID: 4721 RVA: 0x0004165C File Offset: 0x0003F85C
		// (set) Token: 0x06001272 RID: 4722 RVA: 0x00041674 File Offset: 0x0003F874
		internal float pixelsPerPoint
		{
			get
			{
				return this.m_PixelsPerPoint;
			}
			set
			{
				bool flag = !Mathf.Approximately(this.m_PixelsPerPoint, value);
				if (flag)
				{
					this.m_PixelsPerPoint = value;
					this.visualTree.IncrementVersion(VersionChangeType.Layout);
					this.yogaConfig.PointScaleFactor = this.scaledPixelsPerPoint;
					this.visualTree.IncrementVersion(VersionChangeType.StyleSheet);
				}
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06001273 RID: 4723 RVA: 0x000416CC File Offset: 0x0003F8CC
		public float scaledPixelsPerPoint
		{
			get
			{
				return this.m_PixelsPerPoint * this.m_Scale;
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06001274 RID: 4724 RVA: 0x000416EB File Offset: 0x0003F8EB
		// (set) Token: 0x06001275 RID: 4725 RVA: 0x000416F3 File Offset: 0x0003F8F3
		public float referenceSpritePixelsPerUnit { get; set; } = 100f;

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06001276 RID: 4726 RVA: 0x000416FC File Offset: 0x0003F8FC
		// (set) Token: 0x06001277 RID: 4727 RVA: 0x0004173C File Offset: 0x0003F93C
		public PanelClearFlags clearFlags
		{
			get
			{
				PanelClearFlags panelClearFlags = PanelClearFlags.None;
				bool clearColor = this.clearSettings.clearColor;
				if (clearColor)
				{
					panelClearFlags |= PanelClearFlags.Color;
				}
				bool clearDepthStencil = this.clearSettings.clearDepthStencil;
				if (clearDepthStencil)
				{
					panelClearFlags |= PanelClearFlags.Depth;
				}
				return panelClearFlags;
			}
			set
			{
				PanelClearSettings clearSettings = this.clearSettings;
				clearSettings.clearColor = ((value & PanelClearFlags.Color) == PanelClearFlags.Color);
				clearSettings.clearDepthStencil = ((value & PanelClearFlags.Depth) == PanelClearFlags.Depth);
				this.clearSettings = clearSettings;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06001278 RID: 4728 RVA: 0x00041773 File Offset: 0x0003F973
		// (set) Token: 0x06001279 RID: 4729 RVA: 0x0004177B File Offset: 0x0003F97B
		internal PanelClearSettings clearSettings { get; set; } = new PanelClearSettings
		{
			clearDepthStencil = true,
			clearColor = true,
			color = Color.clear
		};

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x0600127A RID: 4730 RVA: 0x00041784 File Offset: 0x0003F984
		// (set) Token: 0x0600127B RID: 4731 RVA: 0x0004178C File Offset: 0x0003F98C
		internal bool duringLayoutPhase { get; set; }

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x0600127C RID: 4732 RVA: 0x00041798 File Offset: 0x0003F998
		public bool isDirty
		{
			get
			{
				return this.version != this.repaintVersion;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x0600127D RID: 4733
		internal abstract uint version { get; }

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x0600127E RID: 4734
		internal abstract uint repaintVersion { get; }

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x0600127F RID: 4735
		internal abstract uint hierarchyVersion { get; }

		// Token: 0x06001280 RID: 4736
		internal abstract void OnVersionChanged(VisualElement ele, VersionChangeType changeTypeFlag);

		// Token: 0x06001281 RID: 4737
		internal abstract void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase);

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06001282 RID: 4738 RVA: 0x000417BB File Offset: 0x0003F9BB
		// (set) Token: 0x06001283 RID: 4739 RVA: 0x000417C3 File Offset: 0x0003F9C3
		internal virtual RepaintData repaintData { get; set; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06001284 RID: 4740 RVA: 0x000417CC File Offset: 0x0003F9CC
		// (set) Token: 0x06001285 RID: 4741 RVA: 0x000417D4 File Offset: 0x0003F9D4
		internal virtual ICursorManager cursorManager { get; set; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06001286 RID: 4742 RVA: 0x000417DD File Offset: 0x0003F9DD
		// (set) Token: 0x06001287 RID: 4743 RVA: 0x000417E5 File Offset: 0x0003F9E5
		public ContextualMenuManager contextualMenuManager { get; internal set; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06001288 RID: 4744
		public abstract VisualElement visualTree { get; }

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06001289 RID: 4745
		// (set) Token: 0x0600128A RID: 4746
		public abstract EventDispatcher dispatcher { get; set; }

		// Token: 0x0600128B RID: 4747 RVA: 0x000417EE File Offset: 0x0003F9EE
		internal void SendEvent(EventBase e, DispatchMode dispatchMode = DispatchMode.Default)
		{
			Debug.Assert(this.dispatcher != null);
			EventDispatcher dispatcher = this.dispatcher;
			if (dispatcher != null)
			{
				dispatcher.Dispatch(e, this, dispatchMode);
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x0600128C RID: 4748
		internal abstract IScheduler scheduler { get; }

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x0600128D RID: 4749
		// (set) Token: 0x0600128E RID: 4750
		internal abstract IStylePropertyAnimationSystem styleAnimationSystem { get; set; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x0600128F RID: 4751
		// (set) Token: 0x06001290 RID: 4752
		public abstract ContextType contextType { get; protected set; }

		// Token: 0x06001291 RID: 4753
		public abstract VisualElement Pick(Vector2 point);

		// Token: 0x06001292 RID: 4754
		public abstract VisualElement PickAll(Vector2 point, List<VisualElement> picked);

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06001293 RID: 4755 RVA: 0x00041815 File Offset: 0x0003FA15
		// (set) Token: 0x06001294 RID: 4756 RVA: 0x0004181D File Offset: 0x0003FA1D
		internal bool disposed { get; private set; }

		// Token: 0x06001295 RID: 4757
		internal abstract IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase);

		// Token: 0x06001296 RID: 4758 RVA: 0x00041828 File Offset: 0x0003FA28
		internal VisualElement GetTopElementUnderPointer(int pointerId)
		{
			return this.m_TopElementUnderPointers.GetTopElementUnderPointer(pointerId);
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x00041848 File Offset: 0x0003FA48
		internal VisualElement RecomputeTopElementUnderPointer(int pointerId, Vector2 pointerPos, EventBase triggerEvent)
		{
			VisualElement visualElement = null;
			bool flag = PointerDeviceState.GetPanel(pointerId, this.contextType) == this && !PointerDeviceState.HasLocationFlag(pointerId, this.contextType, PointerDeviceState.LocationFlag.OutsidePanel);
			if (flag)
			{
				visualElement = this.Pick(pointerPos);
			}
			this.m_TopElementUnderPointers.SetElementUnderPointer(visualElement, pointerId, triggerEvent);
			return visualElement;
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x0004189C File Offset: 0x0003FA9C
		internal void ClearCachedElementUnderPointer(int pointerId, EventBase triggerEvent)
		{
			this.m_TopElementUnderPointers.SetTemporaryElementUnderPointer(null, pointerId, triggerEvent);
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x000418AE File Offset: 0x0003FAAE
		internal void CommitElementUnderPointers()
		{
			this.m_TopElementUnderPointers.CommitElementUnderPointers(this.dispatcher, this.contextType);
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x0600129A RID: 4762
		// (set) Token: 0x0600129B RID: 4763
		internal abstract Shader standardShader { get; set; }

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x000418CC File Offset: 0x0003FACC
		// (set) Token: 0x0600129D RID: 4765 RVA: 0x00003CD2 File Offset: 0x00001ED2
		internal virtual Shader standardWorldSpaceShader
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x0600129E RID: 4766 RVA: 0x000418E0 File Offset: 0x0003FAE0
		// (remove) Token: 0x0600129F RID: 4767 RVA: 0x00041918 File Offset: 0x0003FB18
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action standardShaderChanged;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060012A0 RID: 4768 RVA: 0x00041950 File Offset: 0x0003FB50
		// (remove) Token: 0x060012A1 RID: 4769 RVA: 0x00041988 File Offset: 0x0003FB88
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action standardWorldSpaceShaderChanged;

		// Token: 0x060012A2 RID: 4770 RVA: 0x000419C0 File Offset: 0x0003FBC0
		protected void InvokeStandardShaderChanged()
		{
			bool flag = this.standardShaderChanged != null;
			if (flag)
			{
				this.standardShaderChanged();
			}
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x000419E8 File Offset: 0x0003FBE8
		protected void InvokeStandardWorldSpaceShaderChanged()
		{
			bool flag = this.standardWorldSpaceShaderChanged != null;
			if (flag)
			{
				this.standardWorldSpaceShaderChanged();
			}
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060012A4 RID: 4772 RVA: 0x00041A10 File Offset: 0x0003FC10
		// (remove) Token: 0x060012A5 RID: 4773 RVA: 0x00041A48 File Offset: 0x0003FC48
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action atlasChanged;

		// Token: 0x060012A6 RID: 4774 RVA: 0x00041A7D File Offset: 0x0003FC7D
		protected void InvokeAtlasChanged()
		{
			Action action = this.atlasChanged;
			if (action != null)
			{
				action();
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x060012A7 RID: 4775
		// (set) Token: 0x060012A8 RID: 4776
		public abstract AtlasBase atlas { get; set; }

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x060012A9 RID: 4777 RVA: 0x00041A94 File Offset: 0x0003FC94
		// (remove) Token: 0x060012AA RID: 4778 RVA: 0x00041ACC File Offset: 0x0003FCCC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<Material> updateMaterial;

		// Token: 0x060012AB RID: 4779 RVA: 0x00041B01 File Offset: 0x0003FD01
		internal void InvokeUpdateMaterial(Material mat)
		{
			Action<Material> action = this.updateMaterial;
			if (action != null)
			{
				action(mat);
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x060012AC RID: 4780 RVA: 0x00041B18 File Offset: 0x0003FD18
		// (remove) Token: 0x060012AD RID: 4781 RVA: 0x00041B50 File Offset: 0x0003FD50
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event HierarchyEvent hierarchyChanged;

		// Token: 0x060012AE RID: 4782 RVA: 0x00041B88 File Offset: 0x0003FD88
		internal void InvokeHierarchyChanged(VisualElement ve, HierarchyChangeType changeType)
		{
			bool flag = this.hierarchyChanged != null;
			if (flag)
			{
				this.hierarchyChanged(ve, changeType);
			}
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x060012AF RID: 4783 RVA: 0x00041BB4 File Offset: 0x0003FDB4
		// (remove) Token: 0x060012B0 RID: 4784 RVA: 0x00041BEC File Offset: 0x0003FDEC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<IPanel> beforeUpdate;

		// Token: 0x060012B1 RID: 4785 RVA: 0x00041C21 File Offset: 0x0003FE21
		internal void InvokeBeforeUpdate()
		{
			Action<IPanel> action = this.beforeUpdate;
			if (action != null)
			{
				action(this);
			}
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x00041C38 File Offset: 0x0003FE38
		internal void UpdateElementUnderPointers()
		{
			foreach (int pointerId in PointerId.hoveringPointers)
			{
				bool flag = PointerDeviceState.GetPanel(pointerId, this.contextType) != this || PointerDeviceState.HasLocationFlag(pointerId, this.contextType, PointerDeviceState.LocationFlag.OutsidePanel);
				if (flag)
				{
					this.m_TopElementUnderPointers.SetElementUnderPointer(null, pointerId, new Vector2(float.MinValue, float.MinValue));
				}
				else
				{
					Vector2 pointerPosition = PointerDeviceState.GetPointerPosition(pointerId, this.contextType);
					VisualElement newElementUnderPointer = this.PickAll(pointerPosition, null);
					this.m_TopElementUnderPointers.SetElementUnderPointer(newElementUnderPointer, pointerId, pointerPosition);
				}
			}
			this.CommitElementUnderPointers();
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x00003CD2 File Offset: 0x00001ED2
		void IGroupBox.OnOptionAdded(IGroupBoxOption option)
		{
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00003CD2 File Offset: 0x00001ED2
		void IGroupBox.OnOptionRemoved(IGroupBoxOption option)
		{
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x00041CD8 File Offset: 0x0003FED8
		public virtual void Update()
		{
			this.scheduler.UpdateScheduledEvents();
			this.ValidateFocus();
			this.ValidateLayout();
			this.UpdateAnimations();
			this.UpdateBindings();
		}

		// Token: 0x04000873 RID: 2163
		private UIElementsBridge m_UIElementsBridge;

		// Token: 0x04000874 RID: 2164
		private float m_Scale = 1f;

		// Token: 0x04000875 RID: 2165
		internal YogaConfig yogaConfig;

		// Token: 0x04000876 RID: 2166
		private float m_PixelsPerPoint = 1f;

		// Token: 0x0400087E RID: 2174
		internal ElementUnderPointer m_TopElementUnderPointers = new ElementUnderPointer();
	}
}
