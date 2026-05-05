using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x02000299 RID: 665
	internal abstract class BaseRuntimePanel : Panel
	{
		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06001308 RID: 4872 RVA: 0x000427B3 File Offset: 0x000409B3
		// (set) Token: 0x06001309 RID: 4873 RVA: 0x000427BC File Offset: 0x000409BC
		public GameObject selectableGameObject
		{
			get
			{
				return this.m_SelectableGameObject;
			}
			set
			{
				bool flag = this.m_SelectableGameObject != value;
				if (flag)
				{
					this.AssignPanelToComponents(null);
					this.m_SelectableGameObject = value;
					this.AssignPanelToComponents(this);
				}
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x0600130A RID: 4874 RVA: 0x000427F3 File Offset: 0x000409F3
		// (set) Token: 0x0600130B RID: 4875 RVA: 0x000427FC File Offset: 0x000409FC
		public float sortingPriority
		{
			get
			{
				return this.m_SortingPriority;
			}
			set
			{
				bool flag = !Mathf.Approximately(this.m_SortingPriority, value);
				if (flag)
				{
					this.m_SortingPriority = value;
					bool flag2 = this.contextType == ContextType.Player;
					if (flag2)
					{
						UIElementsRuntimeUtility.SetPanelOrderingDirty();
					}
				}
			}
		}

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x0600130C RID: 4876 RVA: 0x0004283C File Offset: 0x00040A3C
		// (remove) Token: 0x0600130D RID: 4877 RVA: 0x00042874 File Offset: 0x00040A74
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action destroyed;

		// Token: 0x0600130E RID: 4878 RVA: 0x000428AC File Offset: 0x00040AAC
		protected BaseRuntimePanel(ScriptableObject ownerObject, EventDispatcher dispatcher = null) : base(ownerObject, ContextType.Player, dispatcher)
		{
			this.m_RuntimePanelCreationIndex = BaseRuntimePanel.s_CurrentRuntimePanelCounter++;
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x00042908 File Offset: 0x00040B08
		protected override void Dispose(bool disposing)
		{
			bool disposed = base.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					Action action = this.destroyed;
					if (action != null)
					{
						action();
					}
				}
				base.Dispose(disposing);
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06001310 RID: 4880 RVA: 0x00042944 File Offset: 0x00040B44
		// (set) Token: 0x06001311 RID: 4881 RVA: 0x0004295C File Offset: 0x00040B5C
		internal override Shader standardWorldSpaceShader
		{
			get
			{
				return this.m_StandardWorldSpaceShader;
			}
			set
			{
				bool flag = this.m_StandardWorldSpaceShader != value;
				if (flag)
				{
					this.m_StandardWorldSpaceShader = value;
					base.InvokeStandardWorldSpaceShaderChanged();
				}
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x0004298C File Offset: 0x00040B8C
		// (set) Token: 0x06001313 RID: 4883 RVA: 0x000429A4 File Offset: 0x00040BA4
		internal bool drawToCameras
		{
			get
			{
				return this.m_DrawToCameras;
			}
			set
			{
				bool flag = this.m_DrawToCameras != value;
				if (flag)
				{
					this.m_DrawToCameras = value;
					UIRRepaintUpdater uirrepaintUpdater = this.GetUpdater(VisualTreeUpdatePhase.Repaint) as UIRRepaintUpdater;
					if (uirrepaintUpdater != null)
					{
						uirrepaintUpdater.DestroyRenderChain();
					}
				}
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x000429E3 File Offset: 0x00040BE3
		// (set) Token: 0x06001315 RID: 4885 RVA: 0x000429EB File Offset: 0x00040BEB
		internal int targetDisplay { get; set; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x000429F4 File Offset: 0x00040BF4
		internal int screenRenderingWidth
		{
			get
			{
				return BaseRuntimePanel.getScreenRenderingWidth(this.targetDisplay);
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06001317 RID: 4887 RVA: 0x00042A01 File Offset: 0x00040C01
		internal int screenRenderingHeight
		{
			get
			{
				return BaseRuntimePanel.getScreenRenderingHeight(this.targetDisplay);
			}
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x00042A10 File Offset: 0x00040C10
		internal static int getScreenRenderingHeight(int display)
		{
			return (display >= 0 && display < Display.displays.Length) ? Display.displays[display].renderingHeight : Screen.height;
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x00042A44 File Offset: 0x00040C44
		internal static int getScreenRenderingWidth(int display)
		{
			return (display >= 0 && display < Display.displays.Length) ? Display.displays[display].renderingWidth : Screen.width;
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x00042A78 File Offset: 0x00040C78
		public override void Repaint(Event e)
		{
			bool flag = this.targetTexture == null;
			if (flag)
			{
				RenderTexture active = RenderTexture.active;
				int num = (active != null) ? active.width : this.screenRenderingWidth;
				int num2 = (active != null) ? active.height : this.screenRenderingHeight;
				GL.Viewport(new Rect(0f, 0f, (float)num, (float)num2));
				base.Repaint(e);
			}
			else
			{
				Camera current = Camera.current;
				RenderTexture active2 = RenderTexture.active;
				Camera.SetupCurrent(null);
				RenderTexture.active = this.targetTexture;
				GL.Viewport(new Rect(0f, 0f, (float)this.targetTexture.width, (float)this.targetTexture.height));
				base.Repaint(e);
				Camera.SetupCurrent(current);
				RenderTexture.active = active2;
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x00042B56 File Offset: 0x00040D56
		// (set) Token: 0x0600131C RID: 4892 RVA: 0x00042B5E File Offset: 0x00040D5E
		public Func<Vector2, Vector2> screenToPanelSpace
		{
			get
			{
				return this.m_ScreenToPanelSpace;
			}
			set
			{
				this.m_ScreenToPanelSpace = (value ?? BaseRuntimePanel.DefaultScreenToPanelSpace);
			}
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x00042B70 File Offset: 0x00040D70
		internal Vector2 ScreenToPanel(Vector2 screen)
		{
			return this.screenToPanelSpace(screen) / base.scale;
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x00042B9C File Offset: 0x00040D9C
		internal bool ScreenToPanel(Vector2 screenPosition, Vector2 screenDelta, out Vector2 panelPosition, out Vector2 panelDelta, bool allowOutside = false)
		{
			panelPosition = this.ScreenToPanel(screenPosition);
			bool flag = !allowOutside;
			Vector2 vector;
			if (flag)
			{
				Rect layout = this.visualTree.layout;
				bool flag2 = !layout.Contains(panelPosition);
				if (flag2)
				{
					panelDelta = screenDelta;
					return false;
				}
				vector = this.ScreenToPanel(screenPosition - screenDelta);
				bool flag3 = !layout.Contains(vector);
				if (flag3)
				{
					panelDelta = screenDelta;
					return true;
				}
			}
			else
			{
				vector = this.ScreenToPanel(screenPosition - screenDelta);
			}
			panelDelta = panelPosition - vector;
			return true;
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x00042C4C File Offset: 0x00040E4C
		private void AssignPanelToComponents(BaseRuntimePanel panel)
		{
			bool flag = this.selectableGameObject == null;
			if (!flag)
			{
				List<IRuntimePanelComponent> list = ObjectListPool<IRuntimePanelComponent>.Get();
				try
				{
					this.selectableGameObject.GetComponents<IRuntimePanelComponent>(list);
					foreach (IRuntimePanelComponent runtimePanelComponent in list)
					{
						runtimePanelComponent.panel = panel;
					}
				}
				finally
				{
					ObjectListPool<IRuntimePanelComponent>.Release(list);
				}
			}
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x00042CE0 File Offset: 0x00040EE0
		internal void PointerLeavesPanel(int pointerId, Vector2 position)
		{
			base.ClearCachedElementUnderPointer(pointerId, null);
			base.CommitElementUnderPointers();
			PointerDeviceState.SavePointerPosition(pointerId, position, null, this.contextType);
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x00042D02 File Offset: 0x00040F02
		internal void PointerEntersPanel(int pointerId, Vector2 position)
		{
			PointerDeviceState.SavePointerPosition(pointerId, position, this, this.contextType);
		}

		// Token: 0x040008A3 RID: 2211
		private GameObject m_SelectableGameObject;

		// Token: 0x040008A4 RID: 2212
		private static int s_CurrentRuntimePanelCounter = 0;

		// Token: 0x040008A5 RID: 2213
		internal readonly int m_RuntimePanelCreationIndex;

		// Token: 0x040008A6 RID: 2214
		private float m_SortingPriority = 0f;

		// Token: 0x040008A7 RID: 2215
		internal int resolvedSortingIndex = 0;

		// Token: 0x040008A9 RID: 2217
		private Shader m_StandardWorldSpaceShader;

		// Token: 0x040008AA RID: 2218
		private bool m_DrawToCameras;

		// Token: 0x040008AB RID: 2219
		internal RenderTexture targetTexture = null;

		// Token: 0x040008AC RID: 2220
		internal Matrix4x4 panelToWorld = Matrix4x4.identity;

		// Token: 0x040008AE RID: 2222
		internal static readonly Func<Vector2, Vector2> DefaultScreenToPanelSpace = (Vector2 p) => p;

		// Token: 0x040008AF RID: 2223
		private Func<Vector2, Vector2> m_ScreenToPanelSpace = BaseRuntimePanel.DefaultScreenToPanelSpace;
	}
}
