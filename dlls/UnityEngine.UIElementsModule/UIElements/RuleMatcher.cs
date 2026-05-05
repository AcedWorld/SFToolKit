using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000382 RID: 898
	internal struct RuleMatcher
	{
		// Token: 0x06001E5F RID: 7775 RVA: 0x00075757 File Offset: 0x00073957
		public RuleMatcher(StyleSheet sheet, StyleComplexSelector complexSelector, int styleSheetIndexInStack)
		{
			this.sheet = sheet;
			this.complexSelector = complexSelector;
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x00075768 File Offset: 0x00073968
		public override string ToString()
		{
			return this.complexSelector.ToString();
		}

		// Token: 0x04000C9F RID: 3231
		public StyleSheet sheet;

		// Token: 0x04000CA0 RID: 3232
		public StyleComplexSelector complexSelector;
	}
}
