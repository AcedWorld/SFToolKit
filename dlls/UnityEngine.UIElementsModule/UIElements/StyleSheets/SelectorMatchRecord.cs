using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000492 RID: 1170
	internal struct SelectorMatchRecord
	{
		// Token: 0x060024A0 RID: 9376 RVA: 0x000995FA File Offset: 0x000977FA
		public SelectorMatchRecord(StyleSheet sheet, int styleSheetIndexInStack)
		{
			this = default(SelectorMatchRecord);
			this.sheet = sheet;
			this.styleSheetIndexInStack = styleSheetIndexInStack;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x00099614 File Offset: 0x00097814
		public static int Compare(SelectorMatchRecord a, SelectorMatchRecord b)
		{
			bool flag = a.sheet.isDefaultStyleSheet != b.sheet.isDefaultStyleSheet;
			int result;
			if (flag)
			{
				result = (a.sheet.isDefaultStyleSheet ? -1 : 1);
			}
			else
			{
				int num = a.complexSelector.specificity.CompareTo(b.complexSelector.specificity);
				bool flag2 = num == 0;
				if (flag2)
				{
					num = a.styleSheetIndexInStack.CompareTo(b.styleSheetIndexInStack);
				}
				bool flag3 = num == 0;
				if (flag3)
				{
					num = a.complexSelector.orderInStyleSheet.CompareTo(b.complexSelector.orderInStyleSheet);
				}
				result = num;
			}
			return result;
		}

		// Token: 0x04001191 RID: 4497
		public StyleSheet sheet;

		// Token: 0x04001192 RID: 4498
		public int styleSheetIndexInStack;

		// Token: 0x04001193 RID: 4499
		public StyleComplexSelector complexSelector;
	}
}
