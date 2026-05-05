using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020000A5 RID: 165
	public class DropdownField : PopupField<string>
	{
		// Token: 0x060005F7 RID: 1527 RVA: 0x000168F2 File Offset: 0x00014AF2
		public DropdownField() : this(null)
		{
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000168FD File Offset: 0x00014AFD
		public DropdownField(string label) : base(label)
		{
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00016908 File Offset: 0x00014B08
		public DropdownField(List<string> choices, string defaultValue, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null) : this(null, choices, defaultValue, formatSelectedValueCallback, formatListItemCallback)
		{
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00016918 File Offset: 0x00014B18
		public DropdownField(string label, List<string> choices, string defaultValue, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null) : base(label, choices, defaultValue, formatSelectedValueCallback, formatListItemCallback)
		{
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00016929 File Offset: 0x00014B29
		public DropdownField(List<string> choices, int defaultIndex, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null) : this(null, choices, defaultIndex, formatSelectedValueCallback, formatListItemCallback)
		{
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00016939 File Offset: 0x00014B39
		public DropdownField(string label, List<string> choices, int defaultIndex, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null) : base(label, choices, defaultIndex, formatSelectedValueCallback, formatListItemCallback)
		{
		}

		// Token: 0x020000A6 RID: 166
		public new class UxmlFactory : UxmlFactory<DropdownField, DropdownField.UxmlTraits>
		{
		}

		// Token: 0x020000A7 RID: 167
		public new class UxmlTraits : BaseField<string>.UxmlTraits
		{
			// Token: 0x060005FE RID: 1534 RVA: 0x00016954 File Offset: 0x00014B54
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				DropdownField dropdownField = (DropdownField)ve;
				List<string> list = BaseField<string>.UxmlTraits.ParseChoiceList(this.m_Choices.GetValueFromBag(bag, cc));
				bool flag = list != null;
				if (flag)
				{
					dropdownField.choices = list;
				}
				dropdownField.index = this.m_Index.GetValueFromBag(bag, cc);
			}

			// Token: 0x0400028A RID: 650
			private UxmlIntAttributeDescription m_Index = new UxmlIntAttributeDescription
			{
				name = "index",
				defaultValue = -1
			};

			// Token: 0x0400028B RID: 651
			private UxmlStringAttributeDescription m_Choices = new UxmlStringAttributeDescription
			{
				name = "choices"
			};
		}
	}
}
