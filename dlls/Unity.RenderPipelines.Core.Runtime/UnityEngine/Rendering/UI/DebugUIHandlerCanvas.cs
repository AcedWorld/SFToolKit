using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000120 RID: 288
	public class DebugUIHandlerCanvas : MonoBehaviour
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x00027D8C File Offset: 0x00025F8C
		private void OnEnable()
		{
			if (this.prefabs == null)
			{
				this.prefabs = new List<DebugUIPrefabBundle>();
			}
			if (this.m_PrefabsMap == null)
			{
				this.m_PrefabsMap = new Dictionary<Type, Transform>();
			}
			if (this.m_UIPanels == null)
			{
				this.m_UIPanels = new List<DebugUIHandlerPanel>();
			}
			DebugManager.instance.RegisterRootCanvas(this);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00027DE0 File Offset: 0x00025FE0
		private void Update()
		{
			int state = DebugManager.instance.GetState();
			if (this.m_DebugTreeState != state)
			{
				this.ResetAllHierarchy();
			}
			this.HandleInput();
			if (this.m_UIPanels != null && this.m_SelectedPanel < this.m_UIPanels.Count && this.m_UIPanels[this.m_SelectedPanel] != null)
			{
				this.m_UIPanels[this.m_SelectedPanel].UpdateScroll();
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00027E57 File Offset: 0x00026057
		internal void RequestHierarchyReset()
		{
			this.m_DebugTreeState = -1;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00027E60 File Offset: 0x00026060
		private void ResetAllHierarchy()
		{
			foreach (object obj in base.transform)
			{
				CoreUtils.Destroy(((Transform)obj).gameObject);
			}
			this.Rebuild();
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00027EC4 File Offset: 0x000260C4
		private void Rebuild()
		{
			this.m_PrefabsMap.Clear();
			foreach (DebugUIPrefabBundle debugUIPrefabBundle in this.prefabs)
			{
				Type type = Type.GetType(debugUIPrefabBundle.type);
				if (type != null && debugUIPrefabBundle.prefab != null)
				{
					this.m_PrefabsMap.Add(type, debugUIPrefabBundle.prefab);
				}
			}
			this.m_UIPanels.Clear();
			this.m_DebugTreeState = DebugManager.instance.GetState();
			ReadOnlyCollection<DebugUI.Panel> panels = DebugManager.instance.panels;
			DebugUIHandlerWidget selectedWidget = null;
			foreach (DebugUI.Panel panel in panels)
			{
				if (!panel.isEditorOnly)
				{
					if (panel.children.Count((DebugUI.Widget x) => !x.isEditorOnly && !x.isHidden) != 0)
					{
						GameObject gameObject = Object.Instantiate<Transform>(this.panelPrefab, base.transform, false).gameObject;
						gameObject.name = panel.displayName;
						DebugUIHandlerPanel component = gameObject.GetComponent<DebugUIHandlerPanel>();
						component.SetPanel(panel);
						component.Canvas = this;
						this.m_UIPanels.Add(component);
						DebugUIHandlerContainer component2 = gameObject.GetComponent<DebugUIHandlerContainer>();
						DebugUIHandlerWidget debugUIHandlerWidget = null;
						this.Traverse(panel, component2.contentHolder, null, ref debugUIHandlerWidget);
						if (debugUIHandlerWidget != null && debugUIHandlerWidget.GetWidget().queryPath.Contains(panel.queryPath))
						{
							selectedWidget = debugUIHandlerWidget;
						}
					}
				}
			}
			this.ActivatePanel(this.m_SelectedPanel, selectedWidget);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00028088 File Offset: 0x00026288
		private void Traverse(DebugUI.IContainer container, Transform parentTransform, DebugUIHandlerWidget parentUIHandler, ref DebugUIHandlerWidget selectedHandler)
		{
			DebugUIHandlerWidget debugUIHandlerWidget = null;
			for (int i = 0; i < container.children.Count; i++)
			{
				DebugUI.Widget widget = container.children[i];
				if (!widget.isEditorOnly && !widget.isHidden)
				{
					Transform original;
					if (!this.m_PrefabsMap.TryGetValue(widget.GetType(), out original))
					{
						string str = "DebugUI widget doesn't have a prefab: ";
						Type type = widget.GetType();
						Debug.LogWarning(str + ((type != null) ? type.ToString() : null));
					}
					else
					{
						GameObject gameObject = Object.Instantiate<Transform>(original, parentTransform, false).gameObject;
						gameObject.name = widget.displayName;
						DebugUIHandlerWidget component = gameObject.GetComponent<DebugUIHandlerWidget>();
						if (component == null)
						{
							string str2 = "DebugUI prefab is missing a DebugUIHandler for: ";
							Type type2 = widget.GetType();
							Debug.LogWarning(str2 + ((type2 != null) ? type2.ToString() : null));
						}
						else
						{
							if (!string.IsNullOrEmpty(this.m_CurrentQueryPath) && widget.queryPath.Equals(this.m_CurrentQueryPath))
							{
								selectedHandler = component;
							}
							if (debugUIHandlerWidget != null)
							{
								debugUIHandlerWidget.nextUIHandler = component;
							}
							component.previousUIHandler = debugUIHandlerWidget;
							debugUIHandlerWidget = component;
							component.parentUIHandler = parentUIHandler;
							component.SetWidget(widget);
							DebugUIHandlerContainer component2 = gameObject.GetComponent<DebugUIHandlerContainer>();
							if (component2 != null)
							{
								DebugUI.IContainer container2 = widget as DebugUI.IContainer;
								if (container2 != null)
								{
									this.Traverse(container2, component2.contentHolder, component, ref selectedHandler);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x000281EC File Offset: 0x000263EC
		private DebugUIHandlerWidget GetWidgetFromPath(string queryPath)
		{
			if (string.IsNullOrEmpty(queryPath))
			{
				return null;
			}
			return this.m_UIPanels[this.m_SelectedPanel].GetComponentsInChildren<DebugUIHandlerWidget>().FirstOrDefault((DebugUIHandlerWidget w) => w.GetWidget().queryPath == queryPath);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0002823C File Offset: 0x0002643C
		private void ActivatePanel(int index, DebugUIHandlerWidget selectedWidget = null)
		{
			if (this.m_UIPanels.Count == 0)
			{
				return;
			}
			if (index >= this.m_UIPanels.Count)
			{
				index = this.m_UIPanels.Count - 1;
			}
			this.m_UIPanels.ForEach(delegate(DebugUIHandlerPanel p)
			{
				p.gameObject.SetActive(false);
			});
			this.m_UIPanels[index].gameObject.SetActive(true);
			this.m_SelectedPanel = index;
			if (selectedWidget == null)
			{
				selectedWidget = this.m_UIPanels[index].GetFirstItem();
			}
			this.ChangeSelection(selectedWidget, true);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x000282E0 File Offset: 0x000264E0
		internal void ChangeSelection(DebugUIHandlerWidget widget, bool fromNext)
		{
			if (widget == null)
			{
				return;
			}
			if (this.m_SelectedWidget != null)
			{
				this.m_SelectedWidget.OnDeselection();
			}
			DebugUIHandlerWidget selectedWidget = this.m_SelectedWidget;
			this.m_SelectedWidget = widget;
			this.SetScrollTarget(widget);
			if (!this.m_SelectedWidget.OnSelection(fromNext, selectedWidget))
			{
				if (fromNext)
				{
					this.SelectNextItem();
					return;
				}
				this.SelectPreviousItem();
				return;
			}
			else
			{
				if (this.m_SelectedWidget == null || this.m_SelectedWidget.GetWidget() == null)
				{
					this.m_CurrentQueryPath = string.Empty;
					return;
				}
				this.m_CurrentQueryPath = this.m_SelectedWidget.GetWidget().queryPath;
				return;
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00028384 File Offset: 0x00026584
		internal void SelectPreviousItem()
		{
			if (this.m_SelectedWidget == null)
			{
				return;
			}
			DebugUIHandlerWidget debugUIHandlerWidget = this.m_SelectedWidget.Previous();
			if (debugUIHandlerWidget != null)
			{
				this.ChangeSelection(debugUIHandlerWidget, false);
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000283C0 File Offset: 0x000265C0
		internal void SelectNextPanel()
		{
			int num = this.m_SelectedPanel + 1;
			if (num >= this.m_UIPanels.Count)
			{
				num = 0;
			}
			num = Mathf.Clamp(num, 0, this.m_UIPanels.Count - 1);
			this.ActivatePanel(num, null);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00028404 File Offset: 0x00026604
		internal void SelectPreviousPanel()
		{
			int num = this.m_SelectedPanel - 1;
			if (num < 0)
			{
				num = this.m_UIPanels.Count - 1;
			}
			num = Mathf.Clamp(num, 0, this.m_UIPanels.Count - 1);
			this.ActivatePanel(num, null);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0002844C File Offset: 0x0002664C
		internal void SelectNextItem()
		{
			if (this.m_SelectedWidget == null)
			{
				return;
			}
			DebugUIHandlerWidget debugUIHandlerWidget = this.m_SelectedWidget.Next();
			if (debugUIHandlerWidget != null)
			{
				this.ChangeSelection(debugUIHandlerWidget, true);
			}
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00028488 File Offset: 0x00026688
		private void ChangeSelectionValue(float multiplier)
		{
			if (this.m_SelectedWidget == null)
			{
				return;
			}
			bool fast = DebugManager.instance.GetAction(DebugAction.Multiplier) != 0f;
			if (multiplier < 0f)
			{
				this.m_SelectedWidget.OnDecrement(fast);
				return;
			}
			this.m_SelectedWidget.OnIncrement(fast);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000284DB File Offset: 0x000266DB
		private void ActivateSelection()
		{
			if (this.m_SelectedWidget == null)
			{
				return;
			}
			this.m_SelectedWidget.OnAction();
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000284F8 File Offset: 0x000266F8
		private void HandleInput()
		{
			if (DebugManager.instance.GetAction(DebugAction.PreviousDebugPanel) != 0f)
			{
				this.SelectPreviousPanel();
			}
			if (DebugManager.instance.GetAction(DebugAction.NextDebugPanel) != 0f)
			{
				this.SelectNextPanel();
			}
			if (DebugManager.instance.GetAction(DebugAction.Action) != 0f)
			{
				this.ActivateSelection();
			}
			if (DebugManager.instance.GetAction(DebugAction.MakePersistent) != 0f && this.m_SelectedWidget != null)
			{
				DebugManager.instance.TogglePersistent(this.m_SelectedWidget.GetWidget(), null);
			}
			float action = DebugManager.instance.GetAction(DebugAction.MoveHorizontal);
			if (action != 0f)
			{
				this.ChangeSelectionValue(action);
			}
			float action2 = DebugManager.instance.GetAction(DebugAction.MoveVertical);
			if (action2 != 0f)
			{
				if (action2 < 0f)
				{
					this.SelectNextItem();
					return;
				}
				this.SelectPreviousItem();
			}
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x000285D0 File Offset: 0x000267D0
		internal void SetScrollTarget(DebugUIHandlerWidget widget)
		{
			if (this.m_UIPanels != null && this.m_SelectedPanel < this.m_UIPanels.Count && this.m_UIPanels[this.m_SelectedPanel] != null)
			{
				this.m_UIPanels[this.m_SelectedPanel].SetScrollTarget(widget);
			}
		}

		// Token: 0x04000510 RID: 1296
		private int m_DebugTreeState;

		// Token: 0x04000511 RID: 1297
		private Dictionary<Type, Transform> m_PrefabsMap;

		// Token: 0x04000512 RID: 1298
		public Transform panelPrefab;

		// Token: 0x04000513 RID: 1299
		public List<DebugUIPrefabBundle> prefabs;

		// Token: 0x04000514 RID: 1300
		private List<DebugUIHandlerPanel> m_UIPanels;

		// Token: 0x04000515 RID: 1301
		private int m_SelectedPanel;

		// Token: 0x04000516 RID: 1302
		private DebugUIHandlerWidget m_SelectedWidget;

		// Token: 0x04000517 RID: 1303
		private string m_CurrentQueryPath;
	}
}
