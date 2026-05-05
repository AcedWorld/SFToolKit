using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B3 RID: 691
	internal class UIRRepaintUpdater : BaseVisualTreeUpdater
	{
		// Token: 0x060013F1 RID: 5105 RVA: 0x00046D1E File Offset: 0x00044F1E
		public UIRRepaintUpdater()
		{
			base.panelChanged += this.OnPanelChanged;
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x060013F2 RID: 5106 RVA: 0x00046D3B File Offset: 0x00044F3B
		public override ProfilerMarker profilerMarker
		{
			get
			{
				return UIRRepaintUpdater.s_ProfilerMarker;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x060013F3 RID: 5107 RVA: 0x00046D42 File Offset: 0x00044F42
		// (set) Token: 0x060013F4 RID: 5108 RVA: 0x00046D4A File Offset: 0x00044F4A
		public bool drawStats { get; set; }

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x060013F5 RID: 5109 RVA: 0x00046D53 File Offset: 0x00044F53
		// (set) Token: 0x060013F6 RID: 5110 RVA: 0x00046D5B File Offset: 0x00044F5B
		public bool breakBatches { get; set; }

		// Token: 0x060013F7 RID: 5111 RVA: 0x00046D64 File Offset: 0x00044F64
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			bool flag = this.renderChain == null;
			if (!flag)
			{
				bool flag2 = (versionChangeType & VersionChangeType.Transform) > (VersionChangeType)0;
				bool flag3 = (versionChangeType & VersionChangeType.Size) > (VersionChangeType)0;
				bool flag4 = (versionChangeType & VersionChangeType.Overflow) > (VersionChangeType)0;
				bool flag5 = (versionChangeType & VersionChangeType.BorderRadius) > (VersionChangeType)0;
				bool flag6 = (versionChangeType & VersionChangeType.BorderWidth) > (VersionChangeType)0;
				bool flag7 = (versionChangeType & VersionChangeType.RenderHints) > (VersionChangeType)0;
				bool flag8 = flag7;
				if (flag8)
				{
					this.renderChain.UIEOnRenderHintsChanged(ve);
				}
				bool flag9 = flag2 || flag3 || flag6;
				if (flag9)
				{
					this.renderChain.UIEOnTransformOrSizeChanged(ve, flag2, flag3 || flag6);
				}
				bool flag10 = flag4 || flag5;
				if (flag10)
				{
					this.renderChain.UIEOnClippingChanged(ve, false);
				}
				bool flag11 = (versionChangeType & VersionChangeType.Opacity) > (VersionChangeType)0;
				if (flag11)
				{
					this.renderChain.UIEOnOpacityChanged(ve, false);
				}
				bool flag12 = (versionChangeType & VersionChangeType.Color) > (VersionChangeType)0;
				if (flag12)
				{
					this.renderChain.UIEOnColorChanged(ve);
				}
				bool flag13 = (versionChangeType & VersionChangeType.Repaint) > (VersionChangeType)0;
				if (flag13)
				{
					this.renderChain.UIEOnVisualsChanged(ve, false);
				}
			}
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x00046E6C File Offset: 0x0004506C
		public override void Update()
		{
			bool flag = this.renderChain == null;
			if (flag)
			{
				this.InitRenderChain();
			}
			bool flag2 = this.renderChain == null || this.renderChain.device == null;
			if (!flag2)
			{
				this.renderChain.ProcessChanges();
				PanelClearSettings clearSettings = base.panel.clearSettings;
				bool flag3 = clearSettings.clearColor || clearSettings.clearDepthStencil;
				if (flag3)
				{
					Color color = clearSettings.color;
					color = color.RGBMultiplied(color.a);
					GL.Clear(clearSettings.clearDepthStencil, clearSettings.clearColor, color, 0.99f);
				}
				this.renderChain.drawStats = this.drawStats;
				this.renderChain.device.breakBatches = this.breakBatches;
				this.renderChain.Render();
			}
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x00046F48 File Offset: 0x00045148
		protected virtual RenderChain CreateRenderChain()
		{
			return new RenderChain(base.panel);
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x00046F65 File Offset: 0x00045165
		static UIRRepaintUpdater()
		{
			Utility.GraphicsResourcesRecreate += UIRRepaintUpdater.OnGraphicsResourcesRecreate;
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x00046F94 File Offset: 0x00045194
		private static void OnGraphicsResourcesRecreate(bool recreate)
		{
			bool flag = !recreate;
			if (flag)
			{
				UIRenderDevice.PrepareForGfxDeviceRecreate();
			}
			Dictionary<int, Panel>.Enumerator panelsIterator = UIElementsUtility.GetPanelsIterator();
			while (panelsIterator.MoveNext())
			{
				if (recreate)
				{
					KeyValuePair<int, Panel> keyValuePair = panelsIterator.Current;
					AtlasBase atlas = keyValuePair.Value.atlas;
					if (atlas != null)
					{
						atlas.Reset();
					}
				}
				else
				{
					KeyValuePair<int, Panel> keyValuePair = panelsIterator.Current;
					UIRRepaintUpdater uirrepaintUpdater = keyValuePair.Value.GetUpdater(VisualTreeUpdatePhase.Repaint) as UIRRepaintUpdater;
					if (uirrepaintUpdater != null)
					{
						uirrepaintUpdater.DestroyRenderChain();
					}
				}
			}
			bool flag2 = !recreate;
			if (flag2)
			{
				UIRenderDevice.FlushAllPendingDeviceDisposes();
			}
			else
			{
				UIRenderDevice.WrapUpGfxDeviceRecreate();
			}
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x0004702A File Offset: 0x0004522A
		private void OnPanelChanged(BaseVisualElementPanel obj)
		{
			this.DetachFromPanel();
			this.AttachToPanel();
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x0004703C File Offset: 0x0004523C
		private void AttachToPanel()
		{
			Debug.Assert(this.attachedPanel == null);
			bool flag = base.panel == null;
			if (!flag)
			{
				this.attachedPanel = base.panel;
				this.attachedPanel.atlasChanged += this.OnPanelAtlasChanged;
				this.attachedPanel.standardShaderChanged += this.OnPanelStandardShaderChanged;
				this.attachedPanel.standardWorldSpaceShaderChanged += this.OnPanelStandardWorldSpaceShaderChanged;
				this.attachedPanel.hierarchyChanged += this.OnPanelHierarchyChanged;
			}
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x000470D4 File Offset: 0x000452D4
		private void DetachFromPanel()
		{
			bool flag = this.attachedPanel == null;
			if (!flag)
			{
				this.DestroyRenderChain();
				this.attachedPanel.atlasChanged -= this.OnPanelAtlasChanged;
				this.attachedPanel.standardShaderChanged -= this.OnPanelStandardShaderChanged;
				this.attachedPanel.standardWorldSpaceShaderChanged -= this.OnPanelStandardWorldSpaceShaderChanged;
				this.attachedPanel.hierarchyChanged -= this.OnPanelHierarchyChanged;
				this.attachedPanel = null;
			}
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00047160 File Offset: 0x00045360
		private void InitRenderChain()
		{
			this.renderChain = this.CreateRenderChain();
			BaseVisualElementPanel baseVisualElementPanel = this.attachedPanel;
			bool flag = ((baseVisualElementPanel != null) ? baseVisualElementPanel.visualTree : null) != null;
			if (flag)
			{
				this.renderChain.UIEOnChildAdded(this.attachedPanel.visualTree);
			}
			this.OnPanelStandardShaderChanged();
			bool flag2 = base.panel.contextType == ContextType.Player;
			if (flag2)
			{
				this.OnPanelStandardWorldSpaceShaderChanged();
			}
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x000471CC File Offset: 0x000453CC
		internal void DestroyRenderChain()
		{
			bool flag = this.renderChain == null;
			if (!flag)
			{
				this.renderChain.Dispose();
				this.renderChain = null;
				this.ResetAllElementsDataRecursive(this.attachedPanel.visualTree);
			}
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x0004720E File Offset: 0x0004540E
		private void OnPanelAtlasChanged()
		{
			this.DestroyRenderChain();
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x00047218 File Offset: 0x00045418
		private void OnPanelHierarchyChanged(VisualElement ve, HierarchyChangeType changeType)
		{
			bool flag = this.renderChain == null;
			if (!flag)
			{
				switch (changeType)
				{
				case HierarchyChangeType.Add:
					this.renderChain.UIEOnChildAdded(ve);
					break;
				case HierarchyChangeType.Remove:
					this.renderChain.UIEOnChildRemoving(ve);
					break;
				case HierarchyChangeType.Move:
					this.renderChain.UIEOnChildrenReordered(ve);
					break;
				}
			}
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0004727C File Offset: 0x0004547C
		private void OnPanelStandardShaderChanged()
		{
			bool flag = this.renderChain == null;
			if (!flag)
			{
				Shader shader = base.panel.standardShader;
				bool flag2 = shader == null;
				if (flag2)
				{
					shader = Shader.Find(UIRUtility.k_DefaultShaderName);
					Debug.Assert(shader != null, "Failed to load UIElements default shader");
					bool flag3 = shader != null;
					if (flag3)
					{
						shader.hideFlags |= HideFlags.DontSaveInEditor;
					}
				}
				this.renderChain.defaultShader = shader;
			}
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x000472F8 File Offset: 0x000454F8
		private void OnPanelStandardWorldSpaceShaderChanged()
		{
			bool flag = this.renderChain == null;
			if (!flag)
			{
				Shader shader = base.panel.standardWorldSpaceShader;
				bool flag2 = shader == null;
				if (flag2)
				{
					shader = Shader.Find(UIRUtility.k_DefaultWorldSpaceShaderName);
					Debug.Assert(shader != null, "Failed to load UIElements default world-space shader");
					bool flag3 = shader != null;
					if (flag3)
					{
						shader.hideFlags |= HideFlags.DontSaveInEditor;
					}
				}
				this.renderChain.defaultWorldSpaceShader = shader;
			}
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x00047374 File Offset: 0x00045574
		private void ResetAllElementsDataRecursive(VisualElement ve)
		{
			ve.renderChainData = default(RenderChainVEData);
			int i = ve.hierarchy.childCount - 1;
			while (i >= 0)
			{
				this.ResetAllElementsDataRecursive(ve.hierarchy[i--]);
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06001406 RID: 5126 RVA: 0x000473C6 File Offset: 0x000455C6
		// (set) Token: 0x06001407 RID: 5127 RVA: 0x000473CE File Offset: 0x000455CE
		private protected bool disposed { protected get; private set; }

		// Token: 0x06001408 RID: 5128 RVA: 0x000473D8 File Offset: 0x000455D8
		protected override void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.DetachFromPanel();
				}
				this.disposed = true;
			}
		}

		// Token: 0x04000947 RID: 2375
		private BaseVisualElementPanel attachedPanel;

		// Token: 0x04000948 RID: 2376
		internal RenderChain renderChain;

		// Token: 0x04000949 RID: 2377
		private static readonly string s_Description = "Update Rendering";

		// Token: 0x0400094A RID: 2378
		private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(UIRRepaintUpdater.s_Description);
	}
}
