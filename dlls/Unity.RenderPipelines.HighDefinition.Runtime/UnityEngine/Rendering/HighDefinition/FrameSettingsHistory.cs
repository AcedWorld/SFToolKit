using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B8 RID: 440
	internal struct FrameSettingsHistory
	{
		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x0006E324 File Offset: 0x0006C524
		public static bool enabled
		{
			get
			{
				if (!FrameSettingsHistory.s_PossiblyInUse)
				{
					return FrameSettingsHistory.s_PossiblyInUse = (DebugManager.instance.displayEditorUI || DebugManager.instance.displayRuntimeUI);
				}
				if (DebugManager.instance.displayEditorUI || DebugManager.instance.displayRuntimeUI)
				{
					return true;
				}
				if (FrameSettingsHistory.s_PossiblyInUse)
				{
					return FrameSettingsHistory.s_PossiblyInUse = FrameSettingsHistory.containers.Any((IFrameSettingsHistoryContainer history) => history.frameSettingsHistory.hasDebug);
				}
				return false;
			}
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x0006E3AC File Offset: 0x0006C5AC
		static FrameSettingsHistory()
		{
			FrameSettingsHistory.attributes = new Dictionary<FrameSettingsField, FrameSettingsFieldAttribute>();
			FrameSettingsHistory.attributesGroup = new Dictionary<int, IOrderedEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>>>();
			Dictionary<FrameSettingsField, string> enumNameMap = FrameSettingsFieldAttribute.GetEnumNameMap();
			Type typeFromHandle = typeof(FrameSettingsField);
			foreach (FrameSettingsField key in enumNameMap.Keys)
			{
				FrameSettingsHistory.attributes[key] = typeFromHandle.GetField(enumNameMap[key]).GetCustomAttribute<FrameSettingsFieldAttribute>();
			}
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x0006E4D0 File Offset: 0x0006C6D0
		public static void AggregateFrameSettings(ref FrameSettings aggregatedFrameSettings, Camera camera, HDAdditionalCameraData additionalData, HDRenderPipelineAsset hdrpAsset, HDRenderPipelineAsset defaultHdrpAsset)
		{
			if (hdrpAsset == null && defaultHdrpAsset == null)
			{
				return;
			}
			FrameSettingsHistory.AggregateFrameSettings(ref aggregatedFrameSettings, camera, additionalData, HDRenderPipelineGlobalSettings.instance.GetDefaultFrameSettings((additionalData != null) ? additionalData.defaultFrameSettings : FrameSettingsRenderType.Camera), (hdrpAsset != null) ? hdrpAsset.currentPlatformRenderPipelineSettings : defaultHdrpAsset.currentPlatformRenderPipelineSettings);
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x0006E528 File Offset: 0x0006C728
		public static void AggregateFrameSettings(ref FrameSettings aggregatedFrameSettings, Camera camera, IFrameSettingsHistoryContainer historyContainer, ref FrameSettings defaultFrameSettings, RenderPipelineSettings supportedFeatures)
		{
			FrameSettingsHistory frameSettingsHistory = historyContainer.frameSettingsHistory;
			aggregatedFrameSettings = defaultFrameSettings;
			bool flag = false;
			if (historyContainer.hasCustomFrameSettings)
			{
				FrameSettings.Override(ref aggregatedFrameSettings, historyContainer.frameSettings, historyContainer.frameSettingsMask);
				flag = (frameSettingsHistory.customMask.mask != historyContainer.frameSettingsMask.mask);
				frameSettingsHistory.customMask = historyContainer.frameSettingsMask;
			}
			frameSettingsHistory.overridden = aggregatedFrameSettings;
			FrameSettings.Sanitize(ref aggregatedFrameSettings, camera, supportedFeatures);
			frameSettingsHistory.hasDebug = (frameSettingsHistory.debug != aggregatedFrameSettings);
			flag |= (frameSettingsHistory.sanitazed != aggregatedFrameSettings);
			bool flag2 = !frameSettingsHistory.hasDebug || flag;
			frameSettingsHistory.sanitazed = aggregatedFrameSettings;
			if (flag2)
			{
				frameSettingsHistory.debug = frameSettingsHistory.sanitazed;
			}
			else
			{
				FrameSettings.Sanitize(ref frameSettingsHistory.debug, camera, supportedFeatures);
			}
			aggregatedFrameSettings = frameSettingsHistory.debug;
			historyContainer.frameSettingsHistory = frameSettingsHistory;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0006E61C File Offset: 0x0006C81C
		private static DebugUI.HistoryBoolField GenerateHistoryBoolField(IFrameSettingsHistoryContainer frameSettingsContainer, FrameSettingsField field, FrameSettingsFieldAttribute attribute)
		{
			string str = "";
			for (int i = 0; i < attribute.indentLevel; i++)
			{
				str += "  ";
			}
			return new DebugUI.HistoryBoolField
			{
				displayName = str + attribute.displayedName,
				tooltip = attribute.tooltip,
				getter = (() => frameSettingsContainer.frameSettingsHistory.debug.IsEnabled(field)),
				setter = delegate(bool value)
				{
					FrameSettingsHistory frameSettingsHistory = frameSettingsContainer.frameSettingsHistory;
					frameSettingsHistory.debug.SetEnabled(field, value);
					frameSettingsContainer.frameSettingsHistory = frameSettingsHistory;
				},
				historyGetter = new Func<bool>[]
				{
					() => frameSettingsContainer.frameSettingsHistory.sanitazed.IsEnabled(field),
					() => frameSettingsContainer.frameSettingsHistory.overridden.IsEnabled(field),
					() => HDRenderPipelineGlobalSettings.instance.GetDefaultFrameSettings(frameSettingsContainer.frameSettingsHistory.defaultType).IsEnabled(field)
				}
			};
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x0006E6E4 File Offset: 0x0006C8E4
		private static DebugUI.HistoryEnumField GenerateHistoryEnumField(IFrameSettingsHistoryContainer frameSettingsContainer, FrameSettingsField field, FrameSettingsFieldAttribute attribute, Type autoEnum)
		{
			string str = "";
			for (int i = 0; i < attribute.indentLevel; i++)
			{
				str += "  ";
			}
			DebugUI.HistoryEnumField historyEnumField = new DebugUI.HistoryEnumField();
			historyEnumField.displayName = str + attribute.displayedName;
			historyEnumField.tooltip = attribute.tooltip;
			historyEnumField.getter = delegate()
			{
				if (!frameSettingsContainer.frameSettingsHistory.debug.IsEnabled(field))
				{
					return 0;
				}
				return 1;
			};
			historyEnumField.setter = delegate(int value)
			{
				FrameSettingsHistory frameSettingsHistory = frameSettingsContainer.frameSettingsHistory;
				frameSettingsHistory.debug.SetEnabled(field, value == 1);
				frameSettingsContainer.frameSettingsHistory = frameSettingsHistory;
			};
			historyEnumField.autoEnum = autoEnum;
			historyEnumField.getIndex = delegate()
			{
				if (!frameSettingsContainer.frameSettingsHistory.debug.IsEnabled(field))
				{
					return 0;
				}
				return 1;
			};
			historyEnumField.setIndex = delegate(int a)
			{
			};
			historyEnumField.historyIndexGetter = new Func<int>[]
			{
				delegate()
				{
					if (!frameSettingsContainer.frameSettingsHistory.sanitazed.IsEnabled(field))
					{
						return 0;
					}
					return 1;
				},
				delegate()
				{
					if (!frameSettingsContainer.frameSettingsHistory.overridden.IsEnabled(field))
					{
						return 0;
					}
					return 1;
				},
				delegate()
				{
					if (!HDRenderPipelineGlobalSettings.instance.GetDefaultFrameSettings(frameSettingsContainer.frameSettingsHistory.defaultType).IsEnabled(field))
					{
						return 0;
					}
					return 1;
				}
			};
			return historyEnumField;
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0006E7E8 File Offset: 0x0006C9E8
		private static ObservableList<DebugUI.Widget> GenerateHistoryArea(IFrameSettingsHistoryContainer frameSettingsContainer, int groupIndex)
		{
			if (!FrameSettingsHistory.attributesGroup.ContainsKey(groupIndex) || FrameSettingsHistory.attributesGroup[groupIndex] == null)
			{
				Dictionary<int, IOrderedEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>>> dictionary = FrameSettingsHistory.attributesGroup;
				int groupIndex2 = groupIndex;
				Dictionary<FrameSettingsField, FrameSettingsFieldAttribute> dictionary2 = FrameSettingsHistory.attributes;
				IOrderedEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>> value;
				if (dictionary2 == null)
				{
					value = null;
				}
				else
				{
					IEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>> enumerable = dictionary2.Where(delegate(KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute> pair)
					{
						FrameSettingsFieldAttribute value2 = pair.Value;
						return value2 != null && value2.group == groupIndex;
					});
					if (enumerable == null)
					{
						value = null;
					}
					else
					{
						value = from pair in enumerable
						orderby pair.Value.orderInGroup
						select pair;
					}
				}
				dictionary[groupIndex2] = value;
			}
			if (!FrameSettingsHistory.attributesGroup.ContainsKey(groupIndex))
			{
				throw new ArgumentException("Unknown groupIndex");
			}
			ObservableList<DebugUI.Widget> observableList = new ObservableList<DebugUI.Widget>();
			foreach (KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute> keyValuePair in FrameSettingsHistory.attributesGroup[groupIndex])
			{
				switch (keyValuePair.Value.type)
				{
				case FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox:
					observableList.Add(FrameSettingsHistory.GenerateHistoryBoolField(frameSettingsContainer, keyValuePair.Key, keyValuePair.Value));
					break;
				case FrameSettingsFieldAttribute.DisplayType.BoolAsEnumPopup:
					observableList.Add(FrameSettingsHistory.GenerateHistoryEnumField(frameSettingsContainer, keyValuePair.Key, keyValuePair.Value, FrameSettingsHistory.RetrieveEnumTypeByField(keyValuePair.Key)));
					break;
				}
			}
			return observableList;
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x0006E94C File Offset: 0x0006CB4C
		private static DebugUI.Widget[] GenerateFrameSettingsPanelContent(IFrameSettingsHistoryContainer frameSettingsContainer)
		{
			DebugUI.Widget[] array = new DebugUI.Widget[FrameSettingsHistory.foldoutNames.Length];
			for (int i = 0; i < FrameSettingsHistory.foldoutNames.Length; i++)
			{
				array[i] = new DebugUI.Foldout(FrameSettingsHistory.foldoutNames[i], FrameSettingsHistory.GenerateHistoryArea(frameSettingsContainer, i), FrameSettingsHistory.columnNames, FrameSettingsHistory.columnTooltips);
			}
			return array;
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0006E99C File Offset: 0x0006CB9C
		private static void GenerateFrameSettingsPanel(string menuName, IFrameSettingsHistoryContainer frameSettingsContainer)
		{
			List<DebugUI.Widget> list = new List<DebugUI.Widget>();
			list.AddRange(FrameSettingsHistory.GenerateFrameSettingsPanelContent(frameSettingsContainer));
			DebugManager.instance.GetPanel(menuName, true, 2, true).children.Add(list.ToArray());
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0006E9D9 File Offset: 0x0006CBD9
		private static Type RetrieveEnumTypeByField(FrameSettingsField field)
		{
			if (field == FrameSettingsField.LitShaderMode)
			{
				return typeof(LitShaderMode);
			}
			throw new ArgumentException("Unknown enum type for this field");
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0006E9F3 File Offset: 0x0006CBF3
		public static IDebugData RegisterDebug(IFrameSettingsHistoryContainer frameSettingsContainer, bool sceneViewCamera = false)
		{
			FrameSettingsHistory.GenerateFrameSettingsPanel(frameSettingsContainer.panelName, frameSettingsContainer);
			FrameSettingsHistory.containers.Add(frameSettingsContainer);
			return frameSettingsContainer;
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0006EA0E File Offset: 0x0006CC0E
		public static void UnRegisterDebug(IFrameSettingsHistoryContainer container)
		{
			DebugManager.instance.RemovePanel(container.panelName);
			FrameSettingsHistory.containers.Remove(container);
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0006EA2C File Offset: 0x0006CC2C
		public static bool IsRegistered(IFrameSettingsHistoryContainer container, bool sceneViewCamera = false)
		{
			return sceneViewCamera || FrameSettingsHistory.containers.Contains(container);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x0006EA3E File Offset: 0x0006CC3E
		internal void TriggerReset()
		{
			this.debug = this.sanitazed;
			this.hasDebug = false;
		}

		// Token: 0x0400153D RID: 5437
		internal static readonly string[] foldoutNames = new string[]
		{
			"Rendering",
			"Lighting",
			"Async Compute",
			"Light Loop"
		};

		// Token: 0x0400153E RID: 5438
		private static readonly string[] columnNames = new string[]
		{
			"Debug",
			"Sanitized",
			"Overridden",
			"Default"
		};

		// Token: 0x0400153F RID: 5439
		private static readonly string[] columnTooltips = new string[]
		{
			"Displays Frame Setting values you can modify for the selected Camera.",
			"Displays the Frame Setting values that the selected Camera uses after Unity checks to see if your HDRP Asset supports them.",
			"Displays the Frame Setting values that the selected Camera overrides.",
			"Displays the default Frame Setting values in your current HDRP Asset."
		};

		// Token: 0x04001540 RID: 5440
		private static readonly Dictionary<FrameSettingsField, FrameSettingsFieldAttribute> attributes;

		// Token: 0x04001541 RID: 5441
		private static Dictionary<int, IOrderedEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>>> attributesGroup = new Dictionary<int, IOrderedEnumerable<KeyValuePair<FrameSettingsField, FrameSettingsFieldAttribute>>>();

		// Token: 0x04001542 RID: 5442
		internal static HashSet<IFrameSettingsHistoryContainer> containers = new HashSet<IFrameSettingsHistoryContainer>();

		// Token: 0x04001543 RID: 5443
		public FrameSettingsRenderType defaultType;

		// Token: 0x04001544 RID: 5444
		public FrameSettings overridden;

		// Token: 0x04001545 RID: 5445
		public FrameSettingsOverrideMask customMask;

		// Token: 0x04001546 RID: 5446
		public FrameSettings sanitazed;

		// Token: 0x04001547 RID: 5447
		public FrameSettings debug;

		// Token: 0x04001548 RID: 5448
		private bool hasDebug;

		// Token: 0x04001549 RID: 5449
		private static bool s_PossiblyInUse;
	}
}
