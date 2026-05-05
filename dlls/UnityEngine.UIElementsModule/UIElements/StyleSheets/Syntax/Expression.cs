using System;

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	// Token: 0x020004A8 RID: 1192
	internal class Expression
	{
		// Token: 0x06002523 RID: 9507 RVA: 0x0009CB1D File Offset: 0x0009AD1D
		public Expression(ExpressionType type)
		{
			this.type = type;
			this.combinator = ExpressionCombinator.None;
			this.multiplier = new ExpressionMultiplier(ExpressionMultiplierType.None);
			this.subExpressions = null;
			this.keyword = null;
		}

		// Token: 0x040011E4 RID: 4580
		public ExpressionType type;

		// Token: 0x040011E5 RID: 4581
		public ExpressionMultiplier multiplier;

		// Token: 0x040011E6 RID: 4582
		public DataType dataType;

		// Token: 0x040011E7 RID: 4583
		public ExpressionCombinator combinator;

		// Token: 0x040011E8 RID: 4584
		public Expression[] subExpressions;

		// Token: 0x040011E9 RID: 4585
		public string keyword;
	}
}
