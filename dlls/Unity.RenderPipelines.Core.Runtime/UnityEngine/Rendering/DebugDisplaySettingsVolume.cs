using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityEngine.Rendering
{
	// Token: 0x0200005F RID: 95
	public class DebugDisplaySettingsVolume : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000CD8E File Offset: 0x0000AF8E
		public IVolumeDebugSettings2 volumeDebugSettings { get; }

		// Token: 0x06000300 RID: 768 RVA: 0x0000CD96 File Offset: 0x0000AF96
		public DebugDisplaySettingsVolume(IVolumeDebugSettings2 volumeDebugSettings)
		{
			this.volumeDebugSettings = volumeDebugSettings;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000CDA5 File Offset: 0x0000AFA5
		public bool AreAnySettingsActive
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000CDA8 File Offset: 0x0000AFA8
		public bool IsPostProcessingAllowed
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000CDAB File Offset: 0x0000AFAB
		public bool IsLightingActive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000CDAE File Offset: 0x0000AFAE
		public bool TryGetScreenClearColor(ref Color color)
		{
			return false;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000CDB1 File Offset: 0x0000AFB1
		public IDebugDisplaySettingsPanelDisposable CreatePanel()
		{
			return new DebugDisplaySettingsVolume.SettingsPanel(this);
		}

		// Token: 0x040001AF RID: 431
		internal int volumeComponentEnumIndex;

		// Token: 0x02000164 RID: 356
		private static class Styles
		{
			// Token: 0x040005FC RID: 1532
			public static readonly GUIContent none = new GUIContent("None");

			// Token: 0x040005FD RID: 1533
			public static readonly GUIContent editorCamera = new GUIContent("Editor Camera");
		}

		// Token: 0x02000165 RID: 357
		private static class Strings
		{
			// Token: 0x040005FE RID: 1534
			public static readonly string none = "None";

			// Token: 0x040005FF RID: 1535
			public static readonly string camera = "Camera";

			// Token: 0x04000600 RID: 1536
			public static readonly string parameter = "Parameter";

			// Token: 0x04000601 RID: 1537
			public static readonly string component = "Component";

			// Token: 0x04000602 RID: 1538
			public static readonly string debugViewNotSupported = "Debug view not supported";

			// Token: 0x04000603 RID: 1539
			public static readonly string volumeInfo = "Volume Info";

			// Token: 0x04000604 RID: 1540
			public static readonly string interpolatedValue = "Interpolated Value";

			// Token: 0x04000605 RID: 1541
			public static readonly string defaultValue = "Default Value";

			// Token: 0x04000606 RID: 1542
			public static readonly string global = "Global";

			// Token: 0x04000607 RID: 1543
			public static readonly string local = "Local";
		}

		// Token: 0x02000166 RID: 358
		internal static class WidgetFactory
		{
			// Token: 0x060009F5 RID: 2549 RVA: 0x0002C160 File Offset: 0x0002A360
			public static DebugUI.EnumField CreateComponentSelector(DebugDisplaySettingsVolume.SettingsPanel panel, Action<DebugUI.Field<int>, int> refresh)
			{
				int num = 0;
				List<GUIContent> list = new List<GUIContent>
				{
					DebugDisplaySettingsVolume.Styles.none
				};
				List<int> list2 = new List<int>
				{
					num++
				};
				foreach (ValueTuple<string, Type> valueTuple in panel.data.volumeDebugSettings.volumeComponentsPathAndType)
				{
					list.Add(new GUIContent
					{
						text = valueTuple.Item1
					});
					list2.Add(num++);
				}
				return new DebugUI.EnumField
				{
					displayName = DebugDisplaySettingsVolume.Strings.component,
					getter = (() => panel.data.volumeDebugSettings.selectedComponent),
					setter = delegate(int value)
					{
						panel.data.volumeDebugSettings.selectedComponent = value;
					},
					enumNames = list.ToArray(),
					enumValues = list2.ToArray(),
					getIndex = (() => panel.data.volumeComponentEnumIndex),
					setIndex = delegate(int value)
					{
						panel.data.volumeComponentEnumIndex = value;
					},
					onValueChanged = refresh
				};
			}

			// Token: 0x060009F6 RID: 2550 RVA: 0x0002C288 File Offset: 0x0002A488
			public static DebugUI.ObjectPopupField CreateCameraSelector(DebugDisplaySettingsVolume.SettingsPanel panel, Action<DebugUI.Field<Object>, Object> refresh)
			{
				return new DebugUI.ObjectPopupField
				{
					displayName = DebugDisplaySettingsVolume.Strings.camera,
					getter = (() => panel.data.volumeDebugSettings.selectedCamera),
					setter = delegate(Object value)
					{
						Camera[] array = panel.data.volumeDebugSettings.cameras.ToArray<Camera>();
						panel.data.volumeDebugSettings.selectedCameraIndex = Array.IndexOf<Camera>(array, value as Camera);
					},
					getObjects = (() => panel.data.volumeDebugSettings.cameras),
					onValueChanged = refresh
				};
			}

			// Token: 0x060009F7 RID: 2551 RVA: 0x0002C2F0 File Offset: 0x0002A4F0
			private static DebugUI.Widget CreateVolumeParameterWidget(string name, VolumeParameter param, Func<bool> isHiddenCallback = null)
			{
				DebugDisplaySettingsVolume.WidgetFactory.<>c__DisplayClass2_0 CS$<>8__locals1 = new DebugDisplaySettingsVolume.WidgetFactory.<>c__DisplayClass2_0();
				CS$<>8__locals1.param = param;
				if (CS$<>8__locals1.param == null)
				{
					DebugUI.Value value3 = new DebugUI.Value();
					value3.displayName = name;
					value3.getter = (() => "-");
					return value3;
				}
				CS$<>8__locals1.parameterType = CS$<>8__locals1.param.GetType();
				if (CS$<>8__locals1.parameterType == typeof(ColorParameter))
				{
					ColorParameter p = (ColorParameter)CS$<>8__locals1.param;
					return new DebugUI.ColorField
					{
						displayName = name,
						hdr = p.hdr,
						showAlpha = p.showAlpha,
						getter = (() => p.value),
						setter = delegate(Color value)
						{
							p.value = value;
						},
						isHiddenCallback = isHiddenCallback
					};
				}
				if (CS$<>8__locals1.parameterType == typeof(BoolParameter))
				{
					BoolParameter p = (BoolParameter)CS$<>8__locals1.param;
					return new DebugUI.BoolField
					{
						displayName = name,
						getter = (() => p.value),
						setter = delegate(bool value)
						{
							p.value = value;
						},
						isHiddenCallback = isHiddenCallback
					};
				}
				Type[] genericTypeArguments = CS$<>8__locals1.parameterType.GetTypeInfo().BaseType.GenericTypeArguments;
				if (genericTypeArguments.Length != 0 && genericTypeArguments[0].IsArray)
				{
					return new DebugUI.ObjectListField
					{
						displayName = name,
						getter = (() => (Object[])CS$<>8__locals1.parameterType.GetProperty("value").GetValue(CS$<>8__locals1.param, null)),
						type = CS$<>8__locals1.parameterType
					};
				}
				CS$<>8__locals1.property = CS$<>8__locals1.param.GetType().GetProperty("value");
				MethodInfo method = CS$<>8__locals1.property.PropertyType.GetMethod("ToString", Type.EmptyTypes);
				if (!(method == null) && !(method.DeclaringType == typeof(object)) && !(method.DeclaringType == typeof(Object)))
				{
					return new DebugUI.Value
					{
						displayName = name,
						getter = delegate
						{
							object value4 = CS$<>8__locals1.property.GetValue(CS$<>8__locals1.param);
							if (value4 != null)
							{
								return value4.ToString();
							}
							return DebugDisplaySettingsVolume.Strings.none;
						},
						isHiddenCallback = isHiddenCallback
					};
				}
				PropertyInfo nameProp = CS$<>8__locals1.property.PropertyType.GetProperty("name");
				if (nameProp == null)
				{
					DebugUI.Value value2 = new DebugUI.Value();
					value2.displayName = name;
					value2.getter = (() => DebugDisplaySettingsVolume.Strings.debugViewNotSupported);
					return value2;
				}
				return new DebugUI.Value
				{
					displayName = name,
					getter = delegate
					{
						object value4 = CS$<>8__locals1.property.GetValue(CS$<>8__locals1.param);
						if (value4 == null || value4.Equals(null))
						{
							return DebugDisplaySettingsVolume.Strings.none;
						}
						return nameProp.GetValue(value4) ?? DebugDisplaySettingsVolume.Strings.none;
					},
					isHiddenCallback = isHiddenCallback
				};
			}

			// Token: 0x060009F8 RID: 2552 RVA: 0x0002C5C4 File Offset: 0x0002A7C4
			public static DebugUI.Table CreateVolumeTable(DebugDisplaySettingsVolume data)
			{
				DebugDisplaySettingsVolume.WidgetFactory.<>c__DisplayClass3_0 CS$<>8__locals1 = new DebugDisplaySettingsVolume.WidgetFactory.<>c__DisplayClass3_0();
				CS$<>8__locals1.data = data;
				CS$<>8__locals1.table = new DebugUI.Table
				{
					displayName = DebugDisplaySettingsVolume.Strings.parameter,
					isReadOnly = true
				};
				CS$<>8__locals1.selectedType = CS$<>8__locals1.data.volumeDebugSettings.selectedComponentType;
				if (CS$<>8__locals1.selectedType == null)
				{
					return CS$<>8__locals1.table;
				}
				VolumeStack volumeStack = CS$<>8__locals1.data.volumeDebugSettings.selectedCameraVolumeStack ?? VolumeManager.instance.stack;
				CS$<>8__locals1.stackComponent = volumeStack.GetComponent(CS$<>8__locals1.selectedType);
				if (CS$<>8__locals1.stackComponent == null)
				{
					return CS$<>8__locals1.table;
				}
				CS$<>8__locals1.volumes = CS$<>8__locals1.data.volumeDebugSettings.GetVolumes();
				CS$<>8__locals1.inst = (VolumeComponent)ScriptableObject.CreateInstance(CS$<>8__locals1.selectedType);
				DebugDisplaySettingsVolume.WidgetFactory.<>c__DisplayClass3_0 CS$<>8__locals2 = CS$<>8__locals1;
				DebugUI.Table.Row row = new DebugUI.Table.Row();
				row.displayName = DebugDisplaySettingsVolume.Strings.volumeInfo;
				row.opened = true;
				ObservableList<DebugUI.Widget> children = row.children;
				DebugUI.Value value = new DebugUI.Value();
				value.displayName = DebugDisplaySettingsVolume.Strings.interpolatedValue;
				value.getter = (() => string.Empty);
				children.Add(value);
				CS$<>8__locals2.row = row;
				DebugUI.Table.Row row2 = new DebugUI.Table.Row();
				row2.displayName = "GameObject";
				ObservableList<DebugUI.Widget> children2 = row2.children;
				DebugUI.Value value2 = new DebugUI.Value();
				value2.getter = (() => string.Empty);
				children2.Add(value2);
				DebugUI.Table.Row row3 = row2;
				Volume[] volumes = CS$<>8__locals1.volumes;
				for (int i = 0; i < volumes.Length; i++)
				{
					Volume volume = volumes[i];
					VolumeProfile volumeProfile = volume.HasInstantiatedProfile() ? volume.profile : volume.sharedProfile;
					CS$<>8__locals1.row.children.Add(new DebugUI.Value
					{
						displayName = volumeProfile.name,
						getter = delegate
						{
							string str = volume.isGlobal ? DebugDisplaySettingsVolume.Strings.global : DebugDisplaySettingsVolume.Strings.local;
							float volumeWeight = CS$<>8__locals1.data.volumeDebugSettings.GetVolumeWeight(volume);
							return str + " (" + (volumeWeight * 100f).ToString() + "%)";
						}
					});
					row3.children.Add(new DebugUI.ObjectField
					{
						displayName = volumeProfile.name,
						getter = (() => volume)
					});
				}
				ObservableList<DebugUI.Widget> children3 = CS$<>8__locals1.row.children;
				DebugUI.Value value3 = new DebugUI.Value();
				value3.displayName = DebugDisplaySettingsVolume.Strings.defaultValue;
				value3.getter = (() => string.Empty);
				children3.Add(value3);
				CS$<>8__locals1.table.children.Add(CS$<>8__locals1.row);
				ObservableList<DebugUI.Widget> children4 = row3.children;
				DebugUI.Value value4 = new DebugUI.Value();
				value4.getter = (() => string.Empty);
				children4.Add(value4);
				CS$<>8__locals1.table.children.Add(row3);
				CS$<>8__locals1.rows = new List<DebugUI.Table.Row>();
				CS$<>8__locals1.<CreateVolumeTable>g__AddParameterRows|0(CS$<>8__locals1.selectedType, null, 0);
				foreach (DebugUI.Table.Row item in from t in CS$<>8__locals1.rows
				orderby t.displayName
				select t)
				{
					CS$<>8__locals1.table.children.Add(item);
				}
				CS$<>8__locals1.data.volumeDebugSettings.RefreshVolumes(CS$<>8__locals1.volumes);
				for (int j = 0; j < CS$<>8__locals1.volumes.Length; j++)
				{
					CS$<>8__locals1.table.SetColumnVisibility(j + 1, CS$<>8__locals1.data.volumeDebugSettings.VolumeHasInfluence(CS$<>8__locals1.volumes[j]));
				}
				CS$<>8__locals1.timer = 0f;
				CS$<>8__locals1.refreshRate = 0.2f;
				CS$<>8__locals1.table.isHiddenCallback = delegate()
				{
					CS$<>8__locals1.timer += Time.deltaTime;
					if (CS$<>8__locals1.timer >= CS$<>8__locals1.refreshRate)
					{
						if (CS$<>8__locals1.data.volumeDebugSettings.selectedCamera != null)
						{
							Volume[] volumes2 = CS$<>8__locals1.data.volumeDebugSettings.GetVolumes();
							if (!CS$<>8__locals1.data.volumeDebugSettings.RefreshVolumes(volumes2))
							{
								for (int k = 0; k < volumes2.Length; k++)
								{
									bool visible = CS$<>8__locals1.data.volumeDebugSettings.VolumeHasInfluence(volumes2[k]);
									CS$<>8__locals1.table.SetColumnVisibility(k + 1, visible);
								}
							}
							if (!CS$<>8__locals1.volumes.SequenceEqual(volumes2))
							{
								CS$<>8__locals1.volumes = volumes2;
								DebugManager.instance.ReDrawOnScreenDebug();
							}
						}
						CS$<>8__locals1.timer = 0f;
					}
					return false;
				};
				return CS$<>8__locals1.table;
			}
		}

		// Token: 0x02000167 RID: 359
		[DisplayInfo(name = "Volume", order = 2147483647)]
		internal class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsVolume>
		{
			// Token: 0x060009F9 RID: 2553 RVA: 0x0002C9C4 File Offset: 0x0002ABC4
			public SettingsPanel(DebugDisplaySettingsVolume data) : base(data)
			{
				base.AddWidget(DebugDisplaySettingsVolume.WidgetFactory.CreateComponentSelector(this, delegate(DebugUI.Field<int> _, int __)
				{
					this.Refresh();
				}));
				base.AddWidget(DebugDisplaySettingsVolume.WidgetFactory.CreateCameraSelector(this, delegate(DebugUI.Field<Object> _, Object __)
				{
					this.Refresh();
				}));
			}

			// Token: 0x060009FA RID: 2554 RVA: 0x0002CA00 File Offset: 0x0002AC00
			private void Refresh()
			{
				DebugUI.Panel panel = DebugManager.instance.GetPanel(this.PanelName, false, 0, false);
				if (panel == null)
				{
					return;
				}
				bool flag = false;
				if (this.m_VolumeTable != null)
				{
					flag = true;
					panel.children.Remove(this.m_VolumeTable);
				}
				if (this.m_Data.volumeDebugSettings.selectedComponent > 0 && this.m_Data.volumeDebugSettings.selectedCamera != null)
				{
					flag = true;
					this.m_VolumeTable = DebugDisplaySettingsVolume.WidgetFactory.CreateVolumeTable(this.m_Data);
					base.AddWidget(this.m_VolumeTable);
					panel.children.Add(this.m_VolumeTable);
				}
				if (flag)
				{
					DebugManager.instance.ReDrawOnScreenDebug();
				}
			}

			// Token: 0x04000608 RID: 1544
			private DebugUI.Table m_VolumeTable;
		}
	}
}
