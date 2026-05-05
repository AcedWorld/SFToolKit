using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEngine.NVIDIA
{
	// Token: 0x0200001A RID: 26
	internal class DebugView
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00003600 File Offset: 0x00001800
		internal void Reset()
		{
			this.InternalReset();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003608 File Offset: 0x00001808
		internal void Update()
		{
			this.InternalUpdate();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003610 File Offset: 0x00001810
		internal DebugUI.Widget CreateWidget()
		{
			return this.InternalCreateWidget();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003618 File Offset: 0x00001818
		private void InternalReset()
		{
			GraphicsDevice device = GraphicsDevice.device;
			if (device != null && this.m_DebugView != null)
			{
				device.DeleteDebugView(this.m_DebugView);
			}
			this.m_DebugView = null;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000364C File Offset: 0x0000184C
		private void InternalUpdate()
		{
			GraphicsDevice device = GraphicsDevice.device;
			bool flag = DebugManager.instance.displayRuntimeUI || DebugManager.instance.displayEditorUI;
			if (device != null)
			{
				if (flag && this.m_DebugView == null)
				{
					this.m_DebugView = device.CreateDebugView();
				}
				else if (!flag && this.m_DebugView != null)
				{
					device.DeleteDebugView(this.m_DebugView);
					this.m_DebugView = null;
				}
			}
			if (device != null)
			{
				if (this.m_DebugView != null)
				{
					this.m_Data.deviceState = DebugView.DeviceState.Active;
					this.m_Data.dlssSupported = device.IsFeatureAvailable(GraphicsDeviceFeature.DLSS);
					device.UpdateDebugView(this.m_DebugView);
					DebugView.TranslateDlssFeatureArray(this.m_Data.dlssFeatureInfos, this.m_DebugView);
				}
				else
				{
					this.m_Data.deviceState = DebugView.DeviceState.Unknown;
				}
			}
			else if (device == null)
			{
				bool flag2 = NVUnityPlugin.IsLoaded();
				this.m_Data.deviceState = (flag2 ? DebugView.DeviceState.DeviceCreationFailed : DebugView.DeviceState.MissingPluginDLL);
				this.m_Data.dlssSupported = false;
				DebugView.ClearFeatureStateContainer(this.m_Data.dlssFeatureInfos);
			}
			this.UpdateDebugUITable();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000374C File Offset: 0x0000194C
		private static void ClearFeatureStateContainer(DebugView.Container<DLSSDebugFeatureInfos>[] containerArray)
		{
			for (int i = 0; i < containerArray.Length; i++)
			{
				containerArray[i].data = default(DLSSDebugFeatureInfos);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003778 File Offset: 0x00001978
		private static void TranslateDlssFeatureArray(DebugView.Container<DLSSDebugFeatureInfos>[] containerArray, in GraphicsDeviceDebugView debugView)
		{
			DebugView.ClearFeatureStateContainer(containerArray);
			if (!debugView.dlssFeatureInfos.Any<DLSSDebugFeatureInfos>())
			{
				return;
			}
			int num = 0;
			foreach (DLSSDebugFeatureInfos data in debugView.dlssFeatureInfos)
			{
				if (num == containerArray.Length)
				{
					break;
				}
				containerArray[num++].data = data;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000037EC File Offset: 0x000019EC
		private DebugUI.Widget InternalCreateWidget()
		{
			if (this.m_DebugWidget != null)
			{
				return this.m_DebugWidget;
			}
			this.m_DlssViewStateTableHeader = new DebugUI.Table.Row
			{
				displayName = "",
				children = 
				{
					new DebugUI.Container
					{
						displayName = "Status"
					},
					new DebugUI.Container
					{
						displayName = "Input resolution"
					},
					new DebugUI.Container
					{
						displayName = "Output resolution"
					},
					new DebugUI.Container
					{
						displayName = "Quality"
					}
				}
			};
			this.m_DlssViewStateTable = new DebugUI.Table
			{
				displayName = "DLSS Slot ID",
				isReadOnly = true
			};
			this.m_DlssViewStateTable.children.Add(this.m_DlssViewStateTableHeader);
			DebugUI.Container container = new DebugUI.Container();
			container.displayName = "NVIDIA device debug view";
			container.children.Add(new DebugUI.Value
			{
				displayName = "NVUnityPlugin Version",
				getter = delegate
				{
					if (this.m_DebugView != null)
					{
						return this.m_DebugView.deviceVersion.ToString("X2");
					}
					return "-";
				}
			});
			container.children.Add(new DebugUI.Value
			{
				displayName = "NGX API Version",
				getter = delegate
				{
					if (this.m_DebugView != null)
					{
						return this.m_DebugView.ngxVersion.ToString("X2");
					}
					return "-";
				}
			});
			container.children.Add(new DebugUI.Value
			{
				displayName = "Device Status",
				getter = (() => this.m_Data.deviceState.ToString())
			});
			container.children.Add(new DebugUI.Value
			{
				displayName = "DLSS Supported",
				getter = delegate
				{
					if (!this.m_Data.dlssSupported)
					{
						return "False";
					}
					return "True";
				}
			});
			ObservableList<DebugUI.Widget> children = container.children;
			DebugUI.Value value = new DebugUI.Value();
			value.displayName = "DLSS Injection Point";
			value.getter = (() => HDRenderPipeline.currentAsset.currentPlatformRenderPipelineSettings.dynamicResolutionSettings.DLSSInjectionPoint);
			children.Add(value);
			container.children.Add(this.m_DlssViewStateTable);
			this.m_DebugWidget = container;
			this.m_Data.dlssFeatureInfos = new DebugView.Container<DLSSDebugFeatureInfos>[4];
			this.m_DlssViewStateTableRows = new DebugUI.Table.Row[this.m_Data.dlssFeatureInfos.Length];
			for (int i = 0; i < this.m_Data.dlssFeatureInfos.Length; i++)
			{
				DebugView.Container<DLSSDebugFeatureInfos> c = new DebugView.Container<DLSSDebugFeatureInfos>
				{
					data = default(DLSSDebugFeatureInfos)
				};
				this.m_Data.dlssFeatureInfos[i] = c;
				DebugUI.Table.Row row = new DebugUI.Table.Row
				{
					children = 
					{
						new DebugUI.Value
						{
							getter = delegate
							{
								if (!c.data.validFeature)
								{
									return "";
								}
								return "Valid";
							}
						},
						new DebugUI.Value
						{
							getter = delegate
							{
								if (!c.data.validFeature)
								{
									return "";
								}
								return DebugView.<InternalCreateWidget>g__resToString|17_0(c.data.execData.subrectWidth, c.data.execData.subrectHeight);
							}
						},
						new DebugUI.Value
						{
							getter = delegate
							{
								if (!c.data.validFeature)
								{
									return "";
								}
								return DebugView.<InternalCreateWidget>g__resToString|17_0(c.data.initData.outputRTWidth, c.data.initData.outputRTHeight);
							}
						},
						new DebugUI.Value
						{
							getter = delegate
							{
								if (!c.data.validFeature)
								{
									return "";
								}
								return c.data.initData.quality.ToString();
							}
						}
					}
				};
				row.isHiddenCallback = (() => !c.data.validFeature);
				this.m_DlssViewStateTableRows[i] = row;
			}
			ObservableList<DebugUI.Widget> children2 = this.m_DlssViewStateTable.children;
			DebugUI.Widget[] dlssViewStateTableRows = this.m_DlssViewStateTableRows;
			children2.Add(dlssViewStateTableRows);
			return this.m_DebugWidget;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003B18 File Offset: 0x00001D18
		private void UpdateDebugUITable()
		{
			for (int i = 0; i < this.m_DlssViewStateTableRows.Length; i++)
			{
				DLSSDebugFeatureInfos data = this.m_Data.dlssFeatureInfos[i].data;
				this.m_DlssViewStateTableRows[i].displayName = (data.validFeature ? Convert.ToString(data.featureSlot) : "");
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003C21 File Offset: 0x00001E21
		[CompilerGenerated]
		internal static string <InternalCreateWidget>g__resToString|17_0(uint a, uint b)
		{
			return a.ToString() + "x" + b.ToString();
		}

		// Token: 0x04000073 RID: 115
		private GraphicsDeviceDebugView m_DebugView;

		// Token: 0x04000074 RID: 116
		private DebugView.Data m_Data = new DebugView.Data();

		// Token: 0x04000075 RID: 117
		private const int MaxDebugRows = 4;

		// Token: 0x04000076 RID: 118
		private DebugUI.Container m_DebugWidget;

		// Token: 0x04000077 RID: 119
		private DebugUI.Table.Row[] m_DlssViewStateTableRows;

		// Token: 0x04000078 RID: 120
		private DebugUI.Container m_DlssViewStateTableHeader;

		// Token: 0x04000079 RID: 121
		private DebugUI.Table m_DlssViewStateTable;

		// Token: 0x0200024A RID: 586
		private enum DeviceState
		{
			// Token: 0x040019F1 RID: 6641
			Unknown,
			// Token: 0x040019F2 RID: 6642
			MissingPluginDLL,
			// Token: 0x040019F3 RID: 6643
			DeviceCreationFailed,
			// Token: 0x040019F4 RID: 6644
			Active
		}

		// Token: 0x0200024B RID: 587
		private class Container<T> where T : struct
		{
			// Token: 0x040019F5 RID: 6645
			public T data = Activator.CreateInstance<T>();
		}

		// Token: 0x0200024C RID: 588
		private class Data
		{
			// Token: 0x040019F6 RID: 6646
			public DebugView.DeviceState deviceState;

			// Token: 0x040019F7 RID: 6647
			public bool dlssSupported;

			// Token: 0x040019F8 RID: 6648
			public DebugView.Container<DLSSDebugFeatureInfos>[] dlssFeatureInfos;
		}
	}
}
