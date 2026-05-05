using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000024 RID: 36
	[AttributeUsage(AttributeTargets.Field)]
	internal class FrameSettingsFieldAttribute : Attribute
	{
		// Token: 0x0600004B RID: 75 RVA: 0x000044A0 File Offset: 0x000026A0
		public static Dictionary<FrameSettingsField, string> GetEnumNameMap()
		{
			if (FrameSettingsFieldAttribute.s_FrameSettingsEnumNameMap == null)
			{
				FrameSettingsFieldAttribute.s_FrameSettingsEnumNameMap = new Dictionary<FrameSettingsField, string>();
				Type typeFromHandle = typeof(FrameSettingsField);
				foreach (string text in Enum.GetNames(typeFromHandle))
				{
					if (typeFromHandle.GetField(text).GetCustomAttribute<ObsoleteAttribute>() == null)
					{
						FrameSettingsFieldAttribute.s_FrameSettingsEnumNameMap.Add((FrameSettingsField)Enum.Parse(typeFromHandle, text), text);
					}
				}
			}
			return FrameSettingsFieldAttribute.s_FrameSettingsEnumNameMap;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000450C File Offset: 0x0000270C
		static FrameSettingsFieldAttribute()
		{
			FrameSettingsFieldAttribute.GetEnumNameMap();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004514 File Offset: 0x00002714
		public FrameSettingsFieldAttribute(int group, FrameSettingsField autoName = FrameSettingsField.None, string displayedName = null, string tooltip = null, FrameSettingsFieldAttribute.DisplayType type = FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, Type targetType = null, FrameSettingsField[] positiveDependencies = null, FrameSettingsField[] negativeDependencies = null, int customOrderInGroup = -1)
		{
			if (string.IsNullOrEmpty(displayedName))
			{
				if (!FrameSettingsFieldAttribute.s_FrameSettingsEnumNameMap.TryGetValue(autoName, out displayedName))
				{
					displayedName = autoName.ToString();
				}
				displayedName = displayedName.CamelToPascalCaseWithSpace(true);
			}
			this.group = group;
			if (customOrderInGroup != -1)
			{
				FrameSettingsFieldAttribute.autoOrder = customOrderInGroup;
			}
			this.orderInGroup = FrameSettingsFieldAttribute.autoOrder++;
			this.displayedName = displayedName;
			this.type = type;
			this.targetType = targetType;
			this.dependencySeparator = ((positiveDependencies != null) ? positiveDependencies.Length : 0);
			this.dependencies = new FrameSettingsField[this.dependencySeparator + ((negativeDependencies != null) ? negativeDependencies.Length : 0)];
			if (positiveDependencies != null)
			{
				positiveDependencies.CopyTo(this.dependencies, 0);
			}
			if (negativeDependencies != null)
			{
				negativeDependencies.CopyTo(this.dependencies, this.dependencySeparator);
			}
			FrameSettingsField[] array = this.dependencies;
			this.indentLevel = ((array != null) ? array.Length : 0);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004600 File Offset: 0x00002800
		public bool IsNegativeDependency(FrameSettingsField frameSettingsField)
		{
			return Array.FindIndex<FrameSettingsField>(this.dependencies, (FrameSettingsField fsf) => fsf == frameSettingsField) >= this.dependencySeparator;
		}

		// Token: 0x040000A1 RID: 161
		public readonly FrameSettingsFieldAttribute.DisplayType type;

		// Token: 0x040000A2 RID: 162
		public readonly string displayedName;

		// Token: 0x040000A3 RID: 163
		public readonly string tooltip;

		// Token: 0x040000A4 RID: 164
		public readonly int group;

		// Token: 0x040000A5 RID: 165
		public readonly int orderInGroup;

		// Token: 0x040000A6 RID: 166
		public readonly Type targetType;

		// Token: 0x040000A7 RID: 167
		public readonly int indentLevel;

		// Token: 0x040000A8 RID: 168
		public readonly FrameSettingsField[] dependencies;

		// Token: 0x040000A9 RID: 169
		private readonly int dependencySeparator;

		// Token: 0x040000AA RID: 170
		private static int autoOrder;

		// Token: 0x040000AB RID: 171
		private static Dictionary<FrameSettingsField, string> s_FrameSettingsEnumNameMap;

		// Token: 0x0200024F RID: 591
		public enum DisplayType
		{
			// Token: 0x040019FD RID: 6653
			BoolAsCheckbox,
			// Token: 0x040019FE RID: 6654
			BoolAsEnumPopup,
			// Token: 0x040019FF RID: 6655
			Others
		}
	}
}
