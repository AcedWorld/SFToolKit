using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine.Rendering.UI;

namespace UnityEngine.Rendering
{
	// Token: 0x02000063 RID: 99
	public sealed class DebugManager
	{
		// Token: 0x06000324 RID: 804 RVA: 0x0000D720 File Offset: 0x0000B920
		private void RegisterActions()
		{
			this.m_DebugActions = new DebugActionDesc[9];
			this.m_DebugActionStates = new DebugActionState[9];
			this.AddAction(DebugAction.EnableDebugMenu, new DebugActionDesc
			{
				buttonTriggerList = 
				{
					new string[]
					{
						"Enable Debug Button 1",
						"Enable Debug Button 2"
					}
				},
				keyTriggerList = 
				{
					new KeyCode[]
					{
						KeyCode.LeftControl,
						KeyCode.Backspace
					}
				},
				repeatMode = DebugActionRepeatMode.Never
			});
			this.AddAction(DebugAction.ResetAll, new DebugActionDesc
			{
				keyTriggerList = 
				{
					new KeyCode[]
					{
						KeyCode.LeftAlt,
						KeyCode.Backspace
					}
				},
				buttonTriggerList = 
				{
					new string[]
					{
						"Debug Reset",
						"Enable Debug Button 2"
					}
				},
				repeatMode = DebugActionRepeatMode.Never
			});
			this.AddAction(DebugAction.NextDebugPanel, new DebugActionDesc
			{
				buttonTriggerList = 
				{
					new string[]
					{
						"Debug Next"
					}
				},
				repeatMode = DebugActionRepeatMode.Never
			});
			this.AddAction(DebugAction.PreviousDebugPanel, new DebugActionDesc
			{
				buttonTriggerList = 
				{
					new string[]
					{
						"Debug Previous"
					}
				},
				repeatMode = DebugActionRepeatMode.Never
			});
			DebugActionDesc debugActionDesc = new DebugActionDesc();
			debugActionDesc.buttonTriggerList.Add(new string[]
			{
				"Debug Validate"
			});
			debugActionDesc.repeatMode = DebugActionRepeatMode.Never;
			this.AddAction(DebugAction.Action, debugActionDesc);
			this.AddAction(DebugAction.MakePersistent, new DebugActionDesc
			{
				buttonTriggerList = 
				{
					new string[]
					{
						"Debug Persistent"
					}
				},
				repeatMode = DebugActionRepeatMode.Never
			});
			DebugActionDesc debugActionDesc2 = new DebugActionDesc();
			debugActionDesc2.buttonTriggerList.Add(new string[]
			{
				"Debug Multiplier"
			});
			debugActionDesc2.repeatMode = DebugActionRepeatMode.Delay;
			debugActionDesc.repeatDelay = 0f;
			this.AddAction(DebugAction.Multiplier, debugActionDesc2);
			this.AddAction(DebugAction.MoveVertical, new DebugActionDesc
			{
				axisTrigger = "Debug Vertical",
				repeatMode = DebugActionRepeatMode.Delay,
				repeatDelay = 0.16f
			});
			this.AddAction(DebugAction.MoveHorizontal, new DebugActionDesc
			{
				axisTrigger = "Debug Horizontal",
				repeatMode = DebugActionRepeatMode.Delay,
				repeatDelay = 0.16f
			});
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000D94B File Offset: 0x0000BB4B
		internal void EnableInputActions()
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000D950 File Offset: 0x0000BB50
		private void AddAction(DebugAction action, DebugActionDesc desc)
		{
			this.m_DebugActions[(int)action] = desc;
			this.m_DebugActionStates[(int)action] = new DebugActionState();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000D978 File Offset: 0x0000BB78
		private void SampleAction(int actionIndex)
		{
			DebugActionDesc debugActionDesc = this.m_DebugActions[actionIndex];
			DebugActionState debugActionState = this.m_DebugActionStates[actionIndex];
			if (!debugActionState.runningAction)
			{
				for (int i = 0; i < debugActionDesc.buttonTriggerList.Count; i++)
				{
					string[] array = debugActionDesc.buttonTriggerList[i];
					bool flag = true;
					try
					{
						string[] array2 = array;
						for (int j = 0; j < array2.Length; j++)
						{
							flag = Input.GetButton(array2[j]);
							if (!flag)
							{
								break;
							}
						}
					}
					catch (ArgumentException)
					{
						flag = false;
					}
					if (flag)
					{
						debugActionState.TriggerWithButton(array, 1f);
						break;
					}
				}
				if (debugActionDesc.axisTrigger != "")
				{
					try
					{
						float axis = Input.GetAxis(debugActionDesc.axisTrigger);
						if (axis != 0f)
						{
							debugActionState.TriggerWithAxis(debugActionDesc.axisTrigger, axis);
						}
					}
					catch (ArgumentException)
					{
					}
				}
				for (int k = 0; k < debugActionDesc.keyTriggerList.Count; k++)
				{
					bool flag2 = true;
					KeyCode[] array3 = debugActionDesc.keyTriggerList[k];
					try
					{
						KeyCode[] array4 = array3;
						for (int j = 0; j < array4.Length; j++)
						{
							flag2 = Input.GetKey(array4[j]);
							if (!flag2)
							{
								break;
							}
						}
					}
					catch (ArgumentException)
					{
						flag2 = false;
					}
					if (flag2)
					{
						debugActionState.TriggerWithKey(array3, 1f);
						return;
					}
				}
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000DAD8 File Offset: 0x0000BCD8
		private void UpdateAction(int actionIndex)
		{
			DebugActionDesc desc = this.m_DebugActions[actionIndex];
			DebugActionState debugActionState = this.m_DebugActionStates[actionIndex];
			if (debugActionState.runningAction)
			{
				debugActionState.Update(desc);
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000DB08 File Offset: 0x0000BD08
		internal void UpdateActions()
		{
			for (int i = 0; i < this.m_DebugActions.Length; i++)
			{
				this.UpdateAction(i);
				this.SampleAction(i);
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000DB36 File Offset: 0x0000BD36
		internal float GetAction(DebugAction action)
		{
			return this.m_DebugActionStates[(int)action].actionState;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000DB48 File Offset: 0x0000BD48
		internal bool GetActionToggleDebugMenuWithTouch()
		{
			int touchCount = Input.touchCount;
			TouchPhase? touchPhase = new TouchPhase?(TouchPhase.Began);
			if (touchCount == 3)
			{
				foreach (Touch touch in Input.touches)
				{
					if ((touchPhase == null || touch.phase == touchPhase.Value) && touch.tapCount == 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000DBA8 File Offset: 0x0000BDA8
		internal bool GetActionReleaseScrollTarget()
		{
			bool flag = Input.mouseScrollDelta != Vector2.zero;
			bool touchSupported = Input.touchSupported;
			return flag || touchSupported;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		private void RegisterInputs()
		{
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600032E RID: 814 RVA: 0x0000DBCE File Offset: 0x0000BDCE
		public static DebugManager instance
		{
			get
			{
				return DebugManager.s_Instance.Value;
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000DBDA File Offset: 0x0000BDDA
		private void UpdateReadOnlyCollection()
		{
			this.m_Panels.Sort();
			this.m_ReadOnlyPanels = this.m_Panels.AsReadOnly();
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000DBF8 File Offset: 0x0000BDF8
		public ReadOnlyCollection<DebugUI.Panel> panels
		{
			get
			{
				if (this.m_ReadOnlyPanels == null)
				{
					this.UpdateReadOnlyCollection();
				}
				return this.m_ReadOnlyPanels;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000331 RID: 817 RVA: 0x0000DC10 File Offset: 0x0000BE10
		// (remove) Token: 0x06000332 RID: 818 RVA: 0x0000DC48 File Offset: 0x0000BE48
		public event Action<bool> onDisplayRuntimeUIChanged = delegate(bool <p0>)
		{
		};

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000333 RID: 819 RVA: 0x0000DC80 File Offset: 0x0000BE80
		// (remove) Token: 0x06000334 RID: 820 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
		public event Action onSetDirty = delegate()
		{
		};

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000335 RID: 821 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		// (remove) Token: 0x06000336 RID: 822 RVA: 0x0000DD28 File Offset: 0x0000BF28
		private event Action resetData;

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0000DD5D File Offset: 0x0000BF5D
		public bool isAnyDebugUIActive
		{
			get
			{
				return this.displayRuntimeUI || this.displayPersistentRuntimeUI;
			}
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000DD70 File Offset: 0x0000BF70
		private DebugManager()
		{
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000DE03 File Offset: 0x0000C003
		public void RefreshEditor()
		{
			this.refreshEditorRequested = true;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000DE0C File Offset: 0x0000C00C
		public void Reset()
		{
			Action action = this.resetData;
			if (action != null)
			{
				action();
			}
			this.ReDrawOnScreenDebug();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000DE25 File Offset: 0x0000C025
		public void ReDrawOnScreenDebug()
		{
			if (this.displayRuntimeUI)
			{
				DebugUIHandlerCanvas rootUICanvas = this.m_RootUICanvas;
				if (rootUICanvas == null)
				{
					return;
				}
				rootUICanvas.RequestHierarchyReset();
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000DE3F File Offset: 0x0000C03F
		public void RegisterData(IDebugData data)
		{
			this.resetData += data.GetReset();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000DE4D File Offset: 0x0000C04D
		public void UnregisterData(IDebugData data)
		{
			this.resetData -= data.GetReset();
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000DE5C File Offset: 0x0000C05C
		public int GetState()
		{
			int num = 17;
			foreach (DebugUI.Panel panel in this.m_Panels)
			{
				num = num * 23 + panel.GetHashCode();
			}
			return num;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000DEB8 File Offset: 0x0000C0B8
		internal void RegisterRootCanvas(DebugUIHandlerCanvas root)
		{
			this.m_Root = root.gameObject;
			this.m_RootUICanvas = root;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000DECD File Offset: 0x0000C0CD
		internal void ChangeSelection(DebugUIHandlerWidget widget, bool fromNext)
		{
			this.m_RootUICanvas.ChangeSelection(widget, fromNext);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000DEDC File Offset: 0x0000C0DC
		internal void SetScrollTarget(DebugUIHandlerWidget widget)
		{
			if (this.m_RootUICanvas != null)
			{
				this.m_RootUICanvas.SetScrollTarget(widget);
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
		private void EnsurePersistentCanvas()
		{
			if (this.m_RootUIPersistentCanvas == null)
			{
				DebugUIHandlerPersistentCanvas debugUIHandlerPersistentCanvas = Object.FindObjectOfType<DebugUIHandlerPersistentCanvas>();
				if (debugUIHandlerPersistentCanvas == null)
				{
					this.m_PersistentRoot = Object.Instantiate<Transform>(Resources.Load<Transform>("DebugUIPersistentCanvas")).gameObject;
					this.m_PersistentRoot.name = "[Debug Canvas - Persistent]";
					this.m_PersistentRoot.transform.localPosition = Vector3.zero;
				}
				else
				{
					this.m_PersistentRoot = debugUIHandlerPersistentCanvas.gameObject;
				}
				this.m_RootUIPersistentCanvas = this.m_PersistentRoot.GetComponent<DebugUIHandlerPersistentCanvas>();
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000DF80 File Offset: 0x0000C180
		internal void TogglePersistent(DebugUI.Widget widget, int? forceTupleIndex = null)
		{
			if (widget == null)
			{
				return;
			}
			this.EnsurePersistentCanvas();
			DebugUI.Value value = widget as DebugUI.Value;
			if (value != null)
			{
				this.m_RootUIPersistentCanvas.Toggle(value, null);
				return;
			}
			DebugUI.ValueTuple valueTuple = widget as DebugUI.ValueTuple;
			if (valueTuple == null)
			{
				DebugUI.Container container = widget as DebugUI.Container;
				if (container != null)
				{
					int value2 = container.children.Max(delegate(DebugUI.Widget w)
					{
						DebugUI.ValueTuple valueTuple2 = w as DebugUI.ValueTuple;
						if (valueTuple2 == null)
						{
							return -1;
						}
						return valueTuple2.pinnedElementIndex;
					});
					using (IEnumerator<DebugUI.Widget> enumerator = container.children.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							DebugUI.Widget widget2 = enumerator.Current;
							if (widget2 is DebugUI.Value || widget2 is DebugUI.ValueTuple)
							{
								this.TogglePersistent(widget2, new int?(value2));
							}
						}
						return;
					}
				}
				Debug.Log("Only readonly items can be made persistent.");
				return;
			}
			this.m_RootUIPersistentCanvas.Toggle(valueTuple, forceTupleIndex);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000E06C File Offset: 0x0000C26C
		private void OnPanelDirty(DebugUI.Panel panel)
		{
			this.onSetDirty();
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000E07C File Offset: 0x0000C27C
		public int PanelIndex([DisallowNull] string displayName)
		{
			if (displayName == null)
			{
				displayName = string.Empty;
			}
			for (int i = 0; i < this.m_Panels.Count; i++)
			{
				if (displayName.Equals(this.m_Panels[i].displayName, StringComparison.InvariantCultureIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000E0C6 File Offset: 0x0000C2C6
		public string PanelDiplayName([DisallowNull] int panelIndex)
		{
			if (panelIndex < 0 || panelIndex > this.m_Panels.Count - 1)
			{
				return string.Empty;
			}
			return this.m_Panels[panelIndex].displayName;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000E0F3 File Offset: 0x0000C2F3
		public void RequestEditorWindowPanelIndex(int index)
		{
			this.m_RequestedPanelIndex = new int?(index);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000E101 File Offset: 0x0000C301
		internal int? GetRequestedEditorWindowPanelIndex()
		{
			int? requestedPanelIndex = this.m_RequestedPanelIndex;
			this.m_RequestedPanelIndex = null;
			return requestedPanelIndex;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000E118 File Offset: 0x0000C318
		public DebugUI.Panel GetPanel(string displayName, bool createIfNull = false, int groupIndex = 0, bool overrideIfExist = false)
		{
			int num = this.PanelIndex(displayName);
			DebugUI.Panel panel = (num >= 0) ? this.m_Panels[num] : null;
			if (panel != null)
			{
				if (!overrideIfExist)
				{
					return panel;
				}
				panel.onSetDirty -= this.OnPanelDirty;
				this.RemovePanel(panel);
				panel = null;
			}
			if (createIfNull)
			{
				panel = new DebugUI.Panel
				{
					displayName = displayName,
					groupIndex = groupIndex
				};
				panel.onSetDirty += this.OnPanelDirty;
				this.m_Panels.Add(panel);
				this.UpdateReadOnlyCollection();
			}
			return panel;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
		public int FindPanelIndex(string displayName)
		{
			return this.m_Panels.FindIndex((DebugUI.Panel p) => p.displayName == displayName);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000E1D8 File Offset: 0x0000C3D8
		public void RemovePanel(string displayName)
		{
			DebugUI.Panel panel = null;
			foreach (DebugUI.Panel panel2 in this.m_Panels)
			{
				if (panel2.displayName == displayName)
				{
					panel2.onSetDirty -= this.OnPanelDirty;
					panel = panel2;
					break;
				}
			}
			this.RemovePanel(panel);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000E254 File Offset: 0x0000C454
		public void RemovePanel(DebugUI.Panel panel)
		{
			if (panel == null)
			{
				return;
			}
			this.m_Panels.Remove(panel);
			this.UpdateReadOnlyCollection();
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000E270 File Offset: 0x0000C470
		public DebugUI.Widget[] GetItems(DebugUI.Flags flags)
		{
			List<DebugUI.Widget> list;
			DebugUI.Widget[] result;
			using (ListPool<DebugUI.Widget>.Get(out list))
			{
				foreach (DebugUI.Panel container in this.m_Panels)
				{
					DebugUI.Widget[] itemsFromContainer = this.GetItemsFromContainer(flags, container);
					list.AddRange(itemsFromContainer);
				}
				result = list.ToArray();
			}
			return result;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000E2FC File Offset: 0x0000C4FC
		internal DebugUI.Widget[] GetItemsFromContainer(DebugUI.Flags flags, DebugUI.IContainer container)
		{
			List<DebugUI.Widget> list;
			DebugUI.Widget[] result;
			using (ListPool<DebugUI.Widget>.Get(out list))
			{
				foreach (DebugUI.Widget widget in container.children)
				{
					if (widget.flags.HasFlag(flags))
					{
						list.Add(widget);
					}
					else
					{
						DebugUI.IContainer container2 = widget as DebugUI.IContainer;
						if (container2 != null)
						{
							list.AddRange(this.GetItemsFromContainer(flags, container2));
						}
					}
				}
				result = list.ToArray();
			}
			return result;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000E3AC File Offset: 0x0000C5AC
		public DebugUI.Widget GetItem(string queryPath)
		{
			foreach (DebugUI.Panel container in this.m_Panels)
			{
				DebugUI.Widget item = this.GetItem(queryPath, container);
				if (item != null)
				{
					return item;
				}
			}
			return null;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000E40C File Offset: 0x0000C60C
		private DebugUI.Widget GetItem(string queryPath, DebugUI.IContainer container)
		{
			foreach (DebugUI.Widget widget in container.children)
			{
				if (widget.queryPath == queryPath)
				{
					return widget;
				}
				DebugUI.IContainer container2 = widget as DebugUI.IContainer;
				if (container2 != null)
				{
					DebugUI.Widget item = this.GetItem(queryPath, container2);
					if (item != null)
					{
						return item;
					}
				}
			}
			return null;
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000351 RID: 849 RVA: 0x0000E484 File Offset: 0x0000C684
		// (remove) Token: 0x06000352 RID: 850 RVA: 0x0000E4B8 File Offset: 0x0000C6B8
		public static event Action<DebugManager.UIMode, bool> windowStateChanged;

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000E4EB File Offset: 0x0000C6EB
		// (set) Token: 0x06000354 RID: 852 RVA: 0x0000E4F8 File Offset: 0x0000C6F8
		public bool displayEditorUI
		{
			get
			{
				return this.editorUIState.open;
			}
			set
			{
				this.editorUIState.open = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000E506 File Offset: 0x0000C706
		// (set) Token: 0x06000356 RID: 854 RVA: 0x0000E50E File Offset: 0x0000C70E
		public bool enableRuntimeUI
		{
			get
			{
				return this.m_EnableRuntimeUI;
			}
			set
			{
				if (value != this.m_EnableRuntimeUI)
				{
					this.m_EnableRuntimeUI = value;
					DebugUpdater.SetEnabled(value);
				}
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000357 RID: 855 RVA: 0x0000E526 File Offset: 0x0000C726
		// (set) Token: 0x06000358 RID: 856 RVA: 0x0000E544 File Offset: 0x0000C744
		public bool displayRuntimeUI
		{
			get
			{
				return this.m_Root != null && this.m_Root.activeInHierarchy;
			}
			set
			{
				if (value)
				{
					this.m_Root = Object.Instantiate<Transform>(Resources.Load<Transform>("DebugUICanvas")).gameObject;
					this.m_Root.name = "[Debug Canvas]";
					this.m_Root.transform.localPosition = Vector3.zero;
					this.m_RootUICanvas = this.m_Root.GetComponent<DebugUIHandlerCanvas>();
					this.m_Root.SetActive(true);
				}
				else
				{
					CoreUtils.Destroy(this.m_Root);
					this.m_Root = null;
					this.m_RootUICanvas = null;
				}
				this.onDisplayRuntimeUIChanged(value);
				DebugUpdater.HandleInternalEventSystemComponents(value);
				this.runtimeUIState.open = (this.m_Root != null && this.m_Root.activeInHierarchy);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000359 RID: 857 RVA: 0x0000E604 File Offset: 0x0000C804
		// (set) Token: 0x0600035A RID: 858 RVA: 0x0000E621 File Offset: 0x0000C821
		public bool displayPersistentRuntimeUI
		{
			get
			{
				return this.m_RootUIPersistentCanvas != null && this.m_PersistentRoot.activeInHierarchy;
			}
			set
			{
				if (value)
				{
					this.EnsurePersistentCanvas();
					return;
				}
				CoreUtils.Destroy(this.m_PersistentRoot);
				this.m_PersistentRoot = null;
				this.m_RootUIPersistentCanvas = null;
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000E646 File Offset: 0x0000C846
		[Obsolete("Use DebugManager.instance.displayEditorUI.open property instead. #from(23.1)")]
		public void ToggleEditorUI(bool open)
		{
			this.editorUIState.open = open;
		}

		// Token: 0x040001C7 RID: 455
		private const string kEnableDebugBtn1 = "Enable Debug Button 1";

		// Token: 0x040001C8 RID: 456
		private const string kEnableDebugBtn2 = "Enable Debug Button 2";

		// Token: 0x040001C9 RID: 457
		private const string kDebugPreviousBtn = "Debug Previous";

		// Token: 0x040001CA RID: 458
		private const string kDebugNextBtn = "Debug Next";

		// Token: 0x040001CB RID: 459
		private const string kValidateBtn = "Debug Validate";

		// Token: 0x040001CC RID: 460
		private const string kPersistentBtn = "Debug Persistent";

		// Token: 0x040001CD RID: 461
		private const string kDPadVertical = "Debug Vertical";

		// Token: 0x040001CE RID: 462
		private const string kDPadHorizontal = "Debug Horizontal";

		// Token: 0x040001CF RID: 463
		private const string kMultiplierBtn = "Debug Multiplier";

		// Token: 0x040001D0 RID: 464
		private const string kResetBtn = "Debug Reset";

		// Token: 0x040001D1 RID: 465
		private const string kEnableDebug = "Enable Debug";

		// Token: 0x040001D2 RID: 466
		private DebugActionDesc[] m_DebugActions;

		// Token: 0x040001D3 RID: 467
		private DebugActionState[] m_DebugActionStates;

		// Token: 0x040001D4 RID: 468
		private static readonly Lazy<DebugManager> s_Instance = new Lazy<DebugManager>(() => new DebugManager());

		// Token: 0x040001D5 RID: 469
		private ReadOnlyCollection<DebugUI.Panel> m_ReadOnlyPanels;

		// Token: 0x040001D6 RID: 470
		private readonly List<DebugUI.Panel> m_Panels = new List<DebugUI.Panel>();

		// Token: 0x040001DA RID: 474
		public bool refreshEditorRequested;

		// Token: 0x040001DB RID: 475
		private int? m_RequestedPanelIndex;

		// Token: 0x040001DC RID: 476
		private GameObject m_Root;

		// Token: 0x040001DD RID: 477
		private DebugUIHandlerCanvas m_RootUICanvas;

		// Token: 0x040001DE RID: 478
		private GameObject m_PersistentRoot;

		// Token: 0x040001DF RID: 479
		private DebugUIHandlerPersistentCanvas m_RootUIPersistentCanvas;

		// Token: 0x040001E1 RID: 481
		private DebugManager.UIState editorUIState = new DebugManager.UIState
		{
			mode = DebugManager.UIMode.EditorMode
		};

		// Token: 0x040001E2 RID: 482
		private bool m_EnableRuntimeUI = true;

		// Token: 0x040001E3 RID: 483
		private DebugManager.UIState runtimeUIState = new DebugManager.UIState
		{
			mode = DebugManager.UIMode.RuntimeMode
		};

		// Token: 0x02000168 RID: 360
		public enum UIMode
		{
			// Token: 0x0400060A RID: 1546
			EditorMode,
			// Token: 0x0400060B RID: 1547
			RuntimeMode
		}

		// Token: 0x02000169 RID: 361
		private class UIState
		{
			// Token: 0x1700014D RID: 333
			// (get) Token: 0x060009FD RID: 2557 RVA: 0x0002CABB File Offset: 0x0002ACBB
			// (set) Token: 0x060009FE RID: 2558 RVA: 0x0002CAC3 File Offset: 0x0002ACC3
			public bool open
			{
				get
				{
					return this.m_Open;
				}
				set
				{
					if (this.m_Open == value)
					{
						return;
					}
					this.m_Open = value;
					Action<DebugManager.UIMode, bool> windowStateChanged = DebugManager.windowStateChanged;
					if (windowStateChanged == null)
					{
						return;
					}
					windowStateChanged(this.mode, this.m_Open);
				}
			}

			// Token: 0x0400060C RID: 1548
			public DebugManager.UIMode mode;

			// Token: 0x0400060D RID: 1549
			[SerializeField]
			private bool m_Open;
		}
	}
}
